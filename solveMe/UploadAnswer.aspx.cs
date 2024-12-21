using System;
using System.Data.SqlClient;
using System.Configuration;

namespace solveMe
{
    public partial class UploadAnswer : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["solveMeDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuestion();
            }
        }

        private void LoadQuestion()
        {
            string questionId = Request.QueryString["QuestionID"];
            if (!string.IsNullOrEmpty(questionId))
            {
                // Fetch and display question statement
                string query = "SELECT statement FROM Problem WHERE Id = @questionId";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@questionId", questionId);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            lblQuestion.Text = "Question: " + reader["statement"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string questionId = Request.QueryString["QuestionID"];
            string userId = ((solveMe.User)Session["CurrUser"]).id.ToString(); // Assuming user is logged in
            string answer = txtAnswer.Text;

            if (!string.IsNullOrEmpty(answer))
            {
                // Insert the answer into the Solution table
                string query = "INSERT INTO Solution (problemId, userId, solution) VALUES (@problemId, @userId, @solution)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@problemId", questionId);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@solution", answer);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                lblMessage.Text = "Answer uploaded successfully!";
                lblMessage.Visible = true;
            }
        }
    }
}
