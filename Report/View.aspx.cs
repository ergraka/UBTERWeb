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

public partial class View : System.Web.UI.Page
{
    public string _CANDIDATEID = string.Empty;
    public string _ROLL = string.Empty;
    public string _CANDIDATE_NAME= string.Empty;
    public string _FATHER_NAME = string.Empty;
    public string _SEM = string.Empty;
    public string _NATIONALITY = string.Empty;
    public string _DOB=string.Empty;
    public string _GENDER= string.Empty;
    public string _CATEGORY = string.Empty;
    public string _SUBCAT = string.Empty;
    public string _MONO= string.Empty;
    public string _LLN= string.Empty;
    public string _EMAIL = string.Empty;
    public string _CADDRESS=string.Empty;
    public string _CDISTRICT=string.Empty;
    public string _CSTATE=string.Empty;
    public string _CPIN=string.Empty;
    public string _CTEHSIL = string.Empty;
    public string _CBLOCK = string.Empty;
    public string _ISSAME=string.Empty;
    public string _PADDRESS=string.Empty;
    public string _PDISTRICT=string.Empty;
    public string _PSTATE=string.Empty;
    public string _PPIN = string.Empty;
    public string _PTEHSIL = string.Empty;
    public string _PBLOCK = string.Empty;
    public string _TENUNI= string.Empty;
    public string _TENYEAR= string.Empty;
    public string _TENMO = string.Empty;
    public string _TENMM = string.Empty;
    public string _TENPER= string.Empty;    
    public string _INTERUNI= string.Empty;
    public string _INTERYEAR= string.Empty;
    public string _INTERMO = string.Empty;
    public string _INTERMM = string.Empty;
    public string _INTERPER= string.Empty;
    public string _UG = string.Empty;
    public string _UGUNI = string.Empty;
    public string _UGYEAR= string.Empty;
    public string _UGMO = string.Empty;
    public string _UGMM = string.Empty;
    public string _UGPER= string.Empty;
    public string _PG = string.Empty;
    public string _PGUNI = string.Empty;
    public string _PGYEAR= string.Empty;
    public string _PGMO = string.Empty;
    public string _PGMM = string.Empty;
    public string _PGPER= string.Empty;
    public string _OTH = string.Empty;
    public string _OUNI = string.Empty;
    public string _OYEAR= string.Empty;
    public string _OMO = string.Empty;
    public string _OMM = string.Empty;
    public string _OPER= string.Empty;
    public string _INSTITUTE = string.Empty;
    public string _BRANCH = string.Empty;
    public string _GRP = string.Empty;
    public string _SHIFT = string.Empty;
    public string _FEE = string.Empty;
    public string _FEEDATE = string.Empty;
    public string _COMP = string.Empty;
    public string _REGPVT = string.Empty;

