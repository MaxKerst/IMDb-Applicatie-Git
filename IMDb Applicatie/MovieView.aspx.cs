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
                hyperGenre.NavigateUrl = "~/ViewGenre.aspx";
                hyperRegisseur.NavigateUrl = "~/ViewRegisseur.aspx";
                ddlMovies.Items.Add("Selecteer een film");
                List<Film> films = Portal.ObtainFilms();
                foreach (Film f in films)
                {
                    ListItem _listItem = new ListItem(f.Titel, f.Id);
                    ddlMovies.Items.Add(_listItem);
                }
            }
            if (IMDbSession.SelectedFilm != null)
            {
                tbMovieName.Text = IMDbSession.SelectedFilm.Titel;
                tbDescription.InnerText = IMDbSession.SelectedFilm.Beschrijving;
                IMDbSession.Genre = IMDbSession.SelectedFilm.Genre;
                hyperGenre.Text = IMDbSession.SelectedFilm.Genre;
                tbRating.Text = IMDbSession.SelectedFilm.FilmRating.ToString();
                IMDbSession.SelectedRegisseur = new Regisseur(IMDbSession.SelectedFilm.FilmRegisseur.Id);
                hyperRegisseur.Text = IMDbSession.SelectedFilm.FilmRegisseur.Naam;

                lbCast.Items.Clear();
                foreach (Acteur a in IMDbSession.SelectedFilm.Cast)
                {
                    lbCast.Items.Add(new ListItem(a.Naam, a.Id.ToString()));
                }

                lbPrizes.Items.Clear();
                foreach (Prijs p in IMDbSession.SelectedFilm.FilmPrijs)
                {
                    lbPrizes.Items.Add(new ListItem(p.Titel + " - " + p.Jaar.ToString(), p.Id.ToString()));
                }

                lbRecensies.Items.Clear();
                foreach (Recensie r in IMDbSession.SelectedFilm.FilmRecensies)
                {
                    lbRecensies.Items.Add(new ListItem(r.Body + " - " + r.Plaatser.Gebruikersnaam, r.Id.ToString()));
                }
            }
        }

        public void ddlMovies_Selection_Change(object sender, EventArgs e)
        {
            if (ddlMovies.SelectedValue != "Selecteer een film")
            {
                ChangeVisibility(true);
                IMDbSession.SelectedFilm = Portal.ObtainFilm(ddlMovies.SelectedValue);
                tbMovieName.Text = IMDbSession.SelectedFilm.Titel;
                tbDescription.InnerText = IMDbSession.SelectedFilm.Beschrijving;
                IMDbSession.Genre = IMDbSession.SelectedFilm.Genre;
                hyperGenre.Text = IMDbSession.SelectedFilm.Genre;
                tbRating.Text = IMDbSession.SelectedFilm.FilmRating.ToString();
                IMDbSession.SelectedRegisseur = new Regisseur(IMDbSession.SelectedFilm.FilmRegisseur.Id);
                hyperRegisseur.Text = IMDbSession.SelectedFilm.FilmRegisseur.Naam;

                lbCast.Items.Clear();
                foreach (Acteur a in IMDbSession.SelectedFilm.Cast)
                {
                    lbCast.Items.Add(new ListItem(a.Naam, a.Id.ToString()));
                }

                lbPrizes.Items.Clear();
                foreach (Prijs p in IMDbSession.SelectedFilm.FilmPrijs)
                {
                    lbPrizes.Items.Add(new ListItem(p.Titel + " - " + p.Jaar.ToString(), p.Id.ToString()));
                }

                lbRecensies.Items.Clear();
                foreach (Recensie r in IMDbSession.SelectedFilm.FilmRecensies)
                {
                    lbRecensies.Items.Add(new ListItem(r.Body + " - " + r.Plaatser.Gebruikersnaam, r.Id.ToString()));
                }
            }

        }

        public void lbCast_SelectedIndexChanged(object sender, EventArgs e)
        {
            IMDbSession.SelectedActeur = Portal.GetActeur(lbCast.SelectedItem.Value);
            Response.Redirect("ViewActeur");
        }

        public void ChangeVisibility(bool truefalse)
        {
            tbDescription.Visible = truefalse;
            hyperGenre.Visible = truefalse;
            tbMovieName.Visible = truefalse;
            tbRating.Visible = truefalse;
            lbCast.Visible = truefalse;
            lbPrizes.Visible = truefalse;
            lbRecensies.Visible = truefalse;
            hyperRegisseur.Visible = truefalse;
            lblCast.Visible = truefalse;
            lblDescrip.Visible = truefalse;
            lblFilm.Visible = truefalse;
            lblGenre.Visible = truefalse;
            lblPrijzen.Visible = truefalse;
            lblRating.Visible = truefalse;
            lblRecensies.Visible = truefalse;
            hyperRegisseur.Visible = truefalse;
            lblRegisseur.Visible = truefalse;
            if(IMDbSession.UserID != null)
            {
                tbRecensie.Visible = truefalse;
                btnPostRecensie.Visible = truefalse;   
            }
        }

        protected void btnPostRecensie_OnClick(object sender, EventArgs e)
        {
            if (Portal.InsertRecensie(Convert.ToInt32(IMDbSession.UserID), Convert.ToInt32(ddlMovies.SelectedValue),
                tbRecensie.Text))
            {
                lblError.Visible = false;
                lbRecensies.Items.Clear();
                tbRecensie.Text = "";
                IMDbSession.SelectedFilm = Portal.ObtainFilm(ddlMovies.SelectedValue);
                foreach (Recensie r in IMDbSession.SelectedFilm.FilmRecensies)
                {
                    lbRecensies.Items.Add(new ListItem(r.Body + " - " + r.Plaatser.Gebruikersnaam, r.Id.ToString()));
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }
    }
}