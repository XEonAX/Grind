using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.IO;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Threading;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Collections.Concurrent;
namespace Grind.Common
{

    public static class Globals
    {
        public static ObservableCollection<Person> People = new ObservableCollection<Person>();
        public static ConcurrentDictionary<string, Person> DictTrigramToPerson = new ConcurrentDictionary<string, Person>();
        public static ConcurrentDictionary<int, string> DictIdToPersonName = new ConcurrentDictionary<int, string>();
        public static ConcurrentDictionary<string, int> DictNameToPersonId = new ConcurrentDictionary<string, int>();
        public static ConcurrentDictionary<string, Person> DictNameToPerson = new ConcurrentDictionary<string, Person>();

        public static void Notify()
        {
            People.CollectionChanged += People_CollectionChanged;
        }
        public static void UnNotify()
        {
            People.CollectionChanged -= People_CollectionChanged;
        }

        public static void SyncPeopleDicts()
        {
            People_CollectionChanged(null, null);
        }

        public static void FillPeople(ObservableCollection<Person> NewPeople)
        {
            UnNotify();
            People.Clear();
            foreach (var person in NewPeople)
            {
                People.Add(person);
            }
            Notify();
            SyncPeopleDicts(); 
        }
        public static void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DictTrigramToPerson.Clear();
            DictIdToPersonName.Clear();
            DictNameToPersonId.Clear();
            DictNameToPerson.Clear();
            foreach (var person in Globals.People)
            {
                DictTrigramToPerson.TryAdd(person.trigram, person);
                DictIdToPersonName.TryAdd(person.id, person.name);
                DictNameToPersonId.TryAdd(person.name, person.id);
                DictNameToPerson.TryAdd(person.name, person);
            }

        }
        public static string GetPersonNameFromId(int id)
        {
            string name;
            if (DictIdToPersonName.TryGetValue(id, out name))
                return name;
            else if (id == 0)
            {
                return "Server";
            }
            else
                return "Unidentifed User (id=" + id.ToString() + ")";
        }
        public static Person GetPersonFromTrigram(string trigram)
        {
            Person person;
            if (DictTrigramToPerson.TryGetValue(trigram, out person))
                return person;
            else
            {
                return new Person { id = -1, name = @"Unidentifed User (trigram=""" + trigram + @""")", trigram = trigram, active = false };
            }
        }
        public static Person GetPersonFromName(string name)
        {
            Person person;
            if (DictTrigramToPerson.TryGetValue(name, out person))
                return person;
            else
            {
                return new Person { id = -1, name = @"Unidentifed User (name=""" + name + @""")", trigram = "", active = false };
            }
        }
        public static int GetPersonIdFromName(string name)
        {
            int id;
            if (DictNameToPersonId.TryGetValue(name, out id))
            {
                return id;
            }
            else
                return -1;
        }


    }
    public class Session
    {
        public RootObject rootObject;
        
        public Person User = new Person();

        public Controllers Controllers;
        public RestService RestService;
        public WebsocketService WebsocketService;
        public Cache Cache;
        public Callbacker Callbacker;
        public Session(string SqlConnectionString, string RestServiceEndpointUrl, string WebSocketServiceEndpointUrl, Callbacker Callbacker)
        {
            this.Callbacker = Callbacker;
            if (!Validate(SqlConnectionString, RestServiceEndpointUrl, WebSocketServiceEndpointUrl, Callbacker)) Environment.Exit(-1);
            Cache = new Cache(SqlConnectionString, Callbacker);
            RestService = new RestService(RestServiceEndpointUrl, Callbacker, User);
            WebsocketService = new WebsocketService(WebSocketServiceEndpointUrl, Callbacker);
            Controllers = new Controllers(Cache, RestService, WebsocketService, Callbacker);
        }

        private bool Validate(string SqlConnectionString, string RestServiceEndpointUrl, string WebSocketServiceEndpointUrl, Common.Callbacker Callbacker)
        {
            if (!File.Exists(SqlConnectionString.Substring(@"data source=".Length)))
            {
                Callbacker.callback(eAction.Error, SqlConnectionString.Substring(@"data source=".Length) + " is not accesible." +
                    Environment.NewLine +"Please correct and restart application");
                return false;
            }
            return true;
        }



        public RetCode ServerLogin(string trigram, string password)
        {
            RetCode ret = RestService.ServerLogin(trigram, password);
            User = RestService.User;
            return ret;
        }


        internal void Deauthorize()
        {
            System.Windows.Forms.MessageBox.Show("Invalid Token. Re-Login!!", "Forbidden", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            User.token = "";
        }

        public RetCode ReadPeople()
        {
            List<Person> cpeople = Cache.GetObjects<Person>();
            if (State.IsOnline)
            {
                List<TimeStamp> lts = Controllers.LatestTimeStamps<Person>();
                if (lts != null)
                {
                    if (RetCode.successful == RestService.ReadObject(RestService.rRestClient, "people", "", out RestService.rRestResponse))
                    {
                        Globals.FillPeople(JsonConvert.DeserializeObject<ObservableCollection<Person>>(RestService.rRestResponse.Content));
                        if (lts.Except(Cache.PeopleTS).ToList().Count > 0 || Cache.PeopleTS.Except(lts).ToList().Count > 0)
                        {
                            Cache.DeleteOldObjects<Person>(lts.Except(Cache.PeopleTS).ToList());
                            Cache.DeleteObjects<Person>(Cache.PeopleTS.Except(lts).ToList());
                            cpeople = Cache.GetObjects<Person>();
                            Cache.AddObjects<Person>(Globals.People.Except(cpeople).ToList());
                        }
                        return RetCode.successful;
                    }
                    else
                    {
                        Callbacker.callback(eAction.Message, "Offline Cache People");
                        Globals.FillPeople(new ObservableCollection<Person>(cpeople));
                        return RetCode.unsuccessful;
                    }
                }
                else
                {
                    Callbacker.callback(eAction.Message, "Offline Cache People");
                    Globals.FillPeople(new ObservableCollection<Person>(cpeople));
                    RestService.rRestResponse = null;
                    return RetCode.unsuccessful;
                }
            }
            else
            {

                Callbacker.callback(eAction.Message, "Up to date Cached People");
                Globals.FillPeople(new ObservableCollection<Person>(cpeople));
                RestService.rRestResponse = null;
                return RetCode.successful;//We have good people in cache
            }
        }

    }
}
