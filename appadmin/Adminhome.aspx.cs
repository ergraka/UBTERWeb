using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Collections;
using _Examination;

public partial class Adminhome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            else
            {
                //*************************************************SUMMARY
                string _sqlQueryreg = string.Empty;
                string[] AllQueryParamreg = new string[1];
                BLL objbllreg = new BLL();
                DataTable dtsumm = new DataTable();
                _sqlQueryreg = "select (SELECT COUNT(*) FROM INSLOGIN WHERE INSCODE!='0') AS TOTINS,(SELECT COUNT(DISTINCT BRCODE) FROM BRLOGIN WHERE BRCODE!='0') AS TOTBRANCH,(SELECT COUNT(*) FROM REGISTRATION WHERE STAT='A') AS TOTSTU";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtsumm, AllQueryParamreg);
                Grdsumm.DataSource = dtsumm;
                Grdsumm.DataBind();
                //Get Session
                DataTable dtsess = new DataTable();
                _sqlQueryreg = "select * FROM FORMSESS ORDER BY SESSDETAIL";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtsess, AllQueryParamreg);
                Grdsess.DataSource = dtsess;
                Grdsess.DataBind();
                //***********************************************************
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
}