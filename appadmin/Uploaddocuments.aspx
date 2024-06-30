<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Uploaddocuments.aspx.cs" Inherits="Uploaddocuments" Title="Upload Document" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../Scripts/Preview.js"></script>
    <script type="text/javascript">
        function showimagepreview(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#imgprvw').attr('src', e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <center>
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
        </asp:ScriptManager>
        <div style="width: 95%">
            <table border="1" width="100%" cellpadding="1" cellspacing="0" style="color: #000000;
                border-collapse: collapse;">
                <tr>
                   <td colspan="5">
                        <div class="row">
                            <div class="col-lg-4">
                                Registration Number:<span style="color: #FF0000">*</span>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox ID="Txtroll" ValidationGroup="Reg" CssClass="Fontfill" Placeholder="Registration Number"
                                    MaxLength="8" onkeypress="return numbersonly(event)" runat="server"></asp:TextBox>
                                <asp:Button ID="Btnsearch" CssClass="btn" runat="server" ValidationGroup="Reg" Text="Search"
                                    OnClick="Btnsearch_Click" />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center">
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Label ID="Lblid" runat="server" Text=""></asp:Label>-<asp:Label ID="LblMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center" style="color: #FFFFFF; background-color: #1E90FF;
                        font-family: Agency FB; font-size: 25px;">
                        Upload Photo, Sign and Other Documents
                    </td>
                </tr>
                <tr>
                    <td align="center" class="heading">
                        SR NO
                    </td>
                    <td align="center" class="heading" style="width: 40%">
                        Document Type
                    </td>
                    <td align="center" class="heading">
                        Select Document
                    </td>
                    <td align="center" class="heading">
                        Upload Document
                    </td>
                    <td align="center" class="heading">
                        View Document
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        01
                    </td>
                    <td align="center">
                        <asp:Label ID="Lblphoto" runat="server" Text="Upload Photo"></asp:Label>
                        <span style="color: #FF0000">*</span>
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="Fileuploadph" runat="server" onchange="showimagepreview(this)" />
                        <br />
                        <span style="color: #FF0000">( Select only jpg file )</span>
                    </td>
                    <td align="center">
                        <asp:Button ID="Btnph" runat="server" Text="Upload" OnClick="Btnph_Click" />
                    </td>
                    <td align="center">
                        <asp:HyperLink ID="Lnkph" Target="_blank" NavigateUrl="" runat="server">
                            <asp:Image ID="Imgph" Height="80px" Width="100px" runat="server" /></asp:HyperLink>
                        <br />
                        <span style="color: #FF0000">( 20kb-50kb )</span>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        02
                    </td>
                    <td align="center">
                        <asp:Label ID="Lblsign" runat="server" Text="Upload Sign"></asp:Label><span style="color: #FF0000">*</span>
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="Fileuploadsign" runat="server" onchange="showimagepreview(this)" />
                        <br />
                        <span style="color: #FF0000">( Select only jpg file )</span>
                    </td>
                    <td align="center">
                        <asp:Button ID="Btnsign" runat="server" Text="Upload" OnClick="Btnsign_Click" />
                    </td>
                    <td align="center">
                        <asp:HyperLink ID="Lnksign" Target="_blank" NavigateUrl="" runat="server">
                            <asp:Image ID="Imgsign" Height="50px" Width="100px" runat="server" /></asp:HyperLink>
                        <br />
                        <span style="color: #FF0000">( 10kb-20kb )</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center">
                        <img id="imgprvw" src="" height="250px" width="300px" alt="Preview of Images" />
                    </td>
                </tr>
                
            </table>
        </div>
    </center>
</asp:Content>
