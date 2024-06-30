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
public partial class Brhomesingle : System.Web.UI.Page
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
                    Lnkscrunapp.Enabled = true;
                    Lnkreevanapp.Enabled = true;
                    if (Session["BRCODE"].ToString() != null)
                    {
                        bindsourcedata();
                        SCRU();
                        REEVA();
                        NEWSEM();
                    }
                    else { Response.Redirect("Inslogin.aspx", false); }
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

        string[] spl2 = Session["BRCODE"].ToString().Split('|');
        string brcode = spl2[0].ToString();
        _sqlQuery = "select Count(*) as CON from REGISTRATION where INSCODE='" + inscode + "' and BRCODE='" + brcode + "'";
        _sqlQuery1 = "select Count(*) as CON from REGISTRATION where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "'";
        _sqlQuery2 = "select Count(*) as CON from REGISTRATION where ISCOMPLETED is NUll and INSCODE='" + inscode + "' and BRCODE='" + brcode + "'";


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
        Lnknapproved.Text = dt2.Rows[0]["CON"].ToString() + " - Click here to View/Approved.";
    }
    protected void Lnkapproved_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Stulist.aspx?REG=APP", false);
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
            Response.Redirect("Stulist.aspx?REG=NAPP", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
    protected void Lnkall_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Stulist.aspx?REG=ALL", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }

    private void SCRU()
    {
        string _sqlQuery = string.Empty;
        string _sqlQuery1 = string.Empty;
        string _sqlQuery2 = string.Empty;
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        string[] spl1 = Session["INSCODE"].ToString().Split('|');
        string inscode = spl1[0].ToString();

        string[] spl2 = Session["BRCODE"].ToString().Split('|');
        string brcode = spl2[0].ToString();
        _sqlQuery = "select Count(*) as CON from SCRU where INSCODE='" + inscode + "' and BRCODE='" + brcode + "'";
        _sqlQuery1 = "select Count(*) as CON from SCRU where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "'";
        _sqlQuery2 = "select Count(*) as CON from SCRU where ISCOMPLETED is NUll and INSCODE='" + inscode + "' and BRCODE='" + brcode + "'";
        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        Lnkscruall.Text = dt.Rows[0]["CON"].ToString() + " - Click here to view.";

        DataTable dt1 = new DataTable();
        string[] AllQueryParam1 = new string[1];
        AllQueryParam1[0] = _sqlQuery1;
        BLL objbllLogin1 = new BLL();
        objbllLogin1.QUERYBLL(ref dt1, AllQueryParam1);
        Lnkscruapp.Text = dt1.Rows[0]["CON"].ToString() + " - Click here to view.";

        DataTable dt2 = new DataTable();
        string[] AllQueryParam2 = new string[1];
        AllQueryParam2[0] = _sqlQuery2;
        BLL objbllLogin2 = new BLL();
        objbllLogin2.QUERYBLL(ref dt2, AllQueryParam2);
        Lnkscrunapp.Text = dt2.Rows[0]["CON"].ToString() + " - Click here to View/Approved.";
    }
    private void REEVA()
    {

        string _sqlQuery = string.Empty;
        string _sqlQuery1 = string.Empty;
        string _sqlQuery2 = string.Empty;

        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        string[] spl1 = Session["INSCODE"].ToString().Split('|');
        string inscode = spl1[0].ToString();

        string[] spl2 = Session["BRCODE"].ToString().Split('|');
        string brcode = spl2[0].ToString();
        _sqlQuery = "select Count(*) as CON from REEVA where INSCODE='" + inscode + "' and BRCODE='" + brcode + "'";
        _sqlQuery1 = "select Count(*) as CON from REEVA where ISCOMPLETED='1' and INSCODE='" + inscode + "' and BRCODE='" + brcode + "'";
        _sqlQuery2 = "select Count(*) as CON from REEVA where ISCOMPLETED is NUll and INSCODE='" + inscode + "' and BRCODE='" + brcode + "'";

        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        Lnkreevaall.Text = dt.Rows[0]["CON"].ToString() + " - Click here to view.";

        DataTable dt1 = new DataTable();
        string[] AllQueryParam1 = new string[1];
        AllQueryParam1[0] = _sqlQuery1;
        BLL objbllLogin1 = new BLL();
        objbllLogin1.QUERYBLL(ref dt1, AllQueryParam1);
        Lnkreevaapp.Text = dt1.Rows[0]["CON"].ToString() + " - Click here to view.";

        DataTable dt2 = new DataTable();
        string[] AllQueryParam2 = new string[1];
        AllQueryParam2[0] = _sqlQuery2;
        BLL objbllLogin2 = new BLL();
        objbllLogin2.QUERYBLL(ref dt2, AllQueryParam2);
        Lnkreevanapp.Text = dt2.Rows[0]["CON"].ToString() + " - Click here to View/Approved.";
    }
    private void NEWSEM()
    {

        string _sqlQuery = string.Empty;
        string _sqlQuery1 = string.Empty;
        string _sqlQuery2 = string.Empty;

        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        string[] spl1 = Session["INSCODE"].ToString().Split('|');
        string inscode = spl1[0].ToString();

        string[] spl2 = Session["BRCODE"].ToString().Split('|');
        string brcode = spl2[0].ToString();
        _sqlQuery = "select Count(*) as CON from REGISTRATION where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND ISSEM2='1'";
        _sqlQuery1 = "select Count(*) as CON from REGISTRATION where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND ISSEM2='1' AND ISSEM2COMP='1'";
        _sqlQuery2 = "select Count(*) as CON from REGISTRATION where ISSEM2COMP is NUll and INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND ISSEM2='1'";

        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        //Lnksem2all.Text = dt.Rows[0]["CON"].ToString() + " - Click here to view.";

        DataTable dt1 = new DataTable();
        string[] AllQueryParam1 = new string[1];
        AllQueryParam1[0] = _sqlQuery1;
        BLL objbllLogin1 = new BLL();
        objbllLogin1.QUERYBLL(ref dt1, AllQueryParam1);
       // Lnksem2app.Text = dt1.Rows[0]["CON"].ToString() + " - Click here to view.";

        DataTable dt2 = new DataTable();
        string[] AllQueryParam2 = new string[1];
        AllQueryParam2[0] = _sqlQuery2;
        BLL objbllLogin2 = new BLL();
        objbllLogin2.QUERYBLL(ref dt2, AllQueryParam2);
       // Lnksem2napp.Text = dt2.Rows[0]["CON"].ToString() + " - Click here to View/Approved.";
    }
}
