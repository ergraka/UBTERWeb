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
public partial class Brhome : System.Web.UI.Page
{
    public string CP = string.Empty;
    public string cname = string.Empty;
    public string LNKURL = "~/Institute/Stulist.aspx?";
    string REG = string.Empty;
    string BACKP = string.Empty;
    string SBACKP = string.Empty;
    string SCRU = string.Empty;
    string REEVA = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null && Session["UTYPE"] != null)
            {
                if (!IsPostBack)
                {
                    if (Session["BRCODE"].ToString() != null)
                    {
                        string[] splins = Session["INSCODE"].ToString().Split('|');
                        string INSCODE = splins[0].ToString();

                        string[] splbrc = Session["BRCODE"].ToString().Split('|');
                        string BRCODE = splbrc[0].ToString();

                        string _sqlQueryreg = string.Empty;
                        DataTable dtreg = new DataTable();
                        string[] AllQueryParamreg = new string[1];
                        _sqlQueryreg = "SELECT * FROM BRLOGIN where INSCODE='" + INSCODE + "' and BRCODE='" + BRCODE + "'";
                        AllQueryParamreg[0] = _sqlQueryreg;
                        BLL objbllreg = new BLL();
                        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                        if (dtreg.Rows.Count > 0)
                        {
                            REG = dtreg.Rows[0]["REG"].ToString();
                            BACKP = dtreg.Rows[0]["BACKP"].ToString();
                            SBACKP = dtreg.Rows[0]["SBACKP"].ToString();
                            SCRU = dtreg.Rows[0]["SCRU"].ToString();
                            REEVA = dtreg.Rows[0]["REEVA"].ToString();

                            string REGIS = dtreg.Rows[0]["SEM"].ToString();
                            string ADMT = dtreg.Rows[0]["ADMT"].ToString();
                            string VER = dtreg.Rows[0]["VER"].ToString();
                            string LISTE = dtreg.Rows[0]["LISTE"].ToString();
                            string LISTD = dtreg.Rows[0]["LISTD"].ToString();
                            string SESS = dtreg.Rows[0]["SESS"].ToString();

                            string SBPADMT = dtreg.Rows[0]["SBPADMT"].ToString();
                            string SBPVER = dtreg.Rows[0]["SBPVER"].ToString();
                            string SBPLISTE = dtreg.Rows[0]["SBPLISTE"].ToString();
                            string SBPLISTD = dtreg.Rows[0]["SBPLISTD"].ToString();


                            for (int i = 1; i <= 8; i++)
                            {
                                string SM = "0" + i.ToString();
                                if (i == 7)
                                { SM = "P"; }
                                else if (i == 8) { SM = "Q"; }

                                if (REGIS.Contains(SM) == true)
                                {
                                    if (SM == "01")
                                    {
                                        if (REG != "N") { Lnksem1.Visible = true; TRUPGRADE.Visible = true; }
                                        if (BACKP != "N") { Lnkback.Visible = true; TRUPGRADE.Visible = true; }
                                        if (SBACKP != "N") { Lnksback.Visible = true; TRUPGRADE.Visible = true; }
                                    }
                                    else if (SM == "02")
                                    {
                                        if (BACKP != "N") { Lnkback.Visible = true; TRUPGRADE.Visible = true; }
                                        if (SBACKP != "N") { Lnksback.Visible = true; TRUPGRADE.Visible = true; }
                                    }
                                    else if (SM == "03")
                                    {
                                        if (BACKP != "N") { Lnkback.Visible = true; TRUPGRADE.Visible = true; }
                                        if (SBACKP != "N") { Lnksback.Visible = true; TRUPGRADE.Visible = true; }
                                    }
                                    else if (SM == "04")
                                    {
                                        if (BACKP != "N") { Lnkback.Visible = true; TRUPGRADE.Visible = true; }
                                        if (SBACKP != "N") { Lnksback.Visible = true; TRUPGRADE.Visible = true; }
                                    }
                                    else if (SM == "05")
                                    {
                                        if (BACKP != "N") { Lnkback.Visible = true; TRUPGRADE.Visible = true; }
                                        if (SBACKP != "N") { Lnksback.Visible = true; TRUPGRADE.Visible = true; }
                                    }
                                    else if (SM == "06")
                                    {
                                        if (BACKP != "N") { Lnkback.Visible = true; TRUPGRADE.Visible = true; }
                                        if (SBACKP != "N") { Lnksback.Visible = true; TRUPGRADE.Visible = true; }
                                    }
                                }
                                stat(SM, REGIS, ADMT, VER, LISTE, LISTD, SESS, SBPADMT, SBPVER, SBPLISTE, SBPLISTD);
                            }
                        }
                        string brc = BRCODE.Substring(0, 2);
                        if (brc == "16" || brc == "07") { CP = "YEAR"; }
                        else { CP = "SEMESTER"; }
                    }
                    else { Response.Redirect("Inslogin.aspx", false); }
                }
            }
            else { Response.Redirect("Inslogin.aspx", false); }
        }
        catch (Exception ex)
        { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }
    }
    private void stat(string VAL, string REGIS, string ADMT, string VER, string LISTE, string LISTD, string SESS, string SBPADMT, string SBPVER, string SBPLISTE, string SBPLISTD)
    {
        string[] SPL1ST = null;
        string[] SPL2ND = null;
        string[] SPL3RD = null;
        string REGPVT = string.Empty;
        string CNT = string.Empty;
        string CLM = string.Empty;
        string SEM = string.Empty;
        string _sqlQuery = string.Empty;
        string[] spl1 = Session["INSCODE"].ToString().Split('|');
        string inscode = spl1[0].ToString();
        string[] spl2 = Session["BRCODE"].ToString().Split('|');
        string brcode = spl2[0].ToString();

        if (VAL == "01") { SEM = "01"; CLM = "SEMCOM1"; REGPVT = "R"; }
        else if (VAL == "02") { SEM = "02"; CLM = "SEMCOM2"; REGPVT = "R"; }
        else if (VAL == "03") { SEM = "03"; CLM = "SEMCOM3"; REGPVT = "R"; }
        else if (VAL == "04") { SEM = "04"; CLM = "SEMCOM4"; REGPVT = "R"; }
        else if (VAL == "05") { SEM = "05"; CLM = "SEMCOM5"; REGPVT = "R"; }
        else if (VAL == "06") { SEM = "06"; CLM = "SEMCOM6"; REGPVT = "R"; }
        else if (VAL == "P") { REGPVT = "P"; }
        else if (VAL == "Q") { REGPVT = "Q"; }
        DataTable dtdata = ROWS();
        if (VAL == "P" || VAL == "Q")//FOR PRIVATE
        {
            SEM = VAL;
            string _sqlQuery1 = "select Count(*) from REGISTRATION where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "' AND STAT='A'";
            string _sqlQuery2 = "select Count(*) from REGISTRATION where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "' AND STAT='A'";
            string _sqlQuery3 = string.Empty;
            if (VAL == "P")
            {
                _sqlQuery3 = "select Count(*) from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND REGPVT='P'";
            }
            else if (VAL == "Q")
            {
                if (brcode.Substring(0, 2) == "16")
                {
                    _sqlQuery3 = "select Count(*) from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='02' AND REGPVT!='Q'";
                }
                else if (brcode.Substring(0, 2) == "07")
                {
                    _sqlQuery3 = "select Count(*) from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='03' AND REGPVT!='Q'";
                }
                else if (brcode.Substring(0, 2) == "15" || brcode.Substring(0, 2) == "17")
                {
                    _sqlQuery3 = "select Count(*) from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='04' AND REGPVT!='Q'";
                }
                else
                {
                    _sqlQuery3 = "select Count(*) from REGISTRATION where STAT='A' and BRCODE='" + brcode + "' and INSCODE='" + inscode + "' AND SEM='06' AND REGPVT!='Q'";
                }
            }
            string _sqlQuery4 = "select Count(*) from SCRU where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "'";
            string _sqlQuery5 = "select Count(*) from SCRU where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "'";
            string _sqlQuery6 = "select Count(*) from SCRU where ISCOMPLETED is NULL and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "'";
            _sqlQuery = "SELECT (" + _sqlQuery1 + ") AS CON1,(" + _sqlQuery2 + ") AS CON2,(" + _sqlQuery3 + ") AS CON3,(" + _sqlQuery4 + ") AS CON4,(" + _sqlQuery5 + ") AS CON5,(" + _sqlQuery6 + ") AS CON6";
            CNT = COUNT(_sqlQuery);
            SPL1ST = CNT.Split('|');
            string _sqlQuery7 = "select Count(*) from REEVA where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "'";
            string _sqlQuery8 = "select Count(*) from REEVA where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "'";
            string _sqlQuery9 = "select Count(*) from REEVA where ISCOMPLETED is NULL and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "'";
            string _sqlQuery10 = "select Count(*) from BACKP where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "' AND TYPE='B'";
            string _sqlQuery11 = "select Count(*) from BACKP where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "' AND TYPE='B'";
            string _sqlQuery12 = "select Count(*) from BACKP where ISCOMPLETED is NULL and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "' AND TYPE='B'";
            _sqlQuery = "SELECT (" + _sqlQuery7 + ") AS CON1,(" + _sqlQuery8 + ") AS CON2,(" + _sqlQuery9 + ") AS CON3,(" + _sqlQuery10 + ") AS CON4,(" + _sqlQuery11 + ") AS CON5,(" + _sqlQuery12 + ") AS CON6";
            CNT = COUNT(_sqlQuery);
            SPL2ND = CNT.Split('|');
            string _sqlQuery13 = "select Count(*) from BACKP where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            string _sqlQuery14 = "select Count(*) from BACKP where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            string _sqlQuery15 = "select Count(*) from BACKP where ISCOMPLETED is NULL and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            string _sqlQuery16 = "select Count(*) from BACKP where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            string _sqlQuery17 = "select Count(*) from BACKP where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            string _sqlQuery18 = "select Count(*) from BACKP where ISCOMPLETED is NULL and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            _sqlQuery = "SELECT (" + _sqlQuery13 + ") AS CON1,(" + _sqlQuery14 + ") AS CON2,(" + _sqlQuery15 + ") AS CON3,(" + _sqlQuery16 + ") AS CON4,(" + _sqlQuery17 + ") AS CON5,(" + _sqlQuery18 + ") AS CON6";
            CNT = COUNT(_sqlQuery);
            SPL3RD = CNT.Split('|');
        }
        else
        {
            string _sqlQuery1 = "select Count(*) from REGISTRATION where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND STAT='A'";
            string _sqlQuery2 = "select Count(*) from REGISTRATION where " + CLM + "='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND STAT='A'";
            string _sqlQuery3 = "select Count(*) from REGISTRATION where " + CLM + " is NULL and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND STAT='A'";
            string _sqlQuery4 = "select Count(*) from SCRU where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "'";
            string _sqlQuery5 = "select Count(*) from SCRU where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "'";
            string _sqlQuery6 = "select Count(*) from SCRU where ISCOMPLETED is NULL and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "'";
            _sqlQuery = "SELECT (" + _sqlQuery1 + ") AS CON1,(" + _sqlQuery2 + ") AS CON2,(" + _sqlQuery3 + ") AS CON3,(" + _sqlQuery4 + ") AS CON4,(" + _sqlQuery5 + ") AS CON5,(" + _sqlQuery6 + ") AS CON6";
            CNT = COUNT(_sqlQuery);
            SPL1ST = CNT.Split('|');
            string _sqlQuery7 = "select Count(*) from REEVA where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "'";
            string _sqlQuery8 = "select Count(*) from REEVA where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "'";
            string _sqlQuery9 = "select Count(*) from REEVA where ISCOMPLETED is NULL and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "'";
            string _sqlQuery10 = "select Count(*) from BACKP where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND TYPE='B'";
            string _sqlQuery11 = "select Count(*) from BACKP where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND TYPE='B'";
            string _sqlQuery12 = "select Count(*) from BACKP where ISCOMPLETED is NULL and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND TYPE='B'";
            _sqlQuery = "SELECT (" + _sqlQuery7 + ") AS CON1,(" + _sqlQuery8 + ") AS CON2,(" + _sqlQuery9 + ") AS CON3,(" + _sqlQuery10 + ") AS CON4,(" + _sqlQuery11 + ") AS CON5,(" + _sqlQuery12 + ") AS CON6";
            CNT = COUNT(_sqlQuery);
            SPL2ND = CNT.Split('|');
            string _sqlQuery13 = "select Count(*) from BACKP where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            string _sqlQuery14 = "select Count(*) from BACKP where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            string _sqlQuery15 = "select Count(*) from BACKP where ISCOMPLETED is NULL and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            string _sqlQuery16 = "select Count(*) from BACKP where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            string _sqlQuery17 = "select Count(*) from BACKP where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            string _sqlQuery18 = "select Count(*) from BACKP where ISCOMPLETED is NULL and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND SEM='" + SEM + "' AND REGPVT='" + REGPVT + "' AND TYPE='S'";
            _sqlQuery = "SELECT (" + _sqlQuery13 + ") AS CON1,(" + _sqlQuery14 + ") AS CON2,(" + _sqlQuery15 + ") AS CON3,(" + _sqlQuery16 + ") AS CON4,(" + _sqlQuery17 + ") AS CON5,(" + _sqlQuery18 + ") AS CON6";
            CNT = COUNT(_sqlQuery);
            SPL3RD = CNT.Split('|');
        }
        //Enable & Disable Link
        for (int i = 1; i <= 15; i++)
        {
            if (i == 1)//ALL STUDENTS
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL1ST[0].ToString();
                dtdata.Rows[i - 1]["LNKNAME"] = "Click here to view";
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=AALL|" + SEM;
                //Admit Card
                if (ADMT.Contains(VAL) == true)
                {
                    dtdata.Rows[i - 1]["ADMNAME"] = "Download Admit Card";
                    dtdata.Rows[i - 1]["LNKADM"] = LNKURL + "TYP=ADM|" + SEM;
                }
                dtdata.Rows[i - 1]["MRKNAME"] = "Download Marks Sheet";
                dtdata.Rows[i - 1]["LNKMRK"] = LNKURL + "TYP=MRK|" + SEM;
            }
            else if (i == 2)//ALL APPROVED STUDENTS
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL1ST[1].ToString();
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=AAPP|" + SEM;

                if (REGIS.Contains(VAL) == true)
                {
                    if (REG != "N")
                    {
                        if (VAL == "P" || VAL == "Q") { dtdata.Rows[i - 1]["LNKNAME"] = ""; }
                        else { dtdata.Rows[i - 1]["LNKNAME"] = "Click here to Disapproved"; }
                    }
                }

                if (brcode.Substring(0, 2) == "16")
                {
                    dtdata.Rows[i - 1]["NOMNAME"] = "Download SEM/YEAR Nominal Roll";
                    dtdata.Rows[i - 1]["LNKNOMINAL"] = "~/Report/Nominal.aspx?TYP=" + SEM;
                }
                else
                {
                    dtdata.Rows[i - 1]["NOMNAME"] = "Download SEM/YEAR Nominal Roll";
                    dtdata.Rows[i - 1]["LNKNOMINAL"] = "~/Report/Nominal.aspx?TYP=" + SEM;

                }
                
                //dtdata.Rows[i - 1]["LNKNOMINAL"] = "~/Report/Reportdownload.aspx?STAT=REGNOMINAL|" + SEM;
                //Verification
                if (VER.Contains(VAL) == true)
                {
                    dtdata.Rows[i - 1]["ADMNAME"] = "Download Verification";
                    dtdata.Rows[i - 1]["LNKADM"] = LNKURL + "TYP=VER|" + SEM;
                }
                // CROSS LIST
                dtdata.Rows[i - 1]["MRKNAME"] = "Download Result Cross List";
                dtdata.Rows[i - 1]["LNKMRK"] = "~/Institute/Canidpass.aspx?DOWNLOAD=CROSS|" + SEM;
            }
            else if (i == 3)//ALL NOT-APPROVED STUDENTS
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL1ST[2].ToString();
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=ANAPP|" + SEM;
                if (REGIS.Contains(VAL) == true)
                {
                    if (REG != "N")
                    {
                        if (VAL == "P") { dtdata.Rows[i - 1]["SUMM"] = "READY TO MOVE"; dtdata.Rows[i - 1]["LNKNAME"] = ""; }
                        else if (VAL == "Q") { dtdata.Rows[i - 1]["SUMM"] = "READY TO MOVE"; dtdata.Rows[i - 1]["LNKNAME"] = ""; }
                        else { dtdata.Rows[i - 1]["LNKNAME"] = "Click here to Approved"; }
                    }
                }
                //List E
                if (LISTE.Contains(VAL) == true)
                {
                    dtdata.Rows[i - 1]["ADMNAME"] = "Download List-E(Practical)";
                   // dtdata.Rows[i - 1]["LNKADM"] = "~/Report/Liste_Practical.aspx?TYP=" + SEM;
                    dtdata.Rows[i - 1]["LNKADM"] = "https://ubter.ncampus.org/branch_login";
                }
                if(SEM=="P" || SEM=="Q")
                {
                    dtdata.Rows[i - 1]["MRKNAME"] = "Download Result Cross List(O)";
                    dtdata.Rows[i - 1]["LNKMRK"] = "~/Institute/Canidpass.aspx?DOWNLOAD=CROSS|" + SEM.Substring(0) + "O";

                }
                else
                {
                    dtdata.Rows[i - 1]["MRKNAME"] = "Download Result Cross List(O)";
                    dtdata.Rows[i - 1]["LNKMRK"] = "~/Institute/Canidpass.aspx?DOWNLOAD=CROSS|" + SEM.Substring(1) + "O";
                }
               
            }
            else if (i == 4)//ALL SCRUTINY STUDENTS *******************************************************************************************************************
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL1ST[3].ToString();
                dtdata.Rows[i - 1]["LNKNAME"] = "Click here to view";
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=SALL|" + SEM;
                //List D
                if (LISTD.Contains(VAL) == true)
                {
                    dtdata.Rows[i - 1]["ADMNAME"] = "Download List-D(Theory)";
                    //dtdata.Rows[i - 1]["LNKADM"] = "~/Report/Listd_Theory.aspx?TYP=" + SEM;
                    dtdata.Rows[i - 1]["LNKADM"] = "https://ubter.ncampus.org/branch_login";
                }
            }
            else if (i == 5)//ALL SCRUTINY APPROVED STUDENTS
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL1ST[4].ToString();
                if (REGIS.Contains(VAL) == true) { if (SCRU != "N") { dtdata.Rows[i - 1]["LNKNAME"] = "Click here to Disapproved"; } }//SCRU
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=SAPP|" + SEM;

                dtdata.Rows[i - 1]["NOMNAME"] = "Download Scrutiny Nominal Roll";
                dtdata.Rows[i - 1]["LNKNOMINAL"] = "~/Report/Nominalscru.aspx?TYP=" + SEM;
                //Scrutiny Cross List
                dtdata.Rows[i - 1]["MRKNAME"] = "Download Scrutiny Cross List";
                dtdata.Rows[i - 1]["LNKMRK"] = "~/Institute/Canidpass.aspx?DOWNLOAD=SCROSS|" + SEM;
                //Sessional List
                if (SESS.Contains(VAL) == true)
                {
                    dtdata.Rows[i - 1]["ADMNAME"] = "Upload Sessional";
                    //dtdata.Rows[i - 1]["LNKADM"] = "~/Report/List_Sem_Sess.aspx?TYP=" + SEM;
                    dtdata.Rows[i - 1]["LNKADM"] = "https://ubter.ncampus.org/branch_login";
                }
            }
            else if (i == 6)//ALL SCRUTINY NOT-APPROVED STUDENTS
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL1ST[5].ToString();
                if (REGIS.Contains(VAL) == true) { if (SCRU != "N") { dtdata.Rows[i - 1]["LNKNAME"] = "Click here to Approved"; } }//SCRU
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=SNAPP|" + SEM;
            }
            else if (i == 7)//ALL RE-EVALUATION STUDENTS *******************************************************************************************************************
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL2ND[0].ToString();
                dtdata.Rows[i - 1]["LNKNAME"] = "Click here to view";
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=RALL|" + SEM;
            }
            else if (i == 8)//ALL RE-EVALUATION APPROVED STUDENTS
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL2ND[1].ToString();
                if (REGIS.Contains(VAL) == true) { if (REEVA != "N") { dtdata.Rows[i - 1]["LNKNAME"] = "Click here to Disapproved"; } }//REEVA
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=RAPP|" + SEM;
                dtdata.Rows[i - 1]["NOMNAME"] = "Download Re-Evaluation Nominal Roll";
                dtdata.Rows[i - 1]["LNKNOMINAL"] = "~/Report/Nominalreeva.aspx?TYP=" + SEM;
                //RE-EVALUATION Cross List
                dtdata.Rows[i - 1]["MRKNAME"] = "Download Re-Evaluation Cross List";
                dtdata.Rows[i - 1]["LNKMRK"] = "~/Institute/Canidpass.aspx?DOWNLOAD=RCROSS|" + SEM;
            }
            else if (i == 9)//ALL RE-EVALUATION NOT-APPROVED STUDENTS
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL2ND[2].ToString();
                if (REGIS.Contains(VAL) == true) { if (REEVA != "N") { dtdata.Rows[i - 1]["LNKNAME"] = "Click here to Approved"; } }//REEVA
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=RNAPP|" + SEM;
            }
            else if (i == 10)//ALL BACK PAPER STUDENTS *******************************************************************************************************************
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL2ND[3].ToString();
                dtdata.Rows[i - 1]["LNKNAME"] = "Click here to view";
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=BALL|" + SEM;
            }
            else if (i == 11)//ALL BACK PAPER APPROVED STUDENTS
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL2ND[4].ToString();
                if (REGIS.Contains(VAL) == true) { if (BACKP != "N") { dtdata.Rows[i - 1]["LNKNAME"] = "Click here to Disapproved"; } }//BACKP
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=BAPP|" + SEM;
                dtdata.Rows[i - 1]["NOMNAME"] = "Download Back Paper Nominal Roll";
                dtdata.Rows[i - 1]["LNKNOMINAL"] = "~/Report/Nominalbackpaper.aspx?TYP=" + SEM;
            }
            else if (i == 12)//ALL BACK PAPER NOT-APPROVED STUDENTS
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL2ND[5].ToString();
                if (REGIS.Contains(VAL) == true) { if (BACKP != "N") { dtdata.Rows[i - 1]["LNKNAME"] = "Click here to Approved"; } }//BACKP
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=BNAPP|" + SEM;
            }
            else if (i == 13)//ALL SPECIAL BACK PAPER STUDENTS *******************************************************************************************************************
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL3RD[0].ToString();
                dtdata.Rows[i - 1]["LNKNAME"] = "Click here to view";
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=SBALL|" + SEM;

                //Special back Admit Card
                if (SBPADMT.Contains(VAL) == true)
                {
                    dtdata.Rows[i - 1]["ADMNAME"] = "Download Special Back Admit Card";
                    dtdata.Rows[i - 1]["LNKADM"] = LNKURL + "TYP=SADM|" + SEM;
                }


            }
            else if (i == 14)//ALL SPECIAL BACK PAPER APPROVED STUDENTS
            {
                if (REGIS.Contains(VAL) == true) { if (SBACKP != "N") { dtdata.Rows[i - 1]["LNKNAME"] = "Click here to Disapproved"; } }//SBACKP
                dtdata.Rows[i - 1]["COUNT"] = SPL3RD[1].ToString();
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=SBAPP|" + SEM;

                dtdata.Rows[i - 1]["NOMNAME"] = "Download Special Back Paper Nominal Roll";
                dtdata.Rows[i - 1]["LNKNOMINAL"] = "~/Report/Nominalsbackpaper.aspx?TYP=" + SEM;

                dtdata.Rows[i - 1]["MRKNAME"] = "Download SBP Cross List";
                dtdata.Rows[i - 1]["LNKMRK"] = "~/Institute/Canidpass.aspx?DOWNLOAD=SBPCROSS|" + SEM;

                //Special back Verification
                if (SBPVER.Contains(VAL) == true)
                {
                    dtdata.Rows[i - 1]["ADMNAME"] = "Download Special Back Verification";
                    dtdata.Rows[i - 1]["LNKADM"] = LNKURL + "TYP=SVER|" + SEM;
                }

            }
            else if (i == 15)//ALL SPECIAL BACK PAPER NOT-APPROVED STUDENTS
            {
                dtdata.Rows[i - 1]["COUNT"] = SPL3RD[2].ToString();
                dtdata.Rows[i - 1]["LNKURL"] = LNKURL + "TYP=SBNAPP|" + SEM;
                if (REGIS.Contains(VAL) == true) { if (SBACKP != "N") { dtdata.Rows[i - 1]["LNKNAME"] = "Click here to Approved"; } }
            }
        }

        if (VAL == "01") { Grd1.DataSource = dtdata; Grd1.DataBind(); }
        else if (VAL == "02") { Grd2.DataSource = dtdata; Grd2.DataBind(); }
        else if (VAL == "03") { Grd3.DataSource = dtdata; Grd3.DataBind(); }
        else if (VAL == "04") { Grd4.DataSource = dtdata; Grd4.DataBind(); }
        else if (VAL == "05") { Grd5.DataSource = dtdata; Grd5.DataBind(); }
        else if (VAL == "06") { Grd6.DataSource = dtdata; Grd6.DataBind(); }
        else if (VAL == "P") { Grd7.DataSource = dtdata; Grd7.DataBind(); }
        else if (VAL == "Q") { Grd8.DataSource = dtdata; Grd8.DataBind(); }
    }
    private DataTable ROWS()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("SRNO");
        dt.Columns.Add("CNAME");
        dt.Columns.Add("SUMM");
        dt.Columns.Add("LNKNAME");
        dt.Columns.Add("LNKURL");
        dt.Columns.Add("COUNT");
        dt.Columns.Add("NOMNAME");
        dt.Columns.Add("LNKNOMINAL");
        dt.Columns.Add("MRKNAME");
        dt.Columns.Add("LNKMRK");
        dt.Columns.Add("ADMNAME");
        dt.Columns.Add("LNKADM");
        DataRow dr = dt.NewRow();
        for (int i = 1; i <= 15; i++)
        {
            string SN = string.Empty;
            if (i < 10) { SN = "0" + i.ToString(); }
            else { SN = i.ToString(); }

            string TXT = string.Empty;
            if (i == 1) { TXT = "ALL REGISTERED STUDENT"; }
            else if (i == 2) { TXT = "ALL APPROVED STUDENT"; }
            else if (i == 3) { TXT = "ALL NOT-APPROVED STUDENT"; }
            else if (i == 4) { TXT = "SCRUTINY FORM REGISTERED STUDENT"; }
            else if (i == 5) { TXT = "SCRUTINY FORM APPROVED STUDENT"; }
            else if (i == 6) { TXT = "SCRUTINY FORM NOT-APPROVED STUDENT"; }
            else if (i == 7) { TXT = "RE-EVALUATION FORM REGISTERED STUDENT"; }
            else if (i == 8) { TXT = "RE-EVALUATION FORM APPROVED STUDENT"; }
            else if (i == 9) { TXT = "RE-EVALUATION FORM NOT-APPROVED STUDENT"; }
            else if (i == 10) { TXT = "BACK PAPER REGISTERED STUDENT"; }
            else if (i == 11) { TXT = "BACK PAPER APPROVED STUDENT"; }
            else if (i == 12) { TXT = "BACK PAPER NOT-APPROVED STUDENT"; }
            else if (i == 13) { TXT = "SPECIAL BACK PAPER REGISTERED STUDENT"; }
            else if (i == 14) { TXT = "SPECIAL BACK PAPER APPROVED STUDENT"; }
            else if (i == 15) { TXT = "SPECIAL BACK PAPER NOT-APPROVED STUDENT"; }
            dr["SRNO"] = SN;
            dr["SUMM"] = TXT;
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
        CNT = dt.Rows[0]["CON1"].ToString().Trim() + "|" + dt.Rows[0]["CON2"].ToString().Trim() + "|" + dt.Rows[0]["CON3"].ToString().Trim() + "|" + dt.Rows[0]["CON4"].ToString().Trim() + "|" + dt.Rows[0]["CON5"].ToString().Trim() + "|" + dt.Rows[0]["CON6"].ToString().Trim();
        return CNT;
    }
    protected void Lnkapproved_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Stulist.aspx?REG=APP", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
    protected void Lnknapproved_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Stulist.aspx?REG=NAPP", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
    protected void Lnkall_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Stulist.aspx?REG=ALL", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
}
