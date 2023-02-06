using Robo.Model;
using Robo.Service;
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

        public List<ListaProdutos> Listar()
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarProdutos();
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
        public void Inserir(ProdutoInsert model)
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

        public void InserirRobo()
        {
            try
            {
                var produtos = CriarModel();
                _repositorio.AbrirConexao();
                foreach (var produto in produtos)
                {
                    var existe = _repositorio.SeExiste(produto.Nome);
                    if (existe) _repositorio.Atualizar(produto);
                    _repositorio.Inserir(produto);
                }
            }
            finally
            {
                _repositorio.FecharConexao();
            }
            
        }

        private static void ValidarModelProduto(ProdutoInsert model)
        {
            if (model is null)
                throw new ValidacaoException("O json está mal formatado, ou foi enviado vazio.");


            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new ValidacaoException("O nome e obrigatório.");

            if (model.Nome.Trim().Length < 3 || model.Nome.Trim().Length > 255)
                throw new ValidacaoException("O nome precisa ter entre 3 a 255 caracteres.");

            model.Nome = model.Nome.Trim();
        }

        private static List<ProdutoInsert> CriarModel()
        {
            var livros = Scrapping.ScrappingService();
            List<ProdutoInsert> produtos = new List<ProdutoInsert>();
            foreach(var livro in livros)
            {
                var produto = new ProdutoInsert();
                produto.Nome = livro.Titulo;
                produto.Preco = livro.Preco;

                produtos.Add(produto);
            }

            return produtos;
        }
    }
}
