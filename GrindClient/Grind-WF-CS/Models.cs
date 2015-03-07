using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grind_WF_CS
{
    public class RootObject
    {
        public Person person { get; set; }
        public Task task { get; set; }
        public Document document { get; set; }
        public string Status { get; set; }
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

    public class Task 
    {
        public int id { get; set; }
        public int developer_id { get; set; }
        public int reviewer_id { get; set; }
        public string name { get; set; }
        //public string taskName
        //{
        //    get { return this.name + " - " + this.title; }
        //}
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
        //public Person developer { get; set; }
        //public Person reviewer { get; set; }
        public List<Document> documents { get; set; }
        //public string DeveloperName
        //{
        //    get { return Form1.People.Find(x => x.id == this.developer_id).name; }
        //}
        //public string ReviewerName
        //{
        //    get { return Form1.People.Find(x => x.id == this.reviewer_id).name; }
        //}


        //public int Id { get; set; }
        //public int DeveloperId { get; set; }
        //public int ReviewerId { get; set; }
        //public string Name { get; set; }
        //public eTaskStatus TaskStatus { get; set; }
        //public eBugType BugType { get; set; }
        //public string Abstract { get; set; }
        //public string TaskName
        //{
        //    get { return this.Name + " - " + this.Abstract; }
        //}
        //public string TaskType
        //{
        //    get
        //    {
        //        if (this.IsBug)
        //            return "Bug";
        //        else
        //            return "HL";
        //    }
        //    set
        //    {
        //        if (TaskType == "HL")
        //            this.IsBug = false;
        //        else
        //            this.IsBug = true;
        //    }
        //}
        //public string InternalObjectId { get; set; }
        //public bool Approved { get; set; }
        //public bool IsBug { get; set; }
        //public string Description { get; set; }
        //public string Analysis { get; set; }
        //public string Investigation { get; set; }
        //public int CommentsCount { get; set; }
        //public int DocumentsCount { get; set; }
        //public DateTime OpenDate { get; set; }
        //public DateTime AnalysisDate { get; set; }
        //public DateTime PromotionDate { get; set; }
        //public DateTime ReviewDate { get; set; }
        //public DateTime CorrectionDate { get; set; }
        //public DateTime CollectionDate { get; set; }
        //public DateTime ClosedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public DateTime TargetDate { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        ////public string DeveloperName
        ////{
        ////    get { return this.Developer.Name; }
        ////}
        ////public string ReviewerName
        ////{
        ////    get { return this.Reviewer.Name; }
        ////}

        //public Person Developer { get; set; }
        //public Person Reviewer { get; set; }
        //public List<Document> Documents { get; set; }
    }

    public class ClientTask : Task
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

    }


    public enum eTaskStatus
    {
        Open = 0,
        Analysis,
        Review,
        Correction,
        Promotion,
        Colection,
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
