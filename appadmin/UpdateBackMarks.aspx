<%@ Page Title="Update Student" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeFile="UpdateBackMarks.aspx.cs" Inherits="Updatestudent" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
        <%-- <ProgressTemplate>
            <div class="Waiting">
                <div class="center">
                    <img src="../Images/loading.gif" alt="Loading..." />
                </div>
            </div>
        </ProgressTemplate>--%>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <div style="width: 95%">
                    <table width="100%" cellpadding="4">
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- Update Student --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Roll Number:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="Txtroll" ValidationGroup="Reg" CssClass="Fontfill" Placeholder="Registration Number OR Roll Number"
                                            MaxLength="11" onkeypress="return numbersonly(event)" runat="server"></asp:TextBox>
                                        <asp:Button ID="Btnsearch" CssClass="btn" runat="server" ValidationGroup="Reg" Text="Search"
                                            OnClick="Btnsearch_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" class="panel-heading" style="font-family: Agency FB; background-color: #CD5C5C; font-size: 25px; color: #FFFFFF;">-- Update Details --
                            </td>
                        </tr>


                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="LblMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <table cellpadding="4" cellspacing="0" style="width: 100%;">
                                            <tr>
                                                <th align="left" valign="middle">INSTITUTE NAME&nbsp;:
                                                </th>
                                                <td colspan="3" align="left" valign="middle">
                                                    <%=INSTITUTE %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th align="left" valign="middle">BRANCH NAME&nbsp;:
                                                </th>
                                                <td colspan="3" align="left" valign="middle">
                                                    <%=BRANCH %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th align="left" valign="middle">STUDENT NAME&nbsp;:
                                                </th>
                                                <td align="left" valign="middle">
                                                    <%=CNAME %>
                                                </td>
                                                <th align="left" valign="middle">FATHER NAME&nbsp;:
                                                </th>
                                                <td align="left" valign="middle">
                                                    <%=FNAME %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th align="left" valign="middle">REGISTRATION NUMBER&nbsp;:
                                                </th>
                                                <td align="left" valign="middle">
                                                    <%=CANDIDATEID %>
                                                </td>
                                                <th align="left" valign="middle">ROLL NUMBER&nbsp;:
                                                </th>
                                                <td align="left" valign="middle">
                                                    <%=ROLL %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th align="left" valign="middle">DATE&nbsp;:
                                                </th>
                                                <td align="left" valign="middle">
                                                    <%=DATE %>
                                                </td>
                                                <th align="left" valign="middle">CATEGORY&nbsp;:
                                                </th>
                                                <td align="left" valign="middle">
                                                    <%=TYPE %>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>

                          <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="lblstatus" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">



                                        <asp:GridView ID="GVBackMarks" runat="server" AutoGenerateColumns="False" OnRowDeleting="OnRowDeleting"
                                            OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">

                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                                            <Columns>
                                                <asp:TemplateField HeaderText="Semester" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSemester" runat="server" Text='<%# Eval("SemTableName") %>'></asp:Label>
                                                        <%-- <asp:Label  ID="lblColumnId" runat="server" Text='<%# Eval("ColumnId") %>'></asp:Label>--%>
                                                        <asp:Literal ID="lblColumnId" runat="server" Text='<%# Eval("ColumnId") %>' Visible="false"></asp:Literal>
                                                        <asp:Literal ID="lblSess" runat="server" Text='<%# Eval("Sess") %>' Visible="false"></asp:Literal>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Left" />

                                                    <ItemStyle Width="50px" HorizontalAlign="Left"></ItemStyle>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Subject Code" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubjectCode" runat="server" Text='<%# Eval("SubjectCode") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Left" />

                                                    <ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Subject Name" ItemStyle-Width="350" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubjectName" runat="server" Text='<%# Eval("SubjectName") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Left" />

                                                    <ItemStyle Width="350px" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Subject Type" ItemStyle-Width="150" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSType" runat="server" Text='<%# Eval("SType") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Left" />

                                                    <ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Obtained Marks" ItemStyle-Width="150" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblObtMarks" runat="server" Text='<%# Eval("ObtMarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtObtMarks" runat="server" Text='<%# Eval("ObtMarks") %>'></asp:TextBox>
                                                    </EditItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Left" />

                                                    <ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Sessional Marks" ItemStyle-Width="150" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSessMarks" runat="server" Text='<%# Eval("SessMarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSessMarks" runat="server" Text='<%# Eval("SessMarks") %>'></asp:TextBox>
                                                    </EditItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Left" />

                                                    <ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Status" ItemStyle-Width="150" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubjectStatus" runat="server" Text='<%# Eval("SubjectStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSubjectStatus" runat="server" Text='<%# Eval("SubjectStatus") %>'></asp:TextBox>
                                                    </EditItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Left" />

                                                    <ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <%--<asp:TemplateField HeaderText="Update" ItemStyle-Width="50">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" ToolTip="Click here to Edit the record" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are You Sure You want to Delete the Record?');" ToolTip="Click here to Delete the record" />
                                                        </span>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

                                                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150">
                                                    <ItemStyle Width="150px"></ItemStyle>
                                                </asp:CommandField>
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        </asp:GridView>
                                        <%--  <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                    <tr>
                                        <td style="width: 150px">Name:<br />
                                            <asp:TextBox ID="txtName" runat="server" Width="140" />
                                        </td>
                                        <td style="width: 150px">Country:<br />
                                            <asp:TextBox ID="txtCountry" runat="server" Width="140" />
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />
                                        </td>
                                    </tr>
                                </table>--%>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
