using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SYSPROInternSalaryCalculator.Models;
using System.Data.Entity;

namespace SYSPROInternSalaryCalculator.Controllers
{
    public class HomeController : Controller
    {
        public SysproDBContext db = new SysproDBContext();
        public ActionResult Index()
        {

            //Providing default dates ranging 30 days so that user doesn't have to input from scratch
            ViewData["dateFrom"] = DateTime.Now.AddDays(-30);
            ViewData["dateTo"] = DateTime.Now;


            return View();
        }
        [HttpPost]
        public ActionResult Index(DateTime? dateFrom, DateTime? dateTo)
        {

            System.Diagnostics.Debug.WriteLine("Hello - " + dateFrom);
            if(dateFrom != null && dateTo != null)
            {
                ViewData["dateFrom"] = dateFrom;
                ViewData["dateTo"] = dateTo;
                return View(db.Interns.Include(r => r.Role).Where(r => !r.Dismissed));
            }
            return RedirectToAction("index", new { });
        }
        public ActionResult About()
        {
            ViewBag.Message = "SYSPRO Intern Salary Calculator";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ntshovelo Makwarela Contact Details.";

            return View();
        }
        public ActionResult CreateTest()
        {
            ViewBag.Message = "Your test page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if(username.Equals("admin") && password.Equals("admin"))
            {
                return RedirectToAction("Index", new { });
            }
            ViewData["Message"] = "Incorrect username or password.";
            return View();
        }
    }
}