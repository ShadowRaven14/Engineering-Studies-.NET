using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PS7.DAL;
using PS7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace PS7.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> productList;
        IProductDB productDB;

        public IndexModel(IProductDB _productDB)
        {
            productDB = _productDB;
        }

        public void OnGet()
        {
            productList = productDB.List();
        }

    }
}
