using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Models;
using SaatSatış.DAL;

namespace SaatSatış.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        WatchContext db = new WatchContext();
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Md5(user.Password);
               
                if(user.Status == null)
                {
                    user.Status = "User";
                }
                db.Users.Add(user);   
                db.SaveChanges();
                return RedirectToAction("Index", "Front");
            }else
                return View();
        }
        public ActionResult LogInPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult LogInPartial(string userName, string pass)
        {
            string password = Md5(pass);
            User user = db.Users.Where(u => u.UserName == userName && u.Password == password).SingleOrDefault();
            if (user != null && user.Status == "Admin")
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["UserID"] = user.UserID;
                Session["UserName"] = user.UserName;
                Session.Timeout = 2;
                return RedirectToAction("Index", "Watches");
            }
            else if (user != null && user.Status == "User")
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["UserID"] = user.UserID;
                Session["UserName"] = user.UserName;
                Session.Timeout = 2;
                return RedirectToAction("Index","Front");
            }
            return PartialView();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Front");
        }
        public string Md5(string strSifre)
        {
            MD5 md5 = MD5.Create();
            byte[] hashData = md5.ComputeHash(Encoding.UTF8.GetBytes(strSifre));

            string strHashedPassword = "";
            for (int i = 0; i < hashData.Length; i++)
            {
                strHashedPassword += hashData[i].ToString("x2");
            }
            return strHashedPassword;
        }
    }
}