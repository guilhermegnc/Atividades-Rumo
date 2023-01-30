using ApiPonto.Domain.Exceptions;
using ApiPonto.Domain.Models;
using ApiPonto.Repositories.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiPonto.Services
{
    public class EquipeService
    {
        private readonly EquipeRepositorio _repositorio;
        public EquipeService(EquipeRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Equipe> Listar()
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarEquipes();
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public Equipe Obter(int Id)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.Obter(Id);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Atualizar(Equipe model)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Atualizar(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Deletar(int Id)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Deletar(Id);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Inserir(Equipe model)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
    }
}
