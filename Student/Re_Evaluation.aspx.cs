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
public partial class Re_Evaluation : System.Web.UI.Page
{
    public string Comp = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] == null) { Response.Redirect("Login.aspx", false); }
            if (!IsPostBack)
            {
                string[] AllQueryParam = new string[1];
                BLL objbll = new BLL();
                DataTable dtsem = new DataTable();
                string _sqlQuery = "select * from REGISTRATION where CANDIDATEID='" + Session["ID"].ToString().Trim() + "'";
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dtsem, AllQueryParam);
                if (dtsem.Rows.Count == 0) { Response.Redirect("~/Error.aspx", false); }
                string SEM = dtsem.Rows[0]["SEM"].ToString();
                string REGPVT = dtsem.Rows[0]["REGPVT"].ToString();
                string STUTYPE = dtsem.Rows[0]["STUTYPE"].ToString();

                string INSCODE = dtsem.Rows[0]["INSCODE"].ToString();
                string BRCODE = dtsem.Rows[0]["BRCODE"].ToString();
                DataTable dtreg = new DataTable();
                _sqlQuery = "SELECT * FROM BRLOGIN where INSCODE='" + INSCODE + "' and BRCODE='" + BRCODE + "'";
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dtreg, AllQueryParam);
                if (dtreg.Rows.Count == 0) { Response.Redirect("~/Error.aspx", false); }
                string REEVA = dtreg.Rows[0]["REEVA"].ToString();
                string SEMBR = dtreg.Rows[0]["SEM"].ToString();
                if (REEVA == "N" || SEMBR.Contains(SEM) == false) { Response.Redirect("~/Error.aspx", false); }
                //Check Re-Evaluation Status
                DataTable dt = new DataTable();
                _sqlQuery = "select * from REEVA where CANDIDATEID=" + Session["ID"].ToString().Trim();
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count > 0)
                {
                    string ISCOMP = dt.Rows[0]["ISCOMPLETED"].ToString().Trim();
                    if (ISCOMP == "1")
                    {
                        Imgscru.Visible = true;
                        Lnkscrureceipt.Visible = true;
                        Comp = "YOU HAVE SUBMITTED RE-EVALUATION FORM. PLEASE RETAIN PHOTOCOPY OF FILLED-UP RE-EVALUATION FORM FOR FUTURE CORRESPONDENCE.";
                    }
                    else
                    {
                        Imgscru.Visible = true;
                        Lnkscrureceipt.Visible = true;
                        Comp = "YOU HAVE SUBMITTED RE-EVALUATION FORM.</br>>> NOT APPROVED BY BRANCH HOD";
                    }
                    Grdsub.Visible = false;
                    Btnsubmit.Visible = false;
                }
                else { Griddata(SEM, REGPVT, STUTYPE); }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] == null) { Response.Redirect("Login.aspx", false); }
            string _sqlQuery = string.Empty;
            int FEE = 0;
            string SUB = string.Empty;
            string TYP = "R";
            int n = 0;
            foreach (GridViewRow gvrow in Grdsub.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CbSelect");
                if (chk != null & chk.Checked)
                {
                    FEE = FEE + 2000;
                    if (n == 0) { SUB = chk.Text; }
                    else
                    {
                        SUB = SUB + "|" + chk.Text;
                    }
                    n++;
                }
            }
            if (n == 0) { LblMessage.Text = "Please select atleast one subject."; return; }
            DataTable dt = new DataTable();
            string[] AllQueryParam = new string[1];
            _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID=" + Session["ID"].ToString().Trim();
            AllQueryParam[0] = _sqlQuery;
            BLL objbll = new BLL();
            objbll.QUERYBLL(ref dt, AllQueryParam);
            if (dt.Rows.Count > 0)
            {
                _sqlQuery = "DELETE FROM REEVA WHERE CANDIDATEID='" + Session["ID"].ToString().Trim() + "'";
                objbll.ONLYQUERYBLL(_sqlQuery);
                _sqlQuery = "insert into REEVA(CANDIDATEID,ROLL,INSCODE,INSNAME,BRCODE,BRNAME,SHIFT,CNAME,FNAME,DOB,SEM,SUB,TYPE,FEE,REGPVT,UPDATEDON) Values('" + dt.Rows[0]["CANDIDATEID"].ToString() + "','" + dt.Rows[0]["ROLL"].ToString() + "','" + dt.Rows[0]["INSCODE"].ToString() + "','" + dt.Rows[0]["INSNAME"].ToString() + "','" + dt.Rows[0]["BRCODE"].ToString() + "','" + dt.Rows[0]["BRNAME"].ToString() + "','" + dt.Rows[0]["SHIFT"].ToString() + "','" + dt.Rows[0]["CNAME"].ToString() + "','" + dt.Rows[0]["FNAME"].ToString() + "','" + dt.Rows[0]["DOB"].ToString() + "','" + dt.Rows[0]["SEM"].ToString() + "','" + SUB + "','" + TYP + "','" + FEE + "','" + dt.Rows[0]["REGPVT"].ToString() + "',getdate())";
                string result = objbll.ONLYQUERYBLL(_sqlQuery);
                if (result == "1-1")
                {
                    LblMessage.Text = "RE-EVALUATION FORM SUBMITTED SUCCESSFULLY.";
                    Grdsub.Visible = false;
                    Btnsubmit.Visible = false;
                    Imgscru.Visible = false;
                    Lnkscrureceipt.Visible = false;
                    Comp = "YOU HAVE SUBMITTED RE-EVALUATION FORM.</br>>> NOT APPROVED BY BRANCH HOD";
                }
                else { LblMessage.Text = "RE-EVALUATION FORM NOT SUBMITTED."; }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    public void Griddata(string SEM, string REGPVT, string STUTYPE)
    {
        DataTable dtrec = new DataTable();
        if (dtrec.Columns.Count == 0)
        {
            dtrec.Columns.Add("SUBJECT");
            dtrec.Columns.Add("MARKS");
            dtrec.Columns.Add("SUBCODE");
        }
        string BRC = Session["ROLL"].ToString().Trim().Substring(5, 2);
        string _sqlQuery = string.Empty;
        int cntm = 0;
        int cntb = 0;
        if (BRC == "16")
        {
            _sqlQuery = "select * from PH where ROLL='" + Session["ROLL"].ToString().Trim() + "' ORDER BY SUBSTRING(SESS,4,4) DESC, SUBSTRING(SESS,1,2) DESC";
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
            _sqlQuery = "select * from " + TBL + " where ROLL='" + Session["ROLL"].ToString().Trim() + "' ORDER BY SUBSTRING(SESS,4,4) DESC, SUBSTRING(SESS,1,2) DESC";
            if (SEM == "01")
            {
                cntm = 10;
                cntb = 0;
            }
            else if (SEM == "02")
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
                                    dr["SUBJECT"] = SNAME;
                                    dr["MARKS"] = TH;
                                    dr["SUBCODE"] = SUB;
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
                                    dr["SUBJECT"] = SNAME;
                                    dr["MARKS"] = TH;
                                    dr["SUBCODE"] = TBACK;
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
            else { LblMessage.Text = "You are not eligible for RE-EVALUATION form."; }
        }
    }
}