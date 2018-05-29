using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class Admin_BatchViewDetails : System.Web.UI.Page
{
    protected string batch_id = "",date1="";
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        batch_id = Request.QueryString.Get("pid").ToString();
        if (batch_id.ToString() == String.Empty)
        {
            Response.Redirect("BatchView.aspx");
        }
        this.Label2.Text = batch_id.ToString();
        if (!IsPostBack)
        {
            refreshdata();
        }
    }
    public void refreshdata()
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "Select * from Student where batch_id='" + batch_id + "'";
        SqlDataAdapter da = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        refreshdata();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        refreshdata();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String id = GridView1.DataKeys[e.RowIndex].Values["stud_code"].ToString();
        string s = "update Student set batch_id=@batch_id where stud_code=@id";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("batch_id", "");
        cmd.Parameters.AddWithValue("id", id);
        Response.Write("<script> alert(' Are you sure you want to delete ?!')</script>");
        int i = cmd.ExecuteNonQuery();
        con.Close();
        refreshdata();
    }
    public void getdate(String id)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "Select * from Student where stud_code='"+id+"'";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            date1 = dr.GetValue(9).ToString();
        }
        con.Close();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        TextBox date = GridView1.Rows[e.RowIndex].FindControl("textbox1") as TextBox;
        TextBox total = GridView1.Rows[e.RowIndex].FindControl("textbox2") as TextBox;
        int t1 = Convert.ToInt32(total.Text) + 1;
        String id = GridView1.DataKeys[e.RowIndex].Values["stud_code"].ToString();
        getdate(id);
        if (date.Equals(date1))
        {
            t1 = t1 - 1;
        }
        string s = "update Student set stud_lastatt=@stud_lastatt,stud_attcount=@stud_attcount where stud_code=@stud_code";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("stud_lastatt", date.Text);
        cmd.Parameters.AddWithValue("stud_attcount", t1);
        cmd.Parameters.AddWithValue("stud_code", id);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        refreshdata();
    }
    protected void Course_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        refreshdata();
    }
}