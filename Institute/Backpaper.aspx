<%@ Page Title="Back Paper" Language="C#" MasterPageFile="~/Institute/Default.master" AutoEventWireup="true"
    CodeFile="Backpaper.aspx.cs" Inherits="Backpaper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true"  ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <table width="1024px" align="center" style="border: solid 1px #000000; color: #000000;
                    font-family: Cambria; font-size: 15px">
                    <tr>
                        <td align="center" colspan="2" style="color: #FFFFFF; background-color: #008000;
                            font-weight: bold; font-size: 22px;" class="lineheader">
                            - APPLICATION FORM FOR BACK PAPER/SPECIAL BACK PAPER -
                        </td>
                    </tr>
                    <tr id="TRBACKP" runat="server">
                        <td colspan="2" style="color: #FF0000">
                            NOTE:- IF YOU WANT'S TO APPLY FOR BACK PAPER, PLEASE SELECT BACK PAPER SUBJECT CODE
                            OF THEORY AND PRACTICAL.
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <%=Comp %>
                            <asp:GridView ID="Grdsub" CssClass="grd" Width="100%" runat="server" AutoGenerateColumns="False"
                                CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                <Columns>
                                    <asp:BoundField HeaderText="REGNO" DataField="REGNO" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="SUBJECT" HeaderStyle-HorizontalAlign="Left">
                                     <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Cbsub" Text='<%# Eval("SUB") %>' CssClass="gridCB" runat="server">
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
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:CheckBox ID="Chksem2" Font-Italic="true" Font-Size="16px" runat="server" Text="I agree to submit back paper of students. " />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Button ID="Btnsubmit" CssClass="butn" runat="server" Text="Submit" OnClick="Btnsubmit_Click" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left" style="font-family: Cambria; font-size: 14px; color: #0000FF;
                            border-top: solid 1px #000000;">
                            <b><u>NOTE :</u>
                                <br />
                                <i style="color: #FF0000">No Chnages allow in Back Paper after Submission of Application
                                    Form.</i>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="LblMessage" Font-Size="15px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                            <br />
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
