
using LyncasAPI.DTO;
using LyncasAPI.Interfaces;
using System.Net.Http.Headers;
using System.Text;


namespace LyncasAPI.Middlewares
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILoginService loginService)
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                var username = credentials[0];
                var password = credentials[1];

                LoginDTO loginDTO = new LoginDTO();
                loginDTO.Email = username;
                loginDTO.Senha = password;
                context.Items["Pessoa"] = await loginService.AutenticarUsuario(loginDTO);
            }
            catch
            {

            }

            await _next(context);
        }
    }
}
