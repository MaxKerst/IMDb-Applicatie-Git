using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDb_Applicatie
{
    public class Film
    {
        public string Titel;
        public string Beschrijving;
        public Regisseur FilmRegisseur;
        public string Genre;
        public List<Prijs> FilmPrijs;
        public List<Recensie> FilmRecensies;
        public List<Acteur> Cast;
        public double FilmRating;
        public string Id;

        public Film(string id, string titel)
        {
            Titel = titel;
            Id = id;
        }
        public Film(string titel, string beschrijving, Regisseur filmRegisseur, string genre, List<Prijs> filmPrijs,
            List<Recensie> filmRecensies, List<Acteur> cast, double filmRating)
        {
            Titel = titel;
            Beschrijving = beschrijving;
            FilmRegisseur = filmRegisseur;
            Genre = genre;
            FilmPrijs = filmPrijs;
            FilmRecensies = filmRecensies;
            Cast = cast;
            FilmRating = filmRating;
        }

        public Film(string titel, string beschrijving, Regisseur filmRegisseur, string genre, double filmRating)
        {
            Titel = titel;
            Beschrijving = beschrijving;
            FilmRegisseur = filmRegisseur;
            Genre = genre;
            FilmRating = filmRating;
        }
    }
}