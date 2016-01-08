using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMDb_Applicatie
{
    public partial class ViewRegisseur : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            if (IMDbSession.SelectedRegisseur == null)
            {
                //Hide alle controls
                lblName.Visible = true;
                lbFilms.Visible = false;
                lbPrijzen.Visible = false;
                lblWoonplek.Visible = false;
                lblDob.Visible = false;
                lblWoonplekWoonplek.Visible = false;
                lblFilms.Visible = false;
                lblPrijzen.Visible = false;
                lblGeboortedatum.Visible = false;
                lblName.Text =
                    "Er is geen regisseur opgegeven, dus er kan geen informatie getoond worden. Probeer opnieuw een regisseur te selecteren bij een film.";
            }
            else
            {
                lbPrijzen.Items.Clear();
                lbFilms.Items.Clear();
                Regisseur selectedRegisseur = (Portal.GetRegisseur(IMDbSession.SelectedFilm.FilmRegisseur.Id));
                lblName.Text = "Informatie over " + selectedRegisseur.Naam;
                lblWoonplek.Text = selectedRegisseur.Woonplek;
                lblDob.Text = selectedRegisseur.Dob.ToShortDateString();
                foreach (Film f in selectedRegisseur.Films)
                {
                    lbFilms.Items.Add(new ListItem(f.Titel, f.Id.ToString()));
                }
                foreach (Prijs p in selectedRegisseur.Prijzen)
                {
                    lbPrijzen.Items.Add(new ListItem(p.Titel + " - " + p.Jaar));
                }
            }
        }

        public void lbFilms_SelectedIndexChanged(object sender, EventArgs e)
        {
            IMDbSession.SelectedFilm = Portal.ObtainFilm(lbFilms.SelectedItem.Value);
            Response.Redirect("ViewMovie");
        }
    }
}