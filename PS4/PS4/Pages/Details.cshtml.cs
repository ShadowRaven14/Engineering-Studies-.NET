using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS4.Models;
using PS4.DAL;
using Microsoft.AspNetCore.Http;

namespace PS4.Pages
{
    public class DetailsModel : MyPageModel
    {
        [BindProperty]
        public Product product { get; set; }

        public void OnGet(int id)
        {
            LoadDB();
            shopcartDB.Clear();
            for (int i = 1; ; i++)
            {
                string add = Request.Cookies[i.ToString()];
                if (add == null) break;
                else shopcartDB.AddToCart(productDB.lookforID(int.Parse(add)));
            }
            product = productDB.lookforID(id);
            SaveDB();
        }
        public IActionResult OnPostAdd(int id)
        {
            LoadDB();
            Product p = productDB.lookforID(id);

            var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(30) };

            shopcartDB.AddToCart(p);

            Response.Cookies.Append(shopcartDB.GetProductsList.Count.ToString(), p.id.ToString(), cookieOptions);

            SaveDB();
            return RedirectToPage("List");
        }
    }
}
