using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Admin_CourseDelete : System.Web.UI.Page
{
    protected string pro_id = "";
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
            this.Label2.Text = dr.GetValue(1).ToString();
            this.Label4.Text = dr.GetValue(2).ToString();
            this.Label6.Text = dr.GetValue(3).ToString();
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "delete from Course where course_id='" + pro_id + "'";
        SqlCommand cmd = new SqlCommand(s, con);
        int i = 0;
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            i = cmd.ExecuteNonQuery();
            if (i == 1)
            {
                Response.Redirect("CourseDetail.aspx");
            }
            else
            {
                Response.Write("<script>alert('Course Not Deleted Successfully')</script>");
            }
        }
        else
        {

        }
        con.Close();
    }
}