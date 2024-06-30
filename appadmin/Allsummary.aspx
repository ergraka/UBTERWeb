<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Allsummary.aspx.cs" Inherits="Allsummary" Title="All Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server" EnableHistory="false" ></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <table width="90%" cellpadding="4" align="center">
                    <tr>
                        <td class="linktd" style="color: #FFFF00; font-family: Agency FB; font-size: 22px;
                            background-image: url(../Images/bg.jpg);" align="center" valign="middle">
                            <asp:Label ID="Lblhead" runat="server" Text="- STUDENT SUMMARY -"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <hr />
                            <asp:Label ID="Lblcaption" Font-Names="Cambria" runat="server" Text="Please Click on Registration Number for View Details."></asp:Label>
                            <asp:GridView ID="Grdbranch" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None">
                                <Columns>
                                    <asp:BoundField HeaderText="BRANCH" DataField="BRNAME">
                                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="left"></ItemStyle>
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="INSTITUTE" DataField="INSNAME">
                                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="left"></ItemStyle>
                                    </asp:BoundField>

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
                            <asp:GridView ID="Grdcandidate" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None">
                                <Columns>
                                    <asp:BoundField HeaderText="SRNO" DataField="SRNO">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="REGISTRATION NO" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="center">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:HyperLink CssClass="grd" Target="_blank" ID="HyperLink1" runat="server" Text='<%# Eval("CANDIDATEID") %>'
                                                NavigateUrl='<%# Eval("LNKURL") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="NAME" DataField="CNAME">
                                        <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="FNAME" DataField="FNAME">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="INSTITUTE" DataField="INSNAME">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="BRANCH" DataField="BRNAME">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="SEM" DataField="SEM">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="STATUS" DataField="STAT">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="center"></ItemStyle>
                                    </asp:BoundField>
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
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Label ID="LblMessage" Font-Size="12px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
