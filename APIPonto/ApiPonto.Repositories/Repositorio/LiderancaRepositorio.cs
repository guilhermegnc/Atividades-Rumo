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
    public class LiderancaRepositorio : Contexto
    {
        public LiderancaRepositorio(IConfiguration configuration) : base(configuration)
        {
        }

        public void Inserir(Lideranca model)
        {
            string comandoSql = @"INSERT INTO Liderancas 
                                    (FuncionarioId, DescricaoEquipe) 
                                        VALUES
                                    (@FuncionarioId, @DescricaoEquipe);";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);
                cmd.Parameters.AddWithValue("@DescricaoEquipe", model.Descricao);
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(Lideranca model)
        {
            string comandoSql = @"UPDATE Liderancas 
                                SET 
                                    FuncionarioId = @FuncionarioId,
                                    DescricaoEquipe = @DescricaoEquipe
                                WHERE LiderancaId = @LiderancaId;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", model.Id);
                cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);
                cmd.Parameters.AddWithValue("@DescricaoEquipe", model.Descricao);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o IdentificadorProduto {model.Id}");
            }
        }
        public bool SeExiste(int Id)
        {
            string comandoSql = @"SELECT COUNT(LiderancaId) as total FROM Liderancas WHERE LiderancaId = @LiderancaId";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", Id);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public Lideranca? Obter(int Id)
        {
            string comandoSql = @"SELECT LiderancaId, FuncionarioId, DescricaoEquipe FROM Liderancas WHERE LiderancaId = @LiderancaId";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", Id);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        var lideranca = new Lideranca();
                        lideranca.Id = Convert.ToInt32(rdr["LiderancaId"]);
                        lideranca.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                        lideranca.Descricao = Convert.ToString(rdr["DescricaoEquipe"]);
                        return lideranca;
                    }
                    else
                        return null;
                }
            }
        }
        public List<Lideranca> ListarLiderancas()
        {
            string comandoSql = @"SELECT LiderancaId, FuncionarioId, DescricaoEquipe FROM Liderancas";


            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    var liderancas = new List<Lideranca>();
                    while (rdr.Read())
                    {
                        var lideranca = new Lideranca();
                        lideranca.Id = Convert.ToInt32(rdr["LiderancaId"]);
                        lideranca.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                        lideranca.Descricao = Convert.ToString(rdr["DescricaoEquipe"]);
                        liderancas.Add(lideranca);
                    }
                    return liderancas;
                }
            }
        }
        public void Deletar(int Id)
        {
            string comandoSql = @"DELETE FROM Liderancas 
                                WHERE LiderancaId = @LiderancaId;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", Id);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o IdentificadorProduto {Id}");
            }
        }
    }
}
