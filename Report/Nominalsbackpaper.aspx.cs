using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using _Examination;
public partial class Nominalsbackpaper : System.Web.UI.Page
{
    public string INSNAME = string.Empty;
    public string BRNAME = string.Empty;
    public string FEE = string.Empty;
    public string TYPSEM = string.Empty;
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
                    if (Request.QueryString["TYP"] != null)
                    {
                        SEM = Request.QueryString["TYP"].ToString().Trim();
                        TYPSEM = SEM;
                        if (TYPSEM == "P") { TYPSEM = "PRIVATE"; }
                        else if (TYPSEM == "Q") { TYPSEM = "QUALIFIED"; }
                    }
                    else { Response.Redirect("~/Error.aspx", false); }
                    string[] insspl = Session["INSCODE"].ToString().Split('|');
                    string[] brspl = Session["BRCODE"].ToString().Split('|');
                    DataTable dtreg = new DataTable();
                    string[] AllQueryParamreg = new string[1];
                    string _sqlQueryreg = string.Empty;
                    if (SEM == "P") { _sqlQueryreg = "select * FROM BACKP where INSCODE='" + insspl[0].ToString() + "' AND TYPE='S' and BRCODE='" + brspl[0].ToString() + "' and ISCOMPLETED='1' AND REGPVT='P' AND STAT='A' order by ROLl ASC"; }
                    else if (SEM == "Q") { _sqlQueryreg = "select * FROM BACKP where INSCODE='" + insspl[0].ToString() + "' AND TYPE='S' and BRCODE='" + brspl[0].ToString() + "' and ISCOMPLETED='1' AND REGPVT='Q' AND STAT='A' order by ROLl ASC"; }
                    else { _sqlQueryreg = "select * FROM BACKP where INSCODE='" + insspl[0].ToString() + "' AND TYPE='S' and BRCODE='" + brspl[0].ToString() + "' and ISCOMPLETED='1' AND SEM='" + SEM + "' AND REGPVT='R' AND STAT='A' order by ROLl ASC"; }
                    AllQueryParamreg[0] = _sqlQueryreg;
                    BLL objbllreg = new BLL();
                    objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                    if (dtreg.Rows.Count > 0)
                    {
                        GridView1.DataSource = dtreg;
                        GridView1.DataBind();
                    }
                    INSNAME = dtreg.Rows[0]["INSNAME"].ToString().Trim();
                    BRNAME = dtreg.Rows[0]["BRNAME"].ToString().Trim();

                    DataTable dtreg1 = new DataTable();
                    string[] AllQueryParamreg1 = new string[1];
                    if (SEM == "P") { _sqlQueryreg = "select SUM(CONVERT(INT,FEE)) as TOTAL from BACKP where INSCODE='" + insspl[0].ToString() + "' AND TYPE='S' and BRCODE='" + brspl[0].ToString() + "' and ISCOMPLETED='1' AND STAT='A' AND REGPVT='P'"; }
                    else if (SEM == "Q") { _sqlQueryreg = "select SUM(CONVERT(INT,FEE)) as TOTAL from BACKP where INSCODE='" + insspl[0].ToString() + "' AND TYPE='S' and BRCODE='" + brspl[0].ToString() + "' and ISCOMPLETED='1' AND STAT='A' AND REGPVT='Q'"; }
                    else { _sqlQueryreg = "select SUM(CONVERT(INT,FEE)) as TOTAL from BACKP where INSCODE='" + insspl[0].ToString() + "' AND TYPE='S' and BRCODE='" + brspl[0].ToString() + "' and ISCOMPLETED='1' AND SEM='" + SEM + "' AND STAT='A' AND REGPVT='R'"; }
                    AllQueryParamreg1[0] = _sqlQueryreg;
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