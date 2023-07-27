using ApiUI.Controllers;
using JobStack.Application.Handlers.Vacancies.Commands.CreateVacancy;
using JobStack.Application.Handlers.Vacancies.Commands.DeleteVacancy;
using JobStack.Application.Handlers.Vacancies.Commands.PermaDeleteVacancy;
using JobStack.Application.Handlers.Vacancies.Commands.UpdateVacancy;
using JobStack.Application.Handlers.Vacancies.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacanciesController : BaseApiController
{
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetVacanciesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> GetAllExperinces()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetVacanciesQuery()));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetVacancyQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetVacancyQuery(id)));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateVacancyCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] CreateVacancyCommand create)
    {
        return GetResponseOnlyResultData(await Mediator.Send(create));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromForm] DeleteVacancyCommand delete)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(delete));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateVacancyCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPut]
    public async Task<IActionResult> Put([FromQuery] UpdateVacancyCommand update)
    {
        return GetResponseOnlyResultData(await Mediator.Send(update));
    }
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete("perma")]
    public async Task<IActionResult> PermaDelete([FromForm] PermaDeleteVacancyCommand perma)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(perma));
    }
}
