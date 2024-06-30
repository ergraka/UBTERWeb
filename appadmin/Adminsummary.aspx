<%@ Page Title="ADMIN HOME" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Adminsummary.aspx.cs" Inherits="Adminsummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server" EnableHistory="false" ></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <div style="width: 90%; background-color: #FAFAD2; height: auto;">
                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td align="center" style="color: #FFFFFF; font-family: Cambria; background-image: url(../Images/bg.png);
                                font-size: 18px;">
                                UBTER SUMMARY
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:GridView ID="Grd1" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None">
                                    <Columns>
                                        <asp:BoundField HeaderText="INSTITUTE NAME" DataField="INSNAME">
                                            <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="BRANCH" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:HyperLink CssClass="grd" ID="HyperLink1" runat="server" Text='<%# Eval("BRCCNT") %>'
                                                    NavigateUrl='<%# Eval("BRCURL") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SEM01" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:HyperLink CssClass="grd" ID="HyperLink1" runat="server" Text='<%# Eval("S01CNT") %>'
                                                    NavigateUrl='<%# Eval("S01URL") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SEM02" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:HyperLink CssClass="grd" ID="HyperLink1" runat="server" Text='<%# Eval("S02CNT") %>'
                                                    NavigateUrl='<%# Eval("S02URL") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SEM03" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:HyperLink CssClass="grd" ID="HyperLink1" runat="server" Text='<%# Eval("S03CNT") %>'
                                                    NavigateUrl='<%# Eval("S03URL") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SEM04" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:HyperLink CssClass="grd" ID="HyperLink1" runat="server" Text='<%# Eval("S04CNT") %>'
                                                    NavigateUrl='<%# Eval("S04URL") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SEM05" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:HyperLink CssClass="grd" ID="HyperLink1" runat="server" Text='<%# Eval("S05CNT") %>'
                                                    NavigateUrl='<%# Eval("S05URL") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SEM06" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:HyperLink CssClass="grd" ID="HyperLink1" runat="server" Text='<%# Eval("S06CNT") %>'
                                                    NavigateUrl='<%# Eval("S06URL") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="PRIVATE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:HyperLink CssClass="grd" ID="HyperLink1" runat="server" Text='<%# Eval("PVTCNT") %>'
                                                    NavigateUrl='<%# Eval("PVTURL") %>'></asp:HyperLink>
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
                            </td>
                        </tr>
                        <tr>
                        <td align="center">
                            <asp:Label ID="LblMessage" Font-Size="12px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
