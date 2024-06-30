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

public partial class Adminlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["ADMIN"] != null) { Response.Redirect("Adminhome.aspx", false); }
            }
        }
        catch (Exception ex) { LblMessage.Text = "PLEASE TRY AFTER SOME TIMES."; }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            string[] AllQueryParam = new string[2];
           // string _sqlQuery = "select * from ADMINLOGIN where USERID='" + txtUserName.Text + "' and PASSWORD='" + txtPassword.Text + "'";
            AllQueryParam[0] = txtUserName.Text;
            AllQueryParam[1] = txtPassword.Text;
            BLL objbllLogin = new BLL();
            objbllLogin.AdminLogin(ref dt, AllQueryParam);
            if (dt.Rows.Count > 0)
            {
                LblMessage.Text = "";
                if (txtUserName.Text.ToUpper() == "USER") { Session["USER"] = txtUserName.Text; Response.Redirect("Search.aspx", false); }
                else { Session["ADMIN"] = txtUserName.Text; Response.Redirect("Adminhome.aspx", false); }
            }
            else
            {
                LblMessage.Text = "INVALID USER NAME OR PASSWORD.";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('INVALID USER NAME OR PASSWORD.');", true);
            }
        }
        catch (Exception ex)
        {
            LblMessage.Text = "PLEASE TRY AFTER SOME TIMES.";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('PLEASE TRY AFTER SOME TIMES.');", true);
        }
    }
}