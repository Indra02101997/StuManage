using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Client : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label2.Text = Session["name"].ToString();
        if (!IsPostBack)
        {
            if (Session["id"] == null && Session["name"] == null)
            {
                Response.Redirect("~/Client/Default.aspx");
            }
            else
            {
                Response.ClearHeaders();
                Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                Response.AddHeader("Pragma", "no-cache");
            }
        }
    }
    protected void logout_click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Clear();
        Response.Redirect("~/Client/Default.aspx");
    }
}
