
namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CompaniesController : BaseApiController
{
    // 2014-12-01 00:00:00.0000000
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManageCreateCompanyCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] ManageCreateCompanyCommand create)
    {
        return GetResponseOnlyResultData(await Mediator.Send(create));
    }

    //[AllowAnonymous]
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCompaniesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetCompaniesQuery()));
    }
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCompaniesCountQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet("{count}")]
    public async Task<IActionResult> GetCountCompanies(int count)
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetCompaniesCountQuery(count)));
    }

    //[AllowAnonymous]
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ManageGetCompaniesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> ManageGetAllCompanies()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new ManageGetCompaniesQuery()));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCompanyQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetCompanyQuery(id)));
    }

    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateCompanyCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPut]
    public async Task<IActionResult> Put([FromQuery] UpdateCompanyCommand update)
    {
        return GetResponseOnlyResultData(await Mediator.Send(update));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete("perma")]
    public async Task<IActionResult> PermaDelete([FromForm] PermaDeleteCompanyCommand perma)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(perma));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromForm] DeleteCompanyCommand delete)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(delete));
    }
}
