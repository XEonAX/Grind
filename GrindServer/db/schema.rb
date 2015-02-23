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
    t.text     "comment",    limit: 65535
    t.integer  "person_id",  limit: 4
    t.datetime "created_at"
    t.datetime "updated_at"
    t.integer  "parent_id",  limit: 4
    t.integer  "task_id",    limit: 4
  end

  create_table "documents", force: :cascade do |t|
    t.string   "name",               limit: 255
    t.binary   "data",               limit: 65535
    t.string   "path",               limit: 255
    t.integer  "task_id",            limit: 4
    t.integer  "developer_id",       limit: 4
    t.string   "internal_object_id", limit: 255
    t.datetime "created_at"
    t.datetime "updated_at"
  end

  create_table "people", force: :cascade do |t|
    t.string  "name",                 limit: 255
    t.string  "trigram",              limit: 255
    t.string  "state",                limit: 255
    t.string  "level",                limit: 255
    t.string  "internal_object_id",   limit: 255
    t.integer "unread_objects_count", limit: 4
    t.integer "documents_count",      limit: 4
    t.integer "tasks_count",          limit: 4
  end

  create_table "tasks", force: :cascade do |t|
    t.string   "name",               limit: 255
    t.integer  "task_status",        limit: 4
    t.string   "task_type",          limit: 255
    t.string   "abstract",           limit: 255
    t.string   "bug_type",           limit: 255
    t.string   "internal_object_id", limit: 255
    t.boolean  "approved",           limit: 1
    t.text     "description",        limit: 65535
    t.text     "analysis",           limit: 65535
    t.text     "investigation",      limit: 65535
    t.integer  "developer_id",       limit: 4
    t.integer  "reviewer_id",        limit: 4
    t.integer  "comments_count",     limit: 4
    t.integer  "documents_count",    limit: 4
    t.date     "open_date"
    t.date     "analysis_date"
    t.date     "promotion_date"
    t.date     "review_date"
    t.date     "correction_date"
    t.date     "collection_date"
    t.date     "closed_date"
    t.date     "modified_date"
    t.date     "target_date"
    t.datetime "created_at"
    t.datetime "updated_at"
  end

  create_table "unread_objects", force: :cascade do |t|
    t.string   "person_id",          limit: 255
    t.string   "internal_object_id", limit: 255
    t.string   "unread_cause",       limit: 255
    t.datetime "created_at"
    t.datetime "updated_at"
  end

end
