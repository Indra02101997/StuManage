using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Admin_BatchView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            refreshdata();
        }
    }
    protected void Course_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Batch.PageIndex = e.NewPageIndex;
        refreshdata();
    }
    public void refreshdata()
    {
        SqlDataSource da1 = new SqlDataSource();
        da1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        da1.SelectCommand = @"SELECT Batch.batch_id,Batch.batch_sdate,Batch.batch_edate,Course.course_name FROM  Course INNER JOIN Batch ON Batch.course_id = Course.course_id";
        da1.DataBind();
        Batch.DataSource = da1;
        Batch.DataBind();
        da1.Dispose();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String id = Batch.DataKeys[e.RowIndex].Values["batch_id"].ToString();
        string s = "delete from Batch where batch_id=@batch_id";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("batch_id", id);
        Response.Write("<script> alert(' Are you sure you want to delete ?!')</script>");
        int i = cmd.ExecuteNonQuery();
        con.Close();
        refreshdata();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/BatchAdd.aspx");
    }
}