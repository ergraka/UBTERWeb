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
public partial class Studentbackpaper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (Request.QueryString["STAT"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (!IsPostBack)
            {
                Btnsubmit.Visible = false;
                string STAT = Request.QueryString["STAT"].ToString();
                if (STAT == "BACK") { Lblcp.Text = "Back Paper Registration"; }
                else if (STAT == "SBACK") { Lblcp.Text = "Special Back Paper Registration"; }
                else if (STAT == "SCRU") { Lblcp.Text = "Scrutiny Paper Registration"; }
                else if (STAT == "REEVA") { Lblcp.Text = "Re-Evaluation Paper Registration"; }

                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                string[] AllQueryParamreg = new string[1];
                _sqlQueryreg = "select distinct INSCODE,INSNAME from INSLOGIN order by INSCODE asc";
                AllQueryParamreg[0] = _sqlQueryreg;
                BLL objbllreg = new BLL();
                objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                if (dtreg.Rows.Count > 0)
                {
                    Drpins.DataValueField = dtreg.Columns["INSCODE"].ToString().Trim();
                    Drpins.DataTextField = dtreg.Columns["INSNAME"].ToString().Trim();
                    Drpins.DataSource = dtreg;
                    Drpins.DataBind();
                    if (Drpins.Items.Count > 0) { Drpins.SelectedIndex = 0; }
                }
                else { Response.Redirect("~/Error.aspx", true); }
            }
        }
        catch (Exception ex) { LblMessage.Text = "Server Busy, Please try after some time !"; }
    }
    protected void Drpins_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpins.SelectedIndex > 0)
            {
                string _sqlQueryreg = string.Empty;
                string[] AllQueryParamreg = new string[1];
                BLL objbllreg = new BLL();
                //Get Branch
                DataTable dtins = new DataTable();
                _sqlQueryreg = "select * from BRLOGIN where INSCODE='" + Drpins.SelectedValue + "' order by BRCODE asc";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtins, AllQueryParamreg);
                if (dtins.Rows.Count > 0)
                {
                    Drpbranch.DataValueField = dtins.Columns["BRCODE"].ToString().Trim();
                    Drpbranch.DataTextField = dtins.Columns["BRNAME"].ToString().Trim();
                    Drpbranch.DataSource = dtins;
                    Drpbranch.DataBind();
                    if (Drpbranch.Items.Count > 0) { Drpbranch.SelectedIndex = 0; }
                }
                else { Response.Redirect("~/Error.aspx", true); }
            }
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
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
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            string STAT = Request.QueryString["STAT"].ToString();
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Txtroll.Text == "") { LblMessage.Text = "Please Enter Registration Number OR Roll Number."; return; }
            string _sqlQueryreg = string.Empty;
            DataTable dtreg = new DataTable();
            string[] AllQueryParamreg = new string[1];
            BLL objbllreg = new BLL();

            _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "') AND INSCODE='" + Drpins.SelectedValue + "' AND BRCODE='" + Drpbranch.SelectedValue + "'";
            AllQueryParamreg[0] = _sqlQueryreg;
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count > 0)
            {
                string CANDIDATEID = dtreg.Rows[0]["CANDIDATEID"].ToString();
                string ROLL = dtreg.Rows[0]["ROLL"].ToString();
                string SEM = dtreg.Rows[0]["SEM"].ToString();
                string STUTYPE = dtreg.Rows[0]["STUTYPE"].ToString();
                string REGPVT = dtreg.Rows[0]["REGPVT"].ToString();
                string BRC = dtreg.Rows[0]["BRCODE"].ToString().Substring(0, 2);

                if (STAT == "BACK" || STAT == "SBACK")
                {
                    if (Rdoallback.Checked == true) { Getsubject(STAT, SEM, CANDIDATEID, STUTYPE); }
                    else if (Rdoonlyback.Checked == true) { Getback(CANDIDATEID); }
                    //get Filled back
                    string BACKF = string.Empty;
                    _sqlQueryreg = "SELECT * FROM BACKP where CANDIDATEID='" + CANDIDATEID + "'";
                    AllQueryParamreg[0] = _sqlQueryreg;
                    DataTable dtb = new DataTable();
                    objbllreg.QUERYBLL(ref dtb, AllQueryParamreg);
                    if (dtb.Rows.Count > 0) { BACKF = dtb.Rows[0]["SUBA"].ToString().Trim(); }
                    //Check on Filled back
                    foreach (GridViewRow gvrow in Grdsub.Rows)
                    {
                        CheckBox chk = (CheckBox)gvrow.FindControl("Cbsub");
                        if (BACKF.Contains(chk.Text) == true)
                        { chk.Checked = true; }
                    }
                }
                else if (STAT == "SCRU" || STAT == "REEVA")
                {
                    SCRU_REEVA(ROLL,SEM,REGPVT,STUTYPE,BRC);
                    //get Filled back
                    string BACKF = string.Empty;
                    if (STAT == "SCRU") { _sqlQueryreg = "SELECT * FROM SCRU where CANDIDATEID='" + CANDIDATEID + "'"; }
                    else if (STAT == "REEVA") { _sqlQueryreg = "SELECT * FROM REEVA where CANDIDATEID='" + CANDIDATEID + "'"; }
                    AllQueryParamreg[0] = _sqlQueryreg;
                    DataTable dtb = new DataTable();
                    objbllreg.QUERYBLL(ref dtb, AllQueryParamreg);
                    if (dtb.Rows.Count > 0) { BACKF = dtb.Rows[0]["SUB"].ToString().Trim(); }
                    //Check on Filled back
                    foreach (GridViewRow gvrow in Grdsub.Rows)
                    {
                        CheckBox chk = (CheckBox)gvrow.FindControl("Cbsub");
                        if (BACKF.Contains(chk.Text) == true)
                        { chk.Checked = true; }
                    }
                    Btnsubmit.Visible = true;
                    Grdsub.Visible = true;
                }
            }
            else
            {
                LblMessage.Text = Txtroll.Text + "- IS Invalid Registration Number OR Roll Number for Select Institute.Please Enter Valid Registration Number OR Roll Number.";
            }
        }
        catch (Exception ex)
        { LblMessage.Text = ex.Message; }
    }
    //Get All Subject
    private void Getsubject(string BTYPE, string SEM, string CANDIDATEID, string STUTYPE)
    {
        DataTable dtr = new DataTable();
        dtr.Columns.Add("REGNO");
        dtr.Columns.Add("SUB");
        DataRow dr = dtr.NewRow();
        string[] AllQueryParam = new string[1];
        BLL objbllLogin = new BLL();
        string _sqlQuery = string.Empty;
        string brr = Drpbranch.SelectedValue.Substring(0, 2);
        DataTable dt = new DataTable();
        if (STUTYPE == "O") { _sqlQuery = "SELECT * FROM SUBJ where BRCODE='" + brr + "' ORDER BY SEM,SUBCODE ASC"; }
        else { _sqlQuery = "SELECT * FROM SUBN where BRCODE='" + brr + "' ORDER BY SEM,SUBCODE ASC"; }
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string TYPE = dt.Rows[i]["TYPE"].ToString().Trim();
                if (TYPE.Length == 2)
                {
                    dr["REGNO"] = CANDIDATEID;
                    dr["SUB"] = dt.Rows[i]["SUBCODE"].ToString() + "T";
                    dtr.Rows.Add(dr);
                    dr = dtr.NewRow();
                    if (BTYPE == "SBACK" || BTYPE == "BACK")
                    {
                        dr["REGNO"] = CANDIDATEID;
                        dr["SUB"] = dt.Rows[i]["SUBCODE"].ToString() + "P";
                        dtr.Rows.Add(dr);
                        dr = dtr.NewRow();
                    }
                }
                else if (TYPE.Length == 1)
                {
                    if (TYPE == "T")
                    {
                        dr["REGNO"] = CANDIDATEID;
                        dr["SUB"] = dt.Rows[i]["SUBCODE"].ToString() + dt.Rows[i]["TYPE"].ToString();
                        dtr.Rows.Add(dr);
                        dr = dtr.NewRow();
                    }
                    if (TYPE == "P")
                    {
                        if (BTYPE == "SBACK" || BTYPE == "BACK")
                        {
                            dr["REGNO"] = CANDIDATEID;
                            dr["SUB"] = dt.Rows[i]["SUBCODE"].ToString() + dt.Rows[i]["TYPE"].ToString();
                            dtr.Rows.Add(dr);
                            dr = dtr.NewRow();
                        }
                    }
                }
            }
            Grdsub.DataSource = dtr;
            Grdsub.DataBind();
            Grdsub.Visible = true;
            Btnsubmit.Visible = true;

           
        }
    }
    //Actual back
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
                            if (brr != "16")
                            {
                                SGPA = Convert.ToDecimal(dtrec.Rows[r]["SGPA"].ToString().Trim());
                            }
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
                    if (z > 1 || GRP == "A"|| brr == "16")
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
            if (SMMM == "02" || SMMM == "04" || SMMM == "06")
            {
                int SS1 = Convert.ToInt32(SMMM) - 1;
                if (Sublist.Count > 6)
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
    //Scrutiny & Re-Evaluation
    public void SCRU_REEVA(string ROLL, string SEM, string REGPVT, string STUTYPE, string BRC)
    {
        DataTable dtrec = new DataTable();
        dtrec.Columns.Add("REGNO");
        dtrec.Columns.Add("SUB");
        string _sqlQuery = string.Empty;
        int cntm = 0;
        int cntb = 0;
        if (BRC == "16")
        {
            _sqlQuery = "select * from PH where ROLL='" + ROLL + "' ORDER BY SUBSTRING(SESS,4,4) DESC, SUBSTRING(SESS,1,2) DESC";
            cntm = 6;
            cntb = 2;
        }
        else
        {
            string TBL = string.Empty;
            if (SEM == "01" && (REGPVT == "R" || REGPVT == "P")) { TBL = "SEMESTER1"; }
            else if (SEM == "02" && (REGPVT == "R" || REGPVT == "P")) { TBL = "SEMESTER2"; }
            else if (SEM == "03" && (REGPVT == "R" || REGPVT == "P")) { TBL = "SEMESTER3"; }
            else if (SEM == "04" && (REGPVT == "R" || REGPVT == "P")) { TBL = "SEMESTER4"; }
            else if (SEM == "05" && (REGPVT == "R" || REGPVT == "P")) { TBL = "SEMESTER5"; }
            else if (SEM == "06" && (REGPVT == "R" || REGPVT == "P")) { TBL = "SEMESTER6"; }
            else if (REGPVT == "P" || REGPVT == "Q") { TBL = "PRIVAT"; }
            if (STUTYPE == "N") { TBL = "N" + TBL; }
            _sqlQuery = "select * from " + TBL + " where ROLL='" + ROLL + "' ORDER BY SUBSTRING(SESS,4,4) DESC, SUBSTRING(SESS,1,2) DESC";
            if (SEM == "01")
            {
                cntm = 10;
                cntb = 0;
            }
            else if (SEM == "02" && STUTYPE == "N")
            {
                cntm = 10;
                cntb = 17;
            }
            else
            {
                cntm = 12;
                cntb = 17;
            }
        }
        DataRow dr = dtrec.NewRow();
        string[] AllQueryParam = new string[1];
        BLL objbll = new BLL();
        DataTable dt = new DataTable();
        AllQueryParam[0] = _sqlQuery;
        objbll.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count > 0)
        {
            string RLFLG = dt.Rows[0]["RLFLG"].ToString().Trim();
            if (RLFLG != "UFM")
            {
                if ((BRC == "16") || (REGPVT == "R" || REGPVT == "P"))
                {
                    for (int i = 1; i <= cntm; i++)
                    {
                        string SUB = dt.Rows[0]["SUB" + i.ToString()].ToString().Trim();
                        if (SUB != "")
                        {
                            if (STUTYPE == "N") { _sqlQuery = "select * from SUBN where SUBCODE='" + SUB + "' and (TYPE='T' OR TYPE='TP')"; }
                            else { _sqlQuery = "select * from SUBJ where SUBCODE='" + SUB + "' and (TYPE='T' OR TYPE='TP')"; }
                            DataTable dt2 = new DataTable();
                            AllQueryParam[0] = _sqlQuery;
                            objbll.QUERYBLL(ref dt2, AllQueryParam);
                            if (dt2.Rows.Count > 0)
                            {
                                string SNAME = SUB + "-" + dt2.Rows[0]["SUBJECT"].ToString().Trim();
                                string TH = string.Empty;
                                if (BRC == "16") { TH = dt.Rows[0]["T" + i.ToString()].ToString().Trim(); }
                                else { TH = dt.Rows[0]["TH" + i.ToString()].ToString().Trim(); }
                                if (TH != "")
                                {
                                    dr["REGNO"] = ROLL;
                                    dr["SUB"] = SUB;
                                    dtrec.Rows.Add(dr);
                                    dr = dtrec.NewRow();
                                }
                            }
                        }
                    }
                }
                if (SEM != "01")
                {
                    for (int i = 1; i <= cntb; i++)//PREVIOUS SEMESTER
                    {
                        string TBACK = dt.Rows[0]["BPAPT" + i.ToString()].ToString().Trim();
                        if (TBACK != "")
                        {
                            DataTable dt1 = new DataTable();
                            if (STUTYPE == "N") { _sqlQuery = "select * from SUBN where SUBCODE='" + TBACK + "' and (TYPE='T' OR TYPE='TP')"; }
                            else { _sqlQuery = "select * from SUBJ where SUBCODE='" + TBACK + "' and (TYPE='T' OR TYPE='TP')"; }
                            AllQueryParam[0] = _sqlQuery;
                            objbll.QUERYBLL(ref dt1, AllQueryParam);
                            if (dt1.Rows.Count > 0)
                            {
                                string SNAME = TBACK + "-" + dt1.Rows[0]["SUBJECT"].ToString().Trim();
                                string TH = dt.Rows[0]["BMRK" + i.ToString()].ToString().Trim();
                                if (TH != "")
                                {
                                    dr["REGNO"] = ROLL;
                                    dr["SUB"] = TBACK;
                                    dtrec.Rows.Add(dr);
                                    dr = dtrec.NewRow();
                                }
                            }
                        }
                    }
                }
                Grdsub.DataSource = dtrec;
                Grdsub.DataBind();
            }
            else { LblMessage.Text = "You are not eligible for Scrutiny form."; }
        }
    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string _sqlQuery = string.Empty;
            BLL objbll = new BLL();
            string[] AllQueryParam = new string[1];
            int FEEBACK = 0;
            string SUBA = string.Empty;
            string SUBN = string.Empty;
            string SESS = Getsession();
            int n1 = 0;
            int n2 = 0;
            string TYP = "B";
            string STAT = Request.QueryString["STAT"].ToString();
            if (STAT == "BACK") { TYP = "B"; }
            else if (STAT == "SBACK") { TYP = "S"; }
            foreach (GridViewRow gvrow in Grdsub.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("Cbsub");
                if (chk != null & chk.Checked)
                {
                    if (STAT == "BACK" || STAT == "SBACK") { FEEBACK = FEEBACK + 200; }
                    else if (STAT == "SCRU") { FEEBACK = FEEBACK + 250; }
                    else if (STAT == "REEVA") { FEEBACK = FEEBACK + 2000; }
                    if (n1 == 0) { SUBA = chk.Text; }
                    else
                    {
                        SUBA = SUBA + "|" + chk.Text;
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
            if (n1 == 0) { LblMessage.Text = "Please select atleast one subject."; return; }
            if (STAT == "SBACK")
            {
                FEEBACK = FEEBACK + 530;
            }
            DataTable dt = new DataTable();
            _sqlQuery = "select * from REGISTRATION where STAT='A' AND (CANDIDATEID='" + Txtroll.Text + "' OR ROLL='" + Txtroll.Text + "')";
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dt, AllQueryParam);
            if (dt.Rows.Count > 0)
            {

                if (Rdoallback.Checked == true) { SUBN = ""; }

                string CANDIDATEID = dt.Rows[0]["CANDIDATEID"].ToString().Trim();
                string STUTYPE = dt.Rows[0]["STUTYPE"].ToString().Trim();
                if (STAT == "BACK" || STAT == "SBACK") { _sqlQuery = "select * from BACKP where CANDIDATEID='" + CANDIDATEID + "'"; }
                else if (STAT == "REEVA") { _sqlQuery = "select * from REEVA where CANDIDATEID='" + CANDIDATEID + "'"; }
                else if (STAT == "SCRU") { _sqlQuery = "select * from SCRU where CANDIDATEID='" + CANDIDATEID + "'"; }
                DataTable dtb = new DataTable();
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dtb, AllQueryParam);
                if (dtb.Rows.Count == 0)
                {
                    if (STAT == "BACK" || STAT == "SBACK") { _sqlQuery = "insert into BACKP(CANDIDATEID,ROLL,INSCODE,INSNAME,BRCODE,BRNAME,SHIFT,CNAME,FNAME,DOB,SEM,SUBA,SUBN,TYPE,FEE,ISCOMPLETED,SESS,STUTYPE,REGPVT,STAT,UPDATEDON) Values('" + dt.Rows[0]["CANDIDATEID"].ToString() + "','" + dt.Rows[0]["ROLL"].ToString() + "','" + dt.Rows[0]["INSCODE"].ToString() + "','" + dt.Rows[0]["INSNAME"].ToString() + "','" + dt.Rows[0]["BRCODE"].ToString() + "','" + dt.Rows[0]["BRNAME"].ToString() + "','" + dt.Rows[0]["SHIFT"].ToString() + "','" + dt.Rows[0]["CNAME"].ToString() + "','" + dt.Rows[0]["FNAME"].ToString() + "','" + dt.Rows[0]["DOB"].ToString() + "','" + dt.Rows[0]["SEM"].ToString() + "','" + SUBA + "','" + SUBN + "','" + TYP + "','" + FEEBACK + "','1','" + SESS + "','" + STUTYPE + "','" + dt.Rows[0]["REGPVT"].ToString() + "','A',GETDATE())"; }
                    else if (STAT == "REEVA") { _sqlQuery = "insert into REEVA(CANDIDATEID,ROLL,INSCODE,INSNAME,BRCODE,BRNAME,SHIFT,CNAME,FNAME,DOB,SEM,SUB,TYPE,FEE,ISCOMPLETED,SESS,STUTYPE,REGPVT,UPDATEDON) Values('" + dt.Rows[0]["CANDIDATEID"].ToString() + "','" + dt.Rows[0]["ROLL"].ToString() + "','" + dt.Rows[0]["INSCODE"].ToString() + "','" + dt.Rows[0]["INSNAME"].ToString() + "','" + dt.Rows[0]["BRCODE"].ToString() + "','" + dt.Rows[0]["BRNAME"].ToString() + "','" + dt.Rows[0]["SHIFT"].ToString() + "','" + dt.Rows[0]["CNAME"].ToString() + "','" + dt.Rows[0]["FNAME"].ToString() + "','" + dt.Rows[0]["DOB"].ToString() + "','" + dt.Rows[0]["SEM"].ToString() + "','" + SUBA + "','" + TYP + "','" + FEEBACK + "','1','" + SESS + "','" + STUTYPE + "','" + dt.Rows[0]["REGPVT"].ToString() + "',getdate())"; }
                    else if (STAT == "SCRU") { _sqlQuery = "insert into SCRU(CANDIDATEID,ROLL,INSCODE,INSNAME,BRCODE,BRNAME,SHIFT,CNAME,FNAME,DOB,SEM,SUB,TYPE,FEE,ISCOMPLETED,SESS,STUTYPE,REGPVT,UPDATEDON) Values('" + dt.Rows[0]["CANDIDATEID"].ToString() + "','" + dt.Rows[0]["ROLL"].ToString() + "','" + dt.Rows[0]["INSCODE"].ToString() + "','" + dt.Rows[0]["INSNAME"].ToString() + "','" + dt.Rows[0]["BRCODE"].ToString() + "','" + dt.Rows[0]["BRNAME"].ToString() + "','" + dt.Rows[0]["SHIFT"].ToString() + "','" + dt.Rows[0]["CNAME"].ToString() + "','" + dt.Rows[0]["FNAME"].ToString() + "','" + dt.Rows[0]["DOB"].ToString() + "','" + dt.Rows[0]["SEM"].ToString() + "','" + SUBA + "','" + TYP + "','" + FEEBACK + "','1','" + SESS + "','" + STUTYPE + "','" + dt.Rows[0]["REGPVT"].ToString() + "',getdate())"; }
                    string result = objbll.ONLYQUERYBLL(_sqlQuery);
                    if (result == "1-1")
                    {
                        LblMessage.Text = "FORM SUBMITTED SUCCESSFULLY.";
                        Grdsub.Visible = false;
                        Btnsubmit.Visible = false;
                    }
                    else { LblMessage.Text = "FORM SUBMISSION FAILED."; }
                }
                else
                {
                    if (STAT == "BACK" || STAT == "SBACK") { _sqlQuery = "UPDATE BACKP SET SUBA='" + SUBA + "',SUBN='" + SUBN + "',FEE='" + FEEBACK + "',ISCOMPLETED='1' WHERE CANDIDATEID='" + CANDIDATEID + "'"; }
                    else if (STAT == "REEVA") { _sqlQuery = "UPDATE REEVA SET SUB='" + SUBA + "',FEE='" + FEEBACK + "',ISCOMPLETED='1' WHERE CANDIDATEID='" + CANDIDATEID + "'"; }
                    else if (STAT == "SCRU") { _sqlQuery = "UPDATE SCRU SET SUB='" + SUBA + "',FEE='" + FEEBACK + "',ISCOMPLETED='1' WHERE CANDIDATEID='" + CANDIDATEID + "'"; }
                    string result = objbll.ONLYQUERYBLL(_sqlQuery);
                    if (result == "1-1")
                    {
                        LblMessage.Text = "FORM SUBMITTED SUCCESSFULLY.";
                        Grdsub.Visible = false;
                        Btnsubmit.Visible = false;
                    }
                    else { LblMessage.Text = "FORM SUBMISSION FAILED."; }
                }
            }
            else { LblMessage.Text = "Not found in Registration."; }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
}