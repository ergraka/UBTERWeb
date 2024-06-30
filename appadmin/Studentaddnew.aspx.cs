using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using _Examination;
using System.Text.RegularExpressions;

public partial class Studentaddnew : System.Web.UI.Page
{
    string SEM = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (!IsPostBack)
            {
                string _sqlQueryreg = string.Empty;
                BLL objbllreg = new BLL();
                string[] AllQueryParamreg = new string[1];

                DataTable dtreg = new DataTable();
                _sqlQueryreg = "select distinct INSCODE,INSNAME from INSLOGIN order by INSCODE asc";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                if (dtreg.Rows.Count > 0)
                {
                    Drpins.DataValueField = dtreg.Columns["INSCODE"].ToString().Trim();
                    Drpins.DataTextField = dtreg.Columns["INSNAME"].ToString().Trim();
                    Drpins.DataSource = dtreg;
                    Drpins.DataBind();
                    if (Drpins.Items.Count > 0) { Drpins.SelectedIndex = 0; }
                }
                else { Response.Redirect("~/Error.aspx", true); }

                //Get Regsession
                DataTable dtsess = new DataTable();
                _sqlQueryreg = "select * FROM FORMSESS WHERE SESSNAME='REG'";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtsess, AllQueryParamreg);
                if (dtsess.Rows.Count > 0)
                {
                    Txtsession.Text = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
                    Txtsession.Enabled = false;
                }



