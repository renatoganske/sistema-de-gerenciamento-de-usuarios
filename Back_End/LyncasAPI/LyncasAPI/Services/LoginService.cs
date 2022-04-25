using AutoMapper;
using LyncasAPI.DTO;
using LyncasAPI.Hash;
using LyncasAPI.Interfaces;

namespace LyncasAPI.Repositorio
{
    public class LoginService : ILoginService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        public LoginService(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioResponseDTO> AutenticarUsuario(LoginDTO loginDTO)
        {
            loginDTO.Senha = HashDaSenha.ImplementaHashDaSenha(loginDTO.Senha);
            var usuarioLogin = await _pessoaRepository.ListarUsuarioLogin(loginDTO);

            if (usuarioLogin == null || usuarioLogin.autenticacao.Senha != loginDTO.Senha)
            {
                throw new BadHttpRequestException("Usuário não autorizado.", 401);
            }

            return _mapper.Map<UsuarioResponseDTO>(usuarioLogin);
        }
    }
}
