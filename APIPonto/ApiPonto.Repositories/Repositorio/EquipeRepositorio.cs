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
    public class EquipeRepositorio : Contexto
    {
        public EquipeRepositorio(IConfiguration configuration) : base(configuration)
        {
        }

        public void Inserir(Equipe model)
        {
            string comandoSql = @"INSERT INTO Equipes 
                                    (LiderancaId, FuncionarioId) 
                                        VALUES
                                    (@LiderancaId, @FuncionarioId);";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", model.LiderancaId);
                cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(Equipe model)
        {
            string comandoSql = @"UPDATE Equipes 
                                SET 
                                    LiderancaId = @LiderancaId,
                                    FuncionarioId = @FuncionarioId
                                WHERE EquipeId = @EquipeId;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@EquipeId", model.Id);
                cmd.Parameters.AddWithValue("@LiderancaId", model.LiderancaId);
                cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o IdentificadorProduto {model.Id}");
            }
        }
        public bool SeExiste(int Id)
        {
            string comandoSql = @"SELECT COUNT(EquipeId) as total FROM Equipes WHERE EquipeId = @EquipeId";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@EquipeId", Id);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public Equipe? Obter(int Id)
        {
            string comandoSql = @"SELECT EquipeId, LiderancaId, FuncionarioId FROM Equipes WHERE EquipeId = @EquipeId";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@EquipeId", Id);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        var equipe = new Equipe();
                        equipe.Id = Convert.ToInt32(rdr["EquipeId"]);
                        equipe.LiderancaId = Convert.ToInt32(rdr["LiderancaId"]);
                        equipe.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                        return equipe;
                    }
                    else
                        return null;
                }
            }
        }
        public List<Equipe> ListarEquipes()
        {
            string comandoSql = @"SELECT EquipeId, LiderancaId, FuncionarioId FROM Equipes";


            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    var equipes = new List<Equipe>();
                    while (rdr.Read())
                    {
                        var equipe = new Equipe();
                        equipe.Id = Convert.ToInt32(rdr["EquipeId"]);
                        equipe.LiderancaId = Convert.ToInt32(rdr["LiderancaId"]);
                        equipe.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                        equipes.Add(equipe);
                    }
                    return equipes;
                }
            }
        }
        public void Deletar(int Id)
        {
            string comandoSql = @"DELETE FROM Equipes 
                                WHERE EquipeId = @EquipeId;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@EquipeId", Id);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o IdentificadorProduto {Id}");
            }
        }
    }
}
