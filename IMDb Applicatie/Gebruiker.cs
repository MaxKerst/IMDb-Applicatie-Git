﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDb_Applicatie
{
    public class Gebruiker
    {
        public string Gebruikersnaam;
        private string _wachtwoord;
        public int Rechten;

        public Gebruiker(string gebruikersnaam, string wachtwoord, int rechten)
        {
            Gebruikersnaam = gebruikersnaam;
            _wachtwoord = wachtwoord;
            Rechten = rechten;
        }
    }
}