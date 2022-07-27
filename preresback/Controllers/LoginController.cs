using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using preresback.Domain.IServices;
using preresback.Domain.Models;
using preresback.Utils;
using System;
using System.Threading.Tasks;

namespace preresback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                var user = await _loginService.ValidateUser(usuario);
                if (user == null)
                {
                    return BadRequest(new { message = "Usuario o contraseña invalidos" });
                }

                return Ok(new { usuario = user.NombreUsuario });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
