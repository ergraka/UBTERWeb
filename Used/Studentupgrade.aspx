<%@ Page Title="Student List" Language="C#" MasterPageFile="~/Institute/Default.master"
    AutoEventWireup="true" CodeFile="Studentupgrade.aspx.cs" Inherits="Studentupgrade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table width="90%" align="center" style="margin: 0px; font-family: Tahoma;">
                    <tr>
                        <td>
                            <p style="color: #FF0000; font-family:Cambria;">
                                Note:-<br>
                                1.Check on Roll Number is compulsory for next semester/year.<br>2.Please check on student
                                    back paper which paper student has submit fee. </br>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:GridView ID="Grdaproved" CssClass="grd" Width="100%" runat="server" AutoGenerateColumns="False"
                                CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                        HeaderText="SRNO">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="CNAME" DataField="CNAME" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="NOTE" DataField="REMARK" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="SEM/YEAR" DataField="SEM" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="CHECK" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CbSelect" Text='<%# Eval("ROLL") %>' CssClass="gridCB" runat="server">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                            <asp:Button ID="Btnapproved" CssClass="butn" runat="server" Text="Submit" OnClick="Btnapproved_Click" />
                            <br />
                            <asp:CheckBox ID="Chkall" Font-Size="12px" Font-Names="Cambria" AutoPostBack="true"
                                Text="Check/un-Check All" runat="server" OnCheckedChanged="Chkall_CheckedChanged" />
                            <br />
                            <br />
                            <asp:Label ID="ltrlMessage" Font-Size="13px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <hr />
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>
