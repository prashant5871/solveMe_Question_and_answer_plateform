using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace solveMe
{
    public partial class MyQuestionsPage : System.Web.UI.Page
    {
        // Connection string from web.config
        private string connectionString = ConfigurationManager.ConnectionStrings["solveMeDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserQuestions();
            }
        }

        // Method to load questions posted by the logged-in user
        private void LoadUserQuestions()
        {
            // Assuming you have a User class and session variable storing current user info
            var user = (User)Session["CurrUser"];
            if (user == null)
            {
                // Redirect to login if no user is logged in
                Response.Redirect("Login.aspx");
                return;
            }

            // SQL query to fetch questions by the logged-in user along with the category name
            string query = @"
                SELECT 
                    P.Id,
                    P.statement,
                    C.Name AS CategoryName
                FROM 
                    Problem P
                INNER JOIN 
                    Category C ON P.categoryId = C.Id
                WHERE 
                    P.userId = @UserId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameter for userId
                    cmd.Parameters.AddWithValue("@UserId", user.id);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            // Bind data to the repeater
                            rptMyQuestions.DataSource = dt;
                            rptMyQuestions.DataBind();

                            // Hide no questions panel
                            pnlNoQuestions.Visible = false;
                        }
                        else
                        {
                            // Show no questions panel
                            pnlNoQuestions.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
