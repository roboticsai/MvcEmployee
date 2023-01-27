using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcEmployee.Data;
using System;
using System.Linq;

namespace MvcEmployee.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcEmployeeContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcEmployeeContext>>()))
        {
            // Look for any Employee.
            if (context.Employee.Any())
            {
                return;   // DB has been seeded
            }
            context.Employee.AddRange(
                new Employee
                {
                    Name = "When Harry Met Sally",
                },
                new Employee
                {
                    Name = "When Harry Met Sally",
                },
                new Employee
                {
                    Name = "When Harry Met Sally",
                },
                new Employee
                {
                    Name = "When Harry Met Sally",
                }
            );
            context.SaveChanges();
        }
    }
}