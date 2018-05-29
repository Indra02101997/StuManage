using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class Admin_TeacherAdd : System.Web.UI.Page
{
    protected string path = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.RadioButton1.Checked = true;
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
        {
            sex = "Male";
        }
        else
        {
            sex = "Female";
        }
        string address = this.TextBox3.Text;
        string qua = this.DropDownList1.SelectedItem.Text;
        if (FileUpload1.PostedFile.FileName != "" || FileUpload1.PostedFile.FileName != null)
        {
            string file = Path.GetFileName(FileUpload1.PostedFile.FileName);
            int imgSize = FileUpload1.PostedFile.ContentLength;
            string ext = Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
            FileUpload1.SaveAs(Server.MapPath("~/TeacherCv/" + file));
            path = "~/TeacherCv/" + file;
        }
        String s="insert into Teacher(teacher_name,teacher_age,teacher_sex,teacher_address,teacher_qualification,teacher_cv) values(@teacher_name,@teacher_age,@teacher_sex,@teacher_address,@teacher_qualification,@teacher_cv)";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("teacher_name", name);
        cmd.Parameters.AddWithValue("teacher_age", age);
        cmd.Parameters.AddWithValue("teacher_sex", sex);
        cmd.Parameters.AddWithValue("teacher_address", address);
        cmd.Parameters.AddWithValue("teacher_qualification", qua);
        cmd.Parameters.AddWithValue("teacher_cv", path);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Response.Redirect("~/Admin/TeacherDetail.aspx");
            }
            else
            {

            }
        }
        else
        {
            Response.Write("<script>alert('Teacher Not Added Successfully')</script>");
        }
        con.Close();
    }
}