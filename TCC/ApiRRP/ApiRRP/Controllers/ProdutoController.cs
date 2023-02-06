using RRP.Domains.Exceptions;
using RRP.Domains.Models;
using RRP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPonto.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;
        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet("Produto")]
        [ProducesResponseType(typeof(Produto), 200)]
        [ProducesResponseType(401)]
        public IActionResult Listar()
        {
            return StatusCode(200, _service.Listar());
        }

        [HttpPost("Produto")]
        public IActionResult Inserir([FromBody] ProdutoInsert model)
        {
            try
            {
                _service.Inserir(model);
                return StatusCode(201);
            }
            catch (ValidacaoException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPost("Produto/Robo")]
        public IActionResult InserirRobo()
        {
            try
            {
                _service.InserirRobo();
                return StatusCode(201);
            }
            catch (ValidacaoException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpDelete("Produto/{Nome}")]
        public IActionResult Deletar([FromRoute] string? Nome)
        {
            _service.Deletar(Nome);
            return StatusCode(200);
        }
    }
}

