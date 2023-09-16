using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PS5.Models;

namespace PS5
{
    public class CreateModel : MyPageModel
    {
        [BindProperty]
        public Product newProduct { get; set; }

        public void OnGet()
        {
            newProduct = new Product();
        }

        public int id { get; set; }

        public string lblInfoText;

        private readonly ILogger<CreateModel> _logger;
        public IConfiguration _configuration { get; }
        public CreateModel(IConfiguration configuration, ILogger<CreateModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult OnPost()
        {
            //MAIN - ODWO£ANIE DO BAZY
            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = "INSERT INTO Product (Name, Price) VALUES (@name, @price)";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("name", newProduct.name);
            cmd.Parameters.AddWithValue("price", float.Parse(newProduct.price.Replace('.', ',')));
            cmd.ExecuteNonQuery();
            //MAIN - ODWO£ANIE DO BAZY

            con.Close(); //WYJŒCIE Z BAZY
            return RedirectToPage("List");
        }
    }
}
