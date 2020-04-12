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
                return rdr.GetInt16("id");
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
                return rdr.GetString("name");
            return "NULL";
        }

        public static int getGemeenteCount(int state)
        {
            MySqlConnection con = Program.db.getConnection();
            using var cmd = DatabaseUtil.CommandExecutor(con, "SELECT COUNT(*) FROM gps_cities WHERE state = @state");
            cmd.Parameters.AddWithValue("@state", state);
            con.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
                return rdr.GetInt16(0);
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
                return rdr.GetInt16("id");
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
                return rdr.GetString("name");
            return "NULL";
        }
    }
}
