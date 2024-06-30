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
public partial class Adminbractive : System.Web.UI.Page
{
    public string LNKURL = string.Empty;
    public string TYPENAME = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (!IsPostBack)
            {
                Griddata();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Btnapproved_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            Approved();
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    public void Approved()
    {
        string _sqlQuery = string.Empty;
        int count = 0;
        foreach (GridViewRow gvrow in Grdaproved.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("CbSelect");
            if (chk != null & chk.Checked)
            {
                string PQ = string.Empty;
                BLL objbllonlyquery = new BLL();
                     _sqlQuery = "UPDATE BACKP SET ISCOMPLETED=NULL,UPDATEDON=SWITCHOFFSET(SYSDATETIMEOFFSET(), '+05:30') WHERE CANDIDATEID='" + chk.Text + "'"; //DISAPPROVED SPECIAL BACK PAPER
                string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                if (result == "1-1") { count++; }
            }
        }
        ltrlMessage.Text = count.ToString() + "-RECORDS UPDATED SUCCESSFULLY.";
        Griddata();
    }
    public void Griddata()
    {
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        //_sqlQueryreg = "select * from REGISTRATION where STAT='A' AND INSCODE='" + inscode + "' order by BRCODE,SEM,CNAME asc";
        AllQueryParamreg[0] = _sqlQueryreg;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        DataTable dtdata = ROWS();
        DataRow dr = dtdata.NewRow();
        for (int i = 0; i < dtreg.Rows.Count; i++)
        {
            dr["CNAME"] = dtreg.Rows[i]["CNAME"].ToString().Trim();
            dr["LNKURL"] = LNKURL + dtreg.Rows[i]["CANDIDATEID"].ToString().Trim();
            dr["ROLL"] = dtreg.Rows[i]["ROLL"].ToString().Trim();
            dr["CANDIDATEID"] = dtreg.Rows[i]["CANDIDATEID"].ToString().Trim();
            dr["FNAME"] = dtreg.Rows[i]["FNAME"].ToString().Trim();
            dr["BRCODE"] = dtreg.Rows[i]["BRCODE"].ToString().Trim();
            dr["SEM"] = dtreg.Rows[i]["SEM"].ToString().Trim();
            dr["DOB"] = dtreg.Rows[i]["DOB"].ToString().Trim();
            dtdata.Rows.Add(dr);
            dr = dtdata.NewRow();
        }
        Grdaproved.DataSource = dtdata;
        Grdaproved.DataBind();
        if (Grdaproved.Rows.Count == 0) { ltrlMessage.Text = "No Records Found !"; }
        else { Grdaproved.Visible = true; }
        Btnapproved.Visible = true;
        Chkall.Visible = true;
    }
    protected void Chkall_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Chkall.Checked == true)
            {
                foreach (GridViewRow gvrow in Grdaproved.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("CbSelect");
                    chk.Checked = true;
                }
            }
            else
            {
                foreach (GridViewRow gvrow in Grdaproved.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("CbSelect");
                    chk.Checked = false;
                }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Server Busy, Please try after some time !"; }
    }
    private DataTable ROWS()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("CNAME");
        dt.Columns.Add("LNKURL");
        dt.Columns.Add("ROLL");
        dt.Columns.Add("CANDIDATEID");
        dt.Columns.Add("FNAME");
        dt.Columns.Add("BRCODE");
        dt.Columns.Add("SEM");
        dt.Columns.Add("DOB");
        return dt;
    }
}