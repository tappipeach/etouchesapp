using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using RestSharp;
using Newtonsoft.Json;

namespace RegCenter.Models
{
    public class Etouches
    {
        public String AccountKey = "c2d3a15e04e3fcbb96fcfcec42bed57d69fc69cb";
        public String AccountId = "1831";
        public String Username = "colinmcfadden";
        public String Password = "I@DelT43";

        const String BaseUrl = "https://etouches.com/api/v2";
      

        public Auth Authorize() {
            // create a restclient
            RestClient Client = new RestClient(BaseUrl + "/global/");
            Client.Authenticator = new SimpleAuthenticator("accountid", AccountId, "key", AccountKey);

            var request = new RestRequest("authorize.json", Method.GET);

            // var request will create this output: https://wwww.etouches/com/api/v2/global/authorize.json?accountid=...&key=_
            request.RequestFormat = DataFormat.Json;

            // assemble the uri
            var response = Client.Execute<Auth>(request);

            return response.Data;
        }

        // GET: Event details
        public EventsList GetEvent(String id, String token) {

            // new RestSharp client
            var eventClient = new RestClient("https://etouches.com/api/v2/");
            // new RestRequest
            var request = new RestRequest("ereg/getEvent.json?accesstoken=" + token + "&eventid=" + id, Method.GET);
            request.RequestFormat = DataFormat.Json;

            // execute URI, response contains query of JSON
            var response = eventClient.Execute(request);

            // var json = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
            // deserialize JSON
            var eventDetails = JsonConvert.DeserializeObject<EventsList>(response.Content);
            //var clicks = Convert.ToInt32(json.data.link_clicks.Value); NOT SURE WHAT THIS IS

            return eventDetails;
        }

        // GET: Event questions
        public QuestionsList GetQuestions(String id, String token) {

            // new RestSharp client
            var eventClient = new RestClient("https://etouches.com/api/v2/");
            // new RestRequest
            var request = new RestRequest("ereg/listQuestions.json?accesstoken=" + token + "&eventid=" + id, Method.GET);
            request.RequestFormat = DataFormat.Json;

            // execute URI, response contains query of JSON
            var response = eventClient.Execute(request);

            // var getQuestions = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
            // deserialize JSON
            var getQuestions = JsonConvert.DeserializeObject<List<QuestionsList>>(response.Content);
            //var clicks = Convert.ToInt32(json.data.link_clicks.Value); NOT SURE WHAT THIS IS

            return getQuestions;

        }

    }
}
