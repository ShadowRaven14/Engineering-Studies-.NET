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
using System.Data;
using System.Reflection.Metadata;

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

            //ODWO£ANIE do BAZY oraz do PROCEDURY
            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            SqlCommand cmd = new SqlCommand("sp_productSelectID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ODWO£ANIE DO NAME
            //SqlParameter name_SqlParam = new SqlParameter("@name", SqlDbType.VarChar, 50);
            //name_SqlParam.Value = newProduct.name;
            //cmd.Parameters.Add(name_SqlParam);

            //ODWO£ANIE DO PRICE
            //SqlParameter price_SqlParam = new SqlParameter("@price", SqlDbType.VarChar, 50);
            //price_SqlParam.Value = newProduct.price;
            //cmd.Parameters.Add(price_SqlParam);

            //ODWO£ANIE DO ID
            SqlParameter productID_SqlParam = new SqlParameter("@id", SqlDbType.Int);
            //productID_SqlParam.Value = ParameterDirection.id;
            productID_SqlParam.Value = id;
            //(ParameterDirection)id;
            //ParameterDirection.Output;
            cmd.Parameters.Add(productID_SqlParam);

            con.Open();
            //cmd.Parameters.AddWithValue("@id", id);
            int numAff = cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            //MAIN - ODWO£ANIE DO BAZY

            while (reader.Read())
            {
                newProduct.name = reader["Name"].ToString();
                newProduct.price = reader["Price"].ToString();
                //String.Format("{0:0.00}", Decimal.Parse(reader["Price"].ToString()));
            }
            con.Close(); //WYJŒCIE Z BAZY
        }

        public IActionResult OnPost()
        {

            //ODWO£ANIE do BAZY oraz do PROCEDURY
            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            SqlCommand cmd = new SqlCommand("sp_productEdit", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ODWO£ANIE DO NAME
            SqlParameter name_SqlParam = new SqlParameter("@name", SqlDbType.VarChar, 50);
            name_SqlParam.Value = newProduct.name;
            cmd.Parameters.Add(name_SqlParam);

            //ODWO£ANIE DO PRICE
            SqlParameter price_SqlParam = new SqlParameter("@price", SqlDbType.VarChar, 50);
            price_SqlParam.Value = newProduct.price;
            cmd.Parameters.Add(price_SqlParam);

            //ODWO£ANIE DO ID
            SqlParameter productID_SqlParam = new SqlParameter("@id", SqlDbType.Int);
            //productID_SqlParam.Direction = ParameterDirection.Output;
            productID_SqlParam.Value = id;
            cmd.Parameters.Add(productID_SqlParam);

            con.Open();
            cmd.ExecuteNonQuery();

            con.Close(); //WYJŒCIE Z BAZY
            return RedirectToPage("List");
        }
    }
}
