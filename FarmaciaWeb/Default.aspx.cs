using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }




    protected void iniciar_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(TextBox1.Text) && !String.IsNullOrEmpty(Password1.Value))
        {
            Response.Write("<script>alert('"+TextBox1.Text+" "+Password1.Value+"')</script>");
            Session["admin"] = "admin";
        }
    }
}