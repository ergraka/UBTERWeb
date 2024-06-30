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
public partial class Phbackpaper : System.Web.UI.Page
{
    public string Comp = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["ID"] != null && Session["ROLL"] != null)
            {
                if (!IsPostBack)
                {
                    DataTable dt = new DataTable();
                    string[] AllQueryParam = new string[1];
                    string _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID=" + Session["ID"].ToString().Trim();
                    AllQueryParam[0] = _sqlQuery;
                    BLL objbllLogin = new BLL();
                    objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                    if (dt.Rows.Count > 0)
                    {
                        string ISSEM2 = dt.Rows[0]["ISSEM2"].ToString().Trim();
                        string ISSEM2COMP = dt.Rows[0]["ISSEM2COMP"].ToString().Trim();
                        string BACKT = dt.Rows[0]["BACKT"].ToString().Trim(); if (BACKT == "") { BACKT = "None"; }
                        string BACKP = dt.Rows[0]["BACKP"].ToString().Trim(); if (BACKP == "") { BACKP = "None"; }
                        if (ISSEM2 == "True")
                        {
                            if (ISSEM2COMP == "True") { Comp = "YOU HAVE SUBMITTED BACK PAPER APPLICATION FORM.</br>APPROVED BY H.O.D.</br></br>BACK PAPERS THEORY - [ " + BACKT + " ]</br></br>BACK PAPER PRACTICAL - [" + BACKP + " ]"; }
                            else { Comp = "YOU HAVE SUBMITTED BACK PAPER APPLICATION FORM.</br>NOT APPROVED BY H.O.D."; }
                            Grdsub.Visible = false;
                            Btnsubmit.Visible = false;
                            Chksem2.Visible = false;
                            TRBACKP.Visible = false;
                        }
                        else
                        {
                            Griddata();
                        }
                    }

                }
            }
            else { Response.Redirect("Login.aspx", false); }

        }
        catch (Exception ex) { LblMessage.Text = "Server Busy, Please try after some time !"; }
    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null && Session["ROLL"] != null)
            {
                string SEMNEWFEE = string.Empty;
                string _sqlQuery = string.Empty;
                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID=" + Session["ID"].ToString().Trim();
                AllQueryParam[0] = _sqlQuery;
                BLL objbllLogin = new BLL();
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count > 0)
                {
                    string FEE = dt.Rows[0]["SEM2FEE"].ToString();
                    if (FEE == "720") { SEMNEWFEE = FEE; }
                    else { SEMNEWFEE = "720"; }
                }
                if (Chksem2.Checked == false) { LblMessage.Text = "Please check mark on checkbox."; return; }

                int FEEBACK = 0;
                string SUBTH = string.Empty;
                string SUBPR = string.Empty;
                int n1 = 0;
                int n2 = 0;
                foreach (GridViewRow gvrow in Grdsub.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("CbSelectth");
                    if (chk != null & chk.Checked)
                    {
                        FEEBACK = FEEBACK + 200;
                        if (n1 == 0) { SUBTH = chk.Text; }
                        else
                        {
                            SUBTH = SUBTH + "|" + chk.Text;
                        }
                        n1++;
                    }
                }
                foreach (GridViewRow gvrow in Grdsub.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("CbSelectpr");
                    if (chk != null & chk.Checked)
                    {
                        FEEBACK = FEEBACK + 200;
                        if (n2 == 0) { SUBPR = chk.Text; }
                        else
                        {
                            SUBPR = SUBPR + "|" + chk.Text;
                        }
                        n2++;
                    }
                }
                if (FEEBACK >= 800) { FEEBACK = 800; }
                BLL objbllonlyquery = new BLL();
                _sqlQuery = "UPDATE REGISTRATION SET BACKT='" + SUBTH + "',BACKP='" + SUBPR + "', ISSEM2='1', BACKFEE='" + FEEBACK + "' WHERE CANDIDATEID='" + Session["ID"].ToString() + "'";
                string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                if (result == "1-1")
                {
                    Comp = "YOU HAVE SUBMITTED BACK PAPER APPLICATION FORM.</br>NOT APPROVED BY H.O.D.";
                    LblMessage.Text = Comp;
                    Grdsub.Visible = false;
                    Btnsubmit.Visible = false;
                    Chksem2.Visible = false;
                    TRBACKP.Visible = false;
                }
                else { LblMessage.Text = "YOU HAVE NOT SUBMITTED BACK PAPER APPLICATION FORM."; }

            }
            else { Response.Redirect("Login.aspx"); }
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    public void Griddata()
    {
        DataTable dtrec = new DataTable();
        if (dtrec.Columns.Count == 0)
        {
            dtrec.Columns.Add("SUBJECT");
            dtrec.Columns.Add("THE_MARKS");
            dtrec.Columns.Add("THE_BACK");
            dtrec.Columns.Add("PRA_MARKS");
            dtrec.Columns.Add("PRA_BACK");
        }
        DataRow dr = dtrec.NewRow();
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        string _sqlQuery = "select * from RESPHARMACY where ROLL=" + Session["ROLL"].ToString().Trim();
        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count > 0)
        {
            string RLFLG = dt.Rows[0]["RLFLG"].ToString().Trim();
            if (RLFLG != "UFM")
            {
                int a = 0;
                for (int i = 1; i <= 6; i++)//COUNT BACK
                {
                    string SUB = dt.Rows[0]["SUB" + i.ToString()].ToString().Trim();
                    if (SUB != "")
                    {
                        string TB = dt.Rows[0]["GBT" + i.ToString()].ToString().Trim();
                        string PB = dt.Rows[0]["GBP" + i.ToString()].ToString().Trim();
                        if (TB == "B" || PB == "B") { a++; }
                    }
                }



                for (int i = 1; i <= 6; i++)//ADD BACK
                {
                    string SUB = dt.Rows[0]["SUB" + i.ToString()].ToString().Trim();
                    if (SUB != "")
                    {
                        string SNAME = SUB + "-" + dt.Rows[0]["SNAME" + i.ToString()].ToString().Trim();
                        string TH = dt.Rows[0]["T" + i.ToString()].ToString().Trim();
                        string PR = dt.Rows[0]["P" + i.ToString()].ToString().Trim();

                        string TB = dt.Rows[0]["GBT" + i.ToString()].ToString().Trim();
                        string PB = dt.Rows[0]["GBP" + i.ToString()].ToString().Trim();

                        if (TB != "") { TH = TH + "(" + TB + ")"; }
                        if (PB != "") { PR = PR + "(" + PB + ")"; }
                        if (a <= 2)
                        {
                            if (TB == "B" || PB == "B")
                            {
                                dr["SUBJECT"] = SNAME;
                                if (TB == "B")
                                {
                                    dr["THE_MARKS"] = TH;
                                    dr["THE_BACK"] = SUB;
                                }
                                if (PB == "B")
                                {
                                    dr["PRA_MARKS"] = PR;
                                    dr["PRA_BACK"] = SUB;
                                }
                                dtrec.Rows.Add(dr);
                                dr = dtrec.NewRow();
                            }
                        }
                        else
                        {

                            dr["SUBJECT"] = SNAME;
                            if (SUB != "0196")
                            {
                                dr["THE_MARKS"] = TH;
                                dr["THE_BACK"] = SUB;
                                dr["PRA_MARKS"] = PR;
                                dr["PRA_BACK"] = SUB;
                            }
                            else
                            {
                                dr["THE_MARKS"] = TH;
                                dr["THE_BACK"] = SUB;
                            }
                            dtrec.Rows.Add(dr);
                            dr = dtrec.NewRow();
                        }
                    }
                }
                if (a == 0)
                {
                    LblMessage.Visible = true;
                    Btnsubmit.Visible = false;
                    LblMessage.Text = "You are not eligible for Back Paper Application Form.";
                    Chksem2.Visible = false;
                }
                else
                {
                    LblMessage.Visible = false;
                    Btnsubmit.Visible = true;
                    LblMessage.Text = "You are eligible for Back Paper Application Form.";
                    Chksem2.Visible = true;
                }

                Grdsub.DataSource = dtrec;
                Grdsub.DataBind();
                if (dtrec.Rows.Count == 0) { Chksem2.Text = "I agree to submit application form "; TRBACKP.Visible = false; }
                foreach (GridViewRow gvrow in Grdsub.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("CbSelectth");
                    string SUB = chk.Text.Trim();
                    if (SUB == "")
                    {
                        chk.Visible = false;
                    }
                }
                foreach (GridViewRow gvrow in Grdsub.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("CbSelectpr");
                    string SUB = chk.Text.Trim();
                    if (SUB == "")
                    {
                        chk.Visible = false;
                    }
                }
            }
            else { LblMessage.Text = "You are not eligible for Back Paper Application Form."; }
        }
    }
}