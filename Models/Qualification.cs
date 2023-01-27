using System.ComponentModel.DataAnnotations;

namespace MvcEmployee.Models;

public class Qualification
{
    public string? Name { get; set; }
    public decimal Marks { get; set; }
    public int EmployeeId {get; set; }
    public Employee? Employee { get; set; } 

    public int QualificationId { get; set; }
    public QualificationList? QualificationList { get; set; }
}
