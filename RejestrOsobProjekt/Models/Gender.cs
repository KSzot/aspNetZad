using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrOsobProjekt.Models
{
    public class Gender
    {
        public int Id { get; set; }
        [Display(Name = "Płeć")]
        public string Name { get; set; }
    }
}