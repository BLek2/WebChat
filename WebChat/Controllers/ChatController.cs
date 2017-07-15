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
            var lines = System.IO.File.ReadAllLines(Server.MapPath("~/Content/ChatRoom/Messages.txt"));
            ViewBag.lines = lines;

          
            FileStream file1 = new FileStream(Server.MapPath("~/Content/ChatRoom/CookieList.txt"), FileMode.Create);
            StreamWriter writer = new StreamWriter(file1);

            HttpCookie cookieNickName = Request.Cookies["NickName"];

            writer.Write(cookieNickName.Value + "\r");
            writer.Close();

            var cookie = System.IO.File.ReadAllLines(Server.MapPath("~/Content/ChatRoom/CookieList.txt"));
            ViewBag.cookie = cookie;


            return View();
        }
        [HttpPost]
        public JsonResult Room(string message)
        {
            FileStream file1 = new FileStream(Server.MapPath("~/Content/ChatRoom/Messages.txt"),FileMode.Append);
            StreamWriter writer = new StreamWriter(file1);

            HttpCookie cookieNickName = Request.Cookies["NickName"];

            writer.Write(cookieNickName.Value+":"+message + "\r");
            writer.Close();

            var lines = System.IO.File.ReadAllLines(Server.MapPath("~/Content/ChatRoom/Messages.txt"));
            ViewBag.lines = lines;

            return Json(lines,JsonRequestBehavior.AllowGet);
        }
    }
}