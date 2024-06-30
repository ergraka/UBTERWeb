<%@ Page Title="Search" Language="C#" MasterPageFile="~/Institute/Default.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <div style="width: 95%">
                    <table width="100%" cellpadding="1" cellspacing="0" style="color: #000000; border-collapse: collapse;">
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- SEARCH STUDENT --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Roll Number OR Registration Number<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="Txtregno" CssClass="Fontfill" Placeholder="Roll Number OR Registration Number"
                                            MaxLength="11" onkeypress="return numbersonly(event)" runat="server"></asp:TextBox>
                                        <asp:Button ID="Btnsearch" CssClass="btn" runat="server" Text="Search" OnClick="Btnsearch_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <%=STR %>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:GridView ID="Grd1" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                            DataKeyNames="FORMTYPE" AllowSorting="True" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None">
                                            <Columns>
                                                <asp:BoundField HeaderText="FORM TYPE" DataField="FORMTYPE">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="REG NO" DataField="CANDIDATEID">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ROLL NUMBER" DataField="ROLL">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="STATUS" DataField="STAT">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="VIEW FORM" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:HyperLink CssClass="grd" ID="HyperLink1" Target="_blank" runat="server" Text='<%# Eval("VIEWNAME") %>'
                                                            NavigateUrl='<%# Eval("VIEWURL") %>'></asp:HyperLink>
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
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="LblMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Name
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="Lblcname" ForeColor="#FF0000" runat="server" Text="Name"></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Father Name
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="Lblfname" ForeColor="#FF0000" runat="server" Text="Father Name"></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                       Semester/Year
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="Lblsem" ForeColor="#FF0000" runat="server" Text="Semester"></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Student Type (Regular/Private/Passed)
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="Lbltype" ForeColor="#FF0000" runat="server" Text="Student Current Status"></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Institute Name
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="Lblins" ForeColor="#FF0000" runat="server" Text="Institute Name"></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Branch Name
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="Lblbranch" ForeColor="#FF0000" runat="server" Text="Branch Name"></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12 text-center" style="background-color:cornflowerblue; color:white">
                                        <%=STUTAB %>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
