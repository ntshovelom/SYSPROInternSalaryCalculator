using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SYSPROInternSalaryCalculator.Models
{
    public class Intern_Task
    {
        public int Id { set; get; }

        [Required]
        [Display(Name = "Intern")]
        public Intern Intern { set; get; }
        [Required]
        [Display(Name = "Task")]
        public Task Task { set; get; }
        [Required]
        [Display(Name = "Hours")]
        public int HoursWorked { set; get; }
        [Required]
        [Display(Name = "Salary (R)")]
        public double Salary { set; get; }
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { set; get; }

        
    }
}