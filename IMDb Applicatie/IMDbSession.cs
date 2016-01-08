using System.Web;
using System.Web.SessionState;

namespace IMDb_Applicatie
{
    public static class IMDbSession
    {
        private static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public static Film SelectedFilm
        {
            get { return Session["SelectedFilm"] as Film; }
            set { Session["SelectedFilm"] = value; }
        }

        public static string Genre
        {
            get { return Session["Genre"] as string; }
            set { Session["Genre"] = value; }
        }

        public static Regisseur SelectedRegisseur
        {
            get { return Session["SelectedRegisseur"] as Regisseur; }
            set { Session["SelectedRegisseur"] = value; }
        }

        public static Acteur SelectedActeur
        {
            get { return Session["SelectedActeur"] as Acteur; }
            set { Session["SelectedActeur"] = value; }
        }

        public static string UserID
        {
            get { return Session["UserID"] as string; }
            set { Session["UserID"] = value; }
        }
    }
}