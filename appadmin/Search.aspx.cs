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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null && Session["USER"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Session["ADMIN"] == null && Session["USER"] != null)
            {
                Txtregno.MaxLength = 11;
                Grd1.Visible = false;
                Lnkadmitcard.Visible = false;
                Lnkverification.Visible = false;
                Rdoapprove.Visible = false;
                Rdodapprove.Visible = false;
                Rdodelete.Visible = false;
            }
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
        else { LblMessage.Text = ""; }
    }
    private DataTable ROWS()
    {
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
            { _sqlQueryreg = "SELECT * FROM " + TBL + " WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND TYPE='" + TYPE + "'"; }
            else
            { _sqlQueryreg = "SELECT * FROM " + TBL + " WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "')"; }
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
                    Lblsem.Text = dtreg.Rows[0]["SEM"].ToString() + "/" + dtreg.Rows[0]["REGPVT"].ToString();
                    Lblcname.Text = dtreg.Rows[0]["CNAME"].ToString();
                    Lblfname.Text = dtreg.Rows[0]["FNAME"].ToString();

                    Lnkmarksheet.NavigateUrl = "~/Report/Marksheet.aspx?AAAAA=STU|" + dtreg.Rows[0]["CANDIDATEID"].ToString();

                    Lnkadmitcard.NavigateUrl = "~/Report/Admitcard.aspx?AAAAA=" + dtreg.Rows[0]["CANDIDATEID"].ToString();

                    Lnkverification.NavigateUrl = "~/Report/Verification.aspx?AAAAA=" + dtreg.Rows[0]["CANDIDATEID"].ToString();


                    //dr["VIEWURL"] = "~/Report/ReportDownload.aspx?STAT=" + dtreg.Rows[0]["CANDIDATEID"].ToString();
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
            Lblins.Text = "Institute Name";
            Lblbranch.Text = "Branch Name";
            if (Session["ADMIN"] == null && Session["USER"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            else
            {
                bindsourcedata();

            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null && Session["USER"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            string TYPE = Grd1.DataKeys[e.RowIndex].Value.ToString();

            string _sqlQuery = string.Empty;
            if (TYPE=="REGISTRATION")//Registration
            {
                string CLM2 = string.Empty;
                if (Lblsem.Text == "01") {  CLM2 = "SEMCOM1";  }
                else if (Lblsem.Text == "02") {  CLM2 = "SEMCOM2"; }
                else if (Lblsem.Text == "03") {  CLM2 = "SEMCOM3";  }
                else if (Lblsem.Text == "04") {  CLM2 = "SEMCOM4";  }
                else if (Lblsem.Text == "05") {  CLM2 = "SEMCOM5";  }
                else if (Lblsem.Text == "06") {  CLM2 = "SEMCOM6"; }

                if (Rdodapprove.Checked == true) { _sqlQuery = "UPDATE REGISTRATION SET " + CLM2 + "=NULL WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "')"; }
                else if (Rdoapprove.Checked == true) { _sqlQuery = "UPDATE REGISTRATION SET " + CLM2 + "='1' WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "')"; }
                else
                {
                    LblMessage.Text = "Registration will not be Delete.";
                    return;
                }
            }
            else if (TYPE == "SCRUTINY")//Scrutiny
            {
                if (Rdodapprove.Checked == true) { _sqlQuery = "UPDATE SCRU SET ISCOMPLETED=NULL WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "')"; }
                else if (Rdoapprove.Checked == true) { _sqlQuery = "UPDATE SCRU SET ISCOMPLETED='1' WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "')"; }
                else if (Rdodelete.Checked == true) { _sqlQuery = "DELETE FROM SCRU WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "')"; }
                else { return; }
            }
            else if (TYPE == "RE-EVALUATION")//Re-Evaluation
            {
                if (Rdodapprove.Checked == true) { _sqlQuery = "UPDATE REEVA SET ISCOMPLETED=NULL WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "')"; }
                else if (Rdoapprove.Checked == true) { _sqlQuery = "UPDATE REEVA SET ISCOMPLETED='1' WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "')"; }
                else if (Rdodelete.Checked == true) { _sqlQuery = "DELETE FROM REEVA WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "')"; }
                else { return; }
            }
            else if (TYPE == "BACK PAPER")//BACK Paper
            {
                if (Rdodapprove.Checked == true) { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED=NULL WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND TYPE='B'"; }
                else if (Rdoapprove.Checked == true) { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED='1' WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND TYPE='B'"; }
                else if (Rdodelete.Checked == true) { _sqlQuery = "DELETE FROM BACKP WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND TYPE='B'"; }
                else { return; }
            }
            else if (TYPE == "SPECIAL BACK PAPER")//Special BACK Paper
            {
                if (Rdodapprove.Checked == true) { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED=NULL WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND TYPE='S'"; }
                else if (Rdoapprove.Checked == true) { _sqlQuery = "UPDATE BACKP SET ISCOMPLETED='1' WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND TYPE='S'"; }
                else if (Rdodelete.Checked == true) { _sqlQuery = "DELETE FROM BACKP WHERE (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND TYPE='S'"; }
                else { return; }
            }
            BLL objbllLogin = new BLL();
            string result = objbllLogin.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                LblMessage.Text = "Successfully Completed.";
                bindsourcedata();
            }
            else { LblMessage.Text = "Failed."; }
        }
        catch (Exception ex) { LblMessage.Text = "Please Try after some times."; }
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


        //Get Exam Apeared OR NOT
        int GG = 0;
        string TBLCHK = "SEMESTER"+Convert.ToInt32(SMMM);
        if (STUTYPE == "N") { TBLCHK = "N" + TBLCHK; }
        if (BR == "16") { _sqlQuery = "SELECT * FROM PH where ROLL='" + ROLL + "' AND SMCODE='" + SMMM.Substring(1, 1) + "'"; }
        else { _sqlQuery = "SELECT * FROM " + TBLCHK + " where ROLL='" + ROLL + "'"; }
        DataTable dtchk = new DataTable();
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtchk, AllQueryParam);
        if (dtchk.Rows.Count >0) { GG = 1; }



        //Get Subject
        string brr = BRCODE.Substring(0, 2).ToString();
        string PVTTBL = string.Empty;
        if (STUTYPE == "N")
        {
            if (GG == 1) { _sqlQuery = "SELECT * FROM SUBN where BRCODE='" + brr + "' AND SEM<=" + SEM + " ORDER BY SEM,SUBCODE ASC"; }
            else { _sqlQuery = "SELECT * FROM SUBN where BRCODE='" + brr + "' AND SEM<" + SEM + " ORDER BY SEM,SUBCODE ASC"; }
            SEMYEAR = "NSEMESTER";
            PVTTBL = "NPRIVAT";
        }
        else
        {
            if (GG == 1) { _sqlQuery = "SELECT * FROM SUBJ where BRCODE='" + brr + "' AND SEM<=" + SEM + " ORDER BY SEM,SUBCODE ASC"; }
            else { _sqlQuery = "SELECT * FROM SUBJ where BRCODE='" + brr + "' AND SEM<" + SEM + " ORDER BY SEM,SUBCODE ASC"; }
            SEMYEAR = "SEMESTER";
            PVTTBL = "PRIVAT";
        }
        DataTable dt = new DataTable();
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
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
                                if (TB == "" || TB == "G")
                                {
                                    if (STUTYPE == "N" && brr != "16") { if (SGPA > 4) { Sublist.Remove(SUB + "T"); } }
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
        if (Sublist.Count > 0) { STR = STR + ("<td style='background-color: #FF0000; color: #FFFFFF; font-size: 15px' valign=\"top\" align=\"center\"><b>Remaining Back = " + Sublist.Count.ToString() + "</b>&nbsp;|&nbsp; " + BACK + "</td>"); }
        else { STR = STR + ("<td style='background-color: #4169E1; color: #FFFFFF; font-size: 15px' valign=\"top\" align=\"center\"><b>No Back</b></td>"); }
        STR = STR + ("</tr>");


    }
}