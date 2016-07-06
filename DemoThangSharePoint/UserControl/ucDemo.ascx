<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDemo.ascx.cs" Inherits="DemoThangSharePoint.ucDemo" %>
<%@ Register Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" Namespace="Microsoft.SharePoint.WebControls" TagPrefix="cc1" %>
<style type="text/css">
    .auto-style1 {
        width: 103px;
    }
    .auto-style2 {
        width: 133px;
    }
    .auto-style3 {
        width: 182px;
    }
    .auto-style4 {
        width: 146px;
    }
    .auto-style5 {
        width: 103px;
        height: 23px;
    }
    .auto-style6 {
        width: 133px;
        height: 23px;
    }
    .auto-style7 {
        width: 146px;
        height: 23px;
    }
    .auto-style8 {
        width: 182px;
        height: 23px;
    }
    #Nhap {
        width: 723px;
    }
    #Button1 {
        width: 119px;
    }
</style>
<asp:Panel ID="Panel1" runat="server">  
    <asp:Label ID="Label2" runat="server" Text="Upload File"></asp:Label>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Load to List " onclick="UploadFile" />
    
    <br />
    <asp:Label ID="Label1" runat="server" Text="Status:"></asp:Label>
</asp:Panel>
          <br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
  
    <Columns>
      <asp:BoundField HeaderText="Mã bộ , Ngành" DataField="MaBoNganh" />
        <asp:BoundField HeaderText="Tên bộ , Ngành" DataField="TenBoNganh" />
         <asp:BoundField HeaderText="Căn Cứ" DataField="CanCu" />
         <asp:BoundField HeaderText="Ngày có hiệu lực" DataField="HieuLucTuNgay" />
         <asp:BoundField HeaderText="Ngày hết hiệu lực" DataField="NgayHetHieuLuc" />
    </Columns>

</asp:GridView>
  <br />
    <asp:Button ID="Button1" runat="server" Text="Export File " onclick="SaveToExcel"/>



