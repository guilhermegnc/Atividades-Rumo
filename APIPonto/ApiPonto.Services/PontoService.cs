using ApiPonto.Domain.Exceptions;
using ApiPonto.Domain.Models;
using ApiPonto.Repositories.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPonto.Services
{
    public class PontoService
    {
        private readonly PontoRepositorio _repositorio;
        public PontoService(PontoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Ponto> Listar()
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarPontos();
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public Ponto Obter(int Id)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.SeExiste(Id);
                return _repositorio.Obter(Id);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Atualizar(Ponto model)
        {
            try
            {
                ValidarModelPonto(model);
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
        public void Inserir(Ponto model)
        {
            try
            {
                ValidarModelPonto(model);
                _repositorio.AbrirConexao();
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }

        private static void ValidarModelPonto(Ponto model)
        {
            if (model is null)
                throw new ValidacaoException("O json está mal formatado, ou foi enviado vazio.");
        }
    }
}
