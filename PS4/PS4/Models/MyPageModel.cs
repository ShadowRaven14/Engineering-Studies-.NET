using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS4.DAL;

namespace PS4.Models
{
    public class MyPageModel : PageModel
    {
        public ProductDB productDB;
        
        public string jsonProductDB { get; set; }

        public ShopCartDB shopcartDB;

        public string jsonShopCartDB { get; set; }

        public MyPageModel()
        {
            productDB = new ProductDB();
            shopcartDB = new ShopCartDB();
        }
        public void LoadDB()
        {
            jsonProductDB = HttpContext.Session.GetString("jsonProductDB");
            productDB.Load(jsonProductDB);
            jsonShopCartDB = HttpContext.Session.GetString("jsonShopCartDB");
            shopcartDB.Load(jsonShopCartDB);
        }
        public void SaveDB()
        {
            jsonProductDB = productDB.Save();
            HttpContext.Session.SetString("jsonProductDB", jsonProductDB);
            jsonShopCartDB = shopcartDB.Save();
            HttpContext.Session.SetString("jsonShopCartDB", jsonShopCartDB);
        }

    }
}
