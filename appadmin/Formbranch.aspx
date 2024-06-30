<%@ Page Title="Add Branch" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Formbranch.aspx.cs" Inherits="Formbranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
        <ProgressTemplate>
            <div class="Waiting">
                <div class="center">
                    <img src="../Images/loading.gif" alt="Loading..." />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <div style="width: 95%">
                    <table width="100%" cellpadding="4">
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB;
                                    font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- Add Institute & Barch Category For Registration Form --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Work Name<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="Drpworks" ValidationGroup="Reg" CssClass="Fontfill" AutoPostBack="true"
                                            runat="server" OnSelectedIndexChanged="Drpworks_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:GridView ID="Grdwork" Width="100%" runat="server" BackColor="White" BorderColor="#CC9966"
                                            BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                            <RowStyle BackColor="White" ForeColor="#330099" />
                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                            <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                            <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                            <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                            <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Search Type:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="Drpsearchtype" ValidationGroup="Reg" CssClass="Fontfill" AutoPostBack="true"
                                            OnSelectedIndexChanged="Drpsearchtype_SelectedIndexChanged" runat="server">
                                            <asp:ListItem Text="-Select Type-" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Institute" Value="I"></asp:ListItem>
                                            <asp:ListItem Text="Branch" Value="B"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr id="TRINS" runat="server" visible="false">
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Institute Name<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="Drpins" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Button ID="Btnsearch" CssClass="btn" runat="server" ValidationGroup="Reg" Text="Get Branch"
                                            OnClick="Btnsearch_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:CheckBox ID="Chksem01" Font-Size="16px" Font-Names="Cambria" AutoPostBack="true"
                                            Text="SEM 01" runat="server" OnCheckedChanged="Chksem01_CheckedChanged" />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="Chksem02" Font-Size="16px" Font-Names="Cambria" AutoPostBack="true"
                                            Text="SEM 02" runat="server" OnCheckedChanged="Chksem02_CheckedChanged" />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="Chksem03" Font-Size="16px" Font-Names="Cambria" AutoPostBack="true"
                                            Text="SEM 03" runat="server" OnCheckedChanged="Chksem03_CheckedChanged" />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="Chksem04" Font-Size="16px" Font-Names="Cambria" AutoPostBack="true"
                                            Text="SEM 04" runat="server" OnCheckedChanged="Chksem04_CheckedChanged" />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="Chksem05" Font-Size="16px" Font-Names="Cambria" AutoPostBack="true"
                                            Text="SEM 05" runat="server" OnCheckedChanged="Chksem05_CheckedChanged" />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="Chksem06" Font-Size="16px" Font-Names="Cambria" AutoPostBack="true"
                                            Text="SEM 06" runat="server" OnCheckedChanged="Chksem06_CheckedChanged" />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="Chksemp" Font-Size="16px" Font-Names="Cambria" AutoPostBack="true"
                                            Text="PRIVATE" runat="server" OnCheckedChanged="Chksemp_CheckedChanged" />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="Chksemq" Font-Size="16px" Font-Names="Cambria" AutoPostBack="true"
                                            Text="QUALIFIED" runat="server" OnCheckedChanged="Chksemq_CheckedChanged" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:GridView ID="Grdbr" DataKeyNames="BRCODE" CssClass="grd" Width="90%" runat="server"
                                            AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                            BorderStyle="None" BorderWidth="1px">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                    HeaderText="SRNO">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="BRANCH" DataField="BRCODE" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="SEM 01" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem01" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SEM 02" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem02" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SEM 03" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem03" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SEM 04" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem04" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SEM 05" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem05" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SEM 06" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem06" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PRIVATE" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsemp" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="QUALIFIED" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsemq" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
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
                                        <asp:GridView ID="Grdins" DataKeyNames="BRCODE" CssClass="grd" Width="90%" runat="server"
                                            AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                            BorderStyle="None" BorderWidth="1px">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                    HeaderText="SRNO">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="INSTITUTE" DataField="INSCODE" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="BRANCH" DataField="BRCODE" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="SEM 01" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem01" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SEM 02" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem02" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SEM 03" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem03" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SEM 04" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem04" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SEM 05" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem05" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SEM 06" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsem06" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PRIVATE" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsemp" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="QUALIFIED" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsemq" Text='<%# Eval("WORKID") %>' CssClass="gridCB" runat="server">
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
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Reg"
                                            DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                        <asp:CompareValidator ID="CVPDrpworks" runat="server" Display="None" ValidationGroup="Reg"
                                            ErrorMessage="Please Select Work Name." ControlToValidate="Drpworks" ValueToCompare="0"
                                            Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Button ID="Btnsubmit" CssClass="btn" runat="server" Text="Submit" OnClick="Btnsubmit_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="LblMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
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
