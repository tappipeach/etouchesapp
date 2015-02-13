using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using RestSharp;

namespace RegCenter.Models
{
    public class Etouches
    {
        public String AccountKey = "c2d3a15e04e3fcbb96fcfcec42bed57d69fc69cb";
        public String AccountId = "1831";
        public String Username = "colinmcfadden";
        public String Password = "I@DelT43";
      

        public Auth Authorize() {
            // create a restclient
            RestClient Client = new RestClient("https://www.etouches.com/api/v2/global/");
            Client.Authenticator = new SimpleAuthenticator("accountid", AccountId, "key", AccountKey);

            var request = new RestRequest("authorize.json", Method.GET);

            // var request will create this output: https://wwww.etouches/com/api/v2/global/authorize.json?accountid=...&key=_
            request.RequestFormat = DataFormat.Json;

            // assemble the uri
            var yes = Client.Execute<Auth>(request);

            return yes.Data;
        }

        public EventsList getEvents()
        {
            RestClient Client = new RestClient("https://www.etouches.com/api/v2/global/");
            Etouches consume = new Etouches();
            Auth authorize = consume.Authorize();

            Client.Authenticator = new SimpleAuthenticator("accesstoken", authorize.accesstoken);

        }

    }
}