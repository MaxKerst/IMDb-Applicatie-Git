using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMDb_Applicatie
{
    public partial class ViewMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hyperGenre.NavigateUrl = "~/ViewGenre.aspx";
                hyperRegisseur.NavigateUrl = "~/ViewRegisseur.aspx";
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
                else
                {
                    tbMovieName.Text = "Er is geen film gevonden, probeer opnieuw een film te selecteren bij een acteur of regisseur.";
                    lblFilm.Visible = false;
                    lblGenre.Visible = false;
                    tbDescription.Visible = false;
                    hyperGenre.Visible = false;
                    tbRating.Visible = false;
                    lbCast.Visible = false;
                    lbPrizes.Visible = false;
                    lbRecensies.Visible = false;
                    hyperRegisseur.Visible = false;
                    lblCast.Visible = false;
                    lblDescrip.Visible = false;
                    lblFilm.Visible = false;
                    lblGenre.Visible = false;
                    lblPrijzen.Visible = false;
                    lblRating.Visible = false;
                    lblRecensies.Visible = false;
                    hyperRegisseur.Visible = false;
                    lblRegisseur.Visible = false;
                }
            }
        }

        protected void lbCast_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            IMDbSession.SelectedActeur = Portal.GetActeur(lbCast.SelectedItem.Value);
            Response.Redirect("ViewActeur");
        }
    }
}
