using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SYSPROInternSalaryCalculator.Models;
using System.Data.Entity;

namespace SYSPROInternSalaryCalculator.Controllers
{
    public class Intern_TasksController : Controller
    {
        SysproDBContext db = new SysproDBContext();

        public ActionResult Index()
        {
            
            //user can not capture time is no task or intern has been added
            if(db.Tasks.Count() < 1 || db.Interns.Count() < 1)
            {
                ViewData["Message"] = "Please add interns and tasks before capturing time";
            }
            return View(db.Intern_Tasks.Include(r => r.Intern).Include(r => r.Task).OrderByDescending(r => r.Date).ToList());
        }

        public ActionResult Capture()
        {
            ViewData["tasks"] = db.Tasks.ToList();
            ViewData["interns"] = db.Interns.Where(r => !r.Dismissed).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Capture(int intern_id, int task_id, int hoursWorked, DateTime date)
        {
            Intern intern = db.Interns.Include(r => r.Role).Where(i => i.Id == intern_id).FirstOrDefault();
            Intern_Task it = new Intern_Task()
            {
                Intern = intern,
                Task = db.Tasks.Find(task_id),
                HoursWorked = hoursWorked,
                Date = date,

                // Calculating salary is necessary at this stage as it
                // allows the price to not be affected by change in hourly rate
                Salary = (hoursWorked <= 11 ? hoursWorked * intern.Role.RatePerHour : intern.Role.RatePerHour * 11)

            };
            db.Intern_Tasks.Add(it);
            db.SaveChanges();
            return RedirectToAction("Index", new { });
        }
        public ActionResult Edit(int Id)
        {
            ViewData["tasks"] = db.Tasks.ToList();
            ViewData["interns"] = db.Interns.Where(r => !r.Dismissed).ToList();
            Intern_Task it = db.Intern_Tasks.Include(r => r.Intern).Include(r => r.Task).Where(r => r.Id == Id).FirstOrDefault();
            return View(it);
            
        }
        [HttpPost]
        public ActionResult Edit(int Id, int intern_id, int task_id, int hoursWorked, DateTime date)
        {

            Intern_Task it = db.Intern_Tasks.Find(Id);

            it.Intern = db.Interns.Include(r => r.Role).Where(r => r.Id == intern_id).FirstOrDefault();
            it.Task = db.Tasks.Find(task_id);
            it.HoursWorked = hoursWorked;
            it.Date = date;
            it.Salary = (hoursWorked <= 11 ? hoursWorked * it.Intern.Role.RatePerHour : it.Intern.Role.RatePerHour * 11);
            db.Entry(it).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", new { });

        }
    }
}