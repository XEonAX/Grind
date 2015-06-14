# app.rb
# try https://github.com/bbatsov/ruby-style-guide
require 'sinatra/base'
require 'sinatra/reloader'
require 'sinatra/activerecord'
require 'json'
require 'multi_json'
require 'rack/contrib'
require 'sinatra-websocket'
require 'thin'
require 'bcrypt'

module GrindServer

ActiveRecord::Base.default_timezone = :local
# DB Start
ActiveRecord::Base.establish_connection(
  adapter: 'sqlite3',
  database: 'Grind.Server.sqlite'
)

def self.realtime_channel
  @realtime_channel ||= EventMachine::Channel.new
end

def self.online_people
  @online_people ||= []
end



# Alternate Code Begin
# set :database, 'mysql://root@localhost/grindDB'
# ActiveRecord::Base.logger.level = 1
# Alternate Code End
# DB End

class ExceptionHandling
  def initialize(app)
    @app = app
  end

  def call(env)
    @app.call env
    rescue => ex
      env['rack.errors'].puts ex
      env['rack.errors'].puts ex.backtrace.join("\n")
      env['rack.errors'].flush

      hash = { Message: ex.to_s }
      [500, { 'Content-Type' => 'application/json' }, [MultiJson.dump(hash)]]
  end
end

def self.timestamp
  Time.now.strftime('%H:%M:%S')
end

# {Models}

class Person < ActiveRecord::Base
  has_many :unread_objects
  has_many :tasks
  
  include BCrypt
  # attr_accessor :password_hash, :token

  def password
    @password ||= Password.new(password_hash)
  end

  def password=(password)
    self.password_hash = BCrypt::Password.create(password)
  end
  
  def generate_token!
    self.token = SecureRandom.urlsafe_base64(64)
    ActiveRecord::Base.record_timestamps = false
    self.save! #persist
    ActiveRecord::Base.record_timestamps = true
  end

end

class Unread_Object < ActiveRecord::Base
  belongs_to :person, counter_cache: true
end

class Developer < Person
end
class Reviewer < Person
end

class Task < ActiveRecord::Base
  belongs_to :developer, counter_cache: :work_tasks_count
  belongs_to :reviewer, counter_cache: :review_tasks_count
  has_many :documents
  after_save :add_task_to_unread_objects

  protected

  def add_task_to_unread_objects
    Person.find_each do |person|
      Unread_Object.create(
        person_id: person.id,
        internal_object_id: self.id,
        unread_cause: 'Create')
    end

    GrindServer.realtime_channel.push ({
        'nickname' => 'Server',
        'message' => "New Unread Item : Task #{self.id}" ,
        'timestamp' => GrindServer.timestamp }.to_json)
  end

  public

  def task_params
    params.require(:task).permit(:name, :task_status, :bug_type)
  end
end

class Document < ActiveRecord::Base
  belongs_to :task, counter_cache: true
  belongs_to :developer, counter_cache: true
end

class Comment < ActiveRecord::Base
  belongs_to :task, counter_cache: true
  has_many :comments
end


class Sender < Person
end
class Receiver < Person
end
class Message < ActiveRecord::Base
  belongs_to :sender
  belongs_to :receiver
  belongs_to :parent, :class_name => "Message", :foreign_key => "parent_message_id"
  has_many :child_messages, :class_name => "Message",  :foreign_key => "parent_message_id"
end

# }{Models}

