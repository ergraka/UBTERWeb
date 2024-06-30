<%@ Page Language="C#" MasterPageFile="~/Student/Main.master" AutoEventWireup="true"
    CodeFile="Qualification.aspx.cs" Inherits="Qualification" Title="Qualification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function Per12() {
            var A = document.getElementById('<%=Txt12MM.ClientID%>').value;
            if (A.length == 1) { A = '000' + A; } else if (A.length == 2) { A = '00' + A; } else if (A.length == 3) { A = '0' + A; }
            document.getElementById('<%=Txt12MM.ClientID%>').value = A;
            var B = document.getElementById('<%=Txt12MO.ClientID%>').value;
            if (B.length == 1) { B = '000' + B; } else if (B.length == 2) { B = '00' + B; } else if (B.length == 3) { B = '0' + B; }
            document.getElementById('<%=Txt12MO.ClientID%>').value = B;
            if (A != '' && B != '') {
                if (A > B) {
                    var C = B * 100 / A;
                    document.getElementById('<%=Txt12Per.ClientID%>').value = C.toFixed(2);
                }
                else {
                    document.getElementById('<%=Txt12MO.ClientID%>').value = '';
                    document.getElementById('<%=Txt12MM.ClientID%>').value = '';
                    document.getElementById('<%=Txt12Per.ClientID%>').value = '';
                    alert('Intermediate Obtained Marks can not be greater than maximum marks.');
                }
            }
        }
        function PerUG() {
            var A = document.getElementById('<%=TxtUGMM.ClientID%>').value;
            if (A.length == 1) { A = '000' + A; } else if (A.length == 2) { A = '00' + A; } else if (A.length == 3) { A = '0' + A; }
            document.getElementById('<%=TxtUGMM.ClientID%>').value = A;
            var B = document.getElementById('<%=TxtUGMO.ClientID%>').value;
            if (B.length == 1) { B = '000' + B; } else if (B.length == 2) { B = '00' + B; } else if (B.length == 3) { B = '0' + B; }
            document.getElementById('<%=TxtUGMO.ClientID%>').value = B;
            if (A != '' && B != '') {
                if (A > B) {
                    var C = B * 100 / A;
                    document.getElementById('<%=TxtUGPer.ClientID%>').value = C.toFixed(2);
                }
                else {
                    document.getElementById('<%=TxtUGMO.ClientID%>').value = '';
                    document.getElementById('<%=TxtUGMM.ClientID%>').value = '';
                    document.getElementById('<%=TxtUGPer.ClientID%>').value = '';
                    alert('Under Graduate Obtained Marks can not be greater than maximum marks.');
                }
            }
        }
        function PerPG() {
            var A = document.getElementById('<%=TxtPGMM.ClientID%>').value;
            if (A.length == 1) { A = '000' + A; } else if (A.length == 2) { A = '00' + A; } else if (A.length == 3) { A = '0' + A; }
            document.getElementById('<%=TxtPGMM.ClientID%>').value = A;
            var B = document.getElementById('<%=TxtPGMO.ClientID%>').value;
            if (B.length == 1) { B = '000' + B; } else if (B.length == 2) { B = '00' + B; } else if (B.length == 3) { B = '0' + B; }
            document.getElementById('<%=TxtPGMO.ClientID%>').value = B;
            if (A != '' && B != '') {
                if (A > B) {
                    var C = B * 100 / A;
                    document.getElementById('<%=TxtPGPer.ClientID%>').value = C.toFixed(2);
                }
                else {
                    document.getElementById('<%=TxtPGMO.ClientID%>').value = '';
                    document.getElementById('<%=TxtPGMM.ClientID%>').value = '';
                    document.getElementById('<%=TxtPGPer.ClientID%>').value = '';
                    alert('Post Graduate Obtained Marks can not be greater than maximum marks.');
                }
            }
        }
        function PerO() {
            var A = document.getElementById('<%=TxtOMM.ClientID%>').value;
            if (A.length == 1) { A = '000' + A; } else if (A.length == 2) { A = '00' + A; } else if (A.length == 3) { A = '0' + A; }
            document.getElementById('<%=TxtOMM.ClientID%>').value = A;
            var B = document.getElementById('<%=TxtOMO.ClientID%>').value;
            if (B.length == 1) { B = '000' + B; } else if (B.length == 2) { B = '00' + B; } else if (B.length == 3) { B = '0' + B; }
            document.getElementById('<%=TxtOMO.ClientID%>').value = B;
            if (A != '' && B != '') {
                if (A > B) {
                    var C = B * 100 / A;
                    document.getElementById('<%=TxtOPer.ClientID%>').value = C.toFixed(2);
                }
                else {
                    document.getElementById('<%=TxtOMO.ClientID%>').value = '';
                    document.getElementById('<%=TxtOMM.ClientID%>').value = '';
                    document.getElementById('<%=TxtOPer.ClientID%>').value = '';
                    alert('Others Obtained Marks can not be greater than maximum marks.');
                }
            }
        }
    </script>
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table border="1" align="center" style="border: 1px solid #000000; color: #000000;
                font-family: Cambria; border-collapse: collapse; font-size: 15px;">
                <tr>
                    <td colspan="2" style="background-color: #191970; font-size: 13px; font-weight: bold;
                        color: #FFFFFF; height: 30px;" align="center">
                        EXAMINATION
                    </td>
                    <td style="background-color: #191970; font-size: 13px; font-weight: bold; color: #FFFFFF;"
                        align="center">
                        COURSE NAME
                    </td>
                    <td style="background-color: #191970; font-size: 13px; font-weight: bold; color: #FFFFFF;"
                        align="center">
                        BOARD / UNIVERSITY
                    </td>
                    <td style="background-color: #191970; font-size: 13px; font-weight: bold; color: #FFFFFF;"
                        align="center">
                        PASSING YEAR
                    </td>
                    <td style="background-color: #191970; font-size: 13px; font-weight: bold; color: #FFFFFF;"
                        align="center">
                        MARKS OBTAINED
                    </td>
                    <td style="background-color: #191970; font-size: 13px; font-weight: bold; color: #FFFFFF;"
                        align="center">
                        MAX MARKS
                    </td>
                    <td style="background-color: #191970; font-size: 13px; font-weight: bold; color: #FFFFFF;"
                        align="center">
                        PER(%)/GRADE/POINTS
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left">
                        High School or Equivalent<span style="color: #FF0000">*</span>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="Txt10Board" placeholder="Enter Board Name" CssClass="uppercase"
                            TextMode="MultiLine" Width="100%" runat="server" ValidationGroup="Reg" onkeypress="return charsonly(event)"
                            MaxLength="100"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="Drp10Year" Width="80%" runat="server" ValidationGroup="Reg"
                            Font-Names="Cambria">
                            <asp:ListItem Value="0">Year</asp:ListItem>
                            <asp:ListItem Value="2022">2022</asp:ListItem>
                            <asp:ListItem Value="2021">2021</asp:ListItem>
                            <asp:ListItem Value="2020">2020</asp:ListItem>
                            <asp:ListItem Value="2019">2019</asp:ListItem>
                            <asp:ListItem Value="2018">2018</asp:ListItem>
                            <asp:ListItem Value="2017">2017</asp:ListItem>
                            <asp:ListItem Value="2016">2016</asp:ListItem>
                            <asp:ListItem Value="2015">2015</asp:ListItem>
                            <asp:ListItem Value="2014">2014</asp:ListItem>
                            <asp:ListItem Value="2013">2013</asp:ListItem>
                            <asp:ListItem Value="2012">2012</asp:ListItem>
                            <asp:ListItem Value="2011">2011</asp:ListItem>
                            <asp:ListItem Value="2010">2010</asp:ListItem>
                            <asp:ListItem Value="2009">2009</asp:ListItem>
                            <asp:ListItem Value="2008">2008</asp:ListItem>
                            <asp:ListItem Value="2007">2007</asp:ListItem>
                            <asp:ListItem Value="2006">2006</asp:ListItem>
                            <asp:ListItem Value="2005">2005</asp:ListItem>
                            <asp:ListItem Value="2004">2004</asp:ListItem>
                            <asp:ListItem Value="2003">2003</asp:ListItem>
                            <asp:ListItem Value="2002">2002</asp:ListItem>
                            <asp:ListItem Value="2001">2001</asp:ListItem>
                            <asp:ListItem Value="2000">2000</asp:ListItem>
                            <asp:ListItem Value="1999">1999</asp:ListItem>
                            <asp:ListItem Value="1998">1998</asp:ListItem>
                            <asp:ListItem Value="1997">1997</asp:ListItem>
                            <asp:ListItem Value="1996">1996</asp:ListItem>
                            <asp:ListItem Value="1995">1995</asp:ListItem>
                            <asp:ListItem Value="1994">1994</asp:ListItem>
                            <asp:ListItem Value="1993">1993</asp:ListItem>
                            <asp:ListItem Value="1992">1992</asp:ListItem>
                            <asp:ListItem Value="1991">1991</asp:ListItem>
                            <asp:ListItem Value="1990">1990</asp:ListItem>
                            <asp:ListItem Value="1989">1989</asp:ListItem>
                            <asp:ListItem Value="1988">1988</asp:ListItem>
                            <asp:ListItem Value="1987">1987</asp:ListItem>
                            <asp:ListItem Value="1986">1986</asp:ListItem>
                            <asp:ListItem Value="1985">1985</asp:ListItem>
                            <asp:ListItem Value="1984">1984</asp:ListItem>
                            <asp:ListItem Value="1983">1983</asp:ListItem>
                            <asp:ListItem Value="1982">1982</asp:ListItem>
                            <asp:ListItem Value="1981">1981</asp:ListItem>
                            <asp:ListItem Value="1980">1980</asp:ListItem>
                            <asp:ListItem Value="1979">1979</asp:ListItem>
                            <asp:ListItem Value="1978">1978</asp:ListItem>
                            <asp:ListItem Value="1977">1977</asp:ListItem>
                            <asp:ListItem Value="1976">1976</asp:ListItem>
                            <asp:ListItem Value="1975">1975</asp:ListItem>
                            <asp:ListItem Value="1974">1974</asp:ListItem>
                            <asp:ListItem Value="1973">1973</asp:ListItem>
                            <asp:ListItem Value="1972">1972</asp:ListItem>
                            <asp:ListItem Value="1971">1971</asp:ListItem>
                            <asp:ListItem Value="1970">1970</asp:ListItem>
                            <asp:ListItem Value="1969">1969</asp:ListItem>
                            <asp:ListItem Value="1968">1968</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                    </td>
                    <td align="center">
                    </td>
                    <td align="center">
                        <asp:TextBox ID="Txt10Per" placeholder="" MaxLength="5" Width="80%" runat="server"
                            ValidationGroup="Reg" CssClass="uppercase"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left">
                        Intermediate or Equivalent
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="Txt12Board" placeholder="Enter Board Name" Width="100%" runat="server"
                            ValidationGroup="Reg" onkeypress="return charsonly(event)" TextMode="MultiLine"
                            MaxLength="100" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="Drp12Year" Width="80%" runat="server" ValidationGroup="Reg"
                            Font-Names="Cambria">
                            <asp:ListItem Value="0">Year</asp:ListItem>
                            <asp:ListItem Value="2022">2022</asp:ListItem>
                             <asp:ListItem Value="2021">2021</asp:ListItem>
                            <asp:ListItem Value="2020">2020</asp:ListItem>
                            <asp:ListItem Value="2019">2019</asp:ListItem>
                            <asp:ListItem Value="2018">2018</asp:ListItem>
                            <asp:ListItem Value="2017">2017</asp:ListItem>
                            <asp:ListItem Value="2016">2016</asp:ListItem>
                            <asp:ListItem Value="2015">2015</asp:ListItem>
                            <asp:ListItem Value="2014">2014</asp:ListItem>
                            <asp:ListItem Value="2013">2013</asp:ListItem>
                            <asp:ListItem Value="2012">2012</asp:ListItem>
                            <asp:ListItem Value="2011">2011</asp:ListItem>
                            <asp:ListItem Value="2010">2010</asp:ListItem>
                            <asp:ListItem Value="2009">2009</asp:ListItem>
                            <asp:ListItem Value="2008">2008</asp:ListItem>
                            <asp:ListItem Value="2007">2007</asp:ListItem>
                            <asp:ListItem Value="2006">2006</asp:ListItem>
                            <asp:ListItem Value="2005">2005</asp:ListItem>
                            <asp:ListItem Value="2004">2004</asp:ListItem>
                            <asp:ListItem Value="2003">2003</asp:ListItem>
                            <asp:ListItem Value="2002">2002</asp:ListItem>
                            <asp:ListItem Value="2001">2001</asp:ListItem>
                            <asp:ListItem Value="2000">2000</asp:ListItem>
                            <asp:ListItem Value="1999">1999</asp:ListItem>
                            <asp:ListItem Value="1998">1998</asp:ListItem>
                            <asp:ListItem Value="1997">1997</asp:ListItem>
                            <asp:ListItem Value="1996">1996</asp:ListItem>
                            <asp:ListItem Value="1995">1995</asp:ListItem>
                            <asp:ListItem Value="1994">1994</asp:ListItem>
                            <asp:ListItem Value="1993">1993</asp:ListItem>
                            <asp:ListItem Value="1992">1992</asp:ListItem>
                            <asp:ListItem Value="1991">1991</asp:ListItem>
                            <asp:ListItem Value="1990">1990</asp:ListItem>
                            <asp:ListItem Value="1989">1989</asp:ListItem>
                            <asp:ListItem Value="1988">1988</asp:ListItem>
                            <asp:ListItem Value="1987">1987</asp:ListItem>
                            <asp:ListItem Value="1986">1986</asp:ListItem>
                            <asp:ListItem Value="1985">1985</asp:ListItem>
                            <asp:ListItem Value="1984">1984</asp:ListItem>
                            <asp:ListItem Value="1983">1983</asp:ListItem>
                            <asp:ListItem Value="1982">1982</asp:ListItem>
                            <asp:ListItem Value="1981">1981</asp:ListItem>
                            <asp:ListItem Value="1980">1980</asp:ListItem>
                            <asp:ListItem Value="1979">1979</asp:ListItem>
                            <asp:ListItem Value="1978">1978</asp:ListItem>
                            <asp:ListItem Value="1977">1977</asp:ListItem>
                            <asp:ListItem Value="1976">1976</asp:ListItem>
                            <asp:ListItem Value="1975">1975</asp:ListItem>
                            <asp:ListItem Value="1974">1974</asp:ListItem>
                            <asp:ListItem Value="1973">1973</asp:ListItem>
                            <asp:ListItem Value="1972">1972</asp:ListItem>
                            <asp:ListItem Value="1971">1971</asp:ListItem>
                            <asp:ListItem Value="1970">1970</asp:ListItem>
                            <asp:ListItem Value="1969">1969</asp:ListItem>
                            <asp:ListItem Value="1968">1968</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="Txt12MO" placeholder="MO" Width="80%" onkeypress="return numbersonly(event)"
                            runat="server" ValidationGroup="Reg" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="Txt12MM" placeholder="MM" Width="80%" onkeypress="return numbersonly(event)"
                            runat="server" ValidationGroup="Reg" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="Txt12Per" placeholder="00.00" onkeypress="return numAnddot(event)"
                            MaxLength="5" Width="80%" runat="server" CssClass="uppercase"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left">
                        Under Graduate
                    </td>
                    <td>
                        <asp:TextBox ID="TxtUG" placeholder="UG Course" Width="150px" runat="server" ValidationGroup="Reg"
                            onkeypress="return charsonly(event)" MaxLength="50" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtUGUni" placeholder="Enter University Name" TextMode="MultiLine"
                            Width="100%" runat="server" ValidationGroup="Reg" onkeypress="return charsonly(event)"
                            MaxLength="100" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="DrpUGYear" Width="80%" runat="server" ValidationGroup="Reg"
                            Font-Names="Cambria">
                            <asp:ListItem Value="0">Year</asp:ListItem>
                            <asp:ListItem Value="2022">2022</asp:ListItem>
                             <asp:ListItem Value="2021">2021</asp:ListItem>
                            <asp:ListItem Value="2020">2020</asp:ListItem>
                            <asp:ListItem Value="2019">2019</asp:ListItem>
                            <asp:ListItem Value="2018">2018</asp:ListItem>
                            <asp:ListItem Value="2017">2017</asp:ListItem>
                            <asp:ListItem Value="2016">2016</asp:ListItem>
                            <asp:ListItem Value="2015">2015</asp:ListItem>
                            <asp:ListItem Value="2014">2014</asp:ListItem>
                            <asp:ListItem Value="2013">2013</asp:ListItem>
                            <asp:ListItem Value="2012">2012</asp:ListItem>
                            <asp:ListItem Value="2011">2011</asp:ListItem>
                            <asp:ListItem Value="2010">2010</asp:ListItem>
                            <asp:ListItem Value="2009">2009</asp:ListItem>
                            <asp:ListItem Value="2008">2008</asp:ListItem>
                            <asp:ListItem Value="2007">2007</asp:ListItem>
                            <asp:ListItem Value="2006">2006</asp:ListItem>
                            <asp:ListItem Value="2005">2005</asp:ListItem>
                            <asp:ListItem Value="2004">2004</asp:ListItem>
                            <asp:ListItem Value="2003">2003</asp:ListItem>
                            <asp:ListItem Value="2002">2002</asp:ListItem>
                            <asp:ListItem Value="2001">2001</asp:ListItem>
                            <asp:ListItem Value="2000">2000</asp:ListItem>
                            <asp:ListItem Value="1999">1999</asp:ListItem>
                            <asp:ListItem Value="1998">1998</asp:ListItem>
                            <asp:ListItem Value="1997">1997</asp:ListItem>
                            <asp:ListItem Value="1996">1996</asp:ListItem>
                            <asp:ListItem Value="1995">1995</asp:ListItem>
                            <asp:ListItem Value="1994">1994</asp:ListItem>
                            <asp:ListItem Value="1993">1993</asp:ListItem>
                            <asp:ListItem Value="1992">1992</asp:ListItem>
                            <asp:ListItem Value="1991">1991</asp:ListItem>
                            <asp:ListItem Value="1990">1990</asp:ListItem>
                            <asp:ListItem Value="1989">1989</asp:ListItem>
                            <asp:ListItem Value="1988">1988</asp:ListItem>
                            <asp:ListItem Value="1987">1987</asp:ListItem>
                            <asp:ListItem Value="1986">1986</asp:ListItem>
                            <asp:ListItem Value="1985">1985</asp:ListItem>
                            <asp:ListItem Value="1984">1984</asp:ListItem>
                            <asp:ListItem Value="1983">1983</asp:ListItem>
                            <asp:ListItem Value="1982">1982</asp:ListItem>
                            <asp:ListItem Value="1981">1981</asp:ListItem>
                            <asp:ListItem Value="1980">1980</asp:ListItem>
                            <asp:ListItem Value="1979">1979</asp:ListItem>
                            <asp:ListItem Value="1978">1978</asp:ListItem>
                            <asp:ListItem Value="1977">1977</asp:ListItem>
                            <asp:ListItem Value="1976">1976</asp:ListItem>
                            <asp:ListItem Value="1975">1975</asp:ListItem>
                            <asp:ListItem Value="1974">1974</asp:ListItem>
                            <asp:ListItem Value="1973">1973</asp:ListItem>
                            <asp:ListItem Value="1972">1972</asp:ListItem>
                            <asp:ListItem Value="1971">1971</asp:ListItem>
                            <asp:ListItem Value="1970">1970</asp:ListItem>
                            <asp:ListItem Value="1969">1969</asp:ListItem>
                            <asp:ListItem Value="1968">1968</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="TxtUGMO" placeholder="MO" onkeypress="return numbersonly(event)"
                            Width="80%" runat="server" ValidationGroup="Reg" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="TxtUGMM" placeholder="MM" onkeypress="return numbersonly(event)"
                            Width="80%" runat="server" ValidationGroup="Reg" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="TxtUGPer" placeholder="00.00" onkeypress="return numAnddot(event)"
                            MaxLength="5" Width="80%" runat="server" ValidationGroup="Reg" CssClass="uppercase"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left">
                        Post Graduate
                    </td>
                    <td>
                        <asp:TextBox ID="TxtPG" placeholder="PG Course" Width="150px" runat="server" ValidationGroup="Reg"
                            onkeypress="return charsonly(event)" MaxLength="50" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtPGUni" placeholder="Enter University Name" TextMode="MultiLine"
                            Width="100%" runat="server" ValidationGroup="Reg" onkeypress="return charsonly(event)"
                            MaxLength="100" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="DrpPGYear" Width="80%" runat="server" ValidationGroup="Reg"
                            Font-Names="Cambria">
                            <asp:ListItem Value="0">Year</asp:ListItem>
                            <asp:ListItem Value="2022">2022</asp:ListItem>
                             <asp:ListItem Value="2021">2021</asp:ListItem>
                            <asp:ListItem Value="2020">2020</asp:ListItem>
                            <asp:ListItem Value="2019">2019</asp:ListItem>
                            <asp:ListItem Value="2018">2018</asp:ListItem>
                            <asp:ListItem Value="2017">2017</asp:ListItem>
                            <asp:ListItem Value="2016">2016</asp:ListItem>
                            <asp:ListItem Value="2015">2015</asp:ListItem>
                            <asp:ListItem Value="2014">2014</asp:ListItem>
                            <asp:ListItem Value="2013">2013</asp:ListItem>
                            <asp:ListItem Value="2012">2012</asp:ListItem>
                            <asp:ListItem Value="2011">2011</asp:ListItem>
                            <asp:ListItem Value="2010">2010</asp:ListItem>
                            <asp:ListItem Value="2009">2009</asp:ListItem>
                            <asp:ListItem Value="2008">2008</asp:ListItem>
                            <asp:ListItem Value="2007">2007</asp:ListItem>
                            <asp:ListItem Value="2006">2006</asp:ListItem>
                            <asp:ListItem Value="2005">2005</asp:ListItem>
                            <asp:ListItem Value="2004">2004</asp:ListItem>
                            <asp:ListItem Value="2003">2003</asp:ListItem>
                            <asp:ListItem Value="2002">2002</asp:ListItem>
                            <asp:ListItem Value="2001">2001</asp:ListItem>
                            <asp:ListItem Value="2000">2000</asp:ListItem>
                            <asp:ListItem Value="1999">1999</asp:ListItem>
                            <asp:ListItem Value="1998">1998</asp:ListItem>
                            <asp:ListItem Value="1997">1997</asp:ListItem>
                            <asp:ListItem Value="1996">1996</asp:ListItem>
                            <asp:ListItem Value="1995">1995</asp:ListItem>
                            <asp:ListItem Value="1994">1994</asp:ListItem>
                            <asp:ListItem Value="1993">1993</asp:ListItem>
                            <asp:ListItem Value="1992">1992</asp:ListItem>
                            <asp:ListItem Value="1991">1991</asp:ListItem>
                            <asp:ListItem Value="1990">1990</asp:ListItem>
                            <asp:ListItem Value="1989">1989</asp:ListItem>
                            <asp:ListItem Value="1988">1988</asp:ListItem>
                            <asp:ListItem Value="1987">1987</asp:ListItem>
                            <asp:ListItem Value="1986">1986</asp:ListItem>
                            <asp:ListItem Value="1985">1985</asp:ListItem>
                            <asp:ListItem Value="1984">1984</asp:ListItem>
                            <asp:ListItem Value="1983">1983</asp:ListItem>
                            <asp:ListItem Value="1982">1982</asp:ListItem>
                            <asp:ListItem Value="1981">1981</asp:ListItem>
                            <asp:ListItem Value="1980">1980</asp:ListItem>
                            <asp:ListItem Value="1979">1979</asp:ListItem>
                            <asp:ListItem Value="1978">1978</asp:ListItem>
                            <asp:ListItem Value="1977">1977</asp:ListItem>
                            <asp:ListItem Value="1976">1976</asp:ListItem>
                            <asp:ListItem Value="1975">1975</asp:ListItem>
                            <asp:ListItem Value="1974">1974</asp:ListItem>
                            <asp:ListItem Value="1973">1973</asp:ListItem>
                            <asp:ListItem Value="1972">1972</asp:ListItem>
                            <asp:ListItem Value="1971">1971</asp:ListItem>
                            <asp:ListItem Value="1970">1970</asp:ListItem>
                            <asp:ListItem Value="1969">1969</asp:ListItem>
                            <asp:ListItem Value="1968">1968</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="TxtPGMO" placeholder="MO" onkeypress="return numbersonly(event)"
                            Width="80%" runat="server" ValidationGroup="Reg" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="TxtPGMM" placeholder="MM" onkeypress="return numbersonly(event)"
                            Width="80%" runat="server" ValidationGroup="Reg" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="TxtPGPer" placeholder="00.00" Width="80%" runat="server" onkeypress="return numAnddot(event)"
                            MaxLength="5" ValidationGroup="Reg" CssClass="uppercase"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left">
                        Other's
                    </td>
                    <td>
                        <asp:TextBox ID="TxtOTH" placeholder="Other Course" Width="150px" runat="server"
                            onkeypress="return charsonly(event)" ValidationGroup="Reg" MaxLength="50" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtOUni" placeholder="Enter University Name" Width="100%" runat="server"
                            ValidationGroup="Reg" onkeypress="return charsonly(event)" TextMode="MultiLine"
                            MaxLength="100" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:DropDownList ID="DrpOYear" Width="80%" runat="server" ValidationGroup="Reg"
                            Font-Names="Cambria">
                            <asp:ListItem Value="0">Year</asp:ListItem>
                            <asp:ListItem Value="2022">2022</asp:ListItem>
                             <asp:ListItem Value="2021">2021</asp:ListItem>
                            <asp:ListItem Value="2020">2020</asp:ListItem>
                            <asp:ListItem Value="2019">2019</asp:ListItem>
                            <asp:ListItem Value="2018">2018</asp:ListItem>
                            <asp:ListItem Value="2017">2017</asp:ListItem>
                            <asp:ListItem Value="2016">2016</asp:ListItem>
                            <asp:ListItem Value="2015">2015</asp:ListItem>
                            <asp:ListItem Value="2014">2014</asp:ListItem>
                            <asp:ListItem Value="2013">2013</asp:ListItem>
                            <asp:ListItem Value="2012">2012</asp:ListItem>
                            <asp:ListItem Value="2011">2011</asp:ListItem>
                            <asp:ListItem Value="2010">2010</asp:ListItem>
                            <asp:ListItem Value="2009">2009</asp:ListItem>
                            <asp:ListItem Value="2008">2008</asp:ListItem>
                            <asp:ListItem Value="2007">2007</asp:ListItem>
                            <asp:ListItem Value="2006">2006</asp:ListItem>
                            <asp:ListItem Value="2005">2005</asp:ListItem>
                            <asp:ListItem Value="2004">2004</asp:ListItem>
                            <asp:ListItem Value="2003">2003</asp:ListItem>
                            <asp:ListItem Value="2002">2002</asp:ListItem>
                            <asp:ListItem Value="2001">2001</asp:ListItem>
                            <asp:ListItem Value="2000">2000</asp:ListItem>
                            <asp:ListItem Value="1999">1999</asp:ListItem>
                            <asp:ListItem Value="1998">1998</asp:ListItem>
                            <asp:ListItem Value="1997">1997</asp:ListItem>
                            <asp:ListItem Value="1996">1996</asp:ListItem>
                            <asp:ListItem Value="1995">1995</asp:ListItem>
                            <asp:ListItem Value="1994">1994</asp:ListItem>
                            <asp:ListItem Value="1993">1993</asp:ListItem>
                            <asp:ListItem Value="1992">1992</asp:ListItem>
                            <asp:ListItem Value="1991">1991</asp:ListItem>
                            <asp:ListItem Value="1990">1990</asp:ListItem>
                            <asp:ListItem Value="1989">1989</asp:ListItem>
                            <asp:ListItem Value="1988">1988</asp:ListItem>
                            <asp:ListItem Value="1987">1987</asp:ListItem>
                            <asp:ListItem Value="1986">1986</asp:ListItem>
                            <asp:ListItem Value="1985">1985</asp:ListItem>
                            <asp:ListItem Value="1984">1984</asp:ListItem>
                            <asp:ListItem Value="1983">1983</asp:ListItem>
                            <asp:ListItem Value="1982">1982</asp:ListItem>
                            <asp:ListItem Value="1981">1981</asp:ListItem>
                            <asp:ListItem Value="1980">1980</asp:ListItem>
                            <asp:ListItem Value="1979">1979</asp:ListItem>
                            <asp:ListItem Value="1978">1978</asp:ListItem>
                            <asp:ListItem Value="1977">1977</asp:ListItem>
                            <asp:ListItem Value="1976">1976</asp:ListItem>
                            <asp:ListItem Value="1975">1975</asp:ListItem>
                            <asp:ListItem Value="1974">1974</asp:ListItem>
                            <asp:ListItem Value="1973">1973</asp:ListItem>
                            <asp:ListItem Value="1972">1972</asp:ListItem>
                            <asp:ListItem Value="1971">1971</asp:ListItem>
                            <asp:ListItem Value="1970">1970</asp:ListItem>
                            <asp:ListItem Value="1969">1969</asp:ListItem>
                            <asp:ListItem Value="1968">1968</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="TxtOMO" placeholder="MO" onkeypress="return numbersonly(event)"
                            Width="80%" runat="server" ValidationGroup="Reg" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="TxtOMM" placeholder="MM" onkeypress="return numbersonly(event)"
                            Width="80%" runat="server" ValidationGroup="Reg" MaxLength="4" CssClass="uppercase"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="TxtOPer" placeholder="00.00" Width="80%" runat="server" onkeypress="return numAnddot(event)"
                            MaxLength="5" ValidationGroup="Reg" CssClass="uppercase"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" colspan="5" valign="middle">
                        <asp:Label ID="Lblcomplesary" ForeColor="#0000FF" runat="server" Text=""></asp:Label><span
                            style="color: #FF0000">*</span>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="Drpcomp" ValidationGroup="Reg" Width="100%" Font-Names="Cambria"
                            runat="server">
                            <asp:ListItem Value="0">Select One</asp:ListItem>
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" colspan="5" valign="middle">
                        High School Pass ?<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="Drphpass" ValidationGroup="Reg" Width="100%" Font-Names="Cambria"
                            runat="server">
                            <asp:ListItem Value="0">Select One</asp:ListItem>
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" colspan="5" valign="middle">
                        High School Area Type<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="Drpharea" ValidationGroup="Reg" Width="100%" Font-Names="Cambria"
                            runat="server">
                            <asp:ListItem Value="0">Select One</asp:ListItem>
                            <asp:ListItem Value="U">Urban</asp:ListItem>
                            <asp:ListItem Value="R">Rural</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" colspan="5" valign="middle">
                        Intermediate Pass ?<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="Drpipass" ValidationGroup="Reg" Width="100%" Font-Names="Cambria"
                            runat="server">
                            <asp:ListItem Value="0">Select One</asp:ListItem>
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" colspan="5" valign="middle">
                        I.T.I Pass Or Not ?<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="Drpitipass" ValidationGroup="Reg" Width="100%" Font-Names="Cambria"
                            runat="server">
                            <asp:ListItem Value="0">Select One</asp:ListItem>
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="caption" align="left" valign="middle" style="height: 50px">
                        <asp:Button ID="Button1" runat="server" Text="Continue" CssClass="btn" ValidationGroup="Reg"
                            Font-Bold="True" Font-Size="15px" Width="100px" OnClick="Button1_Click" />
                    </td>
                    <td align="left" colspan="8">
                        <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" ValidationGroup="Reg"
        ShowMessageBox="true" runat="server" />
    <asp:RequiredFieldValidator ID="RFV10Board" Display="None" ValidationGroup="Reg"
        ControlToValidate="Txt10Board" runat="server" ErrorMessage="Please Enter 10th Board Name !"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CV10Year" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please Select 10th Passing Year." ControlToValidate="Drp10Year"
        ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
    <asp:RequiredFieldValidator ID="RFV10Per" Display="None" ValidationGroup="Reg" ControlToValidate="Txt10Per"
        runat="server" ErrorMessage="Please Enter 10th Percentage/Grade/Points."></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="Cvhpass" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please Select High School Pass ?" ControlToValidate="Drphpass"
        ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
          <asp:CompareValidator ID="Cvharea" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please Select High School Area Type." ControlToValidate="Drpharea"
        ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
         <asp:CompareValidator ID="Cvipass" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please Select Intermediate Pass ?" ControlToValidate="Drpipass"
        ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
           <asp:CompareValidator ID="Cvitipass" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please Select I.T.I Pass Or Not ?" ControlToValidate="Drpitipass"
        ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
</asp:Content>
