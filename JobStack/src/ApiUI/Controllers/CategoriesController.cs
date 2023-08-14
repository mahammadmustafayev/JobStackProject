
using JobStack.Application.Handlers.Categories.Commands;

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : BaseApiController
{
    //[Authorize(Roles = "superadmin")]
    //[Authorize(Roles = "moderator")]

    //[Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManageCreateCategoryCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]ManageCreateCategoryCommand createCategoryCommand)
    {
        return GetResponseOnlyResultData(await Mediator.Send(createCategoryCommand));
    }

    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManageCreateCategoryCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> PostTest([FromQuery] ManageCreateCategoryCommandTest createCategoryCommand)
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

    [AllowAnonymous]
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCategoriesCountQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet("{count}")]
    public async Task<IActionResult> GetCountCategories(int count)
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetCategoriesCountQuery(count)));
    }

    [AllowAnonymous]
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ManageGetCategoriesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> ManageGetAllCategories()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new ManageGetCategoriesQuery()));
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
