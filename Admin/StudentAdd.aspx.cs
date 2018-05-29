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
    string path_cv = "", path_image = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getdata();
        }
        this.label12.Visible = false;
    }
    public void getdata()
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "Select * from Course";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            this.DropDownList1.Items.Add(dr.GetValue(1).ToString());
        }
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
        int course_id = this.DropDownList1.SelectedIndex + 1;
        string fees = this.TextBox6.Text;
        Random r = new Random();
        int id = r.Next(1, 10000);
        String stud_code = "ST-" + id.ToString();
        String s = "insert into Student(stud_code,stud_name,stud_mail,stud_pass,stud_address,stud_country,course_id,stud_fees,stud_attcount,stud_lastatt,batch_id,stud_cv,stud_image) values (@stud_code,@stud_name,@stud_mail,@stud_pass,@stud_address,@stud_country,@course_id,@stud_fees,@stud_attcount,@stud_lastatt,@batch_id,@stud_cv,@stud_image)";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("stud_code", stud_code);
        cmd.Parameters.AddWithValue("stud_name", name);
        cmd.Parameters.AddWithValue("stud_mail", email);
        cmd.Parameters.AddWithValue("stud_pass", pass);
        cmd.Parameters.AddWithValue("stud_address", address);
        cmd.Parameters.AddWithValue("stud_country", country);
        cmd.Parameters.AddWithValue("course_id", course_id);
        cmd.Parameters.AddWithValue("stud_fees", fees);
        cmd.Parameters.AddWithValue("stud_attcount", 0);
        cmd.Parameters.AddWithValue("stud_lastatt", "");
        cmd.Parameters.AddWithValue("batch_id", "");
        cmd.Parameters.AddWithValue("stud_cv", path_cv);
        cmd.Parameters.AddWithValue("stud_image", path_image);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            this.label12.Visible = true;
            this.label12.Text = "Your Student ID is " + stud_code + ". <br/> Please visit <a href=\"StudentDetail.aspx\"><b>All Students</b></a> to view all students";
        }
        else
        {
            Response.Write("<script>alert('Student not added successfully')</script>");
        }
        con.Close();
    }
}