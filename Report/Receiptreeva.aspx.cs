using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Collections;
using _Examination;

public partial class Receiptreeva: System.Web.UI.Page
{
    public string _CANDIDATEID = string.Empty;
    public string _ROLL = string.Empty;
    public string _CANDIDATE_NAME = string.Empty;
    public string _FATHER_NAME = string.Empty;
    public string _INSTITUTE = string.Empty;
    public string _BRANCH = string.Empty;
    public string _DOB = string.Empty;
    public string _FEE = string.Empty;
    public string _SUB = string.Empty;
    public DateTime indianTime;
    public string CP = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            if (Session["INSCODE"] != null || Session["ADMIN"] != null) { if (Request.QueryString["AAAAA"] != null) { Session["ID"] = Request.QueryString["AAAAA"].ToString(); } }
            if (Session["ID"] != null)
            {

                string SESS = Getsession();
                string[] MM = SESS.Split('-');
                if (MM[0].ToString() == "06") { CP = "SUMMER"; }
                else if (MM[0].ToString() == "12") { CP = "WINTER"; }
                CP = CP + "-" + MM[1].ToString();

                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                string _sqlQuery = "select * from REEVA where CANDIDATEID='" + Session["ID"].ToString().Trim() + "'";
                AllQueryParam[0] = _sqlQuery;
                BLL objbllLogin = new BLL();
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count > 0)
                {
                    _CANDIDATEID = dt.Rows[0]["CANDIDATEID"].ToString();
                    _ROLL = dt.Rows[0]["ROLL"].ToString();
                    _CANDIDATE_NAME = dt.Rows[0]["CNAME"].ToString();
                    _FATHER_NAME = dt.Rows[0]["FNAME"].ToString();
                    _INSTITUTE = dt.Rows[0]["INSNAME"].ToString();
                    _BRANCH = dt.Rows[0]["BRNAME"].ToString();
                    _DOB = dt.Rows[0]["DOB"].ToString();
                    _FEE = dt.Rows[0]["FEE"].ToString();
                    _SUB = dt.Rows[0]["SUB"].ToString();
                    string ISCOMP = dt.Rows[0]["ISCOMPLETED"].ToString().Trim();
                    if (ISCOMP == "1")
                    {
                        TRSTAT.Visible = false;
                    }
                }
                else { Response.Redirect("~/Default.aspx", false); }
            }
            else { Response.Redirect("~/Default.aspx", false); }
        }
        catch (Exception ex) { Response.Write("Server Busy."); }
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