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

public partial class Login : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["INSCODE"] != null && Session["UTYPE"]!=null) 
                {
                    if (Session["UTYPE"].ToString() == "I") { Response.Redirect("Inshome.aspx", false); }
                    else if (Session["UTYPE"].ToString() == "B") { Response.Redirect("Brhome.aspx", false); }
                }
                else
                {
                    if (Session["REGCAT"] != null)
                    {
                        string _sqlQueryreg = string.Empty;
                        DataTable dtreg = new DataTable();
                        string[] AllQueryParamreg = new string[1];
                        _sqlQueryreg = "select distinct INSCODE,INSNAME from INSLOGIN where STATUS='" + Session["REGCAT"].ToString() + "' order by INSCODE asc"; 
                        AllQueryParamreg[0] = _sqlQueryreg;
                        BLL objbllreg = new BLL();
                        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                        if (dtreg.Rows.Count > 0)
                        {
                            Drpins.DataValueField = dtreg.Columns["INSCODE"].ToString().Trim();
                            Drpins.DataTextField = dtreg.Columns["INSNAME"].ToString().Trim();
                            Drpins.DataSource = dtreg;
                            Drpins.DataBind();
                            if (Drpins.Items.Count > 0) { Drpins.SelectedIndex = 0; }
                        }
                        else { Response.Redirect("~/Error.aspx", true); }

                    }
                    else { Response.Redirect("~/Default.aspx", true); }
                }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Drpusertype.SelectedValue == "I")
            {
                string _sqlQueryreg = string.Empty;
                DataTable dt = new DataTable();
                string UserName = string.Empty;
                string Password = string.Empty;
                string[] AllQueryParamreg = new string[3];
                //string[] AllQueryParamreg = new string[1];
               
                //if (txtPassword.Text == "srnDATA@2004")
                //{ 
                //    _sqlQueryreg = "select * from INSLOGIN where INSCODE='" + Drpins.SelectedValue + "'";
 
                //}
               // else { _sqlQueryreg = "select * from INSLOGIN where INSCODE='" + Drpins.SelectedValue + "' AND PASSWORD='" + txtPassword.Text + "'"; }
               // AllQueryParamreg[0] = _sqlQueryreg;
                AllQueryParamreg[0] = Drpins.SelectedValue;
                AllQueryParamreg[1] = "";
                AllQueryParamreg[2] = txtPassword.Text;
                BLL objbllreg = new BLL();
                objbllreg.InsLogin(ref dt, AllQueryParamreg);
                if (dt.Rows.Count > 0)
                {
                    LblMessage.Text = "";
                    Session["INSCODE"] = Drpins.SelectedValue + "|" + Drpins.SelectedItem.ToString();
                    Session["UTYPE"] = "I";
                    string PWD = dt.Rows[0]["PWD"].ToString().Trim();
                    if (PWD == "Y") { Response.Redirect("Inshome.aspx", false); }
                    else { Response.Redirect("Inschangepass.aspx", false); }
                }
                else
                {
                    LblMessage.Text = "Invalid Login ID or Password !";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Login ID or Password !');", true);
                }
            }
            else if (Drpusertype.SelectedValue == "B")
            {
                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                string[] AllQueryParamreg = new string[3];
                //if (txtPassword.Text == "srnDATA@2004")
                //{ _sqlQueryreg = "select * from BRLOGIN where INSCODE='" + Drpins.SelectedValue + "' and BRCODE='" + Drpbranch.SelectedValue + "'"; }
                //else { _sqlQueryreg = "select * from BRLOGIN where INSCODE='" + Drpins.SelectedValue + "' and BRCODE='" + Drpbranch.SelectedValue + "' and PASSWORD='" + txtPassword.Text + "'"; }
                AllQueryParamreg[0] = Drpins.SelectedValue;
                AllQueryParamreg[1] = Drpbranch.SelectedValue;
                AllQueryParamreg[2] = txtPassword.Text;
                BLL objbllreg = new BLL();
                objbllreg.InsLogin(ref dtreg, AllQueryParamreg);
                if (dtreg.Rows.Count > 0)
                {
                    LblMessage.Text = "";
                    Session["INSCODE"] = Drpins.SelectedValue + "|" + Drpins.SelectedItem.ToString();
                    Session["UTYPE"] = "B";
                    Session["BRCODE"] = Drpbranch.SelectedValue + "|" + Drpbranch.SelectedItem.ToString();
                    Response.Redirect("Brhome.aspx", false);
                }
                else
                {
                    LblMessage.Text = "Invalid Login ID or Password !";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Login ID or Password !');", true);
                }
            }
        }
        catch (Exception ex)
        {
            LblMessage.Text = "Please try after some time";
        }
    }

   

    protected void Drpusertype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["REGCAT"] != null)
            {
                if (Drpusertype.SelectedValue == "I") { TRBRANCH.Visible = false; if (Drpbranch.Items.Count > 0) { Drpbranch.Items.Clear(); } }
                else if (Drpusertype.SelectedValue == "B")
                {
                    if (Drpins.SelectedIndex > 0)
                    {
                        TRBRANCH.Visible = true;
                        string _sqlQueryreg = string.Empty;
                        DataTable dtins = new DataTable();
                        string[] AllQueryParamreg = new string[1];
                        _sqlQueryreg = "select * from BRLOGIN where INSCODE='" + Drpins.SelectedValue + "' order by GRP,BRCODE asc";
                        AllQueryParamreg[0] = _sqlQueryreg;
                        BLL objbllreg = new BLL();
                        objbllreg.QUERYBLL(ref dtins, AllQueryParamreg);
                        if (dtins.Rows.Count > 0)
                        {
                            Drpbranch.DataValueField = dtins.Columns["BRCODE"].ToString().Trim();
                            Drpbranch.DataTextField = dtins.Columns["BRNAME"].ToString().Trim();
                            Drpbranch.DataSource = dtins;
                            Drpbranch.DataBind();
                            if (Drpbranch.Items.Count > 0) { Drpbranch.SelectedIndex = 0; }
                        }
                        else { Response.Redirect("~/Error.aspx", true); }
                    }
                }
                else { TRBRANCH.Visible = false; if (Drpbranch.Items.Count > 0) { Drpbranch.Items.Clear(); } }
            }
            else { Response.Redirect("~/Default.aspx", true); }
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    protected void Drpins_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Drpusertype.SelectedIndex = 0;
            if (Drpbranch.Items.Count > 0) { Drpbranch.Items.Clear(); }
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    protected void lnkhome_Click(object sender, EventArgs e)
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
}