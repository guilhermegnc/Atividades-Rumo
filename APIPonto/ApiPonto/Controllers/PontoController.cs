using ApiPonto.Domain.Exceptions;
using ApiPonto.Domain.Models;
using ApiPonto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPonto.Controllers
{
    [Authorize]
    [ApiController]
    public class PontoController : ControllerBase
    {
        private readonly PontoService _service;
        public PontoController(PontoService service)
        {
            _service = service;
        }
       
        [HttpGet("Ponto")]
        public IActionResult Listar()
        {
            return StatusCode(200, _service.Listar());
        }

        [Authorize(Roles = "3")]
        [HttpGet("Ponto/{pontoId}")]
        public IActionResult ObterPorId([FromRoute] int pontoId)
        {
            return StatusCode(200, _service.Obter(pontoId));
        }
     
        [Authorize(Roles = "3")]
        [HttpPost("Ponto")]
        public IActionResult Inserir([FromBody] Ponto model)
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

        [Authorize(Roles = "1")]
        [HttpDelete("Ponto/{pontoId}")]
        public IActionResult Deletar([FromRoute] int pontoId)
        {
            _service.Deletar(pontoId);
            return StatusCode(200);
        }

        [Authorize(Roles = "1")]
        [HttpPut("Ponto")]
        public IActionResult Atualizar([FromBody] Ponto model)
        {
            try
            {
                _service.Atualizar(model);
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
    }
}
