using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Models;
using System.IO;
using Newtonsoft.Json;

namespace WebChat.Controllers
{
    public class ChatController : Controller
    {
        UserContext DbUser = new UserContext();
        static object locker = new object();
        
        [HttpGet]
        public ActionResult Room()
        {
            if(Request.Cookies["NickName"] != null){
                lock (locker)
                {
                    var lines = System.IO.File.ReadAllLines(Server.MapPath("~/Content/ChatRoom/Messages.txt"));
                    ViewBag.lines = lines;
                }
            }
            else {
                return RedirectToAction("LoginForm", "Home");
            }
                          
            return View();
        }

        [HttpPost]
        public JsonResult Room(string message)
        {
            lock(locker)
            {
                FileStream file1 = new FileStream(Server.MapPath("~/Content/ChatRoom/Messages.txt"), FileMode.Append);
                StreamWriter writer = new StreamWriter(file1);

                HttpCookie cookieNickName = Request.Cookies["NickName"];
             
                writer.Write(cookieNickName.Value + ":" + message + "\r");
                writer.Close();
            }

            lock (locker)
            {
                var lines = System.IO.File.ReadAllLines(Server.MapPath("~/Content/ChatRoom/Messages.txt"));
                ViewBag.lines = lines;

                return Json(lines, JsonRequestBehavior.AllowGet);

            }                   
        }

        [HttpPost]
        public ActionResult SignOff()
        {
            Response.Cookies["NickName"].Expires = System.DateTime.Now.AddYears(-50);

            return RedirectToAction("LoginForm", "Home");
        }

        [HttpGet]
        public JsonResult ResultOfText()
        {
            lock(locker)
            {
                var lines = System.IO.File.ReadAllLines(Server.MapPath("~/Content/ChatRoom/Messages.txt"));

                var resultOfThis = JsonConvert.SerializeObject(lines);

                return Json(resultOfThis, JsonRequestBehavior.AllowGet);
            }       
        }
    }
}