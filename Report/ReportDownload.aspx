<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportDownload.aspx.cs" Inherits="ReportDownload" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Download Report</title>
    <link href="../Images/favicon.ico" rel="Icon File" />
    <link href="../CSS/Style.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/All.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Tab.css" type="text/css" rel="Stylesheet" />
    <script src='https://kit.fontawesome.com/a076d05399.js' type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div style="width: 80%">
            <div align="center" style="color: #FFFFFF; font-family: Agency FB;
                background-color: #1E90FF; font-weight: bold; font-size: 20px;">
               DOWNLOAD REPORTS
            </div>
            <rsweb:ReportViewer ShowToolBar="true" ID="ReportViewer1" runat="server" Font-Names="Verdana"
                Width="100%" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                WaitMessageFont-Size="14pt" BorderStyle="Solid" SizeToReportContent="True">
                <LocalReport ReportPath="Report\Report.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
    </center>
    </form>
</body>
</html>
