using System;
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

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Label4.Text = GenerateRandomCode();
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
    private void _sendMail(string Name, string Regno, string Password, string Email)
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
            sr.Append("<b>Dear, " + Name + "</b>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" colspan=3>");
            sr.Append("<br/>Your Registration Number and Password are given below :- <br/><br/>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" >");
            sr.Append("<b>Registration Number : </b>");
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append(Regno);
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append("</td>");
            sr.Append("</tr>");

            sr.Append("<tr>");
            sr.Append("<td width=\"30%\" align=\"left\" >");
            sr.Append("<b>Password : </b>");
            sr.Append("</td>");
            sr.Append("<td>");
            sr.Append(Password);
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

            MailMessage objmsg = new MailMessage("noreply@ubterex.in", Email);
            objmsg.To.Add(Email);
            objmsg.From = new MailAddress("noreply@ubterex.in");
            objmsg.Subject = "UBTE : Student Login Summary";
            objmsg.Body = sr.ToString();
            objmsg.Priority = MailPriority.High;
            objmsg.IsBodyHtml = true;
            SmtpClient smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "dedrelay.secureserver.net";//On VPS Server
                //smtp.Host = "relay-hosting.secureserver.net";//On Godaddy Server
                //smtp.Host = "smtpout.secureserver.net";//On Other Server
                smtp.Port = 25;
                smtp.EnableSsl = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("noreply@ubterex.in", "SrN@7042293429");
                smtp.Timeout = 50000;
            }
            smtp.Send(objmsg);
        }
        catch (Exception ex)
        {
            ltrlMessage.Text = ex.Message;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox13.Text == Label4.Text)
            {
                Label4.Text = GenerateRandomCode();
                bool val = validation();
                if (val == false)
                {
                    ltrlMessage.Text = "Please Enter Atleast one from Roll Number OR Registration Number!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Atleast one from Roll Number OR Registration Number!');", true);
                    return;
                }

                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                string _sqlQuery = string.Empty;
                _sqlQuery = "select * from REGISTRATION where STAT='A' AND (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "')";
                AllQueryParam[0] = _sqlQuery;
                BLL objbllLogin = new BLL();
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count > 0)
                {
                    string _name = dt.Rows[0]["CNAME"].ToString();
                    string _Regid = dt.Rows[0]["CANDIDATEID"].ToString();
                    string _password = dt.Rows[0]["PASSWORD"].ToString();
                    string _EMAL = dt.Rows[0]["EMAIL"].ToString().Trim();
                    if (_EMAL != "")
                    {
                        _sendMail(_name, _Regid, _password, _EMAL);
                        ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Your Password has been sent to your email address. Please find mail in Inbox/Spam and try to login.')</script>", false);
                    }
                    else
                    {
                        ltrlMessage.Text = "No Email ID Found in database for Entered Registration Number/Roll Number.";
                    }
                    TextBox13.Text = "";
                }
                else
                {
                    ltrlMessage.Text = "Registration Number/Roll Number does not exist in our database.";
                    TextBox13.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Registration Number/Roll Number does not exist in our database.')</script>", false);
                }
            }
            else
            {
                Label4.Text = GenerateRandomCode();
                ltrlMessage.Text = "Inavlid captcha value.";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Inavlid captcha value')</script>", false);
                TextBox13.Text = "";
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Label4.Text = GenerateRandomCode();
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void lnkforgotpassword_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Default.aspx", false);
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    private bool validation()
    {
        if (Txtroll.Text == "") { return false; }
        return true;
    }
}