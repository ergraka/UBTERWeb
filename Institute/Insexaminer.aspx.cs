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
using System.Reflection;
public partial class Insexaminer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] == null && Session["UTYPE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            {
                bindsourcedata();
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    private void bindsourcedata()
    {
        string _sqlQuery = string.Empty;
        DataTable dtdata = ROWS();
        Grd1.DataSource = dtdata; Grd1.DataBind();
        if (Grd1.Rows.Count == 0)
        {
            LblMessage.Text = "No Records Found.";
        }
        else { LblMessage.Text = ""; }
    }
    private DataTable ROWS()
    {
        string cntquery = string.Empty;
        DataTable dt = new DataTable();
        dt.Columns.Add("EMPID");
        dt.Columns.Add("EMPCODE");
        dt.Columns.Add("EMPNAME");
        dt.Columns.Add("EMPDESIG");
        dt.Columns.Add("BRCODE");
        dt.Columns.Add("INSCODE");
        dt.Columns.Add("EMPCITY");
        dt.Columns.Add("EMPDIST");
        dt.Columns.Add("MONO");
        dt.Columns.Add("EMAIL");
        dt.Columns.Add("EDITNAME");
        dt.Columns.Add("EDITURL");

        string _sqlQueryreg = string.Empty;
        string[] AllQueryParamreg = new string[1];
        BLL objbllreg = new BLL();
        string[] insspl = Session["INSCODE"].ToString().Split('|');


        DataTable dtreg = new DataTable();
        _sqlQueryreg = "SELECT * FROM EMPLOYEE WHERE INSCODE='" + insspl[0].ToString() + "' ORDER BY EMPNAME";
        AllQueryParamreg[0] = _sqlQueryreg;
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0)
        {
            DataRow dr = dt.NewRow();

            for (int i = 0; i < dtreg.Rows.Count; i++)
            {
                string EMPID = dtreg.Rows[i]["EMPID"].ToString().Trim();
                dr["EMPCODE"] = dtreg.Rows[i]["EMPCODE"].ToString().Trim(); 
                dr["EMPNAME"] = dtreg.Rows[i]["EMPNAME"].ToString().Trim();
                string EMPDESIG= dtreg.Rows[i]["EMPDESIG"].ToString().Trim();
                dr["EMPDESIG"] = EMPDESIG;
                dr["BRCODE"] = dtreg.Rows[i]["BRCODE"].ToString().Trim();
                dr["INSCODE"] = dtreg.Rows[i]["INSCODE"].ToString().Trim();
                dr["EMPCITY"] = dtreg.Rows[i]["EMPCITY"].ToString().Trim();
                string EMPDIST = dtreg.Rows[i]["EMPDIST"].ToString().Trim();
                dr["EMPDIST"] = EMPDIST;
                dr["MONO"] = dtreg.Rows[i]["MONO"].ToString().Trim();
                dr["EMAIL"] = dtreg.Rows[i]["EMAIL"].ToString().Trim();
                dr["EDITNAME"] = "Click here to Edit";
                dr["EDITURL"] = "~/Institute/Insaddexaminer.aspx?STAT=E|"+ EMPID;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
        }
        return dt;
    }
}