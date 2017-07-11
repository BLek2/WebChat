using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Models;
using System.IO;

namespace WebChat.Controllers
{
    public class ChatController : Controller
    {
        UserContext DbUser = new UserContext();
        // GET: Room
        [HttpGet]
        public ActionResult Room()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Room(string message)
        {
            FileStream file1 = new FileStream(Server.MapPath("~/Content/Messages/Messages.txt"),FileMode.Append);
            StreamWriter writer = new StreamWriter(file1);

            HttpCookie cookieNickName = Request.Cookies["NickName"];

            writer.Write(cookieNickName.Value+":"+message + "\r\n");
            writer.Close();

            return View();
        }
    }
}