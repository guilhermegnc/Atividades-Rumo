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
    public class CargoService
    {
        private readonly CargoRepositorio _repositorio;
        public CargoService(CargoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Cargo> Listar()
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarCargos();
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public Cargo Obter(int Id)
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
        public void Atualizar(Cargo model)
        {
            try
            {
                ValidarModelCargo(model);
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
        public void Inserir(Cargo model)
        {
            try
            {
                ValidarModelCargo(model);
                _repositorio.AbrirConexao();
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }

        private static void ValidarModelCargo(Cargo model)
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
