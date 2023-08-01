
namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ExperiencesController : BaseApiController
{
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetExperiencesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> GetAllExperinces()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetExperiencesQuery()));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ManageGetExperiencesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> ManageGetAllExperinces()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new ManageGetExperiencesQuery()));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetExperienceQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetExperienceQuery(id)));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateExperienceCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] CreateExperienceCommand createExperienceCommand)
    {
        return GetResponseOnlyResultData(await Mediator.Send(createExperienceCommand));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromForm] DeleteExperienceCommand deleteExperienceCommand)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(deleteExperienceCommand));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateExperienceCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPut]
    public async Task<IActionResult> Put([FromQuery] UpdateExperienceCommand updateExperienceCommand)
    {
        return GetResponseOnlyResultData(await Mediator.Send(updateExperienceCommand));
    }
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete("perma")]
    public async Task<IActionResult> PermaDelete([FromForm] PermaDeleteExperienceCommand permaDeleteExperienceCommand)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(permaDeleteExperienceCommand));
    }

}
