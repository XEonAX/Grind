using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using NDatabase;
using NDatabase.Api;
using System.Diagnostics;
using NDatabase.Api.Query;
using System.Windows.Controls.Primitives;
namespace Grind.Common
{
    public class Controllers
    {
        #region Statics
        public static RestClient rRestClient;
        public static IRestResponse rRestResponse;
        public static string Message;
        public static IOdb CacheDB;
        public static StatusBarItem bMessage;
        public static StatusBarItem bState;
        private static string lastMessage, lastState;
        public Controllers(string baseUrl)
        {
            rRestClient = new RestClient(baseUrl);
            CacheDB = OdbFactory.Open(@"CacheDB.ndb");
        }
        public Controllers(string baseUrl, ref StatusBarItem sbiMessage, ref StatusBarItem sbiState)
        {
            rRestClient = new RestClient(baseUrl);
            CacheDB = OdbFactory.Open(@"CacheDB.ndb");
            bMessage = sbiMessage;
            bState = sbiState;
        }

        #endregion

        #region Base Object CRUD Methods

        public static bool CreateObject(ref RootObject rootObject, ref RestClient rClient, string requestResource, out IRestResponse rResponse)
        {
            RestRequest rRequest = new RestRequest();
            rRequest.DateFormat = "yyyy-MM-ddTHH:mm:sssssZ";
            rRequest.Resource = requestResource;
            rRequest.Method = Method.POST;
            rRequest.RequestFormat = DataFormat.Json;
            rRequest.AddBody(rootObject);
            rResponse = rClient.Execute(rRequest);
            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                SetState("Creation Successful.");
                return true;
            }
            else
            {
                SetState(rResponse.ErrorMessage + " " + rRestResponse.StatusCode.ToString());
                return false;
            }
        }

        /// <summary>
        /// Downloads Object using GET to rResponse
        /// </summary>
        /// <param name="rClient">RestClient with proper config</param>
        /// <param name="requestResource">Resource like "task/{id}", "people", etc. If it does not contain "{id}" next parameter won't be used</param>
        /// <param name="requestResourceId">"id" to get. If previous parameter does not contain "{id}" this parameter won't be used</param>
        /// <param name="rResponse">Stores retrieved response</param>
        /// <returns>True if 200 OK else false</returns>
        public static bool ReadObject(ref RestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
        {
            RestRequest rRequest = new RestRequest();
            rRequest.Resource = requestResource;// "task/{id}";
            rRequest.DateFormat = "yyyy-MM-ddTHH:mm:sssssZ";
            if (requestResource.Contains("{id}")) rRequest.AddUrlSegment("id", requestResourceId);
            rRequest.Method = Method.GET;
            rResponse = rClient.Execute(rRequest);
            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                SetState("Online");
                return true;
            }
            else
            {
                SetState(rResponse.ErrorMessage);
                return false;
            }

        }

        public static bool UpdateObject(ref RootObject rootObject, ref RestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
        {
            RestRequest rRequest = new RestRequest();
            rRequest.DateFormat = "yyyy-MM-dd";
            rRequest.Resource = requestResource;
            rRequest.Method = Method.PUT;
            rRequest.AddUrlSegment("id", requestResourceId);
            rRequest.RequestFormat = DataFormat.Json;
            rRequest.AddBody(rootObject);
            rResponse = rClient.Execute(rRequest);
            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                SetState("Update Successful");
                return true;
            }
            else
            {
                SetState(rResponse.ErrorMessage);
                return false;
            }
        }

        public static bool DeleteObject(ref RestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
        {
            JsonDeserializer JSONDeserilizer = new JsonDeserializer();
            RestRequest rRequest = new RestRequest();
            rRequest.Resource = requestResource;// "task/{id}";
            rRequest.DateFormat = "yyyy-MM-ddTHH:mm:sssssZ";
            rRequest.AddUrlSegment("id", requestResourceId);
            rRequest.Method = Method.DELETE;
            rResponse = rClient.Execute(rRequest);
            Globals.rootObject = JSONDeserilizer.Deserialize<RootObject>(rResponse);
            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                SetState("Delete Successful");
                return true;
            }
            else
            {
                SetState(rResponse.ErrorMessage);
                return false;
            }
        }
        #endregion

