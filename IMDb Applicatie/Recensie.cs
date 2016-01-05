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
        public int filmIDint;
        public string Body;
        public int Id;

        public Recensie(Gebruiker plaatser, Film filmid, string body)
        {
            Plaatser = plaatser;
            FilmID = filmid;
            Body = body;
        }

        public Recensie(Gebruiker plaatser, int filmidint, string body, int id)
        {
            Plaatser = plaatser;
            filmIDint = filmidint;
            Body = body;
            Id = id;
        }
    }
}