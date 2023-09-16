using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS5.Models;
using PS5.DAL;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace PS5.Pages
{
    public class EditModel : MyPageModel
    {
        [BindProperty]
        public Product newProduct { get; set; }
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        public string lblInfoText;

        private readonly ILogger<EditModel> _logger;
        public IConfiguration _configuration { get; }
        public EditModel(IConfiguration configuration, ILogger<EditModel> logger)
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
            string sql = "SELECT * FROM Product WHERE ID = @id";
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
            //MAIN - ODWO£ANIE DO BAZY
            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = "UPDATE PRODUCT SET Name = @name, Price = @price WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("name", newProduct.name);
            cmd.Parameters.AddWithValue("price", float.Parse(newProduct.price.Replace('.', ',')));
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            //MAIN - ODWO£ANIE DO BAZY

            con.Close(); //WYJŒCIE Z BAZY
            return RedirectToPage("List");
        }
    }
}
