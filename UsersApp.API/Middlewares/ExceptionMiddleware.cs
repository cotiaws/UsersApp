using Newtonsoft.Json;
using System.Net;

namespace UsersApp.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Método para interceptar as requisições e capturar os erros
        /// </summary>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(ApplicationException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Método realizar o tratamento de cada tipo de exceção
        /// </summary>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var message = string.Empty;

            switch(exception)
            {
                case ApplicationException:
                    context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;

                default:
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    break;
            }

            //Retornando a resposta de erro
            await context.Response.WriteAsync(new ErrorDetailsModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }

    public class ErrorDetailsModel
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
