using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMDb_Applicatie
{
    public partial class RegisseurView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            ChangeVisibility(false);
            ddlRegisseurs.Items.Clear();
            ddlRegisseurs.Items.Add("Selecteer een regisseur");
            foreach (ListItem l in Portal.ObtainRegisseurs())
            {
                ddlRegisseurs.Items.Add(l);
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

        public void ddlRegisseurs_Selection_Change(object sender, EventArgs e)
        {
            if (ddlRegisseurs.SelectedItem.Text != "Selecteer een regisseur")
            {
                ChangeVisibility(true);
                lbPrijzen.Items.Clear();
                lbFilms.Items.Clear();
                Regisseur selectedRegisseur = Portal.GetRegisseur(Convert.ToInt32(ddlRegisseurs.SelectedItem.Value));
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