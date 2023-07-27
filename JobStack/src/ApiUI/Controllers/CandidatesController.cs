using ApiUI.Controllers;
using JobStack.Application.Handlers.Candidates.Commands;
using JobStack.Application.Handlers.Candidates.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidatesController : BaseApiController
{
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManageCreateCandidateCommand))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] ManageCreateCandidateCommand create)
    {
        return GetResponseOnlyResultData(await Mediator.Send(create));
    }

    //[AllowAnonymous]
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCandidatesQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpGet]
    public async Task<IActionResult> GetAllCandidates()
    {
        return GetResponseOnlyResultData(await Mediator.Send(new GetCandidatesQuery()));
    }
}
