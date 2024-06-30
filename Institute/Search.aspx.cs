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
public partial class Search : System.Web.UI.Page
{
    public string BACK = string.Empty;
    public string STR = string.Empty;
    public string STUTAB = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] == null) { Response.Redirect("~/Default.aspx", false); }
            Txtregno.MaxLength = 11;
            Grd1.Visible = false;
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    private void bindsourcedata()
    {
        string _sqlQuery = string.Empty;
        DataTable dtdata = ROWS();
        Grd1.DataSource = dtdata; Grd1.DataBind();
        if (Grd1.Rows.Count == 0)
        {
            LblMessage.Text = "No Records Found.";
        }
        else { LblMessage.Text = ""; Grd1.Visible = true; }
    }
    private DataTable ROWS()
    {

        string INSCODE = string.Empty;
        string BRCODE = string.Empty;

        string cntquery = string.Empty;
        DataTable dt = new DataTable();
        dt.Columns.Add("FORMTYPE");
        dt.Columns.Add("CANDIDATEID");
        dt.Columns.Add("ROLL");
        dt.Columns.Add("STAT");
        dt.Columns.Add("VIEWNAME");
        dt.Columns.Add("VIEWURL");
        dt.Columns.Add("EDITNAME");
        dt.Columns.Add("EDITURL");

        string[] splins = Session["INSCODE"].ToString().Split('|');
        INSCODE = splins[0].ToString();
        if (Session["BRCODE"] != null) { string[] splbrc = Session["BRCODE"].ToString().Split('|'); BRCODE = splbrc[0].ToString(); }
        


        string _sqlQueryreg = string.Empty;
        string[] AllQueryParamreg = new string[1];
        BLL objbllreg = new BLL();
        for (int i = 0; i < 5; i++)
        {
            DataTable dtreg = new DataTable();
            string TBL = string.Empty;
            string LINKTYP = string.Empty;
            string TYPE = string.Empty;
            if (i == 0) { TBL = "REGISTRATION"; LINKTYP = "REGISTRATION"; }
            else if (i == 1) { TBL = "SCRU"; LINKTYP = "SCRUTINY"; }
            else if (i == 2) { TBL = "REEVA"; LINKTYP = "RE-EVALUATION"; }
            else if (i == 3) { TBL = "BACKP"; LINKTYP = "BACK PAPER"; TYPE = "B"; }
            else if (i == 4) { TBL = "BACKP"; LINKTYP = "SPECIAL BACK PAPER"; TYPE = "S"; }
            if (i == 3 || i == 4)
            {
                if (Session["BRCODE"] != null) { _sqlQueryreg = "SELECT * FROM " + TBL + " WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND TYPE='" + TYPE + "'"; }
                else { _sqlQueryreg = "SELECT * FROM " + TBL + " WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND INSCODE='" + INSCODE + "' AND TYPE='" + TYPE + "'"; }
            }
            else
            {
                if (Session["BRCODE"] != null) { _sqlQueryreg = "SELECT * FROM " + TBL + " WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "'"; }
                else { _sqlQueryreg = "SELECT * FROM " + TBL + " WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND INSCODE='" + INSCODE + "'"; }
            }
            AllQueryParamreg[0] = _sqlQueryreg;
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["FORMTYPE"] = LINKTYP;
                dr["CANDIDATEID"] = dtreg.Rows[0]["CANDIDATEID"].ToString();
                dr["ROLL"] = dtreg.Rows[0]["ROLL"].ToString();
                dr["VIEWNAME"] = "Click here to View";
                if (i == 0)
                {
                    Session["INSCODE"] = dtreg.Rows[0]["INSCODE"].ToString();
                    Session["BRCODE"] = dtreg.Rows[0]["BRCODE"].ToString();
                    Session["UTYPE"] = "B";

                    Lblins.Text = dtreg.Rows[0]["INSNAME"].ToString();
                    Lblbranch.Text = dtreg.Rows[0]["BRNAME"].ToString();
                    Lblsem.Text = dtreg.Rows[0]["SEM"].ToString();
                    Lblcname.Text = dtreg.Rows[0]["CNAME"].ToString();
                    Lblfname.Text = dtreg.Rows[0]["FNAME"].ToString();

                    string REGPVT= dtreg.Rows[0]["REGPVT"].ToString();
                    if (REGPVT == "R") { REGPVT = "Regular"; STUTAB = "Student will be Show in - SEM/YEAR TAB"; }
                    else if (REGPVT == "P") { REGPVT = "Private"; STUTAB = "Student will be Show in - PRIVATE TAB"; }
                    else if (REGPVT == "Q") { REGPVT = "Passed"; STUTAB = "Student will be Show in - PASSED/SPECIAL TAB"; }
                    Lbltype.Text = REGPVT;

                    dr["VIEWURL"] = "~/Report/View.aspx?AAAAA=" + dtreg.Rows[0]["CANDIDATEID"].ToString();
                    dr["EDITNAME"] = "Edit";
                    dr["EDITURL"] = "~/Student/Status.aspx?AAAAA=" + dtreg.Rows[0]["CANDIDATEID"].ToString();
                }
                else if (i == 1)
                {
                    dr["VIEWURL"] = "~/Report/Receiptscrutiny.aspx?AAAAA=" + dtreg.Rows[0]["CANDIDATEID"].ToString();
                    dr["EDITNAME"] = "Edit";
                    dr["EDITURL"] = "~/Student/Scrutiny.aspx?AAAAA=" + dtreg.Rows[0]["CANDIDATEID"].ToString() + "|" + dtreg.Rows[0]["ROLL"].ToString();
                }
                else if (i == 2)
                {
                    dr["VIEWURL"] = "~/Report/Receiptreeva.aspx?AAAAA=" + dtreg.Rows[0]["CANDIDATEID"].ToString();
                    dr["EDITNAME"] = "Edit";
                    dr["EDITURL"] = "~/Student/Re_Evaluation.aspx?AAAAA=" + dtreg.Rows[0]["CANDIDATEID"].ToString() + "|" + dtreg.Rows[0]["ROLL"].ToString();
                }
                else if (i == 3)
                {
                    dr["VIEWURL"] = "~/Report/Receiptbackpaper.aspx?AAAAA=" + dtreg.Rows[0]["CANDIDATEID"].ToString();
                    dr["EDITNAME"] = "Edit";
                    dr["EDITURL"] = "~/Institute/Backpaper.aspx?AAAAA=BACK|" + dtreg.Rows[0]["CANDIDATEID"].ToString();
                }
                else if (i == 4)
                {
                    dr["VIEWURL"] = "~/Report/Receiptsbackpaper.aspx?AAAAA=" + dtreg.Rows[0]["CANDIDATEID"].ToString();
                    dr["EDITNAME"] = "Edit";
                    dr["EDITURL"] = "~/Institute/Backpaper.aspx?AAAAA=SBACK|" + dtreg.Rows[0]["CANDIDATEID"].ToString();
                }

                string STAT = string.Empty;
                if (i == 0)
                {
                    string SEM = dtreg.Rows[0]["SEM"].ToString();
                    string CLM2 = string.Empty;
                    if (SEM == "01") { CLM2 = "SEMCOM1"; }
                    else if (SEM == "02") { CLM2 = "SEMCOM2"; }
                    else if (SEM == "03") { CLM2 = "SEMCOM3"; }
                    else if (SEM == "04") { CLM2 = "SEMCOM4"; }
                    else if (SEM == "05") { CLM2 = "SEMCOM5"; }
                    else if (SEM == "06") { CLM2 = "SEMCOM6"; }

                    STAT = dtreg.Rows[0][CLM2].ToString();
                    if (STAT == "True" || STAT == "1") { STAT = "Approved"; }
                    else { STAT = "Not-Approved"; }
                    Lblsem.Text = Lblsem.Text + " ( " + STAT + " )";

                }
                else
                {
                    STAT = dtreg.Rows[0]["ISCOMPLETED"].ToString();
                    if (STAT == "True" || STAT == "1") { STAT = "Approved"; }
                    else { STAT = "Not-Approved"; }
                }
                dr["STAT"] = STAT;
                dt.Rows.Add(dr);
                dr = dt.NewRow();

                if (i == 0) { Getback(dtreg.Rows[0]["CANDIDATEID"].ToString()); }
            }

        }
        return dt;
    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] == null) { Response.Redirect("~/Default.aspx", false); }
            Lblins.Text = "Institute Name";
            Lblbranch.Text = "Branch Name";
            bindsourcedata();
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
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
                        if (STUTYPE == "N" && r == 0)
                        {
                            SGPA = Convert.ToDecimal(dtrec.Rows[r]["SGPA"].ToString().Trim());
                        }
                        for (int i = 1; i <= SUBCNT; i++)
                        {//THEORY & PRACTICAL MARKS
                            string SUB = dtrec.Rows[r]["SUB" + i.ToString()].ToString().Trim();
                            if (SUB != "")
                            {//SUBJECT FOUND
                                string TB = dtrec.Rows[r]["GBT" + i.ToString()].ToString().Trim();
                                if (TB == "" || TB == "G")
                                {
                                    if (STUTYPE == "N") { if (SGPA > 4) { Sublist.Remove(SUB + "T"); } }
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
        for (int s = 0; s < Sublist.Count; s++)
        {
            if (s == 0) { BACK = Sublist[s].ToString(); }
            else { BACK = BACK + ", " + Sublist[s].ToString(); }
        }
        STR = STR + ("<tr>");
        if (Sublist.Count > 0) { STR = STR + ("<td style='background-color: #FF0000; color: #FFFFFF; font-size: 15px' valign=\"top\" align=\"center\"><b>Remaining Subject = " + Sublist.Count.ToString() + "</b>&nbsp;|&nbsp; " + BACK + "</td>"); }
        else { STR = STR + ("<td style='background-color: #4169E1; color: #FFFFFF; font-size: 15px' valign=\"top\" align=\"center\"><b>No Back</b></td>"); }
        STR = STR + ("</tr>");


    }
}