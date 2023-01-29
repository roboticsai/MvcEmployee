using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEmployee.Models;

public class EmployeeViewModel
{
        public Employee Employee { get; set; }
        public Qualification Qualification { get; set; }
        public Gender Gender { get; set; }
        public QualificationList QualificationList { get; set; }
}