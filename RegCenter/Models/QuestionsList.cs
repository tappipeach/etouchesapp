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
        public int questionid { get; set; }
        public string fieldname { get; set; }
        public int fieldtype { get; set; }
        public string name { get; set; }
        public int pageid {get; set;}
        public string page { get; set; }
    }
}