        #region person and People CRUD Methods
        public static bool CreatePerson(ref Person person)
        {
            return CreatePerson(ref person, ref rRestClient, out rRestResponse);
        }
        public static bool CreatePerson(ref Person person, ref RestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.person = person;
            return CreateObject(ref rootObject, ref rClient, "person", out rResponse);
        }

        public static bool UpdatePerson(ref Person person)
        {
            return UpdatePerson(ref person, ref rRestClient, out rRestResponse);
        }
        public static bool UpdatePerson(ref Person person, ref RestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.person = person;
            return UpdateObject(ref rootObject, ref rClient, "person/{id}", person.id.ToString(), out rResponse);
        }

        public static bool ReadPeople(out List<Person> people)
        {
            return ReadPeople(out people, ref rRestClient, out rRestResponse);
        }
        public static bool ReadPeople(out List<Person> people, ref RestClient rClient, out IRestResponse rResponse)
        {
            List<Person> cpeople;
            if (RetrieveLatestPeopleFromServer(out cpeople))
            {
                JsonDeserializer JSONDeserilizer = new JsonDeserializer();
                if (ReadObject(ref rClient, "people", "", out rResponse))
                {

                    people = JSONDeserilizer.Deserialize<List<Person>>(rResponse);
                    CacheDB.Store<List<Person>>(people);
                    CacheDB.Commit();
                    return true;
                }
                else
                {
                    if (cpeople != null)
                    {
                        SetMessage("Offline Cache People");
                        people = cpeople;
                    }
                    else
                        people = null;
                    return false;
                }

            }
            else
            {
                SetMessage("Up to date Cached People");
                people = cpeople;
                rResponse = null;
                return true;//We have good people in cache
            }
        }

        public static bool DeletePerson(ref Person person)
        {
            return DeletePerson(ref person, ref rRestClient, out rRestResponse);
        }
        public static bool DeletePerson(ref Person person, ref RestClient rClient, out IRestResponse rResponse)
        {
            return DeleteObject(ref rClient, "person/{id}", person.id.ToString(), out rResponse);
        }
        #endregion

        #region Task CRUD Methods
        public static bool CreateTask(ref Task task)
        {
            return CreateTask(ref task, ref rRestClient, out rRestResponse);
        }
        public static bool CreateTask(ref Task task, ref RestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.task = task;
            return CreateObject(ref rootObject, ref rClient, "task", out rResponse);
        }

        public static bool ReadTask(int taskId, out Task task)
        {
            return ReadTask(taskId, out task, ref rRestClient, out rRestResponse);
        }
        public static bool ReadTask(int taskId, out Task task, ref RestClient rClient, out IRestResponse rResponse)
        {
            Task ctask;
            if (RetrieveLatestTaskFromServer(taskId, out ctask))
            {
                JsonDeserializer JSONDeserilizer = new JsonDeserializer();
                if (ReadObject(ref rClient, "task/{id}", taskId.ToString(), out rResponse))
                {

                    task = JSONDeserilizer.Deserialize<Task>(rResponse);
                    SetMessage("Task Added to Cache:" + task.name);
                    CacheDB.Store<Task>(task);
                    CacheDB.Commit();
                    return true;
                }
                else
                {
                    if (ctask != null)
                    {
                        task = ctask;
                        SetMessage("Offline Task From Cache:" + ctask.name);
                    }
                    else
                        task = null;
                    //task = null;// new Task();
                    return false;
                }
            }
            else
            {
                SetMessage("Up to date Task From Cache:" + ctask.name);
                task = ctask;
                //We have Cached Task
                rResponse = null;
                return true;
            }
        }

