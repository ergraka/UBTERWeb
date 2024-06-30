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
public partial class Student_Examsummary : System.Web.UI.Page
{
    public string ROLL = string.Empty;
    public string CANDIDATEID = string.Empty;
    public string CNAME = string.Empty;
    public string FNAME = string.Empty;
    public string DOB = string.Empty;
    public string SEM = string.Empty;
    public string BRANCH = string.Empty;
    public string INSTITUTE = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                string _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID='" + Session["ID"].ToString().Trim() + "'";
                AllQueryParam[0] = _sqlQuery;
                BLL objbllLogin = new BLL();
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count > 0)
                {
                    ROLL = dt.Rows[0]["ROLL"].ToString();
                    CANDIDATEID = dt.Rows[0]["CANDIDATEID"].ToString();
                    CNAME = dt.Rows[0]["CNAME"].ToString();
                    FNAME = dt.Rows[0]["FNAME"].ToString();
                    DOB = dt.Rows[0]["DOB"].ToString();
                    SEM = "01";
                    BRANCH = dt.Rows[0]["BRNAME"].ToString();
                    INSTITUTE = dt.Rows[0]["INSNAME"].ToString();
                }
            }
            else { Response.Redirect("Login.aspx", false); }
        }
        catch (Exception ex) { LblMessage.Text = "Server Busy."; }
    }
}