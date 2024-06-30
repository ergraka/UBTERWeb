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
public partial class Openreports : System.Web.UI.Page
{
    public string Comp = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (Request.QueryString["STAT"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (!IsPostBack)
            {
                Btnsubmit.Visible = false;
                Grdbr.Visible = false;
                Grdins.Visible = false;


                string STAT = Request.QueryString["STAT"].ToString();
                if (STAT == "ADMT") { Lblcp.Text = "Add Institute & Barch Category For Admit Card"; }
                else if (STAT == "VER") { Lblcp.Text = "Add Institute & Barch Category For Verification"; }
                else if (STAT == "LISTE") { Lblcp.Text = "Add Institute & Barch Category For LIST-E"; }
                else if (STAT == "LISTD") { Lblcp.Text = "Add Institute & Barch Category For LIST-D"; }
                else if (STAT == "SESS") { Lblcp.Text = "Add Institute & Barch Category For Sessional List"; }
                else if (STAT == "SBPADMT") { Lblcp.Text = "Add Institute & Barch Category For SBP Admit Card"; }
                else if (STAT == "SBPVER") { Lblcp.Text = "Add Institute & Barch Category For SBP Verification"; }
                else if (STAT == "SBPLISTE") { Lblcp.Text = "Add Institute & Barch Category For SBP LIST-E"; }
                else if (STAT == "SBPLISTD") { Lblcp.Text = "Add Institute & Barch Category For SBP LIST-D"; }

                Institute();
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            Chksem01.Checked = false;
            Chksem02.Checked = false;
            Chksem03.Checked = false;
            Chksem04.Checked = false;
            Chksem05.Checked = false;
            Chksem06.Checked = false;
            Chksemp.Checked = false;
            Chksemq.Checked = false;

            string STAT = Request.QueryString["STAT"].ToString();
            string _sqlQueryreg = string.Empty;
            string[] AllQueryParamreg = new string[1];
            BLL objbllreg = new BLL();
            
            DataTable dtreg = new DataTable();
            if (Drpsearchtype.SelectedValue == "I") { _sqlQueryreg = "SELECT DISTINCT INSCODE,BRCODE," + STAT + " FROM BRLOGIN WHERE INSCODE='" + Drpins.SelectedValue + "' AND BRCODE !='0' AND STAT='A' ORDER BY INSCODE,BRCODE ASC"; Grdins.Visible = true; Grdbr.Visible = false; }
            else if (Drpsearchtype.SelectedValue == "B") { _sqlQueryreg = "SELECT DISTINCT BRCODE," + STAT + " FROM BRLOGIN WHERE BRCODE !='0' AND STAT='A' ORDER BY BRCODE ASC"; Grdins.Visible = false; Grdbr.Visible = true; }
            AllQueryParamreg[0] = _sqlQueryreg;
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count > 0)
            {
                dtreg.Columns.Add("WORKID");
                for (int i = 0; i < dtreg.Rows.Count; i++)
                {
                    dtreg.Rows[i]["WORKID"] = STAT;
                }
                if (Drpsearchtype.SelectedValue == "I")
                {
                    Grdins.DataSource = dtreg;
                    Grdins.DataBind();
                    ////Checked on Already Open
                    int n = 0;
                    foreach (GridViewRow gvrow in Grdins.Rows)
                    {
                        string VAL = dtreg.Rows[n][STAT].ToString();
                        string SEM = string.Empty;
                        for (int i = 1; i <= 8; i++)
                        {
                            SEM = "0" + i.ToString();
                            if (i == 7) { SEM = "P"; }
                            else if (i == 8) { SEM = "Q"; }
                            CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem" + SEM);
                            if (VAL.Contains(SEM) == true) { chk.Checked = true; }
                        }
                        n++;
                    }
                }
                else if (Drpsearchtype.SelectedValue == "B")
                {
                    Grdbr.DataSource = dtreg;
                    Grdbr.DataBind();
                    ////Checked on Already Open
                    int n = 0;
                    foreach (GridViewRow gvrow in Grdbr.Rows)
                    {
                        string VAL = dtreg.Rows[n][STAT].ToString();
                        string SEM = string.Empty;
                        for (int i = 1; i <= 8; i++)
                        {
                            SEM = "0" + i.ToString();
                            if (i == 7) { SEM = "P"; }
                            else if (i == 8) { SEM = "Q"; }
                            CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem" + SEM);
                            if (VAL.Contains(SEM) == true) { chk.Checked = true; }
                        }
                        n++;
                    }
                }
                Btnsubmit.Visible = true;
            }
            else { LblMessage.Text = "No Records Found."; }
        }
        catch (Exception ex)
        { LblMessage.Text = ex.Message; }
    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            Chksem01.Checked = false;
            Chksem02.Checked = false;
            Chksem03.Checked = false;
            Chksem04.Checked = false;
            Chksem05.Checked = false;
            Chksem06.Checked = false;
            Chksemp.Checked = false;
            Chksemq.Checked = false;
            string _sqlQuery = string.Empty;
            BLL objbll = new BLL();
            string[] AllQueryParam = new string[1];
            //Submit Work
            string STAT = Request.QueryString["STAT"].ToString();
            int n = 0;
            if (Drpsearchtype.SelectedValue == "I")
            {
                foreach (GridViewRow gvrow in Grdins.Rows)
                {
                    int F = 0;
                    string INSCODE = Grdins.Rows[n].Cells[1].Text.ToUpper();
                    string BRCODE = Grdins.Rows[n].Cells[2].Text.ToUpper();
                    string SEM = string.Empty;
                    string VAL = string.Empty;
                    for (int i = 1; i <= 8; i++)
                    {
                        SEM = "0" + i.ToString();
                        if (i == 7) { SEM = "P"; }
                        else if (i == 8) { SEM = "Q"; }
                        CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem" + SEM);
                        if (chk != null & chk.Checked)
                        {
                            if (F == 0) { VAL = SEM; }
                            else { VAL = VAL + "|" + SEM; }
                            F = 1;
                        }
                    }
                    if (F == 1)
                    {
                        _sqlQuery = "UPDATE BRLOGIN SET " + STAT + "='" + VAL + "' WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "'";
                        string result = objbll.ONLYQUERYBLL(_sqlQuery);
                    }
                    else
                    {
                        _sqlQuery = "UPDATE BRLOGIN SET " + STAT + "='N' WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "'";
                        string result = objbll.ONLYQUERYBLL(_sqlQuery);
                    }
                    n++;
                }
            }
            else if (Drpsearchtype.SelectedValue == "B")
            {
                foreach (GridViewRow gvrow in Grdbr.Rows)
                {
                    int F = 0;
                    string BR = Grdbr.Rows[n].Cells[1].Text.ToUpper();
                    string SEM = string.Empty;
                    string VAL = string.Empty;
                    for (int i = 1; i <= 8; i++)
                    {
                        SEM = "0" + i.ToString();
                        if (i == 7) { SEM = "P"; }
                        else if (i == 8) { SEM = "Q"; }
                        CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem" + SEM);
                        if (chk != null & chk.Checked)
                        {
                            if (F == 0) { VAL = SEM; }
                            else { VAL = VAL + "|" + SEM; }
                            F = 1;
                        }
                    }
                    if (F == 1)
                    {
                        _sqlQuery = "UPDATE BRLOGIN SET " + STAT + "='" + VAL + "' WHERE BRCODE='" + BR + "'";
                        string result = objbll.ONLYQUERYBLL(_sqlQuery);
                    }
                    else
                    {
                        _sqlQuery = "UPDATE BRLOGIN SET " + STAT + "='N' WHERE BRCODE='" + BR + "'";
                        string result = objbll.ONLYQUERYBLL(_sqlQuery);
                    }
                    n++;
                }
            }
            LblMessage.Text = "FORM SUBMITTED SUCCESSFULLY.";
            Grdins.Visible = false;
            Grdbr.Visible = false;
            Btnsubmit.Visible = false;
            Drpsearchtype.SelectedIndex = 0;
            Chksem01.Checked = false;
            Chksem02.Checked = false;
            Chksem03.Checked = false;
            Chksem04.Checked = false;
            Chksem05.Checked = false;
            Chksem06.Checked = false;
            Chksemp.Checked = false;
            Chksemq.Checked = false;
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    protected void Chksem01_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpsearchtype.SelectedValue == "I")
            {
                if (Chksem01.Checked == true) { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem01"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem01"); chk.Checked = false; } }
            }
            else if (Drpsearchtype.SelectedValue == "B")
            {
                if (Chksem01.Checked == true) { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem01"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem01"); chk.Checked = false; } }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Chksem02_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpsearchtype.SelectedValue == "I")
            {
                if (Chksem02.Checked == true) { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem02"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem02"); chk.Checked = false; } }
            }
            else if (Drpsearchtype.SelectedValue == "B")
            {
                if (Chksem02.Checked == true) { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem02"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem02"); chk.Checked = false; } }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Chksem03_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpsearchtype.SelectedValue == "I")
            {
                if (Chksem03.Checked == true) { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem03"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem03"); chk.Checked = false; } }
            }
            else if (Drpsearchtype.SelectedValue == "B")
            {
                if (Chksem03.Checked == true) { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem03"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem03"); chk.Checked = false; } }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Chksem04_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpsearchtype.SelectedValue == "I")
            {
                if (Chksem04.Checked == true) { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem04"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem04"); chk.Checked = false; } }
            }
            else if (Drpsearchtype.SelectedValue == "B")
            {
                if (Chksem04.Checked == true) { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem04"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem04"); chk.Checked = false; } }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Chksem05_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpsearchtype.SelectedValue == "I")
            {
                if (Chksem05.Checked == true) { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem05"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem05"); chk.Checked = false; } }
            }
            else if (Drpsearchtype.SelectedValue == "B")
            {
                if (Chksem05.Checked == true) { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem05"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem05"); chk.Checked = false; } }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Chksem06_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpsearchtype.SelectedValue == "I")
            {
                if (Chksem06.Checked == true) { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem06"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem06"); chk.Checked = false; } }
            }
            else if (Drpsearchtype.SelectedValue == "B")
            {
                if (Chksem06.Checked == true) { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem06"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsem06"); chk.Checked = false; } }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Chksemp_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpsearchtype.SelectedValue == "I")
            {
                if (Chksemp.Checked == true) { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsemp"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsemp"); chk.Checked = false; } }
            }
            else if (Drpsearchtype.SelectedValue == "B")
            {
                if (Chksemp.Checked == true) { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsemp"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsemp"); chk.Checked = false; } }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Chksemq_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpsearchtype.SelectedValue == "I")
            {
                if (Chksemq.Checked == true) { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsemq"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdins.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsemq"); chk.Checked = false; } }
            }
            else if (Drpsearchtype.SelectedValue == "B")
            {
                if (Chksemq.Checked == true) { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsemq"); chk.Checked = true; } }
                else { foreach (GridViewRow gvrow in Grdbr.Rows) { CheckBox chk = (CheckBox)gvrow.FindControl("Cbsemq"); chk.Checked = false; } }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Drpsearchtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpsearchtype.SelectedValue == "I")
            {
                TRINS.Visible = true;
                Grdins.Visible = true;
                Grdbr.Visible = false;
            }
            else
            {
                TRINS.Visible = false; 
                Grdins.Visible = false;
                Grdbr.Visible = true;
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    private void Institute()
    {
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        _sqlQueryreg = "select distinct INSCODE,INSNAME from INSLOGIN order by INSCODE asc";
        AllQueryParamreg[0] = _sqlQueryreg;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0)
        {
            Drpins.DataValueField = dtreg.Columns["INSCODE"].ToString().Trim();
            Drpins.DataTextField = dtreg.Columns["INSNAME"].ToString().Trim();
            Drpins.DataSource = dtreg;
            Drpins.DataBind();
            if (Drpins.Items.Count > 0) { Drpins.SelectedIndex = 0; }
        }
        else { Response.Redirect("~/Error.aspx", true); }
    }
}