        public static bool UpdateTask(ref Task task)
        {
            return UpdateTask(ref task, ref rRestClient, out rRestResponse);
        }
        public static bool UpdateTask(ref Task task, ref RestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.task = task;
            return UpdateObject(ref rootObject, ref rClient, "task/{id}", task.id.ToString(), out rResponse);
        }

        public static bool DeleteTask(ref Task task)
        {
            return DeleteTask(ref task, ref rRestClient, out rRestResponse);
        }
        public static bool DeleteTask(ref Task task, ref RestClient rClient, out IRestResponse rResponse)
        {
            return DeleteObject(ref rClient, "task/{id}", task.id.ToString(), out rResponse);
        }
        #endregion

        #region Tasks Read Methods
        public static bool ReadTasks(ref SortableBindingList<TaskListItem> tasks)
        {
            return ReadTasks(ref tasks, ref rRestClient, out rRestResponse);
        }
        public static bool ReadTasks(ref SortableBindingList<TaskListItem> tasks, ref RestClient rClient, out IRestResponse rResponse)
        {
            SortableBindingList<TaskListItem> ctasks;
            if (RetrieveLatestTasksFromServer(out ctasks))
            {
                JsonDeserializer rJSONDeserializer = new JsonDeserializer();
                if (ReadObject(ref rClient, "tasks", "", out rResponse))
                {
                    
                    if (tasks == null) tasks = new SortableBindingList<TaskListItem>();
                    tasks.Clear();
                    foreach (TaskListItem item in rJSONDeserializer.Deserialize<SortableBindingList<TaskListItem>>(rResponse))
                    {
                        tasks.Add(item);
                    }
                    SetMessage("TaskList Added to Cache");
                    CacheDB.Store<SortableBindingList<TaskListItem>>(tasks);
                    CacheDB.Commit();
                    //tasks = rJSONDeserializer.Deserialize<SortableBindingList<ClientTask>>(rResponse);
                    return true;

                }
                else
                {
                    //SetState("Offline1");
                    if (ctasks != null)
                    {
                        tasks = ctasks;
                        SetMessage("Offline TaskList From Cache");
                    }
                    else
                        tasks = null;
                    //tasks = new SortableBindingList<ClientTask>(); 
                    return false;
                }
            }
            else
            {
                tasks = ctasks;
                //We have Cached Task
                rResponse = null;
                return true;
            }

        }

        public static bool ReadTasks(ref List<Task> tasks)
        {
            return ReadTasks(ref tasks, ref rRestClient, out rRestResponse);
        }
        public static bool ReadTasks(ref List<Task> tasks, ref RestClient rClient, out IRestResponse rResponse)
        {
            JsonDeserializer JSONDeserilizer = new JsonDeserializer();
            if (ReadObject(ref rClient, "tasks", "", out rResponse))
            {
                tasks = JSONDeserilizer.Deserialize<List<Task>>(rResponse);
                return true;
            }
            else
            {
                //tasks = null;
                return false;
            }
        }
        #endregion

