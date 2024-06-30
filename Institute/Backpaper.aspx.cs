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
public partial class Backpaper : System.Web.UI.Page
{
    public string Comp = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["BRCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            if (Request.QueryString["AAAAA"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (!IsPostBack)
            {
                string[] SPL = Request.QueryString["AAAAA"].ToString().Split('|');
                string STUTYP = SPL[0].ToString();
                string CANDIDATEID = SPL[1].ToString();
                //Check Back Paper Form Status
                string[] splins = Session["INSCODE"].ToString().Split('|');
                string INSCODE = splins[0].ToString();
                string[] splbrc = Session["BRCODE"].ToString().Split('|');
                string BRCODE = splbrc[0].ToString();
                DataTable dtreg = new DataTable();
                string[] AllQueryParam = new string[1];
                BLL objbll = new BLL();
                string _sqlQuery = "SELECT * FROM BRLOGIN where INSCODE='" + INSCODE + "' and BRCODE='" + BRCODE + "'";
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dtreg, AllQueryParam);
                if (dtreg.Rows.Count == 0) { Response.Redirect("~/Error.aspx", false); }
                string BACKP = dtreg.Rows[0]["BACKP"].ToString();
                string SBACKP = dtreg.Rows[0]["SBACKP"].ToString();
                string SEMBR = dtreg.Rows[0]["SEM"].ToString();
               

                DataTable dtr = new DataTable();
                dtr.Columns.Add("REGNO");
                dtr.Columns.Add("SUB");
                DataRow dr = dtr.NewRow();
                _sqlQuery = "SELECT * FROM REGISTRATION where CANDIDATEID='" + CANDIDATEID + "'";
                DataTable dttyp = new DataTable();
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dttyp, AllQueryParam);
                if (dttyp.Rows.Count == 0) { Response.Redirect("~/Error.aspx", false); }
                string SEM = dttyp.Rows[0]["SEM"].ToString();
                string REGPVT = dttyp.Rows[0]["REGPVT"].ToString();
                //if (REGPVT == "P" || REGPVT == "Q") { SEM = REGPVT; }

                //if ((BACKP == "N" && STUTYP == "BACK") || (SEMBR.Contains(SEM) == false)) { Response.Redirect("~/Error.aspx", false); }
                //if ((SBACKP == "N" && STUTYP == "SBACK") || (SEMBR.Contains(SEM) == false)) { Response.Redirect("~/Error.aspx", false); }
                Getback(CANDIDATEID);
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string _sqlQuery = string.Empty;
            BLL objbll = new BLL();
            string[] AllQueryParam = new string[1];
            if (Chksem2.Checked == false) { LblMessage.Text = "Please check mark on checkbox."; return; }
            int FEEBACK = 0;
            string SUB = string.Empty;
            string SUBN = string.Empty;
            string SESS = Getsession();
            int n1 = 0;
            int n2 = 0;
            string TYP = "B";
            foreach (GridViewRow gvrow in Grdsub.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("Cbsub");
                if (chk != null & chk.Checked)
                {
                    FEEBACK = FEEBACK + 200;
                    if (n1 == 0) { SUB = chk.Text; }
                    else
                    {
                        SUB = SUB + "|" + chk.Text;
                    }
                    n1++;
                }
                else
                {
                    if (n2 == 0) { SUBN = chk.Text; }
                    else
                    {
                        SUBN = SUBN + "|" + chk.Text;
                    }
                    n2++;
                }
            }
            string[] SPL = Request.QueryString["AAAAA"].ToString().Split('|');
            string STUTYP = SPL[0].ToString();
            string CANDIDATEID = SPL[1].ToString();

