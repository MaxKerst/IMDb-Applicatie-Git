<%@ Page Title="Inloggen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IMDb_Applicatie.Account.Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <hr />
                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbName" Placeholder="Gebruikersnaam" CssClass="form-control textbox" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbName"
                                CssClass="text-danger" ErrorMessage="Gebruikersnaam moet worden ingevuld." Display="Dynamic" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbPassword" Placeholder="Wachtwoord" TextMode="Password" CssClass="form-control textbox" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPassword" CssClass="text-danger" ErrorMessage="Het wachtwoord
                                 moet worden ingevuld."
                                Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Inloggen" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
                <asp:Label ID="ErrorTextBox" runat="server" Visible="false" CssClass="has-error has-feedback" ForeColor="red">Gebruikersnaam of wachtwoord is onjuist! Probeer opnieuw!</asp:Label>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Nog geen account? Klik hier om u te registreren</asp:HyperLink>
                </p>
            </section>
        </div>
    </div>
</asp:Content>
