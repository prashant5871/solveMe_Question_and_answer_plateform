using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solveMe
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["CurrUser"] != null)
            {
                Response.Redirect("Index.aspx");
                return;
            }
        }

        protected void btnLogin_Click(Object sender, EventArgs e)
        {
            string userName = username.Text;
            string Password = password.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["solveMeDbCon"].ConnectionString;
            try
            {
                string query = "select * from Users where username=@username and password = @password";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@password", Password);
                cmd.Parameters.AddWithValue("@username", userName);

                using (con)
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.HasRows)
                    {
                        reader.Read();
                        Session["CurrUser"] = new User()
                        {
                            id = (int)reader["Id"],
                            username = (string)reader["username"],
                            password = (string)reader["password"],
                            email = (string)reader["email"],
                            firstName = (string)reader["firstName"],
                            lastName = (string)reader["lastName"],
                            isAdmin = (bool)reader["isAdmin"],
                            isExpert = (bool)reader["isExpert"]
                        };
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        throw new Exception("Invalid credentials , please try again");
                    }
                }

            }
            catch (Exception ex)
            {
                
                Response.Write(ex.Message);
            }
        }
    }
}