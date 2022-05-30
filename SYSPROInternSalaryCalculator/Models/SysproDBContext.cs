using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SYSPROInternSalaryCalculator.Models
{
    public class SysproDBContext : DbContext
    {
        public virtual DbSet<Intern> Interns { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Intern_Task> Intern_Tasks { get; set; }
    }
}