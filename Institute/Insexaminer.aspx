<%@ Page Title="Examiner Details" Language="C#" MasterPageFile="~/Institute/Default.master" AutoEventWireup="true"
    CodeFile="Insexaminer.aspx.cs" Inherits="Insexaminer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <div style="width: 95%">
                    <table width="100%" cellpadding="1" cellspacing="0" style="color: #000000; border-collapse: collapse;">
                        <tr>
                            <td align="left" colspan="2">&#187;&nbsp;<a class="link" href="Insaddexaminer.aspx?STAT=N|0">Add New Examiner.</a>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- EXAMINER SUMMARY --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:GridView ID="Grd1" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                            DataKeyNames="EMPID" AllowSorting="True" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None">
                                            <Columns>
                                                <asp:BoundField HeaderText="EMPLOYEE CODE" DataField="EMPCODE">
                                                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="EMPLOYEE NAME" DataField="EMPNAME">
                                                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="DESIGNATION" DataField="EMPDESIG">
                                                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="BRCODE" DataField="BRCODE">
                                                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="INSCODE" DataField="INSCODE">
                                                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="CITY" DataField="EMPCITY">
                                                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="MOBILE" DataField="MONO">
                                                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="EMAIL" DataField="EMAIL">
                                                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="EDIT" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left">
                                                    <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:HyperLink CssClass="grd" ID="HyperLink1" runat="server" Text='<%# Eval("EDITNAME") %>'
                                                            NavigateUrl='<%# Eval("EDITURL") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" CssClass="txt" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" CssClass="txt" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <hr />
                                        <asp:Label ID="LblMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
