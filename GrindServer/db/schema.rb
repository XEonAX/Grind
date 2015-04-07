# encoding: UTF-8
# This file is auto-generated from the current state of the database. Instead
# of editing this file, please use the migrations feature of Active Record to
# incrementally modify your database, and then regenerate this schema definition.
#
# Note that this schema.rb definition is the authoritative source for your
# database schema. If you need to create the application database on another
# system, you should be using db:schema:load, not running all the migrations
# from scratch. The latter is a flawed and unsustainable approach (the more migrations
# you'll amass, the slower it'll run and the greater likelihood for issues).
#
# It's strongly recommended that you check this file into your version control system.

ActiveRecord::Schema.define(version: 20150131130010) do

  create_table "comments", force: :cascade do |t|
    t.text     "comment"
    t.integer  "person_id"
    t.datetime "created_at"
    t.datetime "updated_at"
    t.integer  "parent_id"
    t.integer  "task_id"
  end

  create_table "documents", force: :cascade do |t|
    t.string   "name"
    t.binary   "data"
    t.string   "path"
    t.integer  "task_id"
    t.integer  "developer_id"
    t.string   "internal_object_id"
    t.datetime "created_at"
    t.datetime "updated_at"
  end

  create_table "people", force: :cascade do |t|
    t.string   "name"
    t.string   "trigram"
    t.boolean  "active"
    t.integer  "level"
    t.string   "internal_object_id"
    t.integer  "unread_objects_count"
    t.integer  "documents_count"
    t.integer  "tasks_count"
    t.datetime "created_at"
    t.datetime "updated_at"
  end

  create_table "tasks", force: :cascade do |t|
    t.string   "name"
    t.integer  "task_status"
    t.integer  "bug_type"
    t.string   "title"
    t.boolean  "is_bug"
    t.string   "internal_object_id"
    t.boolean  "approved"
    t.binary   "description"
    t.binary   "analysis"
    t.binary   "review"
    t.integer  "developer_id"
    t.integer  "reviewer_id"
    t.integer  "comments_count"
    t.integer  "documents_count"
    t.date     "open_date"
    t.date     "analysis_date"
    t.date     "review_date"
    t.date     "correction_date"
    t.date     "promotion_date"
    t.date     "collection_date"
    t.date     "closed_date"
    t.date     "target_date"
    t.datetime "created_at"
    t.datetime "updated_at"
  end

  create_table "unread_objects", force: :cascade do |t|
    t.string   "person_id"
    t.string   "internal_object_id"
    t.string   "unread_cause"
    t.datetime "created_at"
    t.datetime "updated_at"
  end

end
