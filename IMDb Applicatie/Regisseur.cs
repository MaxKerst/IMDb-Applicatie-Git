using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDb_Applicatie
{
    public class Regisseur
    {
        public string Naam;
        public DateTime Dob;
        public string Woonplek;
        public List<Prijs> Prijzen;
        public List<Film> Films;
        public int Id;

        public Regisseur(int id)
        {
            Id = id;
        }
        public Regisseur(string naam, int id)
        {
            Naam = naam;
            Id = id;
        }

        public Regisseur(string naam, DateTime dob, string woonplek, List<Prijs> prijzen, List<Film> films, int id)
        {
            Naam = naam;
            Dob = dob;
            Woonplek = woonplek;
            Prijzen = prijzen;
            Films = films;
            Id = id;
        }
    }
}