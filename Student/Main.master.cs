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

public partial class Main : System.Web.UI.MasterPage
{
    string cname = string.Empty;
    string ISREG = string.Empty;
    string ISQUA = string.Empty;
    string ISADD = string.Empty;
    string ISPH = string.Empty;
    string ISCOMPLETED = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["ID"] != null)
            {
                Lnklogout.Visible = true;
                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                string _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID=" + Session["ID"].ToString().Trim();
                AllQueryParam[0] = _sqlQuery;
                BLL objbllLogin = new BLL();
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count > 0)
                {
                    string BRCODE = dt.Rows[0]["BRCODE"].ToString();
                    string[] SPLBR = BRCODE.Split('-');
                    string BR = SPLBR[0].ToString();
                    cname = dt.Rows[0]["CNAME"].ToString();
                    ISREG = dt.Rows[0]["ISREG"].ToString();
                    ISQUA = dt.Rows[0]["ISQUA"].ToString();
                    ISADD = dt.Rows[0]["ISADD"].ToString();
                    ISPH = dt.Rows[0]["ISPH"].ToString();

                    string SEM = dt.Rows[0]["SEM"].ToString();
                    if (SEM == "03") { ISCOMPLETED = dt.Rows[0]["SEMCOM3"].ToString(); }
                    else { ISCOMPLETED = dt.Rows[0]["SEMCOM1"].ToString(); }

                    if (ISREG == "True")//Registration-1
                    {
                        LnkReg1.Enabled = false;
                        LnkReg1.ForeColor = System.Drawing.Color.White;
                        Imgstatreg1.Visible = true;
                        Imgreg1.Visible = false;
                        Lnkreg1edit.Visible = true;
                    }
                    else
                    {
                        LnkReg1.Enabled = true;
                        LnkReg1.ForeColor = System.Drawing.Color.Red;
                        Imgstatreg1.Visible = false;
                        Imgreg1.Visible = true;
                        Lnkreg1edit.Visible = false;
                    }
                    if (ISREG == "True" && ISQUA == "" || ISQUA == "False")//Qualification
                    {
                        LnkQua.Enabled = true;
                        LnkQua.ForeColor = System.Drawing.Color.Red;
                        ImgStatQua.Visible = false;
                        ImgQua.Visible = true;

                    }
                    else if (ISREG == "True" && ISQUA == "True")
                    {
                        LnkQua.Enabled = false;
                        LnkQua.ForeColor = System.Drawing.Color.White;
                        ImgStatQua.Visible = true;
                        ImgQua.Visible = false;
                        Lnkquaedit.Visible = true;
                    }

                    if (ISQUA == "True" && ISADD == "" || ISADD == "False")//Address
                    {
                        Lnkaddress.Enabled = true;
                        Lnkaddress.ForeColor = System.Drawing.Color.Red;
                        Imgstataddress.Visible = false;
                        Imgaddress.Visible = true;
                    }
                    else if (ISQUA == "True" && ISADD == "True")
                    {
                        Lnkaddress.Enabled = false;
                        Lnkaddress.ForeColor = System.Drawing.Color.White;
                        Imgstataddress.Visible = true;
                        Imgaddress.Visible = false;
                        Lnkaddedit.Visible = true;

                    }
                    if (ISADD == "True" && ISPH == "" || ISPH == "False")//Photo
                    {
                        Lnkphoto.Enabled = false;
                        Lnkphoto.ForeColor = System.Drawing.Color.White;
                        Imgstatphoto.Visible = false;
                        Imgphoto.Visible = true;
                    }
                    else if (ISADD == "True" && ISPH == "True")//Address and Photo
                    {
                        Lnkphoto.Enabled = false;
                        Lnkphoto.ForeColor = System.Drawing.Color.White;
                        Imgstatphoto.Visible = true;
                        Imgphoto.Visible = false;
                        Lnkphedit.Visible = true;
                        Imgview.Visible = true;
                        Lnkview.ForeColor = System.Drawing.Color.Red;
                    }
                    if (ISCOMPLETED == "True")//Branch Approved
                    {
                        Lnkview.Enabled = true;
                        Lnkview.ForeColor = System.Drawing.Color.Red;
                        Imgstatview.Visible = true;
                        Imgview.Visible = true;

                        Lnkreg1edit.Visible = false;
                        Lnkquaedit.Visible = false;
                        Lnkaddedit.Visible = false;
                        Lnkphedit.Visible = false;
                    }
                    //confirmation page
                    //Imgview.Visible = false;
                    //Lnkview.Enabled = false;
                    //Lnkview.ForeColor = System.Drawing.Color.White;

                    string path = "~/Upload/Photo/" + Session["ID"].ToString().Trim() + "P.jpg";
                    string pathsign = "~/Upload/Sign/" + Session["ID"].ToString().Trim() + "S.jpg";
                    if (File.Exists(MapPath(path)) == false && File.Exists(MapPath(pathsign)) == false)
                    {
                        if (ISPH == "True")
                        {
                            Lnkphoto.Enabled = true;
                            Lnkphoto.ForeColor = System.Drawing.Color.Red;
                            Imgstatphoto.Visible = false;
                            Imgphoto.Visible = true;
                            BLL objbllonlyquery = new BLL();
                            _sqlQuery = "update REGISTRATION set ISPH=NULL where CANDIDATEID=" + Session["ID"].ToString().Trim();
                            string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                        }
                    }
                    else
                    {
                        BLL objbllonlyquery = new BLL();
                        _sqlQuery = "update REGISTRATION set ISPH='1' where CANDIDATEID=" + Session["ID"].ToString().Trim();
                        string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Candidate ID or Password !');", true);
                }
            }
            else
            {
                Lnklogout.Visible = false;
                LnkReg1.Enabled = true;
                LnkReg1.ForeColor = System.Drawing.Color.Red;
                Imgstatreg1.Visible = false;
                Imgreg1.Visible = true;
                Lnkphoto.Enabled = false;
                Lnkview.Enabled = false;
            }
            if(Session["ADMIN"]!=null)
            {
                Lnkreg1edit.Visible=true;
                Lnkquaedit.Visible = true;
                Lnkaddedit.Visible = true;
                Lnkphedit.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The registration can not complete. Please try after some time !');", true);
        }

    }
    protected void Lnklogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ID"] = null;
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("Login.aspx", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
    protected void Lnkreg1edit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                Session["EDIT"] = "REG";
                Response.Redirect("Registration.aspx", false);
            }
            else { Session.Abandon(); Response.Redirect("Login.aspx", false); }
        }
        catch (Exception ex)
        {
            Session.Abandon(); Response.Write("Please try after some time.");
        }
    }
    protected void Lnkquaedit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                Session["EDIT"] = "QUA";
                Response.Redirect("Qualification.aspx", false);
            }
            else { Session.Abandon(); Response.Redirect("Login.aspx", false); }
        }
        catch (Exception ex)
        {
            Session.Abandon(); Response.Write("Please try after some time.");
        }
    }
    protected void Lnkaddedit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                Session["EDIT"] = "ADD";
                Response.Redirect("Address.aspx", false);
            }
            else { Session.Abandon(); Response.Redirect("Login.aspx", false); }
        }
        catch (Exception ex)
        {
            Session.Abandon(); Response.Write("Please try after some time.");
        }
    }
    protected void Lnkphedit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                Session["EDIT"] = "PH";
                Response.Redirect("PhotoSign.aspx", false);
            }
            else { Session.Abandon(); Response.Redirect("Login.aspx", false); }
        }
        catch (Exception ex)
        {
            Session.Abandon(); Response.Write("Please try after some time.");
        }
    }
}
