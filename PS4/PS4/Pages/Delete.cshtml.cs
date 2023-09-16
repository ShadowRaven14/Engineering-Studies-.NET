using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS4.Models;

namespace PS4
{
    public class DeleteModel : MyPageModel
    {
        public IActionResult OnGet(int id)
        {
            LoadDB();
            productDB.Delete(id);
            SaveDB();
            return RedirectToPage("List");
        }
    }
}
