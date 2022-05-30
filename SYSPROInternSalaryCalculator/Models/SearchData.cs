using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SYSPROInternSalaryCalculator.Models
{
    public class SearchData
    {
        [Required(ErrorMessage = "From date is required.")]
        public string DateFrom { set; get; }
        [Required(ErrorMessage = "From to is required.")]
        public string DateTo { set; get; }
    }
}