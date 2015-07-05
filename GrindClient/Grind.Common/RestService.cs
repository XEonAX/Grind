using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Common
{
    public class RestService
    {
        public IRestClient rRestClient;
        public IRestResponse rRestResponse;
        private string RestServiceEndpointUrl;
        private Callbacker Callbacker;
        public Person User;

        public RestService(string RestServiceEndpointUrl)
        {
            // TODO: Complete member initialization
            this.RestServiceEndpointUrl = RestServiceEndpointUrl;
        }

        public RestService(string RestServiceEndpointUrl, Callbacker Callbacker)
        {
            // TODO: Complete member initialization
            rRestClient = new RestClient(RestServiceEndpointUrl);
            this.Callbacker = Callbacker;
        }

        public RestService(string RestServiceEndpointUrl, Common.Callbacker Callbacker, Person User)
        {
            // TODO: Complete member initialization
            this.RestServiceEndpointUrl = RestServiceEndpointUrl;
            this.Callbacker = Callbacker;
            this.User = User;
            rRestClient = new RestClient(RestServiceEndpointUrl);
        }

        public RetCode ServerLogin(string trigram, string password)
        {
            RootObject rootObject = new RootObject { person = new Person { trigram = trigram, password = password } };
            rootObject.person = new Person { trigram = trigram, password = password };
            if (CreateObject(rootObject, rRestClient, "login", out rRestResponse) == RetCode.successful)
            {
                User = JsonConvert.DeserializeObject<Person>(rRestResponse.Content);
                return RetCode.successful;
            }
            else
            {
                //Callbacker.callback(eAction.RestError, rRestResponse.StatusCode, rRestResponse.ErrorMessage, rRestResponse.Content);
                return RetCode.unsuccessful;
            }
        }

        #region Base Object CRUD Methods
        public RetCode CreateObject(RootObject rootObject, IRestClient rClient, string requestResource, out IRestResponse rResponse)
        {
            RestRequest rRequest = new RestRequest();
            rRequest.DateFormat = "yyyy-MM-ddTHH:mm:ss.sss";
            rRequest.Resource = requestResource;
            rRequest.Method = Method.POST;
            rRequest.RequestFormat = DataFormat.Json;
            if (requestResource != "login") Authorize(rootObject);
            rRequest.AddBody(rootObject);
            rResponse = rClient.Execute(rRequest);
            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (requestResource != "login") Callbacker.callback(eAction.Message, "Creation Successful.");
                return RetCode.successful;
            }
            else
            {
                Callbacker.callback(eAction.RestError, rResponse.StatusCode, rResponse.ErrorMessage, rResponse.Content);
                return RetCode.unsuccessful;
            }
        }
        public RetCode ReadObject(IRestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
        {
            RestRequest rRequest = new RestRequest();
            rRequest.Resource = requestResource;// "task/{id}";
            rRequest.DateFormat = "yyyy-MM-ddTHH:mm:ss.sss";
            //rRequest.DateFormat = "yyyy-MM-ddTHH:mm:sssssZ";
            if (requestResource.Contains("{id}")) rRequest.AddUrlSegment("id", requestResourceId);
            rRequest.Method = Method.GET;
            rResponse = rClient.Execute(rRequest);
            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Callbacker.callback(eAction.State,"Online");
                return RetCode.successful;
            }
            else
            {
                Callbacker.callback(eAction.RestError,rResponse.StatusCode,rResponse.ErrorMessage,rResponse.Content);
                return RetCode.unsuccessful;
            }

        }
        public RetCode UpdateObject(RootObject rootObject, IRestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
        {
            RestRequest rRequest = new RestRequest();
            rRequest.DateFormat = "yyyy-MM-ddTHH:mm:ss.sss";
            rRequest.Resource = requestResource;
            rRequest.Method = Method.PUT;
            rRequest.AddUrlSegment("id", requestResourceId);
            rRequest.RequestFormat = DataFormat.Json;
            Authorize(rootObject);
            rRequest.AddBody(rootObject);
            rResponse = rClient.Execute(rRequest);

            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Callbacker.callback(eAction.State,"Update Successful");
                return RetCode.successful;
            }
            else
            {
                Callbacker.callback(eAction.RestError, rResponse.StatusCode, rResponse.ErrorMessage, rResponse.Content);
                return RetCode.unsuccessful;
            }
        }
        public RetCode DeleteObject(IRestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
        {
            RestRequest rRequest = new RestRequest();
            rRequest.Resource = requestResource;// "task/{id}";
            rRequest.DateFormat = "yyyy-MM-ddTHH:mm:sssssZ";
            rRequest.AddUrlSegment("id", requestResourceId);
            rRequest.Method = Method.DELETE;
            rRequest.AddBody(Authorize(new RootObject()));
            rResponse = rClient.Execute(rRequest);
            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Callbacker.callback(eAction.State,"Delete Successful");
                return RetCode.successful;
            }
            else
            {
                Callbacker.callback(eAction.RestError, rResponse.StatusCode, rResponse.ErrorMessage, rResponse.Content);
                return RetCode.unsuccessful;
            }
        }
        #endregion

        public string GetResponseError()
        {
            String Error = "";
            if (rRestResponse != null)
            {
                if (rRestResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    if (rRestResponse.ContentType == @"application/json")
                    {
                        RootObject RO = JsonConvert.DeserializeObject<RootObject>(rRestResponse.Content);
                        Error = RO.Message;
                    }
                    else
                        Error = (rRestResponse.StatusCode.ToString() + rRestResponse.ErrorMessage).Trim();
                }
            }
            return Error;
        }
        public RootObject Authorize(RootObject RO)
        {
            if (User.token != null)
                RO.token = User.token;
            else
            {
                Callbacker.callback(eAction.Error, "Not LoggedIn");
            }
            return RO;
        }
    }
}
