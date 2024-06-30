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

public partial class Regsummary : System.Web.UI.Page
{
    public string ONLINE = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ONLINE = Application["Online"].ToString();
            if (Session["ADMIN"] == null) { Response.Redirect("~/Admin/Adminlogin.aspx", false); }
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                dt.Columns.Add("STRTSESS");
                dt.Columns.Add("SEM01");
                dt.Columns.Add("SEM02");
                dt.Columns.Add("SEM03");
                dt.Columns.Add("SEM04");
                dt.Columns.Add("SEM05");
                dt.Columns.Add("SEM06");
                dt.Columns.Add("PVT");
                dt.Columns.Add("QUA");
                dt.Columns.Add("TOT");
                //Category Wise Summary
                string cntquery = string.Empty;
                string _sqlQueryreg = string.Empty;
                DataTable dtreg = new DataTable();
                string[] AllQueryParamreg = new string[1];
                _sqlQueryreg = "SELECT DISTINCT STRTSESS FROM REGISTRATION GROUP BY STRTSESS ORDER BY STRTSESS ASC";
                AllQueryParamreg[0] = _sqlQueryreg;
                BLL objbllreg = new BLL();
                objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
                if (dtreg.Rows.Count > 0)
                {
                    //All Total
                    int ALLSEM01 = 0;
                    int ALLSEM02 = 0;
                    int ALLSEM03 = 0;
                    int ALLSEM04 = 0;
                    int ALLSEM05 = 0;
                    int ALLSEM06 = 0;
                    int ALLPVT = 0;
                    int ALLQUA = 0;
                    int ALLTOT = 0;

                    for (int i = 0; i < dtreg.Rows.Count; i++)
                    {
                        string STRTSESS = dtreg.Rows[i]["STRTSESS"].ToString();
                        dr["STRTSESS"] = STRTSESS;
                        int SESSTOT = 0;
                        for (int j = 1; j <= 8; j++)
                        {
                            string SEM = string.Empty;
                            SEM = "0" + j.ToString();
                            DataTable dtSUM = new DataTable();
                            if (j == 7) { _sqlQueryreg = "SELECT COUNT(*) AS TOT FROM REGISTRATION WHERE STRTSESS='" + STRTSESS + "' AND REGPVT='P' AND STAT='A'"; }
                            else if (j == 8) { _sqlQueryreg = "SELECT COUNT(*) AS TOT FROM REGISTRATION WHERE STRTSESS='" + STRTSESS + "' AND REGPVT='Q' AND STAT='A'"; }
                            else { _sqlQueryreg = "SELECT COUNT(*) AS TOT FROM REGISTRATION WHERE STRTSESS='" + STRTSESS + "' AND SEM='" + SEM + "' AND REGPVT='R' AND STAT='A'"; }
                            AllQueryParamreg[0] = _sqlQueryreg;
                            objbllreg.QUERYBLL(ref dtSUM, AllQueryParamreg);

                            string TOT = dtSUM.Rows[0]["TOT"].ToString();
                            if (j == 1) { dr["SEM01"] = TOT; ALLSEM01 = ALLSEM01 + Convert.ToInt32(TOT); }
                            else if (j == 2) { dr["SEM02"] = TOT; ALLSEM02 = ALLSEM02 + Convert.ToInt32(TOT); }
                            else if (j == 3) { dr["SEM03"] = TOT; ALLSEM03 = ALLSEM03 + Convert.ToInt32(TOT); }
                            else if (j == 4) { dr["SEM04"] = TOT; ALLSEM04 = ALLSEM04 + Convert.ToInt32(TOT); }
                            else if (j == 5) { dr["SEM05"] = TOT; ALLSEM05 = ALLSEM05 + Convert.ToInt32(TOT); }
                            else if (j == 6) { dr["SEM06"] = TOT; ALLSEM06 = ALLSEM06 + Convert.ToInt32(TOT); }
                            else if (j == 7) { dr["PVT"] = TOT; ALLPVT = ALLPVT + Convert.ToInt32(TOT); }
                            else if (j == 8) { dr["QUA"] = TOT; ALLQUA = ALLQUA + Convert.ToInt32(TOT); }

                            SESSTOT = SESSTOT + Convert.ToInt32(TOT);
                            ALLTOT = ALLTOT + Convert.ToInt32(TOT);
                        }
                        dr["TOT"] = SESSTOT.ToString();
                        dt.Rows.Add(dr);
                        dr = dt.NewRow();
                    }

                    dr = dt.NewRow();
                    dr["STRTSESS"] = "TOTAL";
                    dr["SEM01"] = ALLSEM01.ToString();
                    dr["SEM02"] = ALLSEM02.ToString();
                    dr["SEM03"] = ALLSEM03.ToString();
                    dr["SEM04"] = ALLSEM04.ToString();
                    dr["SEM05"] = ALLSEM05.ToString();
                    dr["SEM06"] = ALLSEM06.ToString();
                    dr["PVT"] = ALLPVT.ToString();
                    dr["QUA"] = ALLQUA.ToString();
                    dr["TOT"] = ALLTOT.ToString();
                    dt.Rows.Add(dr);

                    Grddata.DataSource = dt;
                    Grddata.DataBind();
                    LblMessage.Text = "";
                    Grddata.Rows[Grddata.Rows.Count - 1].BackColor = System.Drawing.Color.DodgerBlue;
                    Grddata.Rows[Grddata.Rows.Count - 1].ForeColor = System.Drawing.Color.White;
                }
                else { LblMessage.Text = "कोई डाटा नही मिला।"; }
            }
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }
}
