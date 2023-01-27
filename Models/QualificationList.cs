using System.ComponentModel.DataAnnotations;

namespace MvcEmployee.Models;

public class QualificationList
{
    [Key]
    public int QualificationId { get; set; }
    public string? Name { get; set; }
}
