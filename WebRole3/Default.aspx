<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebRole1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<html>

<body>
   
        <div style="height: 407px">
    
   <h1>Please Select Your Flight Information</h1>

   
    <asp:DropDownList ID="From" runat="server" AutoPostBack ="True" Width="100px" Height="45px" >
        <asp:ListItem Text ="From" Value = ""></asp:ListItem>
        <asp:ListItem Text ="CPH" Value ="CPH"></asp:ListItem>
        <asp:ListItem Text ="DXB" Value ="DXB"></asp:ListItem>
        </asp:DropDownList>
      <asp:DropDownList ID="To" runat="server" AutoPostBack ="true" Width="100px" Height="45px" >
        <asp:ListItem Text ="To" Value = ""></asp:ListItem>
        <asp:ListItem Text ="DXB" Value ="DXB"></asp:ListItem>
        <asp:ListItem Text ="CPH" Value ="CPH"></asp:ListItem>
        </asp:DropDownList>
     
    <br />
            <asp:Label ID="Label1" runat="server" Text="Adult: "></asp:Label> 
     <br />
            <asp:Textbox ID="Textbox1" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    <br />
             <asp:Label ID="Label3" runat="server" Text="Student: "></asp:Label> 
     <br />
            <asp:Textbox ID="Textbox2" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    <br />
             <asp:Label ID="Label4" runat="server" Text="Infant: "></asp:Label> 
     <br />
            <asp:Textbox ID="Textbox3" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    <br />
             <asp:Label ID="Label5" runat="server" Text="Child: "></asp:Label> 
     <br />
            <asp:Textbox ID="Textbox4" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    
    <br />
    <asp:Button ID="Search" runat="server" Text="Search" Width="70px" Height="35px" OnClick="BtnGet_Click" style="margin-top: 0px"></asp:Button>
   
    <br />
   <asp:Label ID="Label2" runat="server" Text="Price: "></asp:Label> 
     <br />
    <asp:Textbox ID="Textbox5" runat="server" Text="" Width="192px" Height="23px"></asp:Textbox>
    
   
</div>
    
</body>
</html>
        
</asp:Content>
