using SourceControlAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceControlAssignment1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Made by Mili Parikh";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Email ID: mili.parikh@thegatewaycorp.co.in";
            return View();
        }

        [HttpPost]
        public ActionResult StudentDetails(student s)
        {
            if(ModelState.IsValid)
            {
                ViewBag.FirstName = s.FirstName;
                ViewBag.MiddleName = s.MiddleName;
                ViewBag.LastName = s.LastName;
                ViewBag.Age = s.Age;
                ViewBag.PhoneNumber = s.PhoneNumber;
                ViewBag.Email = s.Email;
                ViewBag.ConfirmEmail = s.ConfirmEmail;
                ViewBag.College = s.College;
                ViewBag.Branch = s.Branch;
                return View("StudentDetails");
            }
            else
            {
                ViewBag.FirstName = "No Data";
                ViewBag.MiddleName = "No Data";
                ViewBag.LastName = "No Data";
                ViewBag.Age = "No Data";
                ViewBag.PhoneNumber = "No Data";
                ViewBag.Email = "No Data";
                ViewBag.ConfirmEmail = "No Data";
                ViewBag.College = "No Data";
                ViewBag.Branch = "No Data";
                return View("StudentDetails");

            }
        }
    }
}