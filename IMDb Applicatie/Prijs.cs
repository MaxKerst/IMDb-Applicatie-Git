using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDb_Applicatie
{
    public class Prijs
    {
        public string Titel;
        public int Jaar;
        public int Id;

        public Prijs(string titel, int jaar, int id)
        {
            Titel = titel;
            Jaar = jaar;
            Id = id;
        }
    }
}