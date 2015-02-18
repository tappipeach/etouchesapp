using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegCenter.Models;
using RestSharp;
using Newtonsoft.Json;

namespace RegCenter.Controllers
{
    public class EventsController : Controller
    {
        // GET: Access Token
        public static string getKey 
        {
            get 
            {
                // initiate Etouches model
                 Etouches consume = new Etouches();
                // get accesstoken from Authorize function
                 var key = consume.Authorize().accesstoken;

                 return key;
            }
        }

        // GET: Events
        public ActionResult Papercon()
        {
            Etouches consume = new Etouches();
            // event id, assigned by eTouches
            String eventId = "97742";

            // call GetEvent(id, token) in Etouched model, 
            // returns parsed JSON of full event details
            var eventDetails = consume.GetEvent(eventId, getKey);
            var listQuestions = consume.GetQuestions(eventId, getKey);

            List<QuestionsList> questionList = JsonConvert.DeserializeObject<List<QuestionsList>>(listQuestions);
            ViewBag.questions = questionList;

            ViewBag.test = eventDetails.name;
            ViewBag.test1 = eventDetails.code;
            ViewBag.dates = eventDetails.startdate + " to " + eventDetails.enddate;

            return View();
        }

        public ActionResult IbbcPeers()
        {
            return View();
        }

        public ActionResult Nano()
        {
            return View();
        }

        public ActionResult Aicc()
        {
            return View();
        }

        public ActionResult EuroPlace()
        {
            return View();
        }

        public ActionResult Index()
        {
            Etouches consume = new Etouches();

            //initiate list of events
            List<AllEvents> eventsList = JsonConvert.DeserializeObject<List<AllEvents>>(consume.ListEvents(getKey));
            ViewBag.list = eventsList;
    
            return View();
        }
    }
}