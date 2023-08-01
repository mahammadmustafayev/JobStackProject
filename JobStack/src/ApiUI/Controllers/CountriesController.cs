

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CountriesController : BaseApiController
{
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCountriesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> GetAllCountries()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetCountriesQuery()));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ManageGetCountriesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> ManageGetAllCountries()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new ManageGetCountriesQuery()));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateCountryCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] CreateCountryCommand createCountryCommand)
    {
        return GetResponseOnlyResultData(await Mediator.Send(createCountryCommand));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateCountryCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPut]
    public async Task<IActionResult> Put([FromQuery] UpdateCountryCommand updateCountryCommand)
    {
        return GetResponseOnlyResultData(await Mediator.Send(updateCountryCommand));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromForm] DeleteCountryCommand deleteCountryCommand)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(deleteCountryCommand));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete("perma")]
    public async Task<IActionResult> PermaDelete([FromForm] PermaDeleteCountryCommand perma)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(perma));
    }


}
