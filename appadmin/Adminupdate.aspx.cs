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
public partial class Adminupdate : System.Web.UI.Page
{
    public string cname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] != null)
            {
                if (!IsPostBack)
                {
                    bindsourcedata();
                }
            }
            else { Response.Redirect("Adminlogin.aspx", false); }
        }
        catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }
    }
    private void bindsourcedata()
    {
        if (Session["ADMIN"] != null)
        {
            stat();
        }
        else { Response.Redirect("Adminlogin.aspx", false); }
    }
    private void stat()
    {

        string _sqlQuery = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        _sqlQuery = "select distinct BRCODE,BRNAME from BRLOGIN order by BRCODE asc";
        AllQueryParamreg[0] = _sqlQuery;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0)
        {
            //FOR BRANCH CHANGING CURRENT
            Drpcrrbranch.DataValueField = dtreg.Columns["BRCODE"].ToString().Trim();
            Drpcrrbranch.DataTextField = dtreg.Columns["BRNAME"].ToString().Trim();
            Drpcrrbranch.DataSource = dtreg;
            Drpcrrbranch.DataBind();
            if (Drpcrrbranch.Items.Count > 0) { Drpcrrbranch.SelectedIndex = 0; }
            //FOR BRANCH CHANGING NEW
            Drpnewbranch.DataValueField = dtreg.Columns["BRCODE"].ToString().Trim();
            Drpnewbranch.DataTextField = dtreg.Columns["BRNAME"].ToString().Trim();
            Drpnewbranch.DataSource = dtreg;
            Drpnewbranch.DataBind();
            if (Drpnewbranch.Items.Count > 0) { Drpnewbranch.SelectedIndex = 0; }
        }
        //For Change Institute
        DataTable dtins = new DataTable();
        _sqlQuery = "select distinct INSCODE,INSNAME from INSLOGIN order by INSCODE asc";
        AllQueryParamreg[0] = _sqlQuery;
        objbllreg.QUERYBLL(ref dtins, AllQueryParamreg);
        if (dtins.Rows.Count > 0)
        {
            //FOR INSTITUTE CHANGING NEW
            Drpoldins.DataValueField = dtins.Columns["INSCODE"].ToString().Trim();
            Drpoldins.DataTextField = dtins.Columns["INSNAME"].ToString().Trim();
            Drpoldins.DataSource = dtins;
            Drpoldins.DataBind();
            Drpnewins.DataValueField = dtins.Columns["INSCODE"].ToString().Trim();
            Drpnewins.DataTextField = dtins.Columns["INSNAME"].ToString().Trim();
            Drpnewins.DataSource = dtins;
            Drpnewins.DataBind();
            if (Drpnewins.Items.Count > 0) { Drpnewins.SelectedIndex = 0; }
        }
        //For Change User Password
        DataTable dtuser = new DataTable();
        _sqlQuery = "SELECT * FROM ADMINLOGIN ORDER BY USERID";
        AllQueryParamreg[0] = _sqlQuery;
        objbllreg.QUERYBLL(ref dtuser, AllQueryParamreg);
        if (dtuser.Rows.Count > 0)
        {
            //FOR BRANCH CHANGING NEW
            Drpuserid.DataValueField = dtuser.Columns["USERID"].ToString().Trim();
            Drpuserid.DataTextField = dtuser.Columns["USERID"].ToString().Trim();
            Drpuserid.DataSource = dtuser;
            Drpuserid.DataBind();
            if (Drpuserid.Items.Count > 0) { Drpuserid.SelectedIndex = 0; }
        }
    }
    protected void Btnchange_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] != null)
            {
                if (Txtpassword.Text.Length < 8 || Drpuserid.SelectedIndex == 0) { ltrlMessage.Text = "Please Select OR Fill All required Details."; }
                else
                {
                    string _sqlQuery = string.Empty;
                    BLL objbllonlyquery = new BLL();
                    _sqlQuery = "update ADMINLOGIN set PASSWORD='" + Txtpassword.Text + "' where USERID='" + Drpuserid.SelectedValue.ToString() + "'";
                    string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                    if (result == "1-1")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Password changed successfully.');", true);
                        ltrlMessage.Text = "Password Change Successfully for-" + Drpuserid.SelectedItem.ToString();
                    }
                    else { ltrlMessage.Text = "Please try after some times."; }
                }
            }
            else { Response.Redirect("Adminlogin.aspx", false); }
        }
        catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }

    }
    protected void Drpuserid_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] != null)
            {
                if (Drpuserid.SelectedIndex > 0)
                {
                    string _sqlQuery = string.Empty;
                    DataTable dt = new DataTable();
                    string[] AllQueryParam = new string[1];
                    _sqlQuery = "select * from ADMINLOGIN where USERID='" + Drpuserid.SelectedValue.ToString() + "'";
                    AllQueryParam[0] = _sqlQuery;
                    BLL objbllLogin = new BLL();
                    objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                    if (dt.Rows.Count > 0) { Txtpassword.Text = dt.Rows[0]["PASSWORD"].ToString(); }
                }
                else { Txtpassword.Text = ""; }
            }
            else { Response.Redirect("Adminlogin.aspx", false); }
        }
        catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }
    }
    protected void Lnkall_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Stulist.aspx?TYP=ALL|ALL", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
    protected void Lnkapproved_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Stulist.aspx?TYP=APP|ALL", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
    protected void Lnknapproved_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Stulist.aspx?TYP=NAPP|ALL", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
    //INSTITUTE CHNAGE
    protected void Btninschange_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] != null)
            {
                string inscodeold = Drpoldins.SelectedValue.ToString();
                string inscodenew = Drpnewins.SelectedValue.ToString();
                string _sqlQuery = string.Empty;
                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                BLL objbll = new BLL();
                _sqlQuery = "select * from REGISTRATION where (CANDIDATEID='" + Txtregnoins.Text + "' OR ROLL='" + Txtregnoins.Text + "') AND INSCODE='" + inscodeold + "'";
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count == 0) { Lblins.Text = "REGISTRATION NUMBER NOT FOUND FOR CURRENT INSTITUTE."; return; }
                for (int i = 1; i <= 4; i++)
                {
                    string TBL = string.Empty;
                    if (i == 1) { TBL = "REGISTRATION"; }
                    else if (i == 2) { TBL = "BACKP"; }
                    else if (i == 3) { TBL = "SCRU"; }
                    else if (i == 4) { TBL = "REEVA"; }
                    _sqlQuery = "update " + TBL + " set INSCODE='" + inscodenew + "', INSNAME='" + Drpnewins.SelectedItem.ToString() + "' where (CANDIDATEID='" + Txtregnoins.Text + "' OR ROLL='" + Txtregnoins.Text + "')";
                    string result = objbll.ONLYQUERYBLL(_sqlQuery);
                    if (result == "1-1") { Lblins.Text = "Institute Changed Successfully."; }
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Institute Changed Successfully.');", true);
                Txtregnoins.Text = "";
                Drpoldins.SelectedIndex = 0;
                Drpnewins.SelectedIndex = 0;
            }
            else { Response.Redirect("Adminlogin.aspx", false); }
        }
        catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }
    }
    //BRANCH CHANGED
    protected void Btnbrchange_Click(object sender, EventArgs e)
    {
        //Branch Change
        try
        {
            if (Session["ADMIN"] != null)
            {
                string Brcodeold = Drpcrrbranch.SelectedValue.ToString();
                string Brcodenew = Drpnewbranch.SelectedValue.ToString();
                string INSCODE = string.Empty;
                string SHIFT = string.Empty;

                string[] SPLSH = Brcodenew.Split('-');
                SHIFT = SPLSH[1].ToString();

                string _sqlQuery = string.Empty;
                string[] AllQueryParam = new string[1];
                BLL objbll = new BLL();

                //Check Student
                DataTable dt = new DataTable();
                _sqlQuery = "select * from REGISTRATION where (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "') AND BRCODE='" + Brcodeold + "'";
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count == 0) { Lblbrchange.Text = "REGISTRATION NUMBER NOT FOUND FOR CURRENT BRANCH."; return; }
                else { INSCODE = dt.Rows[0]["INSCODE"].ToString(); }
                //Check New Branch in Institute
                DataTable dtins = new DataTable();
                _sqlQuery = "select * from BRLOGIN where INSCODE='" + INSCODE + "' AND BRCODE='" + Brcodenew + "'";
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dtins, AllQueryParam);
                if (dtins.Rows.Count == 0) { Lblbrchange.Text = "New Branch Not Found in Institute-" + INSCODE; return; }

                for (int i = 1; i <= 4; i++)
                {
                    string TBL = string.Empty;
                    if (i == 1) { TBL = "REGISTRATION"; }
                    else if (i == 2) { TBL = "BACKP"; }
                    else if (i == 3) { TBL = "SCRU"; }
                    else if (i == 4) { TBL = "REEVA"; }
                    _sqlQuery = "update " + TBL + " set BRCODE='" + Brcodenew + "', BRNAME='" + Drpnewbranch.SelectedItem.ToString() + "',SHIFT='" + SHIFT + "' where (CANDIDATEID='" + Txtregno.Text + "' OR ROLL='" + Txtregno.Text + "')";
                    string result = objbll.ONLYQUERYBLL(_sqlQuery);
                    if (result == "1-1") { Lblbrchange.Text = "Branch Changed Successfully."; }
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Branch Changed Successfully.');", true);
                Txtregno.Text = "";
                Drpcrrbranch.SelectedIndex = 0;
                Drpnewbranch.SelectedIndex = 0;
            }
            else { Response.Redirect("Adminlogin.aspx", false); }
        }
        catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }
    }
    //SEMESTERE CHANGE
    protected void Btnsemchange_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] != null)
            {
                string Semold = Drpoldsem.SelectedValue.ToString();
                string Semnew = Drpnewsem.SelectedValue.ToString();
                string _sqlQuery = string.Empty;
                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                BLL objbll = new BLL();
                _sqlQuery = "select * from REGISTRATION where (CANDIDATEID='" + Txtregsem.Text + "' OR ROLL='" + Txtregsem.Text + "') AND SEM='" + Semold + "'";
                AllQueryParam[0] = _sqlQuery;
                objbll.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count == 0) { Lblsem.Text = "REGISTRATION NUMBER NOT FOUND FOR CURRENT SEM."; return; }
                for (int i = 1; i <= 4; i++)
                {
                    string TBL = string.Empty;
                    if (i == 1) { TBL = "REGISTRATION"; }
                    else if (i == 2) { TBL = "BACKP"; }
                    else if (i == 3) { TBL = "SCRU"; }
                    else if (i == 4) { TBL = "REEVA"; }
                    _sqlQuery = "UPDATE " + TBL + " SET SEM='" + Semnew + "' WHERE (CANDIDATEID='" + Txtregsem.Text + "' OR ROLL='" + Txtregsem.Text + "')";
                    string result = objbll.ONLYQUERYBLL(_sqlQuery);
                    if (result == "1-1")
                    { Lblsem.Text = "Sem Changed Successfully."; }
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Semester Changed Successfully.');", true);
                Txtregsem.Text = "";
                Drpoldsem.SelectedIndex = 0;
                Drpnewsem.SelectedIndex = 0;
            }
            else { Response.Redirect("Adminlogin.aspx", false); }
        }
        catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }
    }
}
