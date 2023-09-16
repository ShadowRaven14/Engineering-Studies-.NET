using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS4.Models;
using PS4.DAL;

namespace PS4.Pages
{
    public class EditModel : MyPageModel
    {
        [BindProperty]
        public Product editProduct { get; set; }
        public void OnGet(int id)
        {
            LoadDB();
            editProduct = productDB.lookforID(id);
        }
        public IActionResult OnPost()
        {

            LoadDB();
            productDB.Edit(editProduct.id, editProduct);
            SaveDB();
            return RedirectToPage("List");
        }
    }
}
