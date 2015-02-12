class CreateTasksPeopleDocumentsUnreadsAndComments < ActiveRecord::Migration
  def self.up
    create_table :tasks do |t|
      t.string :name
      t.string :task_status
      t.string :task_type
      t.string :abstract
      t.string :bug_type
      t.string :internal_object_id
      t.boolean :approved
      t.text :description
      t.text :analysis
      t.text :investigation
      t.integer :developer_id
      t.integer :reviewer_id
      t.integer :comments_count 
      t.integer :documents_count 
      t.date :open_date
      t.date :analysis_date
      t.date :promotion_date
      t.date :review_date
      t.date :correction_date
      t.date :collection_date
      t.date :closed_date
      t.date :modified_date
      t.date :target_date      
      t.datetime :created_at
      t.datetime :updated_at
    end
    create_table :people do |t|
      t.string :name
      t.string :trigram
      t.string :state
      t.string :level
      t.string :internal_object_id
      t.integer :unread_objects_count
      t.integer :documents_count
      t.integer :tasks_count
    end
    create_table :documents do |t|
      t.string :name
      t.binary :data
      t.string :path
      t.integer :task_id
      t.integer	:developer_id
      t.string :internal_object_id
      t.datetime :created_at
      t.datetime :updated_at
    end
    create_table :comments do |t|
      t.text :comment
      t.integer :person_id
      t.datetime :created_at
      t.datetime :updated_at
      t.integer :parent_id
      t.integer :task_id
    end
    create_table :unread_objects do |t|
      t.string :person_id
      t.string :internal_object_id
      t.string :unread_cause
      t.datetime :created_at
      t.datetime :updated_at
    end
  end
  
  def self.down
    drop_table :tasks
    drop_table :people
    drop_table :documents
    drop_table :comments
    drop_table :unread_objects
  end
end
