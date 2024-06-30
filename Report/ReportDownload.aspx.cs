using System;
using System.Collections;
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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using _Examination;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;

public partial class ReportDownload : System.Web.UI.Page
{
    string _Query = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["STAT"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (Session["INSCODE"] != null || Session["ADMIN"] != null) { if (Request.QueryString["STAT"] != null) { Session["ID"] = Request.QueryString["STAT"].ToString(); } }
            if (!IsPostBack)
            {
                string[] SPL = Request.QueryString["STAT"].ToString().Split('|');
                string TYP = SPL[0].ToString();
                string SEM = SPL[1].ToString();
                if (TYP == "REGNOMINAL") { Regnominal(SEM); }
            }
        }
        catch (Exception ex) { Response.Write(ex.Message); }
    }
    private void Regnominal(string SEM)
    {
        BLL objbllreg = new BLL();
        string[] AllQueryParamreg = new string[1];
        //Get From session
        string FORMSESS = string.Empty;
        DataTable dtsess = new DataTable();
        _Query = "select * FROM FORMSESS WHERE SESSNAME='FORM'";
        AllQueryParamreg[0] = _Query;
        objbllreg.QUERYBLL(ref dtsess, AllQueryParamreg);
        if (dtsess.Rows.Count > 0)
        {
            FORMSESS = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
        }

        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Nominal.rdlc");
        UBTERDataSet tbldata = new UBTERDataSet();

        string SEMYEAR = SEM;
        string CLMSESS = string.Empty;
        string CLMCOM = string.Empty;
        string CLMSEMFEE = string.Empty;
        if (SEM == "01") { CLMSESS = "SEMSESS1"; CLMCOM = "SEMCOM1"; CLMSEMFEE = "SEMFEE1"; }
        else if (SEM == "02") { CLMSESS = "SEMSESS2"; CLMCOM = "SEMCOM2"; CLMSEMFEE = "SEMFEE2"; }
        else if (SEM == "03") { CLMSESS = "SEMSESS3"; CLMCOM = "SEMCOM3"; CLMSEMFEE = "SEMFEE3"; }
        else if (SEM == "04") { CLMSESS = "SEMSESS4"; CLMCOM = "SEMCOM4"; CLMSEMFEE = "SEMFEE4"; }
        else if (SEM == "05") { CLMSESS = "SEMSESS5"; CLMCOM = "SEMCOM5"; CLMSEMFEE = "SEMFEE5"; }
        else if (SEM == "06") { CLMSESS = "SEMSESS6"; CLMCOM = "SEMCOM6"; CLMSEMFEE = "SEMFEE6"; }
        else if (SEM == "P") { CLMSESS = "SPLSESS"; CLMCOM = "SPLCOM"; SEMYEAR = "PRIVATE"; }
        else if (SEM == "Q") { CLMSESS = "SPLSESS"; CLMCOM = "SPLCOM"; SEMYEAR = "QUALIFIED"; }



        string[] insspl = Session["INSCODE"].ToString().Split('|');
        string[] brspl = Session["BRCODE"].ToString().Split('|');
        DataTable dtreg = new DataTable();

        if (SEM == "P") { _Query = "select 'SUMMER-2022' AS HEAD,INSNAME,BRNAME,CANDIDATEID,ROLL,JROLL,CNAME,FNAME,DOB,GENDER,CAT,SEM,SPLFEE AS FEE,REGPVT from REGISTRATION where STAT='A' AND REGPVT='P' AND INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' AND CANDIDATEID IN(SELECT CANDIDATEID FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='B') order by ROLL,CNAME ASC"; }
        else if (SEM == "Q") { _Query = "select 'SUMMER-2022' AS HEAD,INSNAME,BRNAME,CANDIDATEID,ROLL,JROLL,CNAME,FNAME,DOB,GENDER,CAT,SEM,SPLFEE AS FEE,REGPVT from REGISTRATION where STAT='A' AND REGPVT='Q' AND INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' AND CANDIDATEID IN(SELECT CANDIDATEID FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='B') order by ROLL,CNAME ASC"; }
        else { _Query = "select 'SUMMER-2022' AS HEAD,INSNAME,BRNAME,CANDIDATEID,ROLL,JROLL,CNAME,FNAME,DOB,GENDER,CAT,SEM," + CLMSEMFEE + " AS FEE,REGPVT from REGISTRATION where STAT='A' AND REGPVT='R' AND INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' and " + CLMCOM + "='1' and " + CLMSESS + "='" + FORMSESS + "' AND SEM='" + SEM + "' order by ROLL,CNAME ASC"; }
        AllQueryParamreg[0] = _Query;
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0)
        {
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count > 0)
            {
                tbldata.Tables["Nominal"].Merge(dtreg);

                ReportDataSource datasource = new ReportDataSource("UBTERDataSet1", tbldata.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                //Export(insspl[0].ToLower() + "_" + brspl[0].ToString() + "_" + SEM);
            }
        }
    }
    protected void Export(string Filename)
    {
        Warning[] warnings;
        string[] streamIds;
        string contentType;
        string encoding;
        string extension;
        //Export the RDLC Report to Byte Array.
        //< asp:ListItem Text = "Word" Value = "WORD" Selected = "True" />
        //< asp:ListItem Text = "Excel" Value = "EXCEL" />
        //< asp:ListItem Text = "PDF" Value = "PDF" />
        //< asp:ListItem Text = "Image" Value = "IMAGE" />
        byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out contentType, out encoding, out extension, out streamIds, out warnings);
        //Download the RDLC Report in Word, Excel, PDF and Image formats.
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Filename + "." + extension);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }
}