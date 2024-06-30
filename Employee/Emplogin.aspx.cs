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

public partial class Emplogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["ID"] != null) { Response.Redirect("Stuhome.aspx", false); }
            }
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            bool val = validation();
            if (val == false)
            {
                LblMessage.Text = "Please Enter Employee Code and Password.";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Employee Code and Password.');", true);
                return;
            }
            DataTable dt = new DataTable();
            string[] AllQueryParam = new string[1];
            string _sqlQuery = string.Empty;
            
            _sqlQuery = "SELECT * FROM EMPLOYEE WHERE EMPCODE='" + txtUserName.Text + "' AND PASSWORD='" + txtPassword.Text + "'";
            AllQueryParam[0] = _sqlQuery;
            BLL objbllLogin = new BLL();
            objbllLogin.QUERYBLL(ref dt, AllQueryParam);
            if (dt.Rows.Count > 0)
            {
                LblMessage.Text = "";
                Session["EMPCODE"] = dt.Rows[0]["EMPID"].ToString().Trim();
                Response.Redirect("Emphome.aspx", false);
            }
            else { LblMessage.Text = "Invalid Employee Code OR Password."; ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Employee Code OR Password.');", true); }
        }
        catch (Exception ex)
        {
            LblMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The Login can not complete. Please try after some time !');", true);
        }
    }
    protected void lnkforgotpassword_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Default.aspx", false);
        }
        catch (Exception ex)
        {
            //LblMessage.Text = ex.Message;
            LblMessage.Text = "Please try after some time !";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The Login can not complete. Please try after some time !');", true);
        }
    }
    private bool validation()
    {
        if (txtUserName.Text == "") { return false; }
        if (txtPassword.Text == "") { return false; }
        return true;
    }
}