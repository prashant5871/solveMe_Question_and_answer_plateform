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
    public partial class SignUp : System.Web.UI.Page
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string UserName = username.Text;
            string Email = email.Text;
            string Password = password.Text;
            string FirstName = firstName.Text;
            string LastName = lastName.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["solveMeDbCon"].ConnectionString;
            try
            {
                using (con)
                {
                    string query = "insert into Users (username, email, password, firstName, lastName, isAdmin, isExpert) " +
                          "values(@username, @email, @password, @firstName, @lastName, 0, 0); " +
                          "SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", UserName);
                    cmd.Parameters.AddWithValue("@password", Password);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@firstName", FirstName);
                    cmd.Parameters.AddWithValue("@lastName", LastName);
                    con.Open();

                    object newUserIdObj = cmd.ExecuteScalar();
                    int newUserId = Convert.ToInt32(newUserIdObj);

                    Session["CurrUser"] = new User()
                    {
                        id = newUserId,
                        username = UserName,
                        password = Password,
                        email = Email,
                        firstName = FirstName,
                        lastName = LastName,
                        isAdmin = false,
                        isExpert = false
                    };
                    Response.Redirect("Index.aspx");

                }
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}