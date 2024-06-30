using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using _Examination;

public partial class AdminChnagePass : System.Web.UI.Page
{
    string _name = string.Empty;
    string _EMAIL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            }
        }
        catch (Exception ex) { ltrlMessage.Text = "Please try after some time."; }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            BLL objbllonlyquery = new BLL();
            string _sqlQuery = "UPDATE ADMINLOGIN set PASSWORD='" + Txtnpassword.Text.Trim() + "' where PASSWORD='" + Txtpassword.Text.Trim() + "' and USERID='" + Session["ADMIN"].ToString().Trim() + "'";
            string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                ltrlMessage.Text = "Password Changed Successfully.";
            }
            else
            {
                ltrlMessage.Text = "Inavlid Old Password.";
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "POP_PREVIEW", "<script>javascript:alert('Invalid Old Password.')</script>", false);
            }
        }
        catch (Exception ex) { ltrlMessage.Text = ex.Message; }
    }
}
