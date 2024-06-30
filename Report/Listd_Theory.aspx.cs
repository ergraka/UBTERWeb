using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using _Examination;
public partial class Listd_Theory : System.Web.UI.Page
{
    public string DATA = string.Empty;
    public string HEADSESS = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HEADSESS = Getsession();
            if (!IsPostBack)
            {
                if (Session["INSCODE"] != null && Session["BRCODE"] != null)
                {
                    string SEM = string.Empty;
                    if (Request.QueryString["TYP"] != null) { SEM = Request.QueryString["TYP"].ToString().Trim(); }
                    else { Response.Redirect("~/Error.aspx", true); }
                    string[] splbr = Session["BRCODE"].ToString().Split('|');
                    string[] BRSPL = splbr[0].ToString().Split('-');
                    string brcode = splbr[0].ToString();
                    //***************************************************************************GET SUBJECT
                    if (SEM == "P" || SEM == "Q")
                    {
                        for (int j = 1; j <= 2; j++)
                        {
                            string _sqlQueryreg = string.Empty;
                            DataTable dtreg = new DataTable();
                            string[] AllQueryParamreg = new string[1];
                            if (j == 1) { _sqlQueryreg = "select distinct SUBCODE,SUBJECT from SUBN where BRCODE='" + BRSPL[0].ToString() + "' and (TYPE='T' OR TYPE='TP') order by SUBCODE asc"; }
                            else { _sqlQueryreg = "select distinct SUBCODE,SUBJECT from SUBJ where BRCODE='" + BRSPL[0].ToString() + "' and (TYPE='T' OR TYPE='TP') order by SUBCODE asc"; }

                            AllQueryParamreg[0] = _sqlQueryreg;
                            BLL objbllreg = new BLL();
                            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                            if (dtreg.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtreg.Rows.Count; i++)
                                {
                                    string SUBCODE = dtreg.Rows[i]["SUBCODE"].ToString().Trim();
                                    string SUBNAME = dtreg.Rows[i]["SUBJECT"].ToString().Trim();
                                    Drpsub.Items.Add(SUBCODE + "-" + SUBNAME);
                                }
                                if (Drpsub.Items.Count > 0) { Drpsub.SelectedIndex = 0; }
                            }
                        }
                    }
                    else
                    {
                        string _sqlQueryreg = string.Empty;
                        DataTable dtreg = new DataTable();
                        string[] AllQueryParamreg = new string[1];
                        BLL objbllreg = new BLL();
                        string BR = BRSPL[0].ToString();
                        if ((brcode.Substring(0, 2) == "07") || (brcode.Substring(0, 2) == "16" && SEM == "02")) { _sqlQueryreg = "select distinct SUBCODE,SUBJECT from SUBJ where SEM<='" + SEM + "' AND BRCODE='" + BRSPL[0].ToString() + "' and (TYPE='T' OR TYPE='TP') order by SUBCODE asc"; }
                        else { _sqlQueryreg = "select distinct SUBCODE,SUBJECT from SUBN where SEM<='" + SEM + "' AND BRCODE='" + BRSPL[0].ToString() + "' and (TYPE='T' OR TYPE='TP') order by SUBCODE asc"; }
                        AllQueryParamreg[0] = _sqlQueryreg;
                        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);

                        if (dtreg.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtreg.Rows.Count; i++)
                            {
                                string SUBCODE = dtreg.Rows[i]["SUBCODE"].ToString().Trim();
                                string SUBNAME = dtreg.Rows[i]["SUBJECT"].ToString().Trim();
                                Drpsub.Items.Add(SUBCODE + "-" + SUBNAME);
                            }
                            if (Drpsub.Items.Count > 0) { Drpsub.SelectedIndex = 0; }
                        }
                    }
                }
                else { Response.Redirect("~/Institute/Inslogin.aspx", false); }
            }
        }
        catch (Exception ex)
        {
            LblMessage.Text = "Please try after some time !";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The Login can not complete. Please try after some time !');", true);
        }

    }
    protected void Btnview_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["INSCODE"] != null && Session["BRCODE"] != null)
            {

                string SEM = string.Empty;
                if (Request.QueryString["TYP"] != null)
                {
                    SEM = Request.QueryString["TYP"].ToString().Trim();
                }
                else { Response.Redirect("~/Error.aspx", false); }
                LblMessage.Text = "";
                string[] splins = Session["INSCODE"].ToString().Split('|');
                Lblins.Text = splins[1].ToString();
                Lblins1.Text = splins[1].ToString();
                string[] splbr = Session["BRCODE"].ToString().Split('|');
                Lblbranch.Text = splbr[1].ToString();
                Lblbranch1.Text = splbr[1].ToString();
                string[] BRSPL = splbr[0].ToString().Split('-');
                string brcode = splbr[0].ToString();
                //************************************************************************************GET BRANCH SUMMARY
                string[] SUB = Drpsub.Text.Split('-');
                string SUBCODE = SUB[0].ToString();

                Lblfoil1.Text = splins[0].ToString() + BRSPL[0].ToString() + SUBCODE;
                Lblfoil2.Text = splins[0].ToString() + BRSPL[0].ToString() + SUBCODE;

                string SUBTYPE = "B";
                string BACKSEM = string.Empty;
                string _sqlQueryreg1 = string.Empty;
                DataTable dtfound = new DataTable();
                string[] AllQueryParamreg1 = new string[1];


                if (SUBCODE.Length == 4) { _sqlQueryreg1 = "select * from SUBJ where BRCODE='" + BRSPL[0].ToString() + "' AND SUBCODE='" + SUBCODE + "' AND SEM!='" + SEM + "'"; }
                else { _sqlQueryreg1 = "select * from SUBN where BRCODE='" + BRSPL[0].ToString() + "' AND SUBCODE='" + SUBCODE + "' AND SEM!='" + SEM + "'"; }


                AllQueryParamreg1[0] = _sqlQueryreg1;
                BLL objbllreg1 = new BLL();
                objbllreg1.QUERYBLL(ref dtfound, AllQueryParamreg1);
                if (dtfound.Rows.Count > 0)
                {
                    SUBTYPE = "B";
                    BACKSEM = dtfound.Rows[0]["SEM"].ToString();
                }
                else { SUBTYPE = "C"; }
                DataTable dtreg1 = new DataTable();

                if (SUBCODE.Length == 4) { _sqlQueryreg1 = "select * from SUBJ where BRCODE='" + BRSPL[0].ToString() + "' AND SUBCODE='" + SUBCODE + "'"; }
                else { _sqlQueryreg1 = "select * from SUBN where BRCODE='" + BRSPL[0].ToString() + "' AND SUBCODE='" + SUBCODE + "'"; }

                AllQueryParamreg1[0] = _sqlQueryreg1;
                objbllreg1.QUERYBLL(ref dtreg1, AllQueryParamreg1);
                if (dtreg1.Rows.Count > 0)
                {
                    Lblsub.Text = Drpsub.SelectedItem.ToString();
                    Lblsub1.Text = Drpsub.SelectedItem.ToString();
                    Lblmax.Text = dtreg1.Rows[0]["THMAX"].ToString();
                    Lblmax1.Text = dtreg1.Rows[0]["THMAX"].ToString();
                    Lblmin.Text = dtreg1.Rows[0]["THMIN"].ToString();
                    Lblmin1.Text = dtreg1.Rows[0]["THMIN"].ToString();
                    Lblsem.Text = SEM;
                    Lblsem1.Text = SEM;
                    Lblshift.Text = BRSPL[1].ToString();
                    Lblshift1.Text = BRSPL[1].ToString();
                }
                Getdata(SUBTYPE, BACKSEM);
            }
            else { Response.Redirect("~/Institute/Inslogin.aspx", false); }
        }
        catch (Exception ex)
        {
            LblMessage.Text = "Please try after some time !";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Due to technical issue.The Login can not complete. Please try after some time !');", true);
        }
    }
    private void Getdata(string SUBTYPE, string BACKSEM)
    {
        string _sqlQueryreg = string.Empty;
        string[] AllQueryParamreg = new string[1];
        BLL objbllreg = new BLL();

        //Get From session
        string FORMSESS = string.Empty;
        string REGSESS = string.Empty;
        DataTable dtsess = new DataTable();
        _sqlQueryreg = "select * FROM FORMSESS ORDER BY SESSNAME";
        AllQueryParamreg[0] = _sqlQueryreg;
        objbllreg.QUERYBLL(ref dtsess, AllQueryParamreg);
        if (dtsess.Rows.Count > 0)
        {
            FORMSESS = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
            REGSESS = dtsess.Rows[1]["SESSVAL"].ToString().Trim();
        }
        string SEM = string.Empty;
        string CLM = string.Empty;
        string CLMSESS = string.Empty;
        if (Request.QueryString["TYP"] != null)
        {
            SEM = Request.QueryString["TYP"].ToString().Trim();
            if (SEM == "01") { CLM = "SEMCOM1"; CLMSESS = "SEMSESS1"; }
            else if (SEM == "02") { CLM = "SEMCOM2"; CLMSESS = "SEMSESS2"; }
            else if (SEM == "03") { CLM = "SEMCOM3"; CLMSESS = "SEMSESS3"; }
            else if (SEM == "04") { CLM = "SEMCOM4"; CLMSESS = "SEMSESS4"; }
            else if (SEM == "05") { CLM = "SEMCOM5"; CLMSESS = "SEMSESS5"; }
            else if (SEM == "06") { CLM = "SEMCOM6"; CLMSESS = "SEMSESS6"; }
        }
        DATA = "";
        string[] splins = Session["INSCODE"].ToString().Split('|');
        string[] splbr = Session["BRCODE"].ToString().Split('|');
        DataTable dt = new DataTable();
        DataTable dtreg = new DataTable();
        string[] SUB = Drpsub.Text.Split('-');
        string SUBCODE = SUB[0].ToString();
        string STUTY = string.Empty;
        if (SUBCODE.Length == 4) { STUTY = "O"; }
        else { STUTY = "N"; }

        if (SUBTYPE == "C")
        {
            _sqlQueryreg = "select * FROM REGISTRATION where INSCODE='" + splins[0].ToString() + "' and BRCODE='" + splbr[0].ToString() + "' AND " + CLM + "='1' AND " + CLMSESS + "='" + FORMSESS + "' AND STUTYPE='" + STUTY + "' AND SEM='" + Lblsem.Text + "' AND STAT='A' AND REGPVT='R' order by ROLL asc";
            AllQueryParamreg[0] = _sqlQueryreg;
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count > 0) { dt = dtreg.Copy(); }
        }
        else if (SUBTYPE == "B")//BACK PAPER
        {
            DataTable dtback = new DataTable();
            if (Lblsem.Text == "P" || Lblsem.Text == "Q")
            {
                _sqlQueryreg = "SELECT * FROM BACKP WHERE INSCODE='" + splins[0].ToString() + "' AND TYPE='B' and BRCODE='" + splbr[0].ToString() + "' AND ISCOMPLETED='1' AND SUBA LIKE'%" + SUBCODE + "T%' AND REGPVT='" + Lblsem.Text + "' AND STAT='A' order by ROLL asc";
            }
            else
            {
                _sqlQueryreg = "SELECT * FROM BACKP WHERE INSCODE='" + splins[0].ToString() + "' AND TYPE='B' and BRCODE='" + splbr[0].ToString() + "' AND ISCOMPLETED='1' AND SEM='" + Lblsem.Text + "' AND SUBA LIKE'%" + SUBCODE + "T%' AND REGPVT='R' AND STAT='A' order by ROLL asc";
            }
            AllQueryParamreg[0] = _sqlQueryreg;
            objbllreg.QUERYBLL(ref dtback, AllQueryParamreg);
            if (dtback.Rows.Count > 0) { dt = dtback.Copy(); }
            //Group A
            DataTable dtgrpa = new DataTable();
            if (Lblsem.Text == "03")
            {
                if (BACKSEM == "01")
                {
                    if (SUBCODE == "1005" || SUBCODE == "1006" || SUBCODE == "991006")
                    {
                        _sqlQueryreg = "SELECT ROLL FROM REGISTRATION WHERE INSCODE='" + splins[0].ToString() + "' and BRCODE='" + splbr[0].ToString() + "' AND SEMCOM3='1' AND SEM='03' AND (ITIPASS='N' OR ITIPASS IS NULL) AND STRTSESS='" + REGSESS + "' AND GRP='A' AND REGPVT='R' order by ROLL asc";
                    }
                    else
                    {
                        _sqlQueryreg = "SELECT ROLL FROM REGISTRATION WHERE INSCODE='" + splins[0].ToString() + "' and BRCODE='" + splbr[0].ToString() + "' AND SEMCOM3='1' AND SEM='03' AND STRTSESS='" + REGSESS + "' AND GRP='A' AND REGPVT='R' order by ROLL asc";
                    }
                    AllQueryParamreg[0] = _sqlQueryreg;
                    objbllreg.QUERYBLL(ref dtgrpa, AllQueryParamreg);
                    if (dtgrpa.Rows.Count > 0) { dt.Merge(dtgrpa); }
                }
            }
        }
        //Special Back
        //DataTable dtsback = new DataTable();
        //if (Lblsem.Text == "P" || Lblsem.Text == "Q")
        //{
        //    _sqlQueryreg = "SELECT ROLL FROM BACKP WHERE INSCODE='" + splins[0].ToString() + "' AND TYPE='S' and BRCODE='" + splbr[0].ToString() + "' AND ISCOMPLETED='1' AND SUBA LIKE'%" + SUBCODE + "T%' AND REGPVT='" + Lblsem.Text + "' AND ROLL NOT IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1') AND STAT='A' order by ROLL asc";
        //}
        //else
        //{
        //    _sqlQueryreg = "SELECT ROLL FROM BACKP WHERE INSCODE='" + splins[0].ToString() + "' AND TYPE='S' and BRCODE='" + splbr[0].ToString() + "' AND ISCOMPLETED='1' AND SEM='" + Lblsem.Text + "' AND ROLL NOT IN(SELECT ROLL FROM BACKP WHERE ISCOMPLETED='1') AND SUBA LIKE'%" + SUBCODE + "T%' AND REGPVT='R' order by ROLL asc";
        //}
        //AllQueryParamreg[0] = _sqlQueryreg;
        //objbllreg.QUERYBLL(ref dtsback, AllQueryParamreg);
        //if (dtsback.Rows.Count > 0) { dt.Merge(dtsback); }

        if (dt.Rows.Count > 0)
        {
            string[] ROLLALL = dt.Rows.OfType<DataRow>().Select(k => k["ROLL"].ToString()).ToArray();
            Array.Sort(ROLLALL);
            for (int i = 0; i < ROLLALL.Length; i++)
            {
                string ROLL = ROLLALL[i].ToString().Trim();
                DATA = DATA + ("<tr>");
                DATA = DATA + ("<td style='height:30px; border-bottom: 1px solid #000000; border-left: 1px solid #000000; font-weight:bold;font-size: 17px; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + ROLL + "</td>");
                DATA = DATA + ("<td style='height:30px; border-bottom: 1px solid #000000; font-weight:bold;font-size: 17px; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + SUBCODE + "</td>");
                DATA = DATA + ("<td style='height:30px; border-bottom: 1px solid #000000; font-weight:bold;font-size: 17px; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">" + splbr[0].ToString() + "</td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000'</td>");
                DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000'</td>");
                DATA = DATA + ("</tr>");
            }
            DATA = DATA + ("<th colspan='3' style='height:30px; border-bottom: 1px solid #000000; border-left: 1px solid #000000;font-size: 17px; border-right: 1px solid #000000' valign=\"middle\" align=\"center\">TOTAL MARKS</th>");
            DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000'</td>");
            DATA = DATA + ("<td style='border-bottom: 1px solid #000000; border-right: 1px solid #000000'</td>");
        }
        else { LblMessage.Text = "No Records Found."; }
    }
    protected void Imghome_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Session["ID"] != null) { Response.Redirect("~/Student/Stuhome.aspx?mode=home", false); }
            else { Response.Redirect("~/Institute/Inslogin.aspx", false); }
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
            Response.Redirect("~/Institute/Inslogin.aspx", false);
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
            else if (S1 == "12")
            {
                string S3 = S2.Substring(3, 2);
                int PP = Convert.ToInt32(S3) + 1;
                SESS = "WINTER" + S2 + " : " + PP.ToString();
            }
        }
        return SESS;
    }
}