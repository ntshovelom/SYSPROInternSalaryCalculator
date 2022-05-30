using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SYSPROInternSalaryCalculator.Models
{
    public class Role
    {
       
        public int Id { set; get; }
        [Required]
        [Display(Name = "Role")]
        [Microsoft.AspNetCore.Mvc.BindProperty]
        public string Name { set; get; }
        [Required]
        [Display(Name = "Rate (R)")]
        public double RatePerHour { set; get; }
    }
}