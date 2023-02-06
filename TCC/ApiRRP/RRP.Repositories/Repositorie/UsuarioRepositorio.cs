using RRP.Domains.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RRP.Repositories;

namespace RRP.Repositories.Repositorie
{
    public class UsuarioRepositorio : Contexto
    {
        public UsuarioRepositorio(IConfiguration configuration) : base(configuration)
        {
        }

        public Usuario? ObterUsuarioPorCredenciais(string email, string senha)
        {
            string comandoSql = @"SELECT EmailUsuario, NomeUsuario FROM Usuario
                                    WHERE EmailUsuario = @email AND Senha = @senha";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Usuario()
                        {
                            Nome = rdr["NomeUsuario"].ToString(),
                            Email = rdr["EmailUsuario"].ToString(),
                            CargoUsuario = EnumCargoUsuario.Funcionario
                        };
                    }
                    else
                        return null;
                }
            }
        }
    }
}
