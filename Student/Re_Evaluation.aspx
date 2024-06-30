<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Home.master" AutoEventWireup="true"
    CodeFile="Re_Evaluation.aspx.cs" Inherits="Re_Evaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <table width="1024px" align="center" style="border: solid 1px #000000; color: #000000;
                    font-family: Cambria; font-size: 15px">
                    <tr>
                        <td align="center" colspan="2" style="color: #FFFFFF; background-color: #008000;
                            font-weight: bold; font-size: 22px;" class="lineheader">
                            -- RE-EVALUATION FORM --
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <%=Comp %>
                            <asp:GridView ID="Grdsub" CssClass="grd" Width="100%" runat="server" AutoGenerateColumns="False"
                                CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                <Columns>
                                    <asp:BoundField HeaderText="SUBJECT" DataField="SUBJECT" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="MARKS" DataField="MARKS" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="SELECT SUBJECT" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CbSelect" Text='<%# Eval("SUBCODE") %>' CssClass="gridCB" runat="server">
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
                            <asp:Button ID="Btnsubmit" CssClass="butn" runat="server" Text="Submit" OnClick="Btnsubmit_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Image ID="Imgscru" runat="server" Visible="false" Height="25px" Width="20px"
                                ImageUrl="~/Images/rightarrow.gif" />
                            <a id="Lnkscrureceipt" runat="server" visible="false" class="Link" href="~/Report/Receiptreeva.aspx" target="_blank">
                                Print Re-Evaluation Receipt</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left" style="font-family: Cambria; font-size: 14px; color: #0000FF;
                            border-top: solid 1px #000000;">
                            <b><u>NOTE :</u> </b>
                            <br />
                            01 :- RE-EVALUATION FORM FEE PER SUBJECT INR : 2000/-<br />
                            02 :- Once you have submit Correction is not possible.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="LblMessage" Font-Size="15px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                            <p style="color: #2E8B57">
                                - Please Do Not Refresh This Page -</p>
                            <br />
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
