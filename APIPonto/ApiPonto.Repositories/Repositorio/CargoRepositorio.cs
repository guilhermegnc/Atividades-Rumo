using ApiPonto.Domain.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPonto.Repositories.Repositorio
{
    public class CargoRepositorio : Contexto
    {
        public CargoRepositorio(IConfiguration configuration) : base(configuration)
        {
        }

        public void Inserir(Cargo model)
        {
            string comandoSql = @"INSERT INTO Cargos 
                                    (Descricao) 
                                        VALUE
                                    (@Descricao);";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@Descricao", model.Descricao);
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(Cargo model)
        {
            string comandoSql = @"UPDATE Cargos 
                                SET 
                                    Descricao = @Descricao
                                WHERE CargoId = @CargoId;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CargoId", model.Id);
                cmd.Parameters.AddWithValue("@Descricao", model.Descricao);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o IdentificadorProduto {model.Id}");
            }
        }
        public bool SeExiste(int Id)
        {
            string comandoSql = @"SELECT COUNT(CargoId) as total FROM Cargos WHERE CargoId = @CargoId";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CargoId", Id);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public Cargo? Obter(int Id)
        {
            string comandoSql = @"SELECT CargoId, Descricao FROM Cargos WHERE CargoId = @CargoId";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CargoId", Id);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        var cargo = new Cargo();
                        cargo.Id = Convert.ToInt32(rdr["CargoId"]);
                        cargo.Descricao = Convert.ToString(rdr["Descricao"]);
                        return cargo;
                    }
                    else
                        return null;
                }
            }
        }
        public List<Cargo> ListarCargos()
        {
            string comandoSql = @"SELECT CargoId, Descricao FROM Cargos";


            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    var cargos = new List<Cargo>();
                    while (rdr.Read())
                    {
                        var cargo = new Cargo();
                        cargo.Id = Convert.ToInt32(rdr["CargoId"]);
                        cargo.Descricao = Convert.ToString(rdr["Descricao"]);
                        cargos.Add(cargo);
                    }
                    return cargos;
                }
            }
        }
        public void Deletar(int Id)
        {
            string comandoSql = @"DELETE FROM Cargos 
                                WHERE CargoId = @CargoId;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CargoId", Id);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o IdentificadorProduto {Id}");
            }
        }
    }
}
