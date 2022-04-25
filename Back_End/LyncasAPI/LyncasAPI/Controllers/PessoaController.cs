using LyncasAPI.Authorization;
using LyncasAPI.DTO;
using LyncasAPI.Interfaces;
using LyncasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace LyncasAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet("ListarTodosOsUsuarios")]
        public async Task<ActionResult<IEnumerable>> ListarTodosOsUsuarios()
        {
            return Ok(await _service.ListarTodosOsUsuarios());
        }

        [HttpGet("ListarUsuario{id}")]
        public async Task<ActionResult<Pessoa>> ListarUsuarioPorId(int id)
        {
            var usuario = await _service.ListarUsuarioPorId(id);
            return Ok(usuario);
        }

        [HttpPost("AdicionarUsuario")]
        public async Task<ActionResult<UsuarioResponseDTO>> AdicionarUsuario(UsuarioDTO usuario)
        {
            return await _service.AdicionarUsuario(usuario);
        }

        [HttpPut("Atualizar{id}")]
        public async Task<ActionResult<List<UsuarioDTO>>> AtualizarUsuario(int id, UsuarioDTO request)
        {
            await _service.AtualizarUsuario(id, request);
            return Ok("Usuário atualizado com sucesso.");
        }

        [HttpDelete("Excluir{id}")]
        public async Task<ActionResult> ExcluirUsuario(int id)
        {
            await _service.ExcluirUsuario(id);
            return Ok("Usuário excluído com sucesso.");
        }
    }
}
