using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solveMe
{
    public partial class QuestionPage : System.Web.UI.Page
    {
        // Connection string from the web.config file
        private string connectionString = ConfigurationManager.ConnectionStrings["solveMeDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuestions();
            }
        }

        // Method to load questions from the database
        private void LoadQuestions()
        {
            // SQL query to fetch questions along with the user who posted them
            string query = @"
                SELECT 
                    P.Id,
                    P.statement,
                    U.username
                FROM 
                    Problem P
                INNER JOIN 
                    Users U ON P.userId = U.Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        rptQuestions.DataSource = dt;
                        rptQuestions.DataBind();
                    }
                }
            }
        }
    }



}