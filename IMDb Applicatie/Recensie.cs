using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace IMDb_Applicatie
{
    public class Recensie
    {
        public Gebruiker Plaatser;
        public Film FilmID;
        public string Body;

        public Recensie(Gebruiker plaatser, Film filmid, string body)
        {
            Plaatser = plaatser;
            FilmID = filmid;
            Body = body;
        }
    }
}