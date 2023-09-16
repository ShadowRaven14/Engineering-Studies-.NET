using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS7.DAL;

namespace PS7.Pages
{
    public class DeleteModel : PageModel
    {
        IProductDB productDB;
        public DeleteModel(IProductDB _productDB)
        {
            productDB = _productDB;
        }
        public IActionResult OnGet(int _id)
        {
            productDB.Delete(_id);
            return RedirectToPage("Index");
        }
    }
}
