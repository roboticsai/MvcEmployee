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
            // Look for any Gender.
            if (context.Employee.Any())
            {
                return;
            }
            context.Employee.AddRange(
                new Employee
                {
                    Name = "Male"
                },
                new Employee
                {
                    Name = "Female"
                },
                new Employee
                {
                    Name = "Third Party"
                }
            );
            // Look for any Employee.
            if (context.QualificationList.Any())
            {
                return;
            }     
            context.QualificationList.AddRange(
                new QualificationList
                {
                    Name = "SLC"
                },
                new QualificationList
                {
                    Name = "BE"
                },
                new QualificationList
                {
                    Name = "ME"
                },
                new QualificationList
                {
                    Name = "PHD"
                }
            );   
            context.SaveChanges();     
        }
    }
}