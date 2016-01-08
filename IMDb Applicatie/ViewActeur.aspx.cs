using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMDb_Applicatie
{
    public partial class ViewActeur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChangeVisibility(false);
                if (IMDbSession.SelectedActeur == null)
                {
                    lblDob.Visible = true;
                    lblDob.Text = "Er is geen acteur gevonden, probeer opnieuw een acteur te selecteren bij een film.";
                }
                else
                {
                    ChangeVisibility(true);
                    this.Title = IMDbSession.SelectedActeur.Naam;
                    lbFilms.Items.Clear();
                    foreach (Film f in IMDbSession.SelectedActeur.Films)
                    {
                        lbFilms.Items.Add(new ListItem(f.Titel, f.Id.ToString()));
                    }
                    lbPrijzen.Items.Clear();
                    foreach (Prijs p in IMDbSession.SelectedActeur.Prijzen)
                    {
                        lbPrijzen.Items.Add(new ListItem(p.Titel + " - " + p.Jaar.ToString(), p.Id.ToString()));
                    }
                    lblDob.Text = IMDbSession.SelectedActeur.Dob.ToString("yy-MM-dd");
                    lblWoonplek.Text = IMDbSession.SelectedActeur.Woonplek;
                }
            }
        }

        public void ChangeVisibility(bool truefalse)
        {
            lblFilms.Visible = truefalse;
            lbFilms.Visible = truefalse;
            lbPrijzen.Visible = truefalse;
            lblWoonplek.Visible = truefalse;
            lblDob.Visible = truefalse;
            lblWoonplekWoonplek.Visible = truefalse;
            lblFilms.Visible = truefalse;
            lblPrijzen.Visible = truefalse;
            lblGeboortedatum.Visible = truefalse;
        }

        public void lbFilms_SelectedIndexChanged(object sender, EventArgs e)
        {
            IMDbSession.SelectedFilm = Portal.ObtainFilm(lbFilms.SelectedItem.Value);
            Response.Redirect("ViewMovie");
        }
    }
}