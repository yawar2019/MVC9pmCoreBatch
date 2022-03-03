using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApitest5.Models
{
    public class EmployeeContext : IdentityDbContext<ApplicationUser>
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }
        public DbSet<employeedet2> employeedet2 { get; set; }
         
    }
}
