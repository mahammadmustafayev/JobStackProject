using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace ApiUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    //private IMediator _mediator;
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    [ApiExplorerSettings(IgnoreApi = true)]
    public static IActionResult GetResponseOnlyResultMessage(JobStack.Application.Common.Results.IResult result)
    {
        return result.Success ? new OkObjectResult(result.Message) : new BadRequestObjectResult(result.Message);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public static IActionResult GetResponseOnlyResultData<T>(JobStack.Application.Common.Results.IDataResult<T> result)
    {
        return result.Success ? new OkObjectResult(result.Data) : new BadRequestObjectResult(result.Message);
    }
}
