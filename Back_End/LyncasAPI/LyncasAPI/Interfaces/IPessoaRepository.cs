using LyncasAPI.DTO;
using LyncasAPI.Models;

namespace LyncasAPI.Repositorio
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> ListarTodosOsUsuarios();
        Task<Pessoa> ListarUsuarioLogin(LoginDTO loginDTO);
        Task<Pessoa> ListarUsuarioPorID(int id);
        Task<Pessoa> AdicionarUsuario(Pessoa pessoa);
        Task<Pessoa> AtualizarUsuario(Pessoa usuario);
        Task ExcluirUsuario(int id);
    }
}