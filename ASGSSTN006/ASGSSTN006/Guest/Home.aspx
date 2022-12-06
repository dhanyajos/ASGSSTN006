<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ASGSSTN006.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="margin-left: 300px; margin-top: 150px;">

                <tr>
                    <td width="200">
                        <asp:Label ID="Label1" runat="server" Text="Department"></asp:Label>
                    </td>
                    <td width="200">
                        <asp:DropDownList ID="ddldept" runat="server" Width="162px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Designation"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Add" Width="107px" OnClick="Button1_Click" />
                    </td>

                </tr>
            </table>
            <br />
            <h3 style="margin-left: 300px;">Designation Details</h3><br />
            <asp:GridView ID="GridView1" runat="server" style="margin-left: 300px;" Width="634px" AutoGenerateColumns="False" DataKeyNames="desigId" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                    <input type="checkbox" runat="server" name="ch"  id="ch" value='<%#Eval("desigId")%>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="dept_name" HeaderText="Department" />
                    <asp:BoundField DataField="desigName" HeaderText="Designation" />
                    <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                    <asp:HyperLinkField DataNavigateUrlFields="desigId" DataNavigateUrlFormatString="test.aspx?desigId={0}" HeaderText="Viewmore" Text="Go" />


                </Columns>
            </asp:GridView><br />
                 <asp:Button ID="Button2" runat="server" Text="DeleteAll" OnClick="Button2_Click" style="margin-left: 449px" Width="183px" />
        </div>
    </form>
</body>
</html>
