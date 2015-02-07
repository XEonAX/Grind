#app.rb
#try https://github.com/bbatsov/ruby-style-guide
require 'sinatra'
require "sinatra/reloader"
require 'sinatra/activerecord'
require 'json'

set :database, 'mysql://root@localhost/grindDB'

class Person < ActiveRecord::Base
end

class Unread_Object < ActiveRecord::Base
  belongs_to :person
end

class Developer < Person
  has_many :tasks 
end
class Reviewer < Person
  has_many :tasks
  has_many :unread_objects
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
end

class Document < ActiveRecord::Base
  belongs_to :task
  belongs_to :developer
end

class Comment < ActiveRecord::Base
  belongs_to :task
  has_many :comments
end

get '/' do
  "Hola World!"
end

get '/tasks' do
  Task.all.to_json
end

get '/taskslist' do
  #Task.includes([:developer, :reviewer]).all.explain
  Task.all(:joins => :people, :select => "tasks.*, people.*").to_json
  #Task.includes(:reviewer).all.to_json
end

get '/people' do
  Person.all.to_json
end

get '/person/:id' do
  Person.where(["id = ?", params[:id]]).to_json
end

get '/task/:id' do
  Task.where(["id = ?", params[:id]]).to_json
end

get '/document/:id' do
  Document.where(["id = ?", params[:id]]).to_json
end

get '/task/:id/documents' do
#  Task.where(["id = ?", params[:id]]).document.all.to_json
#  Document.where(["task_id = ?", params[:id]]).all.to_json
  Task.find(params[:id]).documents.all.to_json
end


get '/make' do
  person1 = Person.create(  
                          :name => "AEonAX",
                          :trigram =>"anx",
                          :state => "Active",
                          :level => "Master"
                         )
  person2 = Person.create(
                          :name => "XEonAX",
                          :trigram =>"xnx",
                          :state => "Inactive",
                          :level => "User"
                         )
  person3 = Person.create(  
                          :name => "ZEonAX",
                          :trigram =>"znx",
                          :state => "Active",
                          :level => "User"
                         )
  person4 = Person.create(
                          :name => "LEonAX",
                          :trigram =>"lnx",
                          :state => "Inactive",
                          :level => "Master"
                         )
  task1 = Task.create(  
                      :name => "IR-000001V0R2000",
                      :description => "The Very First Incident Report",
                      :task_status => "Opened",
                      :task_type => "Internal",
                      :developer_id => person2.id,
                      :reviewer_id => person1.id,
                      :internal_object_id =>'0000.0000.0000.0001'
                     )
  task2 = Task.create(
                      :name => "IR-000002V0R2000",
                      :description => "Second Incident Report",
                      :task_status => "Tech. Anal.",
                      :task_type => "External",
                      :developer_id => person2.id,
                      :reviewer_id => person1.id,
                      :internal_object_id =>'0000.0000.0000.0002'                     
                     )
  task3 = Task.create(
                      :name => "IR-000003V0R2000",
                      :description => "Another Incident Report",
                      :task_status => "Under Corr.",
                      :task_type => "External",
                      :developer_id => person3.id,
                      :reviewer_id => person1.id,
                      :internal_object_id =>'0000.0000.0000.0003'                      
                     ) 
  document1 = Document.create(
                              :name => "FirstDoku",
                              :path => "\\XEON-NB\Test\FiddlerRoot.cer",
                              :task_id => task1.id,
                              :developer_id => task1.developer.id,
                              :data => Task.all.to_json #SomeBinaryData
                             )
end