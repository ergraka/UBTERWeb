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
using System.Reflection;
public partial class Inshome : System.Web.UI.Page
{
    public string cname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null && Session["UTYPE"] != null)
            {
                if (!IsPostBack)
                {
                   // bindsourcedata();
                }
            }
            else { Response.Redirect("Inslogin.aspx", false); }
        }
        catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }
    }
   
}
