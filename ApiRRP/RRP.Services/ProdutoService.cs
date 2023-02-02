using RRP.Domains.Exceptions;
using RRP.Domains.Models;
using RRP.Repositories.Repositorie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RRP.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepositorio _repositorio;
        public ProdutoService(ProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<ListaProdutos> Listar(string? nome)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarProdutos(nome);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }

        public void Deletar(string Cpf)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Deletar(Cpf);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Inserir(Produto model)
        {
            try
            {
                ValidarModelProduto(model);
                _repositorio.AbrirConexao();
                var existe = _repositorio.SeExiste(model.Nome);
                if (existe) _repositorio.Atualizar(model);
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }

        private static void ValidarModelProduto(Produto model)
        {
            if (model is null)
                throw new ValidacaoException("O json está mal formatado, ou foi enviado vazio.");


            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new ValidacaoException("O nome e obrigatório.");

            if (model.Nome.Trim().Length < 3 || model.Nome.Trim().Length > 255)
                throw new ValidacaoException("O nome precisa ter entre 3 a 255 caracteres.");

            if (ObterTempo(model.DataCadastro) < 0)
                throw new ValidacaoException("Tempo do cadastro é invalido.");

            model.Nome = model.Nome.Trim();
        }

        private static int ObterTempo(DateTime date)
        {
            var today = DateTime.Today;
            var time = today.Year - date.Year;
            if (date > today.AddYears(-time)) time--;
            return time;
        }
    }
}
