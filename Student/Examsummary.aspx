<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Main.master" AutoEventWireup="true"
    CodeFile="Examsummary.aspx.cs" Inherits="Student_Examsummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table width="1024px" align="center" style="border: solid 1px #000000; color: #000000;
                font-family: Cambria; font-size: 15px">
                <tr>
                    <td align="center" colspan="3" style="height: 20px; color: #FFFFFF; background-color: #008000;
                        font-weight: bold; font-style: italic; font-size: 18px;" class="lineheader">
                        - ADMIT CARD SUMMARY -
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        ROLL NUMBER:
                    </td>
                    <th align="left" valign="middle">
                        <%=ROLL %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        REGISTRATION NUMBER:
                    </td>
                    <th align="left" valign="middle">
                        <%=CANDIDATEID %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        CANDIDATE NAME:
                    </td>
                    <th align="left" valign="middle">
                        <%=CNAME %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        FATHER NAME:
                    </td>
                    <th align="left" valign="middle">
                        <%=FNAME %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        DATE OF BIRTH:
                    </td>
                    <th align="left" valign="middle">
                        <%=DOB %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        SEMESTER:
                    </td>
                    <th align="left" valign="middle">
                        <%=SEM %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        BRANCH:
                    </td>
                    <th align="left" valign="middle">
                        <%=BRANCH %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        EXAM CENTRE:
                    </td>
                    <th align="left" valign="middle">
                        <%=INSTITUTE %>
                    </th>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="font-family: Cambria; font-size: 14px; color: #0000FF;
                        border-top: solid 1px #000000;">
                        NOTE : This is only informaion about your admit card, Please collect your admit
                        card from Branch H.O.D.
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
