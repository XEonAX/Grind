class CreateCoursesAndTeachers < ActiveRecord::Migration
  def self.up
#    create_table :courses do |t|
#      t.string :title
#      t.integer :teacher_id
#    end
#    create_table :teachers do |t|
#      t.string :name
#    end
    create_table :tasks do |t|
      t.string :name
	  t.string :task_status
	  t.string :task_type
      t.text :description
      t.text :analysis
	  t.text :investigation
	  t.integer :developer_id
	  t.integer :reviewer_id
	  t.date :open_date
	  t.date :analysis_date
	  t.date :promotion_date
	  t.date :review_date
	  t.date :correction_date
	  t.date :collection_date
	  t.date :closed_date
	  t.date :modified_date
	  t.date :target_date
	end
    create_table :persons do |t|
      t.string :name
	  t.string :trigram
	  t.string :state
	  t.string :level
    end
    create_table :documents do |t|
      t.string :name
	  t.binary :data
	  t.string :path
	  t.integer :task_id
	  t.integer	:developer_id
	end
    create_table :comments do |t|
      t.text :comment
	  t.integer :person_id
	  t.datetime :comment_timestamp
	  t.integer :replied_to_id
    end
    
    
  end

  def self.down
#    drop_table :courses
#    drop_table :teachers

  end
end
