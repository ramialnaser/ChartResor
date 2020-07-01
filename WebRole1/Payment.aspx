<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="WebRole1.Payment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

     <br />
            <asp:Label ID="Label1" runat="server" Text="Price: "></asp:Label> 
     <br />
            <asp:Textbox ID="price" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    <br />
        <asp:Button ID="Search" runat="server" Text="Sum" Width="70px" Height="35px" OnClick="BtnGet_Click" style="margin-top: 0px"></asp:Button>

</asp:Content>
