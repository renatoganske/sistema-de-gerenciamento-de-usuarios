using LyncasAPI.Mensagens;
using Newtonsoft.Json;

namespace LyncasAPI.Middlewares
{
    public class MiddlewareDeErro
    {
        private readonly RequestDelegate next;

        public MiddlewareDeErro(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (BadHttpRequestException ex)
            {
                MensagensDeErro mensagensDeErro = new(ex.HResult, ex.Message, ex.StatusCode);
                await HandleExceptionAsync(context, mensagensDeErro);
            }

            catch (Exception ex)
            {
                string Message = ex.HResult == -2146233088 ? "O email já existe." : ex.Message;
                MensagensDeErro mensagensDeErro = new(ex.HResult, Message);
                await HandleExceptionAsync(context, mensagensDeErro);
            }

        }

        private Task HandleExceptionAsync(HttpContext context, MensagensDeErro ex)
        {
            context.Response.StatusCode = ex.Errors[0].StatusCode;
            var result = JsonConvert.SerializeObject(ex.Errors[0]);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
