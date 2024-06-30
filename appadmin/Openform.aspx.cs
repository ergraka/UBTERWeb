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

public partial class Openform : System.Web.UI.Page
{
    string SEM = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (!IsPostBack)
            {
                Griddata();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            INSERTDATA();
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    private void INSERTDATA()
    {
        if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }

        string REG = "N";
        string BACKP = "N";
        string SBACKP = "N";
        string SCRU = "N";
        string REEVA = "N";

        if (Chkreg.Checked == true) { REG = "Y"; }
        if (Chkbackp.Checked == true) { BACKP = "Y"; }
        if (Chksbackp.Checked == true) { SBACKP = "Y"; }
        if (Chkscru.Checked == true) { SCRU = "Y"; }
        if (Chkreeva.Checked == true) { REEVA = "Y"; }

        BLL _Objbll = new BLL();
        string _sqlQuery = string.Empty;

        string LongParam = Txtworkname.Text + "|" + Txtdatef.Text + "|" + Txtdatee.Text +'|'+ Drpstat.SelectedValue + "|" + Drpdisplay.SelectedValue + "|" + REG + "|" + BACKP + "|" + SBACKP + "|" + SCRU + "|" + REEVA;

       // _sqlQuery = "INSERT INTO WORKS(WORKNAME,STAT,DISPLAY,DATEF,DATET,REG,BACKP,SBACKP,SCRU,REEVA) VALUES('" + Txtworkname.Text + "','" + Drpstat.SelectedValue + "','" + Drpdisplay.SelectedValue + "','" + Txtdatef.Text + "','" + Txtdatee.Text + "','" + REG + "','" + BACKP + "','" + SBACKP + "','" + SCRU + "','" + REEVA + "')";
        //string result = _Objbll.ONLYQUERYBLL(_sqlQuery);

        string result = _Objbll.WorkCRUD("CreateWorks", "", LongParam);

        if (result == "1-1")
        {
            ltrlMessage.Text = "New Records Added Successfully.";
            Griddata();

            Txtworkname.Text = "";
            Txtdatef.Text = "";
            Txtdatee.Text = "";
            Drpstat.SelectedIndex = 0;
            Drpdisplay.SelectedIndex = 0;
            Chkreg.Checked = false;
            Chkbackp.Checked = false;
            Chksbackp.Checked = false;
            Chkscru.Checked = false;
            Chkreeva.Checked = false;
        }
        else { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void Grdedit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (IsPostBack)
            {
                Grdedit.EditIndex = e.NewEditIndex;
                Griddata();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "कृप्या कुछ समय के बाद प्रयास करें।"; }
    }
    protected void Grdedit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (IsPostBack)
            {
                Grdedit.EditIndex = -1;
                Griddata();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "कृप्या कुछ समय के बाद प्रयास करें।"; }
    }
    protected void Grdedit_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            BLL _Objbll = new BLL();
            string _sqlQuery = string.Empty;
            string WORKID = Grdedit.DataKeys[e.RowIndex].Value.ToString();

            GridViewRow row = (GridViewRow)Grdedit.Rows[e.RowIndex];
            TextBox TXTWORKNAME = (TextBox)row.Cells[2].Controls[0];
            TextBox TXTDATES = (TextBox)row.Cells[3].Controls[0];
            TextBox TXTDATEE = (TextBox)row.Cells[4].Controls[0];
            TextBox TXTSTAT = (TextBox)row.Cells[5].Controls[0];
            TextBox TXTDISPALY = (TextBox)row.Cells[6].Controls[0];
            TextBox TXTREG = (TextBox)row.Cells[7].Controls[0];
            TextBox TXTBACKP = (TextBox)row.Cells[8].Controls[0];
            TextBox TXTSBACKP = (TextBox)row.Cells[9].Controls[0];
            TextBox TXTSCRU = (TextBox)row.Cells[10].Controls[0];
            TextBox TXTREEVA = (TextBox)row.Cells[11].Controls[0];
            //GET MARKS IN STRING
            string WORKNAME = TXTWORKNAME.Text.Trim();
            string DATES = TXTDATES.Text.Trim();
            string DATEE = TXTDATEE.Text.Trim();
            string STAT = TXTSTAT.Text.Trim().ToUpper(); if (STAT != "A" && STAT != "C") { ltrlMessage.Text = "Enter A/C in STATUS Column."; return; }
            string DISPLAY = TXTDISPALY.Text.Trim().ToUpper(); if (DISPLAY != "Y" && DISPLAY != "N") { ltrlMessage.Text = "Enter Y/N in DISPLAY Column."; return; }
            string REG = TXTREG.Text.Trim().ToUpper(); if (REG != "Y" && REG != "N") { ltrlMessage.Text = "Enter Y/N in REG Column."; return; }
            string BACKP = TXTBACKP.Text.Trim().ToUpper(); if (BACKP != "Y" && BACKP != "N") { ltrlMessage.Text = "Enter Y/N in BACKP Column."; return; }
            string SBACKP = TXTSBACKP.Text.Trim().ToUpper(); if (SBACKP != "Y" && SBACKP != "N") { ltrlMessage.Text = "Enter Y/N in SBACKP Column."; return; }
            string SCRU = TXTSCRU.Text.Trim().ToUpper(); if (SCRU != "Y" && SCRU != "N") { ltrlMessage.Text = "Enter Y/N in SCRU Column."; return; }
            string REEVA = TXTREEVA.Text.Trim().ToUpper(); if (REEVA != "Y" && REEVA != "N") { ltrlMessage.Text = "Enter Y/N in REEVA Column."; return; }

