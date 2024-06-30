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

public partial class Insloginsingle : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string INS = string.Empty;
                string BR = string.Empty;
                if (Request.QueryString["NEW"] == null) { Response.Redirect("~/Error.aspx", true); }
                {
                    string[] DATA = Request.QueryString["NEW"].ToString().Split('|');
                    INS = DATA[0].ToString();
                    BR = DATA[1].ToString();
                }
                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                string[] AllQueryParamreg = new string[1];
                _sqlQueryreg = "select distinct INSCODE,INSNAME from INSLOGIN order by INSCODE asc";
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
                    Drpins.SelectedValue = INS;
                    Drpins.Enabled = false;
                    Drpusertype.SelectedIndex = 2;
                    Drpusertype.Enabled = false;

                    DataTable dtbr=new DataTable();
                    dtbr.Columns.Add("BRCODE");
                    dtbr.Columns.Add("BRNAME");
                    DataRow dr = dtbr.NewRow();
                    dr["BRCODE"] = "16-I";
                    dr["BRNAME"] = "16-PHARMACY";
                    dtbr.Rows.Add(dr);
                    Drpbranch.DataValueField = dtbr.Columns["BRCODE"].ToString().Trim();
                    Drpbranch.DataTextField = dtbr.Columns["BRNAME"].ToString().Trim();
                    Drpbranch.DataSource = dtbr;
                    Drpbranch.DataBind();
                    if (Drpbranch.Items.Count > 0) { Drpbranch.SelectedIndex = 0; }
                    Drpbranch.Enabled = false;
                }
                else { Response.Redirect("~/Error.aspx", true); }
            }
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Drpusertype.SelectedValue == "B")
            {
                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                string[] AllQueryParamreg = new string[1];
                _sqlQueryreg = "select * from BRLOGIN where INSCODE='" + Drpins.SelectedValue + "' and BRCODE='" + Drpbranch.SelectedValue + "' and PASSWORD='" + txtPassword.Text + "'";
                AllQueryParamreg[0] = _sqlQueryreg;
                BLL objbllreg = new BLL();
                objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                if (dtreg.Rows.Count > 0)
                {
                    LblMessage.Text = "";
                    Session["INSCODE"] = Drpins.SelectedValue + "|" + Drpins.SelectedItem.ToString();
                    Session["UTYPE"] = "B";
                    Session["BRCODE"] = Drpbranch.SelectedValue + "|" + Drpbranch.SelectedItem.ToString();
                    Session["REGCAT"] = "GOVT";
                    Response.Redirect("Brhomesingle.aspx", false);
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
   
}