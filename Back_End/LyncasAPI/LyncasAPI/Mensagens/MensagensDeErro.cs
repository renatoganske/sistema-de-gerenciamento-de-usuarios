namespace LyncasAPI.Mensagens
{
    public class MensagensDeErro
    {
        public MensagensDeErro()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<DetalhesDoErro>();
        }

        public MensagensDeErro(int logref, string message, int statusCode = 500)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<DetalhesDoErro>();
            AddError(logref, message, statusCode);
        }

        public string TraceId { get; private set; }
        public List<DetalhesDoErro> Errors { get; private set; }

        public class DetalhesDoErro
        {
            public DetalhesDoErro(int logref, string message, int statusCode)
            {
                Logref = logref;
                Message = message;
                StatusCode = statusCode;
            }

            public int Logref { get; private set; }
            public string Message { get; private set; }
            public int StatusCode { get; private set; }
        }
        public void AddError(int logref, string message, int statusCode)
        {
            Errors.Add(new DetalhesDoErro(logref, message, statusCode));
        }
    }
}
