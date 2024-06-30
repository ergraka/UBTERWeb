<%@ Page Title="Download Brnach List" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeFile="Branchdownload.aspx.cs" Inherits="Branchdownload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true"  ID="ScriptManager1" EnableHistory="false" runat="server">
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
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- Get Branch All List --"></asp:Label>
                                </p>
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
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Button ID="Btnsearch" CssClass="btn" runat="server" ValidationGroup="Reg" Text="Search"
                                            OnClick="Btnsearch_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" class="panel-heading" style="font-family: Agency FB;
                                background-color: #CD5C5C; font-size: 25px; color: #FFFFFF;">
                                -- ALL LIST --
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:GridView ID="Grdbranch" Width="100%" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" BorderColor="#CCCCCC"
                                            BorderStyle="None">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SRNO">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="INSTITUTE" DataField="INSNAME"></asp:BoundField>
                                                <asp:BoundField HeaderText="BRANCH" DataField="BRNAME"></asp:BoundField>
                                                <asp:TemplateField HeaderText="NOMINAL ROLL">
                                                    <ItemTemplate>
                                                        <asp:HyperLink class="Link" ID="HyperLink1" runat="server" Target="_blank" Text='<%# Eval("NOMNME") %>'
                                                            NavigateUrl='<%# Eval("NOMURL") %>'></asp:HyperLink>&nbsp;,
                                                        <asp:HyperLink class="Link" ID="HyperLink4" runat="server" Target="_blank" Text="Scrutiny"
                                                            NavigateUrl='<%# Eval("SNOMURL") %>'></asp:HyperLink>&nbsp;,
                                                        <asp:HyperLink class="Link" ID="HyperLink5" runat="server" Target="_blank" Text="Re-Evaluation"
                                                            NavigateUrl='<%# Eval("RNOMURL") %>'></asp:HyperLink>&nbsp;,
                                                        <asp:HyperLink class="Link" ID="HyperLink6" runat="server" Target="_blank" Text="Back"
                                                            NavigateUrl='<%# Eval("BNOMURL") %>'></asp:HyperLink>
                                                        &nbsp;,
                                                        <asp:HyperLink class="Link" ID="HyperLink7" runat="server" Target="_blank" Text="Special Back"
                                                            NavigateUrl='<%# Eval("SBNOMURL") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LIST-E">
                                                    <ItemTemplate>
                                                        <asp:HyperLink class="Link" ID="HyperLink1" runat="server" Target="_blank" Text='<%# Eval("NOMNME") %>'
                                                            NavigateUrl='<%# Eval("LSEURL") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LIST-D">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:HyperLink class="Link" ID="HyperLink1" runat="server" Target="_blank" Text='<%# Eval("NOMNME") %>'
                                                            NavigateUrl='<%# Eval("LSDURL") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SESSIONAL LIST">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:HyperLink class="Link" ID="HyperLink1" runat="server" Target="_blank" Text='<%# Eval("NOMNME") %>'
                                                            NavigateUrl='<%# Eval("SESURL") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CROSS LIST">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:HyperLink class="Link" ID="HyperLink1" runat="server" Target="_blank" Text="Result"
                                                            NavigateUrl='<%# Eval("CROURL") %>'></asp:HyperLink>&nbsp;,
                                                        <asp:HyperLink class="Link" ID="HyperLink2" runat="server" Target="_blank" Text="Scrutiny"
                                                            NavigateUrl='<%# Eval("SCROURL") %>'></asp:HyperLink>&nbsp;,
                                                        <asp:HyperLink class="Link" ID="HyperLink3" runat="server" Target="_blank" Text="Re-Evaluation"
                                                            NavigateUrl='<%# Eval("RCROURL") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ADMIT CARD">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:HyperLink class="Link" ID="HyperLink1" runat="server" Target="_blank" Text='<%# Eval("NOMNME") %>'
                                                            NavigateUrl='<%# Eval("ADMURL") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="VERIFICATION">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:HyperLink class="Link" ID="HyperLink1" runat="server" Target="_blank" Text='<%# Eval("NOMNME") %>'
                                                            NavigateUrl='<%# Eval("VERURL") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="MARKS SHEET">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:HyperLink class="Link" ID="HyperLink1" runat="server" Target="_blank" Text='<%# Eval("NOMNME") %>'
                                                            NavigateUrl='<%# Eval("MARURL") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000066" />
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
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
