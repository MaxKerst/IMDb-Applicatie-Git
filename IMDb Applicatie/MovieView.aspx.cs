using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace IMDb_Applicatie
{
    public partial class MovieView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChangeVisibility(false);
                ddlMovies.Items.Clear();
                List<Film> films = Portal.ObtainFilms();
                foreach (Film f in films)
                {
                    ListItem _listItem = new ListItem(f.Titel, f.Id);
                    ddlMovies.Items.Add(_listItem);
                }
            }
            
            btnLogOut.Text = Context.User.Identity.GetUserName();
        }

        public void ddlMovies_Selection_Change(object sender, EventArgs e)
        {
            ChangeVisibility(true);
            Film _selectedFilm = Portal.ObtainFilm(ddlMovies.SelectedValue);
            tbMovieName.Text = _selectedFilm.Titel;
            tbDescription.Text = _selectedFilm.Beschrijving;
            tbGenre.Text = _selectedFilm.Genre;
            tbRating.Text = _selectedFilm.FilmRating.ToString();
            tbRegisseur.Text = _selectedFilm.FilmRegisseur.Naam;
        }

        public void ChangeVisibility(bool truefalse)
        {
            tbDescription.Visible = truefalse;
            tbGenre.Visible = truefalse;
            tbMovieName.Visible = truefalse;
            tbRating.Visible = truefalse;
            lbCast.Visible = truefalse;
            lbPrizes.Visible = truefalse;
            lbRecensies.Visible = truefalse;
            tbRegisseur.Visible = truefalse;
            lblCast.Visible = truefalse;
            lblDescrip.Visible = truefalse;
            lblFilm.Visible = truefalse;
            lblGenre.Visible = truefalse;
            lblPrijzen.Visible = truefalse;
            lblRating.Visible = truefalse;
            lblRecensies.Visible = truefalse;
            tbRegisseur.Visible = truefalse;
        }

        protected void btnLogOut_OnClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Account/Register.aspx");
        }
    }
}