using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SYSPROInternSalaryCalculator.Models;

namespace SYSPROInternSalaryCalculator.Controllers
{
    public class InternsController : Controller
    {
        public  SysproDBContext db = new SysproDBContext();
        public ActionResult Index()
        {

            // Intern intern = db.Interns.Include(r => r.Role).Where(i => i.Firstname == "Khano").FirstOrDefault();
            // System.Diagnostics.Debug.WriteLine("<|> - " + intern.Lastname + " | " + intern.Role);
            ViewData["Message"] = (db.Roles.Count() < 1 ? "Please add roles before adding Interns" : null);
            return View(db.Interns.Include(r => r.Role).Where(r => !r.Dismissed));
        }

       
        public ActionResult Create()
        {
            var roles = db.Roles.ToList();
            //user can not add intern if no role has been added, so we redirect back to index
            if (roles.Count <= 0)
            {
                return RedirectToAction("Index", new { });
            }
            ViewData["roles"] = roles;
            return View();
        }

        [HttpPost]
        public ActionResult Create(string firstname, string lastname, DateTime dateofBirth, string idNumber, string role_id)
        {
            
            if (dateofBirth != null)
            {
                int roleID = int.Parse(role_id);

                System.Diagnostics.Debug.WriteLine("-- " + dateofBirth);

                Intern intern = new Intern()
                {

                    Firstname = firstname,
                    Lastname = lastname,
                    IDNumber = idNumber,
                    DateofBirth = dateofBirth,
                    Dismissed = false,
                    Role = db.Roles.Find(roleID)
                };
                System.Diagnostics.Debug.WriteLine("<> - " + firstname + " --- " + dateofBirth);


                db.Interns.Add(intern);
                db.SaveChanges();
                
            }
            return RedirectToAction("Index", new { });
        }
        public ActionResult Dismiss(int Id) 
        {
            Intern i = db.Interns.Include(r => r.Role).Where(r => r.Id == Id).FirstOrDefault();
            i.Dismissed = true;
            db.Entry(i).State = EntityState.Modified;
            db.SaveChanges();


            return RedirectToAction("Index", new { });
        }
        public ActionResult Edit(int Id)
        {

            var roles = db.Roles.ToList();
            Intern i = db.Interns.Include(r => r.Role).Where(r => r.Id == Id).FirstOrDefault();
            ViewData["roles"] = roles;
            return View(i);
        }

        [HttpPost]
        public ActionResult Edit(int Id, string firstname, string lastname, DateTime dateofBirth, string idNumber, string role_id)
        {

            int roleID = int.Parse(role_id);
            Intern i = db.Interns.Include(r => r.Role).Where(r => r.Id == Id).FirstOrDefault();
            i.Firstname = firstname;
            i.Lastname = lastname;
            i.DateofBirth = dateofBirth;
            i.IDNumber = idNumber;
            i.Role = db.Roles.Find(roleID);

            db.Entry(i).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", new { });
        }
    }
}