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
using _Examination;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["ID"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    DataTable dt = new DataTable();
                    string[] AllQueryParam = new string[1];
                    string _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID=" + Session["ID"].ToString().Trim();
                    AllQueryParam[0] = _sqlQuery;
                    BLL objbllLogin = new BLL();
                    objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                    if (dt.Rows.Count > 0)
                    {
                        if (Session["EDIT"] != null)
                        {
                            if (Session["Edit"].ToString() == "REG") { Response.Redirect("Registration.aspx", false); }
                            if (Session["Edit"].ToString() == "QUA") { Response.Redirect("Qualification.aspx", false); }
                            if (Session["Edit"].ToString() == "PH") { Response.Redirect("PhotoSign.aspx", false); }
                            //Correspondence
                            Txtcaddress.Text = dt.Rows[0]["CADDRESS"].ToString();
                            string Cstate = dt.Rows[0]["CSTATE"].ToString().ToLower();
                            if (Drpcstate.Items.FindByValue(Cstate) != null) { Drpcstate.SelectedValue = Cstate; }
                            else { Txtcother.Visible = true; Txtcother.Text = Cstate; Drpcstate.SelectedValue = "other"; }
                            if (Drpcstate.SelectedValue == "uttarakhand")
                            {
                              
                                Getcstate();
                                Drpcdistname.Visible = true; Txtcdistname.Visible = false;
                                Drpctehsil.Visible = true; Txtctehsil.Visible = false;
                                Drpcblock.Visible = true; Txtcblock.Visible = false;

                                Drpcdistname.SelectedValue = dt.Rows[0]["CDISTRICT"].ToString();
                                Drpctehsil.SelectedValue = dt.Rows[0]["CTEHSIL"].ToString();
                                Drpcblock.SelectedValue = dt.Rows[0]["CBLOCK"].ToString();
                            }
                            else
                            {
                                Drpcdistname.Visible = false; Txtcdistname.Visible = true;
                                Drpctehsil.Visible = false; Txtctehsil.Visible = true;
                                Drpcblock.Visible = false; Txtcblock.Visible = true;

                                Txtcdistname.Text = dt.Rows[0]["CDISTRICT"].ToString();
                                Txtctehsil.Text = dt.Rows[0]["CTEHSIL"].ToString();
                                Txtcblock.Text = dt.Rows[0]["CBLOCK"].ToString();
                            }
                            Txtcpin.Text = dt.Rows[0]["CPIN"].ToString();
                            //Permanent
                            string _ISSAME = dt.Rows[0]["ISSAME"].ToString();
                            if (_ISSAME == "1") { CheckBox1.Checked = true; }
                            Txtpaddress.Text = dt.Rows[0]["PADDRESS"].ToString();
                            string Pstate = dt.Rows[0]["PSTATE"].ToString().ToLower();
                            if (Drppstate.Items.FindByValue(Pstate) != null) { Drppstate.SelectedValue = Pstate; }
                            else { Txtpother.Visible = true; Txtpother.Text = Pstate; Drppstate.SelectedValue = "other"; }
                            if (Drppstate.SelectedValue == "uttarakhand")
                            {
                                Getpstate();
                                Drppdistname.SelectedValue = dt.Rows[0]["PDISTRICT"].ToString();
                                Drpptehsil.SelectedValue = dt.Rows[0]["PTEHSIL"].ToString();
                                Drppblock.SelectedValue = dt.Rows[0]["PBLOCK"].ToString();
                                Drppdistname.Visible = true; Txtpdistname.Visible = false;
                                Drpptehsil.Visible = true; Txtptehsil.Visible = false;
                                Drppblock.Visible = true; Txtpblock.Visible = false;
                            }
                            else
                            {
                                Drppdistname.Visible = false; Txtpdistname.Visible = true;
                                Drpptehsil.Visible = false; Txtptehsil.Visible = true;
                                Drppblock.Visible = false; Txtpblock.Visible = true;

                                Txtpdistname.Text = dt.Rows[0]["PDISTRICT"].ToString();
                                Txtptehsil.Text = dt.Rows[0]["PTEHSIL"].ToString();
                                Txtpblock.Text = dt.Rows[0]["PBLOCK"].ToString();
                            }
                            Txtppin.Text = dt.Rows[0]["PPIN"].ToString();
                            Button1.Text = "Submit";
                        }
                        else
                        {
                            string ISADD = dt.Rows[0]["ISADD"].ToString().Trim();
                            if (ISADD == "True") { Response.Redirect("PhotoSign.aspx", false); }
                        }

                    }
                }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    private bool Validation()
    {
        //Correspondance
        if (Txtcaddress.Text.Trim() == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Correspondance Address.');", true); return false; }
        if (Txtcpin.Text.Trim() == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Correspondance Pin.');", true); return false; }
        if (Drpcstate.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Correspondance State.');", true); return false; }
        if (Drpcstate.SelectedValue == "other")
        {
            if (Txtcother.Text.Trim() == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Correspondance State.');", true); return false; }
        }
        else if (Drpcstate.SelectedValue == "uttarakhand")
        {
            if (Drpcdistname.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Correspondance District.');", true); return false; }
            if (Drpctehsil.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Correspondance Tehsil.');", true); return false; }
            if (Drpcblock.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Correspondance Block.');", true); return false; }
        }
        else
        {
            if (Txtcdistname.Text.Trim() == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Correspondance District.');", true); return false; }
            if (Txtctehsil.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Correspondance Tehsil.');", true); return false; }
            if (Txtcblock.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Correspondance Block.');", true); return false; }
        }
        //Permanent
        if (Txtpaddress.Text.Trim() == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Permanent Address.');", true); return false; }
        if (Drppstate.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Permanent State.');", true); return false; }
        if (Drppstate.SelectedValue == "other")
        {
            if (Txtpother.Text.Trim() == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Permanent State.');", true); return false; }
        }
        else if (Drppstate.SelectedValue == "uttarakhand")
        {
            if (Drppdistname.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Permanent District.');", true); return false; }
            if (Drpptehsil.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Permanent Tehsil.');", true); return false; }
            if (Drppblock.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Permanent Block.');", true); return false; }
            if (Txtppin.Text.Trim() == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Permanent Pin.');", true); return false; }
        }
        else
        {
            if (Txtpdistname.Text.Trim() == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Permanent District.');", true); return false; }
            if (Txtptehsil.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Permanent Tehsil.');", true); return false; }
            if (Txtpblock.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Permanent Block.');", true); return false; }
            if (Txtppin.Text.Trim() == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Permanent Pin.');", true); return false; }
        }
        return true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                bool chk = Validation();
                if (chk == true)
                {
                    Session["EDIT"] = null;
                    INSERTDATA();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Please Select OR Fill all Fields Correctly.')</script>", false);
                    ltrlMessage.Text = "Please Select all Fields Correctly.";
                }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    private void INSERTDATA()
    {
        BEL ObjBEL = new BEL();
        ObjBEL.AddressCandidateId = Session["ID"].ToString();
        //Correspondence
        ObjBEL.CADDRESS = Txtcaddress.Text.ToUpper().Trim();
        if (Drpcstate.SelectedValue != "other") { ObjBEL.CSTATE = Drpcstate.SelectedItem.ToString().ToUpper().Trim(); }
        else { ObjBEL.CSTATE = Txtcother.Text.ToUpper().Trim(); }

        if (Drpcstate.SelectedValue == "uttarakhand")
        {
            ObjBEL.CDISTRICT = Drpcdistname.SelectedItem.ToString().ToUpper().Trim();
            ObjBEL.CTEHSIL = Drpctehsil.SelectedItem.ToString().ToUpper().Trim();
            ObjBEL.CBLOCK = Drpcblock.SelectedItem.ToString().ToUpper().Trim();
        }
        else
        {
            ObjBEL.CDISTRICT = Txtcdistname.Text.ToUpper().Trim();
            ObjBEL.CTEHSIL = Txtctehsil.Text.ToUpper().Trim();
            ObjBEL.CBLOCK = Txtcblock.Text.ToUpper().Trim();
        }
        ObjBEL.CPIN = Txtcpin.Text;
        //Permanent
        if (CheckBox1.Checked == true) { ObjBEL.ISADDRESSSAME = "1"; }
        else { ObjBEL.ISADDRESSSAME = "0"; }

        ObjBEL.PADDRESS = Txtpaddress.Text.ToUpper().Trim();
        if (Drppstate.SelectedValue != "other") { ObjBEL.PSTATE = Drppstate.SelectedItem.ToString().ToUpper().Trim(); }
        else { ObjBEL.PSTATE = Txtpother.Text.ToUpper().Trim(); }
        if (Drppstate.SelectedValue == "uttarakhand")
        {
            ObjBEL.PDISTRICT = Drppdistname.SelectedItem.ToString().ToUpper().Trim();
            ObjBEL.PTEHSIL = Drpptehsil.SelectedItem.ToString().ToUpper().Trim();
            ObjBEL.PBLOCK = Drppblock.SelectedItem.ToString().ToUpper().Trim();
        }
        else
        {
            ObjBEL.PDISTRICT = Txtpdistname.Text.ToUpper().Trim();
            ObjBEL.PTEHSIL = Txtptehsil.Text.ToUpper().Trim();
            ObjBEL.PBLOCK = Txtpblock.Text.ToUpper().Trim();
        }
        ObjBEL.PPIN = Txtppin.Text;
        BLL _ObjAddressBLL = new BLL();
        string Result = _ObjAddressBLL._ADDRESSBLL(ObjBEL);
        if (Result == "1-1") { Response.Redirect("PhotoSign.aspx", false); }
        else { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (CheckBox1.Checked == true)
                {
                    Txtpaddress.Text = Txtcaddress.Text;
                    Drppstate.SelectedValue = Drpcstate.SelectedValue;
                    if (Drppstate.SelectedValue == "other")
                    {
                        Drppdistname.Visible = false; Txtpdistname.Visible = true;
                        Drpptehsil.Visible = false; Txtptehsil.Visible = true;
                        Drppblock.Visible = false; Txtpblock.Visible = true;
                        Txtpother.Visible = true;
                    }
                    else if (Drppstate.SelectedValue == "uttarakhand")
                    {
                        Drppdistname.Visible = true; Txtpdistname.Visible = false;
                        Drpptehsil.Visible = true; Txtptehsil.Visible = false;
                        Drppblock.Visible = true; Txtpblock.Visible = false;
                        Getpstate();
                    }
                    else
                    {
                        Drppdistname.Visible = false; Txtpdistname.Visible = true;
                        Drpptehsil.Visible = false; Txtptehsil.Visible = true;
                        Drppblock.Visible = false; Txtpblock.Visible = true;
                        Txtpother.Visible = false;
                    }
                    Drppdistname.Enabled = false;
                    Drpptehsil.Enabled = false;
                    Drppblock.Enabled = false;
                    Txtptehsil.Enabled = false;
                    Txtpblock.Enabled = false;
                    Txtppin.Text = Txtcpin.Text;
                    Txtpaddress.Enabled = false;
                    Txtpdistname.Enabled = false;
                    Drppstate.Enabled = false;
                    Txtppin.Enabled = false;
                    Txtpother.Text = Txtcother.Text;
                    Txtpother.Enabled = false;

                    Drppdistname.SelectedValue = Drpcdistname.SelectedValue;
                    Drpptehsil.SelectedValue = Drpctehsil.SelectedValue;
                    Drppblock.SelectedValue = Drpcblock.SelectedValue;

                    Txtpdistname.Text = Txtcdistname.Text;
                    Txtptehsil.Text = Txtctehsil.Text;
                    Txtpblock.Text = Txtcblock.Text;
                }
                if (CheckBox1.Checked == false)
                {
                    Txtpaddress.Text = "";
                    Txtpdistname.Text = "";
                    Drppstate.SelectedValue = "0";
                    Txtppin.Text = "";
                    Txtpother.Visible = false;
                    Txtpaddress.Enabled = true;
                    Txtpdistname.Enabled = true;
                    Drppstate.Enabled = true;
                    Txtppin.Enabled = true;
                    Txtpother.Text = "";
                    Txtpother.Enabled = true;
                    Drppdistname.Enabled = true;
                    Drpptehsil.Enabled = true;
                    Drppblock.Enabled = true;
                    Txtptehsil.Enabled = true;
                    Txtpblock.Enabled = true;
                    Txtptehsil.Text = "";
                    Txtpblock.Text = "";

                    if (Drppdistname.Items.Count > 0) { Drppdistname.Items.Clear(); }
                    if (Drpptehsil.Items.Count > 0) { Drpptehsil.Items.Clear(); }
                    if (Drppblock.Items.Count > 0) { Drppblock.Items.Clear(); }

                }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Drpcstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] == null) { Response.Redirect("Login.aspx", false); }
            else
            {
                Getcstate();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Drppstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] == null) { Response.Redirect("Login.aspx", false); }
            else
            {
                Getpstate();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    private void Getcstate()
    {
        if (Drpcstate.SelectedValue == "other")
        {
            Drpcdistname.Visible = false; Txtcdistname.Visible = true;
            Drpctehsil.Visible = false; Txtctehsil.Visible = true;
            Drpcblock.Visible = false; Txtcblock.Visible = true;
            Txtcother.Visible = true;
        }
        else if (Drpcstate.SelectedValue == "uttarakhand")
        {
            Txtcother.Visible = false;
            Drpcdistname.Visible = true; Txtcdistname.Visible = false;
            Drpctehsil.Visible = true; Txtctehsil.Visible = false;
            Drpcblock.Visible = true; Txtcblock.Visible = false;

            string[] AllQueryParam = new string[1];
            BLL objbllLogin = new BLL();
            //District
            string _sqlQuery = "SELECT DISTINCT DCODE,UPPER(DNAME) AS DNAME FROM UKDISTRICT WHERE DCODE IS NOT NULL ORDER BY DCODE ASC";
            AllQueryParam[0] = _sqlQuery;
            DataTable dtdist = new DataTable();
            objbllLogin.QUERYBLL(ref dtdist, AllQueryParam);
            if (dtdist.Rows.Count > 0)
            {
                Drpcdistname.DataTextField = dtdist.Columns["DNAME"].ToString().Trim();
                Drpcdistname.DataValueField = dtdist.Columns["DNAME"].ToString().Trim();
                Drpcdistname.DataSource = dtdist;
                Drpcdistname.DataBind();
            }
            //Tehsil
            _sqlQuery = "SELECT DISTINCT TCODE,UPPER(TNAME) AS TNAME FROM UKDISTRICT WHERE TCODE IS NOT NULL ORDER BY TCODE ASC";
            AllQueryParam[0] = _sqlQuery;
            DataTable dttehsil = new DataTable();
            objbllLogin.QUERYBLL(ref dttehsil, AllQueryParam);
            if (dttehsil.Rows.Count > 0)
            {
                Drpctehsil.DataTextField = dttehsil.Columns["TNAME"].ToString().Trim();
                Drpctehsil.DataValueField = dttehsil.Columns["TNAME"].ToString().Trim();
                Drpctehsil.DataSource = dttehsil;
                Drpctehsil.DataBind();

            }
            //Block
            _sqlQuery = "SELECT DISTINCT BCODE,UPPER(BNAME) AS BNAME FROM UKDISTRICT WHERE BCODE IS NOT NULL ORDER BY BCODE ASC";
            AllQueryParam[0] = _sqlQuery;
            DataTable dtblock = new DataTable();
            objbllLogin.QUERYBLL(ref dtblock, AllQueryParam);
            if (dtblock.Rows.Count > 0)
            {
                Drpcblock.DataTextField = dtblock.Columns["BNAME"].ToString().Trim();
                Drpcblock.DataValueField = dtblock.Columns["BNAME"].ToString().Trim();
                Drpcblock.DataSource = dtblock;
                Drpcblock.DataBind();
            }
        }
        else
        {
            Drpcdistname.Visible = false; Txtcdistname.Visible = true;
            Drpctehsil.Visible = false; Txtctehsil.Visible = true;
            Drpcblock.Visible = false; Txtcblock.Visible = true;
            Txtcother.Visible = false;
        }
    }
    private void Getpstate()
    {
        if (Drppstate.SelectedValue == "other")
        {
            Drppdistname.Visible = false; Txtpdistname.Visible = true;
            Drpptehsil.Visible = false; Txtptehsil.Visible = true;
            Drppblock.Visible = false; Txtpblock.Visible = true;
            Txtpother.Visible = true;
        }
        else if (Drppstate.SelectedValue == "uttarakhand")
        {
            Txtpother.Visible = false;
            Drppdistname.Visible = true; Txtpdistname.Visible = false;
            Drpptehsil.Visible = true; Txtptehsil.Visible = false;
            Drppblock.Visible = true; Txtpblock.Visible = false;

            string[] AllQueryParam = new string[1];
            BLL objbllLogin = new BLL();
            //District
            string _sqlQuery = "SELECT DISTINCT DCODE,UPPER(DNAME) AS DNAME FROM UKDISTRICT WHERE DCODE IS NOT NULL ORDER BY DCODE ASC";
            AllQueryParam[0] = _sqlQuery;
            DataTable dtdist = new DataTable();
            objbllLogin.QUERYBLL(ref dtdist, AllQueryParam);
            if (dtdist.Rows.Count > 0)
            {
                Drppdistname.DataTextField = dtdist.Columns["DNAME"].ToString().Trim();
                Drppdistname.DataValueField = dtdist.Columns["DNAME"].ToString().Trim();
                Drppdistname.DataSource = dtdist;
                Drppdistname.DataBind();
            }
            //Tehsil
            _sqlQuery = "SELECT DISTINCT TCODE,UPPER(TNAME) AS TNAME FROM UKDISTRICT WHERE TCODE IS NOT NULL ORDER BY TCODE ASC";
            AllQueryParam[0] = _sqlQuery;
            DataTable dttehsil = new DataTable();
            objbllLogin.QUERYBLL(ref dttehsil, AllQueryParam);
            if (dttehsil.Rows.Count > 0)
            {
                Drpptehsil.DataTextField = dttehsil.Columns["TNAME"].ToString().Trim();
                Drpptehsil.DataValueField = dttehsil.Columns["TNAME"].ToString().Trim();
                Drpptehsil.DataSource = dttehsil;
                Drpptehsil.DataBind();
            }
            //Block
            _sqlQuery = "SELECT DISTINCT BCODE,UPPER(BNAME) AS BNAME FROM UKDISTRICT WHERE BCODE IS NOT NULL ORDER BY BCODE ASC";
            AllQueryParam[0] = _sqlQuery;
            DataTable dtblock = new DataTable();
            objbllLogin.QUERYBLL(ref dtblock, AllQueryParam);
            if (dtblock.Rows.Count > 0)
            {
                Drppblock.DataTextField = dtblock.Columns["BNAME"].ToString().Trim();
                Drppblock.DataValueField = dtblock.Columns["BNAME"].ToString().Trim();
                Drppblock.DataSource = dtblock;
                Drppblock.DataBind();
            }
        }
        else
        {
            Drppdistname.Visible = false; Txtpdistname.Visible = true;
            Drpptehsil.Visible = false; Txtptehsil.Visible = true;
            Drppblock.Visible = false; Txtpblock.Visible = true;
            Txtpother.Visible = false;
        }
    }
    
}
