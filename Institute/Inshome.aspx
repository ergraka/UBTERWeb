<%@ Page Language="C#" MasterPageFile="~/Institute/Default.master" AutoEventWireup="true"
    CodeFile="Inshome.aspx.cs" Inherits="Inshome" Title="Institute Home" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <div style="width: 95%;">
            <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" EnableCdn="true" runat="server">
            </ajax:ToolkitScriptManager>
            <table cellspacing="0" style="width: 100%; font-family: Cambria; background: url(../Images/Watermark.jpg); color: #000000; background-repeat-x: no-repeat; background-repeat-y: no-repeat; background-position: center;">
                <tr>
                    <td align="left" style="width: 100%;">
                        <ajax:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="Tab">
                            <ajax:TabPanel ID="tbpnlusrdetails" runat="server" Height="300px" HeaderText="INSTITUTE SUMMARY">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table border="1" style="width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td align="center" colspan="3" style="color: #FFFF00; font-size: 18px; background-image: url(../Images/bg.png);">- INSTITUTE SUMMARY -
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">01
                                                </td>
                                                <td align="left" valign="top">INSTITUTE REGISTERED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:LinkButton CssClass="grd" ID="Lnkall" Text="Click here to view" runat="server"
                                                        OnClick="Lnkall_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">02
                                                </td>
                                                <td align="left" valign="top">INSTITUTE APPROVED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:LinkButton CssClass="grd" ID="Lnkapproved" Text="Click here to view" runat="server"
                                                        OnClick="Lnkapproved_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top">03
                                                </td>
                                                <td align="left" valign="top">INSTITUTE NOT-APPROVED STUDENT
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:LinkButton CssClass="grd" ID="Lnknapproved" Text="Click here to view" runat="server"
                                                        OnClick="Lnknapproved_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="left" valign="top" style="color: #FF0000">Note:- All Approved list is display according to first semester approval list of
                                                    all students.
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel1" runat="server" Height="300px" HeaderText="BRANCH PASSWORD">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <table width="100%" style="font-family: Cambria; font-size: 13px">
                                                    <tr>
                                                        <td align="center" colspan="3" style="color: #FFFF00; font-size: 18px; background-image: url(../Images/bg.png);">- CHANGE BRANCH PASSWORD -
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">SELECT BRANCH NAME:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpbranch" ValidationGroup="Reg" Width="450px" AutoPostBack="true"
                                                                runat="server" Font-Names="Cambria" OnSelectedIndexChanged="Drpbranch_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">BRANCH PASSWORD:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:TextBox ID="Txtpassword" ValidationGroup="Reg" Width="450px" Font-Names="Cambria"
                                                                placeholder="BRANCH PASSWORD" runat="server" TextMode="SingleLine" MaxLength="12"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">BRANCH EMAIL:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:TextBox ID="Txtemail" ValidationGroup="Reg" Width="450px" Font-Names="Cambria"
                                                                placeholder="BRANCH EMAIL" runat="server" TextMode="SingleLine" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="2" align="left" valign="middle" style="height: 50px">
                                                            <asp:Button ID="Btnchange" CausesValidation="true" runat="server" CssClass="butn"
                                                                ValidationGroup="Reg" Text="CHANGE" OnClick="Btnchange_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td align="left" valign="middle">
                                                            <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <asp:CompareValidator ID="Cvbranch" runat="server" Display="None" ValidationGroup="Reg"
                                                                ErrorMessage="Please Select Branch !" ControlToValidate="Drpbranch" ValueToCompare="0"
                                                                Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator><asp:RegularExpressionValidator
                                                                    Display="None" ValidationGroup="Reg" ControlToValidate="txtpassword" ID="RE"
                                                                    ValidationExpression="^[\s\S]{8,12}$" runat="server" ErrorMessage="Password must be 8 to 12 characters."></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                        ID="Requireduserpassword" runat="server" ControlToValidate="txtpassword" Display="None"
                                                                        ErrorMessage="Please Enter Password." SetFocusOnError="True" ValidationGroup="Reg"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                                            ID="Rfvemail" Display="None" ValidationGroup="Reg" ControlToValidate="Txtemail"
                                                                            runat="server" ErrorMessage="Please Enter Email Address !"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                                ID="REMail" Display="None" ValidationGroup="Reg" ControlToValidate="Txtemail"
                                                                                runat="server" ErrorMessage="Invalid E-Mail id !" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Reg"
                                                                DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <%--<ajax:TabPanel ID="TabPanel2" runat="server" Height="300px" HeaderText="CHANGE STUDENT BRANCH">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel3" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <table width="100%" style="font-family: Cambria; font-size: 13px">
                                                    <tr>
                                                        <td align="center" colspan="3" style="color: #FFFF00; font-size: 18px; background-image: url(../Images/bg.png);">
                                                            - CHANGE STUDENT BRANCH -
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            REGISTRATION NUMBER:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:TextBox ID="Txtregno" ValidationGroup="Change" Width="450px" Font-Names="Cambria"
                                                                Font-Size="16px" placeholder="REGISTRATION NUMBER" runat="server" TextMode="SingleLine"
                                                                MaxLength="8"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            CURRENT BRANCH:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpcrrbranch" ValidationGroup="Change" Width="450px" runat="server"
                                                                Font-Names="Cambria">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            NEW BRANCH:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpnewbranch" ValidationGroup="Change" Width="450px" runat="server"
                                                                Font-Names="Cambria">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2" align="left" valign="middle" style="height: 50px">
                                                            <asp:Button ID="Btnbrchange" CausesValidation="true" runat="server" CssClass="butn"
                                                                ValidationGroup="Change" OnClick="Btnbrchange_Click" Text="SUBMIT" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" valign="middle">
                                                            <asp:Label ID="Lblbrchange" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txtregno"
                                                                Display="None" ErrorMessage="Please Enter Registration Number." SetFocusOnError="True"
                                                                ValidationGroup="Change"></asp:RequiredFieldValidator><asp:CompareValidator ID="Cvcrrbranch"
                                                                    runat="server" Display="None" ValidationGroup="Change" ErrorMessage="Please Select Current Branch."
                                                                    ControlToValidate="Drpcrrbranch" ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator><asp:CompareValidator
                                                                        ID="Cvnewbranch" runat="server" Display="None" ValidationGroup="Change" ErrorMessage="Please Select New Branch."
                                                                        ControlToValidate="Drpnewbranch" ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator><asp:CompareValidator
                                                                            ID="CompareValidator1" runat="server" Display="None" ValidationGroup="Change"
                                                                            ControlToValidate="Drpcrrbranch" ControlToCompare="Drpnewbranch" Operator="NotEqual"
                                                                            ErrorMessage="Current AND New Branch Should not be same."></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Change"
                                                                DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel3" runat="server" Height="300px" HeaderText="CHANGE STUDENT INSTITUTE">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel4" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <table width="100%" style="font-family: Cambria; font-size: 13px">
                                                    <tr>
                                                        <td align="center" colspan="3" style="color: #FFFF00; font-size: 18px; background-image: url(../Images/bg.png);">
                                                            - CHANGE STUDENT INSTITUTE -
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            REGISTRATION NUMBER:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:TextBox ID="Txtregnoins" ValidationGroup="InsChange" Width="450px" Font-Names="Cambria"
                                                                Font-Size="16px" placeholder="REGISTRATION NUMBER" runat="server" TextMode="SingleLine"
                                                                MaxLength="8"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            New Institute Name:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpnewins" ValidationGroup="InsChange" Width="450px" runat="server"
                                                                Font-Names="Cambria">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2" align="left" valign="middle" style="height: 50px">
                                                            <asp:Button ID="Btninschange" CausesValidation="true" runat="server" CssClass="butn"
                                                                ValidationGroup="InsChange" OnClick="Btninschange_Click" Text="SUBMIT" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" valign="middle">
                                                            <asp:Label ID="Lblins" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txtregnoins"
                                                                Display="None" ErrorMessage="Please Enter Registration Number." SetFocusOnError="True"
                                                                ValidationGroup="InsChange"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator3" runat="server" Display="None" ValidationGroup="InsChange"
                                                                ErrorMessage="Please Select New Institute." ControlToValidate="Drpnewins" ValueToCompare="0"
                                                                Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="InsChange"
                                                                DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel4" runat="server" HeaderText="ACCEPT STUDENTS">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel5" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:GridView ID="Grdaproved" CssClass="grd" Width="100%" runat="server" AutoGenerateColumns="False"
                                                                CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                        HeaderText="SRNO">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="2%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="NAME" DataField="CNAME" HeaderStyle-HorizontalAlign="Left"
                                                                        ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    </asp:BoundField>
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
                                                                    <asp:TemplateField HeaderText="APPROVED" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="middle" style="font-size: 15px; width:250px;">
                                                            SELECT BRANCH NAME:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpbranchaccept" ValidationGroup="Reg" Width="450px" runat="server"
                                                                Font-Names="Cambria">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center" valign="middle" style="height: 50px">
                                                            <asp:Button ID="Btnaccept" CausesValidation="true" runat="server" CssClass="butn"
                                                                ValidationGroup="Insaccept" OnClick="Btnaccept_Click" Text="Accept" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="middle">
                                                            <asp:Label ID="Lblaccept" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>--%>
                            <%-- </ContentTemplate>
                            </ajax:TabPanel>--%>
                        </ajax:TabContainer>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>
