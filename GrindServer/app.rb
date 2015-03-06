#app.rb
#try https://github.com/bbatsov/ruby-style-guide
require 'sinatra'
require "sinatra/reloader"
require 'sinatra/activerecord'
require 'json'
require 'multi_json'
require 'rack/contrib'

use Rack::PostBodyContentTypeParser

set :database, 'mysql://root@localhost/grindDB'
#ActiveRecord::Base.logger.level = 1

#ActiveRecord::Base.connection.execute("set global max_allowed_packet=10000000;")
class App < Sinatra::Application
configure do
 #ActiveRecord::Base.logger.level = 1
# Don't log them. We'll do that ourself
set :dump_errors, false
 
# Don't capture any errors. Throw them up the stack
set :raise_errors, true

# Disable internal middleware for presenting errors
# as useful HTML pages
set :show_exceptions, false
end
end
 
class ExceptionHandling
def initialize(app)
@app = app
end
 
def call(env)
begin
@app.call env
rescue => ex
env['rack.errors'].puts ex
env['rack.errors'].puts ex.backtrace.join("\n")
env['rack.errors'].flush
 
hash = { :message => ex.to_s }
[500, {'Content-Type' => 'application/json'}, [MultiJson.dump(hash)]]
end
end
end
use ExceptionHandling 







class Person < ActiveRecord::Base
  has_many :unread_objects
  has_many :tasks   
end

class Unread_Object < ActiveRecord::Base
  belongs_to :person, counter_cache: true
end

class Developer < Person
end
class Reviewer < Person
end

class Task < ActiveRecord::Base
  belongs_to :developer
  belongs_to :reviewer
  has_many :documents
  after_save :add_task_to_unread_objects
  
  protected
    def add_task_to_unread_objects
      Person.find_each do |person|
        Unread_Object.create(
                              :person_id => person.id,
                              :internal_object_id => self.internal_object_id,
                              :unread_cause => 'Create')
      end
    end
  public  
    def task_params
      params.require(:task).permit(:name, :task_status,:bug_type) 
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



get '/' do
  "Hola World!"
end

# get '/tasks' do
  # Task.all.to_json
# end

get '/tasks' do
  #Task.includes([:developer, :reviewer]).all.to_json
  #Task.joins(:developer,:reviewer).select("*, people.*").to_json
  #Task.includes(:reviewer.name,:developer.name).all.to_json #"undefined method `name' for :reviewer:Symbol"
  #Task.find(:all, :include => {:people => :name}).to_json #Couldn't find all Tasks with 'id': (all, {:include=>{:people=>:name}})
  #Task.includes(:developer,:reviewer).all.as_json(include: [:developer,:reviewer]).to_json
  Task.select(:id,:name,:task_status,:is_bug,:title,:bug_type,:target_date,:created_at,:updated_at,:approved,:developer_id,:reviewer_id,).all.to_json
end

get '/people' do
  Person.all.to_json  
end

get '/person/:id' do
  Person.where(["id = ?", params[:id]]).first.to_json
end


# before do
  # if request.request_method == "POST" and (request.content_type || '').include? "application/json" 
    # request.body.rewind
    # body_parameters = request.body.read
    # parsed = body_parameters && body_parameters.length >= 2 ? JSON.parse(body_parameters, :symbolize_names => true) : nil
    # params.merge!(parsed)
    # end
# end

post '/person' do
  # puts params[:person].except(:id)
  # params[:person].except('id')
  @person = Person.new(params[:person].except('id'))
  if @person.save
    redirect "person/#{@person.id}"
  end  
end

get '/task/:id' do
  # Task.where(["id = ?", params[:id]]).to_json
  # Task.where(["id = ?", params[:id]]).first.to_json
  Task.includes(:developer,:reviewer,:documents).where(["id = ?", params[:id]]).first.as_json(include: [:developer,:reviewer,:documents]).to_json
end


post "/task" do
  # request.body.read
  # hash = JSON.parse(request.body.read)
  # hash.delete("id")
  @task = Task.new(params[:task].except('id','documents','created_at','updated_at'))
  if @task.save
    redirect "task/#{@task.id}"
  end
end


get '/document/:id' do
  Document.where(["id = ?", params[:id]]).first.to_json
end

get '/task/:id/documents' do
  # Task.where(["id = ?", params[:id]]).document.all.to_json
  # Document.where(["task_id = ?", params[:id]]).all.to_json
  Task.find(params[:id]).documents.all.to_json
end


get '/make' do
  person1 = Person.create(  
                          :name => "AEonAX",
                          :trigram =>"anx",
                          :active => true,
                          :level => 0
                         )
  person2 = Person.create(
                          :name => "XEonAX",
                          :trigram =>"xnx",
                          :active => true,
                          :level => 0
                         )
  person3 = Person.create(  
                          :name => "ZEonAX",
                          :trigram =>"znx",
                          :active => true,
                          :level => 0
                         )
  person4 = Person.create(
                          :name => "LEonAX",
                          :trigram =>"lnx",
                          :active => true,
                          :level => 0
                         )
  task1 = Task.create(  
                      :name => "IR-000001V0R2000",
                      :title => "The Very First Incident Report",
                      :task_status => 0,
                      :is_bug => true,
                      :developer_id => person2.id,
                      :reviewer_id => person1.id,
                      :internal_object_id =>'0000.0000.0000.0001',
                      :bug_type => 2,
                      :approved => false,
                      :target_date => DateTime.now,
                      :open_date => DateTime.new(2015,1,3,4,5,6,'+7'),
                      :analysis_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :review_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :correction_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :promotion_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :collection_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :closed_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :approved => false
                     )
  task2 = Task.create(
                      :name => "IR-000002V0R2000",
                      :title => "Second Incident Report",
                      :task_status => 1,
                      :is_bug => true,
                      :developer_id => person2.id,
                      :reviewer_id => person1.id,
                      :internal_object_id =>'0000.0000.0000.0002',
                      :bug_type => 3,
                      :approved => false,
                      :target_date => DateTime.now,
                      :open_date => DateTime.new(2014,2,3,4,5,6,'+7'),
                      :analysis_date => DateTime.new(2014,3,4,4,5,6,'+7'),
                      :review_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :correction_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :promotion_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :collection_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :closed_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :approved => false
                     )
  task3 = Task.create(
                      :name => "IR-000003V0R2000",
                      :title => "Another Incident Report",
                      :task_status => 2,
                      :is_bug => true,
                      :developer_id => person3.id,
                      :reviewer_id => person1.id,
                      :internal_object_id =>'0000.0000.0000.0003',
                      :bug_type => 2,
                      :approved => false,
                      :target_date => DateTime.now,
                      :open_date => DateTime.new(2015,1,1,4,5,6,'+7'),
                      :analysis_date => DateTime.new(2015,2,2,4,5,6,'+7'),
                      :review_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :correction_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :promotion_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :collection_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :closed_date => DateTime.new(2015,1,7,4,5,6,'+7'),
                      :approved => false
                     ) 
  document1 = Document.create(
                              :name => "FirstDoku",
                              :path => "\\XEON-NB\Test\FiddlerRoot.cer",
                              :task_id => task1.id,
                              :developer_id => task1.developer.id,
                              :data => '[]' #SomeBinaryData
                             )
end