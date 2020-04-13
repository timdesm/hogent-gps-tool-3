using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hogent_GPS_Project___Tool_3
{
    class DatabaseManager
    {
        public static Dictionary<int, string> GetStateList()
        {
            Dictionary<int, String> states = new Dictionary<int, string>();

            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_states");
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                states.Add(rdr.GetInt16("id"), rdr.GetString("name"));
            return states;
        }

        public static int getStateID(String state)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_states WHERE LOWER(name) = @name");
            cmd.Parameters.AddWithValue("@name", state.ToLower());
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                int r = rdr.GetInt16("id");
                con.Dispose();
                return r;
            }
            con.Dispose();
            return 0;
        }

        public static String getStateName(int state)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_states WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", state);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                String r = rdr.GetString("name");
                con.Dispose();
                return r;
            }
            con.Dispose();
            return "NULL";
        }

        public static int getCityCount(int state)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT COUNT(*) FROM gps_cities WHERE state = @state");
            cmd.Parameters.AddWithValue("@state", state);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                int r = rdr.GetInt16(0);
                con.Dispose();
                return r;
            }
            con.Dispose();
            return 0;
        }

        public static Dictionary<int, string> getCityList(int state)
        {
            Dictionary<int, String> cities = new Dictionary<int, string>();

            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_cities WHERE state = @state");
            cmd.Parameters.AddWithValue("@state", state);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                cities.Add(rdr.GetInt16("id"), rdr.GetString("name"));
            return cities;
        }

        public static int getCityID(String city)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_cities WHERE LOWER(name) = @name");
            cmd.Parameters.AddWithValue("@name", city.ToLower());
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                int r = rdr.GetInt16("id");
                con.Dispose();
                return r;
            }
            con.Dispose();
            return 0;
        }

        public static String getCityName(int city)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_cities WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", city);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                String r = rdr.GetString("name");
                con.Close();
                return r;
            }
            con.Close();
            return "NULL";
        }

        public static int getStreetCount(int city)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT COUNT(*) FROM gps_streets WHERE city = @city");
            cmd.Parameters.AddWithValue("@city", city);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                int r = rdr.GetInt16(0);
                con.Dispose();
                return r;
            }
            con.Dispose();
            return 0;
        }

        public static Dictionary<int, string> getStreetList(int city)
        {
            Dictionary<int, String> cities = new Dictionary<int, string>();

            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_streets WHERE city = @city");
            cmd.Parameters.AddWithValue("@state", city);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                cities.Add(rdr.GetInt16("id"), rdr.GetString("name"));
            return cities;
        }

        public static Dictionary<int, string> getStreetCityList(String street)
        {
            Dictionary<int, String> cities = new Dictionary<int, string>();

            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_streets WHERE LOWER(name) = @name");
            cmd.Parameters.AddWithValue("@name", street.ToLower());
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                cities.Add(rdr.GetInt16("city"), getCityName(rdr.GetInt16("city")));
            return cities;
        }

        public static String getStreetName(int street)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_streets WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", street);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                String r = rdr.GetString("name");
                con.Dispose();
                return r;
            }
            con.Dispose();
            return "NULL";
        }

        public static int getStreetID(String street, int city)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_streets WHERE LOWER(name)='@name' AND city=@city");
            cmd.Parameters.AddWithValue("@name", street);
            cmd.Parameters.AddWithValue("@city", city);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                int r = rdr.GetInt16("id");
                con.Dispose();
                return r;
            }
            con.Dispose();
            return 0;
        }

        public static int getStreetCityID(int street)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_streets WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", street);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                int r = rdr.GetInt16("city");
                con.Dispose();
                return r;
            }
            con.Dispose();
            return 0;
        }

        public static Double getStreetLength(int street)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_streets WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", street);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                String r = rdr.GetString("length");
                con.Dispose();
                return Double.Parse(r.Replace(".", ","));
            }
            con.Dispose();
            return 0.0;
        }

        public static String getStreetMapString(int street)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT * FROM gps_streets WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", street);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                String r = rdr.GetString("map");
                con.Dispose();
                return r;
            }
            con.Dispose();
            return "{}";
        }
    }
}
