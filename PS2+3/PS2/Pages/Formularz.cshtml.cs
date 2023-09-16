using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Html;
using PS2.Models;

namespace PS2.Pages
{
    public class FormularzModel : PageModel
    {
        [BindProperty]
        public Person person { get; set; }

        public void OnGet()
        {
            //int w = 5;
        }

        public IActionResult OnPost()
        {
            string wiek;

            //if (!ModelState.IsValid) return Page();
            if (person.Email == null) person.Email = "Nie zosta³ podany.";
            if (person.Wiek < 0) wiek = "Nie zosta³ podany.";
            //else wiek = person.Wiek.ToString();
            

            float bmi = (float)(person.Waga /
                            ((person.Wzrost / person.JednostkaM) *
                            (person.Wzrost / person.JednostkaM)));

            return RedirectToPage("WynikBMI", new
            {
                Imie = person.Imie,
                Email = person.Email,
                Wiek = person.Wiek,
                Waga = person.Waga,
                Wzrost = person.Wzrost,
                Plec = person.Plec,
                Wynik = bmi
            });
        }
    }
}