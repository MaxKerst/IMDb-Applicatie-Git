using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
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

        public static int ValidateUser(string email, string wachtwoord)
        {
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT userid, gebruikersnaam FROM gebruiker WHERE gebruikersnaam = :pemail AND wachtwoord = :pwachtwoord";
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
                        var emailCheck = reader.GetString(1);
                        if (emailCheck == email)
                        {
                            return reader.GetInt32(0);
                        }
                        cmd.Dispose();
                        connection.Dispose();
                        reader.Close();
                        return 0;
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                    return 0;
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
            Regisseur filmRegisseur = new Regisseur("test", 1);
            string genre = String.Empty;
            List<Prijs> filmPrijs = new List<Prijs>();
            List<Recensie> filmRecensies = new List<Recensie>();
            List<Acteur> cast = new List<Acteur>();
            double filmRating = 0;

            using (connection = new OracleConnection(connectionstring))
            {
                //string titel, string beschrijving, Regisseur filmRegisseur, string genre, List<Prijs> filmPrijs,
                //List<Recensie> filmRecensies, List<Acteur> cast, double filmRating
                query = "SELECT f.titel, f.beschrijving, r.naam, g.naam, r.regisseurid FROM film f, regisseur r, genre g, filmgenreregel fgr WHERE f.regisseurid = r.regisseurid AND f.filmid = :pid AND f.filmid = fgr.filmid AND fgr.genreid = g.genreid";
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
                        filmRegisseur = new Regisseur(reader.GetString(2), reader.GetInt32(4));
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
                query = "SELECT g.gebruikersnaam, g.userid, r.reviewid, r.rbody FROM recensie r, gebruiker g, film f WHERE r.userid = g.userid AND f.filmid = :pid AND r.filmid = :pid";
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

        public static List<ListItem> GetGenres(string name)
        {
            List<ListItem> filmGenreList = new List<ListItem>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT f.titel, f.filmid FROM film f, filmgenreregel fgr, genre g WHERE f.filmid = fgr.filmid AND fgr.genreid = g.genreid AND g.naam = :pname";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("name", name);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        filmGenreList.Add(new ListItem(reader.GetString(0), reader.GetInt32(1).ToString()));
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }
            return filmGenreList;
        }

        public static Regisseur GetRegisseur(int id)
        {
            string naam = string.Empty;
            DateTime dob = new DateTime(1, 1, 1);
            string woonplek = string.Empty;
            int regisseurid = 0;
            List<Film> films = new List<Film>();
            List<Prijs> prijzen = new List<Prijs>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT r.naam, r.dob, r.woonplek, r.regisseurid FROM regisseur r WHERE r.regisseurid = :pid";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", id);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        naam = reader.GetString(0);
                        dob = reader.GetDateTime(1);
                        woonplek = reader.GetString(2);
                        regisseurid = reader.GetInt32(3);
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
                query = "SELECT p.titel, p.jaar, p.prizeid FROM prijs p, regisseurprijsregel rpr, regisseur r WHERE p.prizeid = rpr.prizeid AND rpr.regisseurid = :pid";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", id);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        prijzen.Add(new Prijs(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2)));
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
                query = "SELECT f.filmid, f.titel FROM film f, regisseur r WHERE r.regisseurid = :pid";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", id);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        films.Add(new Film(reader.GetInt32(0).ToString(), reader.GetString(1)));
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }
            return new Regisseur(naam, dob, woonplek, prijzen, films, regisseurid);
        }

        public static List<ListItem> ObtainGenres()
        {
            List<ListItem> genreList = new List<ListItem>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT g.naam, g.genreid FROM genre g";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        genreList.Add(new ListItem(reader.GetString(0), reader.GetInt32(1).ToString()));
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }
            return genreList;
        }

        public static List<ListItem> ObtainActeurs()
        {
            List<ListItem> acteurList = new List<ListItem>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT a.naam, a.acteurid FROM acteur a";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        acteurList.Add(new ListItem(reader.GetString(0), reader.GetInt32(1).ToString()));
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }
            return acteurList;
        }

        public static Acteur GetActeur(string id)
        {
            string naam = string.Empty;
            DateTime dob = new DateTime(1, 1, 1);
            string woonplek = string.Empty;
            string baan = string.Empty;
            List<Prijs> prijzen = new List<Prijs>();
            List<Film> films = new List<Film>();

            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT f.filmid, f.titel FROM film f, filmacteurregel fcr, acteur a WHERE f.filmid = fcr.filmid AND fcr.acteurid = :pid";
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
                        films.Add(new Film(reader.GetInt32(0).ToString(), reader.GetString(1)));
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
                query = "SELECT p.titel, p.jaar, p.prizeid FROM acteur a, acteurprijsregel apr, prijs p WHERE p.prizeid = apr.prizeid AND apr.acteurid = :pid";
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
                        prijzen.Add(new Prijs(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2)));
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
                query = "SELECT a.naam, a.dob, a.woonplek, a.baan FROM acteur a WHERE a.acteurid = :pid";
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
                        naam = reader.GetString(0);
                        dob = reader.GetDateTime(1);
                        woonplek = reader.GetString(2);
                        baan = reader.GetString(3);
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }
            Acteur acteur = new Acteur(naam, dob, woonplek, baan, prijzen, films, Convert.ToInt32(id));
            return acteur;
        }

        public static List<ListItem> ObtainRegisseurs()
        {
            List<ListItem> regisseurList = new List<ListItem>();
            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT r.naam, r.regisseurid FROM regisseur r";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        regisseurList.Add(new ListItem(reader.GetString(0), reader.GetInt32(1).ToString()));
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                }
            }
            return regisseurList;
        }

        public static bool InsertUser(string username, string password)
        {
            int id = 0;

            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT MAX(userid) FROM gebruiker";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                    return false;
                }
            }
            id = id + 1;
            using (connection = new OracleConnection(connectionstring))
            {
                query = "INSERT INTO gebruiker(userid, gebruikersnaam, wachtwoord) VALUES (:puserid, :pgebruikersnaam, :pwachtwoord)";
                cmd.CommandText = query;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("userid", id);
                    cmd.Parameters.Add("username", username);
                    cmd.Parameters.Add("password", password);
                    cmd.ExecuteNonQuery();
                    return true;
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

        public static bool InsertRecensie(int userid, int filmid, string body)
        {
            int id = 0;

            using (connection = new OracleConnection(connectionstring))
            {
                query = "SELECT MAX(reviewid) FROM recensie";
                cmd.CommandText = query;
                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    cmd.Parameters.Clear();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                catch (Exception ex)
                {
                    cmd.Dispose();
                    connection.Dispose();
                    reader.Close();
                    return false;
                }
            }
            id = id + 1;
            using (connection = new OracleConnection(connectionstring))
            {
                query = @"INSERT INTO recensie (reviewid, userid, filmid, rbody) VALUES(:pid, :puserid, :pfilmid, :precensiebody)";
                cmd.CommandText = query;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("id", id);
                    cmd.Parameters.Add("userid", userid);
                    cmd.Parameters.Add("filmid", filmid);
                    cmd.Parameters.Add("recensiebody", body);
                    cmd.ExecuteNonQuery();
                    return true;
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
    }
}