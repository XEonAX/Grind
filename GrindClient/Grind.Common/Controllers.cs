using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace Grind.Common
{
    public  class Controllers
    {
        #region Statics
        public static RestClient rRestClient;
        public static IRestResponse rRestResponse;
        public static string Message;
        public Controllers(string baseUrl)
        {
            rRestClient = new RestClient(baseUrl);
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
                return true;
            }
            else
                return false;            
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
            rRequest.AddUrlSegment("id", requestResourceId);
            rRequest.Method = Method.GET;
            rResponse = rClient.Execute(rRequest);
            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
                return false;  
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
                return true;
            }
            else
                return false;
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
                return true;
            else
                return false;
        }         
        #endregion

        #region Person and People CRUD Methods
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

        public static bool ReadPeople(ref List<Person> people)
        {
            return ReadPeople(ref people, ref rRestClient, out rRestResponse);
        }
        public static bool ReadPeople(ref List<Person> people, ref RestClient rClient, out IRestResponse rResponse)
        {
            JsonDeserializer JSONDeserilizer = new JsonDeserializer();
            if (ReadObject(ref rClient, "people", "", out rResponse))
            {
                people = JSONDeserilizer.Deserialize<List<Person>>(rResponse);
                return true;
            }
            else
            {
                //people = new List<Person>();
                return false;
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

        public static bool ReadTask(int taskId, ref Task task)
        {
            return ReadTask(taskId, ref task, ref rRestClient, out rRestResponse);
        }
        public static bool ReadTask(int taskId, ref Task task, ref RestClient rClient, out IRestResponse rResponse)
        {
            JsonDeserializer JSONDeserilizer = new JsonDeserializer();
            if (ReadObject(ref rClient, "task/{id}", taskId.ToString(), out rResponse))
            {
                task = JSONDeserilizer.Deserialize<Task>(rResponse);
                return true;
            }
            else
            {
                //task=new Task();
                return false;
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
        public static bool ReadTasks(ref SortableBindingList<ClientTask> tasks)
        {
            return ReadTasks(ref tasks, ref rRestClient, out rRestResponse);
        }
        public static bool ReadTasks(ref SortableBindingList<ClientTask> tasks, ref RestClient rClient, out IRestResponse rResponse)
        {
            JsonDeserializer rJSONDeserializer = new JsonDeserializer();
            if (ReadObject(ref rClient, "tasks", "", out rResponse))
            {
                if (tasks == null) tasks = new SortableBindingList<ClientTask>();
                tasks.Clear();
                foreach (ClientTask item in rJSONDeserializer.Deserialize<SortableBindingList<ClientTask>>(rResponse))
                {
                    tasks.Add(item);
                }    
                //tasks = rJSONDeserializer.Deserialize<SortableBindingList<ClientTask>>(rResponse);
                return true;
        
            }
            else
            {
                //tasks = new SortableBindingList<ClientTask>(); 
                return false;
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

    }
}
