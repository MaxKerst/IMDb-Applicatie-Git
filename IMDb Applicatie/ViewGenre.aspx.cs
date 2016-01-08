using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMDb_Applicatie
{
    public partial class ViewGenre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            if (string.IsNullOrEmpty(IMDbSession.Genre))
            {
                lbGenreMain.Visible = false;
                lblGenreMain.Text =
                    "Er is geen genre opgegeven, dus er kunnen geen films worden getoond. Probeer opnieuw een genre te selecteren bij een film.";
            }
            else
            {
                lblGenreMain.Text = "Alle films van het genre " + IMDbSession.Genre;
                lbGenreMain.Items.Clear();
                foreach (ListItem s in Portal.GetGenres(IMDbSession.Genre))
                {
                    lbGenreMain.Items.Add(s);
                }
            }
        }

        public void lbGenreMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            IMDbSession.SelectedFilm = Portal.ObtainFilm(lbGenreMain.SelectedItem.Value);
            Response.Redirect("ViewMovie");
        }
    }
}