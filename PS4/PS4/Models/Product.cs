using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PS4.Models
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
        public decimal price { get; set; }
        
        
        public static List<Product> GetProducts()
        {
            Product nr1 = new Product
            { id = 1, name = "Zestaw zabawek dla dziecka", price = 155.49M };

            Product nr2 = new Product 
            { id = 2, name = "Zestaw sportowca", price = 229.79M };

            Product nr3 = new Product 
            { id = 3, name = "Zestaw relaksacyjny", price = 499.99M };

            Product nr4 = new Product
            { id = 4, name = "Zestaw wybitnego kucharza", price = 749.99M };

            Product nr5 = new Product
            { id = 5, name = "Zestaw e-sportowca", price = 2789.99M };


            return new List<Product> { nr1, nr2, nr3, nr4, nr5};
        }
    }
}