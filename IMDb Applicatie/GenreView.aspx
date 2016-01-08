<%@ Page Title="Genreoverzicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenreView.aspx.cs" Inherits="IMDb_Applicatie.GenreView" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <div class="col-md-8">
                <div class="form-group">
                    <div class="col-md-10">
                        <asp:DropDownList ID="ddlGenres"
                            AutoPostBack="True"
                            CssClass="form-control"
                            OnSelectedIndexChanged="ddlGenres_Selection_Change"
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
                    <asp:Label ID="lblFilms" runat="server" Text="Films:"></asp:Label>
                    <br />
                    <asp:ListBox ID="lbFilms" SelectionMode="Single" CssClass="form-control" ToolTip="De films bij het geselecteerde genre." AutoPostBack="True" runat="server" OnSelectedIndexChanged="lbFilms_SelectedIndexChanged">
                    </asp:ListBox>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

