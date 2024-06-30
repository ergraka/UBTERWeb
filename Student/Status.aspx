<%@ Page Language="C#" MasterPageFile="~/Student/Main.master" AutoEventWireup="true"
    CodeFile="Status.aspx.cs" Inherits="Status" Title="Status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table width="100%" align="center" style="margin: 0px; border: 1px solid #000000">
                    <tr>
                        <td colspan="2" class="lineheader" style="font-size: 25px; color: #FFFFFF; background-color: #008000;
                            height: 25px;" align="center" valign="middle">
                            <b><span lang="en-us">----- REGISTRATION STATUS -----</span></b>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <asp:Image ID="Image1" ImageUrl="~/Images/welcome.png" runat="server" Width="150px"
                                Height="50px" />
                            &nbsp;
                            <asp:Label ID="Label2" Font-Names="Lucida Fax" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table border="1" width="100%" style="border-collapse: collapse">
                                <tr>
                                    <th align="center" valign="middle">
                                        SR.NO.
                                    </th>
                                    <th align="center" valign="middle">
                                        STEP's
                                    </th>
                                    <th align="center" valign="middle">
                                        STATUS
                                    </th>
                                </tr>
                                <tr>
                                    <th align="center" valign="top">
                                        01.
                                    </th>
                                    <td align="left" valign="top">
                                        Registration
                                    </td>
                                    <td align="left" valign="top">
                                        <%=_ISREG %>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="center" valign="top">
                                        02.
                                    </th>
                                    <td align="left" valign="top">
                                        Qualification Details
                                    </td>
                                    <td align="left" valign="top">
                                        <%=_ISQUA %>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="center" valign="top">
                                        03.
                                    </th>
                                    <td align="left" valign="top">
                                        Address Details
                                    </td>
                                    <td align="left" valign="top">
                                        <%=_ISADD %>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="center" valign="top">
                                        04.
                                    </th>
                                    <td align="left" valign="top">
                                        Upload Photo and Sign Image
                                    </td>
                                    <td align="left" valign="top">
                                        <%=_ISPH %>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="center" valign="top">
                                        05.
                                    </th>
                                    <td align="left" valign="top">
                                        Registration Status
                                    </td>
                                    <td align="left" valign="top">
                                        <%=_ISCOMPLETED %>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>
