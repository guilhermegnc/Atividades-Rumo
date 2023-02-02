using RRP.Domains.Exceptions;
using RRP.Domains.Models;
using RRP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPonto.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;
        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "1")]
        [HttpGet("Funcionario")]
        [ProducesResponseType(typeof(Produto), 200)]
        [ProducesResponseType(401)]
        public IActionResult Listar([FromQuery] string? nomeDoFuncionário)
        {
            return StatusCode(200, _service.Listar(nomeDoFuncionário));
        }

        //[Authorize(Roles = "1")]
        [HttpPost("Funcionario")]
        public IActionResult Inserir([FromBody] Produto model)
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

        //[Authorize(Roles = "1")]
        [HttpDelete("Funcionario/{Nome}")]
        public IActionResult Deletar([FromRoute] string? Nome)
        {
            _service.Deletar(Nome);
            return StatusCode(200);
        }
    }
}

