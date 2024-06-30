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

public partial class Marksheet : System.Web.UI.Page
{
    public string STR = string.Empty;
    public string STRSGPAH = string.Empty;
    public string INSTITUTE = string.Empty;
    public string BRANCH = string.Empty;
    public string CNAME = string.Empty;
    public string FNAME = string.Empty;
    public string CANDIDATEID = string.Empty;
    public string ROLL = string.Empty;
    public string DATE = string.Empty;
    public string TYPE = string.Empty;
    public string STUTYPE = string.Empty;
    public string STRTSESS = string.Empty;
    public string PrivateBack = "";

    public decimal CR1 = 0;
    public decimal CR2 = 0;
    public decimal CR3 = 0;
    public decimal CR4 = 0;
    public decimal CR5 = 0;
    public decimal CR6 = 0;

    public decimal SG1 = 0;
    public decimal SG2 = 0;
    public decimal SG3 = 0;
    public decimal SG4 = 0;
    public decimal SG5 = 0;
    public decimal SG6 = 0;

    public decimal FCGPA = 0;

    string CGPA2 = string.Empty;
    string CGPA4 = string.Empty;
    string CGPA6 = string.Empty;

    string PFlag = string.Empty;

    int SemCount = 0;


    ArrayList Sesslist = new ArrayList();
    BLL objbllLogin = new BLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["BRCODE"] == null && Session["ID"] == null) { Response.Redirect("~/Institute/Inslogin.aspx", false); }
            if (Request.QueryString["AAAAA"] == null) { Response.Redirect("~/Error.aspx", false); }
            string[] SPLROLL = Request.QueryString["AAAAA"].ToString().Split('|');
            string TYP = SPLROLL[0].ToString();
            ROLL = SPLROLL[1].ToString();
            PrivateBack = "N";
            List<string> Sublist = new List<string>();


            if (Session["ROLL"] != null)
            {
                string ROLL1 = Session["ROLL"].ToString();
                if (ROLL != ROLL1) { Response.Redirect("~/Error.aspx", false); }
            }
            int CNT = 0;
            string SEMYEAR = string.Empty;
            string RLFLG = string.Empty;
            string _sqlQuery = string.Empty;
            DataTable dt = new DataTable();
            string[] AllQueryParam = new string[1];
            _sqlQuery = "select * from REGISTRATION where STAT='A' AND (CANDIDATEID='" + ROLL + "' OR ROLL='" + ROLL + "')";
            AllQueryParam[0] = _sqlQuery;
            
            objbllLogin.QUERYBLL(ref dt, AllQueryParam);
            if (dt.Rows.Count == 0) { return; }
            STUTYPE = dt.Rows[0]["STUTYPE"].ToString();
            STR = STR + ("<table style='font-size: 13px; font-family:Cambria; border-collapse:collapse; border-color:#0000CD' border='1' cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" runat=\"server\">");
            INSTITUTE = dt.Rows[0]["INSNAME"].ToString();
            BRANCH = dt.Rows[0]["BRNAME"].ToString();
            CNAME = dt.Rows[0]["CNAME"].ToString();
            FNAME = dt.Rows[0]["FNAME"].ToString();
            CANDIDATEID = dt.Rows[0]["CANDIDATEID"].ToString();
            CANDIDATEID = dt.Rows[0]["CANDIDATEID"].ToString();
            string SMMM = dt.Rows[0]["SEM"].ToString();
            string GRP = dt.Rows[0]["GRP"].ToString();
            ROLL = dt.Rows[0]["ROLL"].ToString();
            STRTSESS = dt.Rows[0]["STRTSESS"].ToString();
            string ITIPASS = dt.Rows[0]["ITIPASS"].ToString();
            DATE = System.DateTime.Now.ToString("dd/MM/yyyy");

            TYPE = dt.Rows[0]["REGPVT"].ToString(); 
            if (TYPE == "P") { TYPE = "PRIVATE"; } else if (TYPE == "Q") { TYPE = "PASSED/SPECIAL"; } else { TYPE = "REGULAR"; }
            
            string BR = BRANCH.Substring(0, 2).ToString();

            if (BR == "16") { SEMYEAR = "YEAR"; CNT = 3; }
            else if (BR == "07") { SEMYEAR = "SEMESTER"; CNT = 4; }
            else { CNT = 7; SEMYEAR = "SEMESTER"; }

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
            //Get All Subject
            if (STUTYPE == "N")
            {
                if (GG == 1) { _sqlQuery = "SELECT * FROM SUBN where BRCODE='" + BR + "' AND SEM<=" + SMMM + " ORDER BY SEM,SUBCODE ASC"; }
                else { _sqlQuery = "SELECT * FROM SUBN where BRCODE='" + BR + "' AND SEM<" + SMMM + " ORDER BY SEM,SUBCODE ASC"; }
            }
            else
            {
                if (GG == 1) { _sqlQuery = "SELECT * FROM SUBJ where BRCODE='" + BR + "' AND SEM<=" + SMMM + " ORDER BY SEM,SUBCODE ASC"; }
                else { _sqlQuery = "SELECT * FROM SUBJ where BRCODE='" + BR + "' AND SEM<" + SMMM + " ORDER BY SEM,SUBCODE ASC"; }
            }
            DataTable dtalsub = new DataTable();
            AllQueryParam[0] = _sqlQuery;
            objbllLogin.QUERYBLL(ref dtalsub, AllQueryParam);
            if (dtalsub.Rows.Count == 0) { return; }
            for (int i = 0; i < dtalsub.Rows.Count; i++)
            {
                string SSEM = dtalsub.Rows[i]["SEM"].ToString().Trim();
                string SUBTYPE = dtalsub.Rows[i]["TYPE"].ToString().Trim();
                string SUBC = dtalsub.Rows[i]["SUBCODE"].ToString().Trim();
                if (SUBTYPE.Length == 2)
                {
                    Sublist.Add(SUBC + "T");
                    Sublist.Add(SUBC + "P");
                }
                else
                {
                    Sublist.Add(SUBC + SUBTYPE);
                }
                if (GRP == "A")
                {
                    if (SSEM == "01" || SSEM == "02") { Sublist.Remove(SUBC + "P"); }
                    if (SSEM == "02") { Sublist.Remove(SUBC + "T"); }
                }
                if (ITIPASS == "Y") { if (SUBC == "1005" || SUBC == "1006" || SUBC == "991006") { Sublist.Remove(SUBC + "T"); } }
            }
            if (BR != "16")
            {
                //***********************************NOT PHARMACY(16)

                string GTOT = "0";
                string RES = string.Empty;
                string SGPA = string.Empty;
                for (int z = 1; z <= CNT; z++)
                {
                    //Get All Table Data
                    string TBL = SEMYEAR + z.ToString();

                    if (z == CNT) { TBL = "PRIVAT"; }
                    if (STUTYPE == "N") { TBL = "N" + TBL; }
                    _sqlQuery = "select * from " + TBL + " where ROLL='" + ROLL + "' ORDER BY SUBSTRING(SESS,4,4) ASC, SUBSTRING(SESS,1,2) ASC";
                    AllQueryParam[0] = _sqlQuery;
                    DataTable dtchk = new DataTable();
                    objbllLogin.QUERYBLL(ref dtchk, AllQueryParam);
                    if (dtchk.Rows.Count > 0)
                    {
                        for (int r = 0; r < dtchk.Rows.Count; r++)
                        {
                            string SS = dtchk.Rows[r]["SESS"].ToString().Substring(3, 4) + dtchk.Rows[r]["SESS"].ToString().Substring(0, 2);
                            Sesslist.Add(SS + "|" + TBL + "|" + dtchk.Rows[r]["SESS"].ToString());
                        }
                    }
                }
                Sesslist.Sort();
                GETCCGPA();
                for (int z = 0; z < Sesslist.Count; z++)
                {
                    string[] SPL = Sesslist[z].ToString().Split('|');
                    string TBL = SPL[1].ToString();
                    string SESS = SPL[2].ToString();

                    GTOT = "0";
                    RES = "";
                    string CAP1 = string.Empty;
                    if (BR == "07") { CAP1 = "YEAR"; } else { CAP1 = "SEMESTER"; }
                    DataTable dtrec = new DataTable();
                    #region OLD_SUBJECT
                    if (STUTYPE == "O")
                    {
                        _sqlQuery = "select * from " + TBL + " where ROLL='" + ROLL + "' AND SESS='" + SESS + "'";
                        AllQueryParam[0] = _sqlQuery;
                        objbllLogin.QUERYBLL(ref dtrec, AllQueryParam);
                        if (dtrec.Rows.Count > 0)
                        {
                            GTOT = "0";
                            string PRREGPVT = dtrec.Rows[0]["REGPVT"].ToString().Trim();
                            string SEM = "0" + dtrec.Rows[0]["SMCODE"].ToString().Trim();
                            if (TBL == "PRIVAT")
                            {
                                string TYPEX = string.Empty;
                                if (BR == "07") { TYPEX = "YEAR"; } else { TYPEX = "SEMESTER"; }
                                if (PRREGPVT == "S" || PRREGPVT == "Q") { CAP1 = "SPECIAL BACK : " + TYPEX; } else { CAP1 = " PRIVATE : " + TYPEX; }
                            }
                            string CAPTION = CAP1 + "-" + SEM + " [ " + SESS + " ]";
                            STR = STR + ("<tr>");
                            STR = STR + ("<th colspan='11' style='background-color: #3CB371; font-family:Agency FB; color: #FFFFFF; font-size: 18px' valign=\"bottom\" align=\"center\">" + CAPTION + "</th>");
                            STR = STR + ("</tr>");
                            //Header
                            STR = STR + ("<tr>");
                            STR = STR + ("<td rowspan='2' style='background-color:#008B8B; color: #F5DEB3;' valign=\"top\" align=\"left\">SUBJECTS</td>");
                            STR = STR + ("<td colspan='3' style='background-color:#008B8B; color: #F5DEB3;' valign=\"top\" align=\"center\">THEORY</td>");
                            STR = STR + ("<td colspan='3' style='background-color:#008B8B; color: #F5DEB3;' valign=\"top\" align=\"center\">PRACTICAL</td>");
                            STR = STR + ("<td colspan='3' style='background-color:#008B8B; color: #F5DEB3;' valign=\"top\" align=\"center\">SESSIONAL</td>");
                            STR = STR + ("<td rowspan='2' style='background-color:#008B8B; color: #F5DEB3;' valign=\"top\" align=\"center\">TOTAL</td>");
                            STR = STR + ("</tr>");
                            STR = STR + ("<tr>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF;' valign=\"top\" align=\"center\">MAX</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF;' valign=\"top\" align=\"center\">MIN</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF;' valign=\"top\" align=\"center\">OBT</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF;' valign=\"top\" align=\"center\">MAX</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF;' valign=\"top\" align=\"center\">MIN</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF;' valign=\"top\" align=\"center\">OBT</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF;' valign=\"top\" align=\"center\">MAX</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF;' valign=\"top\" align=\"center\">MIN</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF;' valign=\"top\" align=\"center\">OBT</td>");
                            STR = STR + ("</tr>");
                            RLFLG = dtrec.Rows[0]["RLFLG"].ToString().Trim();
                            RES = dtrec.Rows[0]["RESULT1"].ToString().Trim();
                            if (TBL != "PRIVAT")
                            {
                                int SUBCNT = 12; if (z == 0) { SUBCNT = 10; }
                                for (int i = 1; i <= SUBCNT; i++)
                                {//THEORY & PRACTICAL MARKS
                                    string SUB = dtrec.Rows[0]["SUB" + i.ToString()].ToString().Trim();
                                    if (SUB != "")
                                    {//SUBJECT FOUND
                                        DataTable dtsub = new DataTable();
                                        _sqlQuery = "SELECT SUBJECT,THMAX,THMIN,PRMAX,PRMIN FROM SUBJ WHERE SUBCODE='" + SUB + "' AND BRCODE='" + BR + "'";
                                        AllQueryParam[0] = _sqlQuery;
                                        objbllLogin.QUERYBLL(ref dtsub, AllQueryParam);
                                        if (dtsub.Rows.Count > 0)
                                        {
                                            string SNAME = SUB + "-" + dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                            string THMAX = dtsub.Rows[0]["THMAX"].ToString().Trim();
                                            string THMIN = dtsub.Rows[0]["THMIN"].ToString().Trim();
                                            string PRMAX = dtsub.Rows[0]["PRMAX"].ToString().Trim();
                                            string PRMIN = dtsub.Rows[0]["PRMIN"].ToString().Trim();

                                            string TH = "000";
                                            if (RLFLG != "UFM") { TH = dtrec.Rows[0]["TH" + i.ToString()].ToString().Trim(); }
                                            string PR = dtrec.Rows[0]["PR" + i.ToString()].ToString().Trim();
                                            string TOT = "0";
                                            if (TH != "" && TH != "ABS" && TH != "AB") { TOT = (Convert.ToInt32(TOT) + Convert.ToInt32(TH)).ToString(); }
                                            if (PR != "" && PR != "ABS" && PR != "AB") { TOT = (Convert.ToInt32(TOT) + Convert.ToInt32(PR)).ToString(); }
                                            for (int T = TOT.Length; T < 3; T++) { TOT = "0" + TOT; }
                                            GTOT = (Convert.ToInt32(GTOT) + Convert.ToInt32(TOT)).ToString();

                                            string TB = string.Empty;
                                            if (RLFLG != "UFM")
                                            { TB = dtrec.Rows[0]["GBT" + i.ToString()].ToString().Trim(); }

                                            string PB = dtrec.Rows[0]["GBP" + i.ToString()].ToString().Trim();
                                            if (TB != "") { TH = TH + "(" + TB + ")"; }
                                            if (PB != "") { PR = PR + "(" + PB + ")"; }
                                            STR = STR + ("<tr>");
                                            STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + THMAX + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + THMIN + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + TH + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + PRMAX + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + PRMIN + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + PR + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + TOT + "</td>");
                                            STR = STR + ("</tr>");
                                            if (TB != "B") { Sublist.Remove(SUB + "T"); }
                                            if (PB != "B") { Sublist.Remove(SUB + "P"); }
                                        }
                                    }//SUBJECT FOUND
                                }//THORY & PRACTICAL MARKS
                                for (int i = 1; i <= 3; i++)
                                {//SESSIONAL MARKS
                                    string SUB = dtrec.Rows[0]["SS5" + i.ToString()].ToString().Trim();
                                    if (SUB != "")
                                    {
                                        DataTable dtsub = new DataTable();
                                        _sqlQuery = "SELECT SUBJECT,SUBMAX,SUBMIN FROM SUBSESS WHERE SUBCODE='" + SUB + "' AND BRCODE='" + BR + "' AND SEM='" + SEM + "'";
                                        AllQueryParam[0] = _sqlQuery;
                                        objbllLogin.QUERYBLL(ref dtsub, AllQueryParam);
                                        if (dtsub.Rows.Count > 0)
                                        {
                                            string SNAME = dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                            string SSMAX = dtsub.Rows[0]["SUBMAX"].ToString().Trim();
                                            string SSMIN = dtsub.Rows[0]["SUBMIN"].ToString().Trim();
                                            string OBT = dtrec.Rows[0]["SSMKS" + i.ToString()].ToString().Trim();
                                            STR = STR + ("<tr>");
                                            STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + SSMAX + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + SSMIN + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + OBT + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + OBT + "</td>");
                                            STR = STR + ("</tr>");
                                            if (OBT != "" && OBT != "ABS" && OBT != "AB") { GTOT = (Convert.ToInt32(GTOT) + Convert.ToInt32(OBT)).ToString(); }
                                        }
                                    }
                                }//SESSIONAL MARKS
                            }
                            if (z > 0 || GRP == "A")
                            {
                                for (int i = 1; i <= 26; i++)//BACK THEORY i=17 Now 26
                                {
                                    string TBACK = dtrec.Rows[0]["BPAPT" + i.ToString()].ToString().Trim();
                                    if (TBACK != "")
                                    {
                                        DataTable dtsub = new DataTable();
                                        _sqlQuery = "SELECT SUBJECT,THMAX,THMIN,PRMAX,PRMIN FROM SUBJ WHERE SUBCODE='" + TBACK + "' AND BRCODE='" + BR + "'";
                                        AllQueryParam[0] = _sqlQuery;
                                        objbllLogin.QUERYBLL(ref dtsub, AllQueryParam);
                                        if (dtsub.Rows.Count > 0)
                                        {
                                            string SNAME = TBACK + "-" + dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                            string THMAX = dtsub.Rows[0]["THMAX"].ToString().Trim();
                                            string THMIN = dtsub.Rows[0]["THMIN"].ToString().Trim();
                                            string TH = "000";
                                            string B = string.Empty;
                                            if (RLFLG != "UFM")
                                            {
                                                TH = dtrec.Rows[0]["BMRK" + i.ToString()].ToString().Trim();
                                                B = dtrec.Rows[0]["BT" + i.ToString()].ToString().Trim();
                                            }

                                            if (B != "B") { Sublist.Remove(TBACK + "T"); }
                                            if (B != "") { TH = TH + "(" + B + ")"; }

                                            STR = STR + ("<tr>");
                                            STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + THMAX + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + THMIN + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + TH + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("</tr>");
                                        }
                                    }
                                }//END BACK THEORY
                                for (int i = 1; i <= 12; i++)//START BACK PRACTICAL i=7 Now 12
                                {
                                    string PBACK = dtrec.Rows[0]["BPAPP" + i.ToString()].ToString().Trim();
                                    if (PBACK != "")
                                    {
                                        DataTable dtsub = new DataTable();
                                        _sqlQuery = "SELECT SUBJECT,THMAX,THMIN,PRMAX,PRMIN FROM SUBJ WHERE SUBCODE='" + PBACK + "' AND BRCODE='" + BR + "'";
                                        AllQueryParam[0] = _sqlQuery;
                                        objbllLogin.QUERYBLL(ref dtsub, AllQueryParam);
                                        if (dtsub.Rows.Count > 0)
                                        {
                                            string SNAME = PBACK + "-" + dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                            string PRMAX = dtsub.Rows[0]["PRMAX"].ToString().Trim();
                                            string PRMIN = dtsub.Rows[0]["PRMIN"].ToString().Trim();

                                            string PR = dtrec.Rows[0]["BPR" + i.ToString()].ToString().Trim();
                                            string B = dtrec.Rows[0]["BP" + i.ToString()].ToString().Trim();
                                            if (B != "B") { Sublist.Remove(PBACK + "P"); }
                                            if (B != "") { PR = PR + "(" + B + ")"; }

                                            STR = STR + ("<tr>");
                                            STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + PRMAX + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + PRMIN + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + PR + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("</tr>");
                                        }
                                    }
                                }
                            }
                            if (RLFLG != "UFM") { for (int T = GTOT.Length; T < 4; T++) { GTOT = "0" + GTOT; } }
                            else { GTOT = ""; }
                            STR = STR + ("<tr>");
                            STR = STR + ("<th valign=\"top\" align=\"left\">Total : " + GTOT + "</th>");
                            STR = STR + ("</tr>");
                            STR = STR + ("<tr>");
                            STR = STR + ("<th valign=\"top\" align=\"left\">Result : " + RES + "</th>");
                            STR = STR + ("</tr>");
                            GTOT = ""; RES = "";
                        }
                    }//
                    #endregion OLD_SUBJECT
                    #region NEW_SUBJECT
                    else//NEW SUBJECT LIST
                    {
                        _sqlQuery = "select * from " + TBL + " where ROLL='" + ROLL + "' AND SESS='" + SESS + "'";
                        AllQueryParam[0] = _sqlQuery;
                        objbllLogin.QUERYBLL(ref dtrec, AllQueryParam);
                        if (dtrec.Rows.Count > 0)
                        {
                            string PRREGPVT = dtrec.Rows[0]["REGPVT"].ToString().Trim();
                            string SEM = dtrec.Rows[0]["SEM"].ToString().Trim();
                            if (TBL == "NPRIVAT")
                            {
                                PrivateBack = "P";
                                string TYPEX = string.Empty;
                                if (BR == "07") { TYPEX = "YEAR"; } else { TYPEX = "SEMESTER"; }
                                if (PRREGPVT == "S" || PRREGPVT == "Q") { CAP1 = "SPECIAL BACK : " + TYPEX; } else { CAP1 = " PRIVATE : " + TYPEX; }
                            }
                            string CAPTION = CAP1 + "-" + SEM + " [ " + SESS + " ]";
                            STR = STR + ("<tr>");
                            STR = STR + ("<th colspan='16' style='background-color: #3CB371; font-family:Agency FB; color: #FFFFFF; font-size: 20px' valign=\"bottom\" align=\"center\">" + CAPTION + "</th>");
                            STR = STR + ("</tr>");
                            //Header
                            STR = STR + ("<tr>");
                            STR = STR + ("<td rowspan='2' style='background-color:#008B8B; color: #F5DEB3; font-size: 18px' valign=\"top\" align=\"left\">SUBJECTS</td>");
                            STR = STR + ("<td colspan='6' style='background-color:#008B8B; color: #F5DEB3; font-size: 18px' valign=\"top\" align=\"center\">THEORY</td>");
                            STR = STR + ("<td colspan='5' style='background-color:#008B8B; color: #F5DEB3; font-size: 18px' valign=\"top\" align=\"center\">PRACTICAL</td>");
                            STR = STR + ("<td rowspan='2' style='background-color:#008B8B; color: #F5DEB3; font-size: 18px' valign=\"top\" align=\"center\">GRADE</td>");
                            STR = STR + ("<td colspan='3' style='background-color:#008B8B; color: #F5DEB3; font-size: 18px' valign=\"top\" align=\"center\">SESSIONAL</td>");
                            STR = STR + ("</tr>");
                            STR = STR + ("<tr>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">MAX</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">MIN</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">OBT</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">SESS MAX</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">SESS OBT</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">TOT</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">MAX</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">OBT</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">SESS MAX</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">SESS OBT</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">TOT</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">MAX</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">MIN</td>");
                            STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">OBT</td>");
                            STR = STR + ("</tr>");

                            RLFLG = dtrec.Rows[0]["RLFLG"].ToString().Trim();
                            if (RLFLG == "UFM") { RES = "UFM"; GTOT = ""; }
                            else
                            {//NOT UFM
                                SGPA = dtrec.Rows[0]["SGPA"].ToString().Trim();
                                RES = dtrec.Rows[0]["RESULT1"].ToString().Trim();

                                GTOT = dtrec.Rows[0]["TOTAL"].ToString().Trim();

                                if (TBL != "NPRIVAT")
                                {
                                    #region Main Subject
                                    
                                   
                                        for (int i = 1; i <= 10; i++)
                                        {
                                            string SUB = dtrec.Rows[0]["SUB" + i.ToString()].ToString().Trim();
                                            if (SUB != "")
                                            {//SUBJECT FOUND
                                                DataTable dtsub = new DataTable();
                                                _sqlQuery = "SELECT * FROM SUBN WHERE SUBCODE='" + SUB + "' AND BRCODE='" + BR + "'";
                                                AllQueryParam[0] = _sqlQuery;
                                                objbllLogin.QUERYBLL(ref dtsub, AllQueryParam);
                                                if (dtsub.Rows.Count > 0)
                                                {
                                                    string SNAME = SUB + "-" + dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                                    string THMAX = dtsub.Rows[0]["THMAX"].ToString().Trim();
                                                    string THMIN = dtsub.Rows[0]["THMIN"].ToString().Trim();
                                                    string TSMAX = dtsub.Rows[0]["TSMAX"].ToString().Trim();
                                                    string PRMAX = dtsub.Rows[0]["PRMAX"].ToString().Trim();
                                                    string PSMAX = dtsub.Rows[0]["PSMAX"].ToString().Trim();


                                                    string SUBTYPE = dtsub.Rows[0]["TYPE"].ToString().Trim();
                                                    string CREDIT = dtsub.Rows[0]["CREDIT"].ToString().Trim();

                                                    if (SUB == "024003") { SUBTYPE = "TP"; }
                                                    else if (SUB == "026004") { SUBTYPE = "TP"; }
                                                    else if (SUB == "084001") { SUBTYPE = "TP"; }

                                                    //THEORY MARKS
                                                    string GRD = dtrec.Rows[0]["G" + i.ToString()].ToString().Trim();
                                                    string[] SS = GRD.Split('-');
                                                    GRD = SS[0].ToString();

                                                    decimal FF = Convert.ToDecimal(CREDIT);
                                                    if (TBL == "NSEMESTER1") { CR1 = CR1 + FF; SG1 = Convert.ToDecimal(SGPA); }
                                                    if (TBL == "NSEMESTER2") { CR2 = CR2 + FF; SG2 = Convert.ToDecimal(SGPA); }
                                                    if (TBL == "NSEMESTER3") { CR3 = CR3 + FF; SG3 = Convert.ToDecimal(SGPA); }
                                                    if (TBL == "NSEMESTER4")
                                                    {
                                                        CR4 = CR4 + FF; SG4 = Convert.ToDecimal(SGPA);
                                                    }
                                                    if (TBL == "NSEMESTER5") { CR5 = CR5 + FF; SG5 = Convert.ToDecimal(SGPA); }
                                                    if (TBL == "NSEMESTER6") { CR6 = CR6 + FF; SG6 = Convert.ToDecimal(SGPA); }


                                                    string TH = "000";
                                                    string THS = "000";
                                                    string TOTTH = "000";
                                                    string TB = string.Empty;
                                                    if (SUBTYPE == "T" || SUBTYPE == "TP")
                                                    {
                                                        if (RLFLG != "UFM")
                                                        {
                                                            TH = dtrec.Rows[0]["T" + i.ToString()].ToString().Trim();
                                                            THS = dtrec.Rows[0]["TS" + i.ToString()].ToString().Trim();
                                                        }
                                                        if (TH != "" && TH != "ABS" && TH != "AB" && TH != "N/A") { TOTTH = (Convert.ToInt32(TOTTH) + Convert.ToInt32(TH)).ToString(); }
                                                        if (THS != "" && THS != "ABS" && THS != "AB" && THS != "N/A") { TOTTH = (Convert.ToInt32(TOTTH) + Convert.ToInt32(THS)).ToString(); }

                                                        if (TH.Length > 0) { for (int T = TH.Length; T < 3; T++) { TH = "0" + TH; } }
                                                        if (THS.Length > 0) { for (int T = THS.Length; T < 3; T++) { THS = "0" + THS; } }
                                                        if (TOTTH.Length > 0) { for (int T = TOTTH.Length; T < 3; T++) { TOTTH = "0" + TOTTH; } }

                                                        TB = dtrec.Rows[0]["GBT" + i.ToString()].ToString().Trim();

                                                        if (TB != "") { TH = TH + "(BK)"; }


                                                        //if (TB != "")
                                                        //{

                                                        //    if (Convert.ToInt16(SMMM) == z + 1 && TYPE == "PRIVATE")
                                                        //    {
                                                        //        PFlag = "Y";
                                                        //        TH = TH + "(BK)";
                                                        //        //
                                                        //    }
                                                        //    else
                                                        //    {
                                                        //        TH = TH + "(BK)";
                                                        //    }
                                                        //}


                                                        if (TB != "B")
                                                        {
                                                            decimal DEC = 0;
                                                            if (SGPA == "") { SGPA = "0"; }
                                                            DEC = Convert.ToDecimal(SGPA);

                                                            //if (DEC >= 4) {
                                                            Sublist.Remove(SUB + "T");
                                                            //}

                                                        }
                                                    }
                                                    else { TH = ""; THS = ""; TOTTH = ""; TB = ""; }
                                                    //PRACTICAL MARKS
                                                    string PR = "000";
                                                    string PRS = "000";
                                                    string TOTPR = "000";
                                                    string PB = string.Empty;
                                                    if (SUBTYPE == "P" || SUBTYPE == "TP" || SUB == "023003")
                                                    {
                                                        PR = dtrec.Rows[0]["P" + i.ToString()].ToString().Trim();
                                                        PRS = dtrec.Rows[0]["PS" + i.ToString()].ToString().Trim();
                                                        if (PR != "" && PR != "ABS" && PR != "AB" && PR != "N/A") { TOTPR = (Convert.ToInt32(TOTPR) + Convert.ToInt32(PR)).ToString(); }
                                                        if (PRS != "" && PRS != "ABS" && PRS != "AB" && PRS != "N/A") { TOTPR = (Convert.ToInt32(TOTPR) + Convert.ToInt32(PRS)).ToString(); }

                                                        if (PR.Length > 0) { for (int T = PR.Length; T < 3; T++) { PR = "0" + PR; } }
                                                        if (PRS.Length > 0) { for (int T = PRS.Length; T < 3; T++) { PRS = "0" + PRS; } }
                                                        if (TOTPR.Length > 0) { for (int T = TOTPR.Length; T < 3; T++) { TOTPR = "0" + TOTPR; } }


                                                        PB = dtrec.Rows[0]["GBP" + i.ToString()].ToString().Trim();
                                                        if (PB != "") { PR = PR + "(BK)"; }
                                                        if (PB != "B") { Sublist.Remove(SUB + "P"); }
                                                    }
                                                    else { PR = ""; PRS = ""; TOTPR = ""; PB = ""; }
                                                    STR = STR + ("<tr>");
                                                    STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + THMAX + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + THMIN + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + TH + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + TSMAX + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + THS + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + TOTTH + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + PRMAX + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + PR + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + PSMAX + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + PRS + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + TOTPR + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + GRD + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("</tr>");
                                                }
                                            }
                                        }
                                   
                                    #endregion

                                    #region OptionalSubject
                                    
                                    DataTable dtsesssub = new DataTable();
                                    _sqlQuery = "SELECT SUBJECT,SUBMAX,SUBMIN,CREDIT FROM SUBSESSN WHERE BRCODE='" + BR + "' AND SEM='" + SEM + "' ORDER BY SUBCODE";
                                    AllQueryParam[0] = _sqlQuery;
                                    objbllLogin.QUERYBLL(ref dtsesssub, AllQueryParam);
                                    for (int i = 0; i < dtsesssub.Rows.Count; i++)//SESSIONAL MARKS
                                    {

                                        string CREDIT = dtsesssub.Rows[0]["CREDIT"].ToString().Trim();
                                        decimal FF = Convert.ToDecimal(CREDIT);
                                        if (TBL == "NSEMESTER1") { CR1 = CR1 + FF; }
                                        if (TBL == "NSEMESTER2") { CR2 = CR2 + FF; }
                                        if (TBL == "NSEMESTER3") { CR3 = CR3 + FF; }
                                        if (TBL == "NSEMESTER4") { CR4 = CR4 + FF; }
                                        if (TBL == "NSEMESTER5") { CR5 = CR5 + FF; }
                                        if (TBL == "NSEMESTER6") { CR6 = CR6 + FF; }



                                        string SNAME = dtsesssub.Rows[i]["SUBJECT"].ToString().Trim();
                                        string SSMAX = dtsesssub.Rows[i]["SUBMAX"].ToString().Trim();
                                        string SSMIN = dtsesssub.Rows[i]["SUBMIN"].ToString().Trim();
                                        string OBT = dtrec.Rows[0]["SSMKS" + (i + 1).ToString()].ToString().Trim();
                                        if (OBT.Length > 0) { for (int T = OBT.Length; T < 3; T++) { OBT = "0" + OBT; } }

                                        STR = STR + ("<tr>");
                                        STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + SSMAX + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + SSMIN + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + OBT + "</td>");
                                        STR = STR + ("</tr>");
                                    }
                                    #endregion
                                }                               
                                if (z > 0 || GRP == "A")
                                {
                                    #region Back Theory Subject
                                    
                                        for (int i = 1; i <= 26; i++)//BACK THEORY
                                        {
                                            string TBACK = dtrec.Rows[0]["BPAPT" + i.ToString()].ToString().Trim();
                                            if (TBACK != "")
                                            {
                                                ///Sublist.Remove(TBACK + "T");
                                                /// Sublist.Add(TBACK + "T");
                                                DataTable dtsub = new DataTable();
                                                _sqlQuery = "SELECT * FROM SUBN WHERE SUBCODE='" + TBACK + "' AND BRCODE='" + BR + "'";
                                                AllQueryParam[0] = _sqlQuery;
                                                objbllLogin.QUERYBLL(ref dtsub, AllQueryParam);
                                                if (dtsub.Rows.Count > 0)
                                                {
                                                    string SNAME = TBACK + "-" + dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                                    string THMAX = dtsub.Rows[0]["THMAX"].ToString().Trim();
                                                    string THMIN = dtsub.Rows[0]["THMIN"].ToString().Trim();
                                                    string TH = dtrec.Rows[0]["BMRK" + i.ToString()].ToString().Trim();

                                                    if (TH.Length > 0) { for (int T = TH.Length; T < 3; T++) { TH = "0" + TH; } }
                                                    string THS = dtrec.Rows[0]["SMRK" + i.ToString()].ToString().Trim();
                                                    if (THS.Length > 0) { for (int T = THS.Length; T < 3; T++) { THS = "0" + THS; } }

                                                    int TM = 0; if (TH != "ABS" && TH != "" && TH != "N/A") { TM = Convert.ToInt32(TH); }
                                                    int SM = 0; if (THS != "ABS" && THS != "" && THS != "N/A") { SM = Convert.ToInt32(THS); }

                                                    string TOTTH = (TM + SM).ToString();
                                                    if (TH == "ABS" || THS == "ABS") { TOTTH = "ABS"; }
                                                    else { if (TOTTH.Length > 0) { for (int T = TOTTH.Length; T < 3; T++) { TOTTH = "0" + TOTTH; } } }
                                                    string B = dtrec.Rows[0]["BT" + i.ToString()].ToString().Trim();
                                                    if (B != "") { TOTTH = TOTTH + "(" + B + ")"; }

                                                    if (B != "B")
                                                    {
                                                        Sublist.Remove(TBACK + "T");
                                                        //if (GRP == "A" || GRP == "E")
                                                        //{
                                                        //    Sublist.Remove(TBACK + "T");
                                                        //}
                                                        string SSSEM = SMMM.Substring(1, 1);
                                                        decimal DEC = 0;

                                                        if (SSSEM == "1" || SSSEM == "2")
                                                        {
                                                            if (CGPA2 == "") { CGPA2 = "0"; }
                                                            DEC = Convert.ToDecimal(CGPA2);
                                                            FCGPA = Convert.ToDecimal(CGPA2);

                                                        }
                                                        else if (SSSEM == "3" || SSSEM == "4")
                                                        {

                                                            if (CGPA4 == "") { CGPA4 = "0"; }
                                                            DEC = Convert.ToDecimal(CGPA4);
                                                            FCGPA = Convert.ToDecimal(CGPA4);
                                                        }
                                                        else if (SSSEM == "5" || SSSEM == "6")
                                                        {
                                                            if (CGPA6 == "") { CGPA6 = "0"; }
                                                            DEC = Convert.ToDecimal(CGPA6);
                                                            FCGPA = Convert.ToDecimal(CGPA6);
                                                        }


                                                        //if (DEC >= 4 || DEC == 0) { Sublist.Remove(TBACK + "T"); }

                                                    }
                                                    string SESSMAX = dtsub.Rows[0]["TSMAX"].ToString().Trim();
                                                    STR = STR + ("<tr>");
                                                    STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + THMAX + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + THMIN + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + TH + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + SESSMAX + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + THS + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + TOTTH + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("</tr>");
                                                }
                                            }
                                        }//END BACK THEORY
                                  
                                    #endregion
                                    //BACK PRACTICAL
                                    #region Back Practical Subject
                                  
                                        for (int i = 1; i <= 12; i++)
                                        {
                                            Sublist.Sort();
                                            string PBACK = dtrec.Rows[0]["BPAPP" + i.ToString()].ToString().Trim();
                                            if (PBACK != "")
                                            {
                                                DataTable dtsub = new DataTable();
                                                _sqlQuery = "SELECT * FROM SUBN WHERE SUBCODE='" + PBACK + "' AND BRCODE='" + BR + "'";
                                                AllQueryParam[0] = _sqlQuery;
                                                objbllLogin.QUERYBLL(ref dtsub, AllQueryParam);
                                                if (dtsub.Rows.Count > 0)
                                                {
                                                    string SNAME = PBACK + "-" + dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                                    string PRMAX = dtsub.Rows[0]["PRMAX"].ToString().Trim();
                                                    string PRMIN = dtsub.Rows[0]["PRMIN"].ToString().Trim();
                                                    string PR = dtrec.Rows[0]["BPR" + i.ToString()].ToString().Trim();
                                                    if (PR.Length > 0) { for (int T = PR.Length; T < 3; T++) { PR = "0" + PR; } }
                                                    string PRS = dtrec.Rows[0]["SPR" + i.ToString()].ToString().Trim();
                                                    if (PRS.Length > 0) { for (int T = PRS.Length; T < 3; T++) { PRS = "0" + PRS; } }
                                                    int PM = 0; if (PR != "ABS" && PR != "" && PR != "N/A") { PM = Convert.ToInt32(PR); }
                                                    int SM = 0; if (PRS != "ABS" && PRS != "" && PRS != "N/A") { SM = Convert.ToInt32(PRS); }
                                                    string TOTPR = (PM + SM).ToString();
                                                    if (TOTPR.Length > 0) { for (int T = TOTPR.Length; T < 3; T++) { TOTPR = "0" + TOTPR; } }
                                                    string B = dtrec.Rows[0]["BP" + i.ToString()].ToString().Trim();
                                                    if (B != "") { TOTPR = TOTPR + "(" + B + ")"; }
                                                    if (B != "B") { Sublist.Remove(PBACK + "P"); }


                                                    string SESSMAX = dtsub.Rows[0]["PSMAX"].ToString().Trim();
                                                    STR = STR + ("<tr>");
                                                    STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + PRMAX + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + PR + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + SESSMAX + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + PRS + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\">" + TOTPR + "</td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                                    STR = STR + ("</tr>");
                                                }
                                            }
                                        }//END BACK PRACTICAL
                                  
                                    #endregion
                                }
                            }
                            if (RLFLG != "UFM") { for (int T = GTOT.Length; T < 4; T++) { GTOT = "0" + GTOT; } }
                            else { GTOT = ""; }
                            STR = STR + ("<tr>");
                            STR = STR + ("<th style='font-size: 18px' valign=\"top\" align=\"left\">Total : " + GTOT + "</th>");

                            //SemCount = SemCount + 1;

                            //try
                            //{

                            //    if (Sesslist.Count == SemCount)
                            //    {
                            //        if (Convert.ToDouble(SGPA) < 4)
                            //        {
                            //            //STR = STR + ("<th style='font-size: 18px' colspan='15' rowspan='3' valign=\"middle\" align=\"left\">SGPA < 4, student will re-appear all theory examinations of the semester" + "</th>");
                            //        }

                            //    }
                            //}
                            //catch
                            //{

                            //}


                            STR = STR + ("</tr>");
                            STR = STR + ("<tr>");
                            STR = STR + ("<th style='font-size: 18px' valign=\"top\" align=\"left\">Result : " + RES + "</th>");

                            STR = STR + ("</tr>");
                            STR = STR + ("<tr>");
                            STR = STR + ("<th style='font-size: 18px' valign=\"top\" align=\"left\">SGPA : " + SGPA + "</th>");

                            STR = STR + ("</tr>");


                        }

                        if ((z == Sesslist.Count - 1) && ((BR == "15" || BR == "17" && SMMM == "04") || (SMMM == "06")))
                        {
                            /////////////////////////////////////////Averge Percentage
                            ///
                            if (CGPA2.Trim() == "") { CGPA2 = "0"; }
                            if (CGPA4.Trim() == "") { CGPA4 = "0"; }
                            if (CGPA6.Trim() == "") { CGPA6 = "0"; }

                            decimal A = (CR1 + CR2) * Convert.ToDecimal(CGPA2) / 2;
                            decimal B = (CR3 + CR4) * Convert.ToDecimal(CGPA4);
                            decimal C = (CR5 + CR6) * Convert.ToDecimal(CGPA6);
                            decimal X = (CR1 + CR2) / 2;
                            decimal Y = (CR3 + CR4);
                            decimal Z = (CR5 + CR6);

                            string AVP = string.Empty;
                            string FCGPA = string.Empty;
                            string FG = string.Empty;
                            string DESC = string.Empty;

                            DataTable dtcgpa = new DataTable();
                            //_sqlQuery = "SELECT * FROM RESULT WHERE ROLL='" + ROLL + "' AND SEM='0" + TBL.Substring(TBL.Length - 1) + "'";
                            _sqlQuery = "SELECT * FROM RESULT WHERE ROLL='" + ROLL + "' AND SEM='"+SMMM+"'";
                            AllQueryParam[0] = _sqlQuery;
                            objbllLogin.QUERYBLL(ref dtcgpa, AllQueryParam);
                            if (dtcgpa.Rows.Count > 0)
                            {
                               // CGPA2A = Convert.ToDecimal(dtcgpa.Rows[0]["CGPA"].ToString().Trim());
                                AVP = dtcgpa.Rows[0]["AVP"].ToString().Trim();
                                FCGPA = dtcgpa.Rows[0]["FCGPA"].ToString().Trim();
                                FG = dtcgpa.Rows[0]["FG"].ToString().Trim();
                                DESC = dtcgpa.Rows[0]["DESC"].ToString().Trim();
                            }


                            //decimal PER2 = (A + B + C) / (X + Y + Z) * 10;
                            //if (PER2 > 90 && PER2 <= 100) { FCGPA = "10"; FG = "O"; DESC = "OUTSTANDING"; }
                            //else if (PER2 > 80 && PER2 <= 90) { FCGPA = "9"; FG = "A+"; DESC = "EXCELLENT"; }
                            //else if (PER2 > 70 && PER2 <= 80) { FCGPA = "8"; FG = "A"; DESC = "VERY GOOD"; }
                            //else if (PER2 > 60 && PER2 <= 70) { FCGPA = "7"; FG = "B+"; DESC = "GOOD"; }
                            //else if (PER2 > 50 && PER2 <= 60) { FCGPA = "6"; FG = "B"; DESC = "ABOVE AVERAGE"; }
                            //else if (PER2 > 40 && PER2 <= 50) { FCGPA = "5"; FG = "C"; DESC = "AVERAGE"; }
                            //else if (PER2 >= 33 && PER2 <= 40) { FCGPA = "4"; FG = "P"; DESC = "PASS"; }
                            //else if (PER2 >= 32 && PER2 <= 0) { FCGPA = "0"; FG = "F"; DESC = "FAIL"; }

                            //AVP = (Math.Round(PER2, 2)).ToString();


                            STR = STR + ("<tr>");
                            STR = STR + ("<th colspan='16' style='font-size: 18px; background-color:#DCDCDC; color: #000000;' valign=\"top\" align=\"left\">Average Percentage : " + AVP + "%, Final CGPA : " + FCGPA + ", Final Grade : " + FG + ", Description : " + DESC + "</th>");
                            STR = STR + ("</tr>");
                        }
                    }
                    #endregion NEW_SUBJECT
                }


            }//NOT PHARMACY(16)

            #region PHAMACy Course
            else
            {//PHARMACY(16)
                string RES = string.Empty;
                string GTOT = string.Empty;
                string CAP1 = string.Empty;
                DataTable dtrec = new DataTable();
                _sqlQuery = "select * from PH where ROLL='" + ROLL + "' ORDER BY SUBSTRING(SESS,4,4) ASC, SUBSTRING(SESS,1,2) ASC";
                AllQueryParam[0] = _sqlQuery;
                objbllLogin.QUERYBLL(ref dtrec, AllQueryParam);
                if (dtrec.Rows.Count > 0)
                {
                    //Header
                    STR = STR + ("<tr>");
                    STR = STR + ("<td rowspan='2' style='background-color:#008B8B; color: #F5DEB3; font-size: 18px' valign=\"top\" align=\"left\">SUBJECTS</td>");
                    STR = STR + ("<td colspan='6' style='background-color:#008B8B; color: #F5DEB3; font-size: 18px' valign=\"top\" align=\"center\">THEORY</td>");
                    STR = STR + ("<td colspan='6' style='background-color:#008B8B; color: #F5DEB3; font-size: 18px' valign=\"top\" align=\"center\">PRACTICAL</td>");
                    STR = STR + ("<td colspan='3' style='background-color:#008B8B; color: #F5DEB3; font-size: 18px' valign=\"top\" align=\"center\">SESSIONAL</td>");
                    STR = STR + ("</tr>");
                    STR = STR + ("<tr>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">MAX</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">MIN</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">OBT</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">SESS MAX</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">SESS OBT</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">TOT</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">MAX</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">MIN</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">OBT</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">SESS MAX</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">SESS OBT</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">TOT</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">MAX</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">MIN</td>");
                    STR = STR + ("<td style='background-color:#66CDAA; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">OBT</td>");
                    STR = STR + ("</tr>");
                    for (int r = 0; r < dtrec.Rows.Count; r++)
                    {
                        string SMCODE = "0" + dtrec.Rows[r]["SMCODE"].ToString().Trim();
                        string REGPVT = dtrec.Rows[r]["REGPVT"].ToString().Trim();
                        CAP1 = "YEAR-" + SMCODE;
                        if (REGPVT == "P") { CAP1 = "PRIVATE : " + CAP1; }
                        else if (REGPVT == "S" || REGPVT == "Q") { CAP1 = "SPECIAL BACK : " + CAP1; }
                        string SESS = dtrec.Rows[r]["SESS"].ToString().Trim();
                        string CAPTION = CAP1 + " [ " + SESS + " ]";
                        STR = STR + ("<tr>");
                        STR = STR + ("<th colspan='16' style='background-color: #3CB371; font-family:Agency FB; color: #FFFFFF; font-size: 20px' valign=\"bottom\" align=\"center\">" + CAPTION + "</th>");
                        STR = STR + ("</tr>");
                        RLFLG = dtrec.Rows[r]["RLFLG"].ToString().Trim();
                        if (RLFLG == "UFM") { RES = "UFM"; GTOT = ""; }
                        else
                        {//NOT UFM
                            RES = dtrec.Rows[r]["RESULT1"].ToString().Trim();
                            GTOT = dtrec.Rows[r]["TOTAL"].ToString().Trim();
                            string DIV = dtrec.Rows[r]["DIV"].ToString().Trim();
                            if (DIV != "") { RES = RES + ", (" + DIV + ")"; }
                            for (int i = 1; i <= 6; i++)
                            {
                                string SUB = dtrec.Rows[r]["SUB" + i.ToString()].ToString().Trim();
                                if (SUB != "")
                                {//SUBJECT FOUND
                                    DataTable dtsub = new DataTable();
                                    if (STUTYPE == "N") { _sqlQuery = "SELECT * FROM SUBN WHERE SUBCODE='" + SUB + "' AND BRCODE='" + BR + "'"; }
                                    else { _sqlQuery = "SELECT * FROM SUBJ WHERE SUBCODE='" + SUB + "' AND BRCODE='" + BR + "'"; }
                                    AllQueryParam[0] = _sqlQuery;
                                    objbllLogin.QUERYBLL(ref dtsub, AllQueryParam);
                                    if (dtsub.Rows.Count > 0)
                                    {
                                        string SNAME = SUB + "-" + dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                        string THMAX = dtsub.Rows[0]["THMAX"].ToString().Trim();
                                        string THMIN = dtsub.Rows[0]["THMIN"].ToString().Trim();
                                        string PRMAX = dtsub.Rows[0]["PRMAX"].ToString().Trim();
                                        string PRMIN = dtsub.Rows[0]["PRMIN"].ToString().Trim();
                                        string SUBTYPE = dtsub.Rows[0]["TYPE"].ToString().Trim();
                                        //THEORY MARKS
                                        string TH = "000";
                                        string THS = "000";
                                        string TOTTH = "000";
                                        string TB = string.Empty;
                                        if (SUBTYPE == "T" || SUBTYPE == "TP")
                                        {
                                            if (RLFLG != "UFM")
                                            {
                                                TH = dtrec.Rows[r]["T" + i.ToString()].ToString().Trim();
                                                THS = dtrec.Rows[r]["TS" + i.ToString()].ToString().Trim();
                                            }
                                            if (TH != "" && TH != "ABS" && TH != "AB") { TOTTH = (Convert.ToInt32(TOTTH) + Convert.ToInt32(TH)).ToString(); }
                                            if (THS != "" && THS != "ABS" && THS != "AB") { TOTTH = (Convert.ToInt32(TOTTH) + Convert.ToInt32(THS)).ToString(); }
                                            for (int T = TH.Length; T < 3; T++) { TH = "0" + TH; }
                                            for (int T = THS.Length; T < 3; T++) { THS = "0" + THS; }
                                            for (int T = TOTTH.Length; T < 3; T++) { TOTTH = "0" + TOTTH; }
                                            TB = dtrec.Rows[r]["GBT" + i.ToString()].ToString().Trim();
                                            if (TB != "") { TH = TH + "(" + TB + ")"; }
                                        }
                                        else { TH = ""; THS = ""; TOTTH = ""; TB = ""; }
                                        //PRACTICAL MARKS
                                        string PR = "000";
                                        string PRS = "000";
                                        string TOTPR = "000";
                                        string PB = string.Empty;
                                        if (SUBTYPE == "P" || SUBTYPE == "TP")
                                        {
                                            PR = dtrec.Rows[r]["P" + i.ToString()].ToString().Trim();
                                            PRS = dtrec.Rows[r]["PS" + i.ToString()].ToString().Trim();
                                            if (PR != "" && PR != "ABS" && PR != "AB") { TOTPR = (Convert.ToInt32(TOTPR) + Convert.ToInt32(PR)).ToString(); }
                                            if (PRS != "" && PRS != "ABS" && PRS != "AB") { TOTPR = (Convert.ToInt32(TOTPR) + Convert.ToInt32(PRS)).ToString(); }
                                            for (int T = PR.Length; T < 3; T++) { PR = "0" + PR; }
                                            for (int T = PRS.Length; T < 3; T++) { PRS = "0" + PRS; }
                                            for (int T = TOTPR.Length; T < 3; T++) { TOTPR = "0" + TOTPR; }
                                            PB = dtrec.Rows[r]["GBP" + i.ToString()].ToString().Trim();
                                            if (PB != "") { PR = PR + "(" + PB + ")"; }
                                        }
                                        else { PR = ""; PRS = ""; TOTPR = ""; PB = ""; }

                                        string SESSMAX = dtsub.Rows[0]["TSMAX"].ToString().Trim();
                                        STR = STR + ("<tr>");
                                        STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + THMAX + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + THMIN + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + TH + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + SESSMAX + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + THS + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + TOTTH + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + PRMAX + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + PRMIN + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + PR + "</td>");
                                        if (SUBTYPE == "P" || SUBTYPE == "TP") { STR = STR + ("<td valign=\"top\" align=\"center\">" + SESSMAX + "</td>"); }
                                        else { STR = STR + ("<td valign=\"top\" align=\"center\"></td>"); }
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + PRS + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + TOTPR + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("</tr>");

                                        //if (RES.ToUpper() != "FAIL" && RES.ToUpper() != "X") { if (TB != "B") { Sublist.Remove(SUB + "T"); } }

                                        if (RES.ToUpper() != "FAIL")
                                        {
                                            if (TB != "B")
                                            {
                                                Sublist.Remove(SUB + "T");
                                            }
                                            else
                                            {
                                                if ((Sublist.Contains(SUB + "T")) == false)
                                                {
                                                    Sublist.Add(SUB + "T");
                                                }
                                            }
                                        }


                                        if (PB != "B") { Sublist.Remove(SUB + "P"); }
                                    }
                                }
                            }
                            for (int i = 2; i <= 3; i++)//SESSIONAL MARKS
                            {
                                string SUB = dtrec.Rows[r]["SS5" + i.ToString()].ToString().Trim();
                                if (SUB != "")
                                {
                                    DataTable dtsub = new DataTable();
                                    if (STUTYPE == "N") { _sqlQuery = "SELECT SUBJECT,SUBMAX,SUBMIN FROM SUBSESSN WHERE SUBCODE='" + SUB + "' AND BRCODE='" + BR + "'"; }
                                    else { _sqlQuery = "SELECT SUBJECT,SUBMAX,SUBMIN FROM SUBSESS WHERE SUBCODE='" + SUB + "' AND BRCODE='" + BR + "'"; }
                                    AllQueryParam[0] = _sqlQuery;
                                    objbllLogin.QUERYBLL(ref dtsub, AllQueryParam);
                                    if (dtsub.Rows.Count > 0)
                                    {
                                        string SNAME = dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                        string SSMAX = dtsub.Rows[0]["SUBMAX"].ToString().Trim();
                                        string SSMIN = dtsub.Rows[0]["SUBMIN"].ToString().Trim();
                                        string OBT = dtrec.Rows[r]["SSMKS" + i.ToString()].ToString().Trim();
                                        for (int T = OBT.Length; T < 3; T++) { OBT = "0" + OBT; }
                                        STR = STR + ("<tr>");
                                        STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + SSMAX + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + SSMIN + "</td>");
                                        STR = STR + ("<td valign=\"top\" align=\"center\">" + OBT + "</td>");
                                        STR = STR + ("</tr>");
                                    }
                                }
                            }
                            if (r > 0)
                            {
                                for (int i = 1; i <= 2; i++)//BACK THEORY
                                {
                                    string TBACK = dtrec.Rows[r]["BPAPT" + i.ToString()].ToString().Trim();
                                    if (TBACK != "")
                                    {
                                        DataTable dtsub = new DataTable();
                                        if (STUTYPE == "N") { _sqlQuery = "SELECT * FROM SUBN WHERE SUBCODE='" + TBACK + "' AND BRCODE='" + BR + "'"; }
                                        else { _sqlQuery = "SELECT * FROM SUBJ WHERE SUBCODE='" + TBACK + "' AND BRCODE='" + BR + "'"; }
                                        AllQueryParam[0] = _sqlQuery;
                                        objbllLogin.QUERYBLL(ref dtsub, AllQueryParam);
                                        if (dtsub.Rows.Count > 0)
                                        {
                                            string SNAME = TBACK + "-" + dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                            string THMAX = dtsub.Rows[0]["THMAX"].ToString().Trim();
                                            string THMIN = dtsub.Rows[0]["THMIN"].ToString().Trim();
                                            string TH = dtrec.Rows[r]["BMRK" + i.ToString()].ToString().Trim();
                                            for (int T = TH.Length; T < 3; T++) { TH = "0" + TH; }
                                            string THS = dtrec.Rows[r]["SMRK" + i.ToString()].ToString().Trim();
                                            for (int T = THS.Length; T < 3; T++) { THS = "0" + THS; }

                                            int TM = 0; if (TH != "ABS" && TH != "") { TM = Convert.ToInt32(TH); }
                                            int SM = 0; if (THS != "ABS" && THS != "") { SM = Convert.ToInt32(THS); }

                                            string TOTTH = (TM + SM).ToString();
                                            for (int T = TOTTH.Length; T < 3; T++) { TOTTH = "0" + TOTTH; }

                                            string B = dtrec.Rows[r]["BT" + i.ToString()].ToString().Trim();
                                            if (B != "B") { Sublist.Remove(TBACK + "T"); }
                                            if (B != "") { TOTTH = TOTTH + "(" + B + ")"; }

                                            string SESSMAX = dtsub.Rows[0]["TSMAX"].ToString().Trim();
                                            STR = STR + ("<tr>");
                                            STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + THMAX + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + THMIN + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + TH + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + SESSMAX + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + THS + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + TOTTH + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");

                                            STR = STR + ("</tr>");
                                        }
                                    }
                                }//END BACK THEORY
                                //BACK PRACTICAL
                                for (int i = 1; i <= 2; i++)
                                {
                                    string PBACK = dtrec.Rows[r]["BPAPP" + i.ToString()].ToString().Trim();
                                    if (PBACK != "")
                                    {
                                        DataTable dtsub = new DataTable();
                                        if (STUTYPE == "N") { _sqlQuery = "SELECT * FROM SUBN WHERE SUBCODE='" + PBACK + "' AND BRCODE='" + BR + "'"; }
                                        else { _sqlQuery = "SELECT * FROM SUBJ WHERE SUBCODE='" + PBACK + "' AND BRCODE='" + BR + "'"; }
                                        AllQueryParam[0] = _sqlQuery;
                                        objbllLogin.QUERYBLL(ref dtsub, AllQueryParam);
                                        if (dtsub.Rows.Count > 0)
                                        {
                                            string SNAME = PBACK + "-" + dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                            string PRMAX = dtsub.Rows[0]["PRMAX"].ToString().Trim();
                                            string PRMIN = dtsub.Rows[0]["PRMIN"].ToString().Trim();
                                            string PR = dtrec.Rows[r]["BPR" + i.ToString()].ToString().Trim();
                                            for (int T = PR.Length; T < 3; T++) { PR = "0" + PR; }
                                            string PRS = dtrec.Rows[r]["SPR" + i.ToString()].ToString().Trim();
                                            for (int T = PRS.Length; T < 3; T++) { PRS = "0" + PRS; }

                                            int PM = 0; if (PR != "ABS" && PR != "") { PM = Convert.ToInt32(PR); }
                                            int SM = 0; if (PRS != "ABS" && PRS != "") { SM = Convert.ToInt32(PRS); }

                                            string TOTPR = (PM + SM).ToString();
                                            for (int T = TOTPR.Length; T < 3; T++) { TOTPR = "0" + TOTPR; }

                                            string B = dtrec.Rows[r]["BP" + i.ToString()].ToString().Trim();
                                            if (B != "B") { Sublist.Remove(PBACK + "P"); }
                                            if (B != "") { TOTPR = TOTPR + "(" + B + ")"; }

                                            string SESSMAX = dtsub.Rows[0]["TSMAX"].ToString().Trim();
                                            STR = STR + ("<tr>");
                                            STR = STR + ("<td valign=\"top\" align=\"left\">" + SNAME + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + PRMAX + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + PRMIN + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + PR + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + SESSMAX + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + PRS + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\">" + TOTPR + "</td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");
                                            STR = STR + ("<td valign=\"top\" align=\"center\"></td>");

                                            STR = STR + ("</tr>");
                                        }
                                    }
                                }//END BACK PRACTICAL
                            }
                        }
                        if (RLFLG != "UFM") { for (int T = GTOT.Length; T < 4; T++) { GTOT = "0" + GTOT; } }
                        else { GTOT = ""; }
                        STR = STR + ("<tr>");
                        STR = STR + ("<th style='font-size: 18px' valign=\"top\" align=\"left\">Total : " + GTOT + "</th>");
                        STR = STR + ("</tr>");
                        STR = STR + ("<tr>");
                        STR = STR + ("<th style='font-size: 18px' valign=\"top\" align=\"left\">Result : " + RES + "</th>");
                        STR = STR + ("</tr>");
                    }
                }
            }//PHARMACY(16)
            #endregion

            #region Old Course

            if (BR != "16")
            {
                if (STUTYPE == "O")
                {
                    DataTable dtgtot = new DataTable();
                    _sqlQuery = "select * from GTOTAL where ROLL='" + ROLL + "'";
                    AllQueryParam[0] = _sqlQuery;
                    objbllLogin.QUERYBLL(ref dtgtot, AllQueryParam);
                    if (dtgtot.Rows.Count > 0)
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            string MRK = dtgtot.Rows[0]["C6" + i.ToString()].ToString().Trim();
                            string MRKNAME = dtgtot.Rows[0]["CNAME6" + i.ToString()].ToString().Trim();
                            if (MRK != "")
                            {
                                STR = STR + ("<tr>");
                                STR = STR + ("<td valign=\"top\" align=\"left\">" + MRKNAME + "&nbsp;:&nbsp;<b>" + MRK + "</b></td>");
                                STR = STR + ("</tr>");
                            }
                        }
                        STR = STR + ("<tr>");
                        STR = STR + ("<td valign=\"top\" align=\"left\">Grand Total &nbsp;:&nbsp;<b>" + dtgtot.Rows[0]["GTOTAL"].ToString().Trim() + "/" + dtgtot.Rows[0]["MAX"].ToString().Trim() + "</b></td>");
                        STR = STR + ("</tr>");
                    }
                }
            }
            #endregion

            #region Add backp Paper
            if (BR != "16" && STUTYPE !="N")
            {
                if (SMMM == "01" || SMMM == "03" || SMMM == "05")
                {
                    int SS1 = Convert.ToInt32(SMMM) - 1;
                    if (Sublist.Count > 6)
                    {
                        for (int i = 0; i < dtalsub.Rows.Count; i++)
                        {
                            string SSEM = dtalsub.Rows[i]["SEM"].ToString().Trim();
                            int SS2 = Convert.ToInt32(SSEM);
                            string SUBTYPE = dtalsub.Rows[i]["TYPE"].ToString().Trim();
                            string SUBC = dtalsub.Rows[i]["SUBCODE"].ToString().Trim();
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
                else if ((SMMM == "02" || SMMM == "04" || SMMM == "06") && TYPE == "PRIVATE")
                {
                    //if (PFlag != "Y")
                    //{
                    int SS1 = Convert.ToInt32(SMMM) - 1;
                    if (Sublist.Count > 6)
                    {
                        if (PrivateBack !="P")
                        {
                        for (int i = 0; i < dtalsub.Rows.Count; i++)
                        {
                            string SSEM = dtalsub.Rows[i]["SEM"].ToString().Trim();
                            int SS2 = Convert.ToInt32(SSEM);
                            string SUBTYPE = dtalsub.Rows[i]["TYPE"].ToString().Trim();
                            string SUBC = dtalsub.Rows[i]["SUBCODE"].ToString().Trim();
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


                    //}

                }
                else
                {

                }

                Sublist.Sort();
            }
            else if(BR=="16")
            {

                //******Change on 29-04-2023********///

                int SS1 = Convert.ToInt32(SMMM);

                //int SS1 = Convert.ToInt32(SMMM) - 1;

                //**************************************////


                if (Sublist.Count > 2)
                {
                    for (int i = 0; i < dtalsub.Rows.Count; i++)
                    {

                        string SSEM = dtalsub.Rows[i]["SEM"].ToString().Trim();
                        int SS2 = Convert.ToInt32(SSEM);
                        string SUBTYPE = dtalsub.Rows[i]["TYPE"].ToString().Trim();
                        string SUBC = dtalsub.Rows[i]["SUBCODE"].ToString().Trim();

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
                    Sublist.Sort();
                }
            }
            else
            { }

            #endregion Add backp Paper
            //

            #region Remaining Back

            string BACK = string.Empty;
            for (int s = 0; s < Sublist.Count; s++)
            {
                if (s == 0) { BACK = Sublist[s].ToString(); }
                else { BACK = BACK + ", " + Sublist[s].ToString(); }
            }
            STR = STR + ("<tr>");

            //if (ROLL == "19113310212")
            //{
            //    Sublist.Clear();
            //}
            
            if (Sublist.Count > 0) { STR = STR + ("<td colspan='17' style='background-color: #FF0000; color: #FFFFFF; font-size: 15px' valign=\"top\" align=\"left\"><b>Remaining Back = " + Sublist.Count.ToString() + "</b>&nbsp;|&nbsp; " + BACK + "</td>"); }
            else { STR = STR + ("<td colspan='17' style='background-color: #4169E1; color: #FFFFFF; font-size: 15px' valign=\"top\" align=\"left\"><b>Remaining Back = " + Sublist.Count.ToString() + "</b>&nbsp;|&nbsp;No Back</td>"); }
            STR = STR + ("</tr>");
            //Promotion Tag
            if (GRP == "A")
            {
                for (int s = 0; s < Sublist.Count; s++)
                {
                    string SSB = Sublist[s].ToString();
                    if (SSB.Contains("100") == true)
                    {
                        Sublist.Remove(SSB);
                    }
                }
            }

            #endregion

           



            if (SMMM != "06")
            {
                int PRM = 0;
                if (BR == "16")
                {
                    if (SMMM == "01") { PRM = 1; }
                }
                else if (BR == "15" && SMMM == "04") { PRM = 2; }
                else if (BR == "16" && SMMM == "02") { PRM = 2; }
                else if (BR == "17" && SMMM == "04") { PRM = 2; }
                else if (BR == "07" && SMMM == "03") { PRM = 2; }
                else
                {
                    PRM = 1;
                }
                if (PRM == 1)
                {
                    //****Commented on 18-03-2023
                    if (SMMM == "01" || SMMM == "03" || SMMM == "05")
                    {

                        STR = STR + ("<tr><td colspan='17' style='background-color: #2E8B57; color: #FFFFFF; font-size: 15px' valign=\"top\" align=\"left\"><b>Promotion - YES</b></td></tr>");
                    }
                    else
                    {

                      
                        if (Sublist.Count > 2 && BR == "16") { STR = STR + ("<tr><td colspan='17' style='background-color: #C0C0C0; color: #A52A2A; font-size: 15px' valign=\"top\" align=\"left\"><b>Promotion - NO ( Year Back )</b></td></tr>"); }
                        else { STR = STR + ("<tr><td colspan='17' style='background-color: #2E8B57; color: #FFFFFF; font-size: 15px' valign=\"top\" align=\"left\"><b>Promotion - YES</b></td></tr>"); }

                        //if (Sublist.Count > 6 && BR != "16") { STR = STR + ("<tr><td colspan='17' style='background-color: #C0C0C0; color: #A52A2A; font-size: 15px' valign=\"top\" align=\"left\"><b>Promotion - NO ( Year Back )</b></td></tr>"); }
                        //else if (Sublist.Count > 2 && BR == "16") { STR = STR + ("<tr><td colspan='17' style='background-color: #C0C0C0; color: #A52A2A; font-size: 15px' valign=\"top\" align=\"left\"><b>Promotion - NO ( Year Back )</b></td></tr>"); }
                        //else { STR = STR + ("<tr><td colspan='17' style='background-color: #2E8B57; color: #FFFFFF; font-size: 15px' valign=\"top\" align=\"left\"><b>Promotion - YES</b></td></tr>"); }

                    }
                   
                }
            }
            STR = STR + ("</table>");
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }

        
    }
    private void GETCCGPA()
    {
        //Current SGPA
        string[] AllQueryParam = new string[1];
        BLL objbllLogin = new BLL();

        string STRSGPAV = string.Empty;
        DataTable dtsgpa = new DataTable();
        string _sqlQuery = "SELECT * FROM RESULT WHERE ROLL='" + ROLL + "' ORDER BY SEM";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtsgpa, AllQueryParam);
        if (dtsgpa.Rows.Count > 0)
        {
            STRSGPAH = STRSGPAH + ("<table style='font-size: 13px; font-family:Cambria; border-collapse:collapse; border-color:#0000CD' border='1' cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" runat=\"server\">");
            STRSGPAH = STRSGPAH + ("<tr>");
            string STRSGPAH1 = ("<tr>");
            STRSGPAV = STRSGPAV + ("<tr>");
            for (int i = 0; i < dtsgpa.Rows.Count; i++)
            {
                string SEM = dtsgpa.Rows[i]["SEM"].ToString().Trim();
                STRSGPAH = STRSGPAH + ("<td style='background-color:#4682B4; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">CURRENT SEM " + SEM + "</td>");
                STRSGPAH1 = STRSGPAH1 + ("<td style='background-color:#4682B4; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">SGPA</td>");
                STRSGPAV = STRSGPAV + ("<td style='font-weight:bold;' valign=\"top\" align=\"center\">" + dtsgpa.Rows[i]["SGPA"].ToString().Trim() + "</td>");
                if (SEM == "02")
                {
                    STRSGPAH = STRSGPAH + ("<td colspan='2' style='background-color:#808080; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">I YEAR</td>");
                    STRSGPAH1 = STRSGPAH1 + ("<td style='background-color:#808080; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">CGPA</td>");
                    STRSGPAH1 = STRSGPAH1 + ("<td style='background-color:#808080; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">PER</td>");
                    string SSG = dtsgpa.Rows[i]["CGPA"].ToString().Trim();
                    if (SSG == "") { SSG = "0"; }
                    CGPA2 = SSG;
                    double PER1 = (Convert.ToDouble(SSG) * 9.5);
                    PER1 = Math.Round(PER1, 2);
                    STRSGPAV = STRSGPAV + ("<td style='font-weight:bold;' valign=\"top\" align=\"center\">" + dtsgpa.Rows[i]["CGPA"].ToString().Trim() + "</td>");
                    STRSGPAV = STRSGPAV + ("<td style='font-weight:bold;' valign=\"top\" align=\"center\">" + PER1.ToString() + " %</td>");
                }
                if (SEM == "04")
                {
                    STRSGPAH = STRSGPAH + ("<td colspan='2' style='background-color:#808080; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">II YEAR</td>");
                    STRSGPAH1 = STRSGPAH1 + ("<td style='background-color:#808080; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">CGPA</td>");
                    STRSGPAH1 = STRSGPAH1 + ("<td style='background-color:#808080; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">PER</td>");
                    string SSG = dtsgpa.Rows[i]["CGPA"].ToString().Trim();
                    if (SSG == "") { SSG = "0"; }
                    CGPA4 = SSG;

                    double PER1 = (Convert.ToDouble(SSG) * 9.5);
                    PER1 = Math.Round(PER1, 2);
                    STRSGPAV = STRSGPAV + ("<td style='font-weight:bold;' valign=\"top\" align=\"center\">" + dtsgpa.Rows[i]["CGPA"].ToString().Trim() + "</td>");
                    STRSGPAV = STRSGPAV + ("<td style='font-weight:bold;' valign=\"top\" align=\"center\">" + PER1.ToString() + " %</td>");
                }
                if (SEM == "06")
                {
                    STRSGPAH = STRSGPAH + ("<td colspan='2' style='background-color:#808080; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">III YEAR</td>");
                    STRSGPAH1 = STRSGPAH1 + ("<td style='background-color:#808080; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">CGPA</td>");
                    STRSGPAH1 = STRSGPAH1 + ("<td style='background-color:#808080; color: #FFFFFF; font-size: 14px' valign=\"top\" align=\"center\">PER</td>");
                    string SSG = dtsgpa.Rows[i]["CGPA"].ToString().Trim();
                    if (SSG == "") { SSG = "0"; }
                    CGPA6 = SSG;
                    //double PER1 = (Convert.ToDouble(SSG) * 9.5);
                    //PER1 = Math.Round(PER1, 2);
                   // STRSGPAV = STRSGPAV + ("<td style='font-weight:bold;' valign=\"top\" align=\"center\">" + dtsgpa.Rows[i]["CGPA"].ToString().Trim() + "</td>");
                    STRSGPAV = STRSGPAV + ("<td style='font-weight:bold;' valign=\"top\" align=\"center\">" + dtsgpa.Rows[i]["FCGPA"].ToString().Trim() + "</td>");
                   // STRSGPAV = STRSGPAV + ("<td style='font-weight:bold;' valign=\"top\" align=\"center\">" + PER1.ToString() + " %</td>");
                    STRSGPAV = STRSGPAV + ("<td style='font-weight:bold;' valign=\"top\" align=\"center\">" + dtsgpa.Rows[i]["AVP"].ToString().Trim() + " %</td>");
                }
            }
            STRSGPAH = STRSGPAH + ("</tr>");
            STRSGPAH1 = STRSGPAH1 + ("</tr>");
            STRSGPAV = STRSGPAV + ("</tr>");
            STRSGPAH = STRSGPAH + STRSGPAH1;
            STRSGPAH = STRSGPAH + STRSGPAV;
            STRSGPAH = STRSGPAH + ("</table>");
        }
    }


   
}