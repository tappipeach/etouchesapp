using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;

namespace RegCenter.Models
{
    public class QuestionsList
    {
        public Questions Questions { get; set; }
    }

    public class Questions
    {
        [JsonProperty("questionid")]
        public string questionid { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }
}