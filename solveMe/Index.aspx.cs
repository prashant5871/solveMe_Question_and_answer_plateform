using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solveMe
{
    public partial class Index : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["solveMeDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadQuestions();
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            LoadFilteredQuestions();
        }

        [WebMethod]
        public static List<Question> SearchQuestions(string searchTerm)
        {
            List<Question> questions = new List<Question>();
            string query = @"
                SELECT 
                    P.Id,
                    P.statement,
                    U.username
                FROM 
                    Problem P
                INNER JOIN 
                    Users U ON P.userId = U.Id
                WHERE 
                    P.statement LIKE @searchTerm
                ORDER BY 
                    P.Id DESC";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["solveMeDbCon"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        questions.Add(new Question
                        {
                            Id = reader.GetInt32(0),
                            statement = reader.GetString(1),
                            username = reader.GetString(2)
                        });
                    }
                }
            }
            return questions;
        }

        private void LoadCategories()
        {
            string query = "SELECT Id, Name FROM Category";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        chkCategories.DataSource = reader;
                        chkCategories.DataTextField = "Name";
                        chkCategories.DataValueField = "Id";
                        chkCategories.DataBind();
                    }
                }
            }
        }

        private void LoadQuestions()
        {
            string query = @"
                SELECT 
                    P.Id,
                    P.statement,
                    U.username
                FROM 
                    Problem P
                INNER JOIN 
                    Users U ON P.userId = U.Id
                ORDER BY 
                    P.Id DESC";

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

        private void LoadFilteredQuestions()
        {
            List<string> selectedCategories = new List<string>();
            foreach (ListItem item in chkCategories.Items)
            {
                if (item.Selected)
                {
                    selectedCategories.Add(item.Value);
                }
            }

            if (selectedCategories.Count == 0)
            {
                LoadQuestions();
                return;
            }

            string categories = string.Join(",", selectedCategories);

            string query = $@"
                SELECT 
                    P.Id,
                    P.statement,
                    U.username
                FROM 
                    Problem P
                INNER JOIN 
                    Users U ON P.userId = U.Id
                WHERE 
                    P.categoryId IN ({categories})";

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
                    else
                    {
                        rptQuestions.DataSource = null;
                        rptQuestions.DataBind();
                    }
                }
            }
        }
    }

    // Question class to hold question data
    public class Question
    {
        public int Id { get; set; }
        public string statement { get; set; }
        public string username { get; set; }
    }
}
