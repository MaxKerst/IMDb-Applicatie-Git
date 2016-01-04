﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDb_Applicatie
{
    public class Acteur
    {
        public string Naam;
        public DateTime Dob;
        public string Woonplek;
        public string Baan;
        public List<Prijs> Prijzen;
        public List<Film> Films;

        public Acteur(string naam, DateTime dob, string woonplek, string baan, List<Prijs> prijzen, List<Film> films)
        {
            Naam = naam;
            Dob = dob;
            Woonplek = woonplek;
            Baan = baan;
            Prijzen = prijzen;
            Films = films;
        }
    }
}