using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEmployee.Models;

public class Qualification
{
    public int QualificationId { get; set; }

    [Range(1, 100)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Marks { get; set; }

    public int EmployeeId {get; set; }
    public Employee? Employee { get; set; } 

    public int QualificationListId { get; set; }
    public QualificationList? QualificationList { get; set; }
}
