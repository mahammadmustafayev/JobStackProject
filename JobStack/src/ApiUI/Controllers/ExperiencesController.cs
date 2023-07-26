using ApiUI.Controllers;
using JobStack.Application.Handlers.Experiences.Commands.CreateExperience;
using JobStack.Application.Handlers.Experiences.Commands.DeleteExperience;
using JobStack.Application.Handlers.Experiences.Commands.PermaDeleteExperience;
using JobStack.Application.Handlers.Experiences.Commands.UpdateExperience;
using JobStack.Application.Handlers.Experiences.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]")]
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
