using LyncasAPI.DTO;

namespace LyncasAPI.Interfaces
{
    public interface ILoginService
    {

        Task<UsuarioResponseDTO> AutenticarUsuario(LoginDTO loginDTO);
    }
}
