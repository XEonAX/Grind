class CreateTasksPeopleDocumentsUnreadsAndComments < ActiveRecord::Migration
  def self.up
    create_table :tasks do |t|
      t.string :name
      t.integer :task_status
      t.integer :bug_type
      t.string :title
      t.boolean :is_bug
      t.string :internal_object_id
      t.boolean :approved
      t.binary :description, :limit => 10.megabyte
      t.binary :analysis, :limit => 10.megabyte
      t.binary :review, :limit => 10.megabyte
      t.integer :developer_id
      t.integer :reviewer_id
      t.integer :comments_count, :default => 0
      t.integer :documents_count, :default => 0
      t.date :open_date
      t.date :analysis_date
      t.date :review_date
      t.date :correction_date
      t.date :promotion_date
      t.date :collection_date
      t.date :closed_date
      #t.date :modified_date
      t.date :target_date
      t.datetime :created_at
      t.datetime :updated_at
      end
    create_table :people do |t|
      t.string :name
      t.string :trigram, :unique => true
      t.boolean :active
      t.integer :level
      t.string :internal_object_id
      t.integer :unread_objects_count, :default => 0
      t.integer :work_tasks_count, :default => 0
      t.integer :review_tasks_count, :default => 0
      t.integer :documents_count, :default => 0
      t.datetime :created_at
      t.datetime :updated_at
      t.string :password_hash
      t.string :token
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
      t.integer :person_id
      t.string :internal_object_id
      t.string :unread_cause
      t.datetime :created_at
      t.datetime :updated_at
    end
    create_table :messages do |t|
      t.integer :sender_id
      t.integer :receiver_id
      t.datetime :created_at
      t.datetime :updated_at
      t.integer :parent_message_id
      t.string :messagetext
    end  
  end
  
  def self.down
    drop_table :tasks
    drop_table :people
    drop_table :documents
    drop_table :comments
    drop_table :unread_objects
    drop_table :messages
  end
end
