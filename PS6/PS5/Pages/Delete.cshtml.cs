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

            //ODWO£ANIE do BAZY oraz do PROCEDURY
            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            SqlCommand cmd = new SqlCommand("sp_productDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ODWO£ANIE DO ID
            SqlParameter productID_SqlParam = new SqlParameter("@id", SqlDbType.Int);
            productID_SqlParam.Value = id;
            cmd.Parameters.Add(productID_SqlParam);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close(); //WYJŒCIE Z BAZY
            return RedirectToPage("List");
        }
    }
}