        #region Helper Methods
        public static bool RetrieveLatestPeopleFromServer(out List<Person> people)
        {
            //IQueryable<List<Person>> osPeople = from _people in CacheDB.AsQueryable<List<Person>>()
            //                                   select _people;
            IObjectSet<List<Person>> osPeople = CacheDB.QueryAndExecute<List<Person>>();
            if (osPeople.Count() == 1)
            {
                people = osPeople.First();
                List<TimeStamp> LatestPeopleTimeStamps = LatestTimeStamps(Model.person);
                if (LatestPeopleTimeStamps != null)
                {
                    if (people.Count == LatestPeopleTimeStamps.Count)
                    {
                        Debug.Print("Same no of People Detected in Cache");
                        foreach (Person person in people)
                        {
                            if (LatestPeopleTimeStamps.Find(x => (x.id == person.id && x.updated_at == person.updated_at)) == null)
                            {
                                Debug.Print("person id " + person.id.ToString() + " not found on server. So we need a refresh.");
                                CacheDB.Delete<List<Person>>(people);//Delete because it's stale
                                CacheDB.Commit();
                                people = null;
                                return true;
                            }
                        }
                        return false;
                    }
                    else
                    {
                        Debug.Print("People found Stale. So killing them.");
                        CacheDB.Delete<List<Person>>(people);//Delete because it's stale
                        CacheDB.Commit();
                        people = null;
                    }
                }
                else
                {
                    SetState("Offline2");
                    //We have unconfirmed people
                    return true;
                }
            }
            else
                foreach (List<Person> __people in osPeople)
                {
                    //How the hell did it enter here??
                    //Kill all group of people that exist in cache.
                    //We need to start afresh
                    CacheDB.Delete<List<Person>>(__people);
                    CacheDB.Commit();
                }
            people = null;
            return true;
        }
        public static bool RetrieveLatestTasksFromServer(out SortableBindingList<TaskListItem> tasks)
        {
            //IQueryable<SortableBindingList<ClientTask>> osTasks = from _tasks in CacheDB.AsQueryable<SortableBindingList<ClientTask>>()
            //                                                     select _tasks;

            IObjectSet<SortableBindingList<TaskListItem>> osTasks = CacheDB.QueryAndExecute<SortableBindingList<TaskListItem>>();
            if (osTasks.Count() == 1)
            {
                tasks = osTasks.First();
                List<TimeStamp> LatestTasksTimeStamps = LatestTimeStamps(Model.task);
                if (LatestTasksTimeStamps != null)
                {
                    if (tasks.Count == LatestTasksTimeStamps.Count)
                    {
                        Debug.Print("Same no of Tasks Detected in Cache");
                        foreach (TaskListItem task in tasks)
                        {
                            if (task == null || LatestTasksTimeStamps.Find(x => (x.id == task.id && x.updated_at == task.updated_at)) == null)
                            {
                                Debug.Print("task not found on server. So we need a refresh.");
                                CacheDB.Delete<SortableBindingList<TaskListItem>>(tasks);//Delete because it's stale
                                CacheDB.Commit();
                                tasks = null;
                                return true;
                            }

                        }
                        return false;
                    }
                    else
                    {
                        SetMessage("Stale tasks found. So deleting them.");
                        CacheDB.Delete<SortableBindingList<TaskListItem>>(tasks);//Delete because it's stale
                        CacheDB.Commit();
                        tasks = null;
                    }
                }
                else
                {
                    SetState("Offline3");
                    //We have unconfirmed people
                    return true;
                }
            }
            else
                foreach (SortableBindingList<TaskListItem> __task in osTasks)
                {
                    //How the hell did it enter here??
                    //delete all group of tasks that exist in cache.
                    //We need to start afresh
                    CacheDB.Delete<SortableBindingList<TaskListItem>>(__task);
                    CacheDB.Commit();
                }
            tasks = null;
            return true;
        }
        public static bool RetrieveLatestTaskFromServer(int id, out Task task)
        {
            //IQueryable<Task> osTasks = from _tasks in CacheDB.AsQueryable<Task>()
            //                          where
            //                              _tasks.id.Equals(id)
            //                          select _tasks;
            IQuery queryById = CacheDB.Query<Task>();
            queryById.Descend("id").Constrain(id).Equal();
            //IEnumerable<Task> osTasks = queryById.Execute<Task>().Where(x=>x.GetType()==typeof(Task));
            IEnumerable<Task> osTasks = queryById.Execute<Task>();

            if (osTasks.Count() == 1)
            {
                task = osTasks.First();
                DateTime? dtTaskLastUpdateAt = TaskLastUpdateAt(id);
                if (dtTaskLastUpdateAt != null)//if false retrieve from Server
                    if (dtTaskLastUpdateAt == task.updated_at)
                    {
                        SetMessage("Task from Cache");
                        return false;
                    }
                    else
                    {
                        SetMessage("Stale Task Deleted from Cache");
                        CacheDB.Delete<Task>(task);//Delete because it's stale
                        CacheDB.Commit();
                        task = null;
                    }
                else
                {
                    SetState("Offline4");
                    //We have unconfirmed Task
                    return true;
                }
            }
            else
                foreach (Task _task in osTasks)
                {
                    //How the hell did it enter here??
                    //Delete all tasks with this IDthat exist in cache.
                    //We need to start afresh
                    CacheDB.Delete<Task>(_task);
                    CacheDB.Commit();
                }
            task = null;
            return true;
        }
        public static DateTime? TaskLastUpdateAt(int id)
        {
            TimeStamp timestamp;
            if (GetLatestTimeStamp(out timestamp, Model.task, id))
                return timestamp.updated_at;
            else
                return null;
        }
        public static bool GetLatestTimeStamp(out TimeStamp timestamp, Model type, int id)
        {
            return GetLatestTimeStamp(out timestamp, type, id, ref  rRestClient, out rRestResponse);
        }

