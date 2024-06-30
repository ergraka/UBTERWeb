<%@ Page Title="Open Registration Form" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeFile="Openform.aspx.cs" Inherits="Openform" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
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
                <div style="width: 95%">
                    <table width="100%" cellpadding="4">
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB;
                                    font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- Open Registration Form --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-2">
                                        Work Name:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="Txtworkname" ValidationGroup="Reg" CssClass="Fontfillnupper" placeholder="Work Name"
                                            runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-2">
                                        Start Date:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="Txtdatef" ValidationGroup="Reg" runat="server" placeholder="YYYY,MM,DD,HH,MM,SS"
                                            MaxLength="19" CssClass="Fontfill"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        End Date:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="Txtdatee" ValidationGroup="Reg" placeholder="YYYY,MM,DD,HH,MM,SS" runat="server"
                                            MaxLength="19" CssClass="Fontfill"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-2">
                                        Status:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:DropDownList ID="Drpstat" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                            <asp:ListItem Value="0">-Select-</asp:ListItem>
                                            <asp:ListItem Value="A">Active</asp:ListItem>
                                            <asp:ListItem Value="C">Close</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-2">
                                        Display on Page:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:DropDownList ID="Drpdisplay" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                            <asp:ListItem Value="0">-Select-</asp:ListItem>
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-2">
                                        Registration Type:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:CheckBox ID="Chkreg" Text="Registration" runat="server" />&nbsp;
                                        <asp:CheckBox ID="Chkbackp" Text="Back Paper" runat="server" />&nbsp;
                                        <asp:CheckBox ID="Chksbackp" Text="Special Back Paper" runat="server" />&nbsp;
                                        <asp:CheckBox ID="Chkscru" Text="Scrutiny" runat="server" />&nbsp;
                                        <asp:CheckBox ID="Chkreeva" Text="Re-Evaluation" runat="server" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <hr />
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
                                        <asp:Button ID="Btnadd" ValidationGroup="Reg" CssClass="btn" runat="server" Text="Click to Add"
                                            OnClick="Btnadd_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <%--   EDIT WORKS--%>
                                        <asp:GridView ID="Grdedit" CssClass="grd" Width="100%" runat="server" Font-Size="13px"
                                            DataKeyNames="WORKID" AutoGenerateColumns="False" CellPadding="1" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowCancelingEdit="Grdedit_RowCancelingEdit"
                                            OnRowEditing="Grdedit_RowEditing" OnRowDeleting="OnRowDeleting" OnRowUpdating="Grdedit_RowUpdating">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                    HeaderText="SR">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="WORKID" DataField="WORKID" HeaderStyle-HorizontalAlign="Center"
                                                    ReadOnly="true" ItemStyle-HorizontalAlign="left">
                                                    <HeaderStyle HorizontalAlign="left" />
                                                    <ItemStyle HorizontalAlign="left" />
                                                </asp:BoundField>
                                                <asp:BoundField ControlStyle-Width="100%" HeaderText="WORK NAME" ItemStyle-HorizontalAlign="left"
                                                    DataField="WORKNAME" />
                                                <asp:BoundField ControlStyle-Width="100px" HeaderText="START DATE" ItemStyle-HorizontalAlign="left"
                                                    DataField="DATEF" />
                                                <asp:BoundField ControlStyle-Width="100px" HeaderText="END DATE" ItemStyle-HorizontalAlign="left"
                                                    DataField="DATET" />
                                                <asp:BoundField ControlStyle-Width="100px" HeaderText="STATUS" ItemStyle-HorizontalAlign="left"
                                                    DataField="STAT" />
                                                <asp:BoundField ControlStyle-Width="100px" HeaderText="DISPLAY" ItemStyle-HorizontalAlign="left"
                                                    DataField="DISPLAY" />
                                                <asp:BoundField ControlStyle-Width="80px" HeaderText="REG" ItemStyle-HorizontalAlign="left"
                                                    DataField="REG" />
                                                <asp:BoundField ControlStyle-Width="80px" HeaderText="BACKP" ItemStyle-HorizontalAlign="left"
                                                    DataField="BACKP" />
                                                <asp:BoundField ControlStyle-Width="80px" HeaderText="SBACKP" ItemStyle-HorizontalAlign="left"
                                                    DataField="SBACKP" />
                                                <asp:BoundField ControlStyle-Width="80px" HeaderText="SCRU" ItemStyle-HorizontalAlign="left"
                                                    DataField="SCRU" />
                                                <asp:BoundField ControlStyle-Width="80px" HeaderText="REEVA" ItemStyle-HorizontalAlign="left"
                                                    DataField="REEVA" />
                                                <asp:CommandField ControlStyle-Width="100%" ShowEditButton="true" ButtonType="Button"
                                                    ControlStyle-BackColor="ButtonHighlight">
                                                    <ControlStyle BackColor="ControlLightLight"></ControlStyle>
                                                </asp:CommandField>
                                                <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="grd" ControlStyle-BackColor="#FFFFFF"
                                                    ItemStyle-ForeColor="#FF0000" ButtonType="Link"></asp:CommandField>
                                            </Columns>
                                            <EditRowStyle Wrap="True" />
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
                                <br />
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
                                        <asp:RequiredFieldValidator ID="RFVworkname" runat="server" ControlToValidate="Txtworkname"
                                            Display="None" ErrorMessage="Please Enter Work Name." SetFocusOnError="True"
                                            ValidationGroup="Reg"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RFVstartdate" runat="server" ControlToValidate="Txtdatef"
                                            Display="None" ErrorMessage="Please Enter Start Date." SetFocusOnError="True"
                                            ValidationGroup="Reg"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CVstatus" runat="server" Display="None" ValidationGroup="Reg"
                                            ErrorMessage="Please Select Status." ControlToValidate="Drpstat" ValueToCompare="0"
                                            Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                        <asp:CompareValidator ID="RFVdisplay" runat="server" Display="None" ValidationGroup="Reg"
                                            ErrorMessage="Please Select Display on Page." ControlToValidate="Drpdisplay"
                                            ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>
