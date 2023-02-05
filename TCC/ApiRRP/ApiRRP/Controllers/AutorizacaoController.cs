using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using RRP.Services;
using RRP.Domains.Models;

namespace RPP.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class AutorizacaoController : ControllerBase
    {
        private readonly AutorizacaoService _service;
        public AutorizacaoController(AutorizacaoService service)
        {
            _service = service;
        }

        [ProducesResponseType(typeof(Token), 200)]
        [ProducesResponseType(401)]
        [HttpPost("Autorizacao")]
        public IActionResult Login([FromQuery] string email, string senha)
        {      
            try
            {                
                var token = _service.Login(email, senha);
                return StatusCode(200, token);
            }
            catch (Exception)
            {
                return StatusCode(401);
            }
        }
    }
}
