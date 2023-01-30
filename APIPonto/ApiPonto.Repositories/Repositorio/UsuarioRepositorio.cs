using ApiPonto.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ApiPonto.Repositories.Repositorio
{
    public class UsuarioRepositorio : Contexto
    {
        public UsuarioRepositorio(IConfiguration configuration) : base(configuration)
        {
        }

        public Usuario? ObterUsuarioPorCredenciais(string email, string senha)
        {
            string comandoSql = @"SELECT u.EmailUsuario, u.NomeUsuario, u.CargoId FROM Usuario u
                                    JOIN Cargos c ON u.CargoId = c.CargoId
                                    WHERE u.EmailUsuario = @email AND u.SenhaUsuario = @senha";

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
                            CargoUsuario = (EnumCargoUsuario)Convert.ToInt32(rdr["CargoId"])
                        };
                    }
                    else
                        return null;
                }
            }
        }
    }
}
