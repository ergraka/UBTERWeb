using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using _Examination;
public partial class List_Sess : System.Web.UI.Page
{
    public string DATA = string.Empty;
    public string SUB1 = string.Empty;
    public string SUB2 = string.Empty;
    public string SUB3 = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["INSCODE"] != null && Session["BRCODE"] != null)
                {

                    string SEM = string.Empty;
                    if (Request.QueryString["TYP"] != null) { SEM = Request.QueryString["TYP"].ToString().Trim(); }
                    else { Response.Redirect("~/Error.aspx", true); }
                    string[] splins = Session["INSCODE"].ToString().Split('|');
                    Lblins.Text = splins[1].ToString();
                    string[] splbr = Session["BRCODE"].ToString().Split('|');
                    Lblbranch.Text = splbr[1].ToString();
                    string[] BRSPL = splbr[0].ToString().Split('-');
                    //***************************************************************************GET SUBJECT
                    string _sqlQueryreg = string.Empty;
                    DataTable dtreg = new DataTable();
                    string[] AllQueryParamreg = new string[1];
                    _sqlQueryreg = "select * from SUBSESS where SEM='" + SEM + "' and BRCODE='" + BRSPL[0].ToString() + "' order by SUBJECT asc";
                    AllQueryParamreg[0] = _sqlQueryreg;
                    BLL objbllreg = new BLL();
                    objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                    if (dtreg.Rows.Count > 0)
                    {
                        SUB1 = dtreg.Rows[0]["SUBJECT"].ToString().Trim() + "</br>( MAX-" + dtreg.Rows[0]["SUBMAX"].ToString().Trim() + ", MIN-" + dtreg.Rows[0]["SUBMIN"].ToString().Trim() + " )";
                        SUB2 = dtreg.Rows[1]["SUBJECT"].ToString().Trim() + "</br>( MAX-" + dtreg.Rows[1]["SUBMAX"].ToString().Trim() + ", MIN-" + dtreg.Rows[1]["SUBMIN"].ToString().Trim() + " )";
                        SUB3 = dtreg.Rows[2]["SUBJECT"].ToString().Trim() + "</br>( MAX-" + dtreg.Rows[2]["SUBMAX"].ToString().Trim() + ", MIN-" + dtreg.Rows[2]["SUBMIN"].ToString().Trim() + " )";
                    }
                    else { LblMessage.Text = "No Subject Found."; }
                    Lblsem.Text = SEM;
                    Getdata();
                    Lblshift.Text = BRSPL[1].ToString();
                }
                else { Response.Redirect("~/Institute/Inslogin.aspx", false); }
            }
        }
        catch (Exception ex)
        {
            LblMessage.Text = "Please try after some time !";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The Login can not complete. Please try after some time !');", true);
        }
       
    }
    private void Getdata()
    {
        string CLM = string.Empty;
        string SEM = Lblsem.Text;
        if (SEM == "01") { CLM = "SEMCOM1"; }
        else if (SEM == "02") { CLM = "SEMCOM2"; }
        else if (SEM == "03") { CLM = "SEMCOM3"; }
        else if (SEM == "04") { CLM = "SEMCOM4"; }
        else if (SEM == "05") { CLM = "SEMCOM5"; }
        else if (SEM == "06") { CLM = "SEMCOM6"; }
        DATA = "";
        string[] splins = Session["INSCODE"].ToString().Split('|');
        string[] splbr = Session["BRCODE"].ToString().Split('|');
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        _sqlQueryreg = "select * FROM REGISTRATION where INSCODE='" + splins[0].ToString() + "' and BRCODE='" + splbr[0].ToString() + "' and SEM='" + Lblsem.Text + "' AND " + CLM + "='1' AND REGPVT='R' AND STAT='A' order by ROLL asc";
        AllQueryParamreg[0] = _sqlQueryreg;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0)
        {
            for (int i = 0; i < dtreg.Rows.Count; i++)
            {

                string ROLL = dtreg.Rows[i]["ROLL"].ToString().Trim();
                string CNAME = dtreg.Rows[i]["CNAME"].ToString().Trim();
                string FNAME = dtreg.Rows[i]["FNAME"].ToString().Trim();
                string DOB = dtreg.Rows[i]["DOB"].ToString().Trim();

                DATA = DATA + ("<tr><td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\">&nbsp;<b>" + ROLL + "</b><br/>&nbsp;" + CNAME + "<br/>&nbsp;" + FNAME + "<br/>&nbsp;" + DOB + "<br/>" + "</td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\"></td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\"></td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"center\"></td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\"></td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\"></td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\"></td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\"></td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000' valign=\"middle\" align=\"left\"></td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000;' valign=\"middle\" align=\"left\"></td></tr>");
            }
        }
        else { LblMessage.Text = "No Records Found."; }
    }
    protected void Imghome_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Session["ID"] != null) { Response.Redirect("~/Student/Stuhome.aspx?mode=home", false); }
            else { Response.Redirect("~/Institute/Inslogin.aspx", false); }
        }
        catch (Exception ex) { }
    }
    protected void Imglogout_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["ID"] = null;
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("~/Institute/Inslogin.aspx", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
}