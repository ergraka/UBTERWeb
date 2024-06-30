using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using _Examination;

public partial class Nominal : System.Web.UI.Page
{
    public string INSNAME = string.Empty;
    public string BRNAME = string.Empty;
    public string SEMYEAR = string.Empty;
    public string FEE = string.Empty;
    public string CP = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
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
                    string CLM = string.Empty;
                    string FEECLM = string.Empty;
                    string SESSCLM = string.Empty;
                    if (Request.QueryString["TYP"] != null)
                    {
                        SEM = Request.QueryString["TYP"].ToString().Trim();
                        SEMYEAR = SEM;
                        if (SEM == "01") { CLM = "SEMCOM1"; FEECLM = "SEMFEE1"; SESSCLM = "SEMSESS1"; }
                        else if (SEM == "02") { CLM = "SEMCOM2"; FEECLM = "SEMFEE2"; SESSCLM = "SEMSESS2"; }
                        else if (SEM == "03") { CLM = "SEMCOM3"; FEECLM = "SEMFEE3"; SESSCLM = "SEMSESS3"; }
                        else if (SEM == "04") { CLM = "SEMCOM4"; FEECLM = "SEMFEE4"; SESSCLM = "SEMSESS4"; }
                        else if (SEM == "05") { CLM = "SEMCOM5"; FEECLM = "SEMFEE5"; SESSCLM = "SEMSESS5"; }
                        else if (SEM == "06") { CLM = "SEMCOM6"; FEECLM = "SEMFEE6"; SESSCLM = "SEMSESS6"; }
                        else if (SEM == "P") { SEMYEAR = "PRIVATE"; }
                        else if (SEM == "Q") { SEMYEAR = "QUALIFIED"; }
                    }
                    else { Response.Redirect("~/Error.aspx", false); }
                    string _sqlQueryreg = string.Empty;
                   
                    string[] insspl = Session["INSCODE"].ToString().Split('|');
                    string[] brspl = Session["BRCODE"].ToString().Split('|');
                    DataTable dtreg = new DataTable();
                    string[] AllQueryParamreg = new string[1];
                    if (SEM == "P") { _sqlQueryreg = "select INSNAME,BRNAME,CANDIDATEID,ROLL,JROLL,CNAME,FNAME,DOB,GENDER,CAT,SEM,SPLFEE AS FEE from REGISTRATION where STAT='A' AND REGPVT='P' AND INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' AND CANDIDATEID IN(SELECT CANDIDATEID FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='B') order by ROLL,CNAME ASC"; }
                    else if (SEM == "Q") { _sqlQueryreg = "select INSNAME,BRNAME,CANDIDATEID,ROLL,JROLL,CNAME,FNAME,DOB,GENDER,CAT,SEM,'530' AS FEE from REGISTRATION where STAT='A' AND REGPVT='Q' AND INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' AND CANDIDATEID IN(SELECT CANDIDATEID FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='B') order by ROLL,CNAME ASC"; }
                    else { _sqlQueryreg = "select INSNAME,BRNAME,CANDIDATEID,ROLL,JROLL,CNAME,FNAME,DOB,GENDER,CAT,SEM," + FEECLM + " AS FEE from REGISTRATION where STAT='A' AND REGPVT='R' AND INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' and " + CLM + "='1' and " + SESSCLM + "='" + SESS + "' AND SEM='" + SEM + "' order by ROLL,CNAME ASC"; }
                    AllQueryParamreg[0] = _sqlQueryreg;
                    BLL objbllreg = new BLL();
                    objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                    if (dtreg.Rows.Count > 0)
                    {
                        GridView1.DataSource = dtreg;
                        GridView1.DataBind();
                        INSNAME = dtreg.Rows[0]["INSNAME"].ToString().Trim();
                        BRNAME = dtreg.Rows[0]["BRNAME"].ToString().Trim();
                    }
                    DataTable dtreg1 = new DataTable();
                    string[] AllQueryParamreg1 = new string[1];
                    string _sqlQueryreg1 = string.Empty;
                    if (SEM == "P") { _sqlQueryreg1 = "select SUM(SPLFEE) as TOTAL from REGISTRATION where STAT='A' AND REGPVT='P' AND INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' AND CANDIDATEID IN(SELECT CANDIDATEID FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='B')"; }
                    else if (SEM == "Q") { _sqlQueryreg1 = "select * from REGISTRATION where STAT='A' AND REGPVT='Q' AND INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' AND CANDIDATEID IN(SELECT CANDIDATEID FROM BACKP WHERE ISCOMPLETED='1' AND TYPE='B')"; }
                    else { _sqlQueryreg1 = "select SUM(" + FEECLM + ") as TOTAL from REGISTRATION where STAT='A' AND REGPVT='R' AND INSCODE='" + insspl[0].ToString() + "' and BRCODE='" + brspl[0].ToString() + "' and " + CLM + "='1' and " + SESSCLM + "='" + SESS + "' AND SEM='" + SEM + "'"; }

                    if (SEM != "Q")
                    {
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
                    else
                    {
                        int F = 530 * dtreg.Rows.Count;
                        string FF = ConvertNumbertoWords(F);
                        FEE = F.ToString() + " (" + FF + " )";
                    }
                }
                else { Response.Redirect("~/Default.aspx", false); }

            }
        }
        catch (Exception ex) { }
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