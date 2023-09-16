using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PS5.Models
{
    public class Product
    {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Musisz podać Nazwę!")]
        public string name { get; set; }

        [Display(Name = "Cena")]
        [Range(0, double.MaxValue, ErrorMessage = "Cena nie może być ujemna!")]
        [Required(ErrorMessage = "Musisz podać Cenę!")]
        public string price { get; set; }

        /*
        public static List<Product> GetProducts()
        {
            Product nr1 = new Product
            { id = 1, name = "Zestaw zabawek dla dziecka", price = 155.49M };

        }
        */
    }
}