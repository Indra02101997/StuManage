using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class Client_Account : System.Web.UI.Page
{
    protected string path_cv = "", path_image = "";
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
        String s = "Select * from Student where stud_code='" + Session["id"].ToString() + "'";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            this.TextBox1.Text = dr.GetValue(1).ToString();
            this.TextBox2.Text = dr.GetValue(2).ToString();
            this.TextBox3.Text = dr.GetValue(3).ToString();
            this.TextBox4.Text = dr.GetValue(4).ToString();
            this.TextBox5.Text = dr.GetValue(5).ToString();
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        string name = this.TextBox1.Text;
        string email = this.TextBox2.Text;
        string pass = this.TextBox3.Text;
        string address = this.TextBox4.Text;
        string country = this.TextBox5.Text;
        if (FileUpload1.PostedFile.FileName != "" || FileUpload1.PostedFile.FileName != null)
        {
            string file = Path.GetFileName(FileUpload1.PostedFile.FileName);
            int imgSize = FileUpload1.PostedFile.ContentLength;
            string ext = Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
            FileUpload1.SaveAs(Server.MapPath("~/StudentCv/" + file));
            path_cv = "~/StudentCv/" + file;
        }
        if (FileUpload2.PostedFile.FileName != "" || FileUpload2.PostedFile.FileName != null)
        {
            string file = Path.GetFileName(FileUpload2.PostedFile.FileName);
            int imgSize = FileUpload2.PostedFile.ContentLength;
            string ext = Path.GetExtension(this.FileUpload2.PostedFile.FileName).ToLower();
            FileUpload2.SaveAs(Server.MapPath("~/StudentImage/" + file));
            path_image = "~/StudentImage/" + file;
        }
        String s = "update Student set stud_name=@stud_name,stud_mail=@stud_mail,stud_pass=@stud_pass,stud_address=@stud_address,stud_country=@stud_country,stud_cv=@stud_cv,stud_image=@stud_image where stud_code=@stud_code";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("stud_name", name);
        cmd.Parameters.AddWithValue("stud_mail", email);
        cmd.Parameters.AddWithValue("stud_pass", pass);
        cmd.Parameters.AddWithValue("stud_address", address);
        cmd.Parameters.AddWithValue("stud_country", country);
        cmd.Parameters.AddWithValue("stud_cv", path_cv);
        cmd.Parameters.AddWithValue("stud_image", path_image);
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
            Response.Write("<script>alert('Details not updated Successfully')</script>");
        }
        con.Close();
    }
}