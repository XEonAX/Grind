using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grind_WF_CS
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Trigram { get; set; }
        public string State { get; set; }
        public string Level { get; set; }
        public string InternalObjectId { get; set; }
        public int UnreadObjectsCount { get; set; }
        public int DocumentsCount { get; set; }
        public int TasksCount { get; set; }
    }

    public class Document
    {
        public int TaskId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public object Data { get; set; }
        public string Path { get; set; }
        public int DeveloperId { get; set; }
        public string InternalObjectId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class Task 
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public int ReviewerId { get; set; }
        public string Name { get; set; }
        public eTaskStatus TaskStatus { get; set; }
        public eBugType BugType { get; set; }
        public string Abstract { get; set; }
        public string TaskName
        {
            get { return this.Name + " - " + this.Abstract; }
        }
        public string TaskType
        {
            get
            {
                if (this.IsBug)
                    return "Bug";
                else
                    return "HL";
            }
            set
            {
                if (TaskType == "HL")
                    this.IsBug = false;
                else
                    this.IsBug = true;
            }
        }
        public string InternalObjectId { get; set; }
        public bool Approved { get; set; }
        public bool IsBug { get; set; }
        public string Description { get; set; }
        public string Analysis { get; set; }
        public string Investigation { get; set; }
        public int CommentsCount { get; set; }
        public int DocumentsCount { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime AnalysisDate { get; set; }
        public DateTime PromotionDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime CorrectionDate { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string DeveloperName
        {
            get { return this.Developer.Name; }
        }
        public string ReviewerName
        {
            get { return this.Reviewer.Name; }
        }

        public Person Developer { get; set; }
        public Person Reviewer { get; set; }
        public List<Document> Documents { get; set; }
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
}
