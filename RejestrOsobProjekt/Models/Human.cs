using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrOsobProjekt.Models
{
    public class Human
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is requierd")]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime DateoFBirth { get; set; }

        public string Place { get; set; }

        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
       
    }
}