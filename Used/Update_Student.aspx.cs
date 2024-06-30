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

public partial class Update_Student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Error.aspx", false);
            if (!IsPostBack)
            {
                if (Session["BRCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["BRCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            ltrlMessage.Text = "";
            Lblregno.Text = "";
            Lblroll.Text = "";
            Txtcname.Text = "";
            Txtfname.Text = "";
            Drpday.SelectedIndex = 0;
            Drpmonth.SelectedIndex = 0;
            Drpyear.SelectedIndex = 0;
            Drpgender.SelectedIndex = 0;
            Drpcat.SelectedIndex = 0;
            Drpsubcat.SelectedIndex = 0;
            Txtmono.Text = "";
            Txtemail.Text = "";
            if (Txtid.Text.Trim() != "")
            {
                string[] insspl = Session["INSCODE"].ToString().Split('|');
                string[] brspl = Session["BRCODE"].ToString().Split('|');
                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                string[] AllQueryParamreg = new string[1];
                if (Txtid.Text.Length == 8) { _sqlQueryreg = "select * from REGISTRATION where CANDIDATEID='" + Txtid.Text + "' AND INSCODE='" + insspl[0].ToString() + "' AND BRCODE='" + brspl[0].ToString() + "'"; }
                else if (Txtid.Text.Length == 11) { _sqlQueryreg = "select * from REGISTRATION where ROLL='" + Txtid.Text + "' AND INSCODE='" + insspl[0].ToString() + "' AND BRCODE='" + brspl[0].ToString() + "'"; }
                else { ltrlMessage.Text = "Invalid Roll Number OR Registration Number."; }
                AllQueryParamreg[0] = _sqlQueryreg;
                BLL objbllreg = new BLL();
                objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                if (dtreg.Rows.Count > 0)
                {
                    Lblregno.Text = dtreg.Rows[0]["CANDIDATEID"].ToString();
                    Lblroll.Text = dtreg.Rows[0]["ROLL"].ToString();
                    Txtcname.Text = dtreg.Rows[0]["CNAME"].ToString();
                    Txtfname.Text = dtreg.Rows[0]["FNAME"].ToString();
                    string[] DOB = dtreg.Rows[0]["DOB"].ToString().Split('/');
                    Drpday.SelectedValue = DOB[0].ToString();
                    Drpmonth.SelectedValue = DOB[1].ToString();
                    Drpyear.SelectedValue = DOB[2].ToString();
                    Drpgender.SelectedValue = dtreg.Rows[0]["GENDER"].ToString();
                    Drpcat.SelectedValue = dtreg.Rows[0]["CAT"].ToString();
                    Drpsubcat.SelectedValue = dtreg.Rows[0]["SUBCAT"].ToString();
                    Txtmono.Text = dtreg.Rows[0]["MONO"].ToString();
                    Txtemail.Text = dtreg.Rows[0]["EMAIL"].ToString();
                }
                else { ltrlMessage.Text = "Invalid Roll Number OR Registration Number."; }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["BRCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            ltrlMessage.Text = "";
            string _sqlQuery = string.Empty;
            BLL objbllonlyquery = new BLL();
            string[] insspl = Session["INSCODE"].ToString().Split('|');
            string[] brspl = Session["BRCODE"].ToString().Split('|');
            string DOB = Drpday.SelectedValue.ToString().Trim() + "/" + Drpmonth.SelectedValue.ToString().Trim() + "/" + Drpyear.SelectedValue.ToString().Trim();
            _sqlQuery = "UPDATE REGISTRATION SET CNAME='" + Txtcname.Text.ToUpper() + "',FNAME='" + Txtfname.Text.ToUpper() + "',DOB='" + DOB + "',GENDER='" + Drpgender.SelectedValue + "',CAT='" + Drpcat.SelectedValue + "',SUBCAT='" + Drpsubcat.SelectedValue + "',MONO='" + Txtmono.Text + "',EMAIL='" + Txtemail.Text.ToUpper() + "' WHERE CANDIDATEID='" + Lblregno.Text + "'";
            string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                ltrlMessage.Text = Lblregno.Text + "-UPDATED SUCCESSFULLY.";
                Lblregno.Text = "";
                Lblroll.Text = "";
                Txtcname.Text = "";
                Txtfname.Text = "";
                Drpday.SelectedIndex = 0;
                Drpmonth.SelectedIndex = 0;
                Drpyear.SelectedIndex = 0;
                Drpgender.SelectedIndex = 0;
                Drpcat.SelectedIndex = 0;
                Drpsubcat.SelectedIndex = 0;
                Txtmono.Text = "";
                Txtemail.Text = "";
            }
            else { ltrlMessage.Text = Lblregno.Text + "-UPDATION FAILED."; }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
}