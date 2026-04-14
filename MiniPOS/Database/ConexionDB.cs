using MySql.Data.MySqlClient;
using System;

namespace MiniPOS.Database
{
    public static class ConexionDB
    {
 
        private const string Server = "localhost";
        private const string Database = "minipos";
        private const string User = "root";
        private const string Password = "1234";  // tu contraseña

        private static readonly string _connectionString =
            $"Server={Server};Database={Database};Uid={User};Pwd={Password};CharSet=utf8mb4;";

        public static MySqlConnection ObtenerConexion()
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        public static bool ProbarConexion()
        {
            try
            {
                using var conn = ObtenerConexion();
                return conn.State == System.Data.ConnectionState.Open;
            }
            catch { return false; }
        }
    }
}