using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SYSPROInternSalaryCalculator.Models;

namespace SYSPROInternSalaryCalculator.Controllers
{
    public class RolesController : Controller
    {
        SysproDBContext db = new SysproDBContext();
        // GET: Role
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include ="Name,RatePerHour")] Role role)
        {
            System.Diagnostics.Debug.WriteLine("Role: " +role.Name );
           /* Role role1 = new Role()
            {
                Name = name,
                RatePerHour = ratePerHour
            };*/
            db.Roles.Add(role);
           db.SaveChanges();

            return RedirectToAction("Index", new { });
        }

        public ActionResult Edit(int Id)
        {
            Role role = db.Roles.Find(Id);
            return View(role);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,RatePerHour")] Role role)
        {


            db.Entry(role).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", new { });
        }

    }
}