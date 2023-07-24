using ApiUI.Controllers;
using JobStack.Application.Handlers.Categories.Commands.CreateCategory;
using JobStack.Application.Handlers.Categories.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : BaseApiController
{
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateCategoryCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] CreateCategoryCommand createCategoryCommand)
    {
        return GetResponseOnlyResultData(await Mediator.Send(createCategoryCommand));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCategoriesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetCategoriesQuery()));
    }
}
