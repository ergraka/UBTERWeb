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

public partial class Studentsummary : System.Web.UI.Page
{
    DataTable dtdata = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("~/Admin/Adminlogin.aspx", false); }
            if (!IsPostBack)
            {
                string _sqlQueryreg = string.Empty;
                string[] AllQueryParamreg = new string[1];
                BLL objbllreg = new BLL();
                //Get Institute
                DataTable dtins = new DataTable();
                _sqlQueryreg = "select distinct INSCODE,INSNAME from INSLOGIN order by INSCODE asc";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtins, AllQueryParamreg);
                if (dtins.Rows.Count > 0)
                {
                    DataRow dr = dtins.NewRow();
                    dr[0] = "ALL";
                    dr[1] = "ALL";
                    dtins.Rows.Add(dr);

                    Drpins.DataValueField = dtins.Columns["INSCODE"].ToString().Trim();
                    Drpins.DataTextField = dtins.Columns["INSNAME"].ToString().Trim();
                    Drpins.DataSource = dtins;
                    Drpins.DataBind();
                    if (Drpins.Items.Count > 0) { Drpins.SelectedIndex = 0; }
                }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("~/Admin/Adminlogin.aspx", false); }
            if (IsPostBack)
            {
                Griddata();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    private void Griddata()
    {
        string _sqlQuery = string.Empty;
        string[] AllQueryParam = new string[1];
        BLL objbll = new BLL();
        DataRow dr = dtdata.NewRow();

        dtdata.Columns.Add("INSCODE");
        dtdata.Columns.Add("BRCODE");
        dtdata.Columns.Add("SEM01");
        dtdata.Columns.Add("SEM02");
        dtdata.Columns.Add("SEM03");
        dtdata.Columns.Add("SEM04");
        dtdata.Columns.Add("SEM05");
        dtdata.Columns.Add("SEM06");


        //Institute
        if (Drpins.SelectedValue == "ALL") { _sqlQuery = "SELECT DISTINCT INSCODE,INSNAME FROM INSLOGIN WHERE INSCODE!='0' ORDER BY INSCODE ASC"; }
        else { _sqlQuery = "SELECT * FROM INSLOGIN WHERE INSCODE='" + Drpins.SelectedValue + "'"; }
        AllQueryParam[0] = _sqlQuery;
        DataTable dtins = new DataTable();
        objbll.QUERYBLL(ref dtins, AllQueryParam);
        if (dtins.Rows.Count == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No Institute Found.');", true); return; }
        for (int i = 0; i < dtins.Rows.Count; i++)
        {
            string INSCODE = dtins.Rows[i]["INSCODE"].ToString();
            //Branch
            if (Drpbranch.SelectedValue == "ALL") { _sqlQuery = "SELECT DISTINCT BRCODE,BRNAME FROM BRLOGIN WHERE BRCODE!='0' AND INSCODE='" + INSCODE + "' ORDER BY BRCODE ASC"; }
            else { _sqlQuery = "SELECT * FROM BRLOGIN WHERE INSCODE='" + INSCODE + "' AND BRCODE='" + Drpbranch.SelectedValue + "' ORDER BY BRCODE ASC"; }
            AllQueryParam[0] = _sqlQuery;
            DataTable dtbr = new DataTable();
            objbll.QUERYBLL(ref dtbr, AllQueryParam);
            for (int b = 0; b < dtbr.Rows.Count; b++)
            {
                string BRCODE = dtbr.Rows[b]["BRCODE"].ToString();

                string _sqlQuery1 = "SELECT COUNT(*) AS CNT FROM REGISTRATION WHERE SEM='01' AND SEMCOM1='1' AND REGPVT='R' AND INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND STAT='A'";
                string _sqlQuery2 = "SELECT COUNT(*) AS CNT FROM REGISTRATION WHERE SEM='02' AND SEMCOM2='1' AND REGPVT='R' AND INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND STAT='A'";
                string _sqlQuery3 = "SELECT COUNT(*) AS CNT FROM REGISTRATION WHERE SEM='03' AND SEMCOM3='1' AND REGPVT='R' AND INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND STAT='A'";
                string _sqlQuery4 = "SELECT COUNT(*) AS CNT FROM REGISTRATION WHERE SEM='04' AND SEMCOM4='1' AND REGPVT='R' AND INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND STAT='A'";
                string _sqlQuery5 = "SELECT COUNT(*) AS CNT FROM REGISTRATION WHERE SEM='05' AND SEMCOM5='1' AND REGPVT='R' AND INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND STAT='A'";
                string _sqlQuery6 = "SELECT COUNT(*) AS CNT FROM REGISTRATION WHERE SEM='06' AND SEMCOM6='1' AND REGPVT='R' AND INSCODE='" + INSCODE + "' AND BRCODE='" + BRCODE + "' AND STAT='A'";

                _sqlQuery = "SELECT (" + _sqlQuery1 + ") AS CON1,(" + _sqlQuery2 + ") AS CON2,(" + _sqlQuery3 + ") AS CON3,(" + _sqlQuery4 + ") AS CON4,(" + _sqlQuery5 + ") AS CON5,(" + _sqlQuery6 + ") AS CON6";
                string CNT = COUNT(_sqlQuery);
                string[] SPL1ST = CNT.Split('|');
                dr["INSCODE"] = INSCODE;
                dr["BRCODE"] = BRCODE;
                dr["SEM01"] = SPL1ST[0].ToString();
                dr["SEM02"] = SPL1ST[1].ToString();
                dr["SEM03"] = SPL1ST[2].ToString();
                dr["SEM04"] = SPL1ST[3].ToString();
                dr["SEM05"] = SPL1ST[4].ToString();
                dr["SEM06"] = SPL1ST[5].ToString();
                dtdata.Rows.Add(dr);
                dr = dtdata.NewRow();
            }
        }
        Grdedit.DataSource = dtdata;
        Grdedit.DataBind();
    }
    protected void Drpins_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("~/Admin/Adminlogin.aspx", false); }
            if (Drpins.SelectedIndex > 0)
            {
                string _sqlQueryreg = string.Empty;
                string[] AllQueryParamreg = new string[1];
                BLL objbllreg = new BLL();
                //Get Branch
                DataTable dtins = new DataTable();
                if (Drpins.SelectedValue == "ALL") { _sqlQueryreg = "select DISTINCT BRCODE,BRNAME from BRLOGIN order by BRCODE asc"; }
                else { _sqlQueryreg = "select * from BRLOGIN where INSCODE='" + Drpins.SelectedValue + "' order by BRCODE asc"; }
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtins, AllQueryParamreg);
                if (dtins.Rows.Count > 0)
                {
                    DataRow dr = dtins.NewRow();
                    dr["BRCODE"] = "ALL";
                    dr["BRNAME"] = "ALL";
                    dtins.Rows.Add(dr);

                    Drpbranch.DataValueField = dtins.Columns["BRCODE"].ToString().Trim();
                    Drpbranch.DataTextField = dtins.Columns["BRNAME"].ToString().Trim();
                    Drpbranch.DataSource = dtins;
                    Drpbranch.DataBind();

                    if (Drpbranch.Items.Count > 0) { Drpbranch.SelectedIndex = 0; }
                }
                else { Response.Redirect("~/Error.aspx", true); }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    private string COUNT(string Query)
    {
        string CNT = string.Empty;
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        AllQueryParam[0] = Query;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        CNT = dt.Rows[0]["CON1"].ToString().Trim() + "|" + dt.Rows[0]["CON2"].ToString().Trim() + "|" + dt.Rows[0]["CON3"].ToString().Trim() + "|" + dt.Rows[0]["CON4"].ToString().Trim() + "|" + dt.Rows[0]["CON5"].ToString().Trim() + "|" + dt.Rows[0]["CON6"].ToString().Trim();
        return CNT;
    }
}