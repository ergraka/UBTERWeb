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

public partial class Registration : System.Web.UI.Page
{
    string _candidateId = string.Empty;
    public int noOfDays = 0;
    public int noOfMonths = 0;
    public int noOfYears = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                if (!IsPostBack)
                {
                    GenerateRandomCode();
                    string _sqlQueryreg = string.Empty;
                    DataTable dtreg = new DataTable();
                    string[] AllQueryParamreg = new string[1];
                    _sqlQueryreg = "select * from REGISTRATION where STAT='A' AND CANDIDATEID='" + Session["ID"].ToString() + "'";
                    AllQueryParamreg[0] = _sqlQueryreg;
                    BLL objbllreg = new BLL();
                    objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                    if (dtreg.Rows.Count > 0)
                    {
                        Lblinscode.Text = dtreg.Rows[0]["INSCODE"].ToString().ToUpper();
                        Lblinsname.Text = dtreg.Rows[0]["INSNAME"].ToString().ToUpper();
                        Lblregcat.Text = dtreg.Rows[0]["REGCAT"].ToString().ToUpper();
                        Lblbrcode.Text = dtreg.Rows[0]["BRCODE"].ToString().ToUpper();
                        Lblbrname.Text = dtreg.Rows[0]["BRNAME"].ToString().ToUpper();
                        Lblregid.Text = dtreg.Rows[0]["CANDIDATEID"].ToString().ToUpper();
                        Lblgroup.Text = dtreg.Rows[0]["GRP"].ToString().ToUpper();
                        Txtcname.Text = dtreg.Rows[0]["CNAME"].ToString().ToUpper();
                        Txtfathername.Text = dtreg.Rows[0]["FNAME"].ToString().ToUpper();
                        Lblshift.Text = dtreg.Rows[0]["SHIFT"].ToString().Trim();
                        string[] DOB = dtreg.Rows[0]["DOB"].ToString().Split('/');
                        Drpday.SelectedValue = DOB[0].ToString();
                        Drpmonth.SelectedValue = DOB[1].ToString();
                        Drpyear.SelectedValue = DOB[2].ToString();
                        string GRP = dtreg.Rows[0]["GRP"].ToString().Trim();
                        if (GRP == "T") { Drpgender.SelectedValue = "F"; Drpgender.Enabled = false; }
                    }
                    if (Session["Edit"] != null)
                    {
                        if (Session["Edit"].ToString() == "QUA") { Response.Redirect("Qualification.aspx", false); }
                        if (Session["Edit"].ToString() == "ADD") { Response.Redirect("Address.aspx", false); }
                        if (Session["Edit"].ToString() == "PH") { Response.Redirect("PhotoSign.aspx", false); }

                        Button1.Text = "Submit";
                        DataTable dt = new DataTable();
                        string[] AllQueryParam = new string[1];
                        string _sqlQuery = "select * from REGISTRATION where STAT='A' AND CANDIDATEID='" + Session["ID"].ToString() + "'";
                        AllQueryParam[0] = _sqlQuery;
                        BLL objbllLogin = new BLL();
                        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                        if (dt.Rows.Count > 0)
                        {
                            Lblinscode.Text = dtreg.Rows[0]["INSCODE"].ToString().ToUpper();
                            Lblinsname.Text = dtreg.Rows[0]["INSNAME"].ToString().ToUpper();
                            Lblregcat.Text = dtreg.Rows[0]["REGCAT"].ToString().ToUpper();
                            Lblbrcode.Text = dtreg.Rows[0]["BRCODE"].ToString().ToUpper();
                            Lblbrname.Text = dtreg.Rows[0]["BRNAME"].ToString().ToUpper();
                            Lblregid.Text = dtreg.Rows[0]["CANDIDATEID"].ToString().ToUpper();
                            Lblgroup.Text = dtreg.Rows[0]["GRP"].ToString().ToUpper();
                            Txtcname.Text = dtreg.Rows[0]["CNAME"].ToString().ToUpper();
                            Txtfathername.Text = dtreg.Rows[0]["FNAME"].ToString().ToUpper();
                            string[] DOB = dt.Rows[0]["DOB"].ToString().Split('/');
                            Drpday.SelectedValue = DOB[0].ToString();
                            Drpmonth.SelectedValue = DOB[1].ToString();
                            Drpyear.SelectedValue = DOB[2].ToString();
                            string GRP = dt.Rows[0]["GRP"].ToString().Trim();
                            if (GRP == "T") { Drpgender.SelectedValue = "F"; Drpgender.Enabled = false; }
                            else { Drpgender.SelectedValue = dt.Rows[0]["GENDER"].ToString().Trim(); }
                            Drpcat.SelectedValue = dt.Rows[0]["CAT"].ToString().Trim();
                            Drpsubcat.SelectedValue = dt.Rows[0]["SUBCAT"].ToString().Trim();
                            Drpminority.SelectedValue = dt.Rows[0]["MINORITY"].ToString().Trim();
                            string NATION = dt.Rows[0]["NATION"].ToString().Trim();
                            if (NATION == "IND") { DrpNationality.SelectedValue = NATION; TxtNationalityOth.Visible = false; }
                            else { TxtNationalityOth.Visible = true; TxtNationalityOth.Text = dt.Rows[0]["NATION"].ToString().Trim(); DrpNationality.SelectedValue = "OTH"; }
                            TxtMono.Text = dt.Rows[0]["MONO"].ToString().Trim();
                            string LLNNO = dt.Rows[0]["LLN"].ToString().Trim();
                            if (LLNNO != "-")
                            {
                                string[] LLN = dt.Rows[0]["LLN"].ToString().Split('-');
                                Txtstdcode.Text = LLN[0].ToString();
                                TxtLLN.Text = LLN[1].ToString();
                            }
                            Txtemail.Text = dt.Rows[0]["EMAIL"].ToString().Trim();
                            Txtcemail.Text = dt.Rows[0]["EMAIL"].ToString().Trim();
                            Txtaadhar.Text = dt.Rows[0]["AADHAR"].ToString().Trim();
                        }
                    }
                }
            }
            else { Response.Redirect("Login.aspx", false); }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    private bool Validation()
    {
        if (Txtcname.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Candidate Name.');", true); return false; }
        if (Txtfathername.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Father Name.');", true); return false; }
        if (Drpday.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Birth Day.');", true); return false; }
        if (Drpmonth.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Birth Month.');", true); return false; }
        if (Drpyear.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Birth Year.');", true); return false; }
        if (Drpgender.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Gender.');", true); return false; }
        if (Drpcat.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Category.');", true); return false; }
        if (Drpsubcat.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Sub Category.');", true); return false; }
        if (Drpminority.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Minority.');", true); return false; }
        if (DrpNationality.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Nationality.');", true); return false; }
        if (DrpNationality.SelectedValue == "IND" && Txtaadhar.Text.Length != 12) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Correct Aadhar Number.');", true); return false; }
        if (DrpNationality.SelectedValue == "OTH" && TxtNationalityOth.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Nationality.');", true); return false; }
        if (TxtMono.Text.Length != 10) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Mobile Number.');", true); return false; }
        if (Txtemail.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Email ID.');", true); return false; }
        if (Txtemail.Text != Txtcemail.Text) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Both Email Id Not Match.');", true); return false; }
        return true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                
                if (Lblcaptch.Text == TxtCaptcha.Text)
                {
                    TxtCaptcha.Text = "";
                    if (IsPostBack)
                    {
                        bool chk = Validation();
                        if (chk == true)
                        {
                            INSERTDATA();
                        }
                        else { ltrlMessage.Text = "Please Fill all Values."; }
                    }
                }
                else { GenerateRandomCode(); ltrlMessage.Text = "Incorrect Captcha Value."; }
            }
            else { Response.Redirect("Login.aspx"); }
        }
        catch (Exception ex)
        {
            GenerateRandomCode();
            ltrlMessage.Text = "Please try after some time.";
        }
    }

    private void INSERTDATA()
    {
        BEL ObjBEL = new BEL();
        ObjBEL.CANDIDATEID = Session["ID"].ToString();
        ObjBEL.GENDER = Drpgender.SelectedValue;
        ObjBEL.CAT = Drpcat.SelectedValue;
        ObjBEL.SUBCAT = Drpsubcat.SelectedValue;
        if (DrpNationality.SelectedValue == "IND") { ObjBEL.NATION = "IND"; }
        else { ObjBEL.NATION = TxtNationalityOth.Text.ToUpper(); }
        ObjBEL.MONO = TxtMono.Text.ToUpper().Trim();
        ObjBEL.LLN = Txtstdcode.Text.ToUpper().Trim() + "-" + TxtLLN.Text.ToUpper().Trim();
        ObjBEL.EMAIL = Txtemail.Text.ToUpper().Trim();
        ObjBEL.MINORITY = Drpminority.Text.ToUpper().Trim();
        ObjBEL.AADHAR = Txtaadhar.Text.ToUpper().Trim();
        BLL _ObjBLL = new BLL();
        string Result = _ObjBLL._Registration(ObjBEL);
        if (Result == "1-1")
        {
            if (Session["EDIT"] != null) { Session["EDIT"] = null; Response.Redirect("Stuhome.aspx", false); }
            else { Response.Redirect("Qualification.aspx", false); }
        }
        else { GenerateRandomCode(); ltrlMessage.Text = "Server Busy!!!!!!"; }
    }
    protected void Drpmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                Drpyear.SelectedIndex = 0;
                ltrlMessage.Text = "";
            }
            else { Response.Redirect("Login.aspx"); }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }

    }
    protected void Drpday_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                Drpmonth.SelectedIndex = 0;
                Drpyear.SelectedIndex = 0;
                ltrlMessage.Text = "";
            }
            else { Response.Redirect("Login.aspx"); }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void DrpNationality_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                if (DrpNationality.SelectedIndex == 2)
                {
                    LblNationalityOth.Visible = true;
                    TxtNationalityOth.Visible = true;
                }
                else
                {
                    LblNationalityOth.Visible = false;
                    TxtNationalityOth.Visible = false;
                }
            }
            else { Response.Redirect("Login.aspx"); }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Imgbtncapcha_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                GenerateRandomCode();
            }
            else { Response.Redirect("Login.aspx"); }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    private void GenerateRandomCode()
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
        Lblcaptch.Text = s;

        //GENERATE IMAGE***********************************************************************************************
        //Bitmap bitmap = new Bitmap(1, 1);
        //Font font = new Font("Arial", 25, FontStyle.Regular, GraphicsUnit.Pixel);
        //Graphics graphics = Graphics.FromImage(bitmap);
        //int width = (int)graphics.MeasureString(text, font).Width;
        //int height = (int)graphics.MeasureString(text, font).Height;
        //bitmap = new Bitmap(bitmap, new Size(width, height));
        //graphics = Graphics.FromImage(bitmap);
        //graphics.Clear(Color.White);
        //graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        //graphics.DrawString(text, font, new SolidBrush(Color.FromArgb(255, 0, 0)), 0, 0);
        //graphics.Flush();
        //graphics.Dispose();
        //bitmap.Save(Server.MapPath("~/Images/Captcha.jpg"), ImageFormat.Jpeg);
        //Imgcap.ImageUrl = "~/Images/Captcha.jpg";
        //***************************************************************************************************************
    }
}

