using System.ComponentModel.DataAnnotations;

namespace MvcEmployee.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public string? Name { get; set; }
    public List<Qualification>? Qualifications { get; set; }
}