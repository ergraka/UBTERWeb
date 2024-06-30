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

public partial class Addoffstudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Error.aspx", false);
            if (!IsPostBack)
            {
                if (Session["INSCODE"] == null && Session["BRCODE"] == null) { Response.Redirect("Inslogin.aspx", false); }
                string[] SPL1 = Session["BRCODE"].ToString().Split('|');
                string[] SPL2 = SPL1[0].ToString().Split('-');
                Drpshift.SelectedValue = SPL2[1].ToString();
                Drpshift.Enabled = false;
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["BRCODE"] != null)
            {
                INSERTDATA();
            }
            else { Response.Redirect("Inslogin.aspx", false); }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
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
    private void INSERTDATA()
    {

        if (Session["INSCODE"] != null && Session["BRCODE"] != null && Session["REGCAT"] != null)
        {
            if (Drpsem.SelectedIndex == 0) { ltrlMessage.Text = "Please Select Semester/Year."; return; }
            if (Drpprireg.SelectedIndex == 0) { ltrlMessage.Text = "Please Select Private/Regular."; return; }
            if (Txtjeeproll.Text == "") { ltrlMessage.Text = "Enter Roll Number."; return; }
            if (Txtcname.Text == "") { ltrlMessage.Text = "Enter Name."; return; }
            if (Txtfname.Text == "") { ltrlMessage.Text = "Enter Father Name."; return; }
            if (Drpday.SelectedIndex == 0 || Drpmonth.SelectedIndex == 0 || Drpyear.SelectedIndex == 0) { ltrlMessage.Text = "Please select Date of birth."; return; }
            if (Drpgrp.SelectedIndex == 0) { ltrlMessage.Text = "select group."; return; }
            //if (Session["REGCAT"].ToString() == "GOVT")
            //{
            //    if (Txtfee.Text != "1620") { ltrlMessage.Text = "Enter Correct Registration Fee."; return; }
            //}
            //else
            //{
            //    if (Txtfee.Text != "2120") { ltrlMessage.Text = "Enter Correct Registration Fee."; return; }
            //}
            if (!Regex.IsMatch(Txtfeedate.Text, @"^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$")) { ltrlMessage.Text = "Invalid Date Format, Please Enter Date In-DD/MM/YYYY."; return; }
            Lblusename.Text = "";
            Lblpassword.Text = "";
            ltrlMessage.Text = "";
            string SEM = Drpsem.SelectedValue.ToString();
            string _sqlQueryreg = string.Empty;
            DataTable dtreg = new DataTable();
            string[] AllQueryParamreg = new string[1];
            _sqlQueryreg = "select * from REGISTRATION where ROLL='" + Txtjeeproll.Text + "'";
            AllQueryParamreg[0] = _sqlQueryreg;
            BLL objbllreg = new BLL();
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count == 0)
            {
                BEL ObjBEL = new BEL();
                string pass = GenerateRandomCode();
                ObjBEL.OLDPASS = pass;
                BLL _Obj = new BLL();
                string _candidateId = _Obj._REGIDBLL(ObjBEL);
                if (_candidateId != "0")
                {
                    string SESS = "07-2021";
                    string _sqlQuery = string.Empty;
                    BLL objbllonlyquery = new BLL();
                    string[] insspl = Session["INSCODE"].ToString().Split('|');
                    string[] brspl = Session["BRCODE"].ToString().Split('|');
                    string DOB = Drpday.SelectedValue.ToString().Trim() + "/" + Drpmonth.SelectedValue.ToString().Trim() + "/" + Drpyear.SelectedValue.ToString().Trim();
                    if (SEM == "01")
                    {
                        string value = "'" + _candidateId + "','" + Txtjeeproll.Text + "','" + pass + "','" + SESS + "','" + Txtcname.Text.ToUpper() + "','" + Txtfname.Text.ToUpper() + "','" + DOB + "','" + Drpshift.SelectedValue + "','" + Session["REGCAT"].ToString() + "','R','" + Drpgrp.SelectedValue + "','" + insspl[0].ToString() + "','" + insspl[1].ToString() + "','" + brspl[0].ToString() + "','" + brspl[1].ToString() + "','" + SEM + "','1','" + Txtfee.Text + "','" + Txtfeedate.Text + "','A','" + Drpprireg.SelectedValue + "'";
                        _sqlQuery = "insert into REGISTRATION(CANDIDATEID,ROLL,PASSWORD,STRTSESS,CNAME,FNAME,DOB,SHIFT,REGCAT,ADDCAT,GRP,INSCODE,INSNAME,BRCODE,BRNAME,SEM,SEM1,SEMFEE1,FEEDATE,STAT,REGPVT) values(" + value + ")";
                    }
                    else if (SEM == "02")
                    {
                        string value = "'" + _candidateId + "','" + Txtjeeproll.Text + "','" + pass + "','" + SESS + "','" + Txtcname.Text.ToUpper() + "','" + Txtfname.Text.ToUpper() + "','" + DOB + "','" + Drpshift.SelectedValue + "','" + Session["REGCAT"].ToString() + "','R','" + Drpgrp.SelectedValue + "','" + insspl[0].ToString() + "','" + insspl[1].ToString() + "','" + brspl[0].ToString() + "','" + brspl[1].ToString() + "','" + SEM + "','1','1','00','1','" + Txtfee.Text + "','" + Txtfeedate.Text + "','A','" + Drpprireg.SelectedValue + "'";
                        _sqlQuery = "insert into REGISTRATION(CANDIDATEID,ROLL,PASSWORD,STRTSESS,CNAME,FNAME,DOB,SHIFT,REGCAT,ADDCAT,GRP,INSCODE,INSNAME,BRCODE,BRNAME,SEM,SEM1,SEMCOM1,SEMFEE1,SEM2,SEMFEE2,FEEDATE,STAT,REGPVT) values(" + value + ")";
                    }
                    else if (SEM == "03")
                    {
                        string value = "'" + _candidateId + "','" + Txtjeeproll.Text + "','" + pass + "','" + SESS + "','" + Txtcname.Text.ToUpper() + "','" + Txtfname.Text.ToUpper() + "','" + DOB + "','" + Drpshift.SelectedValue + "','" + Session["REGCAT"].ToString() + "','R','" + Drpgrp.SelectedValue + "','" + insspl[0].ToString() + "','" + insspl[1].ToString() + "','" + brspl[0].ToString() + "','" + brspl[1].ToString() + "','" + SEM + "','1','1','00','1','1','00','1','" + Txtfee.Text + "','" + Txtfeedate.Text + "','A','" + Drpprireg.SelectedValue + "'";
                        _sqlQuery = "insert into REGISTRATION(CANDIDATEID,ROLL,PASSWORD,STRTSESS,CNAME,FNAME,DOB,SHIFT,REGCAT,ADDCAT,GRP,INSCODE,INSNAME,BRCODE,BRNAME,SEM,SEM1,SEMCOM1,SEMFEE1,SEM2,SEMCOM2,SEMFEE2,SEM3,SEMFEE3,FEEDATE,STAT,REGPVT) values(" + value + ")";
                    }
                    else if (SEM == "04")
                    {
                        string value = "'" + _candidateId + "','" + Txtjeeproll.Text + "','" + pass + "','" + SESS + "','" + Txtcname.Text.ToUpper() + "','" + Txtfname.Text.ToUpper() + "','" + DOB + "','" + Drpshift.SelectedValue + "','" + Session["REGCAT"].ToString() + "','R','" + Drpgrp.SelectedValue + "','" + insspl[0].ToString() + "','" + insspl[1].ToString() + "','" + brspl[0].ToString() + "','" + brspl[1].ToString() + "','" + SEM + "','1','1','00','1','1','00','1','1','00','1','" + Txtfee.Text + "','" + Txtfeedate.Text + "','A','" + Drpprireg.SelectedValue + "'";
                        _sqlQuery = "insert into REGISTRATION(CANDIDATEID,ROLL,PASSWORD,STRTSESS,CNAME,FNAME,DOB,SHIFT,REGCAT,ADDCAT,GRP,INSCODE,INSNAME,BRCODE,BRNAME,SEM,SEM1,SEMCOM1,SEMFEE1,SEM2,SEMCOM2,SEMFEE2,SEM3,SEMCOM3,SEMFEE3,SEM4,SEMFEE4,FEEDATE,STAT,REGPVT) values(" + value + ")";
                    }
                    else if (SEM == "05")
                    {
                        string value = "'" + _candidateId + "','" + Txtjeeproll.Text + "','" + pass + "','" + SESS + "','" + Txtcname.Text.ToUpper() + "','" + Txtfname.Text.ToUpper() + "','" + DOB + "','" + Drpshift.SelectedValue + "','" + Session["REGCAT"].ToString() + "','R','" + Drpgrp.SelectedValue + "','" + insspl[0].ToString() + "','" + insspl[1].ToString() + "','" + brspl[0].ToString() + "','" + brspl[1].ToString() + "','" + SEM + "','1','1','00','1','1','00','1','1','00','1','1','00','1','" + Txtfee.Text + "','" + Txtfeedate.Text + "','A','" + Drpprireg.SelectedValue + "'";
                        _sqlQuery = "insert into REGISTRATION(CANDIDATEID,ROLL,PASSWORD,STRTSESS,CNAME,FNAME,DOB,SHIFT,REGCAT,ADDCAT,GRP,INSCODE,INSNAME,BRCODE,BRNAME,SEM,SEM1,SEMCOM1,SEMFEE1,SEM2,SEMCOM2,SEMFEE2,SEM3,SEMCOM3,SEMFEE3,SEM4,SEMCOM4,SEMFEE4,SEM5,SEMFEE5,FEEDATE,STAT,REGPVT) values(" + value + ")";
                    }
                    else if (SEM == "06")
                    {
                        string value = "'" + _candidateId + "','" + Txtjeeproll.Text + "','" + pass + "','" + SESS + "','" + Txtcname.Text.ToUpper() + "','" + Txtfname.Text.ToUpper() + "','" + DOB + "','" + Drpshift.SelectedValue + "','" + Session["REGCAT"].ToString() + "','R','" + Drpgrp.SelectedValue + "','" + insspl[0].ToString() + "','" + insspl[1].ToString() + "','" + brspl[0].ToString() + "','" + brspl[1].ToString() + "','" + SEM + "','1','1','00','1','1','00','1','1','00','1','1','00','1','1','00','1','1','" + Txtfee.Text + "','" + Txtfeedate.Text + "','A','" + Drpprireg.SelectedValue + "'";
                        _sqlQuery = "insert into REGISTRATION(CANDIDATEID,ROLL,PASSWORD,STRTSESS,CNAME,FNAME,DOB,SHIFT,REGCAT,ADDCAT,GRP,INSCODE,INSNAME,BRCODE,BRNAME,SEM,SEM1,SEMCOM1,SEMFEE1,SEM2,SEMCOM2,SEMFEE2,SEM3,SEMCOM3,SEMFEE3,SEM4,SEMCOM4,SEMFEE4,SEM5,SEMCOM5,SEMFEE5,SEM6,SEMCOM6,SEMFEE6,FEEDATE,STAT,REGPVT) values(" + value + ")";
                    }
                    string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
                    if (result == "1-1")
                    {
                        ltrlMessage.Text = "1." + Txtjeeproll.Text + "-Added Successfully.</br>2.Please Note down the user name and password for completing the application.";
                        Lblusename.Text = _candidateId;
                        Lblpassword.Text = pass;

                        Txtjeeproll.Text = ""; Txtcname.Text = ""; Txtfname.Text = ""; Drpgrp.SelectedIndex = 0;
                        Drpday.SelectedIndex = 0; Drpmonth.SelectedIndex = 0; Drpyear.SelectedIndex = 0;
                        Txtfee.Text = ""; Txtfeedate.Text = "";
                        Drpsem.SelectedIndex = 0;
                        Drpprireg.SelectedIndex = 0;
                    }
                    else { ltrlMessage.Text = "Please try after some time."; }
                }
            }
            else { ltrlMessage.Text = "This Candidate already Registered for-(" + dtreg.Rows[0]["INSCODE"].ToString() + ")" + dtreg.Rows[0]["INSNAME"].ToString(); }
        }
        else { Response.Redirect("Inslogin.aspx", false); }
    }
}