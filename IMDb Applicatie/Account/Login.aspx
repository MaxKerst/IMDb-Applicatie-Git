<%@ Page Title="Inloggen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IMDb_Applicatie.Account.Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tbEmail" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control textbox" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbEmail"
                                CssClass="text-danger" ErrorMessage="Het email veld moet worden ingevuld." Display="Dynamic"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tbPassword" CssClass="col-md-2 control-label">Wachtwoord</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" CssClass="form-control textbox" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPassword" CssClass="text-danger" ErrorMessage="Het wachtwoord
                                 veld moet worden ingevuld." Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Inloggen" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Nog geen account? Klik hier om u te registreren</asp:HyperLink>
                </p>
            </section>
        </div>
    </div>
</asp:Content>
