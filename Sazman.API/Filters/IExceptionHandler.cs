using Microsoft.AspNetCore.Mvc.Filters;

namespace Sazman.API.Filters
{
    public interface IExceptionHandler : IFilterMetadata
    {
        void OnException(ExceptionContext context);
    }
}
