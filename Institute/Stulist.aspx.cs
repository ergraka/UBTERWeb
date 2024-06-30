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
public partial class Stulist : System.Web.UI.Page
{
    public string LNKURL = string.Empty;
    public string TYPENAME = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null && Session["UTYPE"] != null)
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["TYP"] != null)
                    {
                        string[] SPL = Request.QueryString["TYP"].ToString().Trim().Split('|');
                        string TYPEVAL = SPL[0].ToString();
                        string SEM = SPL[1].ToString();
                        Griddata(Session["UTYPE"].ToString(), TYPEVAL, SEM);
                    }
                    else { Response.Redirect("~/Error.aspx", false); }
                }
            }
            else { Response.Redirect("Inslogin.aspx", false); }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void Btnapproved_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null && Session["BRCODE"] != null)
            {
                string[] SPL = Request.QueryString["TYP"].ToString().Trim().Split('|');
                string TYPEVAL = SPL[0].ToString();
                string SEM = SPL[1].ToString();
                Approved(TYPEVAL, SEM);

            }
            else { Response.Redirect("Inslogin.aspx"); }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    public void Approved(string TYPEVAL, string SEM)
    {

        string _sqlQueryreg = string.Empty;
        string[] AllQueryParamreg = new string[1];
        BLL objbllreg = new BLL();
        //Get From session
        string FORMSESS = string.Empty;
        DataTable dtsess = new DataTable();
        _sqlQueryreg = "select * FROM FORMSESS WHERE SESSNAME='FORM'";
        AllQueryParamreg[0] = _sqlQueryreg;
        objbllreg.QUERYBLL(ref dtsess, AllQueryParamreg);
        if (dtsess.Rows.Count > 0)
        {
            FORMSESS = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
        }

        string CLMSESS = string.Empty;
        string CLMCOM = string.Empty;
        string CLMSEMFEE = string.Empty;
        if (SEM == "01") { CLMSESS = "SEMSESS1"; CLMCOM = "SEMCOM1"; CLMSEMFEE = "SEMFEE1"; }
        else if (SEM == "02") { CLMSESS = "SEMSESS2"; CLMCOM = "SEMCOM2"; CLMSEMFEE = "SEMFEE2"; }
        else if (SEM == "03") { CLMSESS = "SEMSESS3"; CLMCOM = "SEMCOM3"; CLMSEMFEE = "SEMFEE3"; }
        else if (SEM == "04") { CLMSESS = "SEMSESS4"; CLMCOM = "SEMCOM4"; CLMSEMFEE = "SEMFEE4"; }
        else if (SEM == "05") { CLMSESS = "SEMSESS5"; CLMCOM = "SEMCOM5"; CLMSEMFEE = "SEMFEE5"; }
        else if (SEM == "06") { CLMSESS = "SEMSESS6"; CLMCOM = "SEMCOM6"; CLMSEMFEE = "SEMFEE6"; }
        else if (SEM == "P"|| SEM == "Q") { CLMSESS = "SPLSESS"; CLMCOM = "SPLCOM"; }
      
        string _sqlQuery = string.Empty;
        int count = 0;
        foreach (GridViewRow gvrow in Grdaproved.Rows)
        {
            string SEMFEE = string.Empty;
            if (Session["REGCAT"].ToString() == "GOVT") { SEMFEE = "1000"; }
            else if (Session["REGCAT"].ToString() == "PVT") { SEMFEE = "1500"; }

            CheckBox chk = (CheckBox)gvrow.FindControl("CbSelect");
            if (chk != null & chk.Checked)
            {

                string BR = Session["BRCODE"].ToString();
                string BRC = BR.Substring(0, 2).ToString();
                int MF = 0;
                string PQ = string.Empty;
                BLL objbllonlyquery = new BLL();
                if (SEM == "P")
                {
                   
                    string SM = string.Empty;
                   

                    DataTable dtreg = new DataTable();

                    _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE CANDIDATEID='" + chk.Text + "'";
                    AllQueryParamreg[0] = _sqlQueryreg;
                    objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                    if (dtreg.Rows.Count > 0)
                    {
                        SM = dtreg.Rows[0]["SEM"].ToString();
                    }
                    string SPLFEE = "500";
                    if (BRC == "16" && SM == "02") { MF = 30; }//2nd Year
                    else if (BRC == "07" && SM == "03") { MF = 30; }//3rd Year
                    else if (BRC == "15" && SM == "04") { MF = 30; }//4th Sem
                    else if (BRC == "17" && SM == "04") { MF = 30; }//4th Sem
                    else if (SM == "06") { MF = 30; }//6th Sem
                    else { MF = 20; SPLFEE = "0"; }
                    SPLFEE = (Convert.ToInt32(SPLFEE) + MF).ToString();
                    SEMFEE = (Convert.ToInt32(SEMFEE) + MF).ToString();

                    if (TYPEVAL == "ANAPP") { _sqlQuery = "UPDATE REGISTRATION SET " + CLMCOM + "='1'," + CLMSEMFEE + "='" + SEMFEE + "'," + CLMSESS + "='"+ FORMSESS+"',SPLFEE ='" + SPLFEE + "',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30'),REGPVT='P' WHERE CANDIDATEID='" + chk.Text + "'"; PQ = "P"; }//APPROVED ALL
                    else if (TYPEVAL == "AAPP") { _sqlQuery = "UPDATE REGISTRATION SET " + CLMCOM + "=NULL," + CLMSEMFEE + "=NULL," + CLMSESS + "=NULL,SPLFEE=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; PQ = "R"; }//DISAPPROVED ALL
                    else if (TYPEVAL == "SNAPP") { _sqlQuery = "UPDATE SCRU SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED SCRUTINY
                    else if (TYPEVAL == "SAPP") { _sqlQuery = "UPDATE SCRU SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED SCRUTINY
                    else if (TYPEVAL == "RNAPP") { _sqlQuery = "UPDATE REEVA SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED RE_EVALUATION
                    else if (TYPEVAL == "RAPP") { _sqlQuery = "UPDATE REEVA SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED RE_EVALUATION
                    else if (TYPEVAL == "BNAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED BACKPAPER
                    else if (TYPEVAL == "BAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED BACK PAPER
                    else if (TYPEVAL == "SBNAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED SPECIAL BACKPAPER
                    else if (TYPEVAL == "SBAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED SPECIAL BACK PAPER
                    else { Response.Redirect("~/Error.aspx", false); }
                }
                else if (SEM == "Q")
                {
                    if (TYPEVAL == "ANAPP") { _sqlQuery = "UPDATE REGISTRATION SET REGPVT='Q',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; PQ = "Q"; }//APPROVED ALL
                    else if (TYPEVAL == "AAPP") { _sqlQuery = "UPDATE REGISTRATION SET REGPVT='R',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; PQ = "R"; }//DISAPPROVED ALL
                    else if (TYPEVAL == "SNAPP") { _sqlQuery = "UPDATE SCRU SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED SCRUTINY
                    else if (TYPEVAL == "SAPP") { _sqlQuery = "UPDATE SCRU SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED SCRUTINY
                    else if (TYPEVAL == "RNAPP") { _sqlQuery = "UPDATE REEVA SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED RE_EVALUATION
                    else if (TYPEVAL == "RAPP") { _sqlQuery = "UPDATE REEVA SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED RE_EVALUATION
                    else if (TYPEVAL == "BNAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED BACKPAPER
                    else if (TYPEVAL == "BAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED BACK PAPER
                    else if (TYPEVAL == "SBNAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED SPECIAL BACKPAPER
                    else if (TYPEVAL == "SBAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED SPECIAL BACK PAPER
                    else { Response.Redirect("~/Error.aspx", false); }
                }
                else
                {
                    if (BRC == "16" && SEM == "02") { MF = 30; }//2nd Year
                    else if (BRC == "07" && SEM == "03") { MF = 30; }//3rd Year
                    else if (BRC == "15" && SEM == "04") { MF = 30; }//4th Sem
                    else if (BRC == "17" && SEM == "04") { MF = 30; }//4th Sem
                    else if (SEM == "06") { MF = 30; }//6th Sem
                    else { MF = 20; }
                    SEMFEE = (Convert.ToInt32(SEMFEE) + MF).ToString();
                    if (TYPEVAL == "ANAPP") { _sqlQuery = "UPDATE REGISTRATION SET " + CLMCOM + "='1'," + CLMSEMFEE + "='" + SEMFEE + "'," + CLMSESS + "='" + FORMSESS + "',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED ALL
                    else if (TYPEVAL == "AAPP") { _sqlQuery = "UPDATE REGISTRATION SET " + CLMCOM + "=NULL," + CLMSEMFEE + "=NULL," + CLMSESS + "=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED ALL
                    else if (TYPEVAL == "SNAPP") { _sqlQuery = "UPDATE SCRU SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED SCRUTINY
                    else if (TYPEVAL == "SAPP") { _sqlQuery = "UPDATE SCRU SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED SCRUTINY
                    else if (TYPEVAL == "RNAPP") { _sqlQuery = "UPDATE REEVA SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED RE_EVALUATION
                    else if (TYPEVAL == "RAPP") { _sqlQuery = "UPDATE REEVA SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED RE_EVALUATION
                    else if (TYPEVAL == "BNAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED BACKPAPER
                    else if (TYPEVAL == "BAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED BACK PAPER
                    else if (TYPEVAL == "SBNAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED='1',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//APPROVED SPECIAL BACKPAPER
                    else if (TYPEVAL == "SBAPP") { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; }//DISAPPROVED SPECIAL BACK PAPER
                    else { Response.Redirect("~/Error.aspx", false); }
                }
                string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                if (result == "1-1") { count++; }

                //Update Other Tables
                if ((SEM == "P" || SEM == "Q") && (TYPEVAL == "ANAPP" || TYPEVAL == "AAPP"))
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        string TBL = string.Empty;
                        if (i == 1) { TBL = "BACKP"; }
                        else if (i == 2) { TBL = "SCRU"; }
                        else if (i == 3) { TBL = "REEVA"; }
                        _sqlQuery = "UPDATE " + TBL + " SET REGPVT='" + PQ + "',UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') where CANDIDATEID='" + chk.Text + "'";
                        objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                    }
                }
            }
        }
        ltrlMessage.Text = count.ToString() + "-RECORDS UPDATED SUCCESSFULLY.";
        Griddata(Session["UTYPE"].ToString(), TYPEVAL, SEM);
    }
    protected void Grddata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (IsPostBack)
            {
                if (Session["UTYPE"] != null)
                {
                    ltrlMessage.Text = "";
                    Grddata.PageIndex = e.NewPageIndex;
                    string[] SPL = Request.QueryString["TYP"].ToString().Trim().Split('|');
                    string TYPEVAL = SPL[0].ToString();
                    string SEM = SPL[1].ToString();
                    Griddata(Session["UTYPE"].ToString(), TYPEVAL, SEM);
                }
                else { Response.Redirect("Inslogin.aspx", false); }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Server Busy, Please try after some time !"; }
    }
    public void Griddata(string TYPE, string TYPEVAL, string SEM)
    {
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        BLL objbllreg = new BLL();


        //Get From session
        string FORMSESS = string.Empty;
        DataTable dtsess = new DataTable();
        _sqlQueryreg = "select * FROM FORMSESS WHERE SESSNAME='FORM'";
        AllQueryParamreg[0] = _sqlQueryreg;
        objbllreg.QUERYBLL(ref dtsess, AllQueryParamreg);
        if (dtsess.Rows.Count > 0)
        {
            FORMSESS = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
        }

        string CLMSESS = string.Empty;
        string CLMCOM = string.Empty;
        string CLMSEMFEE = string.Empty;
        if (SEM == "01") { CLMSESS = "SEMSESS1"; CLMCOM = "SEMCOM1"; CLMSEMFEE = "SEMFEE1"; }
        else if (SEM == "02") { CLMSESS = "SEMSESS2"; CLMCOM = "SEMCOM2"; CLMSEMFEE = "SEMFEE2"; }
        else if (SEM == "03") { CLMSESS = "SEMSESS3"; CLMCOM = "SEMCOM3"; CLMSEMFEE = "SEMFEE3"; }
        else if (SEM == "04") { CLMSESS = "SEMSESS4"; CLMCOM = "SEMCOM4"; CLMSEMFEE = "SEMFEE4"; }
        else if (SEM == "05") { CLMSESS = "SEMSESS5"; CLMCOM = "SEMCOM5"; CLMSEMFEE = "SEMFEE5"; }
        else if (SEM == "06") { CLMSESS = "SEMSESS6"; CLMCOM = "SEMCOM6"; CLMSEMFEE = "SEMFEE6"; }
        else if (SEM == "P" || SEM == "Q") { CLMSESS = "SPLSESS"; CLMCOM = "SPLCOM"; }

        if (TYPE == "I")
        {
            if (Session["INSCODE"] != null)
            {
                string[] spl1 = Session["INSCODE"].ToString().Split('|');
                string inscode = spl1[0].ToString();
                if (TYPEVAL == "ALL") { LNKURL = "~/Report/View.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND INSCODE='" + inscode + "' order by BRCODE,SEM,CNAME asc"; }
                else if (TYPEVAL == "APP") { LNKURL = "~/Report/View.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND SEMCOM1='1' and  INSCODE='" + inscode + "' order by BRCODE,SEM,CNAME asc"; }
                else if (TYPEVAL == "NAPP") { LNKURL = "~/Report/View.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND SEMCOM1 is NULL and INSCODE='" + inscode + "' order by BRCODE,SEM,CNAME asc"; }
                else { Response.Redirect("~/Error.aspx", false); }
            }
            else { Response.Redirect("Inslogin.aspx", false); }
        }
        else if (TYPE == "B")
        {
            if (Session["INSCODE"] != null && Session["BRCODE"] != null)
            {
                string[] spl1 = Session["INSCODE"].ToString().Split('|');
                string inscode = spl1[0].ToString();
                string[] spl2 = Session["BRCODE"].ToString().Split('|');
                string brcode = spl2[0].ToString();
                string SEMYEAR = string.Empty;
                if (brcode.Substring(0, 2) == "16" || brcode.Substring(0, 2) == "07") { SEMYEAR = "YEAR"; }
                else { SEMYEAR = "SEMESTER"; }
                if (SEM == "P")
                {
                    if (TYPEVAL == "AALL") { TYPENAME = "ALL REGISTERED PRIVATE STUDENT LIST"; LNKURL = "~/Report/View.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='P' order by CNAME asc"; }
                    else if (TYPEVAL == "AAPP") { TYPENAME = "ALL REGISTERED PRIVATE STUDENT LIST"; LNKURL = "~/Report/View.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and  INSCODE='" + inscode + "' AND REGPVT='P' order by CNAME asc"; }
                    else if (TYPEVAL == "ANAPP")
                    {
                        TYPENAME = "ALL REGISTERED PRIVATE STUDENT LIST";
                        LNKURL = "~/Report/View.aspx?AAAAA=";
                        _sqlQueryreg = "select * from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='R' order by CNAME asc";
                    }
                    else if (TYPEVAL == "SALL") { TYPENAME = "ALL SCRUTINY FORM REGISTERED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptscrutiny.aspx?AAAAA="; _sqlQueryreg = "select * from SCRU where BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='P' order by ROLL asc"; }
                    else if (TYPEVAL == "SAPP") { TYPENAME = "ALL SCRUTINY FORM APPROVED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptscrutiny.aspx?AAAAA="; _sqlQueryreg = "select * from SCRU where ISCOMPLETED='1' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='P' order by ROLL asc"; }
                    else if (TYPEVAL == "SNAPP") { TYPENAME = "ALL SCRUTINY FORM NOT-APPROVED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptscrutiny.aspx?AAAAA="; _sqlQueryreg = "select * from SCRU where ISCOMPLETED IS NULL AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='P' order by ROLL asc"; }
                    else if (TYPEVAL == "RALL") { TYPENAME = "ALL RE-EVALUATION FORM REGISTERED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptreeva.aspx?AAAAA="; _sqlQueryreg = "select * from REEVA where BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='P' order by ROLL asc"; }
                    else if (TYPEVAL == "RAPP") { TYPENAME = "ALL RE-EVALUATION FORM APPROVED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptreeva.aspx?AAAAA="; _sqlQueryreg = "select * from REEVA where ISCOMPLETED='1' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='P' order by ROLL asc"; }
                    else if (TYPEVAL == "RNAPP") { TYPENAME = "ALL RE-EVALUATION FORM NOT-APPROVED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptreeva.aspx?AAAAA="; _sqlQueryreg = "select * from REEVA where ISCOMPLETED IS NULL AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='P' order by ROLL asc"; }
                    else if (TYPEVAL == "BALL") { TYPENAME = "ALL BACK PAPER FORM REGISTERED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='P' AND TYPE='B' order by ROLL asc"; }
                    else if (TYPEVAL == "BAPP") { TYPENAME = "ALL BACK PAPER FORM APPROVED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED='1' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND TYPE='B' AND REGPVT='P' order by ROLL asc"; }
                    else if (TYPEVAL == "BNAPP") { TYPENAME = "ALL BACK PAPER FORM NOT-APPROVED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED IS NULL AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND TYPE='B' AND REGPVT='P' order by ROLL asc"; }
                    else if (TYPEVAL == "SBALL") { TYPENAME = "ALL SPECIAL BACK PAPER FORM REGISTERED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptsbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='P' AND TYPE='S' order by ROLL asc"; }
                    else if (TYPEVAL == "SBAPP") { TYPENAME = "ALL SPECIAL BACK PAPER FORM APPROVED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptsbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED='1' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND TYPE='S' AND REGPVT='P' order by ROLL asc"; }
                    else if (TYPEVAL == "SBNAPP") { TYPENAME = "ALL SPECIAL BACK PAPER FORM NOT-APPROVED PRIVATE STUDENT LIST"; LNKURL = "~/Report/Receiptsbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED IS NULL AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND TYPE='S' AND REGPVT='P' order by ROLL asc"; }
                    else if (TYPEVAL == "ADM") { TYPENAME = "ALL PRIVATE STUDENT LIST FOR DOWNLOAD ADMIT CARD"; LNKURL = "~/Report/Admitcard.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='P' AND ROLL IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "') order by ROLL asc"; }
                    else if (TYPEVAL == "VER") { TYPENAME = "ALL PRIVATE STUDENT LIST FOR DOWNLOAD VERIFICATION"; LNKURL = "~/Report/Verification.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='P' AND ROLL IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "') order by ROLL asc"; }
                    else if (TYPEVAL == "SADM") { TYPENAME = "ALL PRIVATE STUDENT LIST FOR SPECIAL BACK PAPER : DOWNLOAD ADMIT CARD"; LNKURL = "~/Report/Admitcard.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='P' AND ROLL IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='S' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "') order by ROLL asc"; }
                    else if (TYPEVAL == "SVER") { TYPENAME = "ALL PRIVATE STUDENT LIST FOR SPECIAL BACK PAPER : DOWNLOAD VERIFICATION"; LNKURL = "~/Report/Verification.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='P' AND ROLL IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='S' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "') order by ROLL asc"; }
                    else if (TYPEVAL == "MRK")
                    {
                        TYPENAME = "ALL PRIVATE STUDENT LIST FOR VIEW/DOWNLOAD MARKS SHEET";
                        if (brcode.Substring(0, 2) == "16") { LNKURL = "~/Report/Marksheet.aspx?AAAAA=MRK|"; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='P' order by ROLL asc"; }
                        else { LNKURL = "~/Report/Marksheet.aspx?AAAAA=MRK|"; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='P' order by ROLL asc"; }
                    }
                    else { Response.Redirect("~/Error.aspx", false); }
                }
                else if (SEM == "Q")
                {
                    if (TYPEVAL == "AALL") { TYPENAME = "ALL REGISTERED PASSED STUDENT LIST"; LNKURL = "~/Report/View.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='Q' order by CNAME asc"; }
                    else if (TYPEVAL == "AAPP") { TYPENAME = "ALL REGISTERED PASSED STUDENT LIST"; LNKURL = "~/Report/View.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and  INSCODE='" + inscode + "' AND REGPVT='Q' order by CNAME asc"; }
                    else if (TYPEVAL == "ANAPP")
                    {
                        TYPENAME = "ALL PASSED STUDENT LIST";
                        LNKURL = "~/Report/View.aspx?AAAAA=";
                        if (brcode.Substring(0, 2) == "16")
                        {
                            _sqlQueryreg = "select * from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='02' order by STRTSESS,CNAME asc";
                        }
                        else if (brcode.Substring(0, 2) == "07")
                        {
                            _sqlQueryreg = "select * from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='03' order by STRTSESS,CNAME asc";
                        }
                        else if (brcode.Substring(0, 2) == "15" || brcode.Substring(0, 2) == "17")
                        {
                            _sqlQueryreg = "select * from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='04' order by STRTSESS,CNAME asc";
                        }
                        else
                        {
                            _sqlQueryreg = "select * from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='06' order by STRTSESS,CNAME asc";
                        }
                    }
                    else if (TYPEVAL == "SALL") { TYPENAME = "ALL SCRUTINY FORM REGISTERED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptscrutiny.aspx?AAAAA="; _sqlQueryreg = "select * from SCRU where BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "SAPP") { TYPENAME = "ALL SCRUTINY FORM APPROVED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptscrutiny.aspx?AAAAA="; _sqlQueryreg = "select * from SCRU where ISCOMPLETED='1' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "SNAPP") { TYPENAME = "ALL SCRUTINY FORM NOT-APPROVED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptscrutiny.aspx?AAAAA="; _sqlQueryreg = "select * from SCRU where ISCOMPLETED IS NULL AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "RALL") { TYPENAME = "ALL RE-EVALUATION FORM REGISTERED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptreeva.aspx?AAAAA="; _sqlQueryreg = "select * from REEVA where BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "RAPP") { TYPENAME = "ALL RE-EVALUATION FORM APPROVED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptreeva.aspx?AAAAA="; _sqlQueryreg = "select * from REEVA where ISCOMPLETED='1' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "RNAPP") { TYPENAME = "ALL RE-EVALUATION FORM NOT-APPROVED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptreeva.aspx?AAAAA="; _sqlQueryreg = "select * from REEVA where ISCOMPLETED IS NULL AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "BALL") { TYPENAME = "ALL BACK PAPER FORM REGISTERED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where BRCODE='" + brcode + "' AND TYPE='B' and INSCODE='" + inscode + "' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "BAPP") { TYPENAME = "ALL BACK PAPER FORM APPROVED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED='1' AND BRCODE='" + brcode + "' AND TYPE='B' and INSCODE='" + inscode + "' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "BNAPP") { TYPENAME = "ALL BACK PAPER FORM NOT-APPROVED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED IS NULL AND BRCODE='" + brcode + "' AND TYPE='B' and INSCODE='" + inscode + "' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "SBALL") { TYPENAME = "ALL SPECIAL BACK PAPER FORM REGISTERED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptsbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND TYPE='S' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "SBAPP") { TYPENAME = "ALL SPECIAL BACK PAPER FORM APPROVED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptsbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED='1' AND BRCODE='" + brcode + "' AND TYPE='S' and INSCODE='" + inscode + "' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "SBNAPP") { TYPENAME = "ALL SPECIAL BACK PAPER FORM NOT-APPROVED PASSED STUDENT LIST"; LNKURL = "~/Report/Receiptsbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED IS NULL AND BRCODE='" + brcode + "' AND TYPE='S' and INSCODE='" + inscode + "' AND REGPVT='Q' order by ROLL asc"; }
                    else if (TYPEVAL == "ADM") { TYPENAME = "ALL PASSED STUDENT LIST FOR VIEW/DOWNLOAD ADMIT CARD"; LNKURL = "~/Report/Admitcard.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='Q' AND ROLL IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "') order by ROLL asc"; }
                    else if (TYPEVAL == "VER") { TYPENAME = "ALL PASSED STUDENT LIST FOR DOWNLOAD VERIFICATION"; LNKURL = "~/Report/Verification.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='Q' AND ROLL IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "') order by ROLL asc"; }
                    else if (TYPEVAL == "SADM") { TYPENAME = "ALL PASSED STUDENT LIST FOR SPECIAL BACK PAPER : DOWNLOAD ADMIT CARD"; LNKURL = "~/Report/Admitcard.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='Q' AND ROLL IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='S' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "') order by ROLL asc"; }
                    else if (TYPEVAL == "SVER") { TYPENAME = "ALL PASSED STUDENT LIST FOR SPECIAL BACK PAPER : DOWNLOAD VERIFICATION"; LNKURL = "~/Report/Verification.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='Q' AND ROLL IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='S' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "') order by ROLL asc"; }
                    else if (TYPEVAL == "MRK")
                    {
                        TYPENAME = "ALL PASSED STUDENT LIST FOR VIEW/DOWNLOAD MARKS SHEET";
                        if (brcode.Substring(0, 2) == "16") { LNKURL = "~/Report/Marksheet.aspx?AAAAA=MRK|"; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='Q' order by ROLL asc"; }
                        else { LNKURL = "~/Report/Marksheet.aspx?AAAAA=MRK|"; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='Q' order by ROLL asc"; }
                    }
                    else { Response.Redirect("~/Error.aspx", false); }
                }
                else
                {
                    if (TYPEVAL == "AALL") { TYPENAME = "ALL REGISTERED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/View.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by CNAME asc"; }
                    else if (TYPEVAL == "AAPP") { TYPENAME = "ALL APPROVED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/View.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND " + CLMCOM + "='1' and BRCODE='" + brcode + "' and  INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by CNAME asc"; }
                    else if (TYPEVAL == "ANAPP") { TYPENAME = "ALL NOT-APPROVED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/View.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND " + CLMCOM + " is NULL and BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by CANDIDATEID asc"; }
                    else if (TYPEVAL == "SALL") { TYPENAME = "ALL SCRUTINY FORM REGISTERED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/Receiptscrutiny.aspx?AAAAA="; _sqlQueryreg = "select * from SCRU where BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "SAPP") { TYPENAME = "ALL SCRUTINY FORM APPROVED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/Receiptscrutiny.aspx?AAAAA="; _sqlQueryreg = "select * from SCRU where ISCOMPLETED='1' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "SNAPP") { TYPENAME = "ALL SCRUTINY FORM NOT-APPROVED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/Receiptscrutiny.aspx?AAAAA="; _sqlQueryreg = "select * from SCRU where ISCOMPLETED IS NULL AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "RALL") { TYPENAME = "ALL RE-EVALUATION FORM REGISTERED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/Receiptreeva.aspx?AAAAA="; _sqlQueryreg = "select * from REEVA where BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "RAPP") { TYPENAME = "ALL RE-EVALUATION FORM APPROVED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/Receiptreeva.aspx?AAAAA="; _sqlQueryreg = "select * from REEVA where ISCOMPLETED='1' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "RNAPP") { TYPENAME = "ALL RE-EVALUATION FORM NOT-APPROVED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/Receiptreeva.aspx?AAAAA="; _sqlQueryreg = "select * from REEVA where ISCOMPLETED IS NULL AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "BALL") { TYPENAME = "ALL BACK PAPER FORM REGISTERED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/Receiptbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where BRCODE='" + brcode + "' AND TYPE='B' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "BAPP") { TYPENAME = "ALL BACK PAPER FORM APPROVED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/Receiptbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED='1' AND BRCODE='" + brcode + "' AND TYPE='B' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "BNAPP") { TYPENAME = "ALL BACK PAPER FORM NOT-APPROVED " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST"; LNKURL = "~/Report/Receiptbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED IS NULL AND BRCODE='" + brcode + "' AND TYPE='B' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "SBALL") { TYPENAME = "ALL SPECIAL BACK PAPER FORM REGISTERED STUDENT LIST"; LNKURL = "~/Report/Receiptsbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where BRCODE='" + brcode + "' AND TYPE='S' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "SBAPP") { TYPENAME = "ALL SPECIAL BACK PAPER FORM APPROVED STUDENT LIST"; LNKURL = "~/Report/Receiptsbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED='1' AND TYPE='S' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "SBNAPP") { TYPENAME = "ALL SPECIAL BACK PAPER FORM NOT-APPROVED STUDENT LIST"; LNKURL = "~/Report/Receiptsbackpaper.aspx?AAAAA="; _sqlQueryreg = "select * from BACKP where ISCOMPLETED IS NULL AND TYPE='S' AND BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "ADM") { TYPENAME = "ALL " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST FOR DOWNLOAD ADMIT CARD"; LNKURL = "~/Report/Admitcard.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND " + CLMCOM + "='1' AND " + CLMSESS + "='" + FORMSESS + "' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "VER") { TYPENAME = "ALL " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST FOR DOWNLOAD VERIFICATION"; LNKURL = "~/Report/Verification.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND " + CLMCOM + "='1' AND " + CLMSESS + "='" + FORMSESS + "' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                    else if (TYPEVAL == "SADM") { TYPENAME = "ALL " + SEMYEAR + " " + SEM + " SPECIAL BACK PAPER STUDENT LIST FOR DOWNLOAD ADMIT CARD"; LNKURL = "~/Report/Admitcard.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='R' AND ROLL IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='S' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "') order by ROLL asc"; }
                    else if (TYPEVAL == "SVER") { TYPENAME = "ALL " + SEMYEAR + " " + SEM + " SPECIAL BACK PAPER STUDENT LIST FOR DOWNLOAD VERIFICATION"; LNKURL = "~/Report/Verification.aspx?AAAAA="; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND REGPVT='R' AND ROLL IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='S' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "') order by ROLL asc"; }
                    else if (TYPEVAL == "MRK")
                    {
                        TYPENAME = "ALL " + SEMYEAR + " " + SEM + " REGULAR STUDENT LIST FOR VIEW/DOWNLOAD MARKS SHEET";
                        if (brcode.Substring(0, 2) == "16") { LNKURL = "~/Report/Marksheet.aspx?AAAAA=MRK|"; _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }
                        else { LNKURL = "~/Report/Marksheet.aspx?AAAAA=MRK|"; _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL asc"; }

                    }
                    else if (TYPEVAL == "BACK")
                    {
                        TYPENAME = "ALL STUDENT LIST FOR FILLING BACK PAPER FORM";
                        LNKURL = "~/Institute/Backpaper.aspx?AAAAA=BACK|";
                        _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND ROLL NOT IN(SELECT ROLL FROM BACKP) AND ROLL IS NOT NULL order by SEM asc,ROLL ASC";
                    }
                    else if (TYPEVAL == "SBACK")
                    {
                        TYPENAME = "ALL STUDENT LIST FOR FILLING SPECIAL BACK PAPER";
                        LNKURL = "~/Institute/Backpaper.aspx?AAAAA=SBACK|";
                        if (brcode.Substring(0, 2) == "16") { _sqlQueryreg = "select * FROM REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND ROLL NOT IN(SELECT ROLL FROM BACKP WHERE TYPE='S') ORDER BY ROLL ASC"; }
                        else if (brcode.Substring(0, 2) == "07") { _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND ROLL NOT IN(SELECT ROLL FROM BACKP WHERE TYPE='S') AND SEM='03' ORDER BY ROLL ASC"; }
                        else if (brcode.Substring(0, 2) == "15") { _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND ROLL NOT IN(SELECT ROLL FROM BACKP WHERE TYPE='S') AND SEM='04' ORDER BY ROLL ASC"; }
                        else if (brcode.Substring(0, 2) == "17") { _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND ROLL NOT IN(SELECT ROLL FROM BACKP WHERE TYPE='S') AND SEM='04' ORDER BY ROLL ASC"; }
                        else { _sqlQueryreg = "select * from REGISTRATION where STAT='A' and INSCODE='" + inscode + "' AND BRCODE='" + brcode + "' AND ROLL NOT IN(SELECT ROLL FROM BACKP WHERE TYPE='S') AND SEM='06' ORDER BY ROLL ASC"; }
                    }
                    else { Response.Redirect("~/Error.aspx", false); }
                }
            }
            else { Response.Redirect("Inslogin.aspx", false); }
        }
        if (TYPEVAL == "ANAPP" || TYPEVAL == "SNAPP" || TYPEVAL == "RNAPP" || TYPEVAL == "BNAPP" || TYPEVAL == "SBNAPP")//NOT APPROVED STUDENTS
        {
            AllQueryParamreg[0] = _sqlQueryreg;
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            DataTable dtdata = ROWS();
            DataRow dr = dtdata.NewRow();
            for (int i = 0; i < dtreg.Rows.Count; i++)
            {
                dr["CNAME"] = dtreg.Rows[i]["CNAME"].ToString().Trim();
                dr["LNKURL"] = LNKURL + dtreg.Rows[i]["CANDIDATEID"].ToString().Trim();
                dr["ROLL"] = dtreg.Rows[i]["ROLL"].ToString().Trim();
                dr["CANDIDATEID"] = dtreg.Rows[i]["CANDIDATEID"].ToString().Trim();
                dr["FNAME"] = dtreg.Rows[i]["FNAME"].ToString().Trim();
                dr["BRCODE"] = dtreg.Rows[i]["BRCODE"].ToString().Trim();
                dr["SEM"] = dtreg.Rows[i]["SEM"].ToString().Trim();
                dr["DOB"] = dtreg.Rows[i]["DOB"].ToString().Trim();
                dtdata.Rows.Add(dr);
                dr = dtdata.NewRow();
            }
            Grdaproved.DataSource = dtdata;
            Grdaproved.DataBind();
            if (Grdaproved.Rows.Count == 0) { ltrlMessage.Text = "No Records Found !"; }
            else { Grdaproved.Visible = true; }
            Grddata.Visible = false;
            Btnapproved.Visible = true;
            Chkall.Visible = true;
        }
        else if (TYPEVAL == "AAPP" || TYPEVAL == "SAPP" || TYPEVAL == "RAPP" || TYPEVAL == "BAPP" || TYPEVAL == "SBAPP")//ALL APPROVED STUDENTS
        {
            AllQueryParamreg[0] = _sqlQueryreg;
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            DataTable dtdata = ROWS();
            DataRow dr = dtdata.NewRow();
            for (int i = 0; i < dtreg.Rows.Count; i++)
            {
                dr["CNAME"] = dtreg.Rows[i]["CNAME"].ToString().Trim();
                dr["LNKURL"] = LNKURL + dtreg.Rows[i]["CANDIDATEID"].ToString().Trim();
                dr["ROLL"] = dtreg.Rows[i]["ROLL"].ToString().Trim();
                dr["CANDIDATEID"] = dtreg.Rows[i]["CANDIDATEID"].ToString().Trim();
                dr["FNAME"] = dtreg.Rows[i]["FNAME"].ToString().Trim();
                dr["BRCODE"] = dtreg.Rows[i]["BRCODE"].ToString().Trim();
                dr["SEM"] = dtreg.Rows[i]["SEM"].ToString().Trim();
                dr["DOB"] = dtreg.Rows[i]["DOB"].ToString().Trim();
                dtdata.Rows.Add(dr);
                dr = dtdata.NewRow();
            }
            Grdaproved.DataSource = dtdata;
            Grdaproved.DataBind();
            if (Grdaproved.Rows.Count == 0) { ltrlMessage.Text = "No Records Found !"; }
            else { Grdaproved.Visible = true; }
            Grddata.Visible = false;
            Btnapproved.Visible = true;
            Chkall.Visible = true;
        }
        else//ALL STUDENTS
        {
            AllQueryParamreg[0] = _sqlQueryreg;
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            DataTable dtdata = ROWS();
            DataRow dr = dtdata.NewRow();
            for (int i = 0; i < dtreg.Rows.Count; i++)
            {
                dr["CNAME"] = dtreg.Rows[i]["CNAME"].ToString().Trim();
                if (TYPEVAL == "MRK")
                { dr["LNKURL"] = LNKURL + dtreg.Rows[i]["ROLL"].ToString().Trim(); }
                else { dr["LNKURL"] = LNKURL + dtreg.Rows[i]["CANDIDATEID"].ToString().Trim(); }
                dr["ROLL"] = dtreg.Rows[i]["ROLL"].ToString().Trim();
                dr["CANDIDATEID"] = dtreg.Rows[i]["CANDIDATEID"].ToString().Trim();
                dr["FNAME"] = dtreg.Rows[i]["FNAME"].ToString().Trim();
                dr["BRCODE"] = dtreg.Rows[i]["BRCODE"].ToString().Trim();
                dr["SEM"] = dtreg.Rows[i]["SEM"].ToString().Trim();
                dr["DOB"] = dtreg.Rows[i]["DOB"].ToString().Trim();
                dtdata.Rows.Add(dr);
                dr = dtdata.NewRow();
            }
            Grddata.DataSource = dtdata;
            Grddata.DataBind();
            if (Grddata.Rows.Count == 0) { ltrlMessage.Text = "No Records Found !"; }
            else { Grddata.Visible = true; }
            Grdaproved.Visible = false;
            Btnapproved.Visible = false;
            Chkall.Visible = false;
        }
    }
    protected void Grdapro_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (IsPostBack)
            {
                if (Session["UTYPE"] != null)
                {
                    ltrlMessage.Text = "";
                    Grdaproved.PageIndex = e.NewPageIndex;

                    string[] SPL = Request.QueryString["TYP"].ToString().Trim().Split('|');
                    string TYPEVAL = SPL[0].ToString();
                    string SEM = SPL[1].ToString();
                    Griddata(Session["UTYPE"].ToString(), TYPEVAL, SEM);
                }
                else { Response.Redirect("Inslogin.aspx", false); }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Server Busy, Please try after some time !"; }
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
        dt.Columns.Add("LNKURL");
        dt.Columns.Add("ROLL");
        dt.Columns.Add("CANDIDATEID");
        dt.Columns.Add("FNAME");
        dt.Columns.Add("BRCODE");
        dt.Columns.Add("SEM");
        dt.Columns.Add("DOB");
        return dt;
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Session["BRCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            if (Request.QueryString["TYP"] == null) { Response.Redirect("~/Error.aspx", false); }
            string[] SPL = Request.QueryString["TYP"].ToString().Trim().Split('|');
            string TYPEVAL = SPL[0].ToString();
            string SEM = SPL[1].ToString();

            string ACCID = Grdaproved.DataKeys[e.RowIndex].Value.ToString();
            string _sqlQuery = string.Empty;
            if (TYPEVAL == "ANAPP" || TYPEVAL == "AAPP")//Registration
            {
                //_sqlQuery = "DELETE FROM REGISTRATION WHERE CANDIDATEID='" + ACCID + "'";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Delete Not Allowed from Registration,You Can Only Approve/Disapprove From Registration.');", true);
                return;
            }
            else if (TYPEVAL == "SNAPP" || TYPEVAL == "SAPP")//Scrutiny
            {
                _sqlQuery = "DELETE FROM SCRU WHERE CANDIDATEID='" + ACCID + "'";
            }
            else if (TYPEVAL == "RNAPP" || TYPEVAL == "RAPP")//Re-Evaluation
            {
                _sqlQuery = "DELETE FROM REEVA WHERE CANDIDATEID='" + ACCID + "'";
            }
            else if (TYPEVAL == "BNAPP" || TYPEVAL == "BAPP")//BACK Paper
            {
                _sqlQuery = "DELETE FROM BACKP WHERE CANDIDATEID='" + ACCID + "'";
            }
            else if (TYPEVAL == "SBNAPP" || TYPEVAL == "SBAPP")//Special BACK Paper
            {
                _sqlQuery = "DELETE FROM BACKP WHERE CANDIDATEID='" + ACCID + "'";
            }
            BLL objbllLogin = new BLL();
            string result = objbllLogin.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                ltrlMessage.Text = "Deleted Successfully.";
                Griddata(Session["UTYPE"].ToString(), TYPEVAL, SEM);
            }
            else { ltrlMessage.Text = "Delete Failed."; }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please Try after some times."; }
    }
}