using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class Admin_StudentDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getdata();
        }
    }
    public void getdata()
    {
        SqlDataSource da1 = new SqlDataSource();
        da1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        da1.SelectCommand = @"SELECT Student.stud_code,Student.stud_name,Student.batch_id,Course.course_name FROM  Course INNER JOIN Student ON Student.course_id = Course.course_id";
        da1.DataBind();
        Student.DataSource = da1;
        Student.DataBind();
        da1.Dispose();
    }
    protected void Course_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Student.PageIndex = e.NewPageIndex;
        getdata();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String id = Student.DataKeys[e.RowIndex].Values["stud_code"].ToString();
        string s = "delete from Student where stud_code=@stud_code";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("stud_code", id);
        Response.Write("<script> alert(' Are you sure you want to delete ?!')</script>");
        int i = cmd.ExecuteNonQuery();
        con.Close();
        getdata();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/StudentAdd.aspx");
    }
}