                TRPVT.Visible = true;
                TRJEEPROLL.Visible = false;
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Drpins_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpins.SelectedIndex > 0)
            {
                string _sqlQueryreg = string.Empty;
                string[] AllQueryParamreg = new string[1];
                BLL objbllreg = new BLL();
                //Get Branch
                DataTable dtins = new DataTable();
                _sqlQueryreg = "select * from BRLOGIN where INSCODE='" + Drpins.SelectedValue + "' order by BRCODE asc";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtins, AllQueryParamreg);
                if (dtins.Rows.Count > 0)
                {
                    Drpbranch.DataValueField = dtins.Columns["BRCODE"].ToString().Trim();
                    Drpbranch.DataTextField = dtins.Columns["BRNAME"].ToString().Trim();
                    Drpbranch.DataSource = dtins;
                    Drpbranch.DataBind();
                    if (Drpbranch.Items.Count > 0) { Drpbranch.SelectedIndex = 0; }
                }
                else { Response.Redirect("~/Error.aspx", true); }
                //Get Institute Category
                DataTable dtstatus = new DataTable();
                _sqlQueryreg = "select * from INSLOGIN where INSCODE='" + Drpins.SelectedValue + "'";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtstatus, AllQueryParamreg);
                if (dtstatus.Rows.Count > 0)
                {
                    Lblregcat.Text = dtstatus.Rows[0]["STATUS"].ToString().Trim();
                }
                else { Response.Redirect("~/Error.aspx", true); }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            bool chk = Validation();
            if (chk == true)
            {
                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                string[] AllQueryParamreg = new string[1];
                _sqlQueryreg = "select GRP from BRLOGIN where INSCODE='" + Drpins.SelectedValue + "' and BRCODE='" + Drpbranch.SelectedValue + "'";
                AllQueryParamreg[0] = _sqlQueryreg;
                BLL objbllreg = new BLL();
                objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                if (dtreg.Rows.Count > 0)
                {
                    string GORP = dtreg.Rows[0]["GRP"].ToString();
                    if ((GORP == "E" && Drpgrp.SelectedValue == "A") || (GORP == Drpgrp.SelectedValue))
                    {
                        INSERTDATA();
                    }
                    else { ltrlMessage.Text = "Selected Group are not valid for this branch."; }
                }
                else { Response.Redirect("~/Error.aspx", false); }
            }
            else { ltrlMessage.Text = "Please Fill OR Select all details correctlly."; }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    private string GenerateRandomCode()
    {
        Random random = new Random();
        string pwd = string.Empty;
        for (int i = 0; i < 8; i++)
        {
            pwd = pwd + Convert.ToString(random.Next(0, 9));
        }
        return pwd.ToString();
    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Txtjeeproll.Text != "")
            {
                GROUP();
                Lblcjeep.Text = string.Empty; Txtrank.Text = string.Empty;
                Txtcname.Text = string.Empty; Txtfname.Text = string.Empty;
                Drpday.SelectedIndex = 0; Drpmonth.SelectedIndex = 0; Drpyear.SelectedIndex = 0;
                Txtfee.Text = string.Empty; Txtfeedate.Text = string.Empty;
                Lblusename.Text = string.Empty;
                Lblpassword.Text = string.Empty;
                ltrlMessage.Text = string.Empty;

                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                string[] AllQueryParamreg = new string[1];
                _sqlQueryreg = "select * from JEEPRNK where ROLL='" + Txtjeeproll.Text + "'";
                AllQueryParamreg[0] = _sqlQueryreg;
                BLL objbllreg = new BLL();
                objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                if (dtreg.Rows.Count > 0)
                {
                    string GRP = dtreg.Rows[0]["GRP"].ToString().Trim();
                    if (GRP == "A" && Drpgrp.SelectedValue == "E") { Drpgrp.SelectedValue = "A"; }
                    if (GRP == Drpgrp.SelectedValue)
                    {
                        Lblcjeep.Text = Txtjeeproll.Text;
                        Txtcname.Text = dtreg.Rows[0]["CNAME"].ToString().Trim();
                        Txtfname.Text = dtreg.Rows[0]["FNAME"].ToString().Trim();
                        string[] DOB = dtreg.Rows[0]["DOB"].ToString().Split('/');
                        Drpday.SelectedValue = DOB[0].ToString();
                        Drpmonth.SelectedValue = DOB[1].ToString();
                        Drpyear.SelectedValue = DOB[2].ToString();
                        Txtrank.Text = dtreg.Rows[0]["RANK"].ToString();
                        if (Drpgrp.SelectedValue == "A") { ltrlMessage.Text = Txtjeeproll.Text + "-Roll Number found(Lateral Entry)."; }
                        else { ltrlMessage.Text = Txtjeeproll.Text + "-Roll Number found."; }
                        Drpgrp.Enabled = false;
                    }
                    else { ltrlMessage.Text = "Student Group Not matched with Branch Group, Student group is-" + GRP; }
                }
                else
                {
                    ltrlMessage.Text = Txtjeeproll.Text + "- IS Invalid Roll Number.Please Enter Valid Roll Number.";
                }
            }
            else
            {
                Lblcjeep.Text = string.Empty; Txtrank.Text = string.Empty;
                Txtcname.Text = string.Empty; Txtfname.Text = string.Empty;
                Drpday.SelectedIndex = 0; Drpmonth.SelectedIndex = 0; Drpyear.SelectedIndex = 0;
                Txtfee.Text = string.Empty; Txtfeedate.Text = string.Empty;
                Lblusename.Text = string.Empty;
                Lblpassword.Text = string.Empty;
                ltrlMessage.Text = string.Empty;
                ltrlMessage.Text = "Roll No can't left blank,Please Enter Valid Roll Number.";
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Drpaddcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Drpaddcat.SelectedValue == "M") { TRJEEPROLL.Visible = false; }
            else if (Drpaddcat.SelectedValue == "R") { TRJEEPROLL.Visible = true; }

            Txtjeeproll.Text = string.Empty; Lblcjeep.Text = string.Empty; Txtrank.Text = string.Empty;
            Txtcname.Text = string.Empty; Txtfname.Text = string.Empty;
            Drpday.SelectedIndex = 0; Drpmonth.SelectedIndex = 0; Drpyear.SelectedIndex = 0;
            Txtfee.Text = string.Empty; Txtfeedate.Text = string.Empty;
            Lblusename.Text = string.Empty;
            Lblpassword.Text = string.Empty;
            ltrlMessage.Text = string.Empty;
            GROUP();
            if (Drpaddcat.SelectedValue == "R") { Drpgrp.Enabled = false; TRJEEPROLL.Visible = true; TRCJEEP.Visible = true; }
            else
            {
                Drpgrp.Enabled = true;
                TRCJEEP.Visible = false;
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    private void INSERTDATA()
    {
        string _sqlQueryreg = string.Empty;
        string[] AllQueryParamreg = new string[1];
        BLL objbllreg = new BLL();

        string FORMSESS = string.Empty;
        string REGSESS = string.Empty;
        //Get From session
        DataTable dtsess = new DataTable();
        _sqlQueryreg = "select * FROM FORMSESS ORDER BY SESSNAME ASC";
        AllQueryParamreg[0] = _sqlQueryreg;
        objbllreg.QUERYBLL(ref dtsess, AllQueryParamreg);
        if (dtsess.Rows.Count > 0)
        {
            FORMSESS = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
            REGSESS = dtsess.Rows[1]["SESSVAL"].ToString().Trim();
        }
        if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
        if (Drpgrp.SelectedValue == "A") { SEM = "03"; } else { SEM = "01"; }
        Lblusename.Text = "";
        Lblpassword.Text = "";
        ltrlMessage.Text = "";
        if (!Regex.IsMatch(Txtfeedate.Text, @"^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$")) { ltrlMessage.Text = "Invalid Date Format, Please Enter Date In-DD/MM/YYYY."; return; }
        int found = 0;
        if (Drpaddcat.SelectedValue == "R")
        {

            DataTable dtreg = new DataTable();
            _sqlQueryreg = "select * from REGISTRATION where JROLL='" + Txtjeeproll.Text + "' AND STRTSESS='" + REGSESS + "'";
            AllQueryParamreg[0] = _sqlQueryreg;
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count > 0)
            {
                found = 1;
                ltrlMessage.Text = "This Candidate already Registered for-(" + dtreg.Rows[0]["INSCODE"].ToString() + ")" + dtreg.Rows[0]["INSNAME"].ToString();
            }

        }
        if ((found == 0 && Drpaddcat.SelectedValue == "R") || (Drpaddcat.SelectedValue == "M"))
        {
            BEL ObjBEL = new BEL();
            string pass = GenerateRandomCode();
            ObjBEL.OLDPASS = pass;
            BLL _Obj = new BLL();
            string _candidateId = _Obj._REGIDBLL(ObjBEL);
            if (_candidateId != "0")
            {
                string _sqlQuery = string.Empty;
                BLL objbllonlyquery = new BLL();
                string DOB = Drpday.SelectedValue.ToString().Trim() + "/" + Drpmonth.SelectedValue.ToString().Trim() + "/" + Drpyear.SelectedValue.ToString().Trim();
                if (Drpgrp.SelectedValue == "A")
                {
                    string value = "'" + _candidateId + "','" + Txtsession.Text + "','" + Txtroll.Text + "','" + Lblcjeep.Text + "','" + pass + "','" + Txtcname.Text.ToUpper() + "','" + Txtfname.Text.ToUpper() + "','" + DOB + "','" + Drpshift.SelectedValue + "','" + Lblregcat.Text.ToUpper() + "','" + Drpaddcat.SelectedValue + "','" + Drpgrp.SelectedValue + "','" + Drpins.SelectedValue + "','" + Drpins.SelectedItem.ToString() + "','" + Drpbranch.SelectedValue + "','" + Drpbranch.SelectedItem.ToString() + "','" + SEM + "','1','1','00','1','1','00','1','" + FORMSESS + "','1','" + Txtfee.Text + "','" + Txtfeedate.Text + "','A','R','Yes'";
                    _sqlQuery = "insert into REGISTRATION(CANDIDATEID,STRTSESS,ROLL,JROLL,PASSWORD,CNAME,FNAME,DOB,SHIFT,REGCAT,ADDCAT,GRP,INSCODE,INSNAME,BRCODE,BRNAME,SEM,SEM1,SEMCOM1,SEMFEE1,SEM2,SEMCOM2,SEMFEE2,SEM3,SEMSESS3,SEMCOM3,SEMFEE3,FEEDATE,STAT,REGPVT,LATERAL) values(" + value + ")";
                }
                else
                {
                    string value = "'" + _candidateId + "','" + Txtsession.Text + "','" + Txtroll.Text + "','" + Lblcjeep.Text + "','" + pass + "','" + Txtcname.Text.ToUpper() + "','" + Txtfname.Text.ToUpper() + "','" + DOB + "','" + Drpshift.SelectedValue + "','" + Lblregcat.Text.ToUpper() + "','" + Drpaddcat.SelectedValue + "','" + Drpgrp.SelectedValue + "','" + Drpins.SelectedValue + "','" + Drpins.SelectedItem.ToString() + "','" + Drpbranch.SelectedValue + "','" + Drpbranch.SelectedItem.ToString() + "','" + SEM + "','1','" + FORMSESS + "','1','" + Txtfee.Text + "','" + Txtfeedate.Text + "','A','R',0,0,0,0,'No'";
                    _sqlQuery = "insert into REGISTRATION(CANDIDATEID,STRTSESS,ROLL,JROLL,PASSWORD,CNAME,FNAME,DOB,SHIFT,REGCAT,ADDCAT,GRP,INSCODE,INSNAME,BRCODE,BRNAME,SEM,SEM1,SEMSESS1,SEMCOM1,SEMFEE1,FEEDATE,STAT,REGPVT,ISREG,ISQUA,ISADD,ISPH,LATERAL) values(" + value + ")";
                }
                string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                if (result == "1-1")
                {
                    ltrlMessage.Text = "1.New Candidate Added Successfully for-" + Drpins.SelectedValue + ".</br>2.Please Note down the user name and password for completing the application.";
                    Lblusename.Text = _candidateId;
                    Lblpassword.Text = pass;
                    Txtjeeproll.Text = string.Empty; Lblcjeep.Text = string.Empty; Txtrank.Text = string.Empty;
                    Txtcname.Text = string.Empty; Txtfname.Text = string.Empty;
                    Drpday.SelectedIndex = 0; Drpmonth.SelectedIndex = 0; Drpyear.SelectedIndex = 0;
                    if (Drpgrp.SelectedValue == "A")
                    {
                        BACK(_candidateId);
                    }
                    Txtsession.Text = "";
                    Txtroll.Text = "";
                }
                else { ltrlMessage.Text ="Addition Failed."; }
            }
            else { ltrlMessage.Text = "Id Not Generated."; }
        }
    }
    protected void BACK(string CANDIDATEID)
    {
        try
        {
            string _sqlQuery = string.Empty;
            BLL objbll = new BLL();
            string[] AllQueryParam = new string[1];
            int FEEBACK = 0;
            string SUB = string.Empty;
            string TYP = "B";
            int n = 0;
            string SESS = Getsession();
            string brr = Session["BRCODE"].ToString().Substring(0, 2).ToString();
            _sqlQuery = "SELECT * FROM SUBN where BRCODE='" + brr + "' AND SEM='01' AND TYPE LIKE'%T%' ORDER BY SEM,SUBCODE ASC";
            DataTable dtsub = new DataTable();
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dtsub, AllQueryParam);
            for (int i = 0; i < dtsub.Rows.Count; i++)
            {
                string SUBC = dtsub.Rows[i]["SUBCODE"].ToString().Trim();
                if (n == 0) { SUB = SUBC + "T"; }
                else
                {
                    SUB = SUB + "|" + SUBC + "T";
                }
                n++;
            }
            DataTable dt = new DataTable();
            _sqlQuery = "select * from REGISTRATION where CANDIDATEID='" + CANDIDATEID + "'";
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dt, AllQueryParam);
            _sqlQuery = "select * from BACKP where CANDIDATEID='" + CANDIDATEID + "' AND STAT='A'";
            DataTable dtb = new DataTable();
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dtb, AllQueryParam);
            if (dtb.Rows.Count == 0)
            {
                _sqlQuery = "insert into BACKP(CANDIDATEID,ROLL,INSCODE,INSNAME,BRCODE,BRNAME,SHIFT,CNAME,FNAME,DOB,SEM,SUBA,TYPE,FEE,ISCOMPLETED,SESS,REGPVT,STUTYPE,STAT,UPDATEDON) Values('" + dt.Rows[0]["CANDIDATEID"].ToString() + "','" + dt.Rows[0]["ROLL"].ToString() + "','" + dt.Rows[0]["INSCODE"].ToString() + "','" + dt.Rows[0]["INSNAME"].ToString() + "','" + dt.Rows[0]["BRCODE"].ToString() + "','" + dt.Rows[0]["BRNAME"].ToString() + "','" + dt.Rows[0]["SHIFT"].ToString() + "','" + dt.Rows[0]["CNAME"].ToString() + "','" + dt.Rows[0]["FNAME"].ToString() + "','" + dt.Rows[0]["DOB"].ToString() + "','" + dt.Rows[0]["SEM"].ToString() + "','" + SUB + "','" + TYP + "','" + FEEBACK + "','1','" + SESS + "','" + dt.Rows[0]["REGPVT"].ToString() + "','N','A',GETDATE())";
                string result = objbll.ONLYQUERYBLL(_sqlQuery);
            }
        }
        catch (Exception ex) { Response.Write(ex.Message); }
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
        }
        return SESS;
    }
    private bool Validation()
    {
        if (Drpaddcat.SelectedValue == "R")
        {
            if (Drpshift.SelectedIndex == 0) { return false; }
            if (Lblcjeep.Text == "") { return false; }
            if (Txtcname.Text == "") { return false; }
            if (Txtfname.Text == "") { return false; }
            if (Drpday.SelectedIndex == 0) { return false; }
            if (Drpmonth.SelectedIndex == 0) { return false; }
            if (Drpyear.SelectedIndex == 0) { return false; }
            if (Drpgrp.SelectedIndex == 0) { return false; }
            if (Txtfeedate.Text.Length != 10) { return false; }
        }
        else if (Drpaddcat.SelectedValue == "M")
        {
            if (Drpshift.SelectedIndex == 0) { return false; }
            if (Txtcname.Text == "") { return false; }
            if (Txtfname.Text == "") { return false; }
            if (Drpday.SelectedIndex == 0) { return false; }
            if (Drpmonth.SelectedIndex == 0) { return false; }
            if (Drpyear.SelectedIndex == 0) { return false; }
            if (Drpgrp.SelectedIndex == 0) { return false; }
            if (Txtfeedate.Text.Length != 10) { return false; }
        }
        return true;
    }
    private void GROUP()
    {
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        _sqlQueryreg = "select * from BRLOGIN where INSCODE='" + Drpins.SelectedValue + "' and BRCODE='" + Drpbranch.SelectedValue + "'";
        AllQueryParamreg[0] = _sqlQueryreg;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0) { Drpgrp.SelectedValue = dtreg.Rows[0]["GRP"].ToString(); Drpgrp.Enabled = false; Drpshift.SelectedValue = dtreg.Rows[0]["SHIFT"].ToString(); Drpshift.Enabled = false; }
        else { Response.Redirect("~/Error.aspx", false); }
    }
}