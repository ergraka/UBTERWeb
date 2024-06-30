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
using System.IO;
public partial class Qualification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Txt12MO.Attributes.Add("Onblur", "Per12();");
            Txt12MM.Attributes.Add("Onblur", "Per12();");
            TxtUGMO.Attributes.Add("Onblur", "PerUG();");
            TxtUGMM.Attributes.Add("Onblur", "PerUG();");
            TxtPGMO.Attributes.Add("Onblur", "PerPG();");
            TxtPGMM.Attributes.Add("Onblur", "PerPG();");
            TxtOMO.Attributes.Add("Onblur", "PerO();");
            TxtOMM.Attributes.Add("Onblur", "PerO();");
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
                            if (Session["Edit"].ToString() == "ADD") { Response.Redirect("Address.aspx", false); }
                            if (Session["Edit"].ToString() == "PH") { Response.Redirect("PhotoSign.aspx", false); }

                            Drpcomp.SelectedValue = "Y";
                            Button1.Text = "Submit";
                            Txt10Board.Text = dt.Rows[0]["TENUNI"].ToString().ToUpper();
                            Drp10Year.SelectedValue = dt.Rows[0]["TENYEAR"].ToString().ToUpper();
                            Txt10Per.Text = dt.Rows[0]["TENPER"].ToString().ToUpper();
                            Txt12Board.Text = dt.Rows[0]["INTERUNI"].ToString().ToUpper();
                            Drp12Year.SelectedValue = dt.Rows[0]["INTERYEAR"].ToString().ToUpper();
                            Txt12MO.Text = dt.Rows[0]["INTERMO"].ToString().ToUpper();
                            Txt12MM.Text = dt.Rows[0]["INTERMM"].ToString().ToUpper();
                            Txt12Per.Text = dt.Rows[0]["INTERPER"].ToString().ToUpper();
                            TxtUG.Text = dt.Rows[0]["UG"].ToString().ToUpper();
                            TxtUGUni.Text = dt.Rows[0]["UGUNI"].ToString().ToUpper();
                            DrpUGYear.SelectedValue = dt.Rows[0]["UGYEAR"].ToString().ToUpper();
                            TxtUGMO.Text = dt.Rows[0]["UGMO"].ToString().ToUpper();
                            TxtUGMM.Text = dt.Rows[0]["UGMM"].ToString().ToUpper();
                            TxtUGPer.Text = dt.Rows[0]["UGPER"].ToString().ToUpper();
                            TxtPG.Text = dt.Rows[0]["PG"].ToString().ToUpper();
                            TxtPGUni.Text = dt.Rows[0]["PGUNI"].ToString().ToUpper();
                            DrpPGYear.SelectedValue = dt.Rows[0]["PGYEAR"].ToString().ToUpper();
                            TxtPGMO.Text = dt.Rows[0]["PGMO"].ToString().ToUpper();
                            TxtPGMM.Text = dt.Rows[0]["PGMM"].ToString().ToUpper();
                            TxtPGPer.Text = dt.Rows[0]["PGPER"].ToString().ToUpper();
                            TxtOTH.Text = dt.Rows[0]["OTH"].ToString().ToUpper();
                            TxtOUni.Text = dt.Rows[0]["OUNI"].ToString().ToUpper();
                            DrpOYear.SelectedValue = dt.Rows[0]["OYEAR"].ToString().ToUpper();
                            TxtOMO.Text = dt.Rows[0]["OMO"].ToString().ToUpper();
                            TxtOMM.Text = dt.Rows[0]["OMM"].ToString().ToUpper();
                            TxtOPer.Text = dt.Rows[0]["OPER"].ToString().ToUpper();
                            Drphpass.SelectedValue = dt.Rows[0]["HPASS"].ToString().ToUpper();
                            Drpharea.SelectedValue = dt.Rows[0]["HAREA"].ToString().ToUpper();
                            Drpipass.SelectedValue = dt.Rows[0]["IPASS"].ToString().ToUpper();
                            Drpitipass.SelectedValue = dt.Rows[0]["ITIPASS"].ToString().ToUpper();

                            string GRP = dt.Rows[0]["GRP"].ToString().Trim();
                            Session["GRP"] = GRP;
                            string CAT = dt.Rows[0]["CAT"].ToString().Trim();
                            if (GRP == "E") { Lblcomplesary.Text = "Obtained at least 35% marks at qualifying examination(10th) with Science and math."; }
                            else if (GRP == "P") { Lblcomplesary.Text = "Intermediate/10+2 Qualified with PCB OR PCM."; }
                            else if (GRP == "H")
                            {
                                if (CAT == "SC" || CAT == "ST") { Lblcomplesary.Text = "Intermediate/10+2 or Equivalent Qualified with 40% marks and with English."; }
                                else { Lblcomplesary.Text = "Intermediate/10+2 or Equivalent Qualified with 45% marks and with English."; }
                            }
                            else if (GRP == "M") { Lblcomplesary.Text = "Intermediate/10+2 or Equivalent Qualified(Qualified 10th OR 10+2 with Hindi and English)."; }
                            else if (GRP == "G") { Lblcomplesary.Text = "Graduation Qualified ?."; }
                            if (GRP == "T") { Lblcomplesary.Text = "Obtained at least 35% marks at qualifying examination(10th) ?(Only for women students)."; }
                            if (GRP == "A") { Lblcomplesary.Text = "1.10+2 Qualified with Physics, Chemistry and Math ? OR </br>2.10+2 Qualified with Commerce/Technical Subject OR </br> 3.Two years I.T.I Qualified ?"; }
                        }
                        else
                        {
                            string GRP = dt.Rows[0]["GRP"].ToString().Trim();
                            Session["GRP"] = GRP;
                            string CAT = dt.Rows[0]["CAT"].ToString().Trim();


                            if (GRP == "E") { Lblcomplesary.Text = "Obtained at least 35% marks at qualifying examination(10th) with Science and math."; }
                            else if (GRP == "P") { Lblcomplesary.Text = "Intermediate/10+2 Qualified with PCB OR PCM."; }
                            else if (GRP == "H")
                            {
                                if (CAT == "SC" || CAT == "ST") { Lblcomplesary.Text = "Intermediate/10+2 or Equivalent Qualified with 40% marks and with English."; }
                                else { Lblcomplesary.Text = "Intermediate/10+2 or Equivalent Qualified with 45% marks and with English."; }
                            }
                            else if (GRP == "M") { Lblcomplesary.Text = "Intermediate/10+2 or Equivalent Qualified(Qualified 10th OR 10+2 with Hindi and English)."; }
                            else if (GRP == "G") { Lblcomplesary.Text = "Graduation Qualified ?."; }
                            if (GRP == "T") { Lblcomplesary.Text = "Obtained at least 35% marks at qualifying examination(10th) ?(Only for women students)."; }
                            if (GRP == "A") { Lblcomplesary.Text = "1.10+2 Qualified with Physics, Chemistry and Math ? OR </br>2.10+2 Qualified with Commerce/Technical Subject OR </br> 3.Two years I.T.I Qualified ?"; }
                            string ISQUA = dt.Rows[0]["ISQUA"].ToString().Trim();
                            if (ISQUA == "True") { Response.Redirect("Address.aspx", false); }
                        }
                    }
                }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    private bool Validation()
    {
        if (Txt10Board.Text.Trim() == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter 10th Board Name.');", true); return false; }
        if (Drp10Year.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select 10th Passing Year.');", true); return false; }
        if (Txt10Per.Text.Trim() == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter 10th Percentage OR Grade Or Points.');", true); return false; }
        if (Drpcomp.SelectedValue != "Y") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Fill all Compulsory Fields.');", true); return false; }
        if (Drphpass.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select High School Pass ?');", true); return false; }
        if (Drpharea.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select High School Area Type.');", true); return false; }
        if (Drpipass.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Intermediate Pass ?');", true); return false; }
        if (Drpitipass.SelectedIndex == 0) { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select I.T.I Pass Or Not ?');", true); return false; }
        return true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] != null)
            {
                bool chk = Validation();
                if (chk == true)
                {
                    if (Session["GRP"] != null) { INSERTDATA(); Session["Edit"] = null; Session["GRP"] = null; } else { ltrlMessage.Text = "Please try after some time."; }
                }
                else
                {
                    ltrlMessage.Text = "Please Fill all Fields Correctly OR Fill all Required Fields(according to applied Group).";
                    ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Please Fill all Fields Correctly OR Fill all Required Fields(according to applied Group).')</script>", false);
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            ltrlMessage.Text = "Due to technical issue.The registration can not complete. Please try after some time";
        }
    }
    private void INSERTDATA()
    {
        BEL ObjBEL = new BEL();
        ObjBEL.QuaCandidateId = Session["ID"].ToString().Trim();
        ObjBEL.TENUNI = Txt10Board.Text.ToUpper().Trim();
        ObjBEL.TENYEAR = Drp10Year.SelectedValue;
        ObjBEL.TENMO = "";
        ObjBEL.TENMM = "";
        ObjBEL.TENPER = Txt10Per.Text.ToUpper().Trim();
        ObjBEL.INTERUNI = Txt12Board.Text.ToUpper().Trim();
        ObjBEL.INTERYEAR = Drp12Year.SelectedValue;
        ObjBEL.INTERMO = Txt12MO.Text.ToUpper().Trim();
        ObjBEL.INTERMM = Txt12MM.Text.ToUpper().Trim();
        ObjBEL.INTERPER = Txt12Per.Text.ToUpper().Trim();
        ObjBEL.UG = TxtUG.Text.ToUpper().Trim();
        ObjBEL.UGUNI = TxtUGUni.Text.ToUpper().Trim();
        ObjBEL.UGYEAR = DrpUGYear.SelectedValue;
        ObjBEL.UGMO = TxtUGMO.Text.ToUpper().Trim();
        ObjBEL.UGMM = TxtUGMM.Text.ToUpper().Trim();
        ObjBEL.UGPER = TxtUGPer.Text.ToUpper().Trim();
        ObjBEL.PG = TxtPG.Text.ToUpper().Trim();
        ObjBEL.PGUNI = TxtPGUni.Text.ToUpper().Trim();
        ObjBEL.PGYEAR = DrpPGYear.SelectedValue;
        ObjBEL.PGMO = TxtPGMO.Text.ToUpper().Trim();
        ObjBEL.PGMM = TxtPGMM.Text.ToUpper().Trim();
        ObjBEL.PGPER = TxtPGPer.Text.ToUpper().Trim();
        ObjBEL.OTH = TxtOTH.Text.ToUpper().Trim();
        ObjBEL.OUNI = TxtOUni.Text.ToUpper().Trim();
        ObjBEL.OYEAR = DrpOYear.SelectedValue;
        ObjBEL.OMO = TxtOMO.Text.ToUpper().Trim();
        ObjBEL.OMM = TxtOMM.Text.ToUpper().Trim();
        ObjBEL.OPER = TxtOPer.Text.ToUpper().Trim();
        ObjBEL.HPASS = Drphpass.SelectedValue;
        ObjBEL.HAREA = Drpharea.SelectedValue;
        ObjBEL.IPASS = Drpipass.SelectedValue;
        ObjBEL.ITIPASS = Drpitipass.SelectedValue;
        BLL _ObjBLL = new BLL();
        string Result = _ObjBLL._QUABLL(ObjBEL);
        if (Result == "1-1")
        {
            Response.Redirect("Address.aspx", false);
        }
        else
        {
            ltrlMessage.Text = "Server Busy!!!!!!";
        }
    }
}
