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
public partial class Marks_Pre_List_E : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["INSCODE"] != null && Session["BRCODE"] != null)
                {
                    string[] splbr = Session["BRCODE"].ToString().Split('|');
                    string[] BRSPL = splbr[0].ToString().Split('-');
                    //***************************************************************************GET SUBJECT
                    string _sqlQueryreg = string.Empty;
                    DataTable dtreg = new DataTable();
                    string[] AllQueryParamreg = new string[1];
                    _sqlQueryreg = "select distinct SUBCODE,SUBJECT from SUBJ where SEM='01' and BRCODE='" + BRSPL[0].ToString() + "' and (TYPE='P' OR TYPE='TP') order by SUBCODE asc";
                    AllQueryParamreg[0] = _sqlQueryreg;
                    BLL objbllreg = new BLL();
                    objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                    if (dtreg.Rows.Count > 0)
                    {
                        Drpsub.DataValueField = dtreg.Columns["SUBCODE"].ToString().Trim();
                        Drpsub.DataTextField = dtreg.Columns["SUBJECT"].ToString().Trim();
                        Drpsub.DataSource = dtreg;
                        Drpsub.DataBind();
                        if (Drpsub.Items.Count > 0) { Drpsub.SelectedIndex = 0; }
                    }
                    else { LblMessage.Text = "No Subject Found."; }
                }
                else { Response.Redirect("~/Inslogin.aspx", false); }
            }
        }
        catch (Exception ex)
        {
            LblMessage.Text = "Please try after some time !";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The Login can not complete. Please try after some time !');", true);
        }
    }
    protected void Btnview_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null && Session["BRCODE"] != null)
            {
                LblMessage.Text = "";
                string[] splins = Session["INSCODE"].ToString().Split('|');
                Lblins.Text = splins[1].ToString();
                string[] splbr = Session["BRCODE"].ToString().Split('|');
                Lblbranch.Text = splbr[1].ToString();
                string[] BRSPL = splbr[0].ToString().Split('-');
                //************************************************************************************GET BRANCH SUMMARY
                string _sqlQueryreg1 = string.Empty;
                DataTable dtreg1 = new DataTable();
                string[] AllQueryParamreg1 = new string[1];
                _sqlQueryreg1 = "select PRMAX,PRMIN from SUBJ where BRCODE='" + BRSPL[0].ToString() + "' and SUBCODE='" + Drpsub.SelectedValue + "'";
                AllQueryParamreg1[0] = _sqlQueryreg1;
                BLL objbllreg1 = new BLL();
                objbllreg1.QUERYBLL(ref dtreg1, AllQueryParamreg1);
                if (dtreg1.Rows.Count > 0)
                {
                    Lblsub.Text = Drpsub.SelectedItem.ToString();
                    Lblsubcode.Text = Drpsub.SelectedValue;
                    Lblmax.Text = dtreg1.Rows[0]["PRMAX"].ToString();
                    Lblmin.Text = dtreg1.Rows[0]["PRMIN"].ToString();
                    Lblsem.Text = "01";
                    Lblshift.Text = SHIFTVAL();
                }
                else { Response.Redirect("Error.aspx", true); }
                Griddata();
            }
            else { Response.Redirect("~/Inslogin.aspx", false); }
        }
        catch (Exception ex)
        {
            LblMessage.Text = "Please try after some time !";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The Login can not complete. Please try after some time !');", true);
        }
    }
    private string SHIFTVAL()
    {

        string[] splins = Session["INSCODE"].ToString().Split('|');
        string INSCODE = splins[0].ToString();
        string[] splbr = Session["BRCODE"].ToString().Split('|');
        string BRCODE = splbr[0].ToString();
        string SHFT = string.Empty;
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        _sqlQueryreg = "select SHIFT from BRLOGIN where BRCODE='" + BRCODE + "' and INSCODE='" + INSCODE + "'";
        AllQueryParamreg[0] = _sqlQueryreg;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0)
        {
            SHFT = dtreg.Rows[0]["SHIFT"].ToString();
        }
        if (SHFT == "I") { SHFT = "SHIFT-I"; }
        else if (SHFT == "I") { SHFT = "SHIFT-II"; }
        return SHFT;
    }
    protected void Grddata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (IsPostBack)
            {
                if (Session["INSCODE"] != null && Session["BRCODE"] != null)
                {
                    LblMessage.Text = "";
                    Grddata.PageIndex = e.NewPageIndex;
                    Griddata();
                }
                else { Response.Redirect("~/Inslogin.aspx", false); }
            }
        }
        catch (Exception ex) { LblMessage.Text = "Server Busy, Please try after some time !"; }
    }
    public void Griddata()
    {
        string[] splins = Session["INSCODE"].ToString().Split('|');
        string[] splbr = Session["BRCODE"].ToString().Split('|');
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        _sqlQueryreg = "select * from REGISTRATION where INSCODE='" + splins[0].ToString() + "' and BRCODE='" + splbr[0].ToString() + "' and CANDIDATEID NOT IN(select CANDIDATEID FROM LISTE where  INSCODE='" + splins[0].ToString() + "' and BRCODE='" + splbr[0].ToString() + "' and SUBCODE='" + Drpsub.SelectedValue + "' and SEM='" + Lblsem.Text + "') order by CANDIDATEID asc";
        AllQueryParamreg[0] = _sqlQueryreg;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0)
        {
            Grddata.Visible = true;
            Grddata.DataSource = dtreg;
            Grddata.DataBind();
            Lblcount.Text = dtreg.Rows.Count.ToString();
        }
        else { LblMessage.Text = "No Records Found."; Grddata.Visible = false; Lblcount.Text = dtreg.Rows.Count.ToString(); }
    }
    protected void Btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
            {
                LblMessage.Text = "";
                if (Session["INSCODE"] != null && Session["BRCODE"] != null)
                {
                    string _sqlQuery = string.Empty;
                    int n = 0;
                    int max = Convert.ToInt32(Lblmax.Text);
                    foreach (GridViewRow gvrow in Grddata.Rows)
                    {
                        TextBox Txtmark = (TextBox)gvrow.FindControl("Txtmarks");
                        if (Txtmark.Text!="")
                        {
                            int mrk = Convert.ToInt32(Txtmark.Text);
                            if (mrk <= max)
                            {
                                string CANDIDATEID = Grddata.Rows[n].Cells[0].Text;
                                if (CANDIDATEID == "&nbsp;") { CANDIDATEID = ""; }
                                string CNAME = Grddata.Rows[n].Cells[1].Text;
                                if (CNAME == "&nbsp;") { CNAME = ""; }
                                string FNAME = Grddata.Rows[n].Cells[2].Text;
                                if (FNAME == "&nbsp;") { FNAME = ""; }
                                string DOB = Grddata.Rows[n].Cells[3].Text;
                                if (DOB == "&nbsp;") { DOB = ""; }
                                string SEX = Grddata.Rows[n].Cells[4].Text;
                                if (SEX == "&nbsp;") { SEX = ""; }
                                string[] splins = Session["INSCODE"].ToString().Split('|');
                                string INSCODE = splins[0].ToString();
                                string[] splbr = Session["BRCODE"].ToString().Split('|');
                                string BRCODE = splbr[0].ToString();
                                string SUBCODE = Lblsubcode.Text;
                                string SEM = Lblsem.Text;
                                string MARKS = Txtmark.Text;
                                if (MARKS.Length == 1) { MARKS = "0" + MARKS; }
                                string FLG = "Y";
                                BLL objbllonlyquery = new BLL();
                                _sqlQuery = "INSERT INTO LISTE(CANDIDATEID,CNAME,FNAME,DOB,GENDER,INSCODE,BRCODE,SUBCODE,SEM,MARKS,FLG,UPDATEDON) VALUES('" + CANDIDATEID + "','" + CNAME + "','" + FNAME + "','" + DOB + "','" + SEX + "','" + INSCODE + "','" + BRCODE + "','" + SUBCODE + "','" + SEM + "','" + MARKS + "','" + FLG + "',getdate())";
                                string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                                if (result == "1-1") {  }
                                else { LblMessage.Text = "Marks Saved With Some Errors."; }
                            }
                            else { LblMessage.Text = "Data Submit with Error, Some Marks Are Greater Than Maximum Marks."; }
                        }
                        else { LblMessage.Text = "Marks Submited Successfully, Blank Marks will Not be Submit."; }
                        n++;
                    }
                    Griddata();
                }
                else { Response.Redirect("~/Inslogin.aspx", false); }
            }
        }
        catch (Exception ex) { LblMessage.Text = "Server Busy, Please try after some time !"; }
    }
}