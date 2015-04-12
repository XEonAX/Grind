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
    public static class Controllers
    {
        #region Statics
        public static RestClient rRestClient;
        public static IRestResponse rRestResponse;
        public static string Message;
        public static IOdb CacheDB;
        public static StatusBarItem bMessage;
        public static StatusBarItem bState;
        private static string lastMessage, lastState;
        private static bool isOnline = true;
        private static JsonDeserializer rJSONDeserializer = new JsonDeserializer();
        public static void ControllersInit(string baseUrl)
        {
            rRestClient = new RestClient(baseUrl);
            CacheDB = OdbFactory.Open(@"CacheDB.ndb");
        }
        public static void ControllersInit(string baseUrl, ref StatusBarItem sbiMessage, ref StatusBarItem sbiState)
        {
            rRestClient = new RestClient(baseUrl);
            CacheDB = OdbFactory.Open(@"CacheDB.ndb");
            bMessage = sbiMessage;
            bState = sbiState;
        }

        #endregion

        #region Extensions

        //public static RetCode isLatest(this Task task)
        //{
        //    TimeStamp timestamp;
        //    if (RetCode.successful == GetLatestTimeStamp(out timestamp, Model.task, task.id))
        //    {
        //        if (timestamp.updated_at > task.updated_at)
        //            return RetCode.no;
        //        else
        //            return RetCode.yes;
        //    }
        //    else
        //        return RetCode.maybe;
        //}
        //public static RetCode FilterLatest(this IObjectSet<TimeStamp> timestamplist, out List<TimeStamp> deletionList)
        //{
        //    List<TimeStamp> timestamps;
        //    deletionList = new List<TimeStamp>();
        //    if (RetCode.successful == GetLatestTimeStamps(out timestamps, Model.task))
        //    {
        //        timestamplist.Except(timestamps);
        //        foreach (Task timestampItem in timestamplist)
        //        {
        //            TimeStamp ts = timestamps.Find(x => x.id == timestampItem.id);
        //            if (ts != null && ts.updated_at > timestampItem.updated_at)
        //            {
        //                timestamplist.Remove(timestampItem);
        //                deletionList.Add(timestampItem);
        //            }
        //        }
        //        if (deletionList.Count > 0)
        //            return RetCode.yes;
        //        else
        //            return RetCode.no;
        //    }
        //    else
        //        return RetCode.maybe
        //}


        //public static RetCode isLatest(this Task task)
        //{
        //    TimeStamp timestamp;
        //    if (GetLatestTimeStamp(out timestamp, Model.task, task.id))
        //    {
        //        if (timestamp.updated_at > task.updated_at)
        //            return RetCode.unsuccessful;
        //        else
        //            return RetCode.successful;
        //    }
        //    else
        //        return RetCode.unsuccessful;
        //}

        #endregion
        #region Base Object CRUD Methods

        public static RetCode CreateObject(ref RootObject rootObject, ref RestClient rClient, string requestResource, out IRestResponse rResponse)
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
                SetMessage("Creation Successful.");
                return RetCode.successful;
            }
            else
            {
                SetState(rResponse.ErrorMessage + " " + rRestResponse.StatusCode.ToString());
                return RetCode.unsuccessful;
            }
        }
        public static RetCode ReadObject(ref RestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
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
                return RetCode.successful;
            }
            else
            {
                SetState(rResponse.ErrorMessage);
                return RetCode.unsuccessful;
            }

        }
        public static RetCode UpdateObject(ref RootObject rootObject, ref RestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
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
                return RetCode.successful;
            }
            else
            {
                SetState(rResponse.ErrorMessage);
                return RetCode.unsuccessful;
            }
        }
        public static RetCode DeleteObject(ref RestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
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
                return RetCode.successful;
            }
            else
            {
                SetState(rResponse.ErrorMessage);
                return RetCode.unsuccessful;
            }
        }
        #endregion

        #region person and People CRUD Methods
        public static RetCode CreatePerson(ref Person person)
        {
            return CreatePerson(ref person, ref rRestClient, out rRestResponse);
        }
        public static RetCode CreatePerson(ref Person person, ref RestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.person = person;
            return CreateObject(ref rootObject, ref rClient, "person", out rResponse);
        }

        public static RetCode UpdatePerson(ref Person person)
        {
            return UpdatePerson(ref person, ref rRestClient, out rRestResponse);
        }
        public static RetCode UpdatePerson(ref Person person, ref RestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.person = person;
            return UpdateObject(ref rootObject, ref rClient, "person/{id}", person.id.ToString(), out rResponse);
        }

        public static RetCode ReadPeople(out List<Person> people)
        {
            return ReadPeople(out people, ref rRestClient, out rRestResponse);
        }
        public static RetCode ReadPeople(out List<Person> people, ref RestClient rClient, out IRestResponse rResponse)
        {
            List<Person> cpeople = ReadCachedObjects<Person>();
            if (isOnline)
            {
                List<TimeStamp> lts = LatestTimeStamps(Model.person);
                if (lts != null)
                {
                    if (RetCode.successful == ReadObject(ref rClient, "people", "", out rResponse))
                    {

                        people = rJSONDeserializer.Deserialize<List<Person>>(rResponse);
                        if (people.Except(cpeople).Count()>0)
                        {
                            people.Except(cpeople).ToList().ForEach(x => CacheDB.Store<Person>(x));
                        }
                        CacheDB.Commit();

                        UpdateCachedPeople(lts);
                        return RetCode.successful;
                    }
                    else
                    {
                        SetMessage("Offline Cache People");
                        people = cpeople;
                        return RetCode.unsuccessful;
                    }
                }
                else
                {
                    SetMessage("Offline Cache People");
                    people = cpeople;
                    rResponse = null;
                    return RetCode.unsuccessful;
                }
            }
            else
            {
                SetMessage("Up to date Cached People");
                people = cpeople;
                rResponse = null;
                return RetCode.successful;//We have good people in cache
            }
        }

        public static RetCode DeletePerson(ref Person person)
        {
            return DeletePerson(ref person, ref rRestClient, out rRestResponse);
        }
        public static RetCode DeletePerson(ref Person person, ref RestClient rClient, out IRestResponse rResponse)
        {
            return DeleteObject(ref rClient, "person/{id}", person.id.ToString(), out rResponse);
        }
        #endregion

        #region Task CRUD Methods
        public static RetCode CreateTask(ref Task task)
        {
            return CreateTask(ref task, ref rRestClient, out rRestResponse);
        }
        public static RetCode CreateTask(ref Task task, ref RestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.task = task;
            return CreateObject(ref rootObject, ref rClient, "task", out rResponse);
        }

        public static RetCode ReadTask(int taskId, out Task task)
        {
            return ReadTask(taskId, out task, ref rRestClient, out rRestResponse);
        }
        public static RetCode ReadTask(int taskId, out Task task, ref RestClient rClient, out IRestResponse rResponse)
        {
            task = null;
            Task ctask = ReadCachedObject<Task>(taskId);
            if (isOnline)
            {
                TimeStamp lt = LatestTimeStamp(Model.task, taskId);
                if (lt != null)
                {
                    if (ctask != null)
                    {
                        if (ctask.updated_at == lt.updated_at)
                        {
                            SetMessage("Up to date Task From Cache");
                            task = ctask;
                            rResponse = null;
                            return RetCode.successful;
                        }
                        else
                        {
                            CacheDB.Delete<Task>(ctask);
                            CacheDB.Commit();
                        }
                    }
                    //If it reaches her it means No cached task or stale task
                    if (RetCode.successful == ReadObject(ref rClient, "task/{id}", taskId.ToString(), out rResponse))
                    {
                        task = rJSONDeserializer.Deserialize<Task>(rResponse);
                        SetMessage("Task Added to Cache:" + task.name);
                        CacheDB.Store<Task>(task);
                        CacheDB.Commit();
                        return RetCode.successful;
                    }
                    else
                    {
                        task = ctask;
                        SetMessage("Offline Stale Task From Cache");
                        task = null;
                        //task = null;// new Task();
                        return RetCode.unsuccessful;
                    }
                }
                else
                {
                    SetMessage("Get Timestamp Failed");
                    task = ctask;
                    rResponse = null;
                    return RetCode.unsuccessful;
                }
            }
            else
            {
                SetMessage("Offline Task From Cache");
                task = ctask;
                //We have Cached Task
                rResponse = null;
                return RetCode.successful;
            }
        }


        public static RetCode UpdateTask(ref Task task)
        {
            return UpdateTask(ref task, ref rRestClient, out rRestResponse);
        }
        public static RetCode UpdateTask(ref Task task, ref RestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.task = task;
            return UpdateObject(ref rootObject, ref rClient, "task/{id}", task.id.ToString(), out rResponse);
        }

        public static RetCode DeleteTask(ref Task task)
        {
            return DeleteTask(ref task, ref rRestClient, out rRestResponse);
        }
        public static RetCode DeleteTask(ref Task task, ref RestClient rClient, out IRestResponse rResponse)
        {
            return DeleteObject(ref rClient, "task/{id}", task.id.ToString(), out rResponse);
        }
        #endregion

        #region Tasks Read Methods
        public static RetCode ReadTasks(ref SortableBindingList<TaskListItem> tasks)
        {
            return ReadTasks(ref tasks, ref rRestClient, out rRestResponse);
        }
        public static RetCode ReadTasks(ref SortableBindingList<TaskListItem> tasks, ref RestClient rClient, out IRestResponse rResponse)
        {
            List<Task> cachedTasks = ReadCachedObjects<Task>();
            if (isOnline)
            {
                List<TimeStamp> lts = LatestTimeStamps(Model.task);
                if (lts != null)
                {
                    if (RetCode.successful == ReadObject(ref rClient, "tasks", "", out rResponse))
                    {
                        if (tasks == null) tasks = new SortableBindingList<TaskListItem>();
                        tasks.Clear();
                        foreach (Task item in rJSONDeserializer.Deserialize<SortableBindingList<TaskListItem>>(rResponse))
                            tasks.Add(item.As<TaskListItem>());
                        UpdateCachedTasks(lts);
                        return RetCode.successful;
                    }
                    else
                    {
                        if (cachedTasks != null)
                        {
                            if (tasks == null) tasks = new SortableBindingList<TaskListItem>();
                            tasks.Clear();
                            foreach (Task item in cachedTasks)
                                tasks.Add(item.As<TaskListItem>());
                            SetMessage("Offline TaskList From Cache");
                        }
                        else
                            tasks = null;
                        return RetCode.unsuccessful;
                    }
                }
                else
                {
                    if (cachedTasks != null)
                    {
                        if (tasks == null) tasks = new SortableBindingList<TaskListItem>();
                        tasks.Clear();
                        foreach (Task item in cachedTasks)
                            tasks.Add(item.As<TaskListItem>());
                        SetMessage("Offline TaskList From Cache");
                    }
                    else
                        tasks = null;
                    rResponse = null;
                    return RetCode.unsuccessful;
                }
            }
            else
            {
                if (cachedTasks != null)
                {
                    if (tasks == null) tasks = new SortableBindingList<TaskListItem>();
                    tasks.Clear();
                    foreach (Task item in cachedTasks)
                        tasks.Add(item.As<TaskListItem>());
                    SetMessage("Offline TaskList From Cache");
                }
                else
                    tasks = null;
                rResponse = null;
                return RetCode.successful;
            }

        }

        //public static RetCode ReadTasks(ref List<Task> tasks)
        //{
        //    return ReadTasks(ref tasks, ref rRestClient, out rRestResponse);
        //}
        //public static RetCode ReadTasks(ref List<Task> tasks, ref RestClient rClient, out IRestResponse rResponse)
        //{
        //    JsonDeserializer JSONDeserilizer = new JsonDeserializer();
        //    if (RetCode.successful == ReadObject(ref rClient, "tasks", "", out rResponse))
        //    {
        //        tasks = JSONDeserilizer.Deserialize<List<Task>>(rResponse);
        //        return RetCode.successful;
        //    }
        //    else
        //    {
        //        //tasks = null;
        //        return RetCode.unsuccessful;
        //    }
        //}
        #endregion

        #region Cache Methods


        public static List<T> ReadCachedObjects<T>()
        {
            IObjectSet<T> osTasks = CacheDB.QueryAndExecute<T>();
            return osTasks.ToList<T>();
        }
        public static T ReadCachedObject<T>(int id)
        {
            IQuery queryById = CacheDB.Query<T>();
            queryById.Descend("id").Constrain(id).Equal();
            IEnumerable<T> osTasks = queryById.Execute<T>();
            if (osTasks.Count() == 0) return default(T);
            return osTasks.First();
        }


        public static void UpdateCachedTasks(List<TimeStamp> timestamps)//, out List<Task> Deletions, out List<TimeStamp> Additions)
        {
            //Additions = timestamps.Except(CachedTasks).ToList();
            //Deletions = new List<Task>();
            foreach (TimeStamp item in timestamps)
            {
                IQueryable<Task> tasksById = from cachedtasks in CacheDB.AsQueryable<Task>()
                                             where cachedtasks.id.Equals(item.id)
                                             select cachedtasks;
                if (tasksById.Count() >= 1)
                {
                    foreach (Task taskItem in tasksById)
                    {
                        if (taskItem.updated_at < item.updated_at)
                        {
                            CacheDB.Delete<Task>(taskItem);
                            //Deletions.Add(taskItem);
                        }
                    }
                }
            }
            CacheDB.Commit();
        }

        public static void UpdateCachedPeople(List<TimeStamp> timestamps)
        {
            foreach (TimeStamp item in timestamps)
            {
                IQueryable<Person> personsById = from cachedpeople in CacheDB.AsQueryable<Person>()
                                                 where cachedpeople.id.Equals(item.id)
                                                 select cachedpeople;
                if (personsById.Count() == 1)
                {
                    foreach (Person taskItem in personsById)
                    {
                        if (taskItem.updated_at < item.updated_at)
                        {
                            CacheDB.Delete<Person>(taskItem);
                            //Deletions.Add(taskItem);
                        }
                    }
                }
            }
            CacheDB.Commit();
        }
        #endregion


        #region Helper Methods

        //public static DateTime? TaskLastUpdateAt(int id)
        //{
        //    TimeStamp timestamp;
        //    if (RetCode.successful == GetLatestTimeStamp(out timestamp, Model.task, id))
        //        return timestamp.updated_at;
        //    else
        //        return null;
        //}
        public static TimeStamp LatestTimeStamp(Model type, int id)
        {
            TimeStamp timestamp;
            if (RetCode.successful == GetLatestTimeStamp(out timestamp, type, id))
                return timestamp;
            else
                return null;
        }
        public static RetCode GetLatestTimeStamp(out TimeStamp timestamp, Model type, int id)
        {
            return GetLatestTimeStamp(out timestamp, type, id, ref  rRestClient, out rRestResponse);
        }

        public static RetCode GetLatestTimeStamp(out TimeStamp timestamp, Model type, int id, ref RestClient rClient, out IRestResponse rResponse)
        {

            JsonDeserializer JSONDeserilizer = new JsonDeserializer();
            if (RetCode.successful == ReadObject(ref rClient, @"timestamp/" + type.ToString() + @"/{id}", id.ToString(), out rResponse))
            {

                timestamp = JSONDeserilizer.Deserialize<TimeStamp>(rResponse);
                return RetCode.successful;
            }
            else
            {
                timestamp = new TimeStamp();
                timestamp.updated_at = DateTime.MaxValue;
                timestamp.created_at = DateTime.MaxValue;
                timestamp.id = id;
                return RetCode.unsuccessful;
            }
        }

        public static List<TimeStamp> LatestTimeStamps(Model type)
        {
            List<TimeStamp> timestamps;
            if (RetCode.successful == GetLatestTimeStamps(out timestamps, type))
                return timestamps;
            else
                return null;
        }
        public static RetCode GetLatestTimeStamps(out List<TimeStamp> timestamps, Model type)
        {
            return GetLatestTimeStamps(out timestamps, type, ref  rRestClient, out rRestResponse);
        }

        public static RetCode GetLatestTimeStamps(out List<TimeStamp> timestamps, Model type, ref RestClient rClient, out IRestResponse rResponse)
        {
            JsonDeserializer JSONDeserilizer = new JsonDeserializer();
            if (RetCode.successful == ReadObject(ref rClient, @"timestamps/" + type.ToString(), "", out rResponse))
            {

                timestamps = JSONDeserilizer.Deserialize<List<TimeStamp>>(rResponse);
                return RetCode.successful;
            }
            else
            {
                timestamps = null;
                return RetCode.unsuccessful;
            }
        }
        //public static RetCode ReadPeopleFromCache(out List<Person> people)
        //{
        //    IQueryable<List<Person>> qPeople = from _people in CacheDB.AsQueryable<List<Person>>()
        //                                       select _people;
        //    if (qPeople.Count() > 0)
        //    {
        //        people = qPeople.First();
        //        return RetCode.successful;
        //    }
        //    else
        //    {
        //        people = null;
        //        return RetCode.unsuccessful;
        //    }
        //}

        public static void SetMessage(string Message)
        {

            if (bMessage != null && lastMessage != Message)
                bMessage.Content = Message + Environment.NewLine + bMessage.Content;
            lastMessage = Message;
        }

        public static void SetState(string State)
        {
            if (bState != null && lastState != State)
                bState.Content = State + Environment.NewLine + bState.Content;
            lastState = State;
        }

        public static string GetResponseError()
        {
            String Error = "";
            if (rRestResponse != null)
            {
                if (rRestResponse.StatusCode != System.Net.HttpStatusCode.OK)
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

        public static void setOffline()
        {
            isOnline = false;
        }
        public static void setOnline()
        {
            isOnline = true;
        }

        #endregion
    }
}
