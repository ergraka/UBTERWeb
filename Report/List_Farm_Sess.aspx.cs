using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using _Examination;
public partial class List_Farm_Sess : System.Web.UI.Page
{
    public string DATA = string.Empty;
    public string DATA1 = string.Empty;
    public string SUB = string.Empty;
    public string TYP = string.Empty;
    public string TH= string.Empty;
    public string PR = string.Empty;
    public string HEADSESS = string.Empty;
    string COLL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HEADSESS = Getsession();

            if (!IsPostBack)
            {
                if (Session["INSCODE"] != null && Session["BRCODE"] != null)
                {
                    string SEM = string.Empty;
                    if (Request.QueryString["TYP"] != null) { SEM = Request.QueryString["TYP"].ToString().Trim(); }
                    else { Response.Redirect("~/Error.aspx", true); }
                    string[] splins = Session["INSCODE"].ToString().Split('|');
                    Lblins.Text = splins[1].ToString();
                    string[] splbr = Session["BRCODE"].ToString().Split('|');
                    Lblbranch.Text = splbr[1].ToString();
                    string[] BRSPL = splbr[0].ToString().Split('-');
                    string brcode = splbr[0].ToString();
                    //***************************************************************************GET SUBJECT
                    string _sqlQueryreg = string.Empty;
                    DataTable dtreg = new DataTable();
                    string[] AllQueryParamreg = new string[1];

                    if (brcode.Substring(0, 2) == "07") { _sqlQueryreg = "SELECT * FROM SUBJ WHERE SEM='" + SEM + "' and BRCODE='" + BRSPL[0].ToString() + "' ORDER BY SUBCODE ASC"; }
                    else { _sqlQueryreg = "SELECT * FROM SUBN WHERE SEM='" + SEM + "' and BRCODE='" + BRSPL[0].ToString() + "' ORDER BY SUBCODE ASC"; }


                    AllQueryParamreg[0] = _sqlQueryreg;
                    BLL objbllreg = new BLL();
                    objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                    if (dtreg.Rows.Count > 0)
                    {
                        DATA1 = DATA1 + ("<tr>");
                        DATA1 = DATA1 + ("<th rowspan='2' style='border-bottom: 1px solid #000000; border-right: 1px solid #000000; font-size: 15px' valign=\"top\" align=\"left\">ROLL NO.<br />NAME/FNAME/D-O-B</th>");
                        for (int i = 0; i < dtreg.Rows.Count; i++)
                        {
                            SUB = dtreg.Rows[i]["SUBCODE"].ToString().Trim() + '-' + dtreg.Rows[i]["SUBJECT"].ToString().Trim();
                            DATA1 = DATA1 + ("<th colspan='2' style='border-bottom: 1px solid #000000; border-right: 1px solid #000000; font-size: 15px' valign=\"top\" align=\"center\">" + SUB + "</th>");
                        }
                        DATA1 = DATA1 + ("<th rowspan='2' style='border-bottom: 1px solid #000000; border-right: 1px solid #000000; font-size: 15px' valign=\"top\" align=\"center\">052<br />MM:30</th>");
                        DATA1 = DATA1 + ("<th rowspan='2' style='border-bottom: 1px solid #000000; font-size: 15px' valign=\"top\" align=\"center\">053<br />MM:20</th>");
                        DATA1 = DATA1 + ("</tr>");

                        DATA1 = DATA1 + ("<tr>");
                        for (int i = 0; i < dtreg.Rows.Count; i++)
                        {
                            TYP = dtreg.Rows[i]["TYPE"].ToString();
                            if (TYP == "TP")
                            {
                                COLL = COLL + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                                COLL = COLL + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                                DATA1 = DATA1 + ("<th style='border-bottom: 1px solid #000000; border-right: 1px solid #000000; font-size: 15px' valign=\"top\" align=\"center\">T</th>");
                                DATA1 = DATA1 + ("<th style='border-bottom: 1px solid #000000; border-right: 1px solid #000000; font-size: 15px' valign=\"top\" align=\"center\">P</th>");
                            }
                            else if (TYP == "T")
                            {
                                COLL = COLL + ("<td colspan='2' style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                                DATA1 = DATA1 + ("<th colspan='2' style='border-bottom: 1px solid #000000; border-right: 1px solid #000000; font-size: 15px' valign=\"top\" align=\"center\">T</th>");
                            }
                            else if (TYP == "P")
                            {
                                COLL = COLL + ("<td colspan='2' style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                                DATA1 = DATA1 + ("<th colspan='2' style='border-bottom: 1px solid #000000; border-right: 1px solid #000000; font-size: 15px' valign=\"top\" align=\"center\">P</th>");
                            }
                        }
                        DATA1 = DATA1 + ("</tr>");
                        Lblsem.Text = SEM;
                        Lblshift.Text = BRSPL[1].ToString();
                        Getdata();
                    }
                    else { LblMessage.Text = "No Subject Found."; }
                }
                else { Response.Redirect("~/Institute/Inslogin.aspx", false); }
            }
        }
        catch (Exception ex)
        {
            LblMessage.Text = "Please try after some time !";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The Login can not complete. Please try after some time !');", true);
        }


    }

    private void Getdata()
    {

        string _sqlQueryreg = string.Empty;
        string[] AllQueryParamreg = new string[1];
        BLL objbllreg = new BLL();

        //Get From session
        string FORMSESS = string.Empty;
        DataTable dtsess = new DataTable();
        _sqlQueryreg = "select * FROM FORMSESS WHERE SESSNAME='FORM'";
        AllQueryParamreg[0] = _sqlQueryreg;
        objbllreg.QUERYBLL(ref dtsess, AllQueryParamreg);
        if (dtsess.Rows.Count > 0)
        {
            FORMSESS = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
        }


        string CLM = string.Empty;
        string SEM = Lblsem.Text;
        string CLMSESS = string.Empty;

        if (SEM == "01") { CLM = "SEMCOM1"; CLMSESS = "SEMSESS1"; }
        else if (SEM == "02") { CLM = "SEMCOM2"; CLMSESS = "SEMSESS2"; }
        else if (SEM == "03") { CLM = "SEMCOM3"; CLMSESS = "SEMSESS3"; }
        else if (SEM == "04") { CLM = "SEMCOM4"; CLMSESS = "SEMSESS4"; }
        else if (SEM == "05") { CLM = "SEMCOM5"; CLMSESS = "SEMSESS5"; }
        else if (SEM == "06") { CLM = "SEMCOM6"; CLMSESS = "SEMSESS6"; }

        DATA = "";
        string[] splins = Session["INSCODE"].ToString().Split('|');
        string[] splbr = Session["BRCODE"].ToString().Split('|');
        DataTable dtreg = new DataTable();
        _sqlQueryreg = "select * FROM REGISTRATION where INSCODE='" + splins[0].ToString() + "' and BRCODE='" + splbr[0].ToString() + "' and SEM='" + Lblsem.Text + "' AND " + CLM + "='1' AND " + CLMSESS + "='" + FORMSESS + "' AND STAT='A' AND REGPVT='R' order by ROLL asc";
        AllQueryParamreg[0] = _sqlQueryreg;
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0)
        {
            for (int i = 0; i < dtreg.Rows.Count; i++)
            {

                string ROLL = dtreg.Rows[i]["ROLL"].ToString().Trim();
                string CNAME = dtreg.Rows[i]["CNAME"].ToString().Trim();
                string FNAME = dtreg.Rows[i]["FNAME"].ToString().Trim();
                string DOB = dtreg.Rows[i]["DOB"].ToString().Trim();
                DATA = DATA + ("<tr><td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\">&nbsp;<b>" + ROLL + "</b><br/>&nbsp;" + CNAME + "<br/>&nbsp;" + FNAME + "<br/>&nbsp;" + DOB + "<br/>" + "</td>");
                DATA = DATA + COLL;
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000;' valign=\"middle\" align=\"center\"></td>");
                DATA = DATA + ("<tr>");
            }
        }
        else { LblMessage.Text = "No Records Found."; }
    }
    protected void Imghome_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Session["ID"] != null) { Response.Redirect("~/Student/Stuhome.aspx?mode=home", false); }
            else { Response.Redirect("~/Institute/Inslogin.aspx", false); }
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
            Response.Redirect("~/Institute/Inslogin.aspx", false);
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
            if (S1 == "06") { SESS = "SUMMER" + S2; }
            else if (S1 == "12") 
            {
                string S3 = S2.Substring(3, 2);
                int PP = Convert.ToInt32(S3) + 1;
                SESS = "WINTER" + S2 + " : " + PP.ToString();
            }
        }
        return SESS;
    }
}
