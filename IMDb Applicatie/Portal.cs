using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace IMDb_Applicatie
{
    public static class Portal
    {

        public static bool ValidateUser(string name, string password)
        {
            //database.login aanmaken
            return Database.ValidateUser(name, password);
            //return true;
        }

        public static List<Film> ObtainFilms()
        {
            return Database.ObtainFilms();
        }

        public static Film ObtainFilm(string id)
        {
            return Database.ObtainFilm(id);
        }

        public static void LogOut()
        {
            
        }
    }
}