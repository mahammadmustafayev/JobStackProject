

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class JobAppliesController : BaseApiController
{
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SendJobApplytoCompany))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] SendJobApplytoCompany send)
    {
        return GetResponseOnlyResultData(await Mediator.Send(send));
    }
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetJobAppliesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> GetAllExperinces()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetJobAppliesQuery()));
    }
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ManageGetJobAppliesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> ManageGetAllExperinces()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new ManageGetJobAppliesQuery()));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetJobApplyQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetJobApplyQuery(id)));
    }
}
