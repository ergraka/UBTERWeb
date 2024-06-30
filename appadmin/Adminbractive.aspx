<%@ Page Title="Student List" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeFile="Adminbractive.aspx.cs" Inherits="Adminbractive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
       <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server" EnableHistory="false" ></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table width="1024px" align="center" style="margin: 0px; font-family: Cambria;">
                    <tr>
                        <td align="center" style="background-color: #4169E1; color: #FFFFFF; font-size: 18px;
                            font-style: italic;">
                            <%=TYPENAME %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:CheckBox ID="Chkall" Font-Size="16px" Font-Names="Cambria" AutoPostBack="true"
                                Font-Italic="true" Text="SELECT All" runat="server" OnCheckedChanged="Chkall_CheckedChanged" /><br />
                            <asp:GridView ID="Grdaproved" CssClass="grd" Width="100%" runat="server" AutoGenerateColumns="False"
                                CellPadding="3" BackColor="White" DataKeyNames="CANDIDATEID" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                        HeaderText="SRNO">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NAME" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:HyperLink CssClass="grd" Target="_blank" ID="HyperLink1" runat="server" Text='<%# Eval("CNAME") %>'
                                                NavigateUrl='<%# Eval("LNKURL") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="FATHER NAME" DataField="FNAME" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="REG. NO." DataField="CANDIDATEID" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="center">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="BRANCH" DataField="BRCODE" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="center">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="SEM" DataField="SEM" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="center">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="DATE OF BIRTH" DataField="DOB" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="center">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="grd" ControlStyle-BackColor="#FFFFFF"
                                        ItemStyle-ForeColor="#FF0000" ButtonType="Link"></asp:CommandField>
                                    <asp:TemplateField HeaderText="APPROVE/DISAPPROVE" HeaderStyle-HorizontalAlign="center"
                                        ItemStyle-HorizontalAlign="center">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CbSelect" Text='<%# Eval("CANDIDATEID") %>' CssClass="gridCB" runat="server">
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
                            <div style="background-color: #3CB371">
                                <asp:Button ID="Btnapproved" CssClass="butn" runat="server" Text="SUBMIT" OnClick="Btnapproved_Click" />
                            </div>
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
