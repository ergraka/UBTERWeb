<%@ Page Language="C#" MasterPageFile="~/Student/Main.master" AutoEventWireup="true"
    CodeFile="PhotoSign.aspx.cs" Inherits="PhotoSign" Title="Photo Sign" %>

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
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    </asp:UpdatePanel>
    <center>
        <table width="95%" border="1" cellpadding="1" cellspacing="1" style="border-collapse: collapse">
            <tr>
                <td align="center" style="height: 20px; color: #FFFFFF; font-weight: bold; font-style: italic;
                    font-size: 18px; background-color: #008B8B;">
                    SELECT PHOTO PATH
                </td>
                <td align="center" style="height: 20px; color: #FFFFFF; font-weight: bold; font-style: italic;
                    font-size: 18px; background-color: #008B8B;">
                    SELECT SIGN PATH
                </td>
            </tr>
            <tr>
                <td align="left" style="height: 50px;" valign="middle">
                    <asp:FileUpload ID="FileUploadph" runat="server" onchange="showimagepreview(this)" />
                </td>
                <td align="left" style="height: 50px;" valign="middle">
                    <asp:FileUpload ID="FileUploadsign" runat="server" onchange="showimagepreview(this)" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Button ID="Btnph" runat="server" Text="Upload Photo" OnClick="Btnph_Click" />
                   
                </td>
                <td align="left">
                    <asp:Button ID="Btnsign" runat="server" Text="Upload Sign" OnClick="Btnsign_Click" />
                    
                </td>
            </tr>
            <tr>
                <td align="left" valign="middle">
                    <asp:Image ID="Imgph" Height="200px" Width="200px" runat="server" /><br />
                    <span style="color: #FF0000; font-family: Tahoma;">[ 20kb-50kb ]<br />
                        [ 200 * 230 ]</span>
                </td>
                <td align="left" valign="middle">
                    <asp:Image ID="Imgsign" Height="100px" Width="200px" runat="server" /><br />
                    <span style="color: #FF0000; font-family: Tahoma;">[ 10kb–20kb ]<br />
                        [ 140 * 60 ]</span>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 50px" align="center">
                    <asp:Button ID="Button1" runat="server" CssClass="btn-success" Text="Final Submit" ValidationGroup="Reg"
                        Font-Bold="True" Font-Size="15px" OnClick="BtnSubmit_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <img id="imgprvw" src="" height="250px" width="300px" alt="Preview of Images" />
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
