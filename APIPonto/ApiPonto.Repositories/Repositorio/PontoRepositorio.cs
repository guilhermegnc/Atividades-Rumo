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
    public class PontoRepositorio : Contexto
    {
        public PontoRepositorio(IConfiguration configuration) : base(configuration)
        {
        }

        public void Inserir(Ponto model)
        {
            string comandoSql = @"INSERT INTO Ponto 
                                    (DataHorarioPonto, Justificativa, FuncionarioId) 
                                        VALUES
                                    (@DataHorarioPonto, @Justificativa, @FuncionarioId);";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@DataHorarioPonto", model.DataHorarioPonto);
                cmd.Parameters.AddWithValue("@Justificativa", model.Justificativa is null ? DBNull.Value : model.Justificativa);
                cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(Ponto model)
        {
            string comandoSql = @"UPDATE Ponto
                                SET 
                                    DataHorarioPonto = @DataHorarioPonto,
                                    Justificativa = @Justificativa,
                                    FuncionarioId = @FuncionarioId
                                WHERE PontoId = @PontoId;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@PontoId", model.Id);
                cmd.Parameters.AddWithValue("@DataHorarioPonto", model.DataHorarioPonto);
                cmd.Parameters.AddWithValue("@Justificativa", model.Justificativa is null ? DBNull.Value : model.Justificativa);
                cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o IdentificadorProduto {model.Id}");
            }
        }
        public bool SeExiste(int Id)
        {
            string comandoSql = @"SELECT COUNT(PontoId) as total FROM Ponto WHERE PontoId = @PontoId";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@PontoId", Id);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public Ponto? Obter(int Id)
        {
            string comandoSql = @"SELECT PontoId, DataHorarioPonto, Justificativa,
                                FuncionarioId FROM Ponto WHERE PontoId = @PontoId";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@PontoId", Id);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        var ponto = new Ponto();
                        ponto.Id = Convert.ToInt32(rdr["PontoId"]);
                        ponto.DataHorarioPonto = Convert.ToDateTime(rdr["DataHorarioPonto"]);
                        ponto.Justificativa = rdr["Justificativa"] == DBNull.Value ? null : Convert.ToString(rdr["Justificativa"]);
                        ponto.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                        return ponto;
                    }
                    else
                        return null;
                }
            }
        }
        public List<Ponto> ListarPontos()
        {
            string comandoSql = @"SELECT PontoId, DataHorarioPonto, Justificativa, FuncionarioId FROM Ponto";


            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    var pontos = new List<Ponto>();
                    while (rdr.Read())
                    {
                        var ponto = new Ponto();
                        ponto.Id = Convert.ToInt32(rdr["PontoId"]);
                        ponto.DataHorarioPonto = Convert.ToDateTime(rdr["DataHorarioPonto"]);
                        ponto.Justificativa = rdr["Justificativa"] == DBNull.Value ? null : Convert.ToString(rdr["Justificativa"]);
                        ponto.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                        pontos.Add(ponto);
                    }
                    return pontos;
                }
            }
        }
        public void Deletar(int Id)
        {
            string comandoSql = @"DELETE FROM Ponto 
                                WHERE PontoId = @PontoId;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@PontoId", Id);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o IdentificadorProduto {Id}");
            }
        }
    }
}
