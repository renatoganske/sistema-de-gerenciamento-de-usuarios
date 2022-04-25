using AutoMapper;
using LyncasAPI.DTO;
using LyncasAPI.Hash;
using LyncasAPI.Interfaces;
using LyncasAPI.Models;
using LyncasAPI.Repositorio;

namespace LyncasAPI.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;
        private readonly IMapper _mapper;
        public PessoaService(IPessoaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioResponseDTO>> ListarTodosOsUsuarios()

        {
            var lista = await _repository.ListarTodosOsUsuarios();

            List<UsuarioResponseDTO> pessoas = _mapper.Map<List<UsuarioResponseDTO>>(lista);
            return pessoas;
        }

        public async Task<UsuarioResponseDTO> ListarUsuarioPorId(int id)

        {
            var usuario = await _repository.ListarUsuarioPorID(id);

            if (usuario == null)
                throw new BadHttpRequestException("Usuário não encontrado.", 404);

            var pessoa = _mapper.Map<UsuarioResponseDTO>(usuario);
            return pessoa;
        }

        public async Task<UsuarioResponseDTO> AdicionarUsuario(UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Senha = HashDaSenha.ImplementaHashDaSenha(usuarioDTO.Senha);

            Pessoa usuario = _mapper.Map<Pessoa>(usuarioDTO);
            Pessoa novousuario = await _repository.AdicionarUsuario(usuario);

            return _mapper.Map<UsuarioResponseDTO>(novousuario);

            throw new Exception("Não foi possível adicionar o usuário.");
        }

        public async Task<UsuarioDTO> AtualizarUsuario(int id, UsuarioDTO request)

        {
            Pessoa usuario = await _repository.ListarUsuarioPorID(id);

            if (usuario == null)
                throw new BadHttpRequestException("Usuário não encontrado.", 404);

            if (request.Senha == null || request.Senha.Length == 0)
            {
                request.Senha = usuario.autenticacao.Senha;
            }

            if (request.Senha != null && request.Senha != "")
            {
                request.Senha = HashDaSenha.ImplementaHashDaSenha(request.Senha);
            }

            Pessoa pessoaDB = _mapper.Map(request, usuario);

            Pessoa pessoaAtt = await _repository.AtualizarUsuario(pessoaDB);
            return _mapper.Map<UsuarioDTO>(pessoaAtt);
            throw new Exception("Não foi possível executar a solicitação.");

        }

        public async Task ExcluirUsuario(int id)
        {
            var usuario = await _repository.ListarUsuarioPorID(id);
            if (usuario == null)
                throw new Exception("Usuário inexistente.");

            await _repository.ExcluirUsuario(id);
        }
    }
}

