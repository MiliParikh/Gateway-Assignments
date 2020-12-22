using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LoginRegistrationDisplay.Models;
using NLog;

namespace LoginRegistrationDisplay.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private DB_Entities _db = new DB_Entities();

        
        public ActionResult Index()
        {
            if (Session["IdUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        private static Logger logger = LogManager.GetLogger("MyAppLoggerRules");


        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user, HttpPostedFileBase file)
        {

            logger.Info("Entering the Home Controller. Starting Registration");
            try
            {
                if (ModelState.IsValid)
                {
                    var check = _db.Table.FirstOrDefault(s => s.EmailID == _user.EmailID);
                    if (check == null)
                    {
                        if (file != null)
                        {
                            _user.Image = _user.FirstName + _user.PhoneNumber + Path.GetExtension(file.FileName);
                            file.SaveAs(Server.MapPath("//Content//UserImages//") + _user.Image);
                        }

                        _user.Password = GetMD5(_user.Password);
                        _db.Configuration.ValidateOnSaveEnabled = false;
                        _db.Table.Add(_user);
                        _db.SaveChanges();

                        logger.Info("Registration successful :) ");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        logger.Info("Registration failed :( ");
                        ViewBag.error = "Email already exists";
                        return View();
                    }
                }
                return View();
            }

            catch (Exception e)
            {
                logger.Error("Exception occured." + e.Message);
                return Content("Exception in Registration" + e.Message);
            }
            
        }


        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin _userLogin)
        {
            logger.Info("Entering the Home Controller. Starting Login.");
            try
            {
                if (ModelState.IsValid)
                {
                    var f_password = GetMD5(_userLogin.Password);
                    var data = _db.Table.Where(s => s.EmailID.Equals(_userLogin.EmailID) && s.Password.Equals(f_password)).ToList();
                    if (data.Count() > 0)
                    {
                        //add session
                        Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                        Session["EmailID"] = data.FirstOrDefault().EmailID;
                        Session["PhoneNumber"] = data.FirstOrDefault().PhoneNumber;
                        Session["Age"] = data.FirstOrDefault().Age;
                        Session["DateOfBirth"] = data.FirstOrDefault().DateOfBirth;
                        Session["Image"] = data.FirstOrDefault().Image;

                        logger.Info("Login successful :) ");

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        logger.Info("Login failed :( ");
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Register");
                    }
                }
                return View();
            }

            catch (Exception e)
            {
                logger.Error("Exception occured." + e.Message);
                return Content("Exception in Login" + e.Message);

            }
        }


        //Logout
        public ActionResult Logout()
        {
            logger.Info("Starting Logout.");
            try
            {
                Session.Clear();//remove session
                logger.Info("Logout successful :) ");
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                logger.Error("Exception occured." + e.Message);
                return Content("Exception in Logout" + e.Message);
            }
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }


    }
}