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

public partial class Qp_Allotment : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            //if (Session["INSCODE"] != null || Session["ADMIN"] != null) { if (Request.QueryString["AAAAA"] != null) { Session["ID"] = Request.QueryString["AAAAA"].ToString(); } }
            //if (Session["ID"] != null)
            //{
            //    DataTable dt = new DataTable();
            //    string[] AllQueryParam = new string[1];
            //    string _sqlQuery = "select * from REEVA where CANDIDATEID='" + Session["ID"].ToString().Trim() + "'";
            //    AllQueryParam[0] = _sqlQuery;
            //    BLL objbllLogin = new BLL();
            //    objbllLogin.QUERYBLL(ref dt, AllQueryParam);
            //    if (dt.Rows.Count > 0)
            //    {
            //        _CANDIDATEID = dt.Rows[0]["CANDIDATEID"].ToString();
            //        _ROLL = dt.Rows[0]["ROLL"].ToString();
            //        _CANDIDATE_NAME = dt.Rows[0]["CNAME"].ToString();
            //        _FATHER_NAME = dt.Rows[0]["FNAME"].ToString();
            //        _INSTITUTE = dt.Rows[0]["INSNAME"].ToString();
            //        _BRANCH = dt.Rows[0]["BRNAME"].ToString();
            //        _DOB = dt.Rows[0]["DOB"].ToString();
            //        _FEE = dt.Rows[0]["FEE"].ToString();
            //        _SUB = dt.Rows[0]["SUB"].ToString();
            //        string ISCOMP = dt.Rows[0]["ISCOMPLETED"].ToString().Trim();
            //        if (ISCOMP == "1")
            //        {
            //            TRSTAT.Visible = false;
            //        }
            //    }
            //    else { Response.Redirect("~/Default.aspx", false); }
            //}
            //else { Response.Redirect("~/Default.aspx", false); }
        }
        catch (Exception ex) { Response.Write("Server Busy."); }
    }
}