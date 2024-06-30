<%@ Page Title="Subject Master" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeFile="Subjectmaster.aspx.cs" Inherits="Subjectmaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <div class="Waiting">
                    <div class="center">
                        <img src="../Images/loading.gif" alt="Loading..." />
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="width: 95%">
                    <table width="100%" cellpadding="4">
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- SUBJECT MASTER --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Subject Category:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:RadioButton ID="Rdonew" runat="server" Checked="true" GroupName="A" Text="New Subject" />&nbsp;
                                        <asp:RadioButton ID="Rdoold" runat="server" GroupName="A" Text="Old Subject" />&nbsp;
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Subject Type:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:RadioButton ID="Rdomainsub" runat="server" Checked="true" GroupName="B" Text="Main Subject" />&nbsp;
                                        <asp:RadioButton ID="Rdosesssub" runat="server" GroupName="B" Text="Sessional Subject" />&nbsp;
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Branch Name<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="Drpbranch" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <hr />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        <asp:CheckBox ID="Chkall" runat="server" Text="Update Subject Detail in All Branch." />
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Button ID="Btnsearch" ValidationGroup="Reg" CssClass="btn" runat="server" Text="Search"
                                            OnClick="Btnsearch_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <table id="Tbladdmain" runat="server" visible="false" border="1" cellpadding="0"
                                            cellspacing="0" style="border-collapse: collapse; width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="Drpsem" Width="80px" ValidationGroup="Reg" CssClass="Fontfill"
                                                        runat="server">
                                                        <asp:ListItem Value="0">Sem</asp:ListItem>
                                                        <asp:ListItem Value="01">01</asp:ListItem>
                                                        <asp:ListItem Value="02">02</asp:ListItem>
                                                        <asp:ListItem Value="03">03</asp:ListItem>
                                                        <asp:ListItem Value="04">04</asp:ListItem>
                                                        <asp:ListItem Value="05">05</asp:ListItem>
                                                        <asp:ListItem Value="06">06</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtbrcode" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="2" AutoComplete="Off" ToolTip="Branch"
                                                        placeholder="Branch"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtsubcode" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="6" AutoComplete="Off" ToolTip="Subcode"
                                                        placeholder="Subcode"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtsubname" ValidationGroup="Reg" runat="server" CssClass="Fontfill"
                                                        MaxLength="50" AutoComplete="Off" ToolTip="Subname" placeholder="Subname"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtthmax" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Thmax"
                                                        placeholder="Thmax"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtthmin" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Thmin"
                                                        placeholder="Thmin"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtprmax" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Prmax"
                                                        placeholder="Prmax"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtprmin" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Prmin"
                                                        placeholder="Prmin"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txttsmax" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Tsmax"
                                                        placeholder="Tsmax"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txttsmin" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Tsmin"
                                                        placeholder="Tsmin"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtpsmax" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Psmax"
                                                        placeholder="Psmax"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtpsmin" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Psmin"
                                                        placeholder="Psmin"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtcredit" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="1" AutoComplete="Off" ToolTip="Credit"
                                                        placeholder="Credit"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtmax" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Max"
                                                        placeholder="Max"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtmin" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Min"
                                                        placeholder="Min"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="Drptype" Width="80px" ValidationGroup="Reg" CssClass="Fontfill"
                                                        runat="server">
                                                        <asp:ListItem Value="0">Type</asp:ListItem>
                                                        <asp:ListItem Value="T">T</asp:ListItem>
                                                        <asp:ListItem Value="P">P</asp:ListItem>
                                                        <asp:ListItem Value="TP">TP</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="center" style="width: 60px">
                                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="InsertMain" />
                                                </td>
                                            </tr>
                                        </table>
                                        <%--   EDIT MAIN SUBJECT--%>
                                        <asp:GridView ID="Grdedit" CssClass="grd" Width="100%" runat="server" Font-Size="13px"
                                            DataKeyNames="SUBCODE" CellPadding="1" AutoGenerateColumns="false" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowCancelingEdit="Grdedit_RowCancelingEdit"
                                            OnRowDataBound="OnRowDataBound" OnRowEditing="Grdedit_RowEditing" OnRowUpdating="Grdedit_RowUpdating"
                                            OnRowDeleting="OnRowDeletingMain">

                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                    HeaderText="SR">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:BoundField ControlStyle-Width="100%" ReadOnly="true" HeaderText="SEM" ItemStyle-HorizontalAlign="Center"
                                                    DataField="SEM" />
                                                <asp:BoundField ControlStyle-Width="100%" ReadOnly="true" HeaderText="BRCODE" ItemStyle-HorizontalAlign="Center"
                                                    DataField="BRCODE" />
                                                <asp:BoundField HeaderText="SUBCODE" ControlStyle-Width="50px" ItemStyle-HorizontalAlign="Center"
                                                    DataField="SUBCODE" />
                                                <asp:BoundField ControlStyle-Width="100%" HeaderText="SUBJECT" ItemStyle-HorizontalAlign="Center"
                                                    DataField="SUBJECT" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="THMAX" ItemStyle-HorizontalAlign="Center"
                                                    DataField="THMAX" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="THMIN" ItemStyle-HorizontalAlign="Center"
                                                    DataField="THMIN" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="PRMAX" ItemStyle-HorizontalAlign="Center"
                                                    DataField="PRMAX" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="PRMIN" ItemStyle-HorizontalAlign="Center"
                                                    DataField="PRMIN" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="TSMAX" ItemStyle-HorizontalAlign="Center"
                                                    DataField="TSMAX" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="TSMIN" ItemStyle-HorizontalAlign="Center"
                                                    DataField="TSMIN" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="PSMAX" ItemStyle-HorizontalAlign="Center"
                                                    DataField="PSMAX" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="PSMIN" ItemStyle-HorizontalAlign="Center"
                                                    DataField="PSMIN" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="CREDIT" ItemStyle-HorizontalAlign="Center"
                                                    DataField="CREDIT" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="MAX" ItemStyle-HorizontalAlign="Center"
                                                    DataField="MAX" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="MIN" ItemStyle-HorizontalAlign="Center"
                                                    DataField="MIN" />
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="TYPE" ItemStyle-HorizontalAlign="Center"
                                                    DataField="TYPE" />
                                                <asp:CommandField ControlStyle-Width="100%" ShowEditButton="true" ButtonType="Button"
                                                    ControlStyle-BackColor="ButtonHighlight">
                                                    <ControlStyle BackColor="ControlLightLight"></ControlStyle>
                                                </asp:CommandField>
                                                <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" ControlStyle-CssClass="grd"
                                                    ControlStyle-BackColor="#FFFFFF" ItemStyle-ForeColor="#FF0000" ButtonType="Link"></asp:CommandField>
                                            </Columns>
                                            <EditRowStyle Wrap="True" />
                                            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center"></PagerStyle>
                                            <RowStyle ForeColor="#000066"></RowStyle>
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                            <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                                            <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                                            <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                                            <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                                        </asp:GridView>
                                        <%--   EDIT SESSIONAL SUBJECT--%>
                                        <table id="Tbladdsess" runat="server" visible="false" border="1" cellpadding="0"
                                            cellspacing="0" style="border-collapse: collapse; width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="Drpssem" Width="80px" ValidationGroup="Reg" CssClass="Fontfill"
                                                        runat="server">
                                                        <asp:ListItem Value="0">Sem</asp:ListItem>
                                                        <asp:ListItem Value="01">01</asp:ListItem>
                                                        <asp:ListItem Value="02">02</asp:ListItem>
                                                        <asp:ListItem Value="03">03</asp:ListItem>
                                                        <asp:ListItem Value="04">04</asp:ListItem>
                                                        <asp:ListItem Value="05">05</asp:ListItem>
                                                        <asp:ListItem Value="06">06</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtsbrcode" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="2" AutoComplete="Off" ToolTip="Brcode"
                                                        placeholder="Brcode"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtssubcode" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="6" AutoComplete="Off" ToolTip="Subcode"
                                                        placeholder="Subcode"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtssubname" ValidationGroup="Reg" runat="server" CssClass="Fontfill"
                                                        MaxLength="50" AutoComplete="Off" ToolTip="Subname" placeholder="Subname"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtssubmax" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Submax"
                                                        placeholder="Submax"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtssubmin" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="3" AutoComplete="Off" ToolTip="Submin"
                                                        placeholder="Submin"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Txtscredit" onkeypress="return numbersonly(event)" ValidationGroup="Reg"
                                                        runat="server" CssClass="Fontfill" MaxLength="1" AutoComplete="Off" ToolTip="CEDIT"
                                                        placeholder="CEDIT"></asp:TextBox>
                                                </td>
                                                <td align="center" style="width: 60px">
                                                    <asp:Button ID="Btnsadd" runat="server" Text="Add" OnClick="InsertSess" />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:GridView ID="Grdsess" Visible="False" Width="100%" runat="server" Font-Size="13px"
                                            DataKeyNames="SUBCODE" CellPadding="4" AutoGenerateColumns="False" OnRowCancelingEdit="Grdsess_RowCancelingEdit"
                                            OnRowEditing="Grdsess_RowEditing" OnRowUpdating="Grdsess_RowUpdating" ForeColor="#333333"
                                            GridLines="None" OnRowDeleting="OnRowDeletingSess">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                    HeaderText="SR">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:BoundField ControlStyle-Width="100%" ReadOnly="true" HeaderText="SEM" ItemStyle-HorizontalAlign="Center"
                                                    DataField="SEM">
                                                    <ControlStyle Width="100%" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField ControlStyle-Width="100%" ReadOnly="true" HeaderText="BRCODE" ItemStyle-HorizontalAlign="Center"
                                                    DataField="BRCODE">
                                                    <ControlStyle Width="100%" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="SUBCODE" ControlStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                                                    DataField="SUBCODE">
                                                    <ControlStyle Width="80px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField ControlStyle-Width="100%" HeaderText="SUBJECT" ItemStyle-HorizontalAlign="Center"
                                                    DataField="SUBJECT">
                                                    <ControlStyle Width="100%" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="SUBMAX" ItemStyle-HorizontalAlign="Center"
                                                    DataField="SUBMAX">
                                                    <ControlStyle Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="SUBMIN" ItemStyle-HorizontalAlign="Center"
                                                    DataField="SUBMIN">
                                                    <ControlStyle Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField ControlStyle-Width="50px" HeaderText="CREDIT" ItemStyle-HorizontalAlign="Center"
                                                    DataField="CREDIT">
                                                    <ControlStyle Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:CommandField ControlStyle-Width="100%" ShowEditButton="true" ButtonType="Button"
                                                    ControlStyle-BackColor="ButtonHighlight">
                                                    <ControlStyle BackColor="ControlLightLight"></ControlStyle>
                                                </asp:CommandField>
                                                <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" ControlStyle-CssClass="grd"
                                                    ControlStyle-BackColor="#FFFFFF" ItemStyle-ForeColor="#FF0000" ButtonType="Link"></asp:CommandField>
                                            </Columns>
                                            <EditRowStyle Wrap="True" />
                                            <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True"></FooterStyle>
                                            <HeaderStyle BackColor="#990000" HorizontalAlign="Center" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center"></PagerStyle>
                                            <RowStyle ForeColor="#333333" BackColor="#FFFBD6"></RowStyle>
                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>
                                            <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>
                                            <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>
                                            <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>
                                            <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SUBNMAIN|0"
                                            class="Link" title="Download New Main Subject Details.">Download New Main Subject
                                            Details.</a>
                                    </div>
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SUBOMAIN|0"
                                            class="Link" title="Download Old Main Subject Details.">Download Old Main Subject
                                            Details.</a>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SUBNSESS|0"
                                            class="Link" title="Download New Sessional Subject Details.">Download New Sessional
                                            Subject Details.</a>
                                    </div>
                                    <div class="col-lg-6">
                                        <span style="color: #FF0000">&#x27A4;</span> <a href="../Institute/Canidpass.aspx?DOWNLOAD=SUBOSESS|0"
                                            class="Link" title="Download Old Sessional Subject Details.">Download Old Sessional
                                            Subject Details.</a>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Reg"
                                            DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>
