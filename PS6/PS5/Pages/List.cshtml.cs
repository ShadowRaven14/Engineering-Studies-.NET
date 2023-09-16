using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PS5.Pages
{
    public class ListModel : PageModel
    {
        private readonly ILogger<ListModel> _logger;
        public IConfiguration _configuration { get; }
        public ListModel(IConfiguration configuration, ILogger<ListModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public string lblInfoText;
        public void OnGet()
        {
            //MAIN - ODWO£ANIE DO BAZY
            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = "SELECT * FROM Product";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            StringBuilder htmlStr = new StringBuilder("");
            //MAIN - ODWO£ANIE DO BAZY

            //SKLEJANIE TABELKI
            while (reader.Read())
            {
                htmlStr.Append("<tr>");
                htmlStr.Append("<tr>");
                htmlStr.Append("<tr>");

                //ROZDZIELENIE NA RZÊDY
                htmlStr.Append(" <th scope=\"row\">");

                //ID
                htmlStr.Append(reader["Id"].ToString() + " ");
                htmlStr.Append("</th>"); htmlStr.Append("<td>");

                //NAZWA
                htmlStr.Append(reader["Name"].ToString() + " ");
                htmlStr.Append("</td>"); htmlStr.Append("<td>");

                //CENA
                //htmlStr.Append(String.Format("{0:0.00}", Decimal.Parse(reader["Price"].ToString())) + " ");
                htmlStr.Append(reader["Price"].ToString() + " ");
                htmlStr.Append("</td>"); htmlStr.Append("<td>");

                //LINK - SZCZEGÓ£Y
                htmlStr.Append("<a href=\"Details?id=");
                htmlStr.Append(int.Parse(reader["Id"].ToString()));
                htmlStr.Append("\">Szczegó³y</a> | ");

                //LINK - SZCZEGÓ£Y
                htmlStr.Append("<a href=\"Edit?id=");
                htmlStr.Append(int.Parse(reader["Id"].ToString()));
                htmlStr.Append("\">Edytuj</a> | ");

                //LINK - SZCZEGÓ£Y
                htmlStr.Append("<a href=\"Delete?id=");
                htmlStr.Append(int.Parse(reader["Id"].ToString()));
                htmlStr.Append("\">Kasuj</a> | ");


                htmlStr.Append("</td>");
                htmlStr.Append("<tr/>");
            }
            //SKLEJANIE TABELKI

            reader.Close(); con.Close(); //WYJŒCIE Z BAZY
            lblInfoText = htmlStr.ToString();
        }

    }
}
