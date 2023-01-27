using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcEmployee.Models;

namespace MvcEmployee.Data
{
    public class MvcEmployeeContext : DbContext
    {
        public MvcEmployeeContext (DbContextOptions<MvcEmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<MvcEmployee.Models.Employee> Employee { get; set; } = default!;

        public DbSet<MvcEmployee.Models.QualificationList> QualificationList { get; set; } = default!;

        public DbSet<MvcEmployee.Models.Qualification> Qualification { get; set; } = default!;
    }
}
