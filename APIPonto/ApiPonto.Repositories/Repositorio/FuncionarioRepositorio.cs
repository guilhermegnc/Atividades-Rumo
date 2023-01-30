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
    public class FuncionarioRepositorio : Contexto
    {
        public FuncionarioRepositorio(IConfiguration configuration) : base(configuration)
        {
        }

        public void Inserir(Funcionarios model)
        {
            string comandoSql = @"INSERT INTO Funcionarios 
                                    (NomeDoFuncionario, Cpf, NascimentoFuncionario, DataDeAdmissao, CelularFuncionario,
                                     EmailFuncionario, CargoId) 
                                        VALUES
                                    (@NomeDoFuncionario, @Cpf, @NascimentoFuncionario, @DataDeAdmissao, @CelularFuncionario,
                                     @EmailFuncionario, @CargoId);";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@NomeDoFuncionario", model.Nome);
                cmd.Parameters.AddWithValue("@Cpf", model.Cpf);
                cmd.Parameters.AddWithValue("@NascimentoFuncionario", model.NascimentoFuncionario);
                cmd.Parameters.AddWithValue("@DataDeAdmissao", model.DataAdmissao);
                cmd.Parameters.AddWithValue("@CelularFuncionario", model.NumeroTelefone);
                cmd.Parameters.AddWithValue("@EmailFuncionario", model.Email);
                cmd.Parameters.AddWithValue("@CargoId", model.CargoId);
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(Funcionarios model)
        {
            string comandoSql = @"UPDATE Funcionarios 
                                SET 
                                    NomeDoFuncionario = @NomeDoFuncionario,
                                    CargoId = @CargoId,
                                    NascimentoFuncionario = @NascimentoFuncionario, 
                                    DataDeAdmissao = @DataDeAdmissao ,
                                    CelularFuncionario = @CelularFuncionario,
                                    EmailFuncionario = @EmailFuncionario
                                WHERE Cpf = @Cpf;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@Cpf", model.Cpf);
                cmd.Parameters.AddWithValue("@CargoId", model.CargoId);
                cmd.Parameters.AddWithValue("@NomeDoFuncionario", model.Nome);
                cmd.Parameters.AddWithValue("@NascimentoFuncionario", model.NascimentoFuncionario);
                cmd.Parameters.AddWithValue("@DataDeAdmissao", model.DataAdmissao);
                cmd.Parameters.AddWithValue("@CelularFuncionario", model.NumeroTelefone);
                cmd.Parameters.AddWithValue("@EmailFuncionario", model.Email);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o cpf {model.Cpf}");
            }
        }
        public bool SeExiste(string Cpf)
        {
            string comandoSql = @"SELECT COUNT(Cpf) as total FROM Funcionarios WHERE Cpf = @Cpf";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@Cpf", Cpf);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public Funcionarios? Obter(string Cpf)
        {
            string comandoSql = @"SELECT Cpf, NomeDoFuncionario, NascimentoFuncionario, 
                                DataDeAdmissao, CelularFuncionario, EmailFuncionario, CargoId FROM Funcionarios WHERE Cpf = @Cpf";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@Cpf", Cpf);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        var funcionario = new Funcionarios();
                        funcionario.Cpf = Convert.ToString(rdr["Cpf"]);
                        funcionario.Nome = Convert.ToString(rdr["NomeDoFuncionario"]);
                        funcionario.NascimentoFuncionario = Convert.ToDateTime(rdr["NascimentoFuncionario"]);
                        funcionario.DataAdmissao = Convert.ToDateTime(rdr["DataDeAdmissao"]);
                        funcionario.NumeroTelefone = Convert.ToString(rdr["CelularFuncionario"]);
                        funcionario.Email = Convert.ToString(rdr["EmailFuncionario"]);
                        funcionario.CargoId = Convert.ToInt32(rdr["CargoId"]);
                        return funcionario;
                    }
                    else
                        return null;
                }
            }
        }
        public List<Funcionarios> ListarFuncionarios(string? nome)
        {
            string comandoSql = @"SELECT Cpf, NomeDoFuncionario, NascimentoFuncionario, DataDeAdmissao, CelularFuncionario,
                                EmailFuncionario, CargoId FROM Funcionarios";

            if (!string.IsNullOrWhiteSpace(nome))
                comandoSql += " WHERE NomeDoFuncionario LIKE @nome";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                if (!string.IsNullOrWhiteSpace(nome))
                    cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");

                using (var rdr = cmd.ExecuteReader())
                {
                    var funcionarios = new List<Funcionarios>();
                    while (rdr.Read())
                    {
                        var funcionario = new Funcionarios();
                        funcionario.Cpf = Convert.ToString(rdr["Cpf"]);
                        funcionario.Nome = Convert.ToString(rdr["NomeDoFuncionario"]);
                        funcionario.NascimentoFuncionario = Convert.ToDateTime(rdr["NascimentoFuncionario"]);
                        funcionario.DataAdmissao = Convert.ToDateTime(rdr["DataDeAdmissao"]);
                        funcionario.NumeroTelefone = Convert.ToString(rdr["CelularFuncionario"]);
                        funcionario.Email = Convert.ToString(rdr["EmailFuncionario"]);
                        funcionario.CargoId = Convert.ToInt32(rdr["CargoId"]);
                        funcionarios.Add(funcionario);
                    }
                    return funcionarios;
                }
            }
        }
        public void Deletar(string Cpf)
        {
            string comandoSql = @"DELETE FROM Funcionarios 
                                WHERE Cpf = @Cpf;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@Cpf", Cpf);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o cpf {Cpf}");
            }
        }
    }
}
