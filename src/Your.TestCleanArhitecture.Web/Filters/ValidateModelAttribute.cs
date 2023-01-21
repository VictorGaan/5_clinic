using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Your.TestCleanArhitecture.Web.Filters;

/// <summary>
/// Этот фильтр больше не нужен, поскольку [ApiController] автоматически предоставляет его для API.
/// Как BaseApiController, так и все конечные точки Api в этом примере используют [Api Controller].
/// Этот файл включен, чтобы показать, как и где дополнительные пользовательские фильтры будут добавлены в ваш веб-проект.
/// </summary>
public class ValidateModelAttribute : ActionFilterAttribute
{
  public override void OnActionExecuting(ActionExecutingContext context)
  {
    if (!context.ModelState.IsValid)
    {
      context.Result = new BadRequestObjectResult(context.ModelState);
    }
  }
}
