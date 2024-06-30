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
public partial class Branchdownload : System.Web.UI.Page
{
    public string Comp = string.Empty;
    DataTable dt = new DataTable();
    public string LNKURL = "~/Institute/Stulist.aspx?";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (!IsPostBack)
            {
                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                BLL objbllreg = new BLL();
                string[] AllQueryParamreg = new string[1];

                _sqlQueryreg = "select distinct INSCODE,INSNAME from INSLOGIN order by INSCODE asc";
                AllQueryParamreg[0] = _sqlQueryreg;
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
        }
        catch (Exception ex) { LblMessage.Text = "Server Busy, Please try after some time !"; }
    }
    protected void Drpins_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpins.SelectedIndex > 0)
            {
                string _sqlQueryreg = string.Empty;
                string[] AllQueryParamreg = new string[1];
                BLL objbllreg = new BLL();
                //Get Branch
                DataTable dtins = new DataTable();
                _sqlQueryreg = "select * from BRLOGIN where INSCODE='" + Drpins.SelectedValue + "' order by BRCODE asc";
                AllQueryParamreg[0] = _sqlQueryreg;
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
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            LblMessage.Text = "";
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            bindsourcedata();
        }
        catch (Exception ex)
        { LblMessage.Text = ex.Message; }
    }
    private void bindsourcedata()
    {
        string _sqlQuery = string.Empty;
        DataTable dtdata = ROWS();
        Grdbranch.DataSource = dtdata; Grdbranch.DataBind();
    }
    private DataTable ROWS()
    {

        string INSCODE = Drpins.SelectedValue;
        string BRCODE = Drpbranch.SelectedValue;
        string cntquery = string.Empty;
        DataTable dt = new DataTable();
        dt.Columns.Add("INSNAME");
        dt.Columns.Add("BRNAME");
        dt.Columns.Add("NOMNME");
        dt.Columns.Add("NOMURL");
        dt.Columns.Add("SNOMURL");
        dt.Columns.Add("RNOMURL");
        dt.Columns.Add("BNOMURL");
        dt.Columns.Add("SBNOMURL");
        dt.Columns.Add("LSEURL");
        dt.Columns.Add("LSDURL");
        dt.Columns.Add("SESURL");
        dt.Columns.Add("CROURL");
        dt.Columns.Add("SCROURL");
        dt.Columns.Add("RCROURL");
        dt.Columns.Add("ADMURL");
        dt.Columns.Add("VERURL");
        dt.Columns.Add("MARURL");
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        _sqlQueryreg = "select * from BRLOGIN WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "'";
        AllQueryParamreg[0] = _sqlQueryreg;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0)
        {
            Session["INSCODE"] = Drpins.SelectedValue + "|" + Drpins.SelectedItem.ToString();
            Session["UTYPE"] = "B";
            Session["BRCODE"] = Drpbranch.SelectedValue + "|" + Drpbranch.SelectedItem.ToString();

            int CNT = 0;
            string SEMYEAR = string.Empty;
            string BR = BRCODE.Substring(0, 2).ToString();
            if (BR == "07") { CNT = 5; SEMYEAR = "YEAR"; }
            else if (BR == "16") { CNT = 4; SEMYEAR = "YEAR"; }
            else { CNT = 8; SEMYEAR = "SEM"; }
            DataRow dr = dt.NewRow();
            for (int i = 1; i <= CNT; i++)
            {
                string SEM = "0" + i.ToString();
                if (BR == "07")
                {
                    if (SEM == "04") { SEM = "P"; }
                    else if (SEM == "05") { SEM = "Q"; }
                }
                else if (BR == "16")
                {
                    if (SEM == "03") { SEM = "P"; }
                    else if (SEM == "04") { SEM = "Q"; }
                }
                else
                {
                        if (SEM == "07") { SEM = "P"; }
                        else if (SEM == "08") { SEM = "Q"; }
                }
                string BRNAME = Drpbranch.SelectedValue.ToString();
                string INSNAME = Drpins.SelectedValue.ToString();
                dr["BRNAME"] = BRNAME;
                dr["INSNAME"] = INSNAME;
                dr["NOMNME"] = SEMYEAR + "-" + SEM;
                dr["NOMURL"] = "~/Report/Nominal.aspx?TYP=" + SEM;
                dr["SNOMURL"] = "~/Report/Nominalscru.aspx?TYP=" + SEM;
                dr["RNOMURL"] = "~/Report/Nominalreeva.aspx?TYP=" + SEM;
                dr["BNOMURL"] = "~/Report/Nominalbackpaper.aspx?TYP=" + SEM;
                dr["SBNOMURL"] = "~/Report/Nominalsbackpaper.aspx?TYP=" + SEM;

                // Comment on 01-06-2023

                //dr["LSEURL"] = "~/Report/Liste_Practical.aspx?TYP=" + SEM;
                dr["LSEURL"] = "https://ubter.ncampus.org/branch_login";
                //dr["LSDURL"] = "~/Report/Listd_Theory.aspx?TYP=" + SEM;

                dr["LSDURL"] = "https://ubter.ncampus.org/branch_login";

                //if (BR == "16") { dr["SESURL"] = "~/Report/List_Farm_Sess.aspx?TYP=" + SEM; }
                //else { dr["SESURL"] = "~/Report/List_Sem_Sess.aspx?TYP=" + SEM; }

                dr["SESURL"] = "https://ubter.ncampus.org/branch_login";

                dr["CROURL"] = "~/Institute/Canidpass.aspx?DOWNLOAD=CROSS|" + SEM;
                dr["SCROURL"] = "~/Institute/Canidpass.aspx?DOWNLOAD=SCROSS|" + SEM;
                dr["RCROURL"] = "~/Institute/Canidpass.aspx?DOWNLOAD=RCROSS|" + SEM;

                dr["ADMURL"] = LNKURL + "TYP=ADM|" + SEM;
                dr["VERURL"] = LNKURL + "TYP=VER|" + SEM;
                dr["MARURL"] = LNKURL + "TYP=MRK|" + SEM;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
        }
        return dt;
    }
}