using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class Client_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCapctha();
        }
    }
    public void FillCapctha()
    {
        try
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha"] = captcha.ToString();
            imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {

            throw;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string pass = "";
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        string email = this.TextBox1.Text;
        string p = this.TextBox2.Text;
        string s = "select * from Student where stud_mail='" + email + "'";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            string name = dr.GetValue(1).ToString();
            Session["name"] = name;
            Session["id"] = dr.GetValue(0).ToString();
            pass = dr.GetValue(3).ToString();
        }
        if (Session["captcha"].ToString() != this.TextBox3.Text)
        {
            Response.Write("<script>alert('InValid Captcha Code Try Again')</script>");
            return;
        }
        else if (p != pass && (Session["captcha"].ToString() == this.TextBox3.Text))
        {
            Response.Write("<script>alert('Password Not Matching Try Again!')</script>");
            return;
        }
        else
        {
            Response.Write("<script>alert('You are successfully logged in')</script>");
            Response.Redirect("~/Client/FeesDetails.aspx");
        }
        con.Close();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        FillCapctha();
    }
}