            Grdedit.EditIndex = -1;
            //_sqlQuery = "UPDATE WORKS SET WORKNAME='" + WORKNAME + "',DATEF='" + DATES + "',DATET='" + DATEE + "',STAT='" + STAT + "',DISPLAY='" + DISPLAY + "',REG='" + REG + "',BACKP='" + BACKP + "',SBACKP='" + SBACKP + "',SCRU='" + SCRU + "',REEVA='" + REEVA + "' WHERE WORKID='" + WORKID + "'";

            string LongParam = WORKNAME + "|" + DATES + "|" + DATEE + '|' + STAT + "|" + DISPLAY + "|" + REG + "|" + BACKP + "|" + SBACKP + "|" + SCRU + "|" + REEVA;



            string result = _Objbll.WorkCRUD("UpdateWorks", WORKID, LongParam);
            
            ///string result = _Objbll.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                if (STAT == "C")
                {
                    for (int z = 0; z < 5; z++)
                    {
                        string CLM = string.Empty;
                        if (z == 0) { CLM = "REG"; }
                        else if (z == 1) { CLM = "BACKP"; }
                        else if (z == 2) { CLM = "SBACKP"; }
                        else if (z == 3) { CLM = "SCRU"; }
                        else if (z == 4) { CLM = "REEVA"; }
                        _sqlQuery = "UPDATE BRLOGIN SET " + CLM + "='N' WHERE " + CLM + "='" + WORKID + "'";
                        result = _Objbll.ONLYQUERYBLL(_sqlQuery);
                    }
                }
                Griddata();
                ltrlMessage.Text = "Updated Successfully";
            }
            else { ltrlMessage.Text = "Data Updation Failed."; }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    private void Griddata()
    {
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        _sqlQueryreg = "SELECT * FROM WORKS ORDER BY WORKID DESC";
        AllQueryParamreg[0] = _sqlQueryreg;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (dtreg.Rows.Count > 0)
        {
            Grdedit.DataSource = dtreg;
            Grdedit.DataBind();
        }
        else { ltrlMessage.Text = "No Records Found."; }
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            string WORKID = Grdedit.DataKeys[e.RowIndex].Value.ToString();
            string _sqlQuery = string.Empty;
            BLL objbll = new BLL();
            string[] AllQueryParam = new string[1];
            //Get WORK
            DataTable dtwork = new DataTable();
            _sqlQuery = "select * from WORKS where WORKID='" + WORKID + "'";
            AllQueryParam[0] = _sqlQuery;
            objbll.QUERYBLL(ref dtwork, AllQueryParam);
            if (dtwork.Rows.Count > 0)
            {
                string REG = dtwork.Rows[0]["REG"].ToString();
                if (REG == "Y") { _sqlQuery = "UPDATE BRLOGIN SET REG='N' WHERE REG='" + WORKID + "'"; objbll.ONLYQUERYBLL(_sqlQuery); }
                string BACKP = dtwork.Rows[0]["BACKP"].ToString();
                if (BACKP == "Y") { _sqlQuery = "UPDATE BRLOGIN SET BACKP='N' WHERE BACKP='" + WORKID + "'"; objbll.ONLYQUERYBLL(_sqlQuery); }
                string SBACKP = dtwork.Rows[0]["SBACKP"].ToString();
                if (SBACKP == "Y") { _sqlQuery = "UPDATE BRLOGIN SET SBACKP='N' WHERE SBACKP='" + WORKID + "'"; objbll.ONLYQUERYBLL(_sqlQuery); }
                string SCRU = dtwork.Rows[0]["SCRU"].ToString();
                if (SCRU == "Y") { _sqlQuery = "UPDATE BRLOGIN SET SCRU='N' WHERE SCRU='" + WORKID + "'"; objbll.ONLYQUERYBLL(_sqlQuery); }
                string REEVA = dtwork.Rows[0]["REEVA"].ToString();
                if (REEVA == "Y") { _sqlQuery = "UPDATE BRLOGIN SET REEVA='N' WHERE REEVA='" + WORKID + "'"; objbll.ONLYQUERYBLL(_sqlQuery); }
            }
            //Delete Work
            _sqlQuery = "DELETE FROM WORKS WHERE WORKID='" + WORKID + "'";
            string result = objbll.ONLYQUERYBLL(_sqlQuery);
            ltrlMessage.Text = "Deleted Successfully.";
            Griddata();
        }
        catch (Exception ex) { ltrlMessage.Text = "Please Try after some times."; }
    }
}