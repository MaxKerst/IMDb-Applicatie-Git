<%@ Page Title="Registreren" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="IMDb_Applicatie.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <hr />
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbNaam" CssClass="col-md-2 control-label">Naam</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbNaam" CssClass="form-control textbox-register" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNaam"
                    CssClass="text-danger" ErrorMessage="Het naam veld is verplicht." Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbPassword" CssClass="col-md-2 control-label">Wachtwoord</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" CssClass="form-control textbox-register" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPassword"
                    CssClass="text-danger" ErrorMessage="Het wachtwoord veld is verplicht." Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbConfirmPassword" CssClass="col-md-2 control-label">Wachtwoord herhalen</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbConfirmPassword" TextMode="Password" CssClass="form-control textbox-register" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Het wachtwoord herhaal veld is verplicht." />
                <asp:CompareValidator runat="server" ControlToCompare="tbPassword" ControlToValidate="tbConfirmPassword"
                    CssClass="text-danger" ErrorMessage="De wachtwoorden komen niet overeen." Display="Dynamic" />
            </div>
        </div>
        <asp:Label ID="lblError" runat="server" Text="Er is een error opgetreden tijdens het maken van de account, probeer het opnieuw." CssClass="text-danger" Visible="False"></asp:Label>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Registreren" CssClass="btn btn-default" onclick="RegisterButton_Click"/>
            </div>
        </div>
    </div>
</asp:Content>