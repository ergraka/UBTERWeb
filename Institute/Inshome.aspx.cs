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
public partial class Inshome : System.Web.UI.Page
{
    public string cname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null && Session["UTYPE"] != null)
            {
                if (!IsPostBack)
                {
                    bindsourcedata();
                }
            }
            else { Response.Redirect("Inslogin.aspx", false); }
        }
        catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }
    }
    private void bindsourcedata()
    {
        if (Session["INSCODE"] != null)
        {
            stat();
        }
        else { Response.Redirect("Inslogin.aspx", false); }
    }
    private void stat()
    {

        string _sqlQuery = string.Empty;
        string _sqlQuery1 = string.Empty;
        string _sqlQuery2 = string.Empty;

        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        string[] spl1 = Session["INSCODE"].ToString().Split('|');
        string inscode = spl1[0].ToString();

        _sqlQuery = "select Count(*) as CON from REGISTRATION where STAT='A' AND INSCODE='" + inscode + "'";
        _sqlQuery1 = "select Count(*) as CON from REGISTRATION where STAT='A' AND SEMCOM1='1' and INSCODE='" + inscode + "'";
        _sqlQuery2 = "select Count(*) as CON from REGISTRATION where STAT='A' AND SEMCOM1 is NUll and INSCODE='" + inscode + "'";

        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        Lnkall.Text = dt.Rows[0]["CON"].ToString() + " - Click here to view.";

        DataTable dt1 = new DataTable();
        string[] AllQueryParam1 = new string[1];
        AllQueryParam1[0] = _sqlQuery1;
        BLL objbllLogin1 = new BLL();
        objbllLogin1.QUERYBLL(ref dt1, AllQueryParam1);
        Lnkapproved.Text = dt1.Rows[0]["CON"].ToString() + " - Click here to view.";

        DataTable dt2 = new DataTable();
        string[] AllQueryParam2 = new string[1];
        AllQueryParam2[0] = _sqlQuery2;
        BLL objbllLogin2 = new BLL();
        objbllLogin2.QUERYBLL(ref dt2, AllQueryParam2);
        Lnknapproved.Text = dt2.Rows[0]["CON"].ToString() + " - Click here to View.";

        //FOR INSLOGIN
        if (Session["UTYPE"].ToString() == "I")
        {
            string _sqlQueryreg = string.Empty;
            DataTable dtreg = new DataTable();
            string[] AllQueryParamreg = new string[1];
            _sqlQueryreg = "select distinct BRCODE,BRNAME from BRLOGIN where INSCODE='" + inscode + "' order by BRCODE asc";
            AllQueryParamreg[0] = _sqlQueryreg;
            BLL objbllreg = new BLL();
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count > 0)
            {
                //FOR BRANCH PASSWORD
                Drpbranch.DataValueField = dtreg.Columns["BRCODE"].ToString().Trim();
                Drpbranch.DataTextField = dtreg.Columns["BRNAME"].ToString().Trim();
                Drpbranch.DataSource = dtreg;
                Drpbranch.DataBind();
                if (Drpbranch.Items.Count > 0) { Drpbranch.SelectedIndex = 0; }
                //FOR BRANCH CHANGING CURRENT
                //Drpcrrbranch.DataValueField = dtreg.Columns["BRCODE"].ToString().Trim();
                //Drpcrrbranch.DataTextField = dtreg.Columns["BRNAME"].ToString().Trim();
                //Drpcrrbranch.DataSource = dtreg;
                //Drpcrrbranch.DataBind();
                //if (Drpcrrbranch.Items.Count > 0) { Drpcrrbranch.SelectedIndex = 0; }
                //FOR BRANCH CHANGING NEW
                //Drpnewbranch.DataValueField = dtreg.Columns["BRCODE"].ToString().Trim();
                //Drpnewbranch.DataTextField = dtreg.Columns["BRNAME"].ToString().Trim();
                //Drpnewbranch.DataSource = dtreg;
                //Drpnewbranch.DataBind();
                //if (Drpnewbranch.Items.Count > 0) { Drpnewbranch.SelectedIndex = 0; }
                //BRANCH ACCEPTS
                //Drpbranchaccept.DataValueField = dtreg.Columns["BRCODE"].ToString().Trim();
                //Drpbranchaccept.DataTextField = dtreg.Columns["BRNAME"].ToString().Trim();
                //Drpbranchaccept.DataSource = dtreg;
                //Drpbranchaccept.DataBind();
                //if (Drpbranchaccept.Items.Count > 0) { Drpbranchaccept.SelectedIndex = 0; }
            }
            //For Change Institute
            DataTable dtins = new DataTable();
            _sqlQueryreg = "select distinct INSCODE,INSNAME from INSLOGIN where INSCODE!='" + inscode + "' order by INSCODE asc";
            AllQueryParamreg[0] = _sqlQueryreg;
            objbllreg.QUERYBLL(ref dtins, AllQueryParamreg);
            if (dtins.Rows.Count > 0)
            {
                //FOR BRANCH CHANGING NEW
                //Drpnewins.DataValueField = dtins.Columns["INSCODE"].ToString().Trim();
                //Drpnewins.DataTextField = dtins.Columns["INSNAME"].ToString().Trim();
                //Drpnewins.DataSource = dtins;
                //Drpnewins.DataBind();
                //if (Drpnewins.Items.Count > 0) { Drpnewins.SelectedIndex = 0; }
            }
            //For Change Institute
            //string[] INSSPL = Session["INSCODE"].ToString().Split('|');
            //string INSCODE = INSSPL[0].ToString();
            //DataTable dtinschange = new DataTable();
            //_sqlQueryreg = "SELECT * FROM REGISTRATION WHERE INSOLD='" + INSCODE + "' OR INSNEW='" + INSCODE + "'";
            //AllQueryParamreg[0] = _sqlQueryreg;
            //objbllreg.QUERYBLL(ref dtinschange, AllQueryParamreg);
            //if (dtinschange.Rows.Count > 0)
            //{
            //    Grdaproved.DataSource = dtinschange;
            //    Grdaproved.DataBind();
            //}
            //else { Lblaccept.Text = "No Records Found."; }
        }
    }
    protected void Btnchange_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null && Session["UTYPE"] != null)
            {
                if (Txtpassword.Text.Length < 8 || Drpbranch.SelectedIndex == 0 || Txtemail.Text == "") { ltrlMessage.Text = "Please Select OR Fill All required Details."; }
                else
                {
                    string _sqlQuery = string.Empty;
                    BLL objbllonlyquery = new BLL();
                    string[] spl1 = Session["INSCODE"].ToString().Split('|');
                    string inscode = spl1[0].ToString();
                    _sqlQuery = "update BRLOGIN set PASSWORD='" + Txtpassword.Text + "',EMAIL='" + Txtemail.Text.ToUpper() + "' where INSCODE='" + inscode + "' and BRCODE='" + Drpbranch.SelectedValue + "'";
                    string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                    if (result == "1-1")
                    {

                        _sendMail();
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Password changed successfully, and also send to entered Email Address.');", true);
                        ltrlMessage.Text = "Password Change Successfully for-" + Drpbranch.SelectedItem.ToString();
                    }
                    else { ltrlMessage.Text = "Please try after some times."; }
                }
            }
            else { Response.Redirect("Inslogin.aspx", false); }
        }
        catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }

    }
    protected void Drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null && Session["UTYPE"] != null)
            {
                string _sqlQuery = string.Empty;
                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                string[] spl1 = Session["INSCODE"].ToString().Split('|');
                string inscode = spl1[0].ToString();
                _sqlQuery = "select * from BRLOGIN where INSCODE='" + inscode + "' and BRCODE='" + Drpbranch.SelectedValue + "'";
                AllQueryParam[0] = _sqlQuery;
                BLL objbllLogin = new BLL();
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count > 0) { Txtpassword.Text = dt.Rows[0]["PASSWORD"].ToString(); Txtemail.Text = dt.Rows[0]["EMAIL"].ToString(); }
            }
            else { Response.Redirect("Inslogin.aspx", false); }
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
    
    private void _sendMail()
    {
        System.Text.StringBuilder sr = new System.Text.StringBuilder();
        try
        {
            sr.Append("<html>");
            sr.Append("<head>");
            sr.Append("<body>");
            sr.Append(" <div>");
            sr.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" runat=\"server\">");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" colspan=3>");
            sr.Append("<br/>Institute Name, Branch Name and Password are given below :- <br/><br/>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" >");
            sr.Append("<b>Institute Name : </b>");
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append(Session["INSCODE"].ToString());
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append("</td>");
            sr.Append("</tr>");


            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" >");
            sr.Append("<b>Branch Name : </b>");
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append(Drpbranch.SelectedItem.ToString());
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" >");
            sr.Append("<b>Password : </b>");
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append(Txtpassword.Text);
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\">");
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td style=color:#FF0000; width=\"30%\" align=\"left\" colspan=3>");
            sr.Append("<br/><br/>this is an automatically generated email. please do not reply to this email address.");
            sr.Append("</td>");
            sr.Append("</tr>");


            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" colspan=2>");
            sr.Append("<b><br/>Thanks</b></td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" colspan=2>");
            sr.Append("UBTER TEAM</td>");
            sr.Append("</tr>");

            sr.Append("</table>");
            sr.Append("</div>");
            sr.Append("</body>");
            sr.Append("</head>");
            sr.Append("</html>");

            MailMessage objmsg = new MailMessage("noreply@regapplication.in", Txtemail.Text);
            objmsg.To.Add(Txtemail.Text);
            objmsg.From = new MailAddress("noreply@regapplication.in");
            objmsg.Subject = "UBTER:Change Branch Password For-" + Drpbranch.SelectedItem.ToString();
            objmsg.Body = sr.ToString();
            objmsg.Priority = MailPriority.High;
            objmsg.IsBodyHtml = true;
            SmtpClient smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "dedrelay.secureserver.net";//On Server

                //smtp.Host = "relay-hosting.secureserver.net";//On Server
                //smtp.Host = "smtpout.secureserver.net";//On Local
                smtp.Port = 25;
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("noreply@regapplication.in", "srnDATA@2004");
                smtp.Timeout = 50000;
            }
            smtp.Send(objmsg);
        }
        catch (Exception ex) { }
    }
    //BRANCH CHANGE
    protected void Btnbrchange_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    if (Session["INSCODE"] != null)
        //    {

        //        string[] spl1 = Session["INSCODE"].ToString().Split('|');
        //        string inscode = spl1[0].ToString();
        //        string BRCODE = Drpnewbranch.SelectedValue.ToString();
        //        string BRNAME = Drpnewbranch.SelectedItem.ToString();
        //        string[] SPLBR = BRCODE.Split('-');
        //        string SHIFT = SPLBR[1].ToString();
        //        string _sqlQuery = string.Empty;
        //        DataTable dt = new DataTable();
        //        string[] AllQueryParam = new string[1];
        //        BLL objbll = new BLL();
        //        _sqlQuery = "select * from REGISTRATION where CANDIDATEID='" + Txtregno.Text + "' AND INSCODE='" + inscode + "' AND BRNAME='" + Drpcrrbranch.SelectedItem.ToString() + "'";
        //        AllQueryParam[0] = _sqlQuery;
        //        objbll.QUERYBLL(ref dt, AllQueryParam);
        //        if (dt.Rows.Count == 0) { Lblbrchange.Text = "REGISTRATION NUMBER NOT FOUND FOR CURRENT INSTITUTE AND BRANCH."; return; }
        //        for (int i = 1; i <= 4; i++)
        //        {
        //            string TBL = string.Empty;
        //            if (i == 1) { TBL = "REGISTRATION"; }
        //            else if (i == 2) { TBL = "BACKP"; }
        //            else if (i == 3) { TBL = "REEVA"; }
        //            else if (i == 4) { TBL = "SCRU"; }
        //            _sqlQuery = "update " + TBL + " set BRCODE='" + BRCODE + "',BRNAME='" + BRNAME + "',SHIFT='" + SHIFT + "' where CANDIDATEID='" + Txtregno.Text + "'";
        //            string result = objbll.ONLYQUERYBLL(_sqlQuery);
        //            if (result == "1-1") { Lblbrchange.Text = Txtregno.Text + "-Branch changed successfully"; }
        //        }
        //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Branch changed successfully.');", true);
        //    }
        //    else { Response.Redirect("Inslogin.aspx", false); }
        //}
        //catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }

    }
    //INSTITUTE CHNAGE
    protected void Btninschange_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    if (Session["INSCODE"] != null)
        //    {
        //        string[] spl1 = Session["INSCODE"].ToString().Split('|');
        //        string inscode = spl1[0].ToString();
        //        string inscodenew = Drpnewins.SelectedValue.ToString();
        //        string _sqlQuery = string.Empty;
        //        DataTable dt = new DataTable();
        //        string[] AllQueryParam = new string[1];
        //        BLL objbll = new BLL();
        //        _sqlQuery = "select * from REGISTRATION where CANDIDATEID='" + Txtregnoins.Text + "' AND INSCODE='" + inscode + "'";
        //        AllQueryParam[0] = _sqlQuery;
        //        objbll.QUERYBLL(ref dt, AllQueryParam);
        //        if (dt.Rows.Count == 0) { Lblins.Text = "REGISTRATION NUMBER NOT FOUND FOR CURRENT INSTITUTE."; return; }
        //        for (int i = 1; i <= 1; i++)
        //        {
        //            string TBL = string.Empty;
        //            if (i == 1) { TBL = "REGISTRATION"; }
        //            _sqlQuery = "update " + TBL + " set INSOLD='" + inscode + "', INSNEW='" + inscodenew + "' where CANDIDATEID='" + Txtregnoins.Text + "'";
        //            string result = objbll.ONLYQUERYBLL(_sqlQuery);
        //            if (result == "1-1") { Lblins.Text = "Institute Changing Proceed Successfully, Please visit new Intitute for complete changing process."; }
        //        }
        //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Institute Changing Proceed Successfully, Please visit new Intitute for complete changing process.');", true);
        //        Response.Redirect(Request.RawUrl);
        //    }
        //    else { Response.Redirect("Inslogin.aspx", false); }
        //}
        //catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }

    }
    protected void Btnaccept_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    if (Session["INSCODE"] != null)
        //    {
        //        if (Drpbranchaccept.SelectedIndex == 0) { Lblaccept.Text = "Please select Branch."; return; }
        //        string[] spl1 = Session["INSCODE"].ToString().Split('|');
        //        string inscode = spl1[0].ToString();
        //        string insname = spl1[1].ToString();
        //        string _sqlQuery = string.Empty;
        //        DataTable dt = new DataTable();
        //        string[] AllQueryParam = new string[1];
        //        BLL objbll = new BLL();
        //        foreach (GridViewRow gvrow in Grdaproved.Rows)
        //        {
        //            CheckBox chk = (CheckBox)gvrow.FindControl("CbSelect");
        //            if (chk != null & chk.Checked)
        //            {
        //                for (int i = 1; i <= 4; i++)
        //                {
        //                    string TBL = string.Empty;
        //                    if (i == 1) { TBL = "REGISTRATION"; }
        //                    else if (i == 2) { TBL = "BACKP"; }
        //                    else if (i == 3) { TBL = "REEVA"; }
        //                    else if (i == 4) { TBL = "SCRU"; }
        //                    if (i == 1) { _sqlQuery = "update " + TBL + " SET BRCODE='" + Drpbranchaccept.SelectedValue.ToString() + "',BRNAME='" + Drpbranchaccept.SelectedItem.ToString() + "', INSCODE='" + inscode + "',INSNAME='" + insname + "',INSOLD=NULL,INSNEW=NULL where CANDIDATEID='" + chk.Text + "'"; }
        //                    else
        //                    {
        //                        _sqlQuery = "update " + TBL + " SET BRCODE='" + Drpbranchaccept.SelectedValue.ToString() + "',BRNAME='" + Drpbranchaccept.SelectedItem.ToString() + "', INSCODE='" + inscode + "',INSNAME='" + insname + "' where CANDIDATEID='" + chk.Text + "'";
        //                    }
        //                    string result = objbll.ONLYQUERYBLL(_sqlQuery);
        //                    if (result == "1-1") { Lblaccept.Text = "Institute changed successfully"; }
        //                }
        //            }
        //        }
        //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Institute changed successfully.');", true);
        //        Response.Redirect(Request.RawUrl);
        //    }
        //    else { Response.Redirect("Inslogin.aspx", false); }
        //}
        //catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue process can not be complete, Please try after some time !');", true); }

    }
}
