using ApiUI.Controllers;
using JobStack.Application.Handlers.JobApplies.Commands;
using Microsoft.AspNetCore.Mvc;

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]")]
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
}
