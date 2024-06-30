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

public partial class PhotoSign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] == null) { Response.Redirect("Login.aspx", false); }
            if (!IsPostBack)
            {
                if (Session["EDIT"] != null)
                {
                    if (Session["Edit"].ToString() == "REG") { Response.Redirect("Registration.aspx", false); }
                    if (Session["Edit"].ToString() == "QUA") { Response.Redirect("Qualification.aspx", false); }
                    if (Session["Edit"].ToString() == "ADD") { Response.Redirect("Address.aspx", false); }
                    Imgph.ImageUrl = "~/Upload/Photo/" + Session["ID"].ToString() + "P.jpg";
                    Imgsign.ImageUrl = "~/Upload/Sign/" + Session["ID"].ToString() + "S.jpg";
                    Btnph.Visible = true;
                    Btnsign.Visible = true;
                    Button1.Text = "Submit";
                }
                else
                {
                    DataTable dt = new DataTable();
                    string[] AllQueryParam = new string[1];
                    string _sqlQuery = "select ISPH from REGISTRATION where STAT='A' AND CANDIDATEID=" + Session["ID"].ToString().Trim();
                    AllQueryParam[0] = _sqlQuery;
                    BLL objbllLogin = new BLL();
                    objbllLogin.QUERYBLL(ref dt, AllQueryParam);
                    if (dt.Rows.Count > 0)
                    {
                        string ISPH = dt.Rows[0]["ISPH"].ToString().Trim();
                        if (ISPH == "True") { Response.Redirect("Stuhome.aspx", false); }
                    }
                    Imgph.Visible = true;
                    Imgsign.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            // Response.Write(ex.Message);
            this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please try after some time.');", true);
        }
    }
    protected void Btnph_Click(object sender, EventArgs e)
    {
        try
        {
            //Upload Photo
            if (Session["ID"] == null) { Response.Redirect("Login.aspx", false); }
            if (FileUploadph.FileName.ToString() == "") { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please Browse photo Image first.');", true); return; }
            string fileExt = Path.GetExtension(FileUploadph.FileName.ToString()).ToLower();
            if (fileExt.ToLower() != ".jpg" && fileExt.ToLower() != ".jpeg") { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Only .jpg/.Jpeg format can be uploaded. Please try with correct image format.');", true); return; }

            int minsize = 18 * 1024;//18KB
            int maxsize = 50 * 1024;//50KB
            int filesize = FileUploadph.PostedFile.ContentLength;
            if ((filesize >= minsize && filesize <= maxsize))
            {
                string pathimage = "~/Upload/Photo/" + Session["ID"].ToString().Trim() + "P.jpg";
                FileUploadph.SaveAs(MapPath(pathimage));
                Imgph.ImageUrl = pathimage;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Image Size should be 20kb to 50kb only.');", true);
            }
        }
        catch (Exception ex)
        {
            // Response.Write(ex.Message);
            this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please try after some time.');", true);
        }
    }

    protected void Btnsign_Click(object sender, EventArgs e)
    {
        try
        {
            //Upload Sign
            if (Session["ID"] == null) { Response.Redirect("Login.aspx", false); }

            if (FileUploadsign.FileName.ToString() == "") { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please Browse Sign Image first.');", true); return; }
            string fileExt = Path.GetExtension(FileUploadsign.FileName.ToString()).ToLower();
            if (fileExt.ToLower() != ".jpg" && fileExt.ToLower() != ".jpeg") { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Only .jpg/.Jpeg format can be uploaded. Please try with correct image format.');", true); return; }

            int minsize = 8 * 1024;//8KB
            int maxsize = 20 * 1024;//20KB
            int filesize = FileUploadsign.PostedFile.ContentLength;
            if ((filesize >= minsize && filesize <= maxsize))
            {
                string pathimage = "~/Upload/Sign/" + Session["ID"].ToString().Trim() + "S.jpg";
                FileUploadsign.SaveAs(MapPath(pathimage));
                Imgsign.ImageUrl = pathimage;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Image Size should be 10kb to 20kb only.');", true);
            }
        }
        catch (Exception ex)
        {
            this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please try after some time.');", true);
        }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["ID"] == null) { Response.Redirect("Login.aspx", false); }
            string path1 = "~/Upload/Photo/" + Session["ID"].ToString().Trim() + "P.jpg";
            if (File.Exists(MapPath(path1)) == false) { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please upload photo.');", true); return; }
            string path2 = "~/Upload/Sign/" + Session["ID"].ToString().Trim() + "S.jpg";
            if (File.Exists(MapPath(path2)) == false) { this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please upload sign.');", true); return; }

            string _sqlQuery = string.Empty;
            BLL objbllonlyquery = new BLL();
            _sqlQuery = "update REGISTRATION set ISPH='1',SEM1='1',UPDATEDON=getdate() where CANDIDATEID=" + Session["ID"].ToString().Trim();
            string result = objbllonlyquery.ONLYQUERYBLL(_sqlQuery);
            if (result == "1-1")
            {
                Response.Redirect("~/Report/View.aspx", false);
            }
            Session["EDIT"] = null;
        }
        catch (Exception)
        {
            this.Page.ClientScript.RegisterStartupScript(typeof(MasterPage), "AlertMessage", "javascript:alert('Please try after some time.');", true);
        }
    }
}
