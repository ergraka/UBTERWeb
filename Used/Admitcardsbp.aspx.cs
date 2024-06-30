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
public partial class Admitcardsbp : System.Web.UI.Page
{

    public string ROLL = string.Empty;
    public string REG = string.Empty;
    public string NAME = string.Empty;
    public string SEM = string.Empty;
    public string FNAME = string.Empty;
    public string STAT = string.Empty;
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
            if (Session["INSCODE"] != null && Session["BRCODE"] != null) { if (Request.QueryString["AAAAA"] != null) { Session["ID"] = Request.QueryString["AAAAA"].ToString(); } } else { Response.Redirect("~/Institute/Inslogin.aspx", false); }
            if (Session["ID"] != null)
            {
                

                DataTable dt = new DataTable();
                _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID='" + Session["ID"].ToString().Trim() + "'";
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dt, AllQueryParam);

                if (dt.Rows.Count > 0)
                {
                    ROLL = dt.Rows[0]["ROLL"].ToString().Trim();
                    REG = dt.Rows[0]["CANDIDATEID"].ToString().Trim();
                    NAME = dt.Rows[0]["CNAME"].ToString().Trim();
                    SEM = dt.Rows[0]["SEM"].ToString().Trim(); ;
                    FNAME = dt.Rows[0]["FNAME"].ToString().Trim();
                    STAT = "SPECIAL";
                    BRANCH = dt.Rows[0]["BRNAME"].ToString().Trim();

                    string BR = BRANCH.Substring(0, 2);
                    if (BR == "16") { TRSBP.Visible = false; }

                    DOB = dt.Rows[0]["DOB"].ToString().Trim();
                    CENTRE = "GOVERNMENT GILRS POLYTECHNIC SUDDHOWALA CHAKRATA ROAD, DEHRADUN";
                    Imgphver.ImageUrl = "http://ubterex.in/Upload/Photo/" + REG + "P.jpg";
                    string[] BRSPL = BRANCH.Split('-');
                    string BRCODE = BRSPL[0].ToString();

                    DataTable dtback = new DataTable();
                    _sqlQuery = "select * from BACKP where ROLL='" + ROLL + "' AND SEM='" + SEM + "' AND ISCOMPLETED='1' AND STAT='A' AND TYPE='S'";
                    AllQueryParam[0] = _sqlQuery;
                    objbll.QUERYBLL(ref dtback, AllQueryParam);
                    if (dtback.Rows.Count > 0)
                    {
                        string SUBA = dtback.Rows[0]["SUBA"].ToString();
                        string[] SPL = SUBA.Split('|');

                        SUBJECTS = "<table cellpadding='0' cellspacing='0' style='width:1024px;'>";
                        SUBJECTS = SUBJECTS + ("<tr><th style='height:30px; border-top: 1px solid #000000;border-bottom: 1px solid #000000;border-right: 1px solid #000000;' valign=\"middle\" align=\"center\">SR NO</th>");
                        SUBJECTS = SUBJECTS + ("<th style='height:30px; border-bottom: 1px solid #000000; border-top: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\">&nbsp;SUBJECT NAME</th>");
                        SUBJECTS = SUBJECTS + ("<th style='height:30px; border-bottom: 1px solid #000000; border-top: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">SUBJECT CODE</th>");
                        SUBJECTS = SUBJECTS + ("<th style='height:30px; border-bottom: 1px solid #000000; border-top: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">DATE OF EXAM</th>");
                        SUBJECTS = SUBJECTS + ("<th style='height:30px; border-bottom: 1px solid #000000; border-top: 1px solid #000000;' valign=\"middle\" align=\"center\">STUDENT SIGNATURE</th>");
                        SUBJECTS = SUBJECTS + ("<th style='height:30px; border-top: 1px solid #000000;border-bottom: 1px solid #000000;border-left: 1px solid #000000;' valign=\"middle\" align=\"center\">INVIGILATOR SIGNATURE</th></tr>");
                        int n = 1;
                        for (int i = 0; i < SPL.Length; i++)
                        {
                            string SR = string.Empty;
                            if (n < 10) { SR = "0" + n.ToString(); }
                            else { SR = n.ToString(); }

                            string SUBJNAME = string.Empty;
                            string SUBJCODE = SPL[i].ToString();

                            string TP = SUBJCODE.Substring(SUBJCODE.Length - 1, 1).ToString();
                            string SB = SUBJCODE.Substring(0, SUBJCODE.Length - 1).ToString();
                            if (TP == "T")
                            {
                                DataTable dtsub = new DataTable();
                                _sqlQuery = "select * from SUBJ where SUBCODE='" + SB + "'";
                                AllQueryParam[0] = _sqlQuery;
                                objbll.QUERYBLL(ref dtsub, AllQueryParam);
                                if (dtsub.Rows.Count > 0) { SUBJNAME = dtsub.Rows[0]["SUBJECT"].ToString().Trim(); }
                                SUBJECTS = SUBJECTS + ("<tr><td style='height:50px; border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + SR + "</td>");
                                SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\">&nbsp;" + SUBJNAME + "</td>");
                                SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + SB + "</td>");
                                SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                                SUBJECTS = SUBJECTS + ("<td style='border-bottom: 1px solid #000000;' valign=\"middle\" align=\"left\"></td>");
                                SUBJECTS = SUBJECTS + ("<td style='border-left: 1px solid #000000;  border-bottom: 1px solid #000000;' valign=\"middle\" align=\"left\"></td></tr>");
                                n++;
                            }
                        }
                        SUBJECTS = SUBJECTS + "</table>";
                    }
                }
                else { Response.Redirect("~/Default.aspx", false); }
            }
            else { Response.Redirect("~/Default.aspx", false); }
        }
        catch (Exception ex) { }
    }
    protected void Imglogout_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["ID"] = null;
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