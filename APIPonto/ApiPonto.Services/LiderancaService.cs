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
    public class LiderancaService
    {
        private readonly LiderancaRepositorio _repositorio;
        public LiderancaService(LiderancaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Lideranca> Listar()
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarLiderancas();
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public Lideranca Obter(int Id)
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
        public void Atualizar(Lideranca model)
        {
            try
            {
                ValidarModelLideranca(model);
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
        public void Inserir(Lideranca model)
        {
            try
            {
                ValidarModelLideranca(model);
                _repositorio.AbrirConexao();
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }

        private static void ValidarModelLideranca(Lideranca model)
        {
            if (model is null)
                throw new ValidacaoException("O json está mal formatado, ou foi enviado vazio.");

            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new ValidacaoException("A descricao e obrigatória.");

            if (model.Descricao.Trim().Length < 3 || model.Descricao.Trim().Length > 255)
                throw new ValidacaoException("A descricao precisa ter entre 3 a 255 caracteres.");

            model.Descricao = model.Descricao.Trim();
        }
    }
}
