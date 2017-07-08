using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Models;

namespace WebChat.Controllers
{
    public class ChatController : Controller
    {
        // GET: Room
        [HttpGet]
        public ActionResult Room(string login)
        {
            var OurName = (string)Session["login"];
            ViewBag.OurName = OurName;
            return View();
        }
        [HttpPost]
        public ActionResult Room(string val,int a)
        {
            return View();
        }
    }
}