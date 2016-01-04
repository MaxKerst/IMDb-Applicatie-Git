﻿using System;
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

        public Regisseur(string naam)
        {
            Naam = naam;
        }

        public Regisseur(string naam, DateTime dob, string woonplek, List<Prijs> prijzen, List<Film> films)
        {
            Naam = naam;
            Dob = dob;
            Woonplek = woonplek;
            Prijzen = prijzen;
            Films = films;
        }
    }
}