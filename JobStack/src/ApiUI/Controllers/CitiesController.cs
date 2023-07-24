using ApiUI.Controllers;
using JobStack.Application.Handlers.Cities.Commands.CreateCity;
using JobStack.Application.Handlers.Cities.Commands.DeleteCity;
using JobStack.Application.Handlers.Cities.Commands.PermaDeleteCity;
using JobStack.Application.Handlers.Cities.Commands.UpdateCity;
using JobStack.Application.Handlers.Cities.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : BaseApiController
{
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCitiesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> GetAllCities()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetCitiesQuery()));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateCityCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] CreateCityCommand createCityCommand)
    {
        return GetResponseOnlyResultData(await Mediator.Send(createCityCommand));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromForm] DeleteCityCommand deleteCityCommand)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(deleteCityCommand));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateCityCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPut]
    public async Task<IActionResult> Put([FromQuery] UpdateCityCommand updateCityCommand)
    {
        return GetResponseOnlyResultData(await Mediator.Send(updateCityCommand));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete("perma")]
    public async Task<IActionResult> PermaDelete([FromForm] PermaDeleteCityCommand permaDeleteCityCommand)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(permaDeleteCityCommand));
    }



}
