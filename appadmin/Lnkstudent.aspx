<%@ Page Title="Student Link" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Lnkstudent.aspx.cs" Inherits="Lnkstudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <div style="width: 95%">
                    <table width="100%" cellpadding="4">
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB;
                                    font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- STUDENT LINK --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Studentaddnew.aspx" class="Link"
                                            title="New Applicant Registration">Add New Student</a><br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Studentbackpaper.aspx?STAT=BACK"
                                            class="Link" title="Back Paper Registration">Add Back Paper</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Studentbackpaper.aspx?STAT=SBACK"
                                            class="Link" title="Special Back Paper Registration">Add Special Back Paper</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Studentbackpaper.aspx?STAT=SCRU"
                                            class="Link" title="Add Scrutiny Subject">Add Scrutiny Subject</a>
                                        <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Studentbackpaper.aspx?STAT=REEVA"
                                            class="Link" title="Add Re-Evaluation Subject">Add Re-Evaluation Subject</a>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Uploaddocuments.aspx"
                                            class="Link" title="Upload Photo & Sign">Upload Student Photo
                                            & Sign</a><br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Studentupdate.aspx"
                                            class="Link" title="Change Student Institute & Branch">Change Student Institute & Branch</a>
                                            <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="Updatestudent.aspx"
                                            class="Link" title="Update Student Details">Update Student Details</a>
                                         <br />
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="SearchFinalMarksheet.aspx"
                                            class="Link" title="Final Student Marksheet">Final Marksheet</a>
                                        <br />
                                         <span style="color: #FF0000">&#x27A4;</span> <a href="UpdateBackMarks.aspx"
                                            class="Link" title="Final Student Marksheet">Update Back Marks</a>

                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
