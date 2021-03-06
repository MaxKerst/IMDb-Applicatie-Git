﻿<%@ Page Title="Acteuroverzicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActeurView.aspx.cs" Inherits="IMDb_Applicatie.ActeurView" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <div class="col-md-8">
                <div class="form-group">
                    <div class="col-md-10">
                        <asp:DropDownList ID="ddlActeurs"
                            AutoPostBack="True"
                            CssClass="form-control"
                            OnSelectedIndexChanged="ddlActeurs_Selection_Change"
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
                        <asp:Label ID="lblGeboortedatum" runat="server" Text="">Geboortedatum:</asp:Label>
                        <br />
                        <asp:Label ID="lblDob" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-10">
                        <asp:Label ID="lblWoonplekWoonplek" runat="server" Text="">Woonplek:</asp:Label>
                        <br />
                        <asp:Label ID="lblWoonplek" runat="server" CssClass="form-control"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-10">
                        <asp:Label ID="lblFilms" runat="server" Text="Films:"></asp:Label>
                        <br />
                        <asp:ListBox ID="lbFilms" SelectionMode="Single" CssClass="form-control" ToolTip="De films bij het geselecteerde genre." AutoPostBack="True" runat="server" OnSelectedIndexChanged="lbFilms_SelectedIndexChanged"></asp:ListBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-10">
                        <asp:Label ID="lblPrijzen" runat="server">Prijzen:</asp:Label>
                        <br />
                        <asp:ListBox ID="lbPrijzen" SelectionMode="Single" CssClass="form-control" ToolTip="Alle prijzen van deze regisseur" EnableViewState="False" runat="server"></asp:ListBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

