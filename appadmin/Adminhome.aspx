<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Adminhome.aspx.cs" Inherits="Adminhome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server" EnableHistory="false"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <div style="width: 95%">
                    <table style="width: 100%; font-family: Cambria; background: url(../Images/Watermark.jpg); border-collapse: collapse; background-repeat-x: no-repeat; background-repeat-y: no-repeat; background-position: center;">
                        <tr>
                            <td colspan="4" align="center">
                                <asp:GridView ID="Grdsumm" Width="100%" runat="server" Font-Size="15px" Font-Names="Cambria"
                                    AutoGenerateColumns="False" AllowSorting="True" CellPadding="4" HorizontalAlign="Center"
                                    ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"
                                    BorderStyle="None" BorderWidth="1px">
                                    <Columns>
                                        <asp:BoundField HeaderText="TOTAL INSTITUTE" DataField="TOTINS">
                                            <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="TOTAL BRANCH" DataField="TOTBRANCH">
                                            <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="TOTAL STUDENT" DataField="TOTSTU">
                                            <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="center"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                    <AlternatingRowStyle BackColor="White" />
                                    <FooterStyle BackColor="#CCCC99" />
                                    <HeaderStyle BackColor="#6B696B" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" />
                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#F7F7DE" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18px" />
                                    <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
                                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                    <SortedAscendingHeaderStyle BackColor="#848384" />
                                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                    <SortedDescendingHeaderStyle BackColor="#575357" />
                                </asp:GridView>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <p  style="background-image: url(../Images/bg.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" || CURRENT LIVE SESSION ||"></asp:Label>
                                </p>
                                <asp:GridView ID="Grdsess" Width="100%" runat="server" Font-Size="15px" Font-Names="Cambria"
                                    AutoGenerateColumns="False" AllowSorting="True" CellPadding="4" HorizontalAlign="Center" BackColor="White" BorderColor="#CC9966"
                                    BorderStyle="None" BorderWidth="1px">
                                    <Columns>
                                        <asp:BoundField HeaderText="SESSION DETAILS" DataField="SESSDETAIL">
                                            <HeaderStyle HorizontalAlign="left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="SESSION VALUES" DataField="SESSVAL">
                                            <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="center"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" ForeColor="#FFFFCC" HorizontalAlign="Center" Font-Bold="True" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="18px" ForeColor="#330099" />
                                    <SelectedRowStyle BackColor="#FFCC66" ForeColor="#663399" Font-Bold="True" />
                                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                </asp:GridView>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Openform.aspx" class="Link"
                                            title="Open Registration Form">Open Registration Form</a><br />
                                    </div>
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Formbranch.aspx" class="Link"
                                            title="Add Institute & Barch Category For
                                            Registration Form">Add Institute & Barch Category For Registration Form</a>
                                    </div>
                                </div>
                                <div class="row">
                                    <p style="background-image: url(../Images/bg.jpg); font-family: Agency FB; text-align: center; font-size: 25px; color: #FFFFFF;">
                                        <asp:Label ID="Label1" runat="server" Text=" || OPEN REPORT'S ||"></asp:Label>
                                    </p>
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Openreports.aspx?STAT=ADMT"
                                            class="Link" title="Open Admit Card">Open Admit Card</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Openreports.aspx?STAT=VER"
                                            class="Link" title="Open Verification">Open Verification</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Openreports.aspx?STAT=LISTE"
                                            class="Link" title="Open LIST-E">Open Practical (LIST-E)</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Openreports.aspx?STAT=LISTD"
                                            class="Link" title="Open LIST-D">Open Theory (LIST-D)</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Openreports.aspx?STAT=SESS"
                                            class="Link" title="Open Sessional List">Open Sessional List</a>
                                    </div>
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Openreports.aspx?STAT=SBPADMT"
                                            class="Link" title="SBP Open Admit Card">SBP Open Admit Card</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Openreports.aspx?STAT=SBPVER"
                                            class="Link" title="SBP Open Verification">SBP Open Verification</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Openreports.aspx?STAT=SBPLISTE"
                                            class="Link" title="SBP Open LIST-E">SBP Open Practical (LIST-E)</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Openreports.aspx?STAT=SBPLISTD"
                                            class="Link" title="SBP Open LIST-D">SBP Open Theory (LIST-D)</a>
                                        <br />
                                    </div>
                                </div>
                            </td>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Label ID="LblMessage" Font-Size="12px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                    </table>
                    <hr />
                    <p align="center" style="font-size: 25px; color: #FF0000; font-family: Agency FB">
                        Uttarakhand Board of Technical Education<br />
                        Roorkee [ HARIDWAR ]<br />
                        India(91)
                    </p>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
