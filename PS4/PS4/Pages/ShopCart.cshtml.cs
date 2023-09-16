using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS4.DAL;
using PS4.Models;

namespace PS4.Pages
{
    public class ShopCartModel : MyPageModel
    {

        public void OnGet()
        {
            LoadDB();
            shopcartDB.Clear();
            for (int i = 1; ; i++)
            {
                string add = Request.Cookies[i.ToString()];
                if (add == null) break;
                else shopcartDB.AddToCart(productDB.lookforID(int.Parse(add)));
            }
            SaveDB();
        }
        public IActionResult OnPostDelete()
        {
            shopcartDB.Clear();
            for (int i = 1; ; i++)
            {
                string add = Request.Cookies[i.ToString()];
                if (add == null) break;
                else Response.Cookies.Delete(add);
            }
            return Page();
        }
    }
}
