using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcEmployee.Models;

namespace MvcEmployee.ViewModels;

public class EmployeeViewModel
{
    public Gender? Gender { get; set; }

    public Employee? Employee {get ; set; }
}