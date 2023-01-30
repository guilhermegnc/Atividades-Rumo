using ApiPonto.Domain.Exceptions;
using ApiPonto.Domain.Models;
using ApiPonto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPonto.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _service;
        public FuncionarioController(FuncionarioService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "1")]
        [HttpGet("Funcionario")]
        [ProducesResponseType(typeof(Funcionarios), 200)]
        [ProducesResponseType(401)]
        public IActionResult Listar([FromQuery] string? nomeDoFuncionário)
        {
            return StatusCode(200, _service.Listar(nomeDoFuncionário));
        }

        //[Authorize(Roles = "1")]
        [HttpGet("Funcionario/{Cpf}")]
        public IActionResult ObterPorCPF([FromRoute] string? Cpf)
        {
            return StatusCode(200, _service.Obter(Cpf));
        }

        //[Authorize(Roles = "1")]
        [HttpPost("Funcionario")]
        public IActionResult Inserir([FromBody] Funcionarios model)
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
        [HttpDelete("Funcionario/{Cpf}")]
        public IActionResult Deletar([FromRoute] string? Cpf)
        {
            _service.Deletar(Cpf);
            return StatusCode(200);
        }

        //[Authorize(Roles = "1")]
        [HttpPut("Funcionario")]
        public IActionResult Atualizar([FromBody] Funcionarios model)
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

