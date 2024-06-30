using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using _Examination;
using System.Text.RegularExpressions;

public partial class Insaddexaminer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Request.QueryString["STAT"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (Session["INSCODE"] == null && Session["UTYPE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            if (!IsPostBack)
            {
                Getdistrict();
                Getinstitute();
                Getbranch();

                string[] SPL = Request.QueryString["STAT"].ToString().Trim().Split('|');
                string TYPE = SPL[0].ToString();
                string EMPID = SPL[1].ToString();
                if(TYPE=="E")
                {
                    string[] insspl = Session["INSCODE"].ToString().Split('|');
                    DataTable dt = new DataTable();
                    string[] AllQueryParam = new string[1];
                    string _sqlQuery = "select * FROM EMPLOYEE WHERE INSCODE='" + insspl[0].ToString() + "' AND EMPID='" + EMPID + "'";
                    AllQueryParam[0] = _sqlQuery;
                    BLL objbllLogin = new BLL();
                    objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                    if (dt.Rows.Count > 0)
                    {
                        Txtexcode.Text = dt.Rows[0]["EMPCODE"].ToString().Trim();
                        Txtexname.Text = dt.Rows[0]["EMPNAME"].ToString().Trim();
                        Drpdesig.SelectedValue = dt.Rows[0]["EMPDESIG"].ToString().Trim();
                        Drpbrcode.SelectedValue = dt.Rows[0]["BRCODE"].ToString().Trim();
                        Drpins.SelectedValue = dt.Rows[0]["INSCODE"].ToString().Trim();
                        Txtcity.Text = dt.Rows[0]["EMPCITY"].ToString().Trim();
                        Drpdistrict.SelectedValue = dt.Rows[0]["EMPDIST"].ToString().Trim();
                        Txtmono.Text = dt.Rows[0]["MONO"].ToString().Trim();
                        Txtemail.Text = dt.Rows[0]["EMAIL"].ToString().Trim();
                        Btnadd.Text = "Update";
                    }
                }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void Btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            INSERTDATA();
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    private void INSERTDATA()
    {
        if (Session["INSCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
        BLL _Objbll = new BLL();
        string _sqlQuery = string.Empty;
        string[] SPL = Request.QueryString["STAT"].ToString().Trim().Split('|');
        string TYPE = SPL[0].ToString();
        string EMPID = SPL[1].ToString();
        if (TYPE == "E")
        {
            _sqlQuery = "UPDATE EMPLOYEE SET EMPCODE='" + Txtexcode.Text.ToUpper() + "',EMPNAME='" + Txtexname.Text.ToUpper() + "',EMPDESIG='" + Drpdesig.SelectedValue + "',BRCODE='" + Drpbrcode.SelectedValue + "',INSCODE='" + Drpins.SelectedValue + "',EMPCITY='" + Txtcity.Text.ToUpper() + "',EMPDIST='" + Drpdistrict.SelectedValue + "',MONO='" + Txtmono.Text + "',EMAIL='" + Txtemail.Text.ToUpper() + "' WHERE EMPID='" + EMPID + "'";
            string result = _Objbll.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                Response.Redirect("~/Institute/Insexaminer.aspx",false);
            }
        }
        else if (TYPE == "N")
        {
            _sqlQuery = "INSERT INTO EMPLOYEE(EMPCODE,EMPNAME,EMPDESIG,BRCODE,INSCODE,EMPCITY,EMPDIST,MONO,EMAIL,STAT) VALUES('" + Txtexcode.Text.ToUpper() + "','" + Txtexname.Text.ToUpper() + "','" + Drpdesig.SelectedValue + "','" + Drpbrcode.SelectedValue + "','" + Drpins.SelectedValue + "','" + Txtcity.Text.ToUpper() + "','" + Drpdistrict.SelectedValue + "','" + Txtmono.Text + "','" + Txtemail.Text.ToUpper() + "','A')";
            string result = _Objbll.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                Response.Redirect("~/Institute/Insexaminer.aspx", false);
            }
            else { ltrlMessage.Text = "Please try after some time."; }
        }
    }
    private void Getdistrict()
    {
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        string _sqlQuery = "select * FROM DISTRICT ORDER BY DISTCODE ASC";
        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count > 0)
        {
            Drpdistrict.DataSource = dt;
            Drpdistrict.DataValueField = "DISTCODE";
            Drpdistrict.DataTextField = "DISTNAME";
            Drpdistrict.DataBind();
        }
    }
    private void Getinstitute()
    {
        string[] insspl = Session["INSCODE"].ToString().Split('|');
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        string _sqlQuery = "select * FROM INSLOGIN WHERE INSCODE='" + insspl[0].ToString() + "' ORDER BY INSCODE ASC";
        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count > 0)
        {
            Drpins.DataSource = dt;
            Drpins.DataValueField = "INSCODE";
            Drpins.DataTextField = "INSNAME";
            Drpins.DataBind();
        }
    }
    private void Getbranch()
    {
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        string _sqlQuery = "SELECT * FROM BRANCH ORDER BY BRCODE ASC";
        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count > 0)
        {

            Drpbrcode.DataSource = dt;
            Drpbrcode.DataValueField = "BRCODE";
            Drpbrcode.DataTextField = "BRNAME";
            Drpbrcode.DataBind();
        }
    }
}