        public static bool GetLatestTimeStamp(out TimeStamp timestamp, Model type, int id, ref RestClient rClient, out IRestResponse rResponse)
        {
            JsonDeserializer JSONDeserilizer = new JsonDeserializer();
            if (ReadObject(ref rClient, @"timestamp/" + type.ToString() + @"/{id}", id.ToString(), out rResponse))
            {

                timestamp = JSONDeserilizer.Deserialize<TimeStamp>(rResponse);
                return true;
            }
            else
            {
                timestamp = null;
                return false;
            }
        }

        public static List<TimeStamp> LatestTimeStamps(Model type)
        {
            List<TimeStamp> timestamps;
            if (GetLatestTimeStamps(out timestamps, type))
                return timestamps;
            else
                return null;
        }
        public static bool GetLatestTimeStamps(out List<TimeStamp> timestamps, Model type)
        {
            return GetLatestTimeStamps(out timestamps, type, ref  rRestClient, out rRestResponse);
        }

        public static bool GetLatestTimeStamps(out List<TimeStamp> timestamps, Model type, ref RestClient rClient, out IRestResponse rResponse)
        {
            JsonDeserializer JSONDeserilizer = new JsonDeserializer();
            if (ReadObject(ref rClient, @"timestamps/" + type.ToString(), "", out rResponse))
            {

                timestamps = JSONDeserilizer.Deserialize<List<TimeStamp>>(rResponse);
                return true;
            }
            else
            {
                timestamps = null;
                return false;
            }
        }
        //public static bool ReadPeopleFromCache(out List<Person> people)
        //{
        //    IQueryable<List<Person>> qPeople = from _people in CacheDB.AsQueryable<List<Person>>()
        //                                       select _people;
        //    if (qPeople.Count() > 0)
        //    {
        //        people = qPeople.First();
        //        return true;
        //    }
        //    else
        //    {
        //        people = null;
        //        return false;
        //    }
        //}

        public static void SetMessage(string Message)
        {
            
            if (bMessage != null && lastMessage!=Message)
                bMessage.Content = Message + Environment.NewLine + bMessage.Content;
            lastMessage = Message;
        }

        public static void SetState(string State)
        {
            if (bState != null && lastState!=State)
                bState.Content = State + Environment.NewLine + bState.Content;
            lastState = State;
        }

        public static string GetResponseError()
        {
            String Error = "";
            if (rRestResponse!=null)
            {
                if (rRestResponse.StatusCode!=System.Net.HttpStatusCode.OK)
                {
                    if (rRestResponse.ContentType == @"application/json")
                    {
                        JsonDeserializer JSONDeserilizer = new JsonDeserializer();
                        RootObject RO = JSONDeserilizer.Deserialize<RootObject>(rRestResponse);
                        Error = Environment.NewLine + RO.Message;
                    }
                    else
                        Error = Environment.NewLine + (rRestResponse.StatusCode.ToString() + rRestResponse.ErrorMessage).Trim();
                }
            }
            return Error;
        }
        #endregion
    }
}
