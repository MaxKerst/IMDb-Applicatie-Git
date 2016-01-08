using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMDb_Applicatie
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name != "clanc")
            {
                Response.Redirect("~/");
            }
            SetVisibility(false, false);
        }

        public void ddlMovies_Selection_Change(object sender, EventArgs e)
        {
            SetVisibility(true, true);
        }

        public void rblEditNew_Index_Changed(object sender, EventArgs e)
        {
            if (rblEditNew.SelectedValue == "Nieuwe film toevoegen")
            {
                SetVisibility(true, false);
            }
            else
            {
                SetVisibility(false, true);
            }
            
        }

        public void SetVisibility(bool truefalse, bool movieslist)
        {
            tbDescription.Visible = truefalse;
            tbGenre.Visible = truefalse;
            tbMovieName.Visible = truefalse;
            tbRating.Visible = truefalse;

            lbCast.Visible = truefalse;
            lbPrizes.Visible = truefalse;
            lbRecensies.Visible = truefalse;
            lbRegisseurs.Visible = truefalse;
            
            lblCast.Visible = truefalse;
            lblDescrip.Visible = truefalse;
            lblFilm.Visible = truefalse;
            lblGenre.Visible = truefalse;
            lblPrijzen.Visible = truefalse;
            lblRating.Visible = truefalse;
            lblRecensies.Visible = truefalse;
            lblRegisseur.Visible = truefalse;

            ddlRegisseurs.Visible = truefalse;
            ddlPrizes.Visible = truefalse;
            ddlActeurs.Visible = truefalse;

            ddlMovies.Visible = movieslist;
            lblFilmSelect.Visible = movieslist;
            
            btnAddActeur.Visible = truefalse;
            btnAddPrize.Visible = truefalse;
            btnAddRegisseur.Visible = truefalse;
            btnDeleteRecensie.Visible = truefalse;
            btnSave.Visible = truefalse;
        }
    }
}