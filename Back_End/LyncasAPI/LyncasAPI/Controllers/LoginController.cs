using LyncasAPI.DTO;
using LyncasAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LyncasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginservice;

        public LoginController(ILoginService loginservice)
        {
            _loginservice = loginservice;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UsuarioResponseDTO>> AutenticarUsuario(LoginDTO loginDTO)
        {
            return await _loginservice.AutenticarUsuario(loginDTO);
        }
    }
}
