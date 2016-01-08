using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace IMDb_Applicatie
{
    public static class Portal
    {

        public static int ValidateUser(string name, string password)
        {
            return Database.ValidateUser(name, password);
        }

        public static List<Film> ObtainFilms()
        {
            return Database.ObtainFilms();
        }

        public static Film ObtainFilm(string id)
        {
            return Database.ObtainFilm(id);
        }

        public static List<ListItem> GetGenres(string name)
        {
            return Database.GetGenres(name);
        }

        public static Regisseur GetRegisseur(int id)
        {
            return Database.GetRegisseur(id);
        }

        public static List<ListItem> ObtainGenres()
        {
            return Database.ObtainGenres();
        }

        public static List<ListItem> ObtainActeurs()
        {
            return Database.ObtainActeurs();
        }

        public static Acteur GetActeur(string id)
        {
            return Database.GetActeur(id);
        }

        public static List<ListItem> ObtainRegisseurs()
        {
            return Database.ObtainRegisseurs();
        }

        public static bool InsertUser(string username, string password)
        {
            return Database.InsertUser(username, password);
        }

        public static bool InsertRecensie(int userid, int filmid, string body)
        {
            return Database.InsertRecensie(userid, filmid, body);
        }
    }
}