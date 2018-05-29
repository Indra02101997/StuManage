using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Client_FeesDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getdata();
        }
    }
    public void view(string id)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "Select * from Course where course_id='" + id + "'";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            this.Label6.Text = dr.GetValue(3).ToString();
            this.Label11.Text = dr.GetValue(1).ToString();
        }
        con.Close();
    }
    public void getdata()
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "Select * from Student where stud_code='" + Session["id"].ToString() + "'";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            this.Label2.Text = dr.GetValue(0).ToString();
            this.Label4.Text = dr.GetValue(1).ToString();
            this.Label8.Text = dr.GetValue(7).ToString();
            string id = dr.GetValue(6).ToString();
            view(id);
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        string t = this.TextBox1.Text;
        int mon = int.Parse(t);
        int m1 = int.Parse(this.Label6.Text);
        int l = int.Parse(this.Label8.Text);
        if ((l+mon) > m1)
        {
            Response.Write("<script>alert('Extra money not required')</script>");
            return;
        }
        else
        {
            l = l + mon;
        }
        String s = "update Student set stud_fees=@stud_fees where stud_code=@stud_code";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("stud_fees", l.ToString());
        cmd.Parameters.AddWithValue("stud_code", Session["id"].ToString());
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Response.Redirect("~/Client/FeesDetails.aspx");
            }
            else
            {

            }
        }
        else
        {
            Response.Write("<script>alert('Fees Details not updated Successfully')</script>");
        }
        con.Close();
    }
}