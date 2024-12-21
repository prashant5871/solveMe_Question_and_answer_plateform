using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace solveMe
{
    public partial class ViewAnswers : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["solveMeDbCon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrUser"] != null)
            {
                User user = (User)Session["CurrUser"];
                if(user.isAdmin)
                {
                    Session["Admin"] = true;
                }
                else
                {
                    Session["Admin"] = false;
                }
            }
            if (!IsPostBack)
            {
                string questionId = Request.QueryString["QuestionID"];
                if (!string.IsNullOrEmpty(questionId))
                {
                    LoadQuestionAndAnswers(questionId);
                }
            }
        }

        // Load the question text and answers
        private void LoadQuestionAndAnswers(string questionId)
        {
            LoadQuestion(questionId);
            LoadAnswers(questionId);
        }

        // Method to load question details
        private void LoadQuestion(string questionId)
        {
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
                    else
                    {
                        lblQuestion.Text = "Question not found.";
                    }
                }
            }
        }

        // Method to load answers
        private void LoadAnswers(string questionId)
        {
            string query = @"SELECT s.Id, s.solution, u.username
                             FROM Solution s
                             JOIN Users u ON s.userId = u.Id
                             WHERE s.problemId = @questionId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@questionId", questionId);
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            rptAnswers.DataSource = dt;
                            rptAnswers.DataBind();
                        }
                        else
                        {
                            lblNoAnswers.Visible = true;
                        }
                    }
                }
            }
        }

        // Method to show delete button only for admin users
        protected void rptAnswers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btnDelete = (Button)e.Item.FindControl("btnDelete");
                bool isAdmin = Convert.ToBoolean(Session["isAdmin"]); // Assuming you set this session variable during login

                if (isAdmin)
                {
                    btnDelete.Visible = true;
                }
            }
        }

        // Handle delete button click
        protected void rptAnswers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteAnswer")
            {
                string answerId = e.CommandArgument.ToString();
                DeleteAnswer(answerId);
            }
        }

        // Method to delete the answer from the database
        private void DeleteAnswer(string answerId)
        {
            string query = "DELETE FROM Solution WHERE Id = @answerId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@answerId", answerId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Reload answers after deletion
            string questionId = Request.QueryString["QuestionID"];
            if (!string.IsNullOrEmpty(questionId))
            {
                LoadAnswers(questionId);
            }
        }
    }
}
