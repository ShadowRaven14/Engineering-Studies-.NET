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
    public class DeleteModel : MyPageModel
    {
        public Product newProduct { get; set; }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public string lblInfoText;

        private readonly ILogger<DeleteModel> _logger;
        public IConfiguration _configuration { get; }
        public DeleteModel(IConfiguration configuration, ILogger<DeleteModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IActionResult OnGet()
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

            con.Close(); //WYJŒCIE Z BAZY
            return RedirectToPage("List");
        }
    }
}
