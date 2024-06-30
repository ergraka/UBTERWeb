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

public partial class Insforgetpassword : System.Web.UI.Page
{
    string _name = string.Empty;
    string _password = string.Empty;
    string _EMAL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Label4.Text = GenerateRandomCode();
                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                string[] AllQueryParamreg = new string[1];
                _sqlQueryreg = "select distinct INSCODE,INSNAME from INSLOGIN order by INSCODE asc";
                AllQueryParamreg[0] = _sqlQueryreg;
                BLL objbllreg = new BLL();
                objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                if (dtreg.Rows.Count > 0)
                {
                    Drpins.DataValueField = dtreg.Columns["INSCODE"].ToString().Trim();
                    Drpins.DataTextField = dtreg.Columns["INSNAME"].ToString().Trim();
                    Drpins.DataSource = dtreg;
                    Drpins.DataBind();
                    if (Drpins.Items.Count > 0) { Drpins.SelectedIndex = 0; }
                }
                else { Response.Redirect("~/Error.aspx", true); }

            }
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    private string GenerateRandomCode()
    {
        Random r = new Random();
        string s = "";
        for (int j = 0; j < 6; j++)
        {
            int i = r.Next(3);
            int ch;
            switch (i)
            {
                case 1:
                    ch = r.Next(0, 9);
                    s = s + ch.ToString();
                    break;
                case 2:
                    ch = r.Next(65, 90);
                    s = s + Convert.ToChar(ch).ToString();
                    break;
                case 3:
                    ch = r.Next(97, 122);
                    s = s + Convert.ToChar(ch).ToString();
                    break;
                default:
                    ch = r.Next(97, 122);
                    s = s + Convert.ToChar(ch).ToString();
                    break;
            }
            r.NextDouble();
            r.Next(100, 1999);
        }
        return s;
    }
    protected void lnkhome_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Default.aspx", false);
        }
        catch (Exception ex)
        {
            //LblMessage.Text = ex.Message;
            LblMessage.Text = "Please try after some time !";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The Login can not complete. Please try after some time !');", true);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Label4.Text = GenerateRandomCode();
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    protected void btngetpass_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox13.Text == Label4.Text)
            {
                Label4.Text = GenerateRandomCode();
                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                string _sqlQuery = "select * from INSLOGIN where MONO='" + Txtmono.Text + "' and INSCODE='"+Drpins.SelectedValue+"'";
                AllQueryParam[0] = _sqlQuery;

                BLL objbllLogin = new BLL();
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count > 0)
                {
                    _name = dt.Rows[0]["INSNAME"].ToString();
                    _password = dt.Rows[0]["PASSWORD"].ToString();
                    _EMAL = dt.Rows[0]["EMAIL"].ToString().Trim();
                    if (_EMAL != "")
                    {
                        _sendMail();
                        LblMessage.Text = "Your Password has been sent to your email address..";
                        ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Your Password has been sent to your email address. Please find mail and try to login.')</script>", false);

                    }
                    else
                    {
                        LblMessage.Text = "No Email ID Found in database for Entered Detils.";

                    }
                    TextBox13.Text = "";
                    Txtmono.Text = "";
                }
                else
                {
                    LblMessage.Text = "Entered Details does not exist in our database.";
                    TextBox13.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Entered Details does not exist in our database.')</script>", false);
                }
            }
            else
            {
                Label4.Text = GenerateRandomCode();
                LblMessage.Text = "Inavlid captcha value.";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Inavlid captcha value')</script>", false);
                TextBox13.Text = "";
            }
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
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
            sr.Append("<b>Dear Institute User;</b>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" colspan=3>");
            sr.Append("<br/>Your Institute Name and Password are given below :- <br/><br/>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" >");
            sr.Append("<b>Institute Name : </b>");
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append(_name);
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" >");
            sr.Append("<b>Institute Password : </b>");
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append(_password);
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


            MailMessage objmsg = new MailMessage("noreply@regapplication.in", _EMAL);
            objmsg.To.Add(_EMAL);
            objmsg.From = new MailAddress("noreply@regapplication.in");
            objmsg.Subject = "UBTER:Institute Forget Password";
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
                smtp.UseDefaultCredentials = false;

                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("noreply@ubter.in", "srnDATA@2004");
                smtp.Timeout = 50000;
            }
            smtp.Send(objmsg);
        }
        catch (Exception ex)
        {

        }
    }
}