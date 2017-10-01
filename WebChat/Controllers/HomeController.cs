using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Models;
using System.Net;
using System.Net.Mail;



namespace WebChat.Controllers
{
    public class HomeController : Controller
    {
        UserContext DbUser = new UserContext();
        // GET: Home
        [HttpGet]
        public ActionResult LoginForm()
        {


            return View();
        }
        [HttpPost]
        public ActionResult LoginForm(string login, string password)
        {

            IEnumerable<User> users = DbUser.Users;

            foreach (var b in users)
            {
                if(b.NickName == login && b.Password == password)
                {
                    ToSetCookie(login);
                    return RedirectToAction("Room","Chat");
                }
            }

            
            return View();
        }
        [HttpGet]
        public ActionResult RegisterForm()
        {
            return View(DbUser.Users);
        }
        [HttpPost]
        public JsonResult RegisterForm(string nickname, string email, string password)
        {
            IQueryable<User> NickNames = DbUser.Users;
             foreach(var b in NickNames)
            {
                   if(b.NickName == nickname)
                {
                    return Json("Такой никнейм уже существует",JsonRequestBehavior.AllowGet);
                }
                   if(b.Email == email)
                {
                    return Json("Такой электронный адрес уже зарегистрированный!",JsonRequestBehavior.AllowGet);
                }
                
            }
            User user = new User
            {
                NickName = nickname,
                Email = email,
                Password = password
            };
            DbUser.Users.Add(user);
            DbUser.SaveChanges();

            ToSetCookie(nickname);

            return Json("Вы успешно зарегистрированы. Можете войти в чат!", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {

            return View();
        }


        private void ToSetCookie(string value)
        {
            HttpCookie cookie = new HttpCookie("NickName");
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddHours(24);
            Response.Cookies.Add(cookie);
        }

    }
}