using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDb_Applicatie
{
    public class Rating
    {
        public Film FilmID;
        public Gebruiker Plaatser;
        public int Ratingnumber;

        public Rating(Film filmID, Gebruiker plaatser, int ratingnumber)
        {
            FilmID = filmID;
            Plaatser = plaatser;
            Ratingnumber = ratingnumber;
        }
    }
}