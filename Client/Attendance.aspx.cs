using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Client_Attendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            getdata();
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
            this.Label6.Text = dr.GetValue(9).ToString();
            this.Label8.Text = dr.GetValue(8).ToString();
        }
        con.Close();
    }
}