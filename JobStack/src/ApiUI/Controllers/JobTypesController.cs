

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class JobTypesController : BaseApiController
{
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetJobTypesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> GetAllTypes()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetJobTypesQuery()));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetJobTypeQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetJobTypeQuery(id)));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ManageGetJobTypesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> ManageGetAllTypes()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new ManageGetJobTypesQuery()));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateJobTypeCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Add([FromQuery] CreateJobTypeCommand create)
    {
        return GetResponseOnlyResultData(await Mediator.Send(create));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpPost]
    // ("status/{id}")
    public async Task<IActionResult> Delete(int id)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(new DeleteJobTypeCommand(id)));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateJobTypeCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] UpdateJobTypeCommand update)
    {
        return GetResponseOnlyResultData(await Mediator.Send(update));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpPost]
    public async Task<IActionResult> PermaDelete(int id)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(new PermaDeleteJobTypeCommand(id)));
    }
}
