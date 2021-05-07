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
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [StringLength(50)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        public DateTime DateoFBirth { get; set; }

        [Display(Name = "Płeć")]
        public int GenderId {get;set;}
        public Gender Gender { get; set; }

        [Display(Name = "Miejsce zaginięcia")]
        public string Place { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data utworzenia")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Zdjęcie")]
        public byte[] Image { get; set; }
    }
}