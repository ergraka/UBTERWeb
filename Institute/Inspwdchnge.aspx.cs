﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using _Examination;

public partial class Inspwdchnge : System.Web.UI.Page
{
    string _EMAIL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["INSCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
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
            sr.Append("<b>Dear,</b>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" colspan=3>");
            sr.Append("<br/>Your New Password are given below :- <br/><br/>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" >");
            sr.Append("<b>New Password : </b>");
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append(Txtnpassword.Text);
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

            MailMessage objmsg = new MailMessage("noreply@regapplication.in", _EMAIL);
            objmsg.To.Add(_EMAIL);
            objmsg.From = new MailAddress("noreply@regapplication.in");
            objmsg.Subject = "Change Institute Password For-" + Session["INSCODE"].ToString();
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
        catch (Exception ex)
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            else
            {

                string[] INSPL = Session["INSCODE"].ToString().Split('|');
                string INS = INSPL[0].ToString();

                BLL objbllonlyquery = new BLL();
                string _sqlQuery = "update INSLOGIN set PASSWORD='" + Txtnpassword.Text.Trim() + "' where PASSWORD='" + Txtpassword.Text.Trim() + "' and INSCODE='" + INS + "'";
                string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);

                if (result == "1-1")
                {
                    ltrlMessage.Text = "Password Changed Successfully.";
                    DataTable dt = new DataTable();
                    string[] AllQueryParam = new string[1];
                    string _sqlQuery1 = "select * from INSLOGIN where INSCODE='" + INS + "'";
                    AllQueryParam[0] = _sqlQuery1;
                    BLL objbllLogin = new BLL();
                    objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                    if (dt.Rows.Count > 0)
                    {
                        _EMAIL = dt.Rows[0]["EMAIL"].ToString().Trim();
                        if (_EMAIL != "")
                        {
                            _sendMail();
                            ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Password Changed Successfully, Password has been also sent to your email address. Please find mail and login with new password next time.');</script>", false);
                        }
                        Txtpassword.Text = "";
                        Txtcpassword.Text = "";
                        Txtnpassword.Text = "";
                    }
                }
                else
                {
                    ltrlMessage.Text = "Inavlid Old Password.";
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Invalid Old Password.')</script>", false);
                }

            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
}