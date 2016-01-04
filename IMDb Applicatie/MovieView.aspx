<%@ Page Title="Filmoverzicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieView.aspx.cs" Inherits="IMDb_Applicatie.MovieView" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <div class="col-md-8">
                <div class="form-group">
                    <div class="col-md-10">
                        <asp:Button ID="btnLogOut" runat="server" Text="Uitloggen" OnClick="btnLogOut_OnClick" />
                        <asp:DropDownList ID="ddlMovies"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="ddlMovies_Selection_Change"
                            runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <%--
                Filmnaam
                Beschrijving
                Genre
                Rating
                ListRegisseurs
                ListCast
                ListPrijzen
                ListRecensies
            --%>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblFilm" runat="server" Text="Film:"></asp:Label>
                    <asp:TextBox runat="server" ID="tbMovieName" CssClass="form-control textbox-register " TextMode="SingleLine" ToolTip="De naam van de film" EnableViewState="False" ReadOnly="True" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblDescrip" runat="server" Text="Beschrijving:"></asp:Label>
                    <asp:TextBox runat="server" ID="tbDescription" CssClass="form-control textbox-register MultiLineTextBox" TextMode="MultiLine" ToolTip="De beschrijving van de film" EnableViewState="False" ReadOnly="True" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblGenre" runat="server" Text="Genre:"></asp:Label>
                    <asp:TextBox runat="server" ID="tbGenre" CssClass="form-control textbox-register" TextMode="SingleLine" ToolTip="Het genre van de film" EnableViewState="False" ReadOnly="True" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblRating" runat="server" Text="Rating:"></asp:Label>
                    <asp:TextBox runat="server" ID="tbRating" CssClass="form-control textbox-register" TextMode="SingleLine" ToolTip="De rating van de film" EnableViewState="False" ReadOnly="True" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tbRegisseur" CssClass="form-control textbox-register" TextMode="SingleLine" ToolTip="De regisseur van de film" EnableViewState="False" ReadOnly="True" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblCast" runat="server" Text="Cast:"></asp:Label>
                    <br />
                    <asp:ListBox ID="lbCast" SelectionMode="Single" CssClass="form-group" ToolTip="De cast van de film." EnableViewState="False" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                        <asp:ListItem>Item 3</asp:ListItem>
                        <asp:ListItem>Item 4</asp:ListItem>
                        <asp:ListItem>Item 5</asp:ListItem>
                        <asp:ListItem>Item 6</asp:ListItem>
                    </asp:ListBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblPrijzen" runat="server" Text="Prijzen:"></asp:Label>
                    <br />
                    <asp:ListBox ID="lbPrizes" SelectionMode="Single" CssClass="form-group" ToolTip="De prijzen van de film." EnableViewState="False" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                        <asp:ListItem>Item 3</asp:ListItem>
                        <asp:ListItem>Item 4</asp:ListItem>
                        <asp:ListItem>Item 5</asp:ListItem>
                        <asp:ListItem>Item 6</asp:ListItem>
                    </asp:ListBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblRecensies" runat="server" Text="Recensies:"></asp:Label>
                    <br />
                    <asp:ListBox ID="lbRecensies" SelectionMode="Single" CssClass="form-group" ToolTip="De prijzen van de film." EnableViewState="False" runat="server">
                        <asp:ListItem>Item 1</asp:ListItem>
                        <asp:ListItem>Item 2</asp:ListItem>
                        <asp:ListItem>Item 3</asp:ListItem>
                        <asp:ListItem>Item 4</asp:ListItem>
                        <asp:ListItem>Item 5</asp:ListItem>
                        <asp:ListItem>Item 6</asp:ListItem>
                    </asp:ListBox>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
