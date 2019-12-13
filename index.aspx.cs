using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_dotNet
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CONNECT TO DB

            string connStr = "Server=localhost;Database=test;UID=sa;PWD=dbpwd1";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            //CREATE A COMMAND
            SqlCommand cmd = new SqlCommand("SELECT [id],[name] FROM [dbo].[test_tab]");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            string temp = "";
            //READ FROM DB
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                temp += reader["id"].ToString();
                temp += reader["name"].ToString();
                temp += "<br/>";

            }
            conn.Close();
            lbl_test.Text = temp;

        }
    }
}