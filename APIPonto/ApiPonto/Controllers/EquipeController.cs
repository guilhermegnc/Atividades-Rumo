using ApiPonto.Domain.Exceptions;
using ApiPonto.Domain.Models;
using ApiPonto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPonto.Controllers
{
    [Authorize]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly EquipeService _service;
        public EquipeController(EquipeService service)
        {
            _service = service;
        }


        [Authorize(Roles = "1,2")]
        [HttpGet("Equipe")]
        public IActionResult Listar()
        {
            return StatusCode(200, _service.Listar());
        }

        [Authorize(Roles = "1,2")]
        [HttpGet("Equipe/{equipeId}")]
        public IActionResult ObterPorId([FromRoute] int equipeId)
        {
            return StatusCode(200, _service.Obter(equipeId));
        }

        [Authorize(Roles = "1,2")]
        [HttpPost("Equipe")]
        public IActionResult Inserir([FromBody] Equipe model)
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
        [HttpDelete("Equipe/{equipeId}")]
        public IActionResult Deletar([FromRoute] int equipeId)
        {
            _service.Deletar(equipeId);
            return StatusCode(200);
        }

        [Authorize(Roles = "1")]
        [HttpPut("Equipe")]
        public IActionResult Atualizar([FromBody] Equipe model)
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
