<%@ Page Language="C#" MasterPageFile="~/appadmin/Admin.master" AutoEventWireup="true"
    CodeFile="Regsummary.aspx.cs" Inherits="Regsummary" Title="Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        setTimeout(function () {
            location = ''
        }, 30000)
    </script>
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="Waiting">
                <div class="center">
                    <asp:Literal ID="Literal1" runat="server">Please wait...</asp:Literal>
                    <img src="../Images/loading.gif" alt="" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table width="90%" cellpadding="2" align="center">
                    <tr>
                        <td align="center" class="linehead" colspan="4" style="color: #FFFFFF; font-family: Agency FB;
                            background-color: #1E90FF; font-weight: bold; font-size: 20px;">
                            REGISTRATION FORM STATUS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:GridView ID="Grddata" Width="100%" runat="server" Font-Size="14px" Font-Names="Cambria"
                                AutoGenerateColumns="False" AllowSorting="True" CellPadding="2" HorizontalAlign="Center"
                                GridLines="Horizontal" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                BorderWidth="1px">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                        HeaderText="SRNO">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                        <HeaderStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="REGISTRATION SESSION" DataField="STRTSESS">
                                        <HeaderStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" BorderStyle="Solid" BorderWidth="1px">
                                        </ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="SEM01" DataField="SEM01">
                                        <HeaderStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="SEM02" DataField="SEM02">
                                        <HeaderStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="SEM03" DataField="SEM03">
                                        <HeaderStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="SEM04" DataField="SEM04">
                                        <HeaderStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="SEM05" DataField="SEM05">
                                        <HeaderStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="SEM06" DataField="SEM06">
                                        <HeaderStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="PRIVATE" DataField="PVT">
                                        <HeaderStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="QUALIFIED" DataField="QUA">
                                        <HeaderStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="TOTAL" DataField="TOT">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#333333" />
                                <HeaderStyle BackColor="#1E90FF" ForeColor="White" Font-Bold="True" />
                                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="16px"
                                    ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#339966" ForeColor="White" Font-Bold="True" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center" style="color: #FF0000">
                            <%=ONLINE %>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="left" style="color: #FF0000">
                            * THIS PAGE WILL BE REFRESH ON EVERY : 30 SECOND'S *
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Label ID="LblMessage" Font-Size="12px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
