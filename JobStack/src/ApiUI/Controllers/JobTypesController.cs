using ApiUI.Controllers;
using JobStack.Application.Handlers.JobTypes.Commands.CreateJobType;
using JobStack.Application.Handlers.JobTypes.Commands.DeleteJobType;
using JobStack.Application.Handlers.JobTypes.Commands.PermaDeleteJobType;
using JobStack.Application.Handlers.JobTypes.Commands.UpdateJobType;
using JobStack.Application.Handlers.JobTypes.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobTypesController : BaseApiController
{
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetJobTypesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> GetAllCities()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetJobTypesQuery()));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateJobTypeCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] CreateJobTypeCommand create)
    {
        return GetResponseOnlyResultData(await Mediator.Send(create));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromForm] DeleteJobTypeCommand delete)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(delete));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateJobTypeCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPut]
    public async Task<IActionResult> Put([FromQuery] UpdateJobTypeCommand update)
    {
        return GetResponseOnlyResultData(await Mediator.Send(update));
    }

    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [HttpDelete("perma")]
    public async Task<IActionResult> PermaDelete([FromForm] PermaDeleteJobTypeCommand perma)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(perma));
    }
}
