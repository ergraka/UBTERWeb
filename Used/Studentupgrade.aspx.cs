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
public partial class Studentupgrade : System.Web.UI.Page
{
    public string LNKURL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Error.aspx", false);
            if (Session["INSCODE"] != null && Session["UTYPE"] != null)
            {
                if (!IsPostBack)
                {
                    string BR = Session["BRCODE"].ToString();
                    string BRC = BR.Substring(0, 2).ToString();

                    string SEM = string.Empty;
                    if (Request.QueryString["TYP"] != null)
                    {
                        SEM = Request.QueryString["TYP"].ToString().Trim();
                    }
                    else { Response.Redirect("~/Error.aspx", false); }
                    Griddata(SEM);
                }
            }
            else { Response.Redirect("Inslogin.aspx", false); }
        }
        catch (Exception ex)
        { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Btnapproved_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null && Session["BRCODE"] != null)
            {
                string SEM = string.Empty;
                string BR = Session["BRCODE"].ToString();
                string BRC = BR.Substring(0, 2).ToString();
                if (Request.QueryString["TYP"] != null)
                {
                    SEM = Request.QueryString["TYP"].ToString().Trim();
                }
                else { Response.Redirect("~/Error.aspx", false); }
                if (SEM == "YBACK") { YBACK(SEM); }
                else { Approved(SEM); }
            }
            else { Response.Redirect("Inslogin.aspx"); }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    public void Approved(string SEM)
    {
        int MF = 0;
        string BR = Session["BRCODE"].ToString();
        string BRC = BR.Substring(0, 2).ToString();
        string CLM1 = string.Empty;
        string CLM2 = string.Empty;
        string CLM3 = string.Empty;
        if (SEM == "01") { CLM1 = "SEM1"; CLM2 = "SEMCOM1"; CLM3 = "SEMFEE1"; }
        else if (SEM == "02") { CLM1 = "SEM2"; CLM2 = "SEMCOM2"; CLM3 = "SEMFEE2"; }
        else if (SEM == "03") { CLM1 = "SEM3"; CLM2 = "SEMCOM3"; CLM3 = "SEMFEE3"; }
        else if (SEM == "04") { CLM1 = "SEM4"; CLM2 = "SEMCOM4"; CLM3 = "SEMFEE4"; }
        else if (SEM == "05") { CLM1 = "SEM5"; CLM2 = "SEMCOM5"; CLM3 = "SEMFEE5"; }
        else if (SEM == "06") { CLM1 = "SEM6"; CLM2 = "SEMCOM6"; CLM3 = "SEMFEE6"; }
        string _sqlQuery = string.Empty;
        int count = 0;
        string FEE = string.Empty;
        if (Session["REGCAT"].ToString() == "GOVT") { FEE = "1100"; }
        else { FEE = "1600"; }
        if (BRC == "16" && SEM == "02") { MF = 30; }//2nd Year
        else if (BRC == "07" && SEM == "03") { MF = 30; }//3rd Year
        else if (BRC == "15" && SEM == "04") { MF = 30; }//4th Sem
        else if (BRC == "17" && SEM == "04") { MF = 30; }//4th Sem
        else if (SEM == "06") { MF = 30; }//6th Sem
        else { MF = 20; }
        FEE = (Convert.ToInt32(FEE) + MF).ToString();
        foreach (GridViewRow gvrow in Grdaproved.Rows)
        {
            string SUB = string.Empty;
            CheckBox chk = (CheckBox)gvrow.FindControl("CbSelect");
            if (chk != null & chk.Checked)
            {
                BLL objbllonlyquery = new BLL();
                _sqlQuery = "UPDATE REGISTRATION SET " + CLM1 + "='1'," + CLM2 + "='1'," + CLM3 + "='" + FEE + "',SEM='" + SEM + "',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE ROLL='" + chk.Text + "'";
                string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                if (result == "1-1")
                {
                    count++;
                    for (int i = 1; i <= 3; i++)
                    {
                        string TBL = string.Empty;
                        if (i == 1) { TBL = "BACKP"; }
                        else if (i == 2) { TBL = "SCRU"; }
                        else if (i == 3) { TBL = "REEVA"; }
                        _sqlQuery = "UPDATE " + TBL + " SET SEM='" + SEM + "',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') where ROLL='" + chk.Text + "'";
                        objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                    }
                }
                else { ltrlMessage.Text = "DATA NOT SUBMIT."; return; }
            }
        }
        ltrlMessage.Text = count.ToString() + "-RECORDS APPROVED SUCCESSFULLY.";
        Griddata(SEM);
    }
    public void YBACK(string SEM)
    {
        string BR = Session["BRCODE"].ToString();
        string BRC = BR.Substring(0, 2).ToString();
        string _sqlQuery = string.Empty;
        int count = 0;
        string FEE = string.Empty;
        if (Session["REGCAT"].ToString() == "GOVT") { FEE = "1020"; }
        else { FEE = "1520"; }
        foreach (GridViewRow gvrow in Grdaproved.Rows)
        {
            string SUB = string.Empty;
            CheckBox chk = (CheckBox)gvrow.FindControl("CbSelect");
            if (chk != null & chk.Checked)
            {
                BLL objbllonlyquery = new BLL();
                _sqlQuery = "UPDATE REGISTRATION SET SEM='01',SEM1='1',SEMCOM1='1',SEMFEE1='" + FEE + "',SEM2=NULL,SEMCOM2=NULL,SEMFEE2=NULL,REGPVT='R',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE ROLL='" + chk.Text + "'";
                string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                if (result == "1-1")
                {
                    count++;
                    for (int i = 1; i <= 3; i++)
                    {
                        string TBL = string.Empty;
                        if (i == 1) { TBL = "BACKP"; }
                        else if (i == 2) { TBL = "SCRU"; }
                        else if (i == 3) { TBL = "REEVA"; }
                        _sqlQuery = "DELETE FROM " + TBL + " where ROLL='" + chk.Text + "'";
                        objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                    }
                }
                else { ltrlMessage.Text = "DATA NOT SUBMIT."; return; }
            }
        }
        ltrlMessage.Text = count.ToString() + "-RECORDS APPROVED SUCCESSFULLY.";
        Griddata(SEM);
    }
    public void Griddata(string SEM)
    {

        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        string CLM1 = string.Empty;
        string CLM2 = string.Empty;
        if (SEM == "01") { CLM1 = "SEM1"; CLM2 = "SEMCOM1"; }
        else if (SEM == "02") { CLM1 = "SEM2"; CLM2 = "SEMCOM2"; }
        else if (SEM == "03") { CLM1 = "SEM3"; CLM2 = "SEMCOM3"; }
        else if (SEM == "04") { CLM1 = "SEM4"; CLM2 = "SEMCOM4"; }
        else if (SEM == "05") { CLM1 = "SEM5"; CLM2 = "SEMCOM5"; }
        else if (SEM == "06") { CLM1 = "SEM6"; CLM2 = "SEMCOM6"; }
        if (Session["INSCODE"] != null && Session["BRCODE"] != null)
        {
            string[] spl1 = Session["INSCODE"].ToString().Split('|');
            string inscode = spl1[0].ToString();
            string[] spl2 = Session["BRCODE"].ToString().Split('|');
            string brcode = spl2[0].ToString();

            if (SEM == "YBACK")
            { _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND BRCODE='" + brcode + "' AND (SEM='02' OR SEM='03' AND REGPVT='P') AND INSCODE='" + inscode + "' order by ROLL asc"; }
            else
            {
                string SM = (Convert.ToInt32(SEM) - 1).ToString();
                _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND REGPVT='R' AND BRCODE='" + brcode + "' AND SEM='0" + SM + "' and SEMCOM" + SM + "='1' and INSCODE='" + inscode + "' AND " + CLM1 + " IS NULL AND " + CLM2 + " IS NULL order by ROLL asc";
            }
            AllQueryParamreg[0] = _sqlQueryreg;
            BLL objbllreg = new BLL();
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            DataTable dtdata = ROWS();
            DataRow dr = dtdata.NewRow();
            for (int i = 0; i < dtreg.Rows.Count; i++)
            {
                string REMARK = string.Empty;
                string CNAME = dtreg.Rows[i]["CNAME"].ToString();
                string ROLL = dtreg.Rows[i]["ROLL"].ToString();
                REMARK = "Ready for new sem/year.";
                dr["CNAME"] = CNAME;
                dr["ROLL"] = ROLL;
                dr["SEM"] = SEM;
                dr["REMARK"] = REMARK;
                dtdata.Rows.Add(dr);
                dr = dtdata.NewRow();
            }
            Grdaproved.DataSource = dtdata;
            Grdaproved.DataBind();
            if (Grdaproved.Rows.Count == 0) { ltrlMessage.Text = "No Records Found !"; }
        }
    }
    protected void Chkall_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["BRCODE"] != null)
            {
                if (Chkall.Checked == true)
                {
                    foreach (GridViewRow gvrow in Grdaproved.Rows)
                    {
                        CheckBox chk = (CheckBox)gvrow.FindControl("CbSelect");
                        chk.Checked = true;
                    }    
                }
                else
                {
                    foreach (GridViewRow gvrow in Grdaproved.Rows)
                    {
                        CheckBox chk = (CheckBox)gvrow.FindControl("CbSelect");
                        chk.Checked = false;
                    }
                }
            }
            else { Response.Redirect("Inslogin.aspx", false); }
        }
        catch (Exception ex) { ltrlMessage.Text = "Server Busy, Please try after some time !"; }
    }
    private DataTable ROWS()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("CNAME");
        dt.Columns.Add("ROLL");
        dt.Columns.Add("SEM");
        dt.Columns.Add("REMARK");
        return dt;
    }
}