using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS1.Pages
{
    public class IndexModel : PageModel
    {
       
        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
            var Nazwisko = Request.Form["nazwisko"];
            var Imie = Request.Form["imie"];
            var Wiek = Request.Form["wiek"];
            var Plec = Request.Form["plec"];
            var Telefon = Request.Form["telefon"];
            var Jezyk1 = Request.Form["jezykProgramowaniaC"];
            var Jezyk2 = Request.Form["jezykProgramowaniaC#"];
            var Jezyk3 = Request.Form["jezykProgrramowaniaJava"];


            if (Jezyk1.Equals("C")) Jezyk1 = "C,"; 
            else Jezyk1 = " ";
            if (Jezyk2.Equals("C#")) Jezyk2 = "C#,"; 
            else Jezyk2 = " ";
            if (Jezyk3.Equals("Java")) Jezyk3 = "Java,"; 
            else Jezyk3 = " ";


            if (Int32.Parse(Wiek) > 18)
            {
                return RedirectToPage("Doswiadczony", new {Nazwisko = Nazwisko, Imie = Imie, Wiek = Wiek, 
                Plec = Plec, Telefon = Telefon, Jezyk1 = Jezyk1, Jezyk2 = Jezyk2, Jezyk3 = Jezyk3 });
            }
            else
            {
                return RedirectToPage("Mlody", "");
            }
        }
    }
}