            if (STUTYP == "SBACK") { FEEBACK = FEEBACK + 530; TYP = "S"; }
            if (n1 == 0) { LblMessage.Text = "Please select atleast one subject."; return; }
            DataTable dt = new DataTable();
            _sqlQuery = "select * from REGISTRATION where CANDIDATEID='" + CANDIDATEID + "'";
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dt, AllQueryParam);
            if (dt.Rows.Count == 0) { LblMessage.Text = "Registration Not Found."; return; }
            _sqlQuery = "select * from BACKP where CANDIDATEID='" + CANDIDATEID + "' AND SUBA='" + SUB + "' AND STAT='A'"; 
            DataTable dtb = new DataTable();
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dtb, AllQueryParam);
            if (dtb.Rows.Count == 0)
            {
                _sqlQuery = "insert into BACKP(CANDIDATEID,ROLL,INSCODE,INSNAME,BRCODE,BRNAME,SHIFT,CNAME,FNAME,DOB,SEM,SUBA,SUBN,TYPE,FEE,ISCOMPLETED,SESS,STUTYPE,REGPVT,STAT,UPDATEDON) Values('" + dt.Rows[0]["CANDIDATEID"].ToString() + "','" + dt.Rows[0]["ROLL"].ToString() + "','" + dt.Rows[0]["INSCODE"].ToString() + "','" + dt.Rows[0]["INSNAME"].ToString() + "','" + dt.Rows[0]["BRCODE"].ToString() + "','" + dt.Rows[0]["BRNAME"].ToString() + "','" + dt.Rows[0]["SHIFT"].ToString() + "','" + dt.Rows[0]["CNAME"].ToString() + "','" + dt.Rows[0]["FNAME"].ToString() + "','" + dt.Rows[0]["DOB"].ToString() + "','" + dt.Rows[0]["SEM"].ToString() + "','" + SUB + "','" + SUBN + "','" + TYP + "','" + FEEBACK + "','1','" + SESS + "','" + dt.Rows[0]["STUTYPE"].ToString() + "','" + dt.Rows[0]["REGPVT"].ToString() + "','A',GETDATE())";
                string result = objbll.ONLYQUERYBLL(_sqlQuery);
                if (result == "1-1")
                {
                    LblMessage.Text = "BACK PAPER FORM SUBMITTED SUCCESSFULLY.";
                    Grdsub.Visible = false;
                    Btnsubmit.Visible = false;
                    Comp = "SUBMITTED BACK PAPER APPLICATION FORM.</br>NOT APPROVED BY H.O.D.";
                }
                else { LblMessage.Text = "NOT SUBMITTED BACK PAPER APPLICATION FORM."; }
            }
            else { LblMessage.Text = "Already Registered for Back Paper."; }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    private string Getsession()
    {
        //Get Regsession
        string SESS = string.Empty;
        DataTable dtsess = new DataTable();
        string _sqlQueryreg = "select * FROM FORMSESS WHERE SESSNAME='FORM'";
        BLL objbllreg = new BLL();
        string[] AllQueryParamreg = new string[1];
        AllQueryParamreg[0] = _sqlQueryreg;
        objbllreg.QUERYBLL(ref dtsess, AllQueryParamreg);
        if (dtsess.Rows.Count > 0)
        {
            SESS = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
        }
        return SESS;
    }
    //Actual back
    private void Getback(string CANDIDATEID)
    {
        string[] SPL = Request.QueryString["AAAAA"].ToString().Split('|');
        string STUTYP = SPL[0].ToString();

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
        string TBLCHK = "SEMESTER" + Convert.ToInt32(SMMM);
        if (STUTYPE == "N") { TBLCHK = "N" + TBLCHK; }
        if (BR == "16") { _sqlQuery = "SELECT * FROM PH where ROLL='" + ROLL + "' AND SMCODE='" + SMMM.Substring(1, 1) + "'"; }
        else { _sqlQuery = "SELECT * FROM " + TBLCHK + " where ROLL='" + ROLL + "'"; }
        DataTable dtfind = new DataTable();
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtfind, AllQueryParam);
        if (dtfind.Rows.Count > 0) { GG = 1; }

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
        if (dt.Rows.Count == 0) { return; }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string TYPE = dt.Rows[i]["TYPE"].ToString().Trim();
            string SSEM = dt.Rows[i]["SEM"].ToString().Trim();
            string SUBC = dt.Rows[i]["SUBCODE"].ToString().Trim();
            if (TYPE.Length == 2)
            {
                Sublist.Add(SUBC + "T");
                if (STUTYP == "SBACK" && brr == "16") { }
                else { Sublist.Add(SUBC + "P"); }
            }
            else
            {
                if (TYPE == "P")
                {
                    if (STUTYP == "SBACK" && brr == "16") { }
                    else { Sublist.Add(SUBC + "P"); }
                }
                else
                {
                    Sublist.Add(SUBC + TYPE);
                }
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
                    string RESULT1 = dtrec.Rows[r]["RESULT1"].ToString().Trim();
                    string RGP = dtrec.Rows[r]["REGPVT"].ToString().Trim();
                    string RLFLG = dtrec.Rows[r]["RLFLG"].ToString().Trim();


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
                            if (brr != "16") { SGPA = Convert.ToDecimal(dtrec.Rows[r]["SGPA"].ToString().Trim()); }
                        }
                        for (int i = 1; i <= SUBCNT; i++)
                        {//THEORY & PRACTICAL MARKS
                            string SUB = dtrec.Rows[r]["SUB" + i.ToString()].ToString().Trim();
                            if (SUB != "")
                            {//SUBJECT FOUND
                                string TB = dtrec.Rows[r]["GBT" + i.ToString()].ToString().Trim();
                                if (TB == "" || TB == "G")
                                {
                                    if (RLFLG != "UFM")
                                    {
                                        if (STUTYPE == "N") { if (SGPA > 4) { Sublist.Remove(SUB + "T"); } }
                                        else
                                        {
                                            if (RESULT1 == "FAIL" || RESULT1 == "X")
                                            {
                                                if (brr == "16") { }
                                                else { Sublist.Remove(SUB + "T"); }
                                            }
                                            else { Sublist.Remove(SUB + "T"); }
                                        }
                                    }
                                }
                                string PB = dtrec.Rows[r]["GBP" + i.ToString()].ToString().Trim();
                                if (PB == "" || PB == "G")
                                {
                                    if (RLFLG != "UFM")
                                    {
                                        Sublist.Remove(SUB + "P");
                                    }
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
                                string BMRK = dtrec.Rows[r]["BMRK" + i.ToString()].ToString().Trim();
                                if ((TB == "" || TB == "G") && (BMRK != "" && BMRK != "N/A" && BMRK != "ABS"))
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
                                string BPR = dtrec.Rows[r]["BPR" + i.ToString()].ToString().Trim();

                                if ((PB == "" || PB == "G") && (BPR != "" && BPR != "N/A" && BPR != "ABS"))
                                {
                                    Sublist.Remove(SUB + "P");
                                }
                            }
                        }
                    }
                }
            }
        }
        //Add backp Paper
        if (BR != "16")
        {
            if (SMMM == "01" || SMMM == "03" || SMMM == "05")
            {
                int SS1 = Convert.ToInt32(SMMM) - 1;
                
                //Remove the code of Back Paper

                //if (Sublist.Count > 6)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {

                //        string SSEM = dt.Rows[i]["SEM"].ToString().Trim();
                //        int SS2 = Convert.ToInt32(SSEM);
                //        string SUBTYPE = dt.Rows[i]["TYPE"].ToString().Trim();
                //        string SUBC = dt.Rows[i]["SUBCODE"].ToString().Trim();

                //        if (SUBTYPE.Contains("T") == true)
                //        {
                //            if (SS2 >= SS1)
                //            {
                //                if (Sublist.Contains(SUBC + "T") == false)
                //                {
                //                  Sublist.Add(SUBC + "T");
                //                }
                //            }
                //        }
                //    }
                //}
            }
        }
        else
        {
            int SS1 = Convert.ToInt32(SMMM) - 1;
            if (Sublist.Count > 2)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string SSEM = dt.Rows[i]["SEM"].ToString().Trim();
                    int SS2 = Convert.ToInt32(SSEM);
                    string SUBTYPE = dt.Rows[i]["TYPE"].ToString().Trim();
                    string SUBC = dt.Rows[i]["SUBCODE"].ToString().Trim();

                    if (SUBTYPE.Contains("T") == true)
                    {
                        if (SS2 >= SS1)
                        {
                            if (Sublist.Contains(SUBC + "T") == false)
                            {
                                Sublist.Add(SUBC + "T");
                            }
                        }
                    }
                }
            }
        }





        for (int s = 0; s < Sublist.Count; s++)
        {
            dr["REGNO"] = CANDIDATEID;
            dr["SUB"] = Sublist[s].ToString();
            dtr.Rows.Add(dr);
            dr = dtr.NewRow();
        }
        Grdsub.DataSource = dtr;
        Grdsub.DataBind();
        Grdsub.Visible = true;
        Btnsubmit.Visible = true;
    }
}