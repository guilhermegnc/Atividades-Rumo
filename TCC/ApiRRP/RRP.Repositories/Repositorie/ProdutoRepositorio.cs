using RRP.Domains.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RRP.Repositories.Repositorie
{
    public class ProdutoRepositorio : Contexto
    {
        public ProdutoRepositorio(IConfiguration configuration) : base(configuration)
        {
        }

        public void Inserir(ProdutoInsert model)
        {
           string comandoSql = @"INSERT INTO Produtos 
                                    (Nome, Preco, DataCadastro, Situacao) 
                                        VALUES
                                    (@Nome, @Preco, @DataCadastro, @Situacao);";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@Preco", model.Preco);
                cmd.Parameters.AddWithValue("@DataCadastro", DateTime.Now);
                cmd.Parameters.AddWithValue("@Situacao", true);
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(ProdutoInsert model)
        {
            string comandoSql = @"UPDATE Produtos 
                                    SET Situacao = false
                                WHERE Nome = @Nome AND Preco != @Preco";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@Preco", model.Preco);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o nome {model.Nome}");
            }
        }
        public bool SeExiste(string Nome)
        {
            string comandoSql = @"SELECT COUNT(Nome) as total FROM Produtos WHERE Nome = @Nome";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@Nome", Nome);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        public List<ListaProdutos> ListarProdutos()
        {
            string comandoSql = @"SELECT Nome, Preco, DataCadastro, Situacao, 
		                            Preco-PrecoAnterior AS DiferencaPreco, 
                                    (Preco-PrecoAnterior) / PrecoAnterior * 100 AS PorcentagemDiferenca
                                FROM (SELECT Nome, Preco, DataCadastro, Situacao,
                                        LAG(Preco) OVER (PARTITION BY Nome ORDER BY DataCadastro) AS PrecoAnterior
		                                From Produtos) x
                                where Situacao != false";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    var produtos = new List<ListaProdutos>();
                    while (rdr.Read())
                    {
                        var produto = new ListaProdutos();
                        produto.Nome = Convert.ToString(rdr["Nome"]);
                        produto.Preco = Convert.ToDecimal(rdr["Preco"]);
                        produto.DataCadastro = Convert.ToDateTime(rdr["DataCadastro"]);
                        produto.Situacao = Convert.ToBoolean(rdr["Situacao"]);
                        produto.DiferencaPreco = rdr["DiferencaPreco"] == DBNull.Value ? null : Convert.ToDecimal(rdr["DiferencaPreco"]);
                        produto.PorcentagemDiferenca = rdr["PorcentagemDiferenca"] == DBNull.Value ? null : Convert.ToDecimal(rdr["PorcentagemDiferenca"]);
                        produtos.Add(produto);
                    }
                    return produtos;
                }
            }
        }
        public void Deletar(string Nome)
        {
            string comandoSql = @"DELETE FROM Produtos 
                                WHERE Nome = @Nome;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@Nome", Nome);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o nome {Nome}");
            }
        }
    }
}
