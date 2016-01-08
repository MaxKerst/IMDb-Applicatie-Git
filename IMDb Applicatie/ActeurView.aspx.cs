using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMDb_Applicatie
{
    public partial class ActeurView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChangeVisibility(false);
                ddlActeurs.Items.Clear();
                ddlActeurs.Items.Add("Selecteer een acteur");
                foreach (ListItem l in Portal.ObtainActeurs())
                {
                    ddlActeurs.Items.Add(l);
                }
            }
        }

        public void ddlActeurs_Selection_Change(object sender, EventArgs e)
        {
            if (ddlActeurs.SelectedValue != "Selecteer een acteur")
            {
                ChangeVisibility(true);
                IMDbSession.SelectedActeur = Portal.GetActeur(ddlActeurs.SelectedItem.Value);
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
                lblDob.Text = IMDbSession.SelectedActeur.Dob.ToString("yy-mm-dd");
                lblWoonplek.Text = IMDbSession.SelectedActeur.Woonplek;
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