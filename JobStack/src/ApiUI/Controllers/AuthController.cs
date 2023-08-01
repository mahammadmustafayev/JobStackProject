namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : BaseApiController
{
    [AllowAnonymous]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<LoginUserCommand>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromQuery] LoginUserCommand loginUserCommand)
    {
        var result = await Mediator.Send(loginUserCommand);
        return result.Success ? Ok(result) : Unauthorized(result.Message);
    }

    [AllowAnonymous]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResult))]
    [HttpPost("registerCandidate")]

    public async Task<IActionResult> RegisterCandidate([FromQuery] RegisterCandidateCommand registerCandidateCommand)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(registerCandidateCommand));
    }

    [AllowAnonymous]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResult))]
    [HttpPost("registerCompany")]

    public async Task<IActionResult> RegisterCompany([FromQuery] RegisterCompanyCommand registerCompanyCommand)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(registerCompanyCommand));
    }
}
