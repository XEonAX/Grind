using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Common
{
    public static class RestService
    {
        public static IRestClient rRestClient;
        public static IRestResponse rRestResponse;
        public static Action<IRestResponse> responseAction;
        public static void Init(string baseUrl, Action<IRestResponse> ResponseAction)
        {
            rRestClient = new RestClient(baseUrl);
            responseAction = ResponseAction;
        }

        #region Base Object CRUD Methods
        public static RetCode CreateObject(RootObject rootObject, IRestClient rClient, string requestResource, out IRestResponse rResponse)
        {
            RestRequest rRequest = new RestRequest();
            rRequest.DateFormat = "yyyy-MM-ddTHH:mm:ss.sss";
            rRequest.Resource = requestResource;
            rRequest.Method = Method.POST;
            rRequest.RequestFormat = DataFormat.Json;
            if(requestResource!="login") rootObject.Authorize();
            rRequest.AddBody(rootObject);
            rResponse = rClient.Execute(rRequest);
            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Helper.SetMessage("Creation Successful.");
                return RetCode.successful;
            }
            else
            {
                Helper.SetState(rResponse.ErrorMessage + " " + rRestResponse.StatusCode.ToString());
                responseAction(rResponse);
                return RetCode.unsuccessful;
            }
        }
        public static RetCode ReadObject(IRestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
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
                Helper.SetState("Online");
                return RetCode.successful;
            }
            else
            {
                Helper.SetState(rResponse.ErrorMessage);
                responseAction(rResponse);
                return RetCode.unsuccessful;
            }

        }
        public static RetCode UpdateObject(RootObject rootObject, IRestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
        {
            RestRequest rRequest = new RestRequest();
            rRequest.DateFormat = "yyyy-MM-ddTHH:mm:ss.sss";
            rRequest.Resource = requestResource;
            rRequest.Method = Method.PUT;
            rRequest.AddUrlSegment("id", requestResourceId);
            rRequest.RequestFormat = DataFormat.Json;
            rootObject.Authorize();
            rRequest.AddBody(rootObject);
            rResponse = rClient.Execute(rRequest);

            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Helper.SetState("Update Successful");
                return RetCode.successful;
            }
            else
            {
                Helper.SetState(rResponse.ErrorMessage);
                responseAction(rResponse);
                return RetCode.unsuccessful;
            }
        }
        public static RetCode DeleteObject(IRestClient rClient, string requestResource, string requestResourceId, out IRestResponse rResponse)
        {
            RestRequest rRequest = new RestRequest();
            rRequest.Resource = requestResource;// "task/{id}";
            rRequest.DateFormat = "yyyy-MM-ddTHH:mm:sssssZ";
            rRequest.AddUrlSegment("id", requestResourceId);
            rRequest.Method = Method.DELETE;
            rRequest.AddBody(new RootObject().Authorize());
            rResponse = rClient.Execute(rRequest);

            Globals.rootObject = JsonConvert.DeserializeObject<RootObject>(rResponse.Content);
            if (rResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Helper.SetState("Delete Successful");
                return RetCode.successful;
            }
            else
            {
                Helper.SetState(rResponse.ErrorMessage);
                return RetCode.unsuccessful;
            }
        }
        #endregion

        public static string GetResponseError()
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
                        Error = (rRestResponse.StatusCode.ToString() + RestService.rRestResponse.ErrorMessage).Trim();
                }
            }
            return Error;
        }
    }
}
