using LyncasAPI.DTO;
using LyncasAPI.Models;

namespace LyncasAPI.Repositorio
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly DataContext _context;

        public PessoaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Pessoa> ListarUsuarioLogin(LoginDTO loginDTO)
        {
            Pessoa? pessoa = await _context.Pessoa.Include(x => x.autenticacao)
                .FirstOrDefaultAsync(x => x.Email == loginDTO.Email);
            return pessoa;
        }

        public async Task<IEnumerable<Pessoa>> ListarTodosOsUsuarios()
        {
            List<Pessoa> lista = await _context.Pessoa.Include(Pessoa => Pessoa.autenticacao)
                .AsNoTracking()
                .ToListAsync();
            return lista;
        }

        public async Task<Pessoa> ListarUsuarioPorID(int id)
        {
            Pessoa? usuario = await _context.Pessoa
                .Include(Pessoa => Pessoa.autenticacao)
                .FirstOrDefaultAsync(u => u.IdPessoa == id);
            return usuario;
        }

        public async Task<Pessoa> AdicionarUsuario(Pessoa pessoa)
        {
            await _context.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa> AtualizarUsuario(Pessoa usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task ExcluirUsuario(int id)
        {
            Pessoa usuario = await ListarUsuarioPorID(id);
            _context.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }

}

