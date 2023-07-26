using ApiUI.Controllers;
using JobStack.Application.Handlers.Categories.Commands.CreateCategory;
using JobStack.Application.Handlers.Categories.Commands.DeleteCategory;
using JobStack.Application.Handlers.Categories.Commands.PermaDeleteCategory;
using JobStack.Application.Handlers.Categories.Commands.UpdateCategory;
using JobStack.Application.Handlers.Categories.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : BaseApiController
{
    //[Authorize(Roles = "superadmin")]
    //[Authorize(Roles = "moderator")]

    //[Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateCategoryCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] CreateCategoryCommand createCategoryCommand)
    {
        return GetResponseOnlyResultData(await Mediator.Send(createCategoryCommand));
    }

    [AllowAnonymous]
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCategoriesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetCategoriesQuery()));
    }

    //[Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateCategoryCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPut]
    public async Task<IActionResult> Put([FromQuery] UpdateCategoryCommand update)
    {
        return GetResponseOnlyResultData(await Mediator.Send(update));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete("perma")]
    public async Task<IActionResult> PermaDelete([FromForm] PermaDeleteCategoryCommand perma)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(perma));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromForm] DeleteCategoryCommand delete)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(delete));
    }
}
