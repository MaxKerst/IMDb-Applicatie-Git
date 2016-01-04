<%@ Page Title="Administratie paneel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="IMDb_Applicatie.AdminPanel" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <div class="col-md-10">
                <asp:RadioButtonList runat="server" ID="rblEditNew" OnSelectedIndexChanged="rblEditNew_Index_Changed" AutoPostBack="true">
                    <asp:ListItem>Nieuwe film toevoegen</asp:ListItem>
                    <asp:ListItem>Bestaande film bewerken</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-md-8">
                <div class="form-group">
                        <asp:Label ID="lblFilmSelect" runat="server" Text="Selecteer uw film:"></asp:Label>

                        <asp:DropDownList ID="ddlMovies"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="ddlMovies_Selection_Change"
                            runat="server">

                            <asp:ListItem Value="White"> White </asp:ListItem>
                            <asp:ListItem Value="Silver"> Silver </asp:ListItem>
                            <asp:ListItem Value="Silver"> Siilver </asp:ListItem>
                            <asp:ListItem Value="DarkGray"> Dark Gray </asp:ListItem>
                            <asp:ListItem Value="Khaki"> Khaki </asp:ListItem>
                            <asp:ListItem Value="DarkKhaki"> Dark Khaki </asp:ListItem>

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
                    <asp:TextBox runat="server" ID="tbMovieName" CssClass="form-control textbox-register " TextMode="SingleLine" ToolTip="De naam van de film" EnableViewState="False" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblDescrip" runat="server" Text="Beschrijving:"></asp:Label>
                    <asp:TextBox runat="server" ID="tbDescription" CssClass="form-control textbox-register MultiLineTextBox" TextMode="MultiLine" ToolTip="De beschrijving van de film" EnableViewState="False" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblGenre" runat="server" Text="Genre:"></asp:Label>
                    <asp:TextBox runat="server" ID="tbGenre" CssClass="form-control textbox-register" TextMode="SingleLine" ToolTip="Het genre van de film" EnableViewState="False" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblRating" runat="server" Text="Rating:"></asp:Label>
                    <asp:TextBox runat="server" ID="tbRating" CssClass="form-control textbox-register" TextMode="SingleLine" ToolTip="De rating van de film" EnableViewState="False" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblRegisseur" runat="server" Text="Regisseur(s):"></asp:Label>
                    <br />
                    <asp:ListBox ID="lbRegisseurs" SelectionMode="Single" CssClass="form-group" ToolTip="De reggisseurs van de film." EnableViewState="False" runat="server">
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
                    <asp:DropDownList ID="ddlRegisseurs"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="ddlMovies_Selection_Change"
                        runat="server">

                        <asp:ListItem Value="White"> White </asp:ListItem>
                        <asp:ListItem Value="Silver"> Silver </asp:ListItem>
                        <asp:ListItem Value="Silver"> Siilver </asp:ListItem>
                        <asp:ListItem Value="DarkGray"> Dark Gray </asp:ListItem>
                        <asp:ListItem Value="Khaki"> Khaki </asp:ListItem>
                        <asp:ListItem Value="DarkKhaki"> Dark Khaki </asp:ListItem>

                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-10">
                    <asp:Button ID="btnAddRegisseur" runat="server" Text="Regisseur toevoegen" CssClass="btn btn-default" />
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
                    <asp:DropDownList ID="ddlActeurs"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="ddlMovies_Selection_Change"
                        runat="server">

                        <asp:ListItem Value="White"> White </asp:ListItem>
                        <asp:ListItem Value="Silver"> Silver </asp:ListItem>
                        <asp:ListItem Value="Silver"> Siilver </asp:ListItem>
                        <asp:ListItem Value="DarkGray"> Dark Gray </asp:ListItem>
                        <asp:ListItem Value="Khaki"> Khaki </asp:ListItem>
                        <asp:ListItem Value="DarkKhaki"> Dark Khaki </asp:ListItem>

                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-10">
                    <asp:Button ID="btnAddActeur" runat="server" Text="Acteur toevoegen" CssClass="btn btn-default" />
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
                    <asp:DropDownList ID="ddlPrizes"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="ddlMovies_Selection_Change"
                        runat="server">

                        <asp:ListItem Value="White"> White </asp:ListItem>
                        <asp:ListItem Value="Silver"> Silver </asp:ListItem>
                        <asp:ListItem Value="Silver"> Siilver </asp:ListItem>
                        <asp:ListItem Value="DarkGray"> Dark Gray </asp:ListItem>
                        <asp:ListItem Value="Khaki"> Khaki </asp:ListItem>
                        <asp:ListItem Value="DarkKhaki"> Dark Khaki </asp:ListItem>

                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-10">
                    <asp:Button ID="btnAddPrize" runat="server" Text="Prijs toevoegen" CssClass="btn btn-default" />
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

                <div class="col-md-10">
                    <asp:Button ID="btnDeleteRecensie" runat="server" Text="Recensie verwijderen" CssClass="btn btn-default" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-10">
                    <asp:Button ID="btnSave" runat="server" Text="Opslaan" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
