<%@ Page Title="Filmoverzicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieView.aspx.cs" Inherits="IMDb_Applicatie.MovieView" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <div class="col-md-8">
                <div class="form-group">
                    <div class="col-md-10">

                        <asp:DropDownList ID="ddlMovies"
                            AutoPostBack="True"
                            CssClass="form-control"
                            OnSelectedIndexChanged="ddlMovies_Selection_Change"
                            runat="server">
                        </asp:DropDownList>
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
                        <asp:ListBox ID="lbCast" SelectionMode="Single" CssClass="form-control" ToolTip="De cast van de film." AutoPostBack="True" runat="server" OnSelectedIndexChanged="lbCast_SelectedIndexChanged"></asp:ListBox>
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
                <div class="form-group">
                    <div class="col-md-10">
                        <asp:TextBox ID="tbRecensie" runat="server" CssClass="form-control" Placeholder="Plaats hier uw recensie" Visible="False"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnPostRecensie" runat="server" Text="Recensie toevoegen" CssClass="btn btn-primary" Width="280px" OnClick="btnPostRecensie_OnClick" Visible="False" />
                        <br />
                        <asp:Label ID="lblError" runat="server" Text="Het was helaas niet mogelijk de recensie toe te voegen, probeer opnieuw." Visible="False" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
