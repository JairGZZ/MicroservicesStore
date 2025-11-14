using Microsoft.AspNetCore.Diagnostics;

namespace CatalogService.Exception
{
    
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Error no controlado: {Message} | Inner: {InnerMessage}",
                exception.Message,
                exception.InnerException?.Message);
            var response = new ErrorResponse();

            switch (exception)
            {
                case NotImplementedException:
                    response.Title = "Algo Salio Mal";
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.ExceptionMessage = exception.Message;
                    break;
                case UnauthorizedAccessException:
                    response.Title = "No esta Autorizado";
                    response.StatusCode = StatusCodes.Status401Unauthorized;
                    response.ExceptionMessage = exception.Message;
                    break;
                   
                default :
                    response.Title = "Error del Servidor";
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.ExceptionMessage = "Ocurrio un error inesperado";
                    response.ExceptionName = exception.GetType().Name;
                    break;

            }
          

            await httpContext.Response.WriteAsJsonAsync(response,cancellationToken);


            return true;

        }
    }
}
