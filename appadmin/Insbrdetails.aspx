<%@ Page Title="Student List" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeFile="Insbrdetails.aspx.cs" Inherits="Insbrdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="width: 95%">
                    <table width="100%" align="center" style="font-size: 12px;">
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB;
                                    font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- Back Paper Registration --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:GridView ID="Grdins" Width="100%" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            HeaderText="SRNO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Width="2%" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="INSTITUTE" DataField="INSNAME" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left">
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="CATEGORY" DataField="TYPE" HeaderStyle-HorizontalAlign="center"
                                            ItemStyle-HorizontalAlign="center">
                                            <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="PASSWORD" DataField="PASSWORD" HeaderStyle-HorizontalAlign="center"
                                            ItemStyle-HorizontalAlign="center">
                                            <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="CELL1" DataField="MONO" HeaderStyle-HorizontalAlign="center"
                                            ItemStyle-HorizontalAlign="center">
                                            <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="CELL2" DataField="LLNO" HeaderStyle-HorizontalAlign="center"
                                            ItemStyle-HorizontalAlign="center">
                                            <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="EMAIL" DataField="EMAIL" HeaderStyle-HorizontalAlign="center"
                                            ItemStyle-HorizontalAlign="center">
                                            <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left"></PagerStyle>
                                    <RowStyle ForeColor="#000066"></RowStyle>
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                    <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                                    <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                                    <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                                    <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                                </asp:GridView>
                                <br />
                                <asp:GridView ID="Grdbranch" Width="100%" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            HeaderText="SRNO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle Width="2%" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="INSTITUTE" DataField="INSCODE" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="BRANCH" DataField="BRNAME" HeaderStyle-HorizontalAlign="center"
                                            ItemStyle-HorizontalAlign="center">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="PASSWORD" DataField="PASSWORD" HeaderStyle-HorizontalAlign="center"
                                            ItemStyle-HorizontalAlign="center">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="GROUP" DataField="GRP" HeaderStyle-HorizontalAlign="center"
                                            ItemStyle-HorizontalAlign="center">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="SHIFT" DataField="SHIFT" HeaderStyle-HorizontalAlign="center"
                                            ItemStyle-HorizontalAlign="center">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="EMAIL" DataField="EMAIL" HeaderStyle-HorizontalAlign="center"
                                            ItemStyle-HorizontalAlign="center">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left"></PagerStyle>
                                    <RowStyle ForeColor="#000066" HorizontalAlign="Left"></RowStyle>
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                    <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                                    <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                                    <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                                    <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                                </asp:GridView>
                                <br />
                                <asp:Label ID="ltrlMessage" Font-Size="13px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <hr />
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>
