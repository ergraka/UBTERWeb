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
using System.Reflection;
using ClosedXML.Excel;

public partial class Canidpass : System.Web.UI.Page
{

    #region _Connection
    //string connectionStringsem = "Data Source=182.50.133.111;Initial Catalog=RESSEM;User Id=RESSEM;Password=abhi@SRN031; Max Pool Size=50000; Min Pool Size=10";
    //string connectionStringyear = "Data Source=182.50.133.111;Initial Catalog=RESYEAR;User Id=RESYEAR;Password=abhi@SRN031; Max Pool Size=50000; Min Pool Size=10";
    string connectionStringsem = System.Configuration.ConfigurationManager.ConnectionStrings["S@N"].ConnectionString.ToString();
    string connectionStringyear = System.Configuration.ConfigurationManager.ConnectionStrings["S@N"].ConnectionString.ToString();
    SqlConnection conn;
    SqlCommand cmd;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["BRCODE"] == null && Session["ADMIN"] == null) { Response.Redirect("Inslogin.aspx", false); }
            if (Request.QueryString["DOWNLOAD"] == null) { Response.Redirect("~/Error.aspx", false); }

            string[] SPL = Request.QueryString["DOWNLOAD"].ToString().Split('|');
            string TYP = SPL[0].ToString();
            string SEM = SPL[1].ToString();

            if (TYP == "CROSS") { Downloadcross(SEM); }
            else if (TYP == "SCROSS") { Downloadscross(); }
            else if (TYP == "RCROSS") { Downloadrcross(); }
            else if (TYP == "SBPCROSS") { Downloadsbpcross(); }
            else if (TYP == "SCRU" || TYP == "REEVA") { SCRE(TYP); }
            else if (TYP == "SUBCOUNT") { SUBCOUNT(SEM); }
            else if (TYP == "SBPSUBINSBR") { SBPSUBINSBR(TYP); }
            else if (TYP == "SBPSUB") { SBPSUB(TYP); }
            else if (TYP == "BACKSUBINSBR") { BACKSUBINSBR(TYP); }
            else if (TYP == "BACKSUB") { BACKSUB(TYP); }
            else if (TYP == "EXAMINER") { EXAMINER(); }
            else if (TYP == "SEMDATA") { SEMDATA(SEM); }
            else if (TYP == "BACKP") { BACKP(); }
            else if (TYP == "PASS")
            {
                string _sqlQuery = string.Empty;
                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                string[] spl1 = Session["INSCODE"].ToString().Split('|');
                string inscode = spl1[0].ToString();
                string[] Brspl1 = Session["BRCODE"].ToString().Split('|');
                string brcode = Brspl1[0].ToString();
                _sqlQuery = "select CANDIDATEID,CNAME,FNAME,DOB,GENDER,INSCODE,BRCODE,SEM,PASSWORD from REGISTRATION where INSCODE='" + inscode + "' and BRCODE='" + brcode + "' AND STAT='A' ORDER BY SEM,CANDIDATEID";
                AllQueryParam[0] = _sqlQuery;
                BLL objbllLogin = new BLL();
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count > 0)
                {
                    ExportToWord(dt, TYP);
                }
            }
            else
            {
                string _sqlQuery = string.Empty;
                DataTable dt = new DataTable();
                string[] AllQueryParam = new string[1];
                if (TYP == "SUBNMAIN") { _sqlQuery = "SELECT * FROM SUBN ORDER BY SEM,BRCODE,SUBCODE ASC"; }
                else if (TYP == "SUBOMAIN") { _sqlQuery = "SELECT * FROM SUBJ ORDER BY SEM,BRCODE,SUBCODE ASC"; }
                else if (TYP == "SUBNSESS") { _sqlQuery = "SELECT * FROM SUBSESSN ORDER BY SEM,BRCODE,SUBCODE ASC"; }
                else if (TYP == "SUBOSESS") { _sqlQuery = "SELECT * FROM SUBSESS ORDER BY SEM,BRCODE,SUBCODE ASC"; }
                AllQueryParam[0] = _sqlQuery;
                BLL objbllLogin = new BLL();
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                if (dt.Rows.Count > 0)
                {
                    ExportToExcel(dt, TYP);
                }
            }
        }
        catch (Exception ex) { Response.Write(ex.Message); }
    }
    private void ExportToWord(DataTable dt, string Filename)//CANDIDATE PASSWORD LIST
    {
        if (dt.Rows.Count > 0)
        {
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dt;
            dgGrid.DataBind();
            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            //Response.ContentType = application/vnd.ms-excel;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Filename + ".doc");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }
    }

    private void Downloadcross(string SEM)//CROSS LIST
    {
        string[] splbrc = Session["BRCODE"].ToString().Split('|');
        string BRC = splbrc[0].ToString();
        string[] splins = Session["INSCODE"].ToString().Split('|');
        string INS = splins[0].ToString();
        string strURL = "~/Institute/CROSS/" + SEM + "/" + INS + "-" + BRC + ".pdf";
        WebClient req = new WebClient();
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + strURL + "");
        byte[] data = req.DownloadData(Server.MapPath(strURL));
        response.BinaryWrite(data);
        response.End();
    }
    private void Downloadscross()//SCRUTINY CROSS LIST
    {
        string[] splbrc = Session["BRCODE"].ToString().Split('|');
        string BRC = splbrc[0].ToString();
        string[] splins = Session["INSCODE"].ToString().Split('|');
        string INS = splins[0].ToString();
        string strURL = "~/Institute/SCRE/S-" + INS + "-" + BRC + ".pdf";
        WebClient req = new WebClient();
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + strURL + "");
        byte[] data = req.DownloadData(Server.MapPath(strURL));
        response.BinaryWrite(data);
        response.End();
    }
    private void Downloadrcross()//RE-EVALUATION CROSS LIST
    {
        string[] splbrc = Session["BRCODE"].ToString().Split('|');
        string BRC = splbrc[0].ToString();
        string[] splins = Session["INSCODE"].ToString().Split('|');
        string INS = splins[0].ToString();
        string strURL = "~/Institute/SCRE/R-" + INS + "-" + BRC + ".pdf";
        WebClient req = new WebClient();
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + strURL + "");
        byte[] data = req.DownloadData(Server.MapPath(strURL));
        response.BinaryWrite(data);
        response.End();
    }
    private void Downloadsbpcross()//SBP CROSS LIST
    {
        string[] splbrc = Session["BRCODE"].ToString().Split('|');
        string BRC = splbrc[0].ToString();
        string[] splins = Session["INSCODE"].ToString().Split('|');
        string INS = splins[0].ToString();
        string strURL = "~/Institute/SBPCROSS/" + INS + "-" + BRC + ".pdf";
        WebClient req = new WebClient();
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + strURL + "");
        byte[] data = req.DownloadData(Server.MapPath(strURL));
        response.BinaryWrite(data);
        response.End();
    }
    private void SCRE(string TYP)
    {
        DataTable dtall = new DataTable();
        dtall.Columns.Add("INSNAME");
        dtall.Columns.Add("BRNAME");
        dtall.Columns.Add("ROLL");
        dtall.Columns.Add("SEM");
        dtall.Columns.Add("SUB");
        dtall.Columns.Add("Theory Marks");
        dtall.Columns.Add("Sessional Marks");
       
        DataRow dr = dtall.NewRow();

        string _sqlQuery = string.Empty;
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        if (TYP == "SCRU") { _sqlQuery = "SELECT * FROM SCRU WHERE ISCOMPLETED='1' ORDER BY INSCODE,BRCODE ASC"; }
        else if (TYP == "REEVA") { _sqlQuery = "SELECT * FROM REEVA WHERE ISCOMPLETED='1' ORDER BY INSCODE,BRCODE ASC"; }
        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] SS = dt.Rows[i]["SUB"].ToString().Split('|');
                for (int j = 0; j < SS.Length; j++)
                {
                    
                    string TH = "";
                    string SE = "";
                    string Semester = "";
                    dr["INSNAME"] = dt.Rows[i]["INSNAME"].ToString();
                    dr["BRNAME"] = dt.Rows[i]["BRNAME"].ToString();
                    dr["ROLL"] = dt.Rows[i]["ROLL"].ToString();
                    dr["SEM"] = dt.Rows[i]["SEM"].ToString();

                    if (dt.Rows[i]["REGPVT"].ToString()=="R")
                    {
                        Semester = dt.Rows[i]["SEM"].ToString();
                    }
                    else
                    {
                        Semester = dt.Rows[i]["REGPVT"].ToString();
                    }

                    GetMarks(dt.Rows[i]["ROLL"].ToString(), SS[j].ToString(), dt.Rows[i]["BRCODE"].ToString(), Semester, out TH, out SE);

                    dr["SUB"] = SS[j].ToString();
                    dr["Theory Marks"] = TH.ToString();
                    dr["Sessional Marks"] = SE.ToString();
                    
                    dtall.Rows.Add(dr);
                    dr = dtall.NewRow();
                }
            }
            ExportToExcel(dtall, TYP);
        }
    }

    public void GetMarks(string Roll, string SUB, string BRCODE, string SEM, out string TH, out string SE)
    {
        TH = "";
        SE = "";
        try
        {
            int cntm = 0;
            int cntb = 0;
            string _sqlQueryreg;
            string[] AllQueryParamreg = new string[1];
            BLL objbllreg = new BLL();
            DataTable dtstu = new DataTable();
            string TBL = string.Empty;
            _sqlQueryreg = "select * FROM  REGISTRATION WHERE ROLL='" + Roll.ToString().Trim() + "'";
            AllQueryParamreg[0] = _sqlQueryreg;
            objbllreg.QUERYBLL(ref dtstu, AllQueryParamreg);
            string STUTYPE = dtstu.Rows[0]["STUTYPE"].ToString().Trim();
            string _sqlQuery = string.Empty;
            if (BRCODE.ToString().Substring(0, 2) == "16")
            {
                conn = new SqlConnection(connectionStringyear);//FOR RESULT ONLY
                _sqlQuery = "select * from PH where ROLL='" + Roll.ToString() + "' ORDER BY SUBSTRING(SESS,4,4) DESC, SUBSTRING(SESS,1,2) DESC";
                cntm = 6;
                cntb = 2;
            }
            else
            {
                conn = new SqlConnection(connectionStringsem);

                if (SEM == "01") { TBL = "SEMESTER1"; }
                else if (SEM == "02") { TBL = "SEMESTER2"; }
                else if (SEM == "03") { TBL = "SEMESTER3"; }
                else if (SEM == "04") { TBL = "SEMESTER4"; }
                else if (SEM == "05") { TBL = "SEMESTER5"; }
                else if (SEM == "06") { TBL = "SEMESTER6"; }
                else { TBL = "PRIVAT"; }
                if (STUTYPE == "N") { TBL = STUTYPE + TBL; }
                _sqlQuery = "select * from " + TBL + " where ROLL='" + Roll.ToString() + "' ORDER BY SUBSTRING(SESS,4,4) DESC, SUBSTRING(SESS,1,2) DESC";
                if (SEM == "01")
                {
                    cntm = 10;
                    cntb = 0;
                }
                else if (SEM == "02" && STUTYPE == "N")
                {
                    cntm = 10;
                    cntb = 17;
                }
                else
                {
                    cntm = 12;
                    cntb = 17;
                }
            }
            DataTable dt1 = new DataTable();
            cmd = new SqlCommand(_sqlQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {

                int found = 0;
                for (int k = 1; k <= cntm; k++)
                {
                    string SUBF = string.Empty;

                    if ((SEM == "P" || SEM == "Q" || SEM == "S") && (BRCODE.ToString().Substring(0, 2) != "16"))
                    { SUBF = dt1.Rows[0]["BPAPT" + k.ToString()].ToString().Trim(); }
                    else { SUBF = dt1.Rows[0]["SUB" + k.ToString()].ToString().Trim(); }

                    if (SUB == SUBF)
                    {
                       // string TH = string.Empty;
                        string TB = string.Empty;
                        //Check OLD Subject
                        _sqlQuery = "select * from SUBJ where SUBCODE='" + SUB + "'";
                        DataTable dt2 = new DataTable();
                        AllQueryParamreg[0] = _sqlQuery;
                        objbllreg.QUERYBLL(ref dt2, AllQueryParamreg);
                        if (dt2.Rows.Count > 0)
                        {
                            if ((SEM == "P" || SEM == "Q" || SEM == "S") && (BRCODE.ToString().Substring(0, 2) != "16"))
                            {
                                TH = dt1.Rows[0]["BMRK" + k.ToString()].ToString().Trim();
                                SE = dt1.Rows[0]["SMRK" + k.ToString()].ToString().Trim();
                                TB = dt1.Rows[0]["BT" + k.ToString()].ToString().Trim();
                            }
                            else
                            {
                                TH = dt1.Rows[0]["TH" + k.ToString()].ToString().Trim();
                                SE = dt1.Rows[0]["TS" + k.ToString()].ToString().Trim();
                                TB = dt1.Rows[0]["GBT" + k.ToString()].ToString().Trim();
                            }
                        }

                        //Check New Subject
                        if (dt2.Rows.Count == 0)
                        {
                            _sqlQuery = "select * from SUBN where SUBCODE='" + SUB + "'";
                            AllQueryParamreg[0] = _sqlQuery;
                            objbllreg.QUERYBLL(ref dt2, AllQueryParamreg);

                            if (TBL == "PRIVAT" || TBL == "NPRIVAT")
                            {
                                TH = dt1.Rows[0]["BMRK" + k.ToString()].ToString().Trim();
                                SE = dt1.Rows[0]["SMRK" + k.ToString()].ToString().Trim();
                            }
                            else
                            {
                                TH = dt1.Rows[0]["T" + k.ToString()].ToString().Trim();
                                SE = dt1.Rows[0]["TS" + k.ToString()].ToString().Trim();

                            }


                        }

                        string SNAME = SUB + "-" + dt2.Rows[0]["SUBJECT"].ToString().Trim();
                        if (TB != "") { TH = TH + " (" + TB + ")"; }
                        found = 1;
                        break;
                    }
                }
                if (found == 0)
                {
                    for (int k = 1; k <= cntb; k++)
                    {
                        string TBACK = dt1.Rows[0]["BPAPT" + k.ToString()].ToString().Trim();
                        if (SUB == TBACK)
                        {
                            _sqlQuery = "select * from SUBJ where SUBCODE='" + SUB + "'";
                            DataTable dt2 = new DataTable();
                            AllQueryParamreg[0] = _sqlQuery;
                            objbllreg.QUERYBLL(ref dt2, AllQueryParamreg);

                            //Check New Subject
                            if (dt2.Rows.Count == 0)
                            {
                                _sqlQuery = "select * from SUBN where SUBCODE='" + SUB + "'";
                                AllQueryParamreg[0] = _sqlQuery;
                                objbllreg.QUERYBLL(ref dt2, AllQueryParamreg);
                            }
                            if (dt2.Rows.Count > 0)
                            {
                                string SNAME = SUB + "-" + dt2.Rows[0]["SUBJECT"].ToString().Trim();
                                TH = dt1.Rows[0]["BMRK" + k.ToString()].ToString().Trim();
                                SE = dt1.Rows[0]["SMRK" + k.ToString()].ToString().Trim();
                                break;
                            }
                        }
                    }
                }
            }

        }
        catch (Exception ex) { Response.Write(ex.Message); }
    }

    private void EXAMINER()
    {
        string _sqlQuery = string.Empty;
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        _sqlQuery = "SELECT EXCODE,EXNAME,EXDESIG,INSCODE,BRCODE,EXCITY,EXDIST,MONO,EMAIL FROM EXAMINER ORDER BY INSCODE,EXNAME ASC";
        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count > 0)
        {
            ExportToExcel(dt, "EXAMINER");
        }
    }
    private void BACKP()
    {
        string _sqlQuery = string.Empty;
        DataTable dt = new DataTable();
        string[] AllQueryParam = new string[1];
        _sqlQuery = "SELECT * FROM BACKP WHERE ISCOMPLETED='1' ORDER BY INSCODE,BRCODE,ROLL ASC";
        AllQueryParam[0] = _sqlQuery;
        BLL objbllLogin = new BLL();
        objbllLogin.QUERYBLL(ref dt, AllQueryParam);
        if (dt.Rows.Count > 0)
        {
            ExportToExcel(dt, "BACKP");
        }
    }
    private void SEMDATA(string SEM)
    {
        DataTable dt = new DataTable();
        string _sqlQuery = string.Empty;
        string[] AllQueryParam = new string[1];
        BLL objbllLogin = new BLL();
        //Get From session
        string FORMSESS = string.Empty;
        DataTable dtsess = new DataTable();
        _sqlQuery = "select * FROM FORMSESS WHERE SESSNAME='FORM'";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtsess, AllQueryParam);
        if (dtsess.Rows.Count > 0)
        {
            FORMSESS = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
        }

        //Semester 1
        DataTable dtsem1 = new DataTable();
        if (SEM == "01" || SEM == "00")
        {
            _sqlQuery = "select * from REGISTRATION where SEM='01' AND SEMSESS1='" + FORMSESS + "' AND SEMCOM1='1' AND REGPVT='R' AND STAT='A' order by CANDIDATEID asc";
            AllQueryParam[0] = _sqlQuery;
            objbllLogin.QUERYBLL(ref dtsem1, AllQueryParam);
        }
        //Semester 2
        DataTable dtsem2 = new DataTable();
        if (SEM == "02" || SEM == "00")
        {
            _sqlQuery = "select * from REGISTRATION where SEM='02' AND SEMSESS2='" + FORMSESS + "' AND SEMCOM2='1' AND REGPVT='R' AND STAT='A' order by CANDIDATEID asc";
            AllQueryParam[0] = _sqlQuery;
            objbllLogin.QUERYBLL(ref dtsem2, AllQueryParam);
        }
        //Semester 3
        DataTable dtsem3 = new DataTable();
        if (SEM == "03" || SEM == "00")
        {
            _sqlQuery = "select * from REGISTRATION where SEM='03' AND SEMSESS3='" + FORMSESS + "' AND SEMCOM3='1' AND REGPVT='R' AND STAT='A' order by CANDIDATEID asc";
            AllQueryParam[0] = _sqlQuery;
            objbllLogin.QUERYBLL(ref dtsem3, AllQueryParam);
        }
        //Semester 4
        DataTable dtsem4 = new DataTable();
        if (SEM == "04" || SEM == "00")
        {
            _sqlQuery = "select * from REGISTRATION where SEM='04' AND SEMSESS4='" + FORMSESS + "' AND SEMCOM4='1' AND REGPVT='R' AND STAT='A' order by CANDIDATEID asc";
            AllQueryParam[0] = _sqlQuery;
            objbllLogin.QUERYBLL(ref dtsem4, AllQueryParam);
        }
        //Semester 5
        DataTable dtsem5 = new DataTable();
        if (SEM == "05" || SEM == "00")
        {
            _sqlQuery = "select * from REGISTRATION where SEM='05' AND SEMSESS5='" + FORMSESS + "' AND SEMCOM5='1' AND REGPVT='R' AND STAT='A' order by CANDIDATEID asc";
            AllQueryParam[0] = _sqlQuery;
            objbllLogin.QUERYBLL(ref dtsem5, AllQueryParam);
        }
        //Semester 6
        DataTable dtsem6 = new DataTable();
        if (SEM == "06" || SEM == "00")
        {
            _sqlQuery = "select * from REGISTRATION where SEM='06' AND SEMSESS6='" + FORMSESS + "' AND SEMCOM6='1' AND REGPVT='R' AND STAT='A' order by CANDIDATEID asc";
            AllQueryParam[0] = _sqlQuery;
            objbllLogin.QUERYBLL(ref dtsem6, AllQueryParam);
        }
        //PRIVATE
        DataTable dtpri = new DataTable();
        if (SEM == "00")
        {
            _sqlQuery = "select * from REGISTRATION where REGPVT='P' AND STAT='A' AND CANDIDATEID IN(SELECT CANDIDATEID FROM BACKP WHERE ISCOMPLETED='1' AND REGPVT='P') order by CANDIDATEID asc";
            AllQueryParam[0] = _sqlQuery;
            objbllLogin.QUERYBLL(ref dtpri, AllQueryParam);
        }
        //SPECIAL
        DataTable dtspl = new DataTable();
        if (SEM == "00")
        {
            _sqlQuery = "select * from REGISTRATION where REGPVT='Q' AND STAT='A' AND CANDIDATEID IN(SELECT CANDIDATEID FROM BACKP WHERE ISCOMPLETED='1' AND REGPVT='Q') order by CANDIDATEID asc";
            AllQueryParam[0] = _sqlQuery;
            objbllLogin.QUERYBLL(ref dtspl, AllQueryParam);
        }
        if (dtsem1.Rows.Count > 0) { dt.Merge(dtsem1); }
        if (dtsem2.Rows.Count > 0) { dt.Merge(dtsem2); }
        if (dtsem3.Rows.Count > 0) { dt.Merge(dtsem3); }
        if (dtsem4.Rows.Count > 0) { dt.Merge(dtsem4); }
        if (dtsem5.Rows.Count > 0) { dt.Merge(dtsem5); }
        if (dtsem6.Rows.Count > 0) { dt.Merge(dtsem6); }
        if (dtpri.Rows.Count > 0) { dt.Merge(dtpri); }
        if (dtspl.Rows.Count > 0) { dt.Merge(dtspl); }

        if (dt.Rows.Count > 0)
        {
            ExportToExcel(dt, "ALL_DATA_" + SEM);
        }
    }
    private void SUBCOUNT(string INSBR)
    {
        DataTable dtdata = new DataTable();
        dtdata.Columns.Add("INSCODE");
        dtdata.Columns.Add("BRCODE");
        dtdata.Columns.Add("SEM");
        dtdata.Columns.Add("STUTYPE");
        dtdata.Columns.Add("SUBCODE");
        dtdata.Columns.Add("COUNT");

        DataTable dt = new DataTable();
        string _sqlQuery = string.Empty;
        string[] AllQueryParam = new string[1];
        BLL objbllLogin = new BLL();
        //Get From session
        string FORMSESS = string.Empty;
        DataTable dtsess = new DataTable();
        _sqlQuery = "select * FROM FORMSESS WHERE SESSNAME='FORM'";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtsess, AllQueryParam);
        if (dtsess.Rows.Count > 0)
        {
            FORMSESS = dtsess.Rows[0]["SESSVAL"].ToString().Trim();
        }

        DataTable dtsub = new DataTable();
        dtsub.Columns.Add("SEM");
        dtsub.Columns.Add("BRCODE");
        dtsub.Columns.Add("SUBCODE");
        dtsub.Columns.Add("TYPE");
        dtsub.Columns.Add("SUBTYPE");
        DataRow dr = dtsub.NewRow();
        //Get Old Subject
        //DataTable dtsubold = new DataTable();
        //_sqlQuery = "SELECT SEM,BRCODE,SUBCODE,TYPE,'O' AS SUBTYPE FROM SUBJ ORDER BY SEM,BRCODE,SUBCODE,TYPE";
        //AllQueryParam[0] = _sqlQuery;
        //objbllLogin.QUERYBLL(ref dtsubold, AllQueryParam);
        //Get New Subject
        DataTable dtsubnew = new DataTable();
        _sqlQuery = "SELECT SEM,BRCODE,SUBCODE,TYPE,'N' AS SUBTYPE FROM SUBN ORDER BY SEM,BRCODE,SUBCODE,TYPE";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtsubnew, AllQueryParam);
        //dtsubnew.Merge(dtsubold);
        for (int i = 0; i < dtsubnew.Rows.Count; i++)
        {

            string SEM = dtsubnew.Rows[i]["SEM"].ToString().Trim();
            string BRCODE = dtsubnew.Rows[i]["BRCODE"].ToString().Trim();
            string SUBCODE = dtsubnew.Rows[i]["SUBCODE"].ToString().Trim();
            string SUBTYPE = dtsubnew.Rows[i]["SUBTYPE"].ToString().Trim();
            string TYPE = dtsubnew.Rows[i]["TYPE"].ToString().Trim();
            if (TYPE.Length == 2)
            {
                dr["SEM"] = SEM;
                dr["BRCODE"] = BRCODE;
                dr["SUBCODE"] = SUBCODE + "T";
                dr["SUBTYPE"] = SUBTYPE;
                dr["TYPE"] = "T";
                dtsub.Rows.Add(dr);
                dr = dtsub.NewRow();
                dr["SEM"] = SEM;
                dr["BRCODE"] = BRCODE;
                dr["SUBCODE"] = SUBCODE + "P";
                dr["SUBTYPE"] = SUBTYPE;
                dr["TYPE"] = "P";
                dtsub.Rows.Add(dr);
                dr = dtsub.NewRow();
            }
            else
            {
                dr["SEM"] = SEM;
                dr["BRCODE"] = BRCODE;
                dr["SUBCODE"] = SUBCODE + TYPE;
                dr["SUBTYPE"] = SUBTYPE;
                dr["TYPE"] = TYPE;
                dtsub.Rows.Add(dr);
                dr = dtsub.NewRow();
            }
        }
        //Semester 1
        DataTable dtsem1 = new DataTable();
        _sqlQuery = "select INSCODE,SUBSTRING(BRCODE,1,2) AS BRCODE,SEM,STUTYPE,COUNT(*) AS CNT from REGISTRATION where SEM='01' AND SEMSESS1='" + FORMSESS + "' AND SEMCOM1='1' AND REGPVT='R' AND STAT='A' GROUP BY INSCODE,SUBSTRING(BRCODE,1,2),SEM,STUTYPE ORDER BY INSCODE,BRCODE,SEM,STUTYPE";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtsem1, AllQueryParam);
        //Semester 2
        DataTable dtsem2 = new DataTable();
        _sqlQuery = "select INSCODE,SUBSTRING(BRCODE,1,2) AS BRCODE,SEM,STUTYPE,COUNT(*) AS CNT from REGISTRATION where SEM='02' AND SEMSESS2='" + FORMSESS + "' AND SEMCOM2='1' AND REGPVT='R' AND STAT='A' GROUP BY INSCODE,SUBSTRING(BRCODE,1,2),SEM,STUTYPE ORDER BY INSCODE,BRCODE,SEM,STUTYPE";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtsem2, AllQueryParam);
        //Semester 3
        DataTable dtsem3 = new DataTable();
        _sqlQuery = "select INSCODE,SUBSTRING(BRCODE,1,2) AS BRCODE,SEM,STUTYPE,COUNT(*) AS CNT from REGISTRATION where SEM='03' AND SEMSESS3='" + FORMSESS + "' AND SEMCOM3='1' AND REGPVT='R' AND STAT='A' GROUP BY INSCODE,SUBSTRING(BRCODE,1,2),SEM,STUTYPE ORDER BY INSCODE,BRCODE,SEM,STUTYPE";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtsem3, AllQueryParam);
        //Semester 4
        DataTable dtsem4 = new DataTable();
        _sqlQuery = "select INSCODE,SUBSTRING(BRCODE,1,2) AS BRCODE,SEM,STUTYPE,COUNT(*) AS CNT from REGISTRATION where SEM='04' AND SEMSESS4='" + FORMSESS + "' AND SEMCOM4='1' AND REGPVT='R' AND STAT='A' GROUP BY INSCODE,SUBSTRING(BRCODE,1,2),SEM,STUTYPE ORDER BY INSCODE,BRCODE,SEM,STUTYPE";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtsem4, AllQueryParam);
        //Semester 5
        DataTable dtsem5 = new DataTable();
        _sqlQuery = "select INSCODE,SUBSTRING(BRCODE,1,2) AS BRCODE,SEM,STUTYPE,COUNT(*) AS CNT from REGISTRATION where SEM='05' AND SEMSESS5='" + FORMSESS + "' AND SEMCOM5='1' AND REGPVT='R' AND STAT='A' GROUP BY INSCODE,SUBSTRING(BRCODE,1,2),SEM,STUTYPE ORDER BY INSCODE,BRCODE,SEM,STUTYPE";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtsem5, AllQueryParam);
        //Semester 6
        DataTable dtsem6 = new DataTable();
        _sqlQuery = "select INSCODE,SUBSTRING(BRCODE,1,2) AS BRCODE,SEM,STUTYPE,COUNT(*) AS CNT from REGISTRATION where SEM='06' AND SEMSESS6='" + FORMSESS + "' AND SEMCOM6='1' AND REGPVT='R' AND STAT='A' GROUP BY INSCODE,SUBSTRING(BRCODE,1,2),SEM,STUTYPE ORDER BY INSCODE,BRCODE,SEM,STUTYPE";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtsem6, AllQueryParam);


        if (dtsem1.Rows.Count > 0) { dt.Merge(dtsem1); }
        if (dtsem2.Rows.Count > 0) { dt.Merge(dtsem2); }
        if (dtsem3.Rows.Count > 0) { dt.Merge(dtsem3); }
        if (dtsem4.Rows.Count > 0) { dt.Merge(dtsem4); }
        if (dtsem5.Rows.Count > 0) { dt.Merge(dtsem5); }
        if (dtsem6.Rows.Count > 0) { dt.Merge(dtsem6); }

        DataRow drdata = dtdata.NewRow();
        for (int s = 0; s < dt.Rows.Count; s++)
        {
            string INSCODE = dt.Rows[s]["INSCODE"].ToString().Trim();
            string BRCODE = dt.Rows[s]["BRCODE"].ToString().Trim();
            string SEM = dt.Rows[s]["SEM"].ToString().Trim();
            string STUTYPE = dt.Rows[s]["STUTYPE"].ToString().Trim();
            string COUNT = dt.Rows[s]["CNT"].ToString().Trim();

            for (int i = 0; i < dtsub.Rows.Count; i++)
            {
                string SUBSEM = dtsub.Rows[i]["SEM"].ToString().Trim();
                string SUBBRCODE = dtsub.Rows[i]["BRCODE"].ToString().Trim();
                string SUBCODE = dtsub.Rows[i]["SUBCODE"].ToString().Trim();
                string SUBSTUTYPE = dtsub.Rows[i]["SUBTYPE"].ToString().Trim();
                string SUBTYPE = dtsub.Rows[i]["TYPE"].ToString().Trim();

                if (SUBSEM == SEM && SUBBRCODE == BRCODE && SUBSTUTYPE == STUTYPE)
                {

                    ////////////////////////////////////////////////////////////////BACKP PAPER
                    DataTable dtbackp = new DataTable();
                    _sqlQuery = "select COUNT(*) AS CNT from BACKP WHERE STAT='A' AND SUBA LIKE '%" + SUBCODE + "%' AND TYPE='B' AND SESS='" + FORMSESS + "' AND ISCOMPLETED='1' AND STUTYPE='" + SUBSTUTYPE + "' AND INSCODE='" + INSCODE + "' AND SUBSTRING(BRCODE,1,2)='" + BRCODE + "'";
                    AllQueryParam[0] = _sqlQuery;
                    objbllLogin.QUERYBLL(ref dtbackp, AllQueryParam);
                    string BCNT = dtbackp.Rows[0]["CNT"].ToString().Trim();
                    if (BCNT == "") { BCNT = "0"; }

                    string CON = (Convert.ToInt32(COUNT) + Convert.ToInt32(BCNT)).ToString();

                    drdata["INSCODE"] = INSCODE;
                    drdata["BRCODE"] = BRCODE;
                    drdata["SEM"] = SEM;
                    drdata["STUTYPE"] = STUTYPE;
                    drdata["SUBCODE"] = SUBCODE;
                    drdata["COUNT"] = CON;
                    dtdata.Rows.Add(drdata);
                    drdata = dtdata.NewRow();
                }
            }
        }
        if (dtdata.Rows.Count > 0)
        {
            ExportToExcel(dtdata, "SUBJECT_COUNT_DATA");
        }
    }
    private void SBPSUB(string TYP)
    {
        DataTable dtall = new DataTable();
        string[] AllQueryParam = new string[1];

        dtall.Columns.Add("SUBCODE");
        dtall.Columns.Add("SUBNAME");
        dtall.Columns.Add("COUNT");


        DataRow dr = dtall.NewRow();
        string _sqlQuery = string.Empty;
        BLL objbllLogin = new BLL();
        DataTable dtsub = new DataTable();
        for (int i = 0; i < 2; i++)
        {
            DataTable dt1 = new DataTable();
            if (i == 0) { _sqlQuery = "SELECT DISTINCT SUBCODE,SUBJECT,TYPE,'O' AS STUTYPE FROM SUBJ ORDER BY SUBCODE ASC"; }
            else if (i == 1) { _sqlQuery = "SELECT DISTINCT SUBCODE,SUBJECT,TYPE,'N' AS STUTYPE FROM SUBN ORDER BY SUBCODE ASC"; }
            AllQueryParam[0] = _sqlQuery;

            objbllLogin.QUERYBLL(ref dt1, AllQueryParam);

            dtsub.Merge(dt1);

        }
        DataTable dt = new DataTable();
        for (int j = 0; j < dtsub.Rows.Count; j++)
        {
            string SUBCODE = dtsub.Rows[j]["SUBCODE"].ToString().Trim();
            string SUBJECT = dtsub.Rows[j]["SUBJECT"].ToString().Trim();
            string TYPE = dtsub.Rows[j]["TYPE"].ToString().Trim();
            string STUTYPE = dtsub.Rows[j]["STUTYPE"].ToString().Trim();

            for (int i = 0; i < TYPE.Length; i++)
            {
                string TT = TYPE[i].ToString();
                string SBB = SUBCODE + TT;

                _sqlQuery = "SELECT COUNT(*) AS CNT FROM BACKP WHERE ISCOMPLETED='1' AND STUTYPE='" + STUTYPE + "' AND SUBA LIKE'%" + SBB + "%' AND TYPE='S'";
                AllQueryParam[0] = _sqlQuery;
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);

                dr["SUBCODE"] = SBB;
                dr["SUBNAME"] = SUBJECT;
                dr["COUNT"] = dt.Rows[0]["CNT"].ToString().Trim();
                dtall.Rows.Add(dr);
                dr = dtall.NewRow();
            }
        }
        ExportToExcel(dtall, TYP);
    }
    private void SBPSUBINSBR(string TYP)
    {
        DataTable dtall = new DataTable();
        string[] AllQueryParam = new string[1];

        dtall.Columns.Add("INSCODE");
        dtall.Columns.Add("BRCODE");
        dtall.Columns.Add("SUBCODE");
        dtall.Columns.Add("SUBNAME");
        dtall.Columns.Add("COUNT");

        DataRow dr = dtall.NewRow();
        string _sqlQuery = string.Empty;
        BLL objbllLogin = new BLL();
        DataTable dtins = new DataTable();
        _sqlQuery = "SELECT DISTINCT INSCODE,SUBSTRING(BRCODE,1,2) AS BRCODE FROM BRLOGIN WHERE BRCODE!='0' ORDER BY INSCODE,BRCODE ASC";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtins, AllQueryParam);
        for (int k = 0; k < dtins.Rows.Count; k++)
        {

            string INSCODE = dtins.Rows[k]["INSCODE"].ToString().Trim();
            string BRCODE = dtins.Rows[k]["BRCODE"].ToString().Trim();
            DataTable dtsub = new DataTable();

            for (int i = 0; i < 2; i++)
            {
                DataTable dt1 = new DataTable();
                if (i == 0) { _sqlQuery = "SELECT DISTINCT SUBCODE,SUBJECT,TYPE,'O' AS STUTYPE FROM SUBJ WHERE BRCODE='" + BRCODE + "' ORDER BY SUBCODE ASC"; }
                else if (i == 1) { _sqlQuery = "SELECT DISTINCT SUBCODE,SUBJECT,TYPE,'N' AS STUTYPE FROM SUBN WHERE BRCODE='" + BRCODE + "' ORDER BY SUBCODE ASC"; }
                AllQueryParam[0] = _sqlQuery;

                objbllLogin.QUERYBLL(ref dt1, AllQueryParam);

                dtsub.Merge(dt1);
            }

            DataTable dt = new DataTable();
            for (int j = 0; j < dtsub.Rows.Count; j++)
            {
                string SUBCODE = dtsub.Rows[j]["SUBCODE"].ToString().Trim();
                string SUBJECT = dtsub.Rows[j]["SUBJECT"].ToString().Trim();
                string TYPE = dtsub.Rows[j]["TYPE"].ToString().Trim();
                string STUTYPE = dtsub.Rows[j]["STUTYPE"].ToString().Trim();

                for (int i = 0; i < TYPE.Length; i++)
                {
                    string TT = TYPE[i].ToString();
                    SUBCODE = SUBCODE + TT;

                    _sqlQuery = "SELECT COUNT(*) AS CNT FROM BACKP WHERE ISCOMPLETED='1' AND STUTYPE='" + STUTYPE + "' AND INSCODE='" + INSCODE + "' AND BRCODE LIKE'%" + BRCODE + "%' AND SUBA LIKE'%" + SUBCODE + "%' AND TYPE='S'";
                    AllQueryParam[0] = _sqlQuery;
                    objbllLogin.QUERYBLL(ref dt, AllQueryParam);

                    dr["INSCODE"] = INSCODE;
                    dr["BRCODE"] = BRCODE;
                    dr["SUBCODE"] = SUBCODE;
                    dr["SUBNAME"] = SUBJECT;
                    dr["COUNT"] = dt.Rows[0]["CNT"].ToString().Trim();
                    dtall.Rows.Add(dr);
                    dr = dtall.NewRow();
                }
            }
        }
        ExportToExcel(dtall, "SBP Ins_Br Subject Count");
    }



    private void BACKSUB(string TYP)
    {
        DataTable dtall = new DataTable();
        string[] AllQueryParam = new string[1];

        dtall.Columns.Add("SUBCODE");
        dtall.Columns.Add("SUBNAME");
        dtall.Columns.Add("COUNT");


        DataRow dr = dtall.NewRow();
        string _sqlQuery = string.Empty;
        BLL objbllLogin = new BLL();
        DataTable dtsub = new DataTable();
        for (int i = 0; i < 2; i++)
        {
            DataTable dt1 = new DataTable();
            if (i == 0) { _sqlQuery = "SELECT DISTINCT SUBCODE,SUBJECT,TYPE,'O' AS STUTYPE FROM SUBJ ORDER BY SUBCODE ASC"; }
            else if (i == 1) { _sqlQuery = "SELECT DISTINCT SUBCODE,SUBJECT,TYPE,'N' AS STUTYPE FROM SUBN ORDER BY SUBCODE ASC"; }
            AllQueryParam[0] = _sqlQuery;

            objbllLogin.QUERYBLL(ref dt1, AllQueryParam);

            dtsub.Merge(dt1);

        }
        DataTable dt = new DataTable();
        for (int j = 0; j < dtsub.Rows.Count; j++)
        {
            string SUBCODE = dtsub.Rows[j]["SUBCODE"].ToString().Trim();
            string SUBJECT = dtsub.Rows[j]["SUBJECT"].ToString().Trim();
            string TYPE = dtsub.Rows[j]["TYPE"].ToString().Trim();
            string STUTYPE = dtsub.Rows[j]["STUTYPE"].ToString().Trim();

            for (int i = 0; i < TYPE.Length; i++)
            {
                string TT = TYPE[i].ToString();
                string SBB = SUBCODE + TT;

                _sqlQuery = "SELECT COUNT(*) AS CNT FROM BACKP WHERE ISCOMPLETED='1' AND STUTYPE='" + STUTYPE + "' AND SUBA LIKE'%" + SBB + "%' AND TYPE='B'";
                AllQueryParam[0] = _sqlQuery;
                objbllLogin.QUERYBLL(ref dt, AllQueryParam);

                dr["SUBCODE"] = SBB;
                dr["SUBNAME"] = SUBJECT;
                dr["COUNT"] = dt.Rows[0]["CNT"].ToString().Trim();
                dtall.Rows.Add(dr);
                dr = dtall.NewRow();
            }
        }
        ExportToExcel(dtall, TYP);
    }
    private void BACKSUBINSBR(string TYP)
    {
        DataTable dtall = new DataTable();
        string[] AllQueryParam = new string[1];

        dtall.Columns.Add("INSCODE");
        dtall.Columns.Add("BRCODE");
        dtall.Columns.Add("SUBCODE");
        dtall.Columns.Add("SUBNAME");
        dtall.Columns.Add("COUNT");

        DataRow dr = dtall.NewRow();
        string _sqlQuery = string.Empty;
        BLL objbllLogin = new BLL();
        DataTable dtins = new DataTable();
        _sqlQuery = "SELECT DISTINCT INSCODE,SUBSTRING(BRCODE,1,2) AS BRCODE FROM BRLOGIN WHERE BRCODE!='0' ORDER BY INSCODE,BRCODE ASC";
        AllQueryParam[0] = _sqlQuery;
        objbllLogin.QUERYBLL(ref dtins, AllQueryParam);
        for (int k = 0; k < dtins.Rows.Count; k++)
        {

            string INSCODE = dtins.Rows[k]["INSCODE"].ToString().Trim();
            string BRCODE = dtins.Rows[k]["BRCODE"].ToString().Trim();
            DataTable dtsub = new DataTable();

            for (int i = 0; i < 2; i++)
            {
                DataTable dt1 = new DataTable();
                if (i == 0) { _sqlQuery = "SELECT DISTINCT SUBCODE,SUBJECT,TYPE,'O' AS STUTYPE FROM SUBJ WHERE BRCODE='" + BRCODE + "' ORDER BY SUBCODE ASC"; }
                else if (i == 1) { _sqlQuery = "SELECT DISTINCT SUBCODE,SUBJECT,TYPE,'N' AS STUTYPE FROM SUBN WHERE BRCODE='" + BRCODE + "' ORDER BY SUBCODE ASC"; }
                AllQueryParam[0] = _sqlQuery;

                objbllLogin.QUERYBLL(ref dt1, AllQueryParam);

                dtsub.Merge(dt1);
            }

            DataTable dt = new DataTable();
            for (int j = 0; j < dtsub.Rows.Count; j++)
            {
                string SUBCODE = dtsub.Rows[j]["SUBCODE"].ToString().Trim();
                string SUBJECT = dtsub.Rows[j]["SUBJECT"].ToString().Trim();
                string TYPE = dtsub.Rows[j]["TYPE"].ToString().Trim();
                string STUTYPE = dtsub.Rows[j]["STUTYPE"].ToString().Trim();

                for (int i = 0; i < TYPE.Length; i++)
                {
                    string TT = TYPE[i].ToString();
                    SUBCODE = SUBCODE + TT;

                    _sqlQuery = "SELECT COUNT(*) AS CNT FROM BACKP WHERE ISCOMPLETED='1' AND STUTYPE='" + STUTYPE + "' AND INSCODE='" + INSCODE + "' AND BRCODE LIKE'%" + BRCODE + "%' AND SUBA LIKE'%" + SUBCODE + "%' AND TYPE='B'";
                    AllQueryParam[0] = _sqlQuery;
                    objbllLogin.QUERYBLL(ref dt, AllQueryParam);

                    dr["INSCODE"] = INSCODE;
                    dr["BRCODE"] = BRCODE;
                    dr["SUBCODE"] = SUBCODE;
                    dr["SUBNAME"] = SUBJECT;
                    dr["COUNT"] = dt.Rows[0]["CNT"].ToString().Trim();
                    dtall.Rows.Add(dr);
                    dr = dtall.NewRow();
                }
            }
        }
        ExportToExcel(dtall, "Back Ins_Br Subject Count");
    }





    private void ExportToExcel(DataTable dt, string Filename)//Export
    {
        if (dt.Rows.Count > 0)
        {
            //DataRow dr = dt.NewRow();
            //dr[0] = Filename+" DATA";
            //dt.Rows.InsertAt(dr, 0);
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "Sheet1");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + Filename + ".xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            //***************************************************************************************************************************2
            //var wbook = new XLWorkbook();
            //var ws = wbook.Worksheets.Add("Sheet1");
            //Response.Clear();
            //Response.Buffer = true;
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AddHeader("content-disposition", "attachment;filename=" + Filename + ".xlsx");
            //ws.Cell("A1").Value = "150";
            //ws.Cell("A1").Style.Protection.SetLocked();
            //ws.Style.Protection.SetLocked();

            //using (MemoryStream MyMemoryStream = new MemoryStream())
            //{
            //    wbook.SaveAs(MyMemoryStream);
            //    MyMemoryStream.WriteTo(Response.OutputStream);
            //    Response.Flush();
            //    Response.End();
            //}
            //************************************************************************************************************************3
            //System.IO.StringWriter tw = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            //DataGrid dgGrid = new DataGrid();
            //dgGrid.DataSource = dt;
            //dgGrid.DataBind();
            ////Get the HTML for the control.
            //dgGrid.RenderControl(hw);
            ////Write the HTML back to the browser.
            ////Response.ContentType = application/vnd.ms-excel;
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Filename + ".xls");
            //this.EnableViewState = false;
            //Response.Write(tw.ToString());
            //Response.End();
        }
    }
}