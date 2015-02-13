using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegCenter.Models;

namespace RegCenter.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Papercon()
        {

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
    }
}