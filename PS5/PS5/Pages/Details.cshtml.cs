using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS5.Models;
using PS5.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace PS5.Pages
{
    public class DetailsModel : MyPageModel
    {
        public Product newProduct { get; set; }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public string lblInfoText;

        private readonly ILogger<DetailsModel> _logger;
        public IConfiguration _configuration { get; }
        public DetailsModel(IConfiguration configuration, ILogger<DetailsModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public void OnGet()
        {
            newProduct = new Product();

            //MAIN - ODWO£ANIE DO BAZY
            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = "DELETE FROM Product WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            //MAIN - ODWO£ANIE DO BAZY

            while (reader.Read())
            {
                newProduct.name = reader["Name"].ToString();
                newProduct.price = String.Format("{0:0.00}", Decimal.Parse(reader["Price"].ToString()));
            }

            con.Close(); //WYJŒCIE Z BAZY
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("List");
        }
    }
}
