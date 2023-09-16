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
using System.Data;

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

            //ODWO£ANIE do BAZY oraz do PROCEDURY
            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            SqlCommand cmd = new SqlCommand("sp_productSelectID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ODWO£ANIE DO ID
            SqlParameter productID_SqlParam = new SqlParameter("@id", SqlDbType.Int);
            productID_SqlParam.Value = id;
            cmd.Parameters.Add(productID_SqlParam);

            con.Open();
            int numAff = cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                newProduct.name = reader["Name"].ToString();
                newProduct.price = reader["Price"].ToString();
            }
            con.Close(); //WYJŒCIE Z BAZY
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("List");
        }
    }
}
