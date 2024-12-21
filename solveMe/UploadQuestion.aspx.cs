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
    public partial class UploadQuestion : System.Web.UI.Page
    {
        private SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =  WebConfigurationManager.ConnectionStrings["solveMeDbCon"].ConnectionString;

            return conn;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlSuccessMessage.Visible = false;
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (Session["CurrUser"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {

                SqlConnection con = getConnection();

                try
                {
                    
                    con.Open();

                    
                    SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM Category", con);

                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    
                    ddlCategory.DataSource = reader;
                    ddlCategory.DataTextField = "Name"; 
                    ddlCategory.DataValueField = "Id";  
                    ddlCategory.DataBind();

                    
                    ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));
                }
                catch (Exception ex)
                {
              
                    Response.Write("<script>alert('Error fetching categories: " + ex.Message + "');</script>");
                }
                finally
                {
                  
                    con.Close();
                }
            }
        }

        protected void btnSubmit_Click(object sender,EventArgs e)
        {
            String CategoryId = ddlCategory.SelectedValue;
            String Question = txtQuestion.Text;

            try
            {
                SqlConnection con = getConnection();
                string query = "insert into Problem (userId,categoryId,statement) values (@userId,@categoryId,@statement)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", ((User)Session["CurrUser"]).id);
                cmd.Parameters.AddWithValue("@categoryId", CategoryId);
                cmd.Parameters.AddWithValue("@statement",Question);

                con.Open();
                cmd.ExecuteNonQuery();
                pnlSuccessMessage.Visible = true;
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}