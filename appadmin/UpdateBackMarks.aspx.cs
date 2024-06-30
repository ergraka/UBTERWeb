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
using Microsoft.Reporting.WebForms;
using System.IO;

public partial class Updatestudent : System.Web.UI.Page
{
    public string Comp = string.Empty;
    public string STR = string.Empty;
    public string STRSGPAH = string.Empty;
    public string INSTITUTE = string.Empty;
    public string BRANCH = string.Empty;
    public string CNAME = string.Empty;
    public string FNAME = string.Empty;
    public string CANDIDATEID = string.Empty;
    public string ROLL = string.Empty;
    public string DATE = string.Empty;
    public string TYPE = string.Empty;
    public string STUTYPE = string.Empty;
    public string STRTSESS = string.Empty;
    BLL objbllLogin = new BLL();

    string constr = ConfigurationManager.ConnectionStrings["S@N"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

        ROLL = Txtroll.Text.Trim();
        lblstatus.Text = "";
    
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("~/Error.aspx", false); }
             
            
        }
        catch (Exception ex) { LblMessage.Text = ex.Message; }
    }

    private void getStudentDeatils(string ROLL)
    {
        try
        {
            LblMessage.Text = "";

            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Txtroll.Text == "") { LblMessage.Text = "Please Enter Registration Number OR Roll Number."; return; }
           // ROLL = Txtroll.Text.Trim();
            string _sqlQuery = string.Empty;
            DataTable dt = new DataTable();
            string[] AllQueryParam = new string[1];
            _sqlQuery = "select * from REGISTRATION where STAT='A' AND (CANDIDATEID='" + ROLL + "' OR ROLL='" + ROLL + "')";
            AllQueryParam[0] = _sqlQuery;

            objbllLogin.QUERYBLL(ref dt, AllQueryParam);
            if (dt.Rows.Count > 0)
            {

                if (dt.Rows.Count == 0) { return; }
                STUTYPE = dt.Rows[0]["STUTYPE"].ToString();
                STR = STR + ("<table style='font-size: 13px; font-family:Cambria; border-collapse:collapse; border-color:#0000CD' border='1' cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" runat=\"server\">");
                INSTITUTE = dt.Rows[0]["INSNAME"].ToString();
                BRANCH = dt.Rows[0]["BRNAME"].ToString();
                CNAME = dt.Rows[0]["CNAME"].ToString();
                FNAME = dt.Rows[0]["FNAME"].ToString();
                CANDIDATEID = dt.Rows[0]["CANDIDATEID"].ToString();
                CANDIDATEID = dt.Rows[0]["CANDIDATEID"].ToString();
                string SMMM = dt.Rows[0]["SEM"].ToString();
                string GRP = dt.Rows[0]["GRP"].ToString();
                ROLL = dt.Rows[0]["ROLL"].ToString();
                STRTSESS = dt.Rows[0]["STRTSESS"].ToString();
                string ITIPASS = dt.Rows[0]["ITIPASS"].ToString();
                DATE = System.DateTime.Now.ToString("dd/MM/yyyy");
                TYPE = dt.Rows[0]["REGPVT"].ToString();
                if (TYPE == "P") { TYPE = "PRIVATE"; } else if (TYPE == "Q") { TYPE = "PASSED/SPECIAL"; } else { TYPE = "REGULAR"; }

               
            }
            else
            {
                // ReportViewer1.Visible = false;
                //Drpclm.SelectedIndex = 0;
                //Trchange.Visible = false;
                //Btnsubmit.Visible = false;
                //Txtchange.Text = "";
                LblMessage.Text = Txtroll.Text + "- IS Invalid Registration Number OR Roll Number.Please Enter Valid Registration Number OR Roll Number.";
            }
        }
        catch (Exception ex)
        { LblMessage.Text = ex.Message; }
    }

    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        
            ROLL = Txtroll.Text.Trim();
            getStudentDeatils(ROLL);
            BindGrid(ROLL);
       
    }

    private void BindGrid(string Roll)
    {
        
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Proc_BackPaprMarks"))
            {
                cmd.Parameters.AddWithValue("@Roll", Roll);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GVBackMarks.DataSource = dt;
                        GVBackMarks.DataBind();
                    }
                }
            }
        }
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GVBackMarks.EditIndex = e.NewEditIndex;
        getStudentDeatils(ROLL);
        BindGrid(ROLL);
    }

    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GVBackMarks.EditIndex = -1;
        getStudentDeatils(ROLL);
        BindGrid(ROLL);
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = GVBackMarks.Rows[e.RowIndex];
            //int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string Semester = (row.FindControl("lblSemester") as Label).Text;
            string SubjectCode = (row.FindControl("lblSubjectCode") as Label).Text;
            string SubjectType = (row.FindControl("lblSType") as Label).Text;

            string ColumnId = (row.FindControl("lblColumnId") as Literal).Text;
            string Sess = (row.FindControl("lblSess") as Literal).Text;
            string ObtMarks = (row.FindControl("txtObtMarks") as TextBox).Text;
            string SessMarks = (row.FindControl("txtSessMarks") as TextBox).Text;
            string SubjectStatus = (row.FindControl("txtSubjectStatus") as TextBox).Text;

            if (ObtMarks.Trim() == "")
            {

                ObtMarks = "9999";
            }

            if (SessMarks.Trim() == "")
            {

                SessMarks = "9999";
            }

            if (SubjectStatus.Trim() == "")
            {

                SubjectStatus = "9999";
            }

            string LongStr = ROLL.Trim() + '|' + Semester.Trim() + '|' + SubjectType.Trim() + '|' + ColumnId.Trim() + '|' + SubjectCode + '|' + ObtMarks.Trim() + '|' + SessMarks.Trim() + '|' + SubjectStatus.Trim() + '|' + Sess.Trim() + '~';

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Proc_BackMarks"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Condition", "Update");
                    cmd.Parameters.AddWithValue("@P_LongStr", LongStr);
                    cmd.Parameters.Add("@P_ProcMessage", SqlDbType.VarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@P_ProcReturn", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    string ProcMessage = Convert.ToString(cmd.Parameters["@P_ProcMessage"].Value);
                    if (cmd.Parameters["@P_ProcReturn"].Value != DBNull.Value)
                    {
                        int ProcReturn = Convert.ToInt32(cmd.Parameters["@P_ProcReturn"].Value);
                        lblstatus.Text = "Record updated successfully";
                    }
                }
            }
        }
        catch(Exception ex)
        {
            lblstatus.Text = ex.Message.ToString();
        }
        GVBackMarks.EditIndex = -1;
        getStudentDeatils(ROLL);
        BindGrid(ROLL);
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            
            GridViewRow row = GVBackMarks.Rows[e.RowIndex];
            //int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string Semester = (row.FindControl("lblSemester") as Label).Text;
            string SubjectCode = (row.FindControl("lblSubjectCode") as Label).Text;
            string SubjectType = (row.FindControl("lblSType") as Label).Text;

            string ColumnId = (row.FindControl("lblColumnId") as Literal).Text;
            string Sess = (row.FindControl("lblSess") as Literal).Text;
            string ObtMarks = (row.FindControl("lblObtMarks") as Label).Text;
            string SessMarks = (row.FindControl("lblSessMarks") as Label).Text;
            string SubjectStatus = (row.FindControl("lblSubjectStatus") as Label).Text;

            if (ObtMarks.Trim() == "")
            {

                ObtMarks = "9999";
            }

            if (SessMarks.Trim() == "")
            {

                SessMarks = "9999";
            }

            if (SubjectStatus.Trim() == "")
            {

                SubjectStatus = "9999";
            }

            string LongStr = ROLL.Trim() + '|' + Semester.Trim() + '|' + SubjectType.Trim() + '|' + ColumnId.Trim() + '|' + SubjectCode + '|' + ObtMarks.Trim() + '|' + SessMarks.Trim() + '|' + SubjectStatus.Trim() + '|'+ Sess.Trim()+ '~';

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Proc_BackMarks"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Condition", "Delete");
                    cmd.Parameters.AddWithValue("@P_LongStr", LongStr);
                    cmd.Parameters.Add("@P_ProcMessage", SqlDbType.VarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@P_ProcReturn", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    string ProcMessage = Convert.ToString(cmd.Parameters["@P_ProcMessage"].Value);
                    if (cmd.Parameters["@P_ProcReturn"].Value != DBNull.Value)
                    {
                        int ProcReturn = Convert.ToInt32(cmd.Parameters["@P_ProcReturn"].Value);
                        lblstatus.Text = "Record deleted successfully";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblstatus.Text = ex.Message.ToString();
        }
        GVBackMarks.EditIndex = -1;
        getStudentDeatils(ROLL);
        BindGrid(ROLL);
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GVBackMarks.EditIndex)
        {
            (e.Row.Cells[7].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            string ObtMarks = (e.Row.FindControl("lblObtMarks") as Label).Text;

            if (Regex.IsMatch(ObtMarks, @"^\d+$"))
            {
                //Row Enable
                e.Row.Enabled = false;
            }
            else
            {
                //Row Disable
                e.Row.Enabled = true;
            }

            //if(string.IsNullOrEmpty(ObtMarks.Trim() as string))
            //{
            //    string str = "hello";
            //}

            
        }
    }

    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //string _sqlQuery = string.Empty;
            //BLL objbll = new BLL();
            //string[] AllQueryParam = new string[1];
            //AllQueryParam[0] = _sqlQuery;
            //_sqlQuery = "UPDATE REGISTRATION SET " + Drpclm.SelectedItem.ToString() + "='" + Txtchange.Text.ToUpper() + "' WHERE (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "')";
            //string result = objbll.ONLYQUERYBLL(_sqlQuery);
            //if (result == "1-1")
            {
                //    if (Drpclm.SelectedItem.ToString() == "SEM" || Drpclm.SelectedItem.ToString() == "REGPVT" || Drpclm.SelectedItem.ToString() == "CNAME" || Drpclm.SelectedItem.ToString() == "FNAME" || Drpclm.SelectedItem.ToString() == "DOB")
                //    {
                //        for (int i = 1; i <= 3; i++)
                //        {
                //            string TBL = string.Empty;
                //            if (i == 1) { TBL = "BACKP"; }
                //            else if (i == 2) { TBL = "SCRU"; }
                //            else if (i == 3) { TBL = "REEVA"; }
                //            _sqlQuery = "UPDATE " + TBL + " SET " + Drpclm.SelectedItem.ToString() + "='" + Txtchange.Text.ToUpper() + "'  WHERE (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "')";
                //            objbll.ONLYQUERYBLL(_sqlQuery);
                //        }
                //    }
                //    LblMessage.Text = "UPDATE COMPLETED SUCCESSFULLY.";
                //    Trchange.Visible = false;
                //    Btnsubmit.Visible = false;
                //    Txtchange.Text = "";
                //    Drpclm.SelectedIndex = 0;
                //}
                //else { LblMessage.Text = "UPDATE FAILED."; }
            }

        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    protected void Drpclm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (Drpclm.SelectedIndex > 0)
            //{
            //    string _sqlQueryreg = string.Empty;
            //    DataTable dtreg = new DataTable();
            //    string[] AllQueryParamreg = new string[1];
            //    _sqlQueryreg = "SELECT " + Drpclm.SelectedItem.ToString() + " FROM REGISTRATION WHERE (ROLL='" + Txtroll.Text + "' OR CANDIDATEID='" + Txtroll.Text + "')";
            //    AllQueryParamreg[0] = _sqlQueryreg;
            //    BLL objbllreg = new BLL();
            //    objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            //    if (dtreg.Rows.Count > 0)
            //    {
            //        Txtchange.Text = dtreg.Rows[0][Drpclm.SelectedItem.ToString()].ToString();
            //    }
            //    else { LblMessage.Text = "No Records Found"; }
            //}
        }
        catch (Exception ex) { LblMessage.Text = "Please try after some time."; }
    }
    
}