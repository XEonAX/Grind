using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Serializers;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using System.Data;
using System.Reflection;
using System.Collections;
using Grind.Common;
using System.Windows.Controls;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
namespace Grind.Common
{
    public class Controllers
    {

       private Cache Cache;
        private RestService RestService;
        private WebsocketService WebsocketService;
        private Callbacker Callbacker;


        public Controllers(Cache Cache, RestService RestService)
        {
            // TODO: Complete member initialization
            this.Cache = Cache;
            this.RestService = RestService;
        }

        public Controllers(Common.Cache Cache, Common.RestService RestService, WebsocketService WebsocketService)
        {
            // TODO: Complete member initialization
            this.Cache = Cache;
            this.RestService = RestService;
            this.WebsocketService = WebsocketService;
        }

        public Controllers(Common.Cache Cache, Common.RestService RestService, Common.WebsocketService WebsocketService, Callbacker Callbacker)
        {
            // TODO: Complete member initialization
            this.Cache = Cache;
            this.RestService = RestService;
            this.WebsocketService = WebsocketService;
            this.Callbacker = Callbacker;
        }


        #region Person and People CRUD Methods
        public RetCode CreatePerson(Person person)
        {
            return CreatePerson(person, RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode CreatePerson(Person person, IRestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.person = person;
            return RestService.CreateObject(rootObject, rClient, "person", out rResponse);
        }

        public RetCode UpdatePerson(Person person)
        {
            return UpdatePerson(person, RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode UpdatePerson(Person person, IRestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.person = person;
            return RestService.UpdateObject(rootObject, rClient, "person/{id}", person.id.ToString(), out rResponse);
        }


        public RetCode ReadPeople(ObservableCollection<Person> people)
        {
            return ReadPeople(people, RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode ReadPeople(ObservableCollection<Person> people, IRestClient rClient, out IRestResponse rResponse)
        {

            List<Person> cpeople = Cache.GetObjects<Person>();
            if (State.IsOnline)
            {
                List<TimeStamp> lts = LatestTimeStamps<Person>();
                if (lts != null)
                {
                    if (RetCode.successful == RestService.ReadObject(rClient, "people", "", out rResponse))
                    {

                        people = JsonConvert.DeserializeObject<ObservableCollection<Person>>(rResponse.Content);
                        if (lts.Except(Cache.PeopleTS).ToList().Count > 0 || Cache.PeopleTS.Except(lts).ToList().Count > 0)
                        {
                            Cache.DeleteOldObjects<Person>(lts.Except(Cache.PeopleTS).ToList());
                            Cache.DeleteObjects<Person>(Cache.PeopleTS.Except(lts).ToList());
                            cpeople = Cache.GetObjects<Person>();
                            Cache.AddObjects<Person>(people.Except(cpeople).ToList());
                        }
                        return RetCode.successful;
                    }
                    else
                    {
                        Callbacker.callback(eAction.Message, "Offline Cache People");
                        people = new ObservableCollection<Person>(cpeople);
                        return RetCode.unsuccessful;
                    }
                }
                else
                {

                    Callbacker.callback(eAction.Message, "Offline Cache People");
                    people = new ObservableCollection<Person>(cpeople);
                    rResponse = null;
                    return RetCode.unsuccessful;
                }
            }
            else
            {

                Callbacker.callback(eAction.Message, "Up to date Cached People");
                people = new ObservableCollection<Person>(cpeople);
                rResponse = null;
                return RetCode.successful;//We have good people in cache
            }
        }

        public RetCode DeletePerson(Person person)
        {
            return DeletePerson(person, RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode DeletePerson(Person person, IRestClient rClient, out IRestResponse rResponse)
        {
            return RestService.DeleteObject(rClient, "person/{id}", person.id.ToString(), out rResponse);
        }
        #endregion

        #region Task CRUD Methods
        public RetCode CreateTask(Task task)
        {
            return CreateTask(task, RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode CreateTask(Task task, IRestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.Task = task;
            return RestService.CreateObject(rootObject, rClient, "task", out rResponse);
        }

        public RetCode ReadTask(int taskId, out Task task)
        {
            return ReadTask(taskId, out task, RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode ReadTask(int taskId, out Task task, IRestClient rClient, out IRestResponse rResponse)
        {
            task = null;
            Task ctask = Cache.GetObject<Task>(taskId);
            if (State.IsOnline)
            {
                TimeStamp lt = LatestTimeStamp<Task>(taskId);
                if (lt != null)
                {
                    if (ctask != null)
                    {
                        if (ctask.updated_at == lt.updated_at)
                        {
                            Callbacker.callback(eAction.Message, "Up to date Task From Cache");
                            task = ctask;
                            rResponse = null;
                            return RetCode.successful;
                        }
                        else
                        {
                            Cache.DeleteObject<Task>(ctask.id);
                        }
                    }
                    //If it reaches here it means No cached task or stale task
                    if (RetCode.successful == RestService.ReadObject(rClient, "task/{id}", taskId.ToString(), out rResponse))
                    {
                        task = JsonConvert.DeserializeObject<Task>(rResponse.Content);

                        Callbacker.callback(eAction.Message, "Task Added to Cache:" + task.name);
                        Cache.AddObject<Task>(task);
                        return RetCode.successful;
                    }
                    else
                    {
                        task = ctask;
                        Callbacker.callback(eAction.Message, "Offline Stale Task From Cache");
                        task = null;
                        //task = null;// new Task();
                        return RetCode.unsuccessful;
                    }
                }
                else
                {
                    Callbacker.callback(eAction.Message, "Get Timestamp Failed");
                    task = ctask;
                    rResponse = null;
                    return RetCode.unsuccessful;
                }
            }
            else
            {
                Callbacker.callback(eAction.Message, "Offline Task From Cache");
                task = ctask;
                //We have Cached Task
                rResponse = null;
                return RetCode.successful;
            }
        }


        public RetCode UpdateTask(Task task)
        {
            return UpdateTask(task, RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode UpdateTask(Task task, IRestClient rClient, out IRestResponse rResponse)
        {
            RootObject rootObject = new RootObject();
            rootObject.Task = task;
            return RestService.UpdateObject(rootObject, rClient, "task/{id}", task.id.ToString(), out rResponse);
        }

        public RetCode DeleteTask(Task task)
        {
            return DeleteTask(task, RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode DeleteTask(Task task, IRestClient rClient, out IRestResponse rResponse)
        {
            return RestService.DeleteObject(rClient, "task/{id}", task.id.ToString(), out rResponse);
        }
        #endregion

        #region Tasks Read Methods
        public RetCode ReadTasks(ref SortableBindingList<TaskListItem> tasks)
        {
            return ReadTasks(ref tasks, RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode ReadTasks(ref SortableBindingList<TaskListItem> tasks, IRestClient rClient, out IRestResponse rResponse)
        {
            List<Task> ctasks = Cache.GetObjects<Task>();
            if (State.IsOnline)
            {
                List<TimeStamp> lts = LatestTimeStamps<Task>();
                if (lts != null)
                {
                    if (RetCode.successful == RestService.ReadObject(rClient, "taskslist", "", out rResponse))
                    {
                        if (tasks == null) tasks = new SortableBindingList<TaskListItem>();
                        tasks.Clear();
                        SortableBindingList<TaskListItem> DesrializedTasks = JsonConvert.DeserializeObject<SortableBindingList<TaskListItem>>(rResponse.Content);
                        foreach (Task item in DesrializedTasks)
                            tasks.Add(item.AsTaskListItem());
                        if (lts.Except(Cache.TasksTS).Count() > 0)
                        {
                            Cache.DeleteOldObjects<Task>(lts);
                        }
                        return RetCode.successful;
                    }
                    else
                    {
                        if (ctasks != null)
                        {
                            if (tasks == null) tasks = new SortableBindingList<TaskListItem>();
                            tasks.Clear();
                            foreach (Task item in ctasks)
                                tasks.Add(item.AsTaskListItem());
                            Callbacker.callback(eAction.Message, "Offline TaskList From Cache");
                        }
                        else
                            tasks = null;
                        return RetCode.unsuccessful;
                    }
                }
                else
                {
                    if (ctasks != null)
                    {
                        if (tasks == null) tasks = new SortableBindingList<TaskListItem>();
                        tasks.Clear();
                        foreach (Task item in ctasks)
                            tasks.Add(item.AsTaskListItem());
                        Callbacker.callback(eAction.Message, "Offline TaskList From Cache");
                    }
                    else
                        tasks = null;
                    rResponse = null;
                    return RetCode.unsuccessful;
                }
            }
            else
            {
                if (ctasks != null)
                {
                    if (tasks == null) tasks = new SortableBindingList<TaskListItem>();
                    tasks.Clear();
                    foreach (Task item in ctasks)
                        tasks.Add(item.AsTaskListItem());
                    Callbacker.callback(eAction.Message, "Offline TaskList From Cache");
                }
                else
                    tasks = null;
                rResponse = null;
                return RetCode.successful;
            }

        }


        public RetCode GetAndStoreTasks()
        {
            return GetAndStoreTasks(RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode GetAndStoreTasks(IRestClient rClient, out IRestResponse rResponse)
        {
            List<Task> ctasks = Cache.GetObjects<Task>();
            List<Task> tasks;
            if (State.IsOnline)
            {
                List<TimeStamp> lts = LatestTimeStamps<Task>();
                if (lts != null)
                {
                    if (RetCode.successful == RestService.ReadObject(rClient, "tasks", "", out rResponse))
                    {

                        tasks = JsonConvert.DeserializeObject<List<Task>>(rResponse.Content);
                        if (lts.Except(Cache.TasksTS).ToList().Count > 0)
                        {
                            Cache.DeleteOldObjects<Task>(lts);
                            Cache.AddObjects<Task>(tasks.Except(ctasks).ToList());
                        }
                        return RetCode.successful;
                    }
                    else
                    {
                        Callbacker.callback(eAction.Message, "Offline Cache Tasks");
                        return RetCode.unsuccessful;
                    }
                }
                else
                {
                    Callbacker.callback(eAction.Message, "Offline Cache Tasks");
                    rResponse = null;
                    return RetCode.unsuccessful;
                }
            }
            else
            {
                Callbacker.callback(eAction.Message, "Up to date Cached Tasks");
                rResponse = null;
                return RetCode.successful;//We have good tasks in cache
            }

        }

        //public RetCode ReadTasks(ref List<Task> tasks)
        //{
        //    return ReadTasks(ref tasks,  RestService.rRestClient, out RestService.rRestResponse);
        //}
        //public RetCode ReadTasks(ref List<Task> tasks, IRestClient rClient, out IRestResponse rResponse)
        //{
        //    JsonDeserializer JSONDeserilizer = new JsonDeserializer();
        //    if (RetCode.successful == ReadObject(rClient, "tasks", "", out rResponse))
        //    {
        //        tasks = JsonConvert.DeserializeObject<List<Task>>(rResponse.Content);
        //        return RetCode.successful;
        //    }
        //    else
        //    {
        //        //tasks = null;
        //        return RetCode.unsuccessful;
        //    }
        //}
        #endregion

        #region TimeStamp Methods
        public TimeStamp LatestTimeStamp<T>(int id)
        {
            TimeStamp timestamp;
            if (RetCode.successful == GetLatestTimeStamp<T>(out timestamp, id))
                return timestamp;
            else
                return null;
        }
        public RetCode GetLatestTimeStamp<T>(out TimeStamp timestamp, int id)
        {
            return GetLatestTimeStamp<T>(out timestamp, id, RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode GetLatestTimeStamp<T>(out TimeStamp timestamp, int id, IRestClient rClient, out IRestResponse rResponse)
        {
            if (RetCode.successful == RestService.ReadObject(rClient, @"timestamp/" + typeof(T).Name.ToLower() + @"/{id}", id.ToString(), out rResponse))
            {

                timestamp = JsonConvert.DeserializeObject<TimeStamp>(rResponse.Content);
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
        #endregion

        #region TimeStamps Methods
        public List<TimeStamp> LatestTimeStamps<T>()
        {
            List<TimeStamp> timestamps;
            if (RetCode.successful == GetLatestTimeStamps<T>(out timestamps))
                return timestamps;
            else
                return null;
        }
        public RetCode GetLatestTimeStamps<T>(out List<TimeStamp> timestamps)
        {
            return GetLatestTimeStamps<T>(out timestamps, RestService.rRestClient, out RestService.rRestResponse);
        }
        public RetCode GetLatestTimeStamps<T>(out List<TimeStamp> timestamps, IRestClient rClient, out IRestResponse rResponse)
        {
            if (RetCode.successful == RestService.ReadObject(rClient, @"timestamps/" + typeof(T).Name.ToLower(), "", out rResponse))
            {
                timestamps = JsonConvert.DeserializeObject<List<TimeStamp>>(rResponse.Content);
                return RetCode.successful;
            }
            else
            {
                timestamps = null;
                return RetCode.unsuccessful;
            }
        }
        #endregion
    }
}
