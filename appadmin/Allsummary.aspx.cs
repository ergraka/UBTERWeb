using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Collections;
using _Examination;

public partial class Allsummary : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Request.QueryString["STAT"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (!IsPostBack)
            {
                string[] SPL = Request.QueryString["STAT"].ToString().Split('|');
                string TYPE = SPL[0].ToString();
                string INSCODE = SPL[1].ToString();
                if (TYPE == "BRCCNT")
                {
                    bindsourcedata();
                    Lblhead.Text = "- BRANCH SUMMARY -";
                    Lblcaption.Text = "FOR DETAILS SUMMARY PLEASE CLICK ON COUNT.";
                    Grdcandidate.Visible = false;
                }
                else if (TYPE == "S01CNT" || TYPE == "S02CNT" || TYPE == "S03CNT" || TYPE == "S04CNT" || TYPE == "S05CNT" || TYPE == "S06CNT" || TYPE == "PVTCNT")
                {

                    Grdbranch.Visible = false;
                    Lblhead.Text = "- STUDENT SUMMARY -";
                    Lblcaption.Text = "FOR DETAILS SUMMARY PLEASE CLICK ON REGISTRATION NUMBER.";

                    string _sqlQueryreg = string.Empty;
                    if (TYPE == "S01CNT") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='01' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC, SEMCOM1 DESC"; }
                    else if (TYPE == "S02CNT") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='02' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC, SEMCOM2 DESC"; }
                    else if (TYPE == "S03CNT") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='03' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC, SEMCOM3 DESC"; }
                    else if (TYPE == "S04CNT") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='04' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC, SEMCOM4 DESC"; }
                    else if (TYPE == "S05CNT") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='05' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC, SEMCOM5 DESC"; }
                    else if (TYPE == "S06CNT") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='06' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC, SEMCOM6 DESC"; }
                    else if (TYPE == "PVTCNT") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND STAT='A' AND REGPVT='P' ORDER BY CNAME ASC"; }
                    DataTable dtreg = new DataTable();
                    string[] AllQueryParamreg = new string[1];
                    AllQueryParamreg[0] = _sqlQueryreg;
                    BLL objbllreg = new BLL();
                    objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                    if (dtreg.Rows.Count > 0)
                    {
                        dt.Columns.Add("SRNO");
                        dt.Columns.Add("CANDIDATEID");
                        dt.Columns.Add("LNKURL");
                        dt.Columns.Add("CNAME");
                        dt.Columns.Add("FNAME");
                        dt.Columns.Add("INSNAME");
                        dt.Columns.Add("BRNAME");
                        dt.Columns.Add("SEM");
                        dt.Columns.Add("STAT");
                        for (int i = 0; i < dtreg.Rows.Count; i++)
                        {
                            DataRow dr = dt.NewRow();
                            int n = i + 1;
                            string SN = string.Empty;
                            if (n < 10) { SN = "0" + n.ToString(); }
                            else { SN = n.ToString(); }
                            dr["SRNO"] = SN;
                            dr["CANDIDATEID"] = dtreg.Rows[i]["CANDIDATEID"].ToString();
                            dr["LNKURL"] = "~/Report/View.aspx?AAAAA=" + dtreg.Rows[i]["CANDIDATEID"].ToString();
                            dr["CNAME"] = dtreg.Rows[i]["CNAME"].ToString();
                            dr["FNAME"] = dtreg.Rows[i]["FNAME"].ToString();
                            dr["INSNAME"] = dtreg.Rows[i]["INSNAME"].ToString();
                            dr["BRNAME"] = dtreg.Rows[i]["BRNAME"].ToString();
                            dr["SEM"] = dtreg.Rows[i]["SEM"].ToString();

                            string STAT = string.Empty;
                            if (TYPE == "S01CNT") { STAT = dtreg.Rows[i]["SEMCOM1"].ToString(); }
                            else if (TYPE == "S02CNT") { STAT = dtreg.Rows[i]["SEMCOM2"].ToString(); }
                            else if (TYPE == "S03CNT") { STAT = dtreg.Rows[i]["SEMCOM3"].ToString(); }
                            else if (TYPE == "S04CNT") { STAT = dtreg.Rows[i]["SEMCOM4"].ToString(); }
                            else if (TYPE == "S05CNT") { STAT = dtreg.Rows[i]["SEMCOM5"].ToString(); }
                            else if (TYPE == "S06CNT") { STAT = dtreg.Rows[i]["SEMCOM6"].ToString(); }
                            else if (TYPE == "PVTCNT") { STAT = "PRIVATE"; }
                            if (STAT == "") { STAT = "NOT-APPROVED"; }
                            else if (STAT == "PRIVATE") { STAT = "PRIVATE"; }
                            else { STAT = "APPROVED"; }

                            dr["STAT"] = STAT;

                            dt.Rows.Add(dr);
                            dr = dt.NewRow();
                        }
                        Grdcandidate.DataSource = dt;
                        Grdcandidate.DataBind();
                        LblMessage.Text = "";
                    }
                    else
                    {
                        LblMessage.Text = "NO RECORDS FOUND.";
                        Grdcandidate.Visible = false;
                    }
                }
                else if (TYPE == "S01CNTBR" || TYPE == "S02CNTBR" || TYPE == "S03CNTBR" || TYPE == "S04CNTBR" || TYPE == "S05CNTBR" || TYPE == "S06CNTBR" || TYPE == "PVTCNTBR")
                {

                    string BRCODE = SPL[2].ToString();
                    Grdbranch.Visible = false;
                    Lblhead.Text = "- STUDENT SUMMARY -";
                    Lblcaption.Text = "FOR DETAILS SUMMARY PLEASE CLICK ON REGISTRATION NUMBER.";

                    string _sqlQueryreg = string.Empty;
                    if (TYPE == "S01CNTBR") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='01' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC,CNAME ASC, SEMCOM1 DESC"; }
                    else if (TYPE == "S02CNTBR") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='02' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC,CNAME ASC, SEMCOM2 DESC"; }
                    else if (TYPE == "S03CNTBR") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='03' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC,CNAME ASC, SEMCOM3 DESC"; }
                    else if (TYPE == "S04CNTBR") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='04' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC,CNAME ASC, SEMCOM4 DESC"; }
                    else if (TYPE == "S05CNTBR") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='05' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC,CNAME ASC, SEMCOM5 DESC"; }
                    else if (TYPE == "S06CNTBR") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='06' AND STAT='A' AND REGPVT='R' ORDER BY BRCODE ASC,CNAME ASC, SEMCOM6 DESC"; }
                    else if (TYPE == "PVTCNTBR") { _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND STAT='A' AND REGPVT='P' ORDER BY CNAME ASC"; }
                    DataTable dtreg = new DataTable();
                    string[] AllQueryParamreg = new string[1];
                    AllQueryParamreg[0] = _sqlQueryreg;
                    BLL objbllreg = new BLL();
                    objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                    if (dtreg.Rows.Count > 0)
                    {
                        dt.Columns.Add("SRNO");
                        dt.Columns.Add("CANDIDATEID");
                        dt.Columns.Add("LNKURL");
                        dt.Columns.Add("CNAME");
                        dt.Columns.Add("FNAME");
                        dt.Columns.Add("INSNAME");
                        dt.Columns.Add("BRNAME");
                        dt.Columns.Add("SEM");
                        dt.Columns.Add("STAT");
                        for (int i = 0; i < dtreg.Rows.Count; i++)
                        {
                            DataRow dr = dt.NewRow();
                            int n = i + 1;
                            string SN = string.Empty;
                            if (n < 10) { SN = "0" + n.ToString(); }
                            else { SN = n.ToString(); }
                            dr["SRNO"] = SN;
                            dr["CANDIDATEID"] = dtreg.Rows[i]["CANDIDATEID"].ToString();
                            dr["LNKURL"] = "~/Report/View.aspx?AAAAA=" + dtreg.Rows[i]["CANDIDATEID"].ToString();
                            dr["CNAME"] = dtreg.Rows[i]["CNAME"].ToString();
                            dr["FNAME"] = dtreg.Rows[i]["FNAME"].ToString();
                            dr["INSNAME"] = dtreg.Rows[i]["INSNAME"].ToString();
                            dr["BRNAME"] = dtreg.Rows[i]["BRNAME"].ToString();
                            dr["SEM"] = dtreg.Rows[i]["SEM"].ToString();

                            string STAT = string.Empty;
                            if (TYPE == "S01CNTBR") { STAT = dtreg.Rows[i]["SEMCOM1"].ToString(); }
                            else if (TYPE == "S02CNTBR") { STAT = dtreg.Rows[i]["SEMCOM2"].ToString(); }
                            else if (TYPE == "S03CNTBR") { STAT = dtreg.Rows[i]["SEMCOM3"].ToString(); }
                            else if (TYPE == "S04CNTBR") { STAT = dtreg.Rows[i]["SEMCOM4"].ToString(); }
                            else if (TYPE == "S05CNTBR") { STAT = dtreg.Rows[i]["SEMCOM5"].ToString(); }
                            else if (TYPE == "S06CNTBR") { STAT = dtreg.Rows[i]["SEMCOM6"].ToString(); }
                            else if (TYPE == "PVTCNTBR") { STAT = "PRIVATE"; }
                            if (STAT == "") { STAT = "NOT-APPROVED"; }
                            else if (STAT == "PRIVATE") { STAT = "PRIVATE"; }
                            else { STAT = "APPROVED"; }

                            dr["STAT"] = STAT;

                            dt.Rows.Add(dr);
                            dr = dt.NewRow();
                        }
                        Grdcandidate.DataSource = dt;
                        Grdcandidate.DataBind();
                        LblMessage.Text = "";
                    }
                    else
                    {
                        LblMessage.Text = "NO RECORDS FOUND.";
                        Grdcandidate.Visible = false;
                    }
                }
                else { Response.Redirect("~/Error.aspx", false); }
            }
        }
        catch (Exception ex) { LblMessage.Text = "PLEASE TRY AFTER SOME TIMES."; }
    }
    private void bindsourcedata()
    {
        string _sqlQuery = string.Empty;
        DataTable dtdata = ROWS();
        Grdbranch.DataSource = dtdata; Grdbranch.DataBind();
    }
    private DataTable ROWS()
    {
        string[] SPLM = Request.QueryString["STAT"].ToString().Split('|');
        string INSCODE = SPLM[1].ToString();
        string cntquery = string.Empty;
        DataTable dt = new DataTable();
        dt.Columns.Add("BRNAME");
        dt.Columns.Add("INSNAME");
        dt.Columns.Add("S01URL");
        dt.Columns.Add("S01CNT");
        dt.Columns.Add("S02URL");
        dt.Columns.Add("S02CNT");
        dt.Columns.Add("S03URL");
        dt.Columns.Add("S03CNT");
        dt.Columns.Add("S04URL");
        dt.Columns.Add("S04CNT");
        dt.Columns.Add("S05URL");
        dt.Columns.Add("S05CNT");
        dt.Columns.Add("S06URL");
        dt.Columns.Add("S06CNT");
        dt.Columns.Add("PVTURL");
        dt.Columns.Add("PVTCNT");
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        _sqlQueryreg = "select * from BRLOGIN WHERE INSCODE='" + INSCODE + "' AND BRCODE!='0' order by BRCODE asc";
        AllQueryParamreg[0] = _sqlQueryreg;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0)
        {
            int CNT1 = 0;
            int CNT2 = 0;
            int CNT3 = 0;
            int CNT4 = 0;
            int CNT5 = 0;
            int CNT6 = 0;
            int CNTP = 0;
            DataRow dr = dt.NewRow();
            for (int i = 0; i < dtreg.Rows.Count; i++)
            {
                string BRCODE = dtreg.Rows[i]["BRCODE"].ToString().Trim();
                string BRNAME = dtreg.Rows[i]["BRNAME"].ToString().Trim();
                string INSNAME = dtreg.Rows[i]["INSNAME"].ToString().Trim();
                string _sqlQuery1 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='01' AND STAT='A' AND REGPVT='R'";
                string _sqlQuery2 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='02' AND STAT='A' AND REGPVT='R'";
                string _sqlQuery3 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='03' AND STAT='A' AND REGPVT='R'";
                string _sqlQuery4 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='04' AND STAT='A' AND REGPVT='R'";
                string _sqlQuery5 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='05' AND STAT='A' AND REGPVT='R'";
                string _sqlQuery6 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND SEM='06' AND STAT='A' AND REGPVT='R'";
                string _sqlQuery7 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND STAT='A' AND REGPVT='P'";

                cntquery = "SELECT (" + _sqlQuery1 + ") AS CON1,(" + _sqlQuery2 + ") AS CON2,(" + _sqlQuery3 + ") AS CON3,(" + _sqlQuery4 + ") AS CON4,(" + _sqlQuery5 + ") AS CON5,(" + _sqlQuery6 + ") AS CON6,(" + _sqlQuery7 + ") AS CON7";
                string CNNT1 = COUNT(cntquery);
                string[] SPL1 = CNNT1.Split('|');
                dr["BRNAME"] = BRNAME;
                dr["INSNAME"] = INSNAME;
                dr["S01URL"] = "~/Admin/Allsummary.aspx?STAT=S01CNTBR|" + INSCODE + "|" + BRCODE;
                dr["S01CNT"] = SPL1[0].ToString();
                dr["S02URL"] = "~/Admin/Allsummary.aspx?STAT=S02CNTBR|" + INSCODE + "|" + BRCODE;
                dr["S02CNT"] = SPL1[1].ToString();
                dr["S03URL"] = "~/Admin/Allsummary.aspx?STAT=S03CNTBR|" + INSCODE + "|" + BRCODE;
                dr["S03CNT"] = SPL1[2].ToString();
                dr["S04URL"] = "~/Admin/Allsummary.aspx?STAT=S04CNTBR|" + INSCODE + "|" + BRCODE;
                dr["S04CNT"] = SPL1[3].ToString();
                dr["S05URL"] = "~/Admin/Allsummary.aspx?STAT=S05CNTBR|" + INSCODE + "|" + BRCODE;
                dr["S05CNT"] = SPL1[4].ToString();
                dr["S06URL"] = "~/Admin/Allsummary.aspx?STAT=S06CNTBR|" + INSCODE + "|" + BRCODE;
                dr["S06CNT"] = SPL1[5].ToString();
                dr["PVTURL"] = "~/Admin/Allsummary.aspx?STAT=PVTCNTBR|" + INSCODE + "|" + BRCODE;
                dr["PVTCNT"] = SPL1[6].ToString();
                dt.Rows.Add(dr);
                dr = dt.NewRow();

                CNT1 = CNT1 + Convert.ToInt32(SPL1[0].ToString());
                CNT2 = CNT2 + Convert.ToInt32(SPL1[1].ToString());
                CNT3 = CNT3 + Convert.ToInt32(SPL1[2].ToString());
                CNT4 = CNT4 + Convert.ToInt32(SPL1[3].ToString());
                CNT5 = CNT5 + Convert.ToInt32(SPL1[4].ToString());
                CNT6 = CNT6 + Convert.ToInt32(SPL1[5].ToString());
                CNTP = CNTP + Convert.ToInt32(SPL1[6].ToString());
            }
            dr["BRNAME"] = "TOTAL";
            dr["S01CNT"] = CNT1.ToString();
            dr["S02CNT"] = CNT2.ToString();
            dr["S03CNT"] = CNT3.ToString();
            dr["S04CNT"] = CNT4.ToString();
            dr["S05CNT"] = CNT5.ToString();
            dr["S06CNT"] = CNT6.ToString();
            dr["PVTCNT"] = CNTP.ToString();
            dt.Rows.Add(dr);
            dr = dt.NewRow();
        }
        return dt;
    }
    private string COUNT(string Query)
    {
        string CNT = string.Empty;
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        AllQueryParam[0] = Query;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        CNT = dt.Rows[0]["CON1"].ToString().Trim() + "|" + dt.Rows[0]["CON2"].ToString().Trim() + "|" + dt.Rows[0]["CON3"].ToString().Trim() + "|" + dt.Rows[0]["CON4"].ToString().Trim() + "|" + dt.Rows[0]["CON5"].ToString().Trim() + "|" + dt.Rows[0]["CON6"].ToString().Trim() + "|" + dt.Rows[0]["CON7"].ToString().Trim();
        return CNT;
    }
}