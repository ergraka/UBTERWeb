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

public partial class Status : System.Web.UI.Page
{
   public string cname = string.Empty;
   public string _ISREG = string.Empty;
   public string _ISQUA = string.Empty;
   public string _ISADD = string.Empty;
   public string _ISPH = string.Empty;
   public string _ISCOMPLETED = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["ADMIN"] != null) { if (Request.QueryString["AAAAA"] != null) { Session["ID"] = Request.QueryString["AAAAA"].ToString(); } }
                if (Session["ID"] != null)
                {
                    DataTable dt = new DataTable();
                    string[] AllQueryParam = new string[1];
                    string _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID=" + Session["ID"].ToString().Trim();
                    AllQueryParam[0] = _sqlQuery;
                    BLL objbllLogin = new BLL();
                    objbllLogin.QUERYBLL(ref dt, AllQueryParam);

                    if (dt.Rows.Count > 0)
                    {

                        cname = dt.Rows[0]["CNAME"].ToString();
                        Label2.Text = cname;
                        string ISREG = string.Empty;
                        string ISQUA = string.Empty;
                        string ISADD = string.Empty;
                        string ISPH = string.Empty;
                        string ISCOMPLETED = string.Empty;
                        ISREG = dt.Rows[0]["ISREG"].ToString();
                        ISQUA = dt.Rows[0]["ISQUA"].ToString();
                        ISADD = dt.Rows[0]["ISADD"].ToString();
                        ISPH = dt.Rows[0]["ISPH"].ToString();
                        string SEM = dt.Rows[0]["SEM"].ToString();
                        if (SEM == "03") { ISCOMPLETED = dt.Rows[0]["SEMCOM3"].ToString(); }
                        else { ISCOMPLETED = dt.Rows[0]["SEMCOM1"].ToString(); }
                        Label2.Text = cname + " : Registration Number : [" + Session["ID"].ToString() + "]";
                        if (ISREG == "True")//Registration
                        {
                            _ISREG = "Completed";
                        }
                        else
                        {
                            _ISREG = "Pending";
                            if (Request.QueryString["Mode"] == null)
                            {
                                Response.Redirect("Registration.aspx", true);
                            }
                        }
                        if (ISQUA == "True")//Qualification
                        {
                            _ISQUA = "Completed";
                        }
                        else
                        {
                            _ISQUA = "Pending";
                            if (Request.QueryString["Mode"] == null)
                            {
                                Response.Redirect("Qualification.aspx", true);
                            }
                        }
                        if (ISADD == "True")//Address
                        {
                            _ISADD = "Completed";
                        }
                        else
                        {
                            _ISADD = "Pending";
                            if (Request.QueryString["Mode"] == null)
                            {
                                Response.Redirect("Address.aspx", true);
                            }
                        }
                        if (ISPH == "True")//Photo
                        {
                            _ISPH = "Completed";
                             string path = "~/Upload/Photo/" + Session["ID"].ToString().Trim() + "P.jpg";
                             if (File.Exists(MapPath(path)) == false)
                             {
                                 _ISPH = "Pending";
                             }
                        }
                        else
                        {
                            _ISPH = "Pending";
                            if (Request.QueryString["Mode"] == null)
                            {
                                Response.Redirect("PhotoSign.aspx", true);
                            }
                        }

                        if (ISCOMPLETED == "True")//Completed
                        {
                            _ISCOMPLETED = "Completed";
                        }
                        else
                        {
                            _ISCOMPLETED = "Pending";
                        }
                    }
                    else { Response.Redirect("Error.aspx", true); }
                }
                else
                {
                    Response.Redirect("Login.aspx", true);
                    _ISREG = "Pending";
                    _ISQUA = "Pending";
                    _ISADD = "Pending";
                    _ISPH = "Pending";
                    _ISCOMPLETED = "Pending";
                    Label2.Text = "New Candidate !";
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The registration can not complete. Please try after some time !');", true);
        }
    }
}
