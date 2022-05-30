using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SYSPROInternSalaryCalculator.Models
{
   
    public class Intern
    {

        public int Id { set; get; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "First Name")]
        public string Firstname { set; get; }
        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { set; get; }
        public bool Dismissed { set; get; }
        [Required(ErrorMessage = "Please ID number")]
        [Display(Name = "Date of Birth")]
        public DateTime DateofBirth { set; get; }
        [Required]
        [Display(Name = "ID Number")]
        [StringLength(maximumLength:13,MinimumLength =13,ErrorMessage ="ID Number must be 13 characters")]
        public string IDNumber { set; get; }

        public byte[] Photo { get; set; }

        [Required]
        [Display(Name = "Role")]
        public Role Role { set; get; }

        public double? TotalSalary()
        {
            double? salary = 0;
            SysproDBContext db = new SysproDBContext();

            /*List<Intern_Task> tasks = db.Intern_Tasks.Where(i => i.Intern.Id == Id).ToList();

            foreach(Intern_Task t in tasks)
            {
                salary += t.Salary;
            }*/
            return db.Intern_Tasks.Where(i => i.Intern.Id == Id).Sum(r => (double?)r.Salary);
            
            
        }

        public double? TotalSalary(DateTime dateFrom, DateTime dateTo)
        {
            double? salary = 0;
            SysproDBContext db = new SysproDBContext();
            return db.Intern_Tasks.Where(i => i.Intern.Id == Id && i.Date >= dateFrom && i.Date <= dateTo).Sum(r => (double?)r.Salary);


        }
        public double? TotalHoursWorked(DateTime dateFrom, DateTime dateTo)
        {
            double? hours = 0;
            SysproDBContext db = new SysproDBContext();

            
            return db.Intern_Tasks.Where(i => i.Intern.Id == Id && i.Date >= dateFrom && i.Date <= dateTo).Sum(r => (double?)r.HoursWorked);


        }

       

    }
}