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
public partial class Insbrdetails : System.Web.UI.Page
{
    public string LNKURL = string.Empty;
    public string TYPENAME = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Request.QueryString["STAT"] == null) { Response.Redirect("~/Error.aspx", false); }

            if (!IsPostBack)
            {
                string STAT = Request.QueryString["STAT"].ToString();
                if (STAT == "INS") { Lblcp.Text = "Institute Summary"; Grdbranch.Visible = false; }
                else if (STAT == "BRC") { Lblcp.Text = "Branch Summary"; Grdins.Visible = false; }
                Griddata();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }

    public void Griddata()
    {
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        string STAT = Request.QueryString["STAT"].ToString();
        if (STAT == "INS") { _sqlQueryreg = "select * from INSLOGIN where STAT='A' AND INSCODE!='0' order by INSCODE asc"; }
        else if (STAT == "BRC") { _sqlQueryreg = "select * from BRLOGIN where STAT='A' AND BRCODE!='0' order by INSCODE,BRCODE asc"; }
        AllQueryParamreg[0] = _sqlQueryreg;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (STAT == "INS") { Grdins.DataSource = dtreg; Grdins.DataBind(); }
        else if (STAT == "BRC") { Grdbranch.DataSource = dtreg; Grdbranch.DataBind(); }
    }
}