using LyncasAPI.DTO;

namespace LyncasAPI.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<UsuarioResponseDTO>> ListarTodosOsUsuarios();

        Task<UsuarioResponseDTO> ListarUsuarioPorId(int id);

        Task<UsuarioResponseDTO> AdicionarUsuario(UsuarioDTO usuarioDTO);

        Task<UsuarioDTO> AtualizarUsuario(int id, UsuarioDTO request);

        Task ExcluirUsuario(int id);
    }
}