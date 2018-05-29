using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Admin_CourseEdit : System.Web.UI.Page
{
    protected string pro_id="";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_Init(object sender, EventArgs e)
    {
        pro_id = Request.QueryString.Get("pid").ToString();
        if (pro_id.ToString() == String.Empty)
        {
            Response.Redirect("CourseDetail.aspx");
        }
        getdata();
    }
    public void getdata()
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "Select * from Course where course_id='" + pro_id + "'";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            this.TextBox1.Text = dr.GetValue(1).ToString();
            this.TextBox2.Text = dr.GetValue(2).ToString();
            this.TextBox3.Text = dr.GetValue(3).ToString();
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        string name = this.TextBox1.Text;
        string duration = this.TextBox2.Text;
        string fees = this.TextBox3.Text;
        String s = "update Course set course_name=@course_name,course_duration=@course_duration,course_fees=@course_fees where course_id=@course_id";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("course_name", name);
        cmd.Parameters.AddWithValue("course_duration", duration);
        cmd.Parameters.AddWithValue("course_fees", fees);
        cmd.Parameters.AddWithValue("course_id", Convert.ToInt32(pro_id));
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Response.Redirect("CourseDetail.aspx");
            }
            else
            {

            }
        }
        else
        {
            Response.Write("<script>alert('Course Not Updated Successfully')</script>");
        }
        con.Close();
    }
}