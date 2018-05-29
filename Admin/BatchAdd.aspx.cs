using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Admin_BatchView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getdata();
            add();
        }
        this.Label5.Visible = false;
    }
    public void getdata()
    {
        this.DropDownList1.Items.Clear();
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
        con.Close();
    }
    public void add()
    {
        this.DropDownList2.Items.Clear();
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        String s = "Select * from Teacher";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            this.DropDownList2.Items.Add(dr.GetValue(1).ToString());
        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        int course = this.DropDownList1.SelectedIndex + 1;
        int teacher = this.DropDownList2.SelectedIndex + 1;
        string sdate = this.TextBox1.Text;
        string edate = this.TextBox2.Text;
        Random r = new Random();
        int id = r.Next(1, 10000);
        String batch_id = "BT-" + id.ToString();
        String s = "insert into Batch(batch_id,course_id,teacher_id,batch_sdate,batch_edate) values(@batch_id,@course_id,@teacher_id,@batch_sdate,@batch_edate)";
        SqlCommand cmd = new SqlCommand(s, con);
        cmd.Parameters.AddWithValue("batch_id", batch_id);
        cmd.Parameters.AddWithValue("course_id", course);
        cmd.Parameters.AddWithValue("teacher_id", teacher);
        cmd.Parameters.AddWithValue("batch_sdate", sdate);
        cmd.Parameters.AddWithValue("batch_edate", edate);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            this.Label5.Visible = true;
            this.Label5.Text = "New Batch ID is "+ batch_id+ ". <br/> Please visit <a href=\"BatchStudentAdd.aspx\"><b>Add Student</b></a> to add students or go to <br/> <a href=\"BatchView.aspx\"> <b>Batch Details</b></a> to view all batches"; ;
        }
        else
        {
            Response.Write("<script>alert('Batch Not Added Successfully')</script>");
        }
        con.Close();
    }
}