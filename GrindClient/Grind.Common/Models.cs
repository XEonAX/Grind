using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.Windows.Documents;
namespace Grind.Common
{
    public class Session : Token
    {
        public Person User { get; set; }
        

    }
    public class Token
    {
        public string token { get; set; }
    }
    public class RootObject
    {
        public Person person { get; set; }
        public Task task { get; set; }
        public Document document { get; set; }
        public string Message { get; set; }
        public string token { get; set; }
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

    public class TimeStamp : IEquatable<TimeStamp>
    {
        public TimeStamp ()
	{

	}
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool Equals(TimeStamp obj)
        {
            TimeStamp otherTimestamp = obj as TimeStamp;
            if (otherTimestamp == null)
                return false;
            return id.Equals(otherTimestamp.id)
                && updated_at.Equals(otherTimestamp.updated_at)
                && created_at.Equals(otherTimestamp.created_at);
        }
        public TimeStamp AsTimeStamp() 
        {
            return new TimeStamp { created_at=created_at,id=id,updated_at=updated_at };
        }
        public override bool Equals(object obj)
        {
            TimeStamp otherTimestamp = obj as TimeStamp;
            if (otherTimestamp == null)
                return false;
            return id.Equals(otherTimestamp.id)
                && updated_at.Equals(otherTimestamp.updated_at)
                && created_at.Equals(otherTimestamp.created_at);
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)2166136261;
                // Suitable nullity checks etc, of course :)
                hash = hash * 16777619 ^ id.GetHashCode();
                hash = hash * 16777619 ^ created_at.GetHashCode();
                hash = hash * 16777619 ^ updated_at.GetHashCode();
                return hash;
            }
        }
    }

    public class Person : TimeStamp, IEquatable<Person>
    {
        public string name { get; set; }
        public string trigram { get; set; }
        public bool active { get; set; }
        public eLevel level { get; set; }
        public string internal_object_id { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public int unread_objects_count { get; set; }
        public int documents_count { get; set; }
        public int work_tasks_count { get; set; }
        public int review_tasks_count { get; set; }

        public bool Equals(Person obj)
        {
            Person otherPerson = obj as Person;
            if (otherPerson == null)
                return base.Equals(obj);
            return id.Equals(otherPerson.id)
                && updated_at.Equals(otherPerson.updated_at)
                && trigram.Equals(otherPerson.trigram)
                && active.Equals(otherPerson.active)
                && level.Equals(otherPerson.level)
                && internal_object_id.Equals(otherPerson.internal_object_id)
                && created_at.Equals(otherPerson.created_at);
        }
        public override bool Equals(object obj)
        {
            Person otherPerson = obj as Person;
            if (otherPerson == null)
                return base.Equals(obj);
            return id.Equals(otherPerson.id)
                && updated_at.Equals(otherPerson.updated_at)
                && trigram.Equals(otherPerson.trigram)
                && active.Equals(otherPerson.active)
                && level.Equals(otherPerson.level)
                && internal_object_id.Equals(otherPerson.internal_object_id)
                && created_at.Equals(otherPerson.created_at);
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)2166136261;
                // Suitable nullity checks etc, of course :)
                hash = hash * 16777619 ^ id.GetHashCode();
                hash = hash * 16777619 ^ trigram.GetHashCode();
                hash = hash * 16777619 ^ active.GetHashCode();
                hash = hash * 16777619 ^ level.GetHashCode();
                hash = hash * 16777619 ^ internal_object_id.GetHashCode();
                hash = hash * 16777619 ^ created_at.GetHashCode();
                hash = hash * 16777619 ^ updated_at.GetHashCode();
                return hash;
            }
        }
    }

    public class Document : TimeStamp
    {
        public int task_id { get; set; }
        public string name { get; set; }
        public string data { get; set; }
        public string path { get; set; }
        public int developer_id { get; set; }
        public string internal_object_id { get; set; }
    }

    public class TaskListItem : Task
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


    public class Task : TimeStamp
    {
        public Task()
        {
            open_date = DateTime.Now.AddDays(0 * 7);
            analysis_date = DateTime.Now.AddDays(1 * 7);
            review_date = DateTime.Now.AddDays(1 * 7);
            correction_date = DateTime.Now.AddDays(1 * 7);
            promotion_date = DateTime.Now.AddDays(1 * 7);
            target_date = DateTime.Now.AddDays(1 * 7);
            collection_date = DateTime.Now.AddDays(2 * 7);
            closed_date = DateTime.Now.AddDays(3 * 7);
            if (Globals.People.Count == 0)    Globals.People.Add(new Person { id = 0, name = "DummyUser", level = eLevel.Master });
            developer_id = Globals.People.First().id;
            reviewer_id = Globals.People.First().id;
            bug_type = eBugType.Others;
            is_bug = true;
        }

        public TaskListItem AsTaskListItem() 
        {
            var type = typeof(TaskListItem);
            var instance = Activator.CreateInstance(type);
            
            PropertyInfo[] properties = type.GetProperties();
            foreach (var property in properties)
                if (property.CanWrite) property.SetValue(instance, property.GetValue(this, null), null);
            return (TaskListItem)instance;
        }

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
        public List<Document> documents { get; set; }
    }

    public class WS_Message : TimeStamp
    {
        public int sender_id { get; set; }
        public int receiver_id { get; set; }
        public int parent_message_id { get; set; }
        public string messagetext { get; set; }
        public List<WS_Message> messages { get; set; }

    }

    public class WS_DisplayMessage : WS_Message
    {
        public string sender_name
        {
            get
            {
                Person X = Globals.People.Find(x => x.id == this.sender_id);
                if (X != null)
                    return X.name;
                else
                    return "DummyUser";
            }
        }

        public FlowDocument flow_message
        {
            get
            {
                if (this.sender_id == 0)
                {
                    FlowDocument FD = new FlowDocument();
                    FD.Blocks.Add(new Paragraph(new Run(this.messagetext)));
                    return FD;
                }
                else
                    return this.messagetext.FlowDocumentFromBase64String();
            }
        }
    }
    public enum Model
    {
        task = 0,
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
    public enum RetCode
    {
        maybe = -1,
        no,
        yes,
        False,
        True,
        unsuccessful,
        successful
    }
}
