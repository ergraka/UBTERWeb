using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.MasterPage
{
    public string user = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null && Session["USER"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Session["ADMIN"] != null)
            {
                if (Session["ADMIN"].ToString().ToUpper() == "UBTER" || Session["ADMIN"].ToString().ToUpper() == "SANTROS" || Session["ADMIN"].ToString().ToUpper() == "CHETAN")
                {
                    user = Session["ADMIN"].ToString().ToUpper();
                    Lnkhome.Visible = true;
                    Lnkinstitute.Visible = true;
                    Lnkbranch.Visible = true;
                    Lnkstudent.Visible = true;
                    Lnkreport.Visible = true;
                    Lnksearch.Visible = true;
                    Lnksubject.Visible = true;
                    Lnkchangepassword.Visible = true;
                }
            }
            else { user = Session["USER"].ToString().ToUpper(); }
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
    protected void Lnklogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("Adminlogin.aspx", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
}
