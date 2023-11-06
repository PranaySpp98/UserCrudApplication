<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication14.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html
xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>


    <form id="form1" runat="server">
        <div>
            <h1>User Registration Form</h1>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Enter Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDesignation" runat="server" Text="Enter Designation"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSkills" runat="server" Text="Enter Skills"></asp:Label>
                    </td>
                    <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                            <asp:ListItem Value="" text="-Select-"/>
                            <asp:ListItem>C#</asp:ListItem>
                            <asp:ListItem>MVC</asp:ListItem>    
                            <asp:ListItem>Java States</asp:ListItem>
                            <asp:ListItem>Azure</asp:ListItem>
                            <asp:ListItem>SQL</asp:ListItem>
                            <asp:ListItem>Angular</asp:ListItem>
                            </asp:DropDownList> 
                    </td>
                    <td>
                        <asp:TextBox ID="txtSkills" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDob" runat="server" Text="Enter Date of Birth"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdtp" runat="server"></asp:TextBox>
                        <asp:LinkButton ID="linkpickdate" runat="server" OnClick="linkpickdate_Click">Get Date</asp:LinkButton>
                        <asp:Calendar ID="datepicker" runat="server" Visible="false" OnSelectionChanged="datepicker_SelectionChanged"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvDisplay" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="10"
                            OnRowCommand="gvDisplay_RowCommand" OnRowDeleting="gvDisplay_RowDeleting"
                            OnSelectedIndexChanging="gvDisplay_SelectedIndexChanging"
                            OnPageIndexChanging="gvDisplay_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Designation" HeaderText="Designation" />
                                <asp:BoundField DataField="Skills" HeaderText="Skills" />
                                <asp:BoundField DataField="DOB" HeaderText="Date of Birth" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:CommandField ButtonType="Button" SelectText="Edit" ShowSelectButton="True" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnDelete" OnClientClick="return confirm('Are you sure,you want to delete this record ?');" Text="Delete" CommandArgument='  
                                                <%# Eval("Id") %>'
                                            CommandName="Delete" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
