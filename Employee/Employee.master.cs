using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using _Examination;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class Employee : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["EMPCODE"] == null) { Response.Redirect("Emplogin.aspx", false); }
            Lblname.Text = "WELCOME : " + Session["EMPCODE"].ToString();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The registration can not complete. Please try after some time !');", true);
        }
    }
    protected void Lnklogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("Emplogin.aspx", false);
        }
        catch (Exception ex) { Response.Write(ex.Message); }
    }
}
