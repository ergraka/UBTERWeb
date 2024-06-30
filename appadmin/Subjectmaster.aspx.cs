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

public partial class Subjectmaster : System.Web.UI.Page
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
                string[] AllQueryParamreg = new string[1];
                BLL objbllreg = new BLL();
                //Get Branch
                DataTable dtins = new DataTable();
                _sqlQueryreg = "SELECT DISTINCT SUBSTRING(BRCODE,1,2) AS BRCODE from BRLOGIN WHERE BRCODE!='0' order by BRCODE asc";
                AllQueryParamreg[0] = _sqlQueryreg;
                objbllreg.QUERYBLL(ref dtins, AllQueryParamreg);
                if (dtins.Rows.Count > 0)
                {
                    Drpbranch.DataValueField = dtins.Columns["BRCODE"].ToString().Trim();
                    Drpbranch.DataTextField = dtins.Columns["BRCODE"].ToString().Trim();
                    Drpbranch.DataSource = dtins;
                    Drpbranch.DataBind();
                    if (Drpbranch.Items.Count > 0) { Drpbranch.SelectedIndex = 0; }
                }
                else { Response.Redirect("~/Error.aspx", true); }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (IsPostBack)
            {
                Griddata();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
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
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void Grdsess_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (IsPostBack)
            {
                Grdsess.EditIndex = e.NewEditIndex;
                Griddata();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
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
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void Grdsess_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (IsPostBack)
            {
                Grdsess.EditIndex = -1;
                Griddata();
            }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void Grdedit_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            BLL _Objbll = new BLL();
            string _sqlQuery = string.Empty;
            string SUBCODE = Grdedit.DataKeys[e.RowIndex].Value.ToString();

            GridViewRow row = (GridViewRow)Grdedit.Rows[e.RowIndex];
            TextBox TXTSUBCODE = (TextBox)row.Cells[3].Controls[0];
            TextBox TXTSUBNAME = (TextBox)row.Cells[4].Controls[0];
            TextBox TXTTHMAX = (TextBox)row.Cells[5].Controls[0];
            TextBox TXTTHMIN = (TextBox)row.Cells[6].Controls[0];
            TextBox TXTPRMAX = (TextBox)row.Cells[7].Controls[0];
            TextBox TXTPRMIN = (TextBox)row.Cells[8].Controls[0];
            TextBox TXTTSMAX = (TextBox)row.Cells[9].Controls[0];
            TextBox TXTTSMIN = (TextBox)row.Cells[10].Controls[0];
            TextBox TXTPSMAX = (TextBox)row.Cells[11].Controls[0];
            TextBox TXTPSMIN = (TextBox)row.Cells[12].Controls[0];
            TextBox TXTCREDIT = (TextBox)row.Cells[13].Controls[0];
            TextBox TXTMAX = (TextBox)row.Cells[14].Controls[0];
            TextBox TXTMIN = (TextBox)row.Cells[15].Controls[0];
            TextBox TXTTYPE = (TextBox)row.Cells[16].Controls[0];
            Grdedit.EditIndex = -1;
            if (Chkall.Checked == true)
            {
                if (Rdonew.Checked == true) { _sqlQuery = "UPDATE SUBN SET SUBCODE='" + TXTSUBCODE.Text + "',SUBJECT='" + TXTSUBNAME.Text.ToUpper() + "',THMAX='" + TXTTHMAX.Text + "',THMIN='" + TXTTHMIN.Text + "',PRMAX='" + TXTPRMAX.Text + "',PRMIN='" + TXTPRMIN.Text + "',TSMAX='" + TXTTSMAX.Text + "',TSMIN='" + TXTTSMIN.Text + "',PSMAX='" + TXTPSMAX.Text + "',PSMIN='" + TXTPSMIN.Text + "',CREDIT='" + TXTCREDIT.Text + "',MAX='" + TXTMAX.Text + "',MIN='" + TXTMIN.Text + "',TYPE='" + TXTTYPE.Text + "' WHERE SUBCODE='" + SUBCODE + "'"; }
                else { _sqlQuery = "UPDATE SUBJ SET SUBCODE='" + TXTSUBCODE.Text + "',SUBJECT='" + TXTSUBNAME.Text.ToUpper() + "',THMAX='" + TXTTHMAX.Text + "',THMIN='" + TXTTHMIN.Text + "',PRMAX='" + TXTPRMAX.Text + "',PRMIN='" + TXTPRMIN.Text + "',TSMAX='" + TXTTSMAX.Text + "',TSMIN='" + TXTTSMIN.Text + "',PSMAX='" + TXTPSMAX.Text + "',PSMIN='" + TXTPSMIN.Text + "',CREDIT='" + TXTCREDIT.Text + "',MAX='" + TXTMAX.Text + "',MIN='" + TXTMIN.Text + "',TYPE='" + TXTTYPE.Text + "' WHERE SUBCODE='" + SUBCODE + "'"; }
            }
            else
            {
                if (Rdonew.Checked == true) { _sqlQuery = "UPDATE SUBN SET SUBCODE='" + TXTSUBCODE.Text + "',SUBJECT='" + TXTSUBNAME.Text.ToUpper() + "',THMAX='" + TXTTHMAX.Text + "',THMIN='" + TXTTHMIN.Text + "',PRMAX='" + TXTPRMAX.Text + "',PRMIN='" + TXTPRMIN.Text + "',TSMAX='" + TXTTSMAX.Text + "',TSMIN='" + TXTTSMIN.Text + "',PSMAX='" + TXTPSMAX.Text + "',PSMIN='" + TXTPSMIN.Text + "',CREDIT='" + TXTCREDIT.Text + "',MAX='" + TXTMAX.Text + "',MIN='" + TXTMIN.Text + "',TYPE='" + TXTTYPE.Text + "' WHERE SUBCODE='" + SUBCODE + "' AND BRCODE='" + Drpbranch.SelectedValue + "'"; }
                else { _sqlQuery = "UPDATE SUBJ SET SUBCODE='" + TXTSUBCODE.Text + "',SUBJECT='" + TXTSUBNAME.Text.ToUpper() + "',THMAX='" + TXTTHMAX.Text + "',THMIN='" + TXTTHMIN.Text + "',PRMAX='" + TXTPRMAX.Text + "',PRMIN='" + TXTPRMIN.Text + "',TSMAX='" + TXTTSMAX.Text + "',TSMIN='" + TXTTSMIN.Text + "',PSMAX='" + TXTPSMAX.Text + "',PSMIN='" + TXTPSMIN.Text + "',CREDIT='" + TXTCREDIT.Text + "',MAX='" + TXTMAX.Text + "',MIN='" + TXTMIN.Text + "',TYPE='" + TXTTYPE.Text + "' WHERE SUBCODE='" + SUBCODE + "' AND BRCODE='" + Drpbranch.SelectedValue + "'"; }
            }
            string result = _Objbll.ONLYQUERYBLL(_sqlQuery);
            Griddata();
            ltrlMessage.Text = "Updated Successfully";
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void Grdsess_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            BLL _Objbll = new BLL();
            string _sqlQuery = string.Empty;
            string SUBCODE = Grdsess.DataKeys[e.RowIndex].Value.ToString();

            GridViewRow row = (GridViewRow)Grdsess.Rows[e.RowIndex];
            TextBox TXTSUBCODE = (TextBox)row.Cells[3].Controls[0];
            TextBox TXTSUBNAME = (TextBox)row.Cells[4].Controls[0];
            TextBox TXTSUBMAX = (TextBox)row.Cells[5].Controls[0];
            TextBox TXTSUBMIN = (TextBox)row.Cells[6].Controls[0];
            TextBox TXTSCREDIT = (TextBox)row.Cells[7].Controls[0];
            Grdsess.EditIndex = -1;
            if (Chkall.Checked == true)
            {
                if (Rdonew.Checked == true) { _sqlQuery = "UPDATE SUBSESSN SET SUBCODE='" + TXTSUBCODE.Text + "',SUBJECT='" + TXTSUBNAME.Text.ToUpper() + "',SUBMAX='" + TXTSUBMAX.Text + "',SUBMIN='" + TXTSUBMIN.Text + "',CREDIT='" + TXTSCREDIT.Text + "' WHERE SUBCODE='" + SUBCODE + "'"; }
                else { _sqlQuery = "UPDATE SUBSESS SET SUBCODE='" + TXTSUBCODE.Text + "',SUBJECT='" + TXTSUBNAME.Text.ToUpper() + "',SUBMAX='" + TXTSUBMAX.Text + "',SUBMIN='" + TXTSUBMIN.Text + "',CREDIT='" + TXTSCREDIT.Text + "' WHERE SUBCODE='" + SUBCODE + "'"; }
            }
            else
            {
                if (Rdonew.Checked == true) { _sqlQuery = "UPDATE SUBSESSN SET SUBCODE='" + TXTSUBCODE.Text + "',SUBJECT='" + TXTSUBNAME.Text.ToUpper() + "',SUBMAX='" + TXTSUBMAX.Text + "',SUBMIN='" + TXTSUBMIN.Text + "',CREDIT='" + TXTSCREDIT.Text + "' WHERE SUBCODE='" + SUBCODE + "' AND BRCODE='" + Drpbranch.SelectedValue + "'"; }
                else { _sqlQuery = "UPDATE SUBSESS SET SUBCODE='" + TXTSUBCODE.Text + "',SUBJECT='" + TXTSUBNAME.Text.ToUpper() + "',SUBMAX='" + TXTSUBMAX.Text + "',SUBMIN='" + TXTSUBMIN.Text + "',CREDIT='" + TXTSCREDIT.Text + "' WHERE SUBCODE='" + SUBCODE + "' AND BRCODE='" + Drpbranch.SelectedValue + "'"; }
            }
            string result = _Objbll.ONLYQUERYBLL(_sqlQuery);
            Griddata();
            ltrlMessage.Text = "Updated Successfully";
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    private void Griddata()
    {
        string _sqlQueryreg = string.Empty;
        DataTable dtreg = new DataTable();
        string[] AllQueryParamreg = new string[1];
        if (Rdomainsub.Checked == true)
        {
            if (Rdonew.Checked == true) { _sqlQueryreg = "SELECT * FROM SUBN WHERE BRCODE='" + Drpbranch.SelectedValue + "' ORDER BY SEM,SUBCODE ASC"; }
            else { _sqlQueryreg = "SELECT * FROM SUBJ WHERE BRCODE='" + Drpbranch.SelectedValue + "' ORDER BY SEM,SUBCODE ASC"; }
        }
        else
        {
            if (Rdonew.Checked == true) { _sqlQueryreg = "SELECT * FROM SUBSESSN WHERE BRCODE='" + Drpbranch.SelectedValue + "' ORDER BY SEM,SUBCODE ASC"; }
            else { _sqlQueryreg = "SELECT * FROM SUBSESS WHERE BRCODE='" + Drpbranch.SelectedValue + "' ORDER BY SEM,SUBCODE ASC"; }
        }
        AllQueryParamreg[0] = _sqlQueryreg;
        BLL objbllreg = new BLL();
        objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
        if (Rdomainsub.Checked == true)
        {
            Grdedit.DataSource = dtreg;
            Grdedit.DataBind();
            Grdedit.Visible = true;
            Tbladdmain.Visible = true;
            Grdsess.Visible = false;
            Tbladdsess.Visible = false;
        }
        else
        {
            Grdsess.DataSource = dtreg;
            Grdsess.DataBind();
            Grdedit.Visible = false;
            Tbladdmain.Visible = false;
            Grdsess.Visible = true;
            Tbladdsess.Visible = true;
        }
        Txtbrcode.Text = Drpbranch.SelectedValue;
        Txtsbrcode.Text = Drpbranch.SelectedValue;
        if (dtreg.Rows.Count == 0) { ltrlMessage.Text = "No Records Found."; }
        else { ltrlMessage.Text = ""; }
    }
    protected void InsertMain(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }

            if (Drpsem.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Selcet Semester.');", true); return; }
            if (Txtbrcode.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Brcode.');", true); return; }
            if (Txtsubcode.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Subcode.');", true); return; }
            if (Txtsubname.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Subname.');", true); return; }
            if (Drptype.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Subject Type.');", true); return; }

            BLL _Objbll = new BLL();
            string _sqlQuery = string.Empty;
            string TBL = string.Empty;
            if (Rdonew.Checked == true) { TBL = "SUBN"; }
            else { TBL = "SUBJ"; }
            _sqlQuery = "INSERT INTO " + TBL + "(SEM,BRCODE,SUBCODE,SUBJECT,THMAX,THMIN,PRMAX,PRMIN,TSMAX,TSMIN,PSMAX,PSMIN,CREDIT,MAX,MIN,TYPE) VALUES('" + Drpsem.SelectedValue + "','" + Txtbrcode.Text + "','" + Txtsubcode.Text + "','" + Txtsubname.Text.ToUpper() + "','" + Txtthmax.Text + "','" + Txtthmin.Text + "','" + Txtprmax.Text + "','" + Txtprmin.Text + "','" + Txttsmax.Text + "','" + Txttsmin.Text + "','" + Txtpsmax.Text + "','" + Txtpsmin.Text + "','" + Txtcredit.Text + "','" + Txtmax.Text + "','" + Txtmin.Text + "','" + Drptype.SelectedValue + "')";
            string result = _Objbll.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                Griddata();
                ltrlMessage.Text = "Inserted Successfully";
                Drpsem.SelectedValue = "0";
                Txtbrcode.Text = "";
                Txtsubcode.Text = "";
                Txtsubname.Text = "";
                Txtthmax.Text = "";
                Txtthmin.Text = "";
                Txtprmax.Text = "";
                Txtprmin.Text = "";
                Txttsmax.Text = "";
                Txttsmin.Text = "";
                Txtpsmax.Text = "";
                Txtpsmin.Text = "";
                Txtcredit.Text = "";
                Txtmax.Text = "";
                Txtmin.Text = "";
                Drptype.SelectedValue = "0";
            }
            else { ltrlMessage.Text = "Deletion Failed"; }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void InsertSess(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }

            if (Drpssem.SelectedValue == "0") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Selcet Semester.');", true); return; }
            if (Txtsbrcode.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Brcode.');", true); return; }
            if (Txtssubcode.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Subcode.');", true); return; }
            if (Txtssubname.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Subname.');", true); return; }
            if (Txtssubmax.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Submax.');", true); return; }
            if (Txtssubmin.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Submin.');", true); return; }
            if (Txtscredit.Text == "") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Credit.');", true); return; }

            BLL _Objbll = new BLL();
            string _sqlQuery = string.Empty;
            string TBL = string.Empty;
            if (Rdonew.Checked == true) { TBL = "SUBSESSN"; }
            else { TBL = "SUBSESS"; }
            _sqlQuery = "INSERT INTO " + TBL + "(SEM,BRCODE,SUBCODE,SUBJECT,SUBMAX,SUBMIN,CREDIT) VALUES('" + Drpssem.SelectedValue + "','" + Txtsbrcode.Text + "','" + Txtssubcode.Text + "','" + Txtssubname.Text.ToUpper() + "','" + Txtssubmax.Text + "','" + Txtssubmin.Text + "','" + Txtcredit.Text + "')";
            string result = _Objbll.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                Griddata();
                ltrlMessage.Text = "Inserted Successfully";
                Drpssem.SelectedValue = "0";
                Txtsbrcode.Text = "";
                Txtssubcode.Text = "";
                Txtssubname.Text = "";
                Txtssubmax.Text = "";
                Txtssubmin.Text = "";
            }
            else { ltrlMessage.Text = "Deletion Failed"; }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void OnRowDeletingMain(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            BLL _Objbll = new BLL();
            string _sqlQuery = string.Empty;
            string SUBCODE = Grdedit.DataKeys[e.RowIndex].Value.ToString();
            var SEM = Grdedit.Rows[e.RowIndex].Cells[1].Text;
            if (Rdonew.Checked == true) { _sqlQuery = "DELETE FROM SUBN WHERE SUBCODE='" + SUBCODE + "' AND BRCODE='" + Drpbranch.SelectedValue + "' AND SEM='" + SEM.ToString() + "'"; }
            else { _sqlQuery = "DELETE FROM SUBJ WHERE SUBCODE='" + SUBCODE + "' AND BRCODE='" + Drpbranch.SelectedValue + "' AND SEM='" + SEM.ToString() + "'"; }
            string result = _Objbll.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                Griddata();
                ltrlMessage.Text = "Deleted Successfully";
            }
            else { ltrlMessage.Text = "Deletion Failed"; }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void OnRowDeletingSess(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            BLL _Objbll = new BLL();
            string _sqlQuery = string.Empty;
            string SUBCODE = Grdsess.DataKeys[e.RowIndex].Value.ToString();
            var SEM = Grdsess.Rows[e.RowIndex].Cells[1].Text;

            if (Rdonew.Checked == true) { _sqlQuery = "DELETE FROM SUBSESSN WHERE SUBCODE='" + SUBCODE + "' AND BRCODE='" + Drpbranch.SelectedValue + "' AND SEM='" + SEM.ToString() + "'"; }
            else { _sqlQuery = "DELETE FROM SUBSESS WHERE SUBCODE='" + SUBCODE + "' AND BRCODE='" + Drpbranch.SelectedValue + "' AND SEM='" + SEM.ToString() + "'"; }
            string result = _Objbll.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                Griddata();
                ltrlMessage.Text = "Deleted Successfully";
            }
            else { ltrlMessage.Text = "Deletion Failed"; }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != Grdedit.EditIndex)
        {
            (e.Row.Cells[18].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row ?');";
        }
    }
}