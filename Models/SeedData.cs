// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// // using MvcEmployee.Data;
// using System;
// using System.Linq;

// namespace MvcEmployee.Models;

// public static class SeedData
// {
//     public static void Initialize(IServiceProvider serviceProvider)
//     {
//         using (var context = new MvcEmployeeContext(
//             serviceProvider.GetRequiredService<
//                 DbContextOptions<MvcEmployeeContext>>()))
//         {
//             // Look for any Employee.
//             if (!context.Employee.Any())
//             {
//                 context.Employee.AddRange(
//                 new Employee
//                 {
//                     Name = "Hari"
//                 },
//                 new Employee
//                 {
//                     Name = "Hari"
//                 },
//                 new Employee
//                 {
//                     Name = "Hari"
//                 }
//                 );
//             }
//             if (!context.QualificationList.Any())
//             {
//                 context.QualificationList.AddRange(
//                 new QualificationList
//                 {
//                     Name = "SLC"
//                 },
//                 new QualificationList
//                 {
//                     Name = "BE"
//                 },
//                 new QualificationList
//                 {
//                     Name = "ME"
//                 }
//                 );
//             }

//         context.SaveChanges();
//         }
//     }
// }