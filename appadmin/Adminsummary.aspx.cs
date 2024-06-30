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
using System.Reflection;
public partial class Adminsummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            else
            {
                bindsourcedata();
            }
        }
        catch (Exception ex) { LblMessage.Text = "PLEASE TRY AFTER SOME TIME."; }
    }
    private void bindsourcedata()
    {
        string _sqlQuery = string.Empty;
        DataTable dtdata = ROWS();
        Grd1.DataSource = dtdata; Grd1.DataBind();
    }
    private DataTable ROWS()
    {
        string cntquery = string.Empty;
        DataTable dt = new DataTable();
        dt.Columns.Add("INSNAME");
        dt.Columns.Add("BRCURL");
        dt.Columns.Add("BRCCNT");
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
        _sqlQueryreg = "select distinct INSCODE,INSNAME from INSLOGIN WHERE INSCODE!='0' order by INSCODE asc";
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
            int CNT7 = 0;
            int CNTP = 0;
            DataRow dr = dt.NewRow();
            for (int i = 0; i < dtreg.Rows.Count; i++)
            {
                string INSCODE = dtreg.Rows[i]["INSCODE"].ToString().Trim();
                string INSNAME = dtreg.Rows[i]["INSNAME"].ToString().Trim();
                string _sqlQuery1 = "SELECT COUNT(*) AS CON FROM BRLOGIN WHERE INSCODE='" + INSCODE + "' AND BRCODE!='0'";
                string _sqlQuery2 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='01' AND STAT='A' AND REGPVT='R'";
                string _sqlQuery3 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='02' AND STAT='A' AND REGPVT='R'";
                string _sqlQuery4 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='03' AND STAT='A' AND REGPVT='R'";
                cntquery = "SELECT (" + _sqlQuery1 + ") AS CON1,(" + _sqlQuery2 + ") AS CON2,(" + _sqlQuery3 + ") AS CON3,(" + _sqlQuery4 + ") AS CON4";
                string CNNT1 = COUNT(cntquery);
                string[] SPL1 = CNNT1.Split('|');
                dr["INSNAME"] = INSNAME;
                dr["BRCURL"] = "~/Admin/Allsummary.aspx?STAT=BRCCNT|" + INSCODE;
                dr["BRCCNT"] = SPL1[0].ToString();
                dr["S01URL"] = "~/Admin/Allsummary.aspx?STAT=S01CNT|" + INSCODE;
                dr["S01CNT"] = SPL1[1].ToString();
                dr["S02URL"] = "~/Admin/Allsummary.aspx?STAT=S02CNT|" + INSCODE;
                dr["S02CNT"] = SPL1[2].ToString();
                dr["S03URL"] = "~/Admin/Allsummary.aspx?STAT=S03CNT|" + INSCODE;
                dr["S03CNT"] = SPL1[3].ToString();
                
                CNT1 = CNT1 + Convert.ToInt32(SPL1[0].ToString());
                CNT2 = CNT2 + Convert.ToInt32(SPL1[1].ToString());
                CNT3 = CNT3 + Convert.ToInt32(SPL1[2].ToString());
                CNT4 = CNT4 + Convert.ToInt32(SPL1[3].ToString());

                string _sqlQuery5 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='04' AND STAT='A' AND REGPVT='R'";
                string _sqlQuery6 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='05' AND STAT='A' AND REGPVT='R'";
                string _sqlQuery7 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND SEM='06' AND STAT='A' AND REGPVT='R'";
                string _sqlQuery8 = "SELECT COUNT(*) AS CON FROM REGISTRATION WHERE INSCODE='" + INSCODE + "' AND STAT='A' AND REGPVT='P'";
                cntquery = "SELECT (" + _sqlQuery5 + ") AS CON1,(" + _sqlQuery6 + ") AS CON2,(" + _sqlQuery7 + ") AS CON3,(" + _sqlQuery8 + ") AS CON4";
                string CNNT2 = COUNT(cntquery);
                string[] SPL2 = CNNT2.Split('|');
                dr["S04URL"] = "~/Admin/Allsummary.aspx?STAT=S04CNT|" + INSCODE;
                dr["S04CNT"] = SPL2[0].ToString();
                dr["S05URL"] = "~/Admin/Allsummary.aspx?STAT=S05CNT|" + INSCODE;
                dr["S05CNT"] = SPL2[1].ToString();
                dr["S06URL"] = "~/Admin/Allsummary.aspx?STAT=S06CNT|" + INSCODE;
                dr["S06CNT"] = SPL2[2].ToString();
                dr["PVTURL"] = "~/Admin/Allsummary.aspx?STAT=PVTCNT|" + INSCODE;
                dr["PVTCNT"] = SPL2[3].ToString();
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                
                CNT5 = CNT5 + Convert.ToInt32(SPL2[0].ToString());
                CNT6 = CNT6 + Convert.ToInt32(SPL2[1].ToString());
                CNT7 = CNT7 + Convert.ToInt32(SPL2[2].ToString());
                CNTP = CNTP + Convert.ToInt32(SPL2[3].ToString());
            }
            dr["INSNAME"] = "TOTAL";
            dr["BRCCNT"] = CNT1.ToString();
            dr["S01CNT"] = CNT2.ToString();
            dr["S02CNT"] = CNT3.ToString();
            dr["S03CNT"] = CNT4.ToString();
            dr["S04CNT"] = CNT5.ToString();
            dr["S05CNT"] = CNT6.ToString();
            dr["S06CNT"] = CNT7.ToString();
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
        CNT = dt.Rows[0]["CON1"].ToString().Trim() + "|" + dt.Rows[0]["CON2"].ToString().Trim() + "|" + dt.Rows[0]["CON3"].ToString().Trim() + "|" + dt.Rows[0]["CON4"].ToString().Trim();
        return CNT;
    }
}