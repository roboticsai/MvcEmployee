using System.ComponentModel.DataAnnotations;

namespace MvcEmployee.Models;

public class Qualification
{
    public int QualificationId { get; set; }
    public string? Name { get; set; }
    public decimal Marks { get; set; }
    public int EmployeeId {get; set; }
    public Employee? Employee {get; set; } 
}
