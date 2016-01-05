using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace IMDb_Applicatie
{
    public static class Database
    {
        private static string connectionstring = "Data Source=localhost; User Id=SYSTEM; password=SYSTEM";
        private static OracleConnection connection;
        private static OracleCommand cmd = new OracleCommand() { InitialLONGFetchSize = -1 };
        private static OracleDataReader reader;
        private static string query = string.Empty;

        public static bool ValidateUser(string email, string wachtwoord)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT gebruikersnaam FROM gebruiker WHERE gebruikersnaam = :pemail AND wachtwoord = :pwachtwoord";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("email", email);
                    cmd.Parameters.Add("wachtwoord", wachtwoord);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var emailCheck = reader.GetString(0);
                        if (emailCheck == email)
                        {
                            cmd.Dispose();
                            connection.Dispose();
                            reader.Close();
                            return true;
                        }
                        cmd.Dispose();
                        connection.Dispose();
                        reader.Close();
                        return false;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                    return false;
                }
            }
        }

        public static List<Film> ObtainFilms()
        {
            List<Film> films = new List<Film>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT filmid, titel FROM film";
                cmd.CommandText = query;
                cmd.Connection = connection;
                
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string titel = reader.GetString(1);
                        films.Add(new Film(id.ToString(), titel));
                    }
                    return films;
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                    return null;
                }
            }
        }

        public static Film ObtainFilm(string id)
        {
            Film _film;
            string titel = string.Empty;
            string beschrijving = string.Empty;
            Regisseur filmRegisseur = new Regisseur("test");
            string genre = String.Empty;
            List<Prijs> filmPrijs = new List<Prijs>();
            List<Recensie> filmRecensies = new List<Recensie>();
            List<Acteur> cast = new List<Acteur>();
            double filmRating = 0;

            using (connection = new OracleConnection(connectionstring))
            {
                //string titel, string beschrijving, Regisseur filmRegisseur, string genre, List<Prijs> filmPrijs,
                //List<Recensie> filmRecensies, List<Acteur> cast, double filmRating
                query = "SELECT f.titel, f.beschrijving, r.naam AS regisseur, g.naam AS genre FROM film f, regisseur r, genre g, filmgenreregel fgr WHERE f.regisseurid = r.regisseurid AND f.filmid = :pid AND f.filmid = fgr.filmid AND fgr.genreid = g.genreid";
                cmd.CommandText = query;
                cmd.Connection = connection;
                
                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", Convert.ToInt32(id));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        titel = reader.GetString(0);
                        beschrijving = reader.GetString(1);
                        filmRegisseur = new Regisseur(reader.GetString(2));
                        genre = reader.GetString(3);
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }

            using (connection = new OracleConnection(connectionstring))
            {
                //string titel, string beschrijving, Regisseur filmRegisseur, string genre, List<Prijs> filmPrijs,
                //List<Recensie> filmRecensies, List<Acteur> cast, double filmRating
                query = "SELECT AVG(r.ratingnumber) FROM rating r WHERE r.filmid = :pid";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", Convert.ToInt32(id));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        filmRating = reader.GetInt32(0);
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }

            using (connection = new OracleConnection(connectionstring))
            {
                //string titel, string beschrijving, Regisseur filmRegisseur, string genre, List<Prijs> filmPrijs,
                //List<Recensie> filmRecensies, List<Acteur> cast, double filmRating
                query = "SELECT a.naam, a.acteurid FROM acteur a, filmacteurregel facr, film f WHERE a.acteurid = facr.acteurid AND facr.filmid = f.filmid AND f.filmid = :pid";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", Convert.ToInt32(id));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cast.Add(new Acteur(reader.GetString(0), reader.GetInt32(1)));
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }
            using (connection = new OracleConnection(connectionstring))
            {
                //string titel, string beschrijving, Regisseur filmRegisseur, string genre, List<Prijs> filmPrijs,
                //List<Recensie> filmRecensies, List<Acteur> cast, double filmRating
                query = "SELECT p.titel, p.jaar, p.prizeid FROM prijs p, filmprijsregel fpr, film f WHERE p.prizeid = fpr.prizeid AND fpr.filmid = f.filmid AND f.filmid = :pid";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", Convert.ToInt32(id));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        filmPrijs.Add(new Prijs(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }
            using (connection = new OracleConnection(connectionstring))
            {
                //string titel, string beschrijving, Regisseur filmRegisseur, string genre, List<Prijs> filmPrijs,
                //List<Recensie> filmRecensies, List<Acteur> cast, double filmRating
                query = "SELECT g.gebruikersnaam, g.userid, r.reviewid, r.rbody FROM recensie r, gebruiker g, film f WHERE r.userid = g.userid AND f.filmid = :pid";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", Convert.ToInt32(id));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        filmRecensies.Add(new Recensie(new Gebruiker(reader.GetString(0), reader.GetInt32(1)), Convert.ToInt32(id),
                            reader.GetString(3), reader.GetInt32(2)));

                        ;
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }
            using (connection = new OracleConnection(connectionstring))
            {
                //string titel, string beschrijving, Regisseur filmRegisseur, string genre, List<Prijs> filmPrijs,
                //List<Recensie> filmRecensies, List<Acteur> cast, double filmRating
                query = "SELECT p.titel, p.jaar, p.prizeid FROM prijs p, filmprijsregel fpr, film f WHERE p.prizeid = fpr.prizeid AND fpr.filmid = f.filmid AND f.filmid = :pid";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", Convert.ToInt32(id));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        filmPrijs.Add(new Prijs(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }
            _film = new Film(titel, beschrijving, filmRegisseur, genre, filmPrijs, filmRecensies, cast, filmRating);
            return _film;
        }
    }
}