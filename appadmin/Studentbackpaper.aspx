<%@ Page Title="Back Paper" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Studentbackpaper.aspx.cs" Inherits="Studentbackpaper" %>

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
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- Back Paper Registration --"></asp:Label>
                                </p>
                            </td>
                        </tr>

                         <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                       Back Paper Type<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:RadioButton ID="Rdoonlyback" Text="Student Back" GroupName="AA" runat="server" />
                                    </div>
                                     <div class="col-lg-3">
                                        <asp:RadioButton ID="Rdoallback" Text="All Back" GroupName="AA" runat="server" />
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Institute Name<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="Drpins" ValidationGroup="Reg" CssClass="Fontfill" AutoPostBack="true"
                                            runat="server" OnSelectedIndexChanged="Drpins_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Branch Name<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="Drpbranch" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Registration Number OR Roll Number:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="Txtroll" ValidationGroup="Reg" CssClass="Fontfill" Placeholder="Registration Number OR Roll Number"
                                            MaxLength="11" onkeypress="return numbersonly(event)" runat="server"></asp:TextBox>
                                        <asp:Button ID="Btnsearch" CssClass="btn" runat="server" ValidationGroup="Reg" Text="Search"
                                            OnClick="Btnsearch_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:GridView ID="Grdsub" CssClass="grd" Width="50%" runat="server" AutoGenerateColumns="False"
                                            CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                            <Columns>
                                                <asp:BoundField HeaderText="REGNO" DataField="REGNO" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="SUBJECT" HeaderStyle-HorizontalAlign="Left">
                                                    <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Cbsub" Text='<%# Eval("SUB") %>' CssClass="gridCB" runat="server"></asp:CheckBox>
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
                                        <asp:CompareValidator ID="CVPDrpins" runat="server" Display="None" ValidationGroup="Reg"
                                            ErrorMessage="Please Select Institute Name." ControlToValidate="Drpins" ValueToCompare="0"
                                            Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                        <asp:CompareValidator ID="Cvbranch" runat="server" Display="None" ValidationGroup="Reg"
                                            ErrorMessage="Please Select Branch." ControlToValidate="Drpbranch" ValueToCompare="0"
                                            Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="Rfvroll" runat="server" ControlToValidate="Txtroll"
                                            Display="None" ErrorMessage="Please Enter Registration Number Or Roll Number."
                                            SetFocusOnError="True" ValidationGroup="Reg"></asp:RequiredFieldValidator>
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
