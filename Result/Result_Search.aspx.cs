using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _Examination;
using System.Data;
public partial class Result_Result_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Grddata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (IsPostBack)
            {
                LblMessage.Text = "";
                Grddata.PageIndex = e.NewPageIndex;
                bindsourcedata();
            }
        }
        catch (Exception ex) { LblMessage.Text = "Server Busy, Please try after some time !"; }
    }
    private void bindsourcedata()
    {
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        string _sqlQuery = string.Empty;
        if (Rdoroll.Checked == true) { _sqlQuery = "select * from REGISTRATION where CANDIDATEID='" + Txtroll.Text + "'"; }
        else if (Rdoname.Checked == true)
        {
            string CNAME = Txtcname.Text;
            string DOB = Drpday.Text + "/" + Drpmonth.Text + "/" + Drpyear.Text;
            _sqlQuery = "select * from REGISTRATION where CNAME LIKE '%" + Txtcname.Text + "%' and DOB='" + DOB + "'";
        }
        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count > 0)
        {
            LblMessage.Text = "";
            Grddata.DataSource = dt;
            Grddata.DataBind();
        }
        else
        {
            Grddata.DataSource = null;
            Grddata.DataBind();
            LblMessage.Text = "NO RECORDS FOUND !";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('NO RECORDS FOUND !');", true);
        }
    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            bindsourcedata();
        }
        catch (Exception ex) { LblMessage.Text = "Server Busy, Please try after some time !"; }

    }
}