using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcEmployee.Models;

namespace MvcEmployee.ViewModels;

public class QualificationViewModel
{
    public Qualification? Qualification { get; set; }

    public QualificationList? QualificationList {get ; set; }
}