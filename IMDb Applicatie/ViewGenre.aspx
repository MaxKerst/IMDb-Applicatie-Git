<%@ Page Title="Genre overzicht" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewGenre.aspx.cs" Inherits="IMDb_Applicatie.ViewGenre" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <div class="form-group">
                <div class="col-md-10">
                    <asp:Label ID="lblGenreMain" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:ListBox ID="lbGenreMain" SelectionMode="Single" CssClass="form-control" ToolTip="Alle films van dit genre." runat="server" OnSelectedIndexChanged="lbGenreMain_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                </div>
            </div>
        </div>        
    </div>
</asp:Content>
