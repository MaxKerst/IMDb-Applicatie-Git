using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMDb_Applicatie
{
    public partial class GenreView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChangeVisibility(false);
                ddlGenres.Items.Clear();
                ddlGenres.Items.Add("Selecteer een genre");
                foreach (ListItem l in Portal.ObtainGenres())
                {
                    ddlGenres.Items.Add(l);
                }
            }
        }

        public void ddlGenres_Selection_Change(object sender, EventArgs e)
        {
            if (ddlGenres.SelectedValue != "Selecteer een genre")
            {
                ChangeVisibility(true);
                lbFilms.Items.Clear();
                foreach (ListItem l in Portal.GetGenres(ddlGenres.SelectedItem.Text))
                {
                    lbFilms.Items.Add(l);
                }
            }
        }

        public void ChangeVisibility(bool truefalse)
        {
            lblFilms.Visible = truefalse;
            lbFilms.Visible = truefalse;
        }

        public void lbFilms_SelectedIndexChanged(object sender, EventArgs e)
        {
            IMDbSession.SelectedFilm = Portal.ObtainFilm(lbFilms.SelectedItem.Value);
            Response.Redirect("ViewMovie");
        }

        protected void btnLogOut_OnClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Account/Register.aspx");
        }
    }
}