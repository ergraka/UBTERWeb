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
public partial class Verification : System.Web.UI.Page
{
    public string ROLL = string.Empty;
    public string REG = string.Empty;
    public string NAME = string.Empty;
    public string SEM = string.Empty;
    public string FNAME = string.Empty;
    public string REGPVT = string.Empty;
    public string BRANCH = string.Empty;
    public string DOB = string.Empty;
    public string CENTRE = string.Empty;
    public string SUBJECTS = string.Empty;
    public string HEAD = string.Empty;

    string[] AllQueryParam = new string[1];
    string _sqlQuery = string.Empty;
    BLL objbll = new BLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["BRCODE"] == null) { Response.Redirect("~/Institute/Inslogin.aspx", false); }
            if (Request.QueryString["AAAAA"] == null) { Response.Redirect("~/Error.aspx", false); }
            string CANDIDATEID = Request.QueryString["AAAAA"].ToString();

            string[] spl1 = Session["INSCODE"].ToString().Split('|');
            string inscode = spl1[0].ToString();
            string[] spl2 = Session["BRCODE"].ToString().Split('|');
            string brcode = spl2[0].ToString();
            //HEAD = "VERIFICATION WINTER EXAMINATION- " + Getsession();
            HEAD = "VERIFICATION SUMMER EXAMINATION-2024";

            DataTable dt = new DataTable();
            _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID='" + CANDIDATEID + "' AND BRCODE='" + brcode + "' AND INSCODE='" + inscode + "'";
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dt, AllQueryParam);
            if (dt.Rows.Count == 0) { Response.Redirect("~/Error.aspx", false); }

            ROLL = dt.Rows[0]["ROLL"].ToString().Trim();
            REG = dt.Rows[0]["CANDIDATEID"].ToString().Trim();
            NAME = dt.Rows[0]["CNAME"].ToString().Trim();
            SEM = dt.Rows[0]["SEM"].ToString().Trim(); ;
            string STRTSESS = dt.Rows[0]["STRTSESS"].ToString().Trim();
            FNAME = dt.Rows[0]["FNAME"].ToString().Trim();
            REGPVT = dt.Rows[0]["REGPVT"].ToString().Trim();
            if (REGPVT == "P") { REGPVT = "PRIVATE"; }
            else if (REGPVT == "Q") { REGPVT = "SPECIAL"; }
            else { REGPVT = "REGULER"; }
            string STUTYPE = dt.Rows[0]["STUTYPE"].ToString().Trim();
            BRANCH = dt.Rows[0]["BRNAME"].ToString().Trim();
            DOB = dt.Rows[0]["DOB"].ToString().Trim();
            CENTRE = dt.Rows[0]["CENTER"].ToString().Trim();
            string isPhoto = dt.Rows[0]["ISPH"].ToString().Trim();

            if (isPhoto == "False" || isPhoto == null || isPhoto == "")
            {
                //Response.Write("Unable to open verifcation due to unavaibility of photo.");
                Response.Redirect("~/Error.aspx");

            }
            else
            {




                //if((inscode).Trim()=="079" || (inscode).Trim()=="140")
                //{
                //    CENTRE = "019-K.L. POLYTECHNIC ROORKEE";
                //}

                //if ((inscode).Trim() == "113" )
                //{
                //    CENTRE = "006-G.P DEHRADUN";
                //}

                //if ((inscode).Trim() == "133" )
                //{
                //    CENTRE = "049-G.P PANTNAGAR";
                // }

                //SBP CENTRE
                //DataTable dtcent = new DataTable();
                //_sqlQuery = "select * from SBPCENTRE where INSCODE='" + inscode + "'";
                //AllQueryParam[0] = _sqlQuery;
                //objbll.QUERYBLL(ref dtcent, AllQueryParam);
                //if (dtcent.Rows.Count > 0) { CENTRE = dtcent.Rows[0]["CENTNAME"].ToString().Trim(); }



                Imgphver.ImageUrl = "http://ubterex.in/Upload/Photo/" + REG + "P.jpg";
                Imgsignver.ImageUrl = "http://ubterex.in/Upload/Sign/" + REG + "S.jpg";
                SUBJECTS = "<table cellpadding='0' cellspacing='0' style='width:1024px;'>";
                SUBJECTS = SUBJECTS + ("<tr>");
                SUBJECTS = SUBJECTS + ("<th style='border-top: 1px solid #000000;border-bottom: 1px solid #000000;border-right: 1px solid #000000;' valign=\"middle\" align=\"center\">SR NO</th>");
                SUBJECTS = SUBJECTS + ("<th style='border-bottom: 1px solid #000000; border-top: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\">&nbsp;SUBJECT NAME</th>");
                SUBJECTS = SUBJECTS + ("<th style='border-bottom: 1px solid #000000; border-top: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">SUBJECT CODE</th>");
                SUBJECTS = SUBJECTS + ("<th style='border-bottom: 1px solid #000000; border-top: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">DATE OF EXAM</th>");
                SUBJECTS = SUBJECTS + ("<th style='border-bottom: 1px solid #000000; border-top: 1px solid #000000;' valign=\"middle\" align=\"center\">STUDENT SIGNATURE</th>");
                SUBJECTS = SUBJECTS + ("<th style='border-top: 1px solid #000000;border-bottom: 1px solid #000000;border-left: 1px solid #000000;' valign=\"middle\" align=\"center\">INVIGILATOR SIGNATURE</th>");
                SUBJECTS = SUBJECTS + ("</tr>");
                int n = 1;

                DataTable dtsbp = new DataTable();
                string BackPFlag = "N";
                _sqlQuery = "SELECT * FROM BACKP WHERE CANDIDATEID='" + CANDIDATEID + "' AND TYPE='S'  AND ISCOMPLETED='1'";
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dtsbp, AllQueryParam);
                if (dtsbp.Rows.Count > 0)
                {
                    BackPFlag = "Y";
                }

                if (REGPVT == "REGULER" && BackPFlag == "N")
                {
                    string[] BRSPL = BRANCH.Split('-');
                    string BRCODE = BRSPL[0].ToString();
                    DataTable dtsub = new DataTable();
                    if (STUTYPE == "N") { _sqlQuery = "select * from SUBN where BRCODE='" + BRCODE + "' AND SEM='" + SEM + "' and (TYPE='T' OR TYPE='TP') ORDER BY SUBCODE ASC"; }
                    else { _sqlQuery = "select * from SUBJ where BRCODE='" + BRCODE + "' AND SEM='" + SEM + "' and (TYPE='T' OR TYPE='TP') ORDER BY SUBCODE ASC"; }
                    AllQueryParam[0] = _sqlQuery;
                    objbll.QUERYBLL(ref dtsub, AllQueryParam);
                    if (dtsub.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtsub.Rows.Count; i++)
                        {
                            string SR = string.Empty;
                            if (n < 10) { SR = "0" + n.ToString(); }
                            else { SR = n.ToString(); }
                            string SUBJNAME = dtsub.Rows[i]["SUBJECT"].ToString().Trim();
                            string SUBJCODE = dtsub.Rows[i]["SUBCODE"].ToString().Trim();
                            SUBJECTS = SUBJECTS + ("<tr>");
                            SUBJECTS = SUBJECTS + ("<td style='height:30px; border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + SR + "</td>");
                            SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\">&nbsp;" + SUBJNAME + "</td>");
                            SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + SUBJCODE + "</td>");
                            SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                            SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000;' valign=\"middle\" align=\"left\"></td>");
                            SUBJECTS = SUBJECTS + ("<td style='border-left: 1px solid #000000;  border-bottom: 1px solid #000000;' valign=\"middle\" align=\"left\"></td>");
                            SUBJECTS = SUBJECTS + ("</tr>");
                            n++;
                        }
                    }
                }
                else
                {
                    //DataTable dtsbp = new DataTable();
                    if (BackPFlag == "N")
                    {
                        _sqlQuery = "SELECT * FROM BACKP WHERE CANDIDATEID='" + CANDIDATEID + "' AND TYPE='B'  AND ISCOMPLETED='1'";
                        AllQueryParam[0] = _sqlQuery;
                        objbll.QUERYBLL(ref dtsbp, AllQueryParam);
                    }
                    if (dtsbp.Rows.Count > 0)
                    {
                        string[] SUBBACK = dtsbp.Rows[0]["SUBA"].ToString().Split('|');
                        for (int i = 0; i < SUBBACK.Length; i++)
                        {
                            string SS = SUBBACK[i].ToString();
                            string SUB = string.Empty;
                            string TP = string.Empty;
                            if (SS.Length == 5)
                            {
                                SUB = SUBBACK[i].ToString().Substring(0, 4).ToString();
                                TP = SUBBACK[i].ToString().Substring(4, 1).ToString();
                            }
                            else
                            {
                                SUB = SUBBACK[i].ToString().Substring(0, 6).ToString();
                                TP = SUBBACK[i].ToString().Substring(6, 1).ToString();
                            }
                            if (TP == "T")
                            {
                                DataTable dtsub = new DataTable();
                                if (STUTYPE == "N") { _sqlQuery = "select TOP(1) * from SUBN where SUBCODE='" + SUB + "'"; }
                                else { _sqlQuery = "select TOP(1) * from SUBJ where SUBCODE='" + SUB + "'"; }
                                AllQueryParam[0] = _sqlQuery;
                                objbll.QUERYBLL(ref dtsub, AllQueryParam);
                                if (dtsub.Rows.Count > 0)
                                {
                                    string SR = string.Empty;
                                    if (n < 10) { SR = "0" + n.ToString(); }
                                    else { SR = n.ToString(); }

                                    string SUBJNAME = dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                    string SUBJCODE = "*" + dtsub.Rows[0]["SUBCODE"].ToString().Trim();
                                    SUBJECTS = SUBJECTS + ("<tr>");
                                    SUBJECTS = SUBJECTS + ("<td style='height:30px; border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + SR + "</td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\">&nbsp;" + SUBJNAME + "</td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + SUBJCODE + "</td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000;' valign=\"middle\" align=\"left\"></td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-left: 1px solid #000000;  border-bottom: 1px solid #000000;' valign=\"middle\" align=\"left\"></td>");
                                    SUBJECTS = SUBJECTS + ("</tr>");
                                    n++;
                                }

                            }
                        }
                    }
                }
                if (REGPVT == "REGULER")
                {
                    DataTable dtback = new DataTable();
                    _sqlQuery = "SELECT * FROM BACKP WHERE CANDIDATEID='" + CANDIDATEID + "' AND TYPE='B'  AND ISCOMPLETED='1'";
                    AllQueryParam[0] = _sqlQuery;
                    objbll.QUERYBLL(ref dtback, AllQueryParam);
                    if (dtback.Rows.Count > 0)
                    {
                        string[] SUBBACK = dtback.Rows[0]["SUBA"].ToString().Split('|');
                        for (int i = 0; i < SUBBACK.Length; i++)
                        {
                            string SS = SUBBACK[i].ToString();
                            string SUB = string.Empty;
                            string TP = string.Empty;
                            if (SS.Length == 5)
                            {
                                SUB = SUBBACK[i].ToString().Substring(0, 4).ToString();
                                TP = SUBBACK[i].ToString().Substring(4, 1).ToString();
                            }
                            else
                            {
                                SUB = SUBBACK[i].ToString().Substring(0, 6).ToString();
                                TP = SUBBACK[i].ToString().Substring(6, 1).ToString();
                            }
                            if (TP == "T")
                            {
                                DataTable dtsub = new DataTable();
                                if (STUTYPE == "N") { _sqlQuery = "select * from SUBN where SUBCODE='" + SUB + "'"; }
                                else { _sqlQuery = "select * from SUBJ where SUBCODE='" + SUB + "'"; }
                                AllQueryParam[0] = _sqlQuery;
                                objbll.QUERYBLL(ref dtsub, AllQueryParam);
                                if (dtsub.Rows.Count > 0)
                                {
                                    string SR = string.Empty;
                                    if (n < 10) { SR = "0" + n.ToString(); }
                                    else { SR = n.ToString(); }
                                    string SUBJNAME = dtsub.Rows[0]["SUBJECT"].ToString().Trim();
                                    string SUBJCODE = "*" + dtsub.Rows[0]["SUBCODE"].ToString().Trim();
                                    SUBJECTS = SUBJECTS + ("<tr>");
                                    SUBJECTS = SUBJECTS + ("<td style='height:30px; border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + SR + "</td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\">&nbsp;" + SUBJNAME + "</td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + SUBJCODE + "</td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000;' valign=\"middle\" align=\"left\"></td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-left: 1px solid #000000;  border-bottom: 1px solid #000000;' valign=\"middle\" align=\"left\"></td>");
                                    SUBJECTS = SUBJECTS + ("</tr>");
                                    n++;
                                }
                            }
                        }
                    }
                    else
                    {
                        string GRP = dt.Rows[0]["GRP"].ToString().Trim();
                        if (GRP == "A" && SEM == "03")
                        {
                            string[] BRSPL = BRANCH.Split('-');
                            string BRCODE = BRSPL[0].ToString();
                            DataTable dtsub = new DataTable();
                            string ITIPASS = dt.Rows[0]["ITIPASS"].ToString().Trim();
                            if (STUTYPE == "N")
                            {
                                if (ITIPASS == "Y") { _sqlQuery = "select * from SUBN where BRCODE='" + BRCODE + "' AND SEM='01' and (TYPE='T' OR TYPE='TP') AND SUBCODE!='991006' ORDER BY SUBCODE ASC"; }
                                else { _sqlQuery = "select * from SUBN where BRCODE='" + BRCODE + "' AND SEM='01' and (TYPE='T' OR TYPE='TP') ORDER BY SUBCODE ASC"; }
                            }
                            else
                            {
                                if (ITIPASS == "Y") { _sqlQuery = "select * from SUBJ where BRCODE='" + BRCODE + "' AND SEM='01' and (TYPE='T' OR TYPE='TP') AND SUBCODE!='1005' AND SUBCODE!='1006' ORDER BY SUBCODE ASC"; }
                                else { _sqlQuery = "select * from SUBJ where BRCODE='" + BRCODE + "' AND SEM='01' and (TYPE='T' OR TYPE='TP') ORDER BY SUBCODE ASC"; }
                            }
                            AllQueryParam[0] = _sqlQuery;
                            objbll.QUERYBLL(ref dtsub, AllQueryParam);
                            if (dtsub.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtsub.Rows.Count; i++)
                                {
                                    string SR = string.Empty;
                                    if (n < 10) { SR = "0" + n.ToString(); }
                                    else { SR = n.ToString(); }

                                    string SUBJNAME = dtsub.Rows[i]["SUBJECT"].ToString().Trim();
                                    string SUBJCODE = dtsub.Rows[i]["SUBCODE"].ToString().Trim();
                                    SUBJECTS = SUBJECTS + ("<tr>");
                                    SUBJECTS = SUBJECTS + ("<td style='height:30px; border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + SR + "</td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\">&nbsp;" + SUBJNAME + "</td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + SUBJCODE + "*</td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000;' valign=\"middle\" align=\"left\"></td>");
                                    SUBJECTS = SUBJECTS + ("<td style='border-left: 1px solid #000000;  border-bottom: 1px solid #000000;' valign=\"middle\" align=\"left\"></td>");
                                    SUBJECTS = SUBJECTS + ("</tr>");
                                    n++;
                                }
                            }
                        }
                    }
                }
                SUBJECTS = SUBJECTS + "</table>";
            }
        }
        catch (Exception ex) { Response.Write(ex.Message); }
    }
    protected void Imglogout_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["BRCODE"] = null;
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("~/Default.aspx", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
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
            string S1 = SESS.Substring(0, 2);
            string S2 = SESS.Substring(2, 5);
            //if (S1 == "06") { SESS = "SUMMER" + S2; }
            if (S1 == "06") { SESS = "SPECIAL BACK PAPER EXAMINATION" + S2; }
            else if (S1 == "12")
            {
                string S3 = S2.Substring(3, 2);
                int PP = Convert.ToInt32(S3) + 1;
                //SESS = "WINTER" + S2 + " : " + PP.ToString();
                SESS = "SPECIAL BACK PAPER EXAMINATION" + S2 + " : " + PP.ToString();
            }
        }
        return SESS;
    }
}