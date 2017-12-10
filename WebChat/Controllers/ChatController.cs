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
        // GET: Room
        [HttpGet]
        public ActionResult Room()
        {
            lock (locker)
            {
                var lines = System.IO.File.ReadAllLines(Server.MapPath("~/Content/ChatRoom/Messages.txt"));
                ViewBag.lines = lines;

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