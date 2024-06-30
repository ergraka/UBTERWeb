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

public partial class Default : System.Web.UI.Page
{
    public System.Text.StringBuilder sr = new System.Text.StringBuilder();
    public System.Text.StringBuilder srwork = new System.Text.StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["CHANGE"] != null)
            {
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Password Changed Successfully. Please Login with new Password !!!!');</script>", false);
            }
            if (!IsPostBack)
            {
                Liveworks();
                #region COUNT ON PER REFRESH
                //COUNT ON PER LOAD/REFRESH
                //this.countMe();
                //DataSet tmpDs = new DataSet();
                //tmpDs.ReadXml(Server.MapPath("~/Report/SANTROSH.xml"));
                //string cnt = tmpDs.Tables[0].Rows[0]["hits"].ToString();
                //int len = cnt.Length;
                //for (int i = 0; i < 10 - len; i++) { cnt = "0" + cnt; }
                //sr.Append("<table border=\"1\">");
                //sr.Append("<tr>");
                //for (int i = 0; i < cnt.Length; i++) { sr.Append("<td style='border:1px solid #DC143C; background-color:#FFE4B5;'>" + cnt.Substring(i, 1) + "</td>"); }
                //sr.Append("</tr>");
                //sr.Append("</table>");
                #endregion
                #region COUNT ON PER SESSION
                string cnt = Application["Online"].ToString();
                int len = cnt.Length;
                for (int i = 0; i < 10 - len; i++) { cnt = "0" + cnt; }
                sr.Append("<table border=\"1\">");
                sr.Append("<tr>");
                for (int i = 0; i < cnt.Length; i++) { sr.Append("<td style='border:1px solid #DC143C; background-color:#FFE4B5;'>" + cnt.Substring(i, 1) + "</td>"); }
                sr.Append("</tr>");
                sr.Append("</table>");
                #endregion
            }
        }
        catch (Exception ex) { Response.Write(ex.Message); }
    }
    protected void Lnkgov_Click(object sender, EventArgs e)
    {
        try
        {
            Session["REGCAT"] = "GOVT";
            Response.Redirect("Institute/Inslogin.aspx", false);
        }
        catch { Response.Redirect("Error.aspx", true); }
    }
    private void countMe()
    {
        DataSet tmpDs = new DataSet();
        tmpDs.ReadXml(Server.MapPath("~/Report/Count.xml"));
        int hits = Int32.Parse(tmpDs.Tables[0].Rows[0]["hits"].ToString());
        hits += 1;
        tmpDs.Tables[0].Rows[0]["hits"] = hits.ToString();
        tmpDs.WriteXml(Server.MapPath("~/Report/Count.xml"));
    }
    protected void Lnkpvt_Click(object sender, EventArgs e)
    {
        try
        {
            Session["REGCAT"] = "PVT";
            Response.Redirect("Institute/Inslogin.aspx", false);
        }
        catch { Response.Redirect("Error.aspx", true); }
    }
    protected void Lnkadmin_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/Adminlogin.aspx", false);
        }
        catch { Response.Redirect("Error.aspx", true); }
    }
    private void Liveworks()
    {
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        string _sqlQuery = "SELECT * FROM WORKS WHERE DISPLAY='Y' ORDER BY WORKID DESC";
        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string DATE = string.Empty;
                string WORKNAME = dt.Rows[i]["WORKNAME"].ToString();
                string[] FDATE = dt.Rows[i]["DATEF"].ToString().Trim().Split(',');
                int F1 = 0;
                int F2 = 0;
                int F3 = 0;
                int F4 = 0;
                int F5 = 0;
                int F6 = 0;
                string DATE1 = string.Empty;
                if (FDATE.Length > 1)
                {
                    F1 = Convert.ToInt32(FDATE[0].ToString());
                    F2 = Convert.ToInt32(FDATE[1].ToString());
                    F3 = Convert.ToInt32(FDATE[2].ToString());
                    F4 = Convert.ToInt32(FDATE[3].ToString());
                    F5 = Convert.ToInt32(FDATE[4].ToString());
                    F6 = Convert.ToInt32(FDATE[5].ToString());
                    DateTime SDATE = new DateTime(F1, F2, F3, F4, F5, F6);
                    DATE1 = FDATE[2].ToString() + "-" + FDATE[1].ToString() + "-" + FDATE[0].ToString();
                }
                string[] LDATE = dt.Rows[i]["DATET"].ToString().Trim().Split(',');
                int L1 = 0;
                int L2 = 0;
                int L3 = 0;
                int L4 = 0;
                int L5 = 0;
                int L6 = 0;
                string DATE2 = string.Empty;
                if (LDATE.Length > 1)
                {
                    L1 = Convert.ToInt32(LDATE[0].ToString());
                    L2 = Convert.ToInt32(LDATE[1].ToString());
                    L3 = Convert.ToInt32(LDATE[2].ToString());
                    L4 = Convert.ToInt32(LDATE[3].ToString());
                    L5 = Convert.ToInt32(LDATE[4].ToString());
                    L6 = Convert.ToInt32(LDATE[5].ToString());
                    DateTime EDATE = new DateTime(L1, L2, L3, L4, L5, L6);
                    DATE2 = LDATE[2].ToString() + "-" + LDATE[1].ToString() + "-" + LDATE[0].ToString();
                }

                
                

                if (F4 > 0) { DATE1 = DATE1 + " [ " + FDATE[3].ToString() + ":" + FDATE[4].ToString() + ":" + FDATE[5].ToString() + " ]"; }
                if (L4 > 0) { DATE2 = DATE2 + " [ " + LDATE[3].ToString() + ":" + LDATE[4].ToString() + ":" + LDATE[5].ToString() + " ]"; }

                if (LDATE.Length < 2) { DATE = "From " + DATE1; }
                else { DATE = "From " + DATE1 + " to " + DATE2; }

                string STAT = dt.Rows[i]["STAT"].ToString();
                if (STAT == "A") { STAT = "Live"; }
                else if (STAT == "C") { STAT = "Closed"; }
                DATE = DATE + " - " + STAT;

                srwork.Append("<tr>");
                srwork.Append("<td>" + WORKNAME + "</td>");
                if (i == 0)
                {
                    srwork.Append("<td>" + DATE + " <img src='Images/new.gif' alt='New' /> </td> ");
                }
                else { srwork.Append("<td>" + DATE + "</td>"); }
                srwork.Append("</tr>");
            }
        }
    }
}