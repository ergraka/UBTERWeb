<%@ Page Title="Report Link" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeFile="Lnkreport.aspx.cs" Inherits="Lnkreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <div style="width: 95%">
                    <table width="100%" cellpadding="4">
                        <tr>
                            <td align="center">
                                <p style="background-image: url(../Images/bg.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                    || DOWNLOAD TABLE DATA ||
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--Semester wise Data--%>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SEMDATA|01"
                                            class="Link" target="_blank" title="Download Sem 01 Data">Download Sem 01 Data </a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SEMDATA|03"
                                            class="Link" target="_blank" title="Download Sem 03 Data">Download Sem 03 Data </a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SEMDATA|05"
                                            class="Link" target="_blank" title="Download Sem 05 Data">Download Sem 05 Data </a>
                                    </div>
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SEMDATA|02"
                                            class="Link" target="_blank" title="Download Sem 02 Data">Download Sem 02 Data </a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SEMDATA|04"
                                            class="Link" target="_blank" title="Download Sem 04 Data">Download Sem 04 Data </a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SEMDATA|06"
                                            class="Link" target="_blank" title="Download Sem 06 Data">Download Sem 06 Data </a>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--All Data--%>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SEMDATA|00"
                                            class="Link" target="_blank" title="Download All Data">Download All Data </a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SCRU|0"
                                            class="Link" title="Download Scrutiny Data.">Download Scrutiny Data.</a>
                                        <br />
                                    </div>
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=BACKP|00"
                                            class="Link" target="_blank" title="Download Back Paper Data">Download All Back Paper & SBP Data </a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=REEVA|0"
                                            class="Link" title="Download Re-Evaluation Data.">Download Re-Evaluation Data.</a><br />
                                    </div>
                                </div>
                            </td>
                        </tr>



                        <tr>
                            <td align="center">
                                <p style="background-image: url(../Images/bg.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                    || DOWNLOAD SUBJECT DATA ||
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SUBCOUNT|INS"
                                            class="Link" title="Download Subject Count Institute Wise.">Download Subject Count Institute Wise.</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SUBCOUNT|BR"
                                            class="Link" title="Download Subject Count Institute & Branch Wise.">Download Subject Count Institute & Branch Wise.</a>
                                    </div>
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SBPSUBINSBR|0"
                                            class="Link" title="SBP Institute & Branch Wise Subject Count Report.">SBP Institute & Branch
                                            Wise Subject Count Report.</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SBPSUB|0"
                                            class="Link" title="SBP Subject Wise Report.">SBP Subject Count Wise Report.</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=BACKSUBINSBR|0"
                                            class="Link" title="Back Paper Institute & Branch Wise Subject Count Report.">Back Paper Institute & Branch
                                            Wise Subject Count Report.</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=BACKSUB|0"
                                            class="Link" title="Back Paper Subject Wise Report.">Back Paper Subject Count Wise Report.</a>
                                    </div>
                                </div>
                            </td>

                        </tr>
                        <tr>
                            <td align="center">
                                <p style="background-image: url(../Images/bg.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                    || OTHER REPORTS ||
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Admin_Report/Regsummary.aspx"
                                            class="Link" title="Session Wise Summary">Session Wise Summary</a><br />
                                    </div>
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Admin_Report/Studentsummary.aspx"
                                            class="Link" title="Student Summary">Student Summary</a>
                                        <br />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
