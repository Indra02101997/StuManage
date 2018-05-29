using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Admin_CourseAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        string name = this.TextBox1.Text;
        string duration = this.TextBox2.Text;
        string fees = this.TextBox3.Text;
        String s = "insert into Course(course_name,course_duration,course_fees) values(@course_name,@course_duration,@course_fees)";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("course_name", name);
        cmd.Parameters.AddWithValue("course_duration", duration);
        cmd.Parameters.AddWithValue("course_fees", fees);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Response.Redirect("~/Admin/CourseDetail.aspx");
            }
            else
            {

            }
        }
        else
        {
            Response.Write("<script>alert('Course Not Added Successfully')</script>");
        }
        con.Close();
    }
}