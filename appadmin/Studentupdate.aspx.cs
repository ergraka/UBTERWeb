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
public partial class Studentupdate : System.Web.UI.Page
{
    public string Comp = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (!IsPostBack)
            {
                Btnsubmit.Visible = false;

                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                BLL objbllreg = new BLL();
                string[] AllQueryParamreg = new string[1];

                _sqlQueryreg = "select distinct INSCODE,INSNAME from INSLOGIN order by INSCODE asc";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                if (dtreg.Rows.Count > 0)
                {
                    //Old Institute
                    Drpins.DataValueField = dtreg.Columns["INSCODE"].ToString().Trim();
                    Drpins.DataTextField = dtreg.Columns["INSNAME"].ToString().Trim();
                    Drpins.DataSource = dtreg;
                    Drpins.DataBind();
                    if (Drpins.Items.Count > 0) { Drpins.SelectedIndex = 0; }
                    //New Institute
                    Drpnins.DataValueField = dtreg.Columns["INSCODE"].ToString().Trim();
                    Drpnins.DataTextField = dtreg.Columns["INSNAME"].ToString().Trim();
                    Drpnins.DataSource = dtreg;
                    Drpnins.DataBind();
                    if (Drpnins.Items.Count > 0) { Drpnins.SelectedIndex = 0; }
                }
                else { Response.Redirect("~/Error.aspx", true); }
                //Get All Branch
                DataTable dtbr = new DataTable();
                _sqlQueryreg = "select distinct BRCODE,BRNAME from BRLOGIN order by BRCODE asc";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtbr, AllQueryParamreg);
                if (dtbr.Rows.Count > 0)
                {
                    Drpnbranch.DataValueField = dtbr.Columns["BRCODE"].ToString().Trim();
                    Drpnbranch.DataTextField = dtbr.Columns["BRNAME"].ToString().Trim();
                    Drpnbranch.DataSource = dtbr;
                    Drpnbranch.DataBind();
                    if (Drpnbranch.Items.Count > 0) { Drpnbranch.SelectedIndex = 0; }
                }
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
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            LblMessage.Text = "";
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Txtroll.Text == "") { LblMessage.Text = "Please Enter Registration Number OR Roll Number."; return; }

            string _sqlQueryreg = string.Empty;
            DataTable dtreg = new DataTable();
            string[] AllQueryParamreg = new string[1];
            _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "') AND INSCODE='" + Drpins.SelectedValue + "' AND BRCODE='" + Drpbranch.SelectedValue + "'";
            AllQueryParamreg[0] = _sqlQueryreg;
            BLL objbllreg = new BLL();
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count > 0)
            {
                Btnsubmit.Visible = true;
                Drpnins.SelectedValue = dtreg.Rows[0]["INSCODE"].ToString();
                Drpnbranch.SelectedValue = dtreg.Rows[0]["BRCODE"].ToString();
                Drpsem.SelectedValue = dtreg.Rows[0]["SEM"].ToString();
                Drpregpvt.SelectedValue = dtreg.Rows[0]["REGPVT"].ToString();
            }
            else
            {
                LblMessage.Text = Txtroll.Text + "- IS Invalid Registration Number OR Roll Number for Select Institute.Please Enter Valid Registration Number OR Roll Number.";
            }
        }
        catch (Exception ex)
        { LblMessage.Text = ex.Message; }
    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string _sqlQuery = string.Empty;
            BLL objbll = new BLL();
            string[] AllQueryParam = new string[1];
            AllQueryParam[0] = _sqlQuery;

            //Institute Type
            string STAT = string.Empty;
            DataTable dtstat = new DataTable();
            _sqlQuery = "SELECT * FROM INSLOGIN WHERE INSCODE='" + Drpins.SelectedValue + "'";
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dtstat, AllQueryParam);
            if (dtstat.Rows.Count > 0)
            {
                STAT = dtstat.Rows[0]["STATUS"].ToString().Trim();
            }
            //Institute Fee
            string FEE = string.Empty;
            DataTable dtfee = new DataTable();
            _sqlQuery = "SELECT * FROM FEE WHERE INS='" + STAT + "' AND TYPE='REG'";
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dtfee, AllQueryParam);
            if (dtfee.Rows.Count > 0)
            {
                FEE = dtfee.Rows[0]["FEE"].ToString().Trim();
            }
            int MF = 0;
            string SEM = Drpsem.Text;
            string BRC = Drpbranch.SelectedValue.Substring(0, 2).ToString();
            if (BRC == "16" && SEM == "02") { MF = 30; }//2nd Year
            else if (BRC == "07" && SEM == "03") { MF = 30; }//3rd Year
            else if (BRC == "15" && SEM == "04") { MF = 30; }//4th Sem
            else if (BRC == "17" && SEM == "04") { MF = 30; }//4th Sem
            else if (SEM == "06") { MF = 30; }//6th Sem
            else { MF = 20; }
            FEE = (Convert.ToInt32(FEE) + MF).ToString();
            if (Chklatefee.Checked == true) { FEE = (Convert.ToInt32(FEE) + 100).ToString(); }
            //Update Registration

            string FORMSESS = string.Empty;
            string REGSESS = string.Empty;
            //Get From session
            DataTable dtsess = new DataTable();
            _sqlQuery = "select * FROM FORMSESS ORDER BY SESSNAME ASC";
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dtsess, AllQueryParam);
            if (dtsess.Rows.Count > 0)
            {
                FORMSESS = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
                REGSESS = dtsess.Rows[1]["SESSVAL"].ToString().Trim();
            }

            string CLMSESS = string.Empty;
            string CLM1 = string.Empty;
            string CLM2 = string.Empty;
            string CLM3 = string.Empty;
            if (SEM == "01") { CLM1 = "SEM1"; CLM2 = "SEMCOM1"; CLM3 = "SEMFEE1"; CLMSESS = "SEMSESS1"; }
            else if (SEM == "02") { CLM1 = "SEM2"; CLM2 = "SEMCOM2"; CLM3 = "SEMFEE2"; CLMSESS = "SEMSESS2"; }
            else if (SEM == "03") { CLM1 = "SEM3"; CLM2 = "SEMCOM3"; CLM3 = "SEMFEE3"; CLMSESS = "SEMSESS3"; }
            else if (SEM == "04") { CLM1 = "SEM4"; CLM2 = "SEMCOM4"; CLM3 = "SEMFEE4"; CLMSESS = "SEMSESS4"; }
            else if (SEM == "05") { CLM1 = "SEM5"; CLM2 = "SEMCOM5"; CLM3 = "SEMFEE5"; CLMSESS = "SEMSESS5"; }
            else if (SEM == "06") { CLM1 = "SEM6"; CLM2 = "SEMCOM6"; CLM3 = "SEMFEE6"; CLMSESS = "SEMSESS6"; }
            _sqlQuery = "UPDATE REGISTRATION SET " + CLM1 + "='1'," + CLM2 + "='1'," + CLM3 + "='" + FEE + "'," + CLMSESS + "='" + FORMSESS + "',INSCODE='" + Drpnins.SelectedValue + "',INSNAME='" + Drpnins.SelectedItem.ToString() + "',BRCODE='" + Drpnbranch.SelectedValue + "',BRNAME='" + Drpnbranch.SelectedItem.ToString() + "',SEM='" + Drpsem.Text + "',REGPVT='" + Drpregpvt.Text + "' WHERE (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "') AND INSCODE='" + Drpins.SelectedValue + "' AND BRCODE='" + Drpbranch.SelectedValue + "'";
            string result = objbll.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                for (int i = 1; i <= 3; i++)
                {
                    string TBL = string.Empty;
                    if (i == 1) { TBL = "BACKP"; }
                    else if (i == 2) { TBL = "SCRU"; }
                    else if (i == 3) { TBL = "REEVA"; }
                    _sqlQuery = "UPDATE " + TBL + " SET INSCODE='" + Drpnins.SelectedValue + "',INSNAME='" + Drpnins.SelectedItem.ToString() + "',BRCODE='" + Drpnbranch.SelectedValue + "',BRNAME='" + Drpnbranch.SelectedItem.ToString() + "',SEM='" + Drpsem.Text + "',REGPVT='" + Drpregpvt.Text + "',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "')";
                    objbll.ONLYQUERYBLL(_sqlQuery);
                }
                LblMessage.Text = "FORM SUBMITTED SUCCESSFULLY.";
                Btnsubmit.Visible = false;
            }
            else { LblMessage.Text = "FORM SUBMISSION FAILED."; }

        }
        catch (Exception ex)
        { LblMessage.Text = ex.Message; }
    }
}