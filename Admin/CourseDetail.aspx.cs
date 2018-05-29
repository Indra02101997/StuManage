using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Admin_CourseDetail : System.Web.UI.Page
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
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "Select * from Course";
        SqlDataAdapter da = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Course.DataSource = ds;
        Course.DataBind();
        con.Close();
    }
    protected void Course_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Course.PageIndex = e.NewPageIndex;
        getdata();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/CourseAdd.aspx");
    }
}