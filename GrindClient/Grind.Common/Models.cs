using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grind.Common
{
    public class RootObject
    {
        public Person person { get; set; }
        public Task task { get;set; }
        public Document document { get; set; }
        public string Message { get; set; }
    }
    

    public class RootPerson 
	{
        public Person person { get; set; }
   	}

    public class RootTask
    {
        public Task task { get; set; }
    }

    public class RootDocument
    {
        public Document document { get; set; }
    }

    public class TimeStamp
    {
        public int id { get; set; }
        public Model type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string trigram { get; set; }
        public bool active { get; set; }
        public eLevel level { get; set; }
        public string internal_object_id { get; set; }
        public int unread_objects_count { get; set; }
        public int documents_count { get; set; }
        public int tasks_count { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Trigram { get; set; }
        //public string State { get; set; }
        //public string Level { get; set; }
        //public string InternalObjectId { get; set; }
        //public int UnreadObjectsCount { get; set; }
        //public int DocumentsCount { get; set; }
        //public int TasksCount { get; set; }
    }

    public class Document
    {
        public int task_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string data { get; set; }
        public string path { get; set; }
        public int developer_id { get; set; }
        public string internal_object_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        //public int TaskId { get; set; }
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public object Data { get; set; }
        //public string Path { get; set; }
        //public int DeveloperId { get; set; }
        //public string InternalObjectId { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }
    public class TaskListItem
    {
        public string taskName
        {
            get { return this.name + " - " + this.title; }
        }
        public string DeveloperName
        {
            get { return Globals.People.Find(x => x.id == this.developer_id).name; }
        }
        public string ReviewerName
        {
            get { return Globals.People.Find(x => x.id == this.reviewer_id).name; }
        }

        public int id { get; set; }
        public int developer_id { get; set; }
        public int reviewer_id { get; set; }
        public string name { get; set; }
        public eTaskStatus task_status { get; set; }
        public eBugType bug_type { get; set; }
        public string title { get; set; }
        public bool approved { get; set; }
        public bool is_bug { get; set; }
        //public DateTime open_date { get; set; }
        //public DateTime analysis_date { get; set; }
        //public DateTime review_date { get; set; }
        //public DateTime correction_date { get; set; }
        //public DateTime promotion_date { get; set; }
        //public DateTime collection_date { get; set; }
        //public DateTime closed_date { get; set; }
        public DateTime target_date { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Task 
    {
        public Task()
        {
            open_date = DateTime.Now.AddDays(0*7);
            analysis_date = DateTime.Now.AddDays(1*7);
            review_date = DateTime.Now.AddDays(1*7);
            correction_date = DateTime.Now.AddDays(1*7);
            promotion_date = DateTime.Now.AddDays(1 * 7);
            target_date = DateTime.Now.AddDays(1 * 7);
            collection_date = DateTime.Now.AddDays(2*7);
            closed_date = DateTime.Now.AddDays(3*7);
            developer_id = Globals.People.First().id;
            reviewer_id = Globals.People.First().id;
        }
        public int id { get; set; }
        public int developer_id { get; set; }
        public int reviewer_id { get; set; }
        public string name { get; set; }
        public eTaskStatus task_status { get; set; }
        public eBugType bug_type { get; set; }
        public string title { get; set; }
        public string internal_object_id { get; set; }
        public bool approved { get; set; }
        public bool is_bug { get; set; }
        public string description { get; set; }
        public string analysis { get; set; }
        public string review { get; set; }
        public int comments_count { get; set; }
        public int documents_count { get; set; }
        public DateTime open_date { get; set; }
        public DateTime analysis_date { get; set; }
        public DateTime review_date { get; set; }
        public DateTime correction_date { get; set; }
        public DateTime promotion_date { get; set; }
        public DateTime collection_date { get; set; }
        public DateTime closed_date { get; set; }
        public DateTime target_date { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Document> documents { get; set; }
    }


    public enum Model
	{
	    task=0,
        person,
        document,
        comment
	}
    public enum eTaskStatus
    {
        Open = 0,
        Analysis,
        Review,
        Correction,
        Promotion,
        Collection,
        Closed
    }
    public enum eBugType
    {
        HMA = 0,
        BackLog,
        CRITSIT,
        Others
    }
    public enum eLevel
    {
        Master = 0,
        Admin,
        User,
        Viewer
    }
}
