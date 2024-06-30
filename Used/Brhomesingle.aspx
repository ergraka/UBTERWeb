<%@ Page Language="C#" MasterPageFile="~/Used/Single.master" AutoEventWireup="true"
    CodeFile="Brhomesingle.aspx.cs" Inherits="Brhomesingle" Title="::BRANCH HOME" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <div style="width: 1024px;">
            <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </ajax:ToolkitScriptManager>
            <table cellspacing="0" style="width: 100%; font-family: Cambria; background: url(../Images/Watermark.jpg);
                color: #000000; background-repeat-x: no-repeat; background-repeat-y: no-repeat;
                background-position: center;">
                <tr>
                    <td align="left" style="width: 100%;">
                        <ajax:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="Tab">
                            <ajax:TabPanel ID="tbpnlusrdetails" runat="server" Height="200px" HeaderText="BRANCH SUMMARY">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table border="1" style="width: 100%">
                                            <tr>
                                                <td align="center" colspan="3" style="color: #2F4F4F; font-weight: bold; font-size: 18px;">
                                                    - BRANCH SUMMARY -
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">
                                                    01.
                                                </td>
                                                <td align="left" valign="top">
                                                    BRANCH REGISTERED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:LinkButton CssClass="grd" ID="Lnkall" Text="" runat="server" OnClick="Lnkall_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">
                                                    02.
                                                </td>
                                                <td align="left" valign="top">
                                                    BRANCH APPROVED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:LinkButton CssClass="grd" ID="Lnkapproved" Text="" runat="server" OnClick="Lnkapproved_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">
                                                    03.
                                                </td>
                                                <td align="left" valign="top">
                                                    BRANCH NOT-APPROVED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:LinkButton CssClass="grd" ID="Lnknapproved" Text="" Enabled="true" runat="server"
                                                        OnClick="Lnknapproved_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel1" runat="server" Height="200px" HeaderText="SCRUTINY FORM"
                                Visible="false">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server">
                                        <table border="1" style="width: 100%">
                                            <tr>
                                                <td align="center" colspan="3" style="color: #2F4F4F; font-weight: bold; font-size: 18px;">
                                                    - SCRUTINY FORM -
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">
                                                    01.
                                                </td>
                                                <td align="left" valign="top">
                                                    SCRUTINY FORM REGISTERED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:HyperLink CssClass="grd" ID="Lnkscruall" NavigateUrl="~/Institute/Apprscru.aspx?TYP=ALL"
                                                        runat="server"></asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">
                                                    02.
                                                </td>
                                                <td align="left" valign="top">
                                                    SCRUTINY FORM APPROVED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:HyperLink CssClass="grd" ID="Lnkscruapp" NavigateUrl="~/Institute/Apprscru.aspx?TYP=APP"
                                                        runat="server"></asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">
                                                    03.
                                                </td>
                                                <td align="left" valign="top">
                                                    SCRUTINY FORM NOT-APPROVED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:HyperLink CssClass="grd" ID="Lnkscrunapp" NavigateUrl="~/Institute/Apprscru.aspx?TYP=NAPP"
                                                        runat="server"></asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel2" runat="server" Height="200px" HeaderText="RE-EVALUATION FORM"
                                Visible="false">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel3" runat="server">
                                        <table border="1" style="width: 100%">
                                            <tr>
                                                <td align="center" colspan="3" style="color: #2F4F4F; font-weight: bold; font-size: 18px;">
                                                    - RE-EVALUATION FORM -
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">
                                                    01.
                                                </td>
                                                <td align="left" valign="top">
                                                    RE-EVALUATION FORM REGISTERED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:HyperLink CssClass="grd" ID="Lnkreevaall" NavigateUrl="~/Institute/Apprreeva.aspx?TYP=ALL"
                                                        runat="server"></asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">
                                                    02.
                                                </td>
                                                <td align="left" valign="top">
                                                    RE-EVALUATION FORM APPROVED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:HyperLink CssClass="grd" ID="Lnkreevaapp" NavigateUrl="~/Institute/Apprreeva.aspx?TYP=APP"
                                                        runat="server"></asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">
                                                    03.
                                                </td>
                                                <td align="left" valign="top">
                                                    RE-EVALUATION FORM NOT-APPROVED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:HyperLink CssClass="grd" ID="Lnkreevanapp" NavigateUrl="~/Institute/Apprreeva.aspx?TYP=NAPP"
                                                        runat="server"></asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>
