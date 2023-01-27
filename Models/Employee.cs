using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEmployee.Models;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Name { get; set; }

    [Display(Name = "Date Of Birth")]
    [DataType(DataType.Date)]
    public DateTime DOB { get; set; } 

    [Range(1, 3)]
    public int Gender { get; set; }

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Salary { get; set; }

    public IEnumerable<Qualification>? Qualification { get; set; }
}