using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Application.BusinessInterface;
using WebApp.Application.Dto;
using WebApp.Application.Dto.Usuario;
using WebApp.Bussines;

namespace WebApp.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBussines _loginBussines;
        private IUsuarioBusiness _usuarioBussines;

        public AuthController(ILoginBussines loginBussines, IUsuarioBusiness usuarioBussines)
        {
            _loginBussines = loginBussines;
            _usuarioBussines = usuarioBussines;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UsuarioDbo usuario)
        {
            if (usuario == null) return BadRequest("Invalid client request");

            var token = _loginBussines.ValidarCredenciais(usuario);
            if (token == null) return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenDbo tokendDbo)
        {
            if (tokendDbo == null) return BadRequest("Invalid client request");

            var token = _loginBussines.ValidarCredenciais(tokendDbo);
            if (token == null) return BadRequest("Invalid client request");

            return Ok(token);
        }

        [HttpPost]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var usuarioNome = User.Identity.Name;
            var result = _loginBussines.RevokeToken(usuarioNome);
            if (!result) return BadRequest("Invalid client request");

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromQuery] CriarUsuarioDbo usuario)
        {
            try
            {
                _usuarioBussines.Criar(usuario);

                return Ok($"Usuário {usuario.NomeCompleto} criado com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("validate-token")]
        [Authorize("Bearer")]
        public IActionResult ValidateToken()
        {
            return Ok(new { valid = true });
        }
    }
}