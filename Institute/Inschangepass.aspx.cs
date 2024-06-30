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
public partial class Inschangepass : System.Web.UI.Page 
{
    string _name = string.Empty;
    string _EMAIL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["INSCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
                else
                {
                    Lblins.Text = Session["INSCODE"].ToString();
                    Lblcaptcha.Text = GenerateRandomCode();
                }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            else
            {
                if (Txtcaptcha.Text == Lblcaptcha.Text)
                {
                    string _sqlQuery = string.Empty;
                    Lblcaptcha.Text = GenerateRandomCode();
                     bool chk = Validation();
                     if (chk == true) { INSERTDATA(); }
                     else
                     {
                         ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Please Select OR Fill all Fields Correctly.')</script>", false);
                         ltrlMessage.Text = "Please Select OR Fill all Fields Correctly.";
                     }
                }
                else
                {
                    Lblcaptcha.Text = GenerateRandomCode();
                    ltrlMessage.Text = "Inavlid insert value.";
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Inavlid Captcha value')</script>", false);
                    Txtcaptcha.Text = "";
                    Txtpassword.Text = "";
                    Txtcpassword.Text = "";
                    Txtnpassword.Text = "";
                }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    private void INSERTDATA()
    {
        BEL ObjBEL = new BEL();
        ObjBEL.OLDPASS = Txtpassword.Text;
        ObjBEL.INSPASSWORD = Txtnpassword.Text;
        ObjBEL.PWD = "Y";
        string[] spl = Lblins.Text.Split('|');
        ObjBEL.PWDINSCODE = spl[0].ToString();
        ObjBEL.INSMONO = TxtMono.Text.ToUpper().Trim();
        ObjBEL.INSLLNO = Txtstdcode.Text.ToUpper().Trim() + "-" + TxtLLN.Text.ToUpper().Trim();
        ObjBEL.INSEMAIL = Txtemail.Text.ToUpper();
        BLL _ObjInsBLL = new BLL();
        string Result = _ObjInsBLL._INSBLL(ObjBEL);
        if (Result == "1-1")
        {
            _sendMail();
            Session.Abandon();
            Txtcaptcha.Text = "";
            Txtpassword.Text = "";
            Txtcpassword.Text = "";
            Txtnpassword.Text = "";
            Response.Redirect("~/Default.aspx?CHANGE=CHANGE", false);
        }
        else
        {
            Lblcaptcha.Text = GenerateRandomCode();
            Txtcaptcha.Text = "";
            ltrlMessage.Text = "Inavlid Old Password.";
            ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Invalid Old Password.')</script>", false);
        }
    }
    private bool Validation()
    {
        if (Txtpassword.Text.Trim() == "") { return false; }
        if (Txtnpassword.Text.Trim() == "") { return false; }
        if (Txtcpassword.Text.Trim() == "") { return false; }
        if (TxtMono.Text.Trim() == "") { return false; }
        if (Txtstdcode.Text.Trim() == "") { return false; }
        if (TxtLLN.Text.Trim() == "") { return false; }
        if (Txtemail.Text.Trim() == "") { return false; }
        if (Txtcemail.Text.Trim() == "") { return false; }
        return true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
            else
            {
                Lblcaptcha.Text = GenerateRandomCode();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Lnklogin_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("Inslogin.aspx", false);
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
            sr.Append("<br/>Institute Name and Password are given below :- <br/><br/>");
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
            sr.Append("<b>Password : </b>");
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

            MailMessage objmsg = new MailMessage("noreply@regapplication.in", Txtemail.Text);
            objmsg.To.Add(Txtemail.Text);
            objmsg.From = new MailAddress("noreply@regapplication.in");
            objmsg.Subject = "UBTER:Change Password-" + Session["INSCODE"].ToString(); ;
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
}