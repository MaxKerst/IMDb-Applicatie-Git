<%@ Page Title="Filmoverzicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMovie.aspx.cs" Inherits="IMDb_Applicatie.ViewMovie" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
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
                    <asp:Label ID="tbMovieName" runat="server" Text="" CssClass="form-control" ToolTip="De naam van de film."></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblDescrip" runat="server" Text="Beschrijving:"></asp:Label>
                    <textarea id="tbDescription" cols="20" rows="2" runat="server" class="form-control MultiLineTextBox" readonly></textarea>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblGenre" runat="server" Text="Genre:"></asp:Label>
                    <asp:HyperLink ID="hyperGenre" runat="server" CssClass="form-control" ToolTip="Het genre van de film"></asp:HyperLink>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblRating" runat="server" Text="Rating:"></asp:Label>
                    <asp:Label ID="tbRating" runat="server" Text="" CssClass="form-control" ToolTip="De naam van de film."></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblRegisseur" runat="server" CssClass="textbox">Regisseur:</asp:Label>
                    <asp:HyperLink ID="hyperRegisseur" runat="server" CssClass="form-control" ToolTip="De regisseur van de film"></asp:HyperLink>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblCast" runat="server" Text="Cast:"></asp:Label>
                    <br />
                    <asp:ListBox ID="lbCast" SelectionMode="Single" CssClass="form-control" ToolTip="De cast van de film." AutoPostBack="True" OnSelectedIndexChanged="lbCast_OnSelectedIndexChanged" runat="server"></asp:ListBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblPrijzen" runat="server" Text="Prijzen:"></asp:Label>
                    <br />
                    <asp:ListBox ID="lbPrizes" SelectionMode="Single" CssClass="form-control" ToolTip="De prijzen van de film." EnableViewState="False" runat="server"></asp:ListBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblRecensies" runat="server" Text="Recensies:"></asp:Label>
                    <br />
                    <asp:ListBox ID="lbRecensies" SelectionMode="Single" CssClass="form-control" ToolTip="De prijzen van de film." EnableViewState="False" runat="server"></asp:ListBox>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
