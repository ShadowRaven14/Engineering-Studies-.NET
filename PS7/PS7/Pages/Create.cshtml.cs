using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS7.DAL;
using PS7.Models;

namespace PS7.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product newProduct { get; set; }
        IProductDB productDB;

        public CreateModel(IProductDB _productDB)
        {
            productDB = _productDB;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            productDB.Add(newProduct);
            return RedirectToPage("Index");
        }
    }
}
