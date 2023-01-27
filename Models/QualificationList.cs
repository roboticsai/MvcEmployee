using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEmployee.Models;

public class QualificationList
{
    public int QualificationListId { get; set; }
    
    public string? Name { get; set; }
}
