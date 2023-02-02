using ApiPonto.Domain.Exceptions;
using ApiPonto.Domain.Models;
using ApiPonto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPonto.Controllers
{
    [Authorize]
    [ApiController]
    public class LiderancaController : ControllerBase
    {
        private readonly LiderancaService _service;
        public LiderancaController(LiderancaService service)
        {
            _service = service;
        }

        [Authorize(Roles = "1,2")]
        [HttpGet("Lideranca")]
        public IActionResult Listar()
        {
            return StatusCode(200, _service.Listar());
        }

        [Authorize(Roles = "1,2")]
        [HttpGet("Lideranca/{liderancaId}")]
        public IActionResult ObterPorId([FromRoute] int liderancaId)
        {
            return StatusCode(200, _service.Obter(liderancaId));
        }

        [Authorize(Roles = "1,2")]
        [HttpPost("Lideranca")]
        public IActionResult Inserir([FromBody] Lideranca model)
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
        [HttpDelete("Lideranca/{liderancaId}")]
        public IActionResult Deletar([FromRoute] int liderancaId)
        {
            _service.Deletar(liderancaId);
            return StatusCode(200);
        }

        [Authorize(Roles = "1")]
        [HttpPut("Lideranca")]
        public IActionResult Atualizar([FromBody] Lideranca model)
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
