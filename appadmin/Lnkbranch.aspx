<%@ Page Title="Branch Link" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeFile="Lnkbranch.aspx.cs" Inherits="Lnkbranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <div style="width: 95%">
                    <table width="100%" cellpadding="4">
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB;
                                    font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- BRANCH LINK --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Insbrdetails.aspx?STAT=BRC"
                                            class="Link" title="View Branch Password">View Branch Password</a>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Documents/Advertisement.pdf"
                                            class="Link" target="_blank" title="Active Or De-Active Branch">Active Or De-Active
                                            Branch </a>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Branchdownload.aspx" class="Link"
                                            title="Download Branch List">Download Branch List</a>
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div class="row">
                                    <div class="col-lg-6">
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
