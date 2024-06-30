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
public partial class Updatestudent : System.Web.UI.Page
{
    public string Comp = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (!IsPostBack)
            {
                Btnsubmit.Visible = false;
                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                BLL objbllreg = new BLL();
                string[] AllQueryParamreg = new string[1];
                //Get Table Schema
                DataTable dtclm = new DataTable();
                _sqlQueryreg = "SELECT TOP(0) * FROM REGISTRATION";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtclm, AllQueryParamreg);
                if (dtclm.Columns.Count > 0)
                {
                    Drpclm.Items.Add("-Select Column-");
                    for (int i = 0; i < dtclm.Columns.Count; i++)
                    {
                        string CLM = dtclm.Columns[i].ToString();
                        if (CLM != "CANDIDATEID" && CLM != "INSCODE" && CLM != "INSNAME" && CLM != "BRCODE" && CLM != "BRNAME" && CLM != "SHIFT" && CLM != "REGCAT" && CLM != "ADDCAT")
                        {
                            Drpclm.Items.Add(CLM);
                        }
                    }
                }
                else { Response.Redirect("~/Error.aspx", true); }

            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            LblMessage.Text = "";
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Txtroll.Text == "") { LblMessage.Text = "Please Enter Registration Number OR Roll Number."; return; }

            string _sqlQueryreg = string.Empty;
            DataTable dtreg = new DataTable();
            string[] AllQueryParamreg = new string[1];
            _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "')";
            AllQueryParamreg[0] = _sqlQueryreg;
            BLL objbllreg = new BLL();
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count > 0)
            {
                Txtchange.Text = "";
                Drpclm.SelectedIndex = 0;
                Trchange.Visible = true;
                Btnsubmit.Visible = true;
            }
            else
            {
                Drpclm.SelectedIndex = 0;
                Trchange.Visible = false;
                Btnsubmit.Visible = false;
                Txtchange.Text = "";
                LblMessage.Text = Txtroll.Text + "- IS Invalid Registration Number OR Roll Number.Please Enter Valid Registration Number OR Roll Number.";
            }
        }
        catch (Exception ex)
        { LblMessage.Text = ex.Message; }
    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string _sqlQuery = string.Empty;
            BLL objbll = new BLL();
            string[] AllQueryParam = new string[1];
            AllQueryParam[0] = _sqlQuery;
            _sqlQuery = "UPDATE REGISTRATION SET " + Drpclm.SelectedItem.ToString() + "='" + Txtchange.Text.ToUpper() + "' WHERE (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "')";
            string result = objbll.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                if (Drpclm.SelectedItem.ToString() == "SEM" || Drpclm.SelectedItem.ToString() == "REGPVT" || Drpclm.SelectedItem.ToString() == "CNAME" || Drpclm.SelectedItem.ToString() == "FNAME" || Drpclm.SelectedItem.ToString() == "DOB")
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        string TBL = string.Empty;
                        if (i == 1) { TBL = "BACKP"; }
                        else if (i == 2) { TBL = "SCRU"; }
                        else if (i == 3) { TBL = "REEVA"; }
                        _sqlQuery = "UPDATE " + TBL + " SET " + Drpclm.SelectedItem.ToString() + "='" + Txtchange.Text.ToUpper() + "'  WHERE (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "')";
                        objbll.ONLYQUERYBLL(_sqlQuery);
                    }
                }
                LblMessage.Text = "UPDATE COMPLETED SUCCESSFULLY.";
                Trchange.Visible = false;
                Btnsubmit.Visible = false;
                Txtchange.Text = "";
                Drpclm.SelectedIndex = 0;
            }
            else { LblMessage.Text = "UPDATE FAILED."; }

        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    protected void Drpclm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Drpclm.SelectedIndex > 0)
            {
                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                string[] AllQueryParamreg = new string[1];
                _sqlQueryreg = "SELECT " + Drpclm.SelectedItem.ToString() + " FROM REGISTRATION WHERE (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "')";
                AllQueryParamreg[0] = _sqlQueryreg;
                BLL objbllreg = new BLL();
                objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                if (dtreg.Rows.Count > 0)
                {
                    Txtchange.Text = dtreg.Rows[0][Drpclm.SelectedItem.ToString()].ToString();
                }
                else { LblMessage.Text = "No Records Found"; }
            }
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
}