using ApiPonto.Domain.Exceptions;
using ApiPonto.Domain.Models;
using ApiPonto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ApiPonto.Controllers
{
    [Authorize]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly CargoService _service;
        public CargoController(CargoService service)
        {
            _service = service;
        }

        [Authorize(Roles = "1")]
        [HttpGet("Cargo")]
        public IActionResult Listar()
        {
            return StatusCode(200, _service.Listar());
        }

        //[Authorize(Roles = "1")]
        [HttpGet("Cargo/{cargoId}")]
        public IActionResult ObterPorId([FromRoute] int cargoId)
        {
            return StatusCode(200, _service.Obter(cargoId));
        }

        [Authorize(Roles = "1")]
        [HttpPost("Cargo")]
        public IActionResult Inserir([FromBody] Cargo model)
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
        [HttpDelete("Cargo/{cargoId}")]
        public IActionResult Deletar([FromRoute] int cargoId)
        {
            _service.Deletar(cargoId);
            return StatusCode(200);
        }

        [Authorize(Roles = "1")]
        [HttpPut("Cargo")]
        public IActionResult Atualizar([FromBody] Cargo model)
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
