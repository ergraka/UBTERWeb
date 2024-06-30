using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using _Examination;
using System.Data.SqlClient;
public partial class Nominalreeva : System.Web.UI.Page
{
    public string INSNAME = string.Empty;
    public string BRNAME = string.Empty;
    public string SEMESTER = string.Empty;
    public string FEE = string.Empty;
    public DateTime indianTime;
    public string CP = string.Empty;

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
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            if (!IsPostBack)
            {
                if (Session["ADMIN"] != null || Session["BRCODE"] != null)
                {

                    string SESS = Getsession();
                    string[] MM = SESS.Split('-');
                    if (MM[0].ToString() == "06") { CP = "SUMMER"; }
                    else if (MM[0].ToString() == "12") { CP = "WINTER"; }
                    CP = CP + "-" + MM[1].ToString();

                    string SEM = string.Empty;
                    if (Request.QueryString["TYP"] != null)
                    {
                        SEM = Request.QueryString["TYP"].ToString().Trim();
                        SEMESTER = SEM;
                        if (SEMESTER == "P") { SEMESTER = "PRIVATE"; }
                        else if (SEMESTER == "Q") { SEMESTER = "QUALIFIED"; }
                    }
                    else { Response.Redirect("~/Error.aspx", false); }
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ROLL");
                    dt.Columns.Add("CNAME");
                    dt.Columns.Add("BRCODE");
                    dt.Columns.Add("SUB");
                    dt.Columns.Add("SUBNAME");
                    dt.Columns.Add("MARKS");
                    dt.Columns.Add("FEE");
                    DataRow dr = dt.NewRow();
                    string[] insspl = Session["INSCODE"].ToString().Split('|');
                    string[] brspl = Session["BRCODE"].ToString().Split('|');


                    string[] AllQueryParamreg = new string[1];
                    string _sqlQueryreg = string.Empty;

                    DataTable dtreg = new DataTable();
                    if (SEM == "P") { _sqlQueryreg = "select * FROM REEVA where INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' and ISCOMPLETED='1' AND REGPVT='P' order by ROLL ASC"; }
                    else if (SEM == "Q") { _sqlQueryreg = "select * FROM REEVA where INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' and ISCOMPLETED='1' AND REGPVT='Q' order by ROLL ASC"; }
                    else { _sqlQueryreg = "select * FROM REEVA where INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' and ISCOMPLETED='1' AND SEM='" + SEM + "' AND REGPVT='R' order by ROLL ASC"; }
                    AllQueryParamreg[0] = _sqlQueryreg;
                    BLL objbllreg = new BLL();
                    objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                    
                    if (dtreg.Rows.Count > 0)
                    {
                        int cntm = 0;
                        int cntb = 0;
                        for (int i = 0; i < dtreg.Rows.Count; i++)
                        {

                            DataTable dtstu = new DataTable();
                            string TBL = string.Empty;
                            _sqlQueryreg = "select * FROM  REGISTRATION WHERE ROLL='" + dtreg.Rows[i]["ROLL"].ToString().Trim() + "'";
                            AllQueryParamreg[0] = _sqlQueryreg;
                            objbllreg.QUERYBLL(ref dtstu, AllQueryParamreg);
                            string STUTYPE = dtstu.Rows[0]["STUTYPE"].ToString().Trim();

                            dr["ROLL"] = dtreg.Rows[i]["ROLL"].ToString();
                            dr["CNAME"] = dtreg.Rows[i]["CNAME"].ToString();
                            dr["BRCODE"] = dtreg.Rows[i]["BRCODE"].ToString();

                            string _sqlQuery = string.Empty;
                            if (dtreg.Rows[i]["BRCODE"].ToString().Substring(0, 2) == "16")
                            {
                                conn = new SqlConnection(connectionStringyear);//FOR RESULT ONLY
                                _sqlQuery = "select * from PH where ROLL='" + dtreg.Rows[i]["ROLL"].ToString() + "' ORDER BY SUBSTRING(SESS,4,4) DESC, SUBSTRING(SESS,1,2) DESC";
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
                                _sqlQuery = "select * from " + TBL + " where ROLL='" + dtreg.Rows[i]["ROLL"].ToString() + "' ORDER BY SUBSTRING(SESS,4,4) DESC, SUBSTRING(SESS,1,2) DESC";
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
                            if (dt1.Rows.Count > 0 )
                            {
                                string[] SPLSUB = dtreg.Rows[i]["SUB"].ToString().Split('|');
                                for (int j = 0; j < SPLSUB.Length; j++)
                                {
                                    int found = 0;
                                    string SUB = SPLSUB[j].ToString();

                                   

                                    for (int k = 1; k <= cntm; k++)
                                    {
                                        string SUBF = string.Empty;

                                        if ((SEM == "P" || SEM == "Q" || SEM == "S") && (dtreg.Rows[i]["BRCODE"].ToString().Substring(0, 2) != "16"))
                                        { SUBF = dt1.Rows[0]["BPAPT" + k.ToString()].ToString().Trim(); }
                                        else { SUBF = dt1.Rows[0]["SUB" + k.ToString()].ToString().Trim(); }

                                        if (SUB == SUBF)
                                        {
                                            string TH = string.Empty;
                                            string TB = string.Empty;
                                            //Check OLD Subject
                                            _sqlQuery = "select * from SUBJ where SUBCODE='" + SUB + "'";
                                            DataTable dt2 = new DataTable();
                                            AllQueryParamreg[0] = _sqlQuery;
                                            objbllreg.QUERYBLL(ref dt2, AllQueryParamreg);
                                            if (dt2.Rows.Count > 0) 
                                            {
                                                if ((SEM == "P" || SEM == "Q" || SEM == "S") && (dtreg.Rows[i]["BRCODE"].ToString().Substring(0, 2) != "16"))
                                                {
                                                    TH = dt1.Rows[0]["BMRK" + k.ToString()].ToString().Trim();
                                                    TB = dt1.Rows[0]["BT" + k.ToString()].ToString().Trim();
                                                }
                                                else
                                                {
                                                    TH = dt1.Rows[0]["TH" + k.ToString()].ToString().Trim();
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
                                                }
                                                else
                                                {
                                                    TH = dt1.Rows[0]["T" + k.ToString()].ToString().Trim();

                                                }

                                                
                                            }

                                            string SNAME = SUB + "-" + dt2.Rows[0]["SUBJECT"].ToString().Trim();
                                            if (TB != "") { TH = TH + " (" + TB + ")"; }
                                            dr["SUB"] = SUB;
                                            dr["SUBNAME"] = SNAME;
                                            dr["MARKS"] = TH;
                                            dr["FEE"] = "2000/-";
                                            dt.Rows.Add(dr);
                                            dr = dt.NewRow();
                                            dr["ROLL"] = dtreg.Rows[i]["ROLL"].ToString();
                                            dr["CNAME"] = dtreg.Rows[i]["CNAME"].ToString();
                                            dr["BRCODE"] = dtreg.Rows[i]["BRCODE"].ToString();
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
                                                    string TH = dt1.Rows[0]["BMRK" + k.ToString()].ToString().Trim();

                                                    dr["SUB"] = SUB;
                                                    dr["SUBNAME"] = SNAME;
                                                    dr["MARKS"] = TH;
                                                    dr["FEE"] = "2000/-";
                                                    dt.Rows.Add(dr);
                                                    dr = dt.NewRow();
                                                    dr["ROLL"] = dtreg.Rows[i]["ROLL"].ToString();
                                                    dr["CNAME"] = dtreg.Rows[i]["CNAME"].ToString();
                                                    dr["BRCODE"] = dtreg.Rows[i]["BRCODE"].ToString();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    INSNAME = dtreg.Rows[0]["INSNAME"].ToString().Trim();
                    BRNAME = dtreg.Rows[0]["BRNAME"].ToString().Trim();

                    DataTable dtreg1 = new DataTable();
                    string[] AllQueryParamreg1 = new string[1];
                    string _sqlQueryreg1 = string.Empty;
                    if (SEM == "P") { _sqlQueryreg1 = "select SUM(CONVERT(INT,FEE)) as TOTAL from REEVA where INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' AND ISCOMPLETED='1' AND REGPVT='P'"; }
                    else if (SEM == "Q") { _sqlQueryreg1 = "select SUM(CONVERT(INT,FEE)) as TOTAL from REEVA where INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' AND ISCOMPLETED='1' AND REGPVT='Q'"; }
                    else { _sqlQueryreg1 = "select SUM(CONVERT(INT,FEE)) as TOTAL from REEVA where INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' AND SEM='" + SEM + "' AND ISCOMPLETED='1' AND REGPVT='R'"; }
                    AllQueryParamreg1[0] = _sqlQueryreg1;
                    BLL objbllreg1 = new BLL();
                    objbllreg1.QUERYBLL(ref dtreg1, AllQueryParamreg1);
                    if (dtreg1.Rows.Count > 0)
                    {
                        FEE = dtreg1.Rows[0]["TOTAL"].ToString();
                        string FF = ConvertNumbertoWords(Convert.ToInt32(FEE));
                        FEE = FEE + " (" + FF + " )";
                    }
                }
                else { Response.Redirect("~/Default.aspx", false); }
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
    public static string ConvertNumbertoWords(int number)
    {
        if (number == 0)
            return "ZERO";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
            number %= 1000000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        if (number > 0)
        {
            if (words != "")
                words += "AND ";
            var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }
}