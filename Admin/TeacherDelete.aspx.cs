using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Admin_TeacherDelete : System.Web.UI.Page
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
            Response.Redirect("TeacherDetail.aspx");
        }
        getdata();
    }
    public void getdata()
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "Select * from Teacher where teacher_id='" + pro_id + "'";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            this.Label2.Text = dr.GetValue(1).ToString();
            this.Label4.Text = dr.GetValue(2).ToString();
            this.Label6.Text = dr.GetValue(3).ToString();
            this.TextBox3.Text = dr.GetValue(4).ToString();
            this.Label9.Text = dr.GetValue(5).ToString();
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "delete from Teacher where teacher_id='" + pro_id + "'";
        SqlCommand cmd = new SqlCommand(s, con);
        int i = 0;
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            i = cmd.ExecuteNonQuery();
            if (i == 1)
            {
                Response.Redirect("TeacherDetail.aspx");
            }
            else
            {
                Response.Write("<script>alert('Teacher Not Deleted Successfully')</script>");
            }
        }
        else
        {

        }
        con.Close();
    }
}