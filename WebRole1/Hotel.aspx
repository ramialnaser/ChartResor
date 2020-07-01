<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hotel.aspx.cs" Inherits="WebRole1.Hotel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <html>

<body>
   
        <div style="height: 407px">
    
   <h1>Please Enter Your Information</h1>
            <br/>
             <asp:CheckBox ID="CheckBox1" runat="server" text="Rent a car"/>
            <br/>

            <asp:Label ID="Label1" runat="server" Text="Traveller: "></asp:Label> 
     <br />
            <asp:Textbox ID="travellers" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    <br />
             <asp:Label ID="Label3" runat="server" Text="Night: "></asp:Label> 
     <br />
            <asp:Textbox ID="nights" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
           
    <br />
             <asp:Label ID="Label4" runat="server" Text="Senior: "></asp:Label> 
     <br />
            <asp:Textbox ID="senior" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    <br />
             <asp:Label ID="Label5" runat="server" Text="Name: "></asp:Label> 
     <br />
            <asp:Textbox ID="name" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
     <br />
             <asp:Label ID="Label6" runat="server" Text="Type Single/Double: "></asp:Label> 
     <br />
            <asp:Textbox ID="type" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    
    <br />
   <asp:Button ID="Button1" runat="server" Text="Continue" Width="70px" Height="35px" OnClick="BtnPost_Click" style="margin-top: 0px"></asp:Button>
   
   <asp:Button ID="Button2" runat="server" Text="Cancel" Width="70px" Height="35px" OnClick="cancel" style="margin-top: 0px"></asp:Button>
     <br />
    
   
</div>
    
</body>
</html>

</asp:Content>
