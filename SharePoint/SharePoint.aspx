<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SharePoint.aspx.cs" Inherits="SharePoint.SharePoint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello everyBody </title>
</head>
    
<body style="height: 530px">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button5" runat="server" Text="Sinhvien" OnClick="Button5_Click" />
            <asp:Button ID="Button6" runat="server" Text="Monhoc" OnClick="Button6_Click" />
            <asp:Button ID="Button7" runat="server" Text="Diem" OnClick="Button7_Click" />
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Edit" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Selected" />
        </p>

       
        <asp:ListBox ID="ListBox2" runat="server" Height="250px" Width="495px" style="margin-right: 64px" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged"></asp:ListBox>

       
        <p>
            Quan ly sinh vien Dai Hoc Cong Nghe
        </p>

       
    </form>
</body>
</html>
