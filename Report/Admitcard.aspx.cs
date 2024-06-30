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
public partial class Admitcard : System.Web.UI.Page
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

            //HEAD = "ADMIT CARD WINTER EXAMINATION- " + Getsession();
            HEAD = "ADMIT CARD SUMMER EXAMINATION-2024";

            string[] spl1 = Session["INSCODE"].ToString().Split('|');
            string inscode = spl1[0].ToString();
            string[] spl2 = Session["BRCODE"].ToString().Split('|');
            string brcode = spl2[0].ToString();

            DataTable dt = new DataTable();
            _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID='" + CANDIDATEID + "' AND BRCODE='" + brcode + "' AND INSCODE='" + inscode + "'";
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dt, AllQueryParam);
            if (dt.Rows.Count == 0) { Response.Redirect("~/Error.aspx", false); }

            ROLL = dt.Rows[0]["ROLL"].ToString().Trim();
            REG = dt.Rows[0]["CANDIDATEID"].ToString().Trim();
            NAME = dt.Rows[0]["CNAME"].ToString().Trim();
            SEM = dt.Rows[0]["SEM"].ToString().Trim();
            string STRTSESS = dt.Rows[0]["STRTSESS"].ToString().Trim();
            FNAME = dt.Rows[0]["FNAME"].ToString().Trim();
            REGPVT = dt.Rows[0]["REGPVT"].ToString().Trim();
            if (REGPVT == "P") { REGPVT = "PRIVATE"; }
            else if (REGPVT == "Q") { REGPVT = "SPECIAL"; }
            else { REGPVT = "REGULER"; }
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

                ////SBP CENTRE
                //DataTable dtcent = new DataTable();
                //_sqlQuery = "select * from SBPCENTRE where INSCODE='" + inscode + "'";
                //AllQueryParam[0] = _sqlQuery;
                //objbll.QUERYBLL(ref dtcent, AllQueryParam);
                //if (dtcent.Rows.Count > 0) { CENTRE = dtcent.Rows[0]["CENTNAME"].ToString().Trim(); }

                Imgphadm.ImageUrl = "https://ubterex.in/Upload/Photo/" + REG + "P.jpg";
            }
            
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