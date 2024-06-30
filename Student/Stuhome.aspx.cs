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
using System.Data;

public partial class Stuhome : System.Web.UI.Page
{
    public string ROLL = string.Empty;
    public string CANDIDATEID = string.Empty;
    public string CNAME = string.Empty;
    public string FNAME = string.Empty;
    public string DOB = string.Empty;
    public string INSNAME = string.Empty;
    public string BRNAME = string.Empty;
    public string SHIFT = string.Empty;
    public string SEM = string.Empty;
    public string REGPVTNM = string.Empty;
    public string BACK = string.Empty;
    public string BackStatus = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Session["ID"] != null)
            {
                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                string _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID=" + Session["ID"].ToString().Trim();
                AllQueryParam[0] = _sqlQuery;
                BLL objbllLogin = new BLL();
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);

                if (dt.Rows.Count > 0)
                {
                    BackStatus = "N";
                    ROLL = dt.Rows[0]["ROLL"].ToString().TrimEnd();
                    CANDIDATEID = dt.Rows[0]["CANDIDATEID"].ToString().TrimEnd();
                    CNAME = dt.Rows[0]["CNAME"].ToString().TrimEnd();
                    FNAME = dt.Rows[0]["FNAME"].ToString().TrimEnd();
                    DOB = dt.Rows[0]["DOB"].ToString().TrimEnd();
                    INSNAME = dt.Rows[0]["INSNAME"].ToString().TrimEnd();
                    BRNAME = dt.Rows[0]["BRNAME"].ToString().TrimEnd();
                    SHIFT = dt.Rows[0]["SHIFT"].ToString().TrimEnd();
                    if (SHIFT == "I") { SHIFT = "First(I)"; }
                    else if (SHIFT == "II") { SHIFT = "Second(II)"; }
                    Imgph.ImageUrl = "http://ubterex.in/Upload/Photo/" + CANDIDATEID + "P.jpg";
                    Imgsign.ImageUrl = "http://ubterex.in/Upload/Sign/" + CANDIDATEID + "S.jpg";
                    SEM = dt.Rows[0]["SEM"].ToString();
                    string REGPVT = dt.Rows[0]["REGPVT"].ToString();


                    //Active/De-Active Scrutiny and Re-Evaluation
                    string INSCODE = dt.Rows[0]["INSCODE"].ToString().TrimEnd();
                    string BRCODE = dt.Rows[0]["BRCODE"].ToString().TrimEnd();

                    DataTable dtscru = new DataTable();
                    _sqlQuery = "SELECT * FROM BRLOGIN where INSCODE='" + INSCODE + "' and BRCODE='" + BRCODE + "'";
                    AllQueryParam[0] = _sqlQuery;
                    objbllLogin.QUERYBLL(ref dtscru, AllQueryParam);

                   string SCRU = dtscru.Rows[0]["SCRU"].ToString();
                   string REEVA = dtscru.Rows[0]["REEVA"].ToString();
                   string REGIS = dtscru.Rows[0]["SEM"].ToString();

                   string SM = SEM;
                   if (REGPVT == "P") { SM = "P"; REGPVTNM = "Private"; }
                   else if (REGPVT == "Q") { SM = "Q"; REGPVTNM = "Passed/Special"; }
                   else if (REGPVT == "R") { REGPVTNM = "Regular"; }
                   if (REGIS.Contains(SM) == true)
                   {
                       if (SCRU != "N") { TRSCRU.Visible = true; }
                       if (REEVA != "N") { TRREEVA.Visible = true; }
                   }

                    if (SEM == "01") { SEM = "First (01)"; }
                    if (SEM == "02") { SEM = "Second (02)"; }
                    if (SEM == "03") { SEM = "Third (03)"; }
                    if (SEM == "04") { SEM = "Fourth (04)"; }
                    if (SEM == "05") { SEM = "Fifth (05)"; }
                    if (SEM == "06") { SEM = "Sixth (06)"; }
                    Lnkmarksheet.NavigateUrl = "~/Report/Marksheet.aspx?AAAAA=STU|" + ROLL;
                    string ISREG = dt.Rows[0]["ISREG"].ToString().TrimEnd();
                    string ISQUA = dt.Rows[0]["ISQUA"].ToString().TrimEnd();
                    string ISADD = dt.Rows[0]["ISADD"].ToString().TrimEnd();
                    string ISPH = dt.Rows[0]["ISPH"].ToString().TrimEnd();
                    if (ISREG == "True" && ISQUA == "True" && ISADD == "True" && ISPH == "True")
                    {
                        Imgpending.Visible = false;
                        
                    }
                    Getback(CANDIDATEID);
                }
            }
            else { Response.Redirect("Login.aspx", false); }
        }
        catch (Exception ex) { Response.Write(ex.Message); }
    }
    protected void Lnklogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ID"] = null;
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("Login.aspx", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
    private void Getback(string CANDIDATEID)
    {

        DataTable dtr = new DataTable();
        dtr.Columns.Add("REGNO");
        dtr.Columns.Add("SUB");
        DataRow dr = dtr.NewRow();
        int CNT = 0;
        List<string> Sublist = new List<string>();
        string SEMYEAR = string.Empty;
        //Get Registration Details
        string[] AllQueryParam = new string[1];
        BLL objbllLogin = new BLL();
        string _sqlQuery = "SELECT * FROM REGISTRATION where CANDIDATEID='" + CANDIDATEID + "'";
        DataTable dttyp = new DataTable();
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dttyp, AllQueryParam);
        string SEM = dttyp.Rows[0]["SEM"].ToString();
        string REGPVT = dttyp.Rows[0]["REGPVT"].ToString();
        string SESS = dttyp.Rows[0]["STRTSESS"].ToString();
        string BRCODE = dttyp.Rows[0]["BRCODE"].ToString();
        string BRANCH = dttyp.Rows[0]["BRNAME"].ToString();
        string SMMM = dttyp.Rows[0]["SEM"].ToString();
        string GRP = dttyp.Rows[0]["GRP"].ToString();
        string ROLL = dttyp.Rows[0]["ROLL"].ToString();
        string ITIPASS = dttyp.Rows[0]["ITIPASS"].ToString();
        string STUTYPE = dttyp.Rows[0]["STUTYPE"].ToString();
        string BR = BRANCH.Substring(0, 2).ToString();
        if (BR == "16") { CNT = 1; }
        else if (BR == "07") { CNT = 4; }
        else { CNT = 7; }
        //Get Subject
        string brr = BRCODE.Substring(0, 2).ToString();
        string PVTTBL = string.Empty;
        if (STUTYPE == "N")
        {
            _sqlQuery = "SELECT * FROM SUBN where BRCODE='" + brr + "' AND SEM<=" + SEM + " ORDER BY SEM,SUBCODE ASC"; 
            SEMYEAR = "NSEMESTER";
            PVTTBL = "NPRIVAT";
        }
        else
        {
            _sqlQuery = "SELECT * FROM SUBJ where BRCODE='" + brr + "' AND SEM<=" + SEM + " ORDER BY SEM,SUBCODE ASC"; 
            SEMYEAR = "SEMESTER";
            PVTTBL = "PRIVAT";
        }
        DataTable dt = new DataTable();
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count == 0) { return; }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string TYPE = dt.Rows[i]["TYPE"].ToString().Trim();
            string SSEM = dt.Rows[i]["SEM"].ToString().Trim();
            string SUBC = dt.Rows[i]["SUBCODE"].ToString().Trim();
            if (TYPE.Length == 2)
            {
                Sublist.Add(SUBC + "T");
                Sublist.Add(SUBC + "P");
            }
            else
            {
                Sublist.Add(SUBC + TYPE);
            }
            if (GRP == "A")
            {
                if (SSEM == "01" || SSEM == "02") { Sublist.Remove(SUBC + "P"); }
                if (SSEM == "02") { Sublist.Remove(SUBC + "T"); }
            }
            if (ITIPASS == "Y") { if (SUBC == "1005" || SUBC == "1006" || SUBC == "991006") { Sublist.Remove(SUBC + "T"); } }
        }
        //Get Attempt Papers
        for (int z = 1; z <= CNT; z++)
        {
            string TBL = SEMYEAR + z.ToString();
            if (brr != "16") { if (z == CNT) { TBL = PVTTBL; } }
            else { TBL = "PH"; }
            _sqlQuery = "select * from " + TBL + " where ROLL='" + ROLL + "' ORDER BY SUBSTRING(SESS,4,4) ASC, SUBSTRING(SESS,1,2) ASC";
            DataTable dtrec = new DataTable();
            AllQueryParam[0] = _sqlQuery;
            objbllLogin.QUERYBLL(ref dtrec, AllQueryParam);
            if (dtrec.Rows.Count > 0)
            {
                BackStatus = "Y";
                //All Subject
                for (int r = 0; r < dtrec.Rows.Count; r++)
                {
                    int SUBCNT = 12;
                    int BACKTCNT = 17;
                    int BACKPCNT = 7;
                    if (TBL != PVTTBL)
                    {
                        if (brr != "16") { if (z <= 2) { SUBCNT = 10; } }
                        else { SUBCNT = 6; BACKTCNT = 2; BACKPCNT = 2; }

                        decimal SGPA = 0;
                        if (STUTYPE == "N" && r == 0 && brr != "16")
                        {
                            SGPA = Convert.ToDecimal(dtrec.Rows[r]["SGPA"].ToString().Trim());
                        }
                        for (int i = 1; i <= SUBCNT; i++)
                        {//THEORY & PRACTICAL MARKS
                            string SUB = dtrec.Rows[r]["SUB" + i.ToString()].ToString().Trim();
                            if (SUB != "")
                            {//SUBJECT FOUND
                                string TB = dtrec.Rows[r]["GBT" + i.ToString()].ToString().Trim();
                                if (TB == ""|| TB == "G")
                                {
                                    if (STUTYPE == "N" && brr != "16") 
                                    { 
                                        //if (SGPA > 4) 
                                        //{ 
                                            Sublist.Remove(SUB + "T"); 
                                        //} 
                                    }
                                    else { Sublist.Remove(SUB + "T"); }
                                }
                                string PB = dtrec.Rows[r]["GBP" + i.ToString()].ToString().Trim();
                                if (PB == "" || PB == "G")
                                {
                                    Sublist.Remove(SUB + "P");
                                }
                            }
                        }
                    }
                    if (z > 1 || GRP == "A" || brr == "16")
                    {
                        //Back Theory
                        for (int i = 1; i <= BACKTCNT; i++)
                        {
                            string SUB = dtrec.Rows[r]["BPAPT" + i.ToString()].ToString().Trim();
                            if (SUB != "")
                            {//SUBJECT FOUND
                                string TB = dtrec.Rows[r]["BT" + i.ToString()].ToString().Trim();
                                if (TB == "" || TB == "G")
                                {
                                    Sublist.Remove(SUB + "T");
                                }
                            }
                        }
                        //Back Practical
                        for (int i = 1; i <= BACKPCNT; i++)
                        {
                            string SUB = dtrec.Rows[r]["BPAPP" + i.ToString()].ToString().Trim();
                            if (SUB != "")
                            {//SUBJECT FOUND
                                string PB = dtrec.Rows[r]["BP" + i.ToString()].ToString().Trim();
                                if (PB == "" || PB == "G")
                                {
                                    Sublist.Remove(SUB + "P");
                                }
                            }
                        }
                    }
                }
            }
        }

        if (BackStatus == "Y")
        {
            for (int s = 0; s < Sublist.Count; s++)
            {
                if (s == 0) { BACK = Sublist[s].ToString(); }
                else { BACK = BACK + ", " + Sublist[s].ToString(); }
            }
            BACK = "<b style='color: #FF0000;'>" + BACK + "</br>" + "Total Back = " + Sublist.Count.ToString() + "</b>";
            if (Sublist.Count == 0) { BACK = "No Back"; }
        }
    }
}