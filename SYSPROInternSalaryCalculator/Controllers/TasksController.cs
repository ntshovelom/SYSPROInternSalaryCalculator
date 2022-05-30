using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SYSPROInternSalaryCalculator.Models;

namespace SYSPROInternSalaryCalculator.Controllers
{
    public class TasksController : Controller
    {
        SysproDBContext db = new SysproDBContext();

        // GET: Tasks
        public ActionResult Index()
        {


            return View(db.Tasks.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, int duration)
        {
            Task task = new Task()
            {
                Name = name,
                Duration = duration
            };


            db.Tasks.Add(task);
            db.SaveChanges();


            return RedirectToAction("Index", new { });
        }

        public ActionResult Edit(int Id)
        {
            return View(db.Tasks.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,name,duration")] Task task)
        {
            db.Entry(task).State = EntityState.Modified;

            db.SaveChanges();


            return RedirectToAction("Index", new { });
        }
    }
}