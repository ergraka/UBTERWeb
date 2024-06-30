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
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class Single : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null && Session["UTYPE"] != null)
            {
                if (Session["UTYPE"].ToString() == "I")
                {
                    Lblname.Text = "<i>WELCOME IN INSTITUTE : </i>" + Session["INSCODE"].ToString();
                   
                }
                else if (Session["UTYPE"].ToString() == "B")
                {
                    string GRP = GROUP();
                    string[] spl = Session["BRCODE"].ToString().Split('|');
                    Lblname.Text = "<i>WELCOME IN INSTITUTE BRANCH : </i>" + Session["INSCODE"].ToString() + "</br>" + Session["BRCODE"].ToString() + " (" + GRP + ")";
                    //HOME
                  
                }
            }
            else
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                Response.Redirect("Inslogin.aspx", false);
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
    protected void Lnkbranch_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Inshome.aspx?PWD=CHANGE", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }


    private string GROUP()
    {
        if (Session["INSCODE"] != null && Session["BRCODE"] != null)
        {
            string[] insspl = Session["INSCODE"].ToString().Split('|');
            string[] brspl = Session["BRCODE"].ToString().Split('|');
            string _sqlQueryreg = string.Empty;
            DataTable dtreg = new DataTable();
            string[] AllQueryParamreg = new string[1];
            _sqlQueryreg = "select GRP from BRLOGIN where INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "'";
            AllQueryParamreg[0] = _sqlQueryreg;
            BLL objbllreg = new BLL();
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count > 0) { string GRP = dtreg.Rows[0]["GRP"].ToString(); return GRP; }
            else { return null; }
        }
        else { Response.Redirect("Inslogin.aspx", false); return null; }
    }
}
