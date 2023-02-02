using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRP.Repositories
{
    public class Contexto
    {
        internal readonly MySqlConnection _conn;
        public Contexto(IConfiguration configuration)
        {
            _conn = new MySqlConnection("Server=localhost;UID=root;Password=240998gui;Database=database_rrp;Port=3006;");
            //_conn = new MySqlConnection(configuration["DbCredentials"]);
        }

        public void AbrirConexao()
        {
            _conn.Open();
        }

        public void FecharConexao()
        {
            _conn.Close();
        }
    }
}