    public string _HPASS = string.Empty;
    public string _HAREA = string.Empty;
    public string _IPASS = string.Empty;
    public string _ITIPASS = string.Empty;
    public string _MINORITY = string.Empty;
    public string _AADHAR = string.Empty;
    public string CP = string.Empty;



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null || Session["ADMIN"] != null) { if (Request.QueryString["AAAAA"] != null) { Session["ID"] = Request.QueryString["AAAAA"].ToString(); } }
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
                    CP = Getsession();

                    _SEM = dt.Rows[0]["SEM"].ToString();
                    string REGPVT = dt.Rows[0]["REGPVT"].ToString();
                    string ISCOMPLETED = string.Empty;
                    if (_SEM == "01" && REGPVT!="P") { ISCOMPLETED = dt.Rows[0]["SEMCOM1"].ToString(); _FEE = dt.Rows[0]["SEMFEE1"].ToString(); }
                    else if (_SEM == "02" && REGPVT != "P") { ISCOMPLETED = dt.Rows[0]["SEMCOM2"].ToString(); _FEE = dt.Rows[0]["SEMFEE2"].ToString(); }
                    else if (_SEM == "03" && REGPVT != "P") { ISCOMPLETED = dt.Rows[0]["SEMCOM3"].ToString(); _FEE = dt.Rows[0]["SEMFEE3"].ToString(); }
                    else if (_SEM == "04" && REGPVT != "P") { ISCOMPLETED = dt.Rows[0]["SEMCOM4"].ToString(); _FEE = dt.Rows[0]["SEMFEE4"].ToString(); }
                    else if (_SEM == "05" && REGPVT != "P") { ISCOMPLETED = dt.Rows[0]["SEMCOM5"].ToString(); _FEE = dt.Rows[0]["SEMFEE5"].ToString(); }
                    else if (_SEM == "06" && REGPVT != "P") { ISCOMPLETED = dt.Rows[0]["SEMCOM6"].ToString(); _FEE = dt.Rows[0]["SEMFEE6"].ToString(); }
                    else if (REGPVT == "P") { _FEE = dt.Rows[0]["SPLFEE"].ToString(); }

                    _FEE = _FEE + "/-";

                   if (REGPVT == "P") { _REGPVT = "PRIVATE"; }
                   else if (REGPVT == "Q") { _REGPVT = "SPECIAL/QUALIFIED"; }
                   else { _REGPVT = "REGULAR"; }

                   _CANDIDATEID = dt.Rows[0]["CANDIDATEID"].ToString();
                   _ROLL = dt.Rows[0]["ROLL"].ToString();
                    _GRP = dt.Rows[0]["GRP"].ToString();
                    _SHIFT = dt.Rows[0]["SHIFT"].ToString();
                    if (_SHIFT == "I") { _SHIFT = "FIRST"; }
                    else if (_SHIFT == "II") { _SHIFT = "SECOND"; }
                    _CANDIDATE_NAME = dt.Rows[0]["CNAME"].ToString();
                    _FATHER_NAME = dt.Rows[0]["FNAME"].ToString();
                    _INSTITUTE = dt.Rows[0]["INSNAME"].ToString();
                    _BRANCH = dt.Rows[0]["BRNAME"].ToString();
                    _NATIONALITY = dt.Rows[0]["NATION"].ToString().Trim(); if (_NATIONALITY == "IND") { _NATIONALITY = "INDIAN"; }
                    _DOB = dt.Rows[0]["DOB"].ToString();
                    _GENDER = dt.Rows[0]["GENDER"].ToString();
                    if (_GENDER == "M") { _GENDER = "MALE"; } else if (_GENDER == "F") { _GENDER = "FEMALE"; } else if (_GENDER == "T") { _GENDER = "TRANSGENDER"; }
                    _CATEGORY = dt.Rows[0]["CAT"].ToString();

                    if (_CATEGORY == "GEN") { _CATEGORY = "General(GEN)"; }
                    else if (_CATEGORY == "OBC") { _CATEGORY = "Other Backward Caste(OBC)"; }
                    else if (_CATEGORY == "SC") { _CATEGORY = "Scheduled Caste(SC)"; }
                    else if (_CATEGORY == "ST") { _CATEGORY = "Scheduled Tribes(ST)"; }
                    else if (_CATEGORY == "EWS") { _CATEGORY = "Economically Weaker Section(EWS)"; }
                    else if (_CATEGORY == "TFW") { _CATEGORY = "Tuition Fee Waiver(TFW)"; }
                    _SUBCAT = dt.Rows[0]["SUBCAT"].ToString();
                    if (_SUBCAT == "DFF") { _SUBCAT = "Dependent Freedom Fighter(D.F.F)"; }
                    else if (_SUBCAT == "MP") { _SUBCAT = "Military Person(M.P)"; }
                    else if (_SUBCAT == "PH") { _SUBCAT = "Physical Handicap(P.H)"; }
                    else if (_SUBCAT == "WO") { _SUBCAT = "Women(WO)"; }
                    else if (_SUBCAT == "N") { _SUBCAT = "None"; }

                    _MINORITY = dt.Rows[0]["MINORITY"].ToString();
                    if (_MINORITY == "Y") { _MINORITY = "Yes"; }
                    else if (_MINORITY == "N") { _MINORITY = "No"; }
                    _AADHAR = dt.Rows[0]["AADHAR"].ToString();

                    _MONO = dt.Rows[0]["MONO"].ToString();
                    _LLN = dt.Rows[0]["LLN"].ToString();
                    _EMAIL = dt.Rows[0]["EMAIL"].ToString();
                    _HPASS = dt.Rows[0]["HPASS"].ToString(); if (_HPASS == "Y") { _HPASS = "Yes"; } else if (_HPASS == "N") { _HPASS = "No"; }
                    _HAREA = dt.Rows[0]["HAREA"].ToString(); if (_HAREA == "U") { _HAREA = "Urban"; } else if (_HAREA == "R") { _HAREA = "Rural"; }
                    _IPASS = dt.Rows[0]["IPASS"].ToString(); if (_IPASS == "Y") { _IPASS = "Yes"; } else if (_IPASS == "N") { _IPASS = "No"; }
                    _ITIPASS = dt.Rows[0]["ITIPASS"].ToString(); if (_ITIPASS == "Y") { _ITIPASS = "Yes"; } else if (_ITIPASS == "N") { _ITIPASS = "No"; }
                    _CADDRESS = dt.Rows[0]["CADDRESS"].ToString();
                    _CDISTRICT = dt.Rows[0]["CDISTRICT"].ToString();
                    _CSTATE = dt.Rows[0]["CSTATE"].ToString();
                    _CTEHSIL = dt.Rows[0]["CTEHSIL"].ToString();
                    _CBLOCK = dt.Rows[0]["CBLOCK"].ToString();
                    _CPIN = dt.Rows[0]["CPIN"].ToString();
                    _ISSAME = dt.Rows[0]["ISSAME"].ToString();
                    _PADDRESS = dt.Rows[0]["PADDRESS"].ToString();
                    _PDISTRICT = dt.Rows[0]["PDISTRICT"].ToString();
                    _PSTATE = dt.Rows[0]["PSTATE"].ToString();
                    _PTEHSIL = dt.Rows[0]["PTEHSIL"].ToString();
                    _PBLOCK = dt.Rows[0]["PBLOCK"].ToString();
                    _PPIN = dt.Rows[0]["PPIN"].ToString();
                    _TENUNI = dt.Rows[0]["TENUNI"].ToString();
                    _TENYEAR = dt.Rows[0]["TENYEAR"].ToString();
                    _TENMO = dt.Rows[0]["TENMO"].ToString();
                    _TENMM = dt.Rows[0]["TENMM"].ToString();
                    _TENPER = dt.Rows[0]["TENPER"].ToString();
                    _INTERUNI = dt.Rows[0]["INTERUNI"].ToString();
                    _INTERYEAR = dt.Rows[0]["INTERYEAR"].ToString();
                    _INTERMO = dt.Rows[0]["INTERMO"].ToString();
                    _INTERMM = dt.Rows[0]["INTERMM"].ToString();
                    _INTERPER = dt.Rows[0]["INTERPER"].ToString();
                    _UG = dt.Rows[0]["UG"].ToString();
                    _UGUNI = dt.Rows[0]["UGUNI"].ToString();
                    _UGYEAR = dt.Rows[0]["UGYEAR"].ToString(); if (_UGYEAR == "Per") { _UGYEAR = "Pursuing"; }
                    _UGMO = dt.Rows[0]["UGMO"].ToString();
                    _UGMM = dt.Rows[0]["UGMM"].ToString();
                    _UGPER = dt.Rows[0]["UGPER"].ToString();
                    _PG = dt.Rows[0]["PG"].ToString();
                    _PGUNI = dt.Rows[0]["PGUNI"].ToString();
                    _PGYEAR = dt.Rows[0]["PGYEAR"].ToString(); if (_PGYEAR == "Per") { _PGYEAR = "Pursuing"; }
                    _PGMO = dt.Rows[0]["PGMO"].ToString();
                    _PGMM = dt.Rows[0]["PGMM"].ToString();
                    _PGPER = dt.Rows[0]["PGPER"].ToString();
                    _OTH = dt.Rows[0]["OTH"].ToString();
                    _OUNI = dt.Rows[0]["OUNI"].ToString();
                    _OYEAR = dt.Rows[0]["OYEAR"].ToString();
                    _OMO = dt.Rows[0]["OMO"].ToString();
                    _OMM = dt.Rows[0]["OMM"].ToString();
                    _OPER = dt.Rows[0]["OPER"].ToString();
                   
                   

                    _FEEDATE = dt.Rows[0]["FEEDATE"].ToString();
                    string GRP = dt.Rows[0]["GRP"].ToString().Trim();
                    string CAT = dt.Rows[0]["CAT"].ToString().Trim();
                    if (GRP == "E") { _COMP = "Obtained at least 35% marks at qualifying examination(10th) with Science and math."; }
                    else if (GRP == "P") { _COMP = "Intermediate/10+2 Qualified with PCB OR PCM."; }
                    else if (GRP == "H")
                    {
                        if (CAT == "SC" || CAT == "ST") { _COMP = "Intermediate/10+2 or Equivalent Qualified with 40% marks and with English."; }
                        else { _COMP = "Intermediate/10+2 or Equivalent Qualified with 45% marks and with English."; }
                    }
                    else if (GRP == "M") { _COMP = "Intermediate/10+2 or Equivalent Qualified(Qualified 10th OR 10+2 with Hindi and English)."; }
                    else if (GRP == "G") { _COMP = "Graduation Qualified ?."; }
                    if (GRP == "T") { _COMP = "Obtained at least 35% marks at qualifying examination(10th) ?(Only for women students)."; }
                    if (GRP == "A") { _COMP = "1.10+2 Qualified with Physics, Chemistry and Math ? OR </br>2.10+2 Qualified with Commerce/Technical Subject OR </br> 3.Two years I.T.I Qualified ?"; }
                    ImgPH.ImageUrl = "http://ubterex.in/Upload/Photo/" + _CANDIDATEID + "P.jpg";
                    ImgSign.ImageUrl = "http://ubterex.in/Upload/Sign/" + _CANDIDATEID + "S.jpg";
                }
                else { Response.Redirect("~/Default.aspx", false); }
            }
            else { Response.Redirect("~/Default.aspx", false); }
        }
        catch (Exception ex) { Response.Write(ex.Message); }
    }
    protected void Imghome_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Session["ID"] != null) { Response.Redirect("~/Student/Stuhome.aspx?mode=home", false); }
            else { Response.Redirect("~/Default.aspx", false); }
        }
        catch (Exception ex) { }
    }
    protected void Imglogout_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["ID"] = null;
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("~/Default.aspx", false);
        }
        catch (Exception ex)
        {
            Response.Write("Please try after some time.");
        }
    }
    private string Getsession()
    {
        //Get Regsession
        string SESS = string.Empty;
        DataTable dtsess = new DataTable();
        string _sqlQueryreg = "select * FROM FORMSESS WHERE SESSNAME='FORM'";
        BLL objbllreg = new BLL();
        string[] AllQueryParamreg = new string[1];
        AllQueryParamreg[0] = _sqlQueryreg;
        objbllreg.QUERYBLL(ref dtsess, AllQueryParamreg);
        if (dtsess.Rows.Count > 0)
        {
            SESS = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
            string S1 = SESS.Substring(0, 2);
            string S2 = SESS.Substring(2, 5);
            if (S1 == "06") { SESS = "SUMMER" + S2; }
            else if (S1 == "12") { SESS = "WINTER" + S2; }
        }
        return SESS;
    }

}