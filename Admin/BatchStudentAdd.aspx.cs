using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Web.Services;
using System.Web.Script.Services;
using System.IdentityModel;
public partial class Admin_BatchStudentAdd : System.Web.UI.Page
{
    string batch = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BatchStudent.Visible = false;
        if (!IsPostBack)
        {
            addbatch();
        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetCompletionList(string prefixText, int count)
    {
        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlCommand com = new SqlCommand())
            {
                com.CommandText = "select stud_code from Student where " + "stud_code like @Search + '%'";

                com.Parameters.AddWithValue("@Search", prefixText);
                com.Connection = con;
                con.Open();
                List<string> countryNames = new List<string>();
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        countryNames.Add(sdr["stud_code"].ToString());
                    }
                }
                con.Close();
                return countryNames;


            }

        }

    }
    public void addbatch()
    {
        this.DropDownList1.Items.Clear();
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "Select * from Batch";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            this.DropDownList1.Items.Add(dr.GetValue(0).ToString());
        }
        con.Close();
    }
    public void view()
    {
        BatchStudent.Visible = true;
        SqlDataSource da1 = new SqlDataSource();
        da1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        da1.SelectCommand = @"SELECT Student.stud_code,Student.stud_name,Student.batch_id,Course.course_name FROM  Course INNER JOIN Student ON Student.course_id = Course.course_id where Student.batch_id=@batch_id";
        da1.SelectParameters.Add("batch_id", batch);
        da1.DataBind();
        BatchStudent.DataSource = da1;
        BatchStudent.DataBind();
        da1.Dispose();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String id = BatchStudent.DataKeys[e.RowIndex].Values["stud_code"].ToString();
        string s = "update Student set batch_id=@batch_id where stud_code=@stud_code";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("batch_id", "");
        cmd.Parameters.AddWithValue("stud_code", id);
        Response.Write("<script> alert(' Are you sure you want to delete ?!')</script>");
        int i = cmd.ExecuteNonQuery();
        con.Close();
        view();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        batch = this.DropDownList1.SelectedItem.ToString();
        string code = this.TextBox1.Text;
        String s = "update Student set batch_id=@batch_id where stud_code=@stud_code";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("batch_id", batch);
        cmd.Parameters.AddWithValue("stud_code", code);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            view();
        }
        con.Close();
    }
    protected void Teacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BatchStudent.PageIndex = e.NewPageIndex;
        view();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        view();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/BatchView.aspx");
    }
}