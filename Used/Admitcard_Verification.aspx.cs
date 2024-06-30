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
public partial class Admitcard_Verification : System.Web.UI.Page
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

            DataTable dt = new DataTable();
            _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID='" + CANDIDATEID + "'";
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dt, AllQueryParam);
            if (dt.Rows.Count == 0) { Response.Redirect("~/Error.aspx", false); }

            ROLL = dt.Rows[0]["ROLL"].ToString().Trim();
            REG = dt.Rows[0]["CANDIDATEID"].ToString().Trim();
            NAME = dt.Rows[0]["CNAME"].ToString().Trim();
            SEM = dt.Rows[0]["SEM"].ToString().Trim(); ;
            string STRTSESS = dt.Rows[0]["STRTSESS"].ToString().Trim(); ;
            FNAME = dt.Rows[0]["FNAME"].ToString().Trim();
            REGPVT = dt.Rows[0]["REGPVT"].ToString().Trim(); 
            if (REGPVT == "P") { REGPVT = "PRIVATE"; } 
            else if(REGPVT=="Q") { REGPVT = "SPECIAL/QUALIFIED"; }
            else { REGPVT = "REGULER"; }
            BRANCH = dt.Rows[0]["BRNAME"].ToString().Trim();
            DOB = dt.Rows[0]["DOB"].ToString().Trim();
            CENTRE = dt.Rows[0]["INSNAME"].ToString().Trim();
            Imgphver.ImageUrl = "http://ubterex.in/Upload/Photo/" + REG + "P.jpg";
            Imgsignver.ImageUrl = "http://ubterex.in/Upload/Sign/" + REG + "S.jpg";
            Imgphadm.ImageUrl = "http://ubterex.in/Upload/Photo/" + REG + "P.jpg";
            string STUTYPE = dt.Rows[0]["STUTYPE"].ToString().Trim();


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
            if (REGPVT == "REGULER")
            {
                string[] BRSPL = BRANCH.Split('-');
                string BRCODE = BRSPL[0].ToString();
                DataTable dtsub = new DataTable();
                if (STUTYPE == "N") { _sqlQuery = "select * from SUBJ where BRCODE='" + BRCODE + "' AND SEM='" + SEM + "' and (TYPE='T' OR TYPE='TP') ORDER BY SUBCODE ASC"; }
                else { _sqlQuery = "select * from SUBN where BRCODE='" + BRCODE + "' AND SEM='" + SEM + "' and (TYPE='T' OR TYPE='TP') ORDER BY SUBCODE ASC"; }
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
            else if (REGPVT == "QUALIFIED" || REGPVT == "PRIVATE")
            {
                DataTable dtsbp = new DataTable();
                _sqlQuery = "SELECT * FROM BACKP WHERE CANDIDATEID='" + CANDIDATEID + "' AND ISCOMPLETED='1' AND TYPE='S'";
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dtsbp, AllQueryParam);
                if (dtsbp.Rows.Count > 0)
                {
                    string[] SUBBACK = dtsbp.Rows[0]["SUBA"].ToString().Split('|');
                    for (int i = 0; i < SUBBACK.Length; i++)
                    {
                        string SUB = SUBBACK[i].ToString().Substring(0, 4).ToString();
                        string TP = SUBBACK[i].ToString().Substring(4, 1).ToString();
                        if (TP == "T")
                        {
                            DataTable dtsub = new DataTable();
                            _sqlQuery = "select * from SUBJ where SUBCODE='" + SUB + "'";
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
            DataTable dtback = new DataTable();
            _sqlQuery = "SELECT * FROM BACKP WHERE CANDIDATEID='" + CANDIDATEID + "' AND ISCOMPLETED='1'";
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dtback, AllQueryParam);
            if (dtback.Rows.Count > 0)
            {
                string[] SUBBACK = dtback.Rows[0]["SUBA"].ToString().Split('|');
                for (int i = 0; i < SUBBACK.Length; i++)
                {
                    string SUB = SUBBACK[i].ToString().Substring(0, 4).ToString();
                    string TP = SUBBACK[i].ToString().Substring(4, 1).ToString();
                    if (TP == "T")
                    {
                        DataTable dtsub = new DataTable();
                        _sqlQuery = "select * from SUBJ where SUBCODE='" + SUB + "'";
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
                    if (ITIPASS == "Y") { _sqlQuery = "select * from SUBJ where BRCODE='" + BRCODE + "' AND SEM='01' and (TYPE='T' OR TYPE='TP') AND SUBCODE!='1005' AND SUBCODE!='1006' ORDER BY SUBCODE ASC"; }
                    else { _sqlQuery = "select * from SUBJ where BRCODE='" + BRCODE + "' AND SEM='01' and (TYPE='T' OR TYPE='TP') ORDER BY SUBCODE ASC"; }
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
            SUBJECTS = SUBJECTS + "</table>";
        }
        catch (Exception ex) { }
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
}