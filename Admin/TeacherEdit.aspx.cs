using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class Admin_TeacherEdit : System.Web.UI.Page
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
            this.TextBox1.Text = dr.GetValue(1).ToString();
            this.TextBox2.Text = dr.GetValue(2).ToString();
            this.TextBox3.Text = dr.GetValue(4).ToString();
            string sex = dr.GetValue(3).ToString();
            if (sex.Equals("Male"))
            {
                this.RadioButton1.Checked = true;
            }
            else
            {
                this.RadioButton2.Checked = true;
            }
            this.DropDownList1.Text = dr.GetValue(5).ToString();
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        string name = this.TextBox1.Text;
        string age = this.TextBox2.Text;
        string sex = "";
        if (this.RadioButton1.Checked == true)
            sex = "Male";
        else
            sex = "Female";
        string qua = this.DropDownList1.SelectedItem.Text;
        string address = this.TextBox3.Text;
        string path = "";
        if (FileUpload1.PostedFile.FileName != "" || FileUpload1.PostedFile.FileName != null)
        {
            string file = Path.GetFileName(FileUpload1.PostedFile.FileName);
            int imgSize = FileUpload1.PostedFile.ContentLength;
            string ext = Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
            FileUpload1.SaveAs(Server.MapPath("~/TeacherCv/" + file));
            path = "~/TeacherCv/" + file;
        }
        String s = "update Teacher set teacher_name=@teacher_name,teacher_age=@teacher_age,teacher_sex=@teacher_sex,teacher_address=@teacher_address,teacher_qualification=@teacher_qualification,teacher_cv=@teacher_cv where teacher_id = @teacher_id";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("teacher_name", name);
        cmd.Parameters.AddWithValue("teacher_age", age);
        cmd.Parameters.AddWithValue("teacher_sex", sex);
        cmd.Parameters.AddWithValue("teacher_address", address);
        cmd.Parameters.AddWithValue("teacher_qualification", qua);
        cmd.Parameters.AddWithValue("teacher_cv", path);
        cmd.Parameters.AddWithValue("teacher_id", Convert.ToInt32(pro_id));
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Response.Redirect("TeacherDetail.aspx");
            }
            else
            {

            }
        }
        else
        {
            Response.Write("<script>alert('Teacher Details Not Updated Successfully')</script>");
        }
        con.Close();
    }
}