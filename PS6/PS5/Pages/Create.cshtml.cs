using System;
using System.Collections.Generic;
using System.Data;
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

        public int id { get; set; }

        public string lblInfoText;

        private readonly ILogger<CreateModel> _logger;
        public IConfiguration _configuration { get; }
        public CreateModel(IConfiguration configuration, ILogger<CreateModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            /*
            newProduct = new Product();

            //ODWO£ANIE do BAZY oraz do PROCEDURY
            string myCompanyDB_connection_string = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDB_connection_string);
            SqlCommand cmd = new SqlCommand("sp_productCreate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ODWO£ANIE DO PRICE
            SqlParameter name_SqlParam = new SqlParameter("@name", SqlDbType.VarChar, 50);
            name_SqlParam.Value = "baton";
            cmd.Parameters.Add(name_SqlParam);

            //ODWO£ANIE DO NAME
            SqlParameter price_SqlParam = new SqlParameter("@price", SqlDbType.VarChar, 50);
            price_SqlParam.Value = 4.50;
            cmd.Parameters.Add(price_SqlParam);

            //ODWO£ANIE DO ID
            SqlParameter productID_SqlParam = new SqlParameter("@id", SqlDbType.Int);
            productID_SqlParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(productID_SqlParam);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //lblInfoText += String.Format("Inserted <b>{0}</b> record(s)<br />", numAff);
            //int productID = (int)cmd.Parameters["@id"].Value;
            //lblInfoText += "New ID: " + productID.ToString();
            */
        }

        public IActionResult OnPost()
        {
            //MAIN - ODWO£ANIE DO BAZY
            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            SqlCommand cmd = new SqlCommand("sp_productCreate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter name_SqlParam = new SqlParameter("@name", SqlDbType.VarChar, 50);
            name_SqlParam.Value = newProduct.name;
            cmd.Parameters.Add(name_SqlParam);

            SqlParameter price_SqlParam = new SqlParameter("@price", SqlDbType.VarChar, 50);
            price_SqlParam.Value = newProduct.price;
            cmd.Parameters.Add(price_SqlParam);

            SqlParameter productID_SqlParam = new SqlParameter("@id", SqlDbType.Int);
            productID_SqlParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(productID_SqlParam);

            con.Open();
            cmd.ExecuteNonQuery(); //B£¥D

            con.Close(); //WYJŒCIE Z BAZY
            return RedirectToPage("List");
        }
    }
}
