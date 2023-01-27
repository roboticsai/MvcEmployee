using System.ComponentModel.DataAnnotations;

namespace MvcEmployee.Models;

public class QualificationList
{
    [Key]
    public int QualificationListId { get; set; }
    public string? Name { get; set; }
}
