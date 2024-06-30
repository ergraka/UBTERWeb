<%@ Page Language="C#" MasterPageFile="~/Institute/Default.master" AutoEventWireup="true"
    CodeFile="Brhome.aspx.cs" Inherits="Brhome" Title="Branch Home" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <div style="width: 100%;">
            <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" EnableCdn="true" runat="server">
            </ajax:ToolkitScriptManager>
            <table cellspacing="0" style="width: 100%; font-family: Cambria; background: url(../Images/Watermark.jpg);
                color: #000000; background-repeat-x: no-repeat; background-repeat-y: no-repeat;
                background-position: center;">
                <%--UPGRAGE STUDENTS--%>
                <tr id="TRUPGRADE" runat="server" visible="false">
                    <td align="center">
                        <i style="color: #FF0000; font-size: 17px;">Add New Student</i>
                        <asp:Image ID="Imgsem1" runat="server" Visible="true" Height="20px" Width="25px"
                            ImageUrl="~/Images/rightarrow.gif" />
                        <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnksem1" runat="server" Font-Size="17px"
                            Visible="false" Text="Click here to add in 1st Semester/Year" NavigateUrl="~/Institute/Approve.aspx"></asp:HyperLink>
                        <br />
                        <i style="color: #FF0000; font-size: 17px;">Back Paper Registration</i>
                        <asp:Image ID="Image1" runat="server" Visible="true" Height="20px" Width="25px" ImageUrl="~/Images/rightarrow.gif" />
                        <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnkback" runat="server" Font-Size="17px"
                            Visible="false" Text="Click here for Back Paper Registration" NavigateUrl="~/Institute/Stulist.aspx?TYP=BACK|ALL"></asp:HyperLink>
                        <br />
                        <i style="color: #FF0000; font-size: 17px;">Special Back Paper Registration</i>
                        <asp:Image ID="Imgsbp" runat="server" Visible="true" Height="20px" Width="25px" ImageUrl="~/Images/rightarrow.gif" />
                        <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnksback" runat="server" Font-Size="17px"
                            Visible="false" Text="Click here for Special Back Paper Registration" NavigateUrl="~/Institute/Stulist.aspx?TYP=SBACK|ALL"></asp:HyperLink>
                        <br />
                        <br />
                    </td>
                </tr>
                <%--UPGRAGE STUDENTS--%>
                <tr>
                    <td align="left" style="width: 100%;">
                        <ajax:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="Tab">
                            <ajax:TabPanel ID="Tab1" runat="server" HeaderText="01 SEM/YEAR">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel4" runat="server">
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td align="center" style="color: #FFFFFF; font-family: Cambria; background-image: url(../Images/bg.png);
                                                    font-size: 18px;">
                                                    - 01
                                                    <%=CP %>
                                                    SUMMARY -
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="Grd1" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                                        BorderStyle="None">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="SR.NO." DataField="SRNO">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="SUMMARY" DataField="SUMM">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="COUNT" DataField="COUNT">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="SUMMARY LINK">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" ID="Lnkurl" runat="server" Text='<%# Eval("LNKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKURL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NOMINAL ROLL">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("NOMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKNOMINAL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="EXAM LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("ADMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKADM") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RESULT LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("MRKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKMRK") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="Tab2" runat="server" CssClass="Tab" HeaderText="02 SEM/YEAR">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td align="center" style="color: #FFFFFF; font-family: Cambria; background-image: url(../Images/bg.png);
                                                    font-size: 18px;">
                                                    - 02
                                                    <%=CP %>
                                                    SUMMARY -
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="Grd2" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                                        BorderStyle="None">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="SR.NO." DataField="SRNO">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="SUMMARY" DataField="SUMM">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="COUNT" DataField="COUNT">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="SUMMARY LINK">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" ID="Lnkurl" runat="server" Text='<%# Eval("LNKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKURL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NOMINAL ROLL">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("NOMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKNOMINAL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="EXAM LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("ADMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKADM") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RESULT LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("MRKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKMRK") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="Tab3" runat="server" HeaderText="03 SEM/YEAR" Visible="True">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server">
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td align="center" style="color: #FFFFFF; font-family: Cambria; background-image: url(../Images/bg.png);
                                                    font-size: 18px;">
                                                    - 03
                                                    <%=CP %>
                                                    SUMMARY -
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="Grd3" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                                        BorderStyle="None" BorderWidth="1px">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="SR.NO." DataField="SRNO">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="SUMMARY" DataField="SUMM">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="COUNT" DataField="COUNT">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="SUMMARY LINK">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" ID="Lnkurl" runat="server" Text='<%# Eval("LNKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKURL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NOMINAL ROLL">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("NOMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKNOMINAL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="EXAM LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("ADMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKADM") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RESULT LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("MRKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKMRK") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="Tab4" runat="server" HeaderText="04 SEM/YEAR" Visible="True">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel3" runat="server">
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td align="center" style="color: #FFFFFF; font-family: Cambria; background-image: url(../Images/bg.png);
                                                    font-size: 18px;">
                                                    - 04
                                                    <%=CP %>
                                                    SUMMARY -
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="Grd4" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                                        BorderStyle="None" BorderWidth="1px">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="SR.NO." DataField="SRNO">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="SUMMARY" DataField="SUMM">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="COUNT" DataField="COUNT">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="SUMMARY LINK">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" ID="Lnkurl" runat="server" Text='<%# Eval("LNKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKURL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NOMINAL ROLL">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("NOMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKNOMINAL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="EXAM LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("ADMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKADM") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RESULT LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("MRKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKMRK") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="Tab5" runat="server" HeaderText="05 SEM/YEAR" Visible="True">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel5" runat="server">
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td align="center" style="color: #FFFFFF; font-family: Cambria; background-image: url(../Images/bg.png);
                                                    font-size: 18px;">
                                                    - 05
                                                    <%=CP %>
                                                    SUMMARY -
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="Grd5" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                                        BorderStyle="None" BorderWidth="1px">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="SR.NO." DataField="SRNO">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="SUMMARY" DataField="SUMM">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="COUNT" DataField="COUNT">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="SUMMARY LINK">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" ID="Lnkurl" runat="server" Text='<%# Eval("LNKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKURL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NOMINAL ROLL">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("NOMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKNOMINAL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="EXAM LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("ADMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKADM") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RESULT LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("MRKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKMRK") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="Tab6" runat="server" HeaderText="06 SEM/YEAR" Visible="True">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel6" runat="server">
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td align="center" style="color: #FFFFFF; font-family: Cambria; background-image: url(../Images/bg.png);
                                                    font-size: 18px;">
                                                    - 06
                                                    <%=CP %>
                                                    SUMMARY -
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="Grd6" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                                        BorderStyle="None" BorderWidth="1px">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="SR.NO." DataField="SRNO">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="SUMMARY" DataField="SUMM">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="COUNT" DataField="COUNT">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="SUMMARY LINK">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" ID="Lnkurl" runat="server" Text='<%# Eval("LNKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKURL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NOMINAL ROLL">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("NOMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKNOMINAL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="EXAM LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("ADMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKADM") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RESULT LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("MRKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKMRK") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="Tab7" runat="server" HeaderText="PRIVATE">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel7" runat="server">
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td align="center" style="color: #FFFFFF; font-family: Cambria; background-image: url(../Images/bg.png);
                                                    font-size: 18px;">
                                                    Private Students List
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="Grd7" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                                        BorderStyle="None" BorderWidth="1px">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="SR.NO." DataField="SRNO">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="SUMMARY" DataField="SUMM">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="COUNT" DataField="COUNT">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="SUMMARY LINK">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" ID="Lnkurl" runat="server" Text='<%# Eval("LNKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKURL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NOMINAL ROLL">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("NOMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKNOMINAL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="EXAM LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("ADMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKADM") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RESULT LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("MRKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKMRK") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="Tab8" runat="server" HeaderText="PASSED/SPECIAL">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel8" runat="server">
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td align="center" style="color: #FFFFFF; font-family: Cambria; background-image: url(../Images/bg.png);
                                                    font-size: 18px;">
                                                    Passed Student & Special Student List
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="Grd8" CssClass="grd" Width="100%" runat="server" Font-Size="15px"
                                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                                        BorderStyle="None" BorderWidth="1px">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="SR.NO." DataField="SRNO">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="SUMMARY" DataField="SUMM">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="COUNT" DataField="COUNT">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="SUMMARY LINK">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" ID="Lnkurl" runat="server" Text='<%# Eval("LNKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKURL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NOMINAL ROLL">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("NOMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKNOMINAL") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="EXAM LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("ADMNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKADM") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RESULT LINKS">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink CssClass="grd" Target="_blank" ID="Lnknominal" runat="server" Text='<%# Eval("MRKNAME") %>'
                                                                        NavigateUrl='<%# Eval("LNKMRK") %>'></asp:HyperLink></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>
