using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;
using _Examination;

public partial class Uploaddocuments : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (!IsPostBack)
            {
                //Images
               
            }
        }
        catch (Exception ex) { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please try after some time.');", true); }
    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMIN"] == null) { Response.Redirect("Adminlogin.aspx", false); }
            if (Txtroll.Text == "") { LblMessage.Text = "Please Enter Registration Number OR Roll Number."; return; }
            string _sqlQueryreg = string.Empty;
            DataTable dtreg = new DataTable();
            string[] AllQueryParamreg = new string[1];
            _sqlQueryreg = "SELECT * FROM REGISTRATION WHERE CANDIDATEID='" + Txtroll.Text + "'";
            AllQueryParamreg[0] = _sqlQueryreg;
            BLL objbllreg = new BLL();
            objbllreg.QUERYBLL(ref dtreg, AllQueryParamreg);
            if (dtreg.Rows.Count > 0)
            {
                string CANDIDATEID = dtreg.Rows[0]["CANDIDATEID"].ToString();
                Lblid.Text = CANDIDATEID;
                LblMessage.Text = "Photo and Sign are display Below.";
                Imgph.ImageUrl = "https://ubterex.in//Upload/Photo/" + CANDIDATEID + "P.jpg";
                Imgsign.ImageUrl = "https://ubterex.in//Upload/Sign/" + CANDIDATEID + "S.jpg";
                Lnkph.NavigateUrl = "https://ubterex.in//Upload/Photo/" + CANDIDATEID + "P.jpg";
                Lnksign.NavigateUrl = "https://ubterex.in//Upload/Sign/" + CANDIDATEID + "S.jpg";
            }
            else
            {
                LblMessage.Text = Txtroll.Text + "- IS Invalid Registration Number.Please Enter Valid Registration Number.";
            }
        }
        catch (Exception ex)
        { LblMessage.Text = ex.Message; }
    }



    protected void Btnph_Click(object sender, EventArgs e)
    {
        try
        {
            //Upload Photo
            if (Session["ADMIN"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (Txtroll.Text == "") { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please Enter Registration Number.');", true); return; }
            if (Fileuploadph.FileName.ToString() == "") { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please Browse photo Image first.');", true); return; }
            string fileExt = Path.GetExtension(Fileuploadph.FileName.ToString()).ToLower();
            if (fileExt.ToLower() != ".jpg") { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Only .jpg format can be uploaded. Please try with correct image format.');", true); return; }

            int minsize = 18 * 1024;//18KB
            int maxsize = 50 * 1024;//50KB
            int filesize = Fileuploadph.PostedFile.ContentLength;
            if ((filesize >= minsize && filesize <= maxsize))
            {
                string pathimage = "~/Upload/Photo/" + Lblid.Text + "P.jpg";
                Fileuploadph.SaveAs(MapPath(pathimage));
                Imgph.ImageUrl = pathimage;
                Lnkph.NavigateUrl = pathimage;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Image Size should be 20kb to 50kb only.');", true);
            }
        }
        catch (Exception ex) { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please try after some time.');", true); }
    }
    protected void Btnsign_Click(object sender, EventArgs e)
    {
        try
        {
            //Upload Sign
            if (Session["ADMIN"] == null) { Response.Redirect("~/Error.aspx", false); }
            if (Txtroll.Text == "") { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please Enter Registration Number.');", true); return; }
            if (Fileuploadsign.FileName.ToString() == "") { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please Browse Sign Image first.');", true); return; }
            string fileExt = Path.GetExtension(Fileuploadsign.FileName.ToString()).ToLower();
            if (fileExt.ToLower() != ".jpg") { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Only .jpg format can be uploaded. Please try with correct image format.');", true); return; }
            
            int minsize = 8 * 1024;//8KB
            int maxsize = 20 * 1024;//20KB
            int filesize = Fileuploadsign.PostedFile.ContentLength;
            if ((filesize >= minsize && filesize <= maxsize))
            {
                string pathimage = "~/Upload/Sign/" + Lblid.Text + "S.jpg";
                Fileuploadsign.SaveAs(MapPath(pathimage));
                Imgsign.ImageUrl = pathimage;
                Lnksign.NavigateUrl = pathimage;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Image Size should be 10kb to 20kb only.');", true);
            }
        }
        catch (Exception ex) { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please try after some time.');", true); }
    }
    
}
