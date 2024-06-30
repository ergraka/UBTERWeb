<%@ Page Title="Student Home" Language="C#" MasterPageFile="~/Student/Home.master"
    AutoEventWireup="true" CodeFile="Stuhome.aspx.cs" Inherits="Stuhome" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <ajax:ToolkitScriptManager ID="scriptmanager1" runat="server">
        </ajax:ToolkitScriptManager>
       <%-- <table cellspacing="0" style="width: 100%; font-family: Cambria; background: url(../Images/Watermark.jpg);
            color: #000000; background-repeat-x: no-repeat; background-repeat-y: no-repeat;
            background-position: center;">--%>
         <table cellspacing="0" style="width: 100%; font-family: Cambria; background: url(../Images/Watermark.jpg);
            color: #000000; background-repeat: no-repeat;
            background-position: center;">
            <tr>
                <td style="font-size: 20px; background-image: url(../Images/bg.png); color: #FFFFFF;
                    font-family: Agency FB;">
                    IMPORTANT LINK'S
                </td>
                <td style="font-size: 20px; background-image: url(../Images/bg.png); color: #FFFFFF;
                    font-family: Agency FB;">
                    REGISTRATION DETAILS
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 50%;">
                    <table class="table" align="center" width="100%" style="font-size: 16px;">
                        <tr>
                            <td>
                                <img src="../Images/Instruction.png" height="25px" width="25px" alt="Government" />
                            </td>
                            <td>
                                <a href="Status.aspx" target="_blank">Registration Status</a>
                                <img runat="server" id="Imgpending" src="../Images/Pending.gif" height="25" width="100"
                                    alt="Government" />
                            </td>
                            <td align="center" rowspan="6">
                                <asp:Image ID="Imgph" CssClass="Photoredius" Height="150px" Width="160px" runat="server" /><br />
                                <asp:Image ID="Imgsign" Height="50px" Width="160px" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="../Images/Feelogo.png" height="25px" width="25px" alt="FEE" />
                            </td>
                            <td>
                                <a href="Feestructure.aspx" target="_blank">Fee Structure</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="../Images/Marksheetlogo.png" height="25px" width="25px" alt="Government" />
                            </td>
                            <td>
                                <asp:HyperLink ID="Lnkmarksheet" runat="server" Target="_blank" NavigateUrl="~/Report/Marksheet.aspx">Marks
                                                    Sheet Summary</asp:HyperLink>
                            </td>
                        </tr>
                        <tr runat="server" id="TRSCRU" visible="false">
                            <td>
                                <img src="../Images/Instruction.png" height="25px" width="25px" alt="Government" />
                            </td>
                            <td>
                                <a href="Scrutiny.aspx" target="_blank">Apply Scrutiny Form</a>
                                <img src="../Images/new.gif" height="20px" width="30px" alt="New" />
                            </td>
                        </tr>
                        <tr runat="server" id="TRREEVA" visible="false">
                            <td>
                                <img src="../Images/Instruction.png" height="25px" width="25px" alt="Government" />
                            </td>
                            <td>
                                <a href="Re_Evaluation.aspx" target="_blank">Apply Re-Evaluation Form</a>
                                <img src="../Images/new.gif" height="20px" width="30px" alt="New" />
                            </td>
                        </tr>
                       <tr>
                            <td class="lineheader" style="font-family: Cambria;" align="center" colspan="2">
                                REMAINING SUBJECT
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="border:1px solid #000000" colspan="2">
                                <%=BACK %>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="center" style="width: 50%;">
                    <table border="1" align="center" width="100%" style="font-size: 14px; height: 400px;
                        border-collapse: collapse;">
                        <tr>
                            <td colspan="2" align="center" style="font-family: Agency FB; font-size: 25px;">
                                <b><i>
                                    <%=CNAME %></i></b>
                                <br />
                                <span style="color: #000000; font-family: Cambria; font-size: 15px">(
                                    <%=REGPVTNM%>
                                    )</span>
                                <br />
                                <i style="color: #3CB371">S/O</i><br />
                                <b><i>
                                    <%=FNAME %></i></b>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                ROLL NUMBER
                            </th>
                            <td align="left">
                                <%=ROLL %>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                REGISTRATION NUMBER
                            </th>
                            <td align="left">
                                <%=CANDIDATEID %>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                STUDENT NAME
                            </th>
                            <td align="left">
                                <%=CNAME %>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                FATHER NAME
                            </th>
                            <td align="left">
                                <%=FNAME %>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                DATE OF BIRTH
                            </th>
                            <td align="left">
                                <%=DOB %>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left" valign="middle">
                                <%=INSNAME %>
                            </th>
                        </tr>
                        <tr>
                            <th align="left">
                                BRANCH
                            </th>
                            <td align="left">
                                <%=BRNAME %>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                SEMETER/YEAR
                            </th>
                            <td align="left">
                                <%=SEM %>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                SHIFT
                            </th>
                            <td align="left">
                                <%=SHIFT %>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Lblmessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