EventMachine.run do
  Signal.trap("INT")  { EventMachine.stop }
  Signal.trap("TERM") { EventMachine.stop }
  #GrindServer.realtime_channel = EventMachine::Channel.new
  class App < Sinatra::Base
    Time.zone = "Kolkata"
    # use Rack::PostBodyContentTypeParser
    set :server, 'thin'
    set :sockets, []
    use ExceptionHandling
    
    before do
      content_type 'application/json'
      begin
        if request.body.read(1)
          request.body.rewind
          @JSON_params = JSON.parse request.body.read, { symbolize_names: true }
        end
      rescue JSON::ParserError => e
        request.body.rewind
        puts "The body #{request.body.read} was not JSON"
        halt 500 
      end
    end

    configure do

      # Don't log them. We'll do that ourself
      set :dump_errors, false

      # Don't capture any errors. Throw them up the stack
      set :raise_errors, true

      # Disable internal middleware for presenting errors
      # as useful HTML pages
      set :show_exceptions, false
    end
    # end

    post '/login' do
      # paramxs = @JSON_params[:person]
      if !@JSON_params[:person][:trigram].present? or !@JSON_params[:person][:password].present?
        halt 403, { Error: 'Trigram/Password not specified.' }.to_json
      end
      person = Person.where(['trigram = ?', @JSON_params[:person][:trigram]]).first
      if person.password == @JSON_params[:person][:password] #compare the hash to the string; magic
        person.generate_token!
        {token: person.token}.to_json # make sure you give hte person the token
      else
         halt 403, {Error: "Invalid Credentials"}.to_json
        #tell the person they aren't logged in
      end
    end
    
    def authenticate!
      @person = Person.where(['token = ?', @JSON_params[:token]]).first
      puts "#{@person.name} authenticated!"
      halt 403, {Error: "Invalid Token"}.to_json unless @person
    end

    post "/protected" do
      authenticate!
      puts @person
    end

    get '/' do
      'Hola World!'
    end

    # get '/tasks' do
    # Task.all.to_json
    # end

    # {GET Lists}
    get '/tasks' do
      Task.all.to_json
    end

    get '/taskslist' do
      Task.select(:id, :name, :task_status, :is_bug, :title, :bug_type, :target_date, :created_at, :updated_at, :approved, :developer_id, :reviewer_id).all.to_json
    end

    get '/timestamps/task' do
      Task.select(:id, :created_at, :updated_at).all.to_json
    end

    get '/people' do
      Person.all.to_json
    end

    get '/timestamps/person' do
      Person.select(:id, :created_at, :updated_at).all.to_json
    end
    # }{GET Lists}

    # {Person CRUD}
    post '/person' do
      authenticate!
      @person = Person.new(@JSON_params[:person].except(:id, :created_at, :updated_at,:password_hash,:token))
      # @person.password = @JSON_params[:person][:password]
      # @person.save
      redirect "person/#{@person.id}" if @person.save
    end

    get '/person/:id' do
      Person.where(['id = ?', params[:id]]).first.to_json
    end

    put '/person/:id' do
      authenticate!
      @person = Person.find(params[:id])
      if @person.update(@JSON_params[:person].except(:unread_objects_count, :documents_count, :tasks_count, :password_hash, :token))
        redirect "person/#{@person.id}"
      end
    end

    delete '/person/:id' do
      authenticate!
      @person = Person.find(params[:id])
      if @person.destroy
        content_type :json
        { Status: 'Person with ID ' + params[:id] + ' destroyed' }.to_json
      end
    end
    # }{Person CRUD}

    # {Task CRUD}
    post '/task' do
      authenticate!
      @task = Task.new(@JSON_params[:task].except(:id, :documents, :created_at, :updated_at))
      redirect "task/#{@task.id}" if @task.save
    end

    post '/tasks' do
      authenticate!
      tasks=Task.create(@JSON_params[:task])
      { Status:  'Tasks created.' }.to_json
      #@tasks = Task.new(@JSON_params[:task])
      #redirect 'task/#{@tasks.id}' if @tasks.save
    end


    get '/task/:id' do
      Task.includes(:documents).where(['id = ?', params[:id]]).first.as_json(include: [:documents]).to_json
    end

    put '/task/:id' do
      @task = Task.find(params[:id])
      redirect "task/#{@task.id}" if @task.update(@JSON_params[:task].except(:documents, :created_at, :updated_at))
    end

    delete '/task/:id' do
      authenticate!
      @task = Task.find(params[:id])
      if @task.destroy
        content_type :json
        { Status: 'Task with ID ' + params[:id] + ' destroyed' }.to_json
      end
    end

    get '/timestamp/task/:id' do
      Task.select(:id, :created_at, :updated_at).where(['id = ?', params[:id]]).first.to_json
    end
    # }{Task CRUD}

    # {GET Document}
    get '/document/:id' do
      Document.where(['id = ?', params[:id]]).first.to_json
    end

    get '/task/:id/documents' do
      # Task.where(['id = ?', params[:id]]).document.all.to_json
      # Document.where(['task_id = ?', params[:id]]).all.to_json
      Task.find(params[:id]).documents.all.to_json
    end
    # }{GET Document}


    get '/people/online' do
      onlinepeople = GrindServer.online_people.map do
                      |hash|{ws_oid: hash[:ws_oid],
                             person_id: hash[:person_id],
                             person_name: hash[:person_name],
                             person_trigram: hash[:person_trigram]}
                     end
      onlinepeople.to_json
      # GrindServer.online_people.inspect
    end
      
    error ActiveRecord::RecordNotFound do
      status 404
    end

  end

  

  EventMachine::WebSocket.start(host: '0.0.0.0', port: 8080) do |websock|
    websock.onopen do
      puts 'New Connection Opened'
      cookies = CGI::Cookie::parse( websock.request["cookie"])
      person = Person.where(['token = ?', cookies["token"]]).first
      if person  
      puts "#{person.name} authenticated!"
      # person=person.attributes.merge(websock.attributes)
      # Subscribe the new user to the GrindServer.realtime_channel with the callback function for the push action
      subscriber = GrindServer.realtime_channel.subscribe { |msg| websock.send msg }
      GrindServer.online_people << {:ws_oid => websock.object_id,
                                    :websocket => websock,
                                    :person_id => person.id,
                                    :person_name => person.name,
                                    :person_trigram => person.trigram,
                                    :subscriber => subscriber}
      # Add the new user to the user list
      # Push the last messages to the user
      # message.all.each do |message|
        # websock.send message.to_json
      # end
      # Broadcast the notification to all users
      onlinepeople = GrindServer.online_people.map do
                      |hash|{ws_oid: hash[:ws_oid],
                             person_id: hash[:person_id],
                             person_name: hash[:person_name],
                             person_trigram: hash[:person_trigram]}
                     end
      # Send last 10 messages to the newly connected user
      websock.send Message.where({ receiver_id: [0, person.id]}).last(10).to_json
      
      GrindServer.realtime_channel.push ({
        'id' => 0,
        'sender_id' => 0,
        'messagetext' => "#{person.name} joined. <$<^<#<#{onlinepeople.length}>#>^>$> users in chat",
        'users' => onlinepeople,
        'metadata' => person.trigram,
        }.to_json)

      else
        websock.close_websocket(code = nil, body = {Error: "Invalid Token"}.to_json)      
      end
    end

    websock.onmessage do |msg|
      puts 'Message received '
      # # Add the timestamp to the message
      @message = Message.new(JSON.parse(msg).except('id', 'created_at','messages','users','metadata','created_at','updated_at','sender_id'))
      @message.sender_id = GrindServer.online_people.find{ |onli| onli[:ws_oid] == websock.object_id }[:person_id]
      @message.save
      # message = JSON.parse(msg).merge('timestamp' => GrindServer.timestamp).to_json
      GrindServer.realtime_channel.push @message.to_json
      # # append the message at the end of the queue
      # @messages << message
      # @messages.shift if @messages.length > 10
      # # puts GrindServer.realtime_channel.inspect
      # # Broadcast the message to all users connected to the GrindServer.realtime_channel
      # GrindServer.realtime_channel.push message
    end

    websock.onclose do
      puts 'Websocket Closed'
      unless GrindServer.online_people.select {|onli|
          onli[:ws_oid] == websock.object_id
          }.empty?
        GrindServer.realtime_channel.unsubscribe(
          GrindServer.online_people.find{ |onli| onli[:ws_oid] == websock.object_id }[:subscriber])
        GrindServer.online_people.delete_if { |onli| onli[:ws_oid] == websock.object_id }
        # Broadcast the notification to all users
        onlinepeople = GrindServer.online_people.map do
                        |hash|{ws_oid: hash[:ws_oid],
                               person_id: hash[:person_id],
                               person_name: hash[:person_name],
                               person_trigram: hash[:person_trigram]}
                       end
        GrindServer.realtime_channel.push ({
          'id' => 0,
          'sender_id' => 0,
          'messagetext' => "A user left. <$<^<#<#{onlinepeople.length}>#>^>$> users in chat",
          'users' => onlinepeople,
          'metadata' => "",
          }.to_json)
      end
    end
  end

  Thin::Server.start App, '0.0.0.0', 4567
end
  
end

