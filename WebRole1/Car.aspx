<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Car.aspx.cs" Inherits="WebRole1.Car" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Please Enter Your Information</h1>

            <asp:Label ID="Label1" runat="server" Text="Passengers: "></asp:Label> 
     <br />
            <asp:Textbox ID="Passenger" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    <br />
             <asp:Label ID="Label3" runat="server" Text="Model(Year): "></asp:Label> 
     <br />
            <asp:Textbox ID="Model" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    <br />
             <asp:Label ID="Label4" runat="server" Text="Driver Age: "></asp:Label> 
     <br />
            <asp:Textbox ID="DriverAge" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    <br/>
             <asp:Label ID="Label2" runat="server" Text="Diesel/Benzene: "></asp:Label> 
     <br/>
            <asp:Textbox ID="DB" runat="server" Text="0" Width="189px" Height="23px"></asp:Textbox>
    <br/>
   
  <br />
   <asp:Button ID="Button1" runat="server" Text="Continue" Width="70px" Height="35px" OnClick="BtnPost_Click" style="margin-top: 0px"></asp:Button>
    
   <asp:Button ID="Button2" runat="server" Text="Cancel" Width="70px" Height="35px" OnClick="cancel" style="margin-top: 0px"></asp:Button>
     <br />
</asp:Content>

