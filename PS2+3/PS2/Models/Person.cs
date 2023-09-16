using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Html;

namespace PS2.Models
{
    public class Person
    {
        [Display(Name= "Imie")]
        [Required(ErrorMessage = "Użytkowniku. Pole 'Imie' jest wymagane.")]
        [StringLength (15, ErrorMessage = "Użytkowniku. Zła ilość znaków.")]
        public string Imie { get; set; }

        public string Email { get; set; }

        [Display(Name = "Wiek")]
        [Range(1, 120, ErrorMessage = "Użytkowniku. Niepoprawna liczba.")]
        public int Wiek { get; set; }

        [Display(Name= "Wzrost")]
        [Required(ErrorMessage = "Użytkowniku. Pole 'Wzrost' jest wymagane.")]
        public int? Wzrost { get; set; }

        [Display(Name= "Waga")]
        [Required(ErrorMessage = "Użytkowniku. Pole 'Waga' jest wymagane.")]
        public int? Waga { get; set; }

        [Display(Name= "Płeć")]
        [Required(ErrorMessage = "Użytkowniku. Pole 'Płeć' jest wymagane.")]
        public string Plec { get; set; }

        public float JednostkaM { get; set; }
    }
}
