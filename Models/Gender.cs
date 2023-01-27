using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcEmployee.Models
{
    public class Gender
    {
        [BindProperty]
        public int GenderId { get; set; }

        [BindProperty]
        public string GenderName { get; set; }
    }
}