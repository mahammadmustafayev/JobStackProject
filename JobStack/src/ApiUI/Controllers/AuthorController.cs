namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthorController : BaseApiController
{
    //[AllowAnonymous]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<LoginUserCommand>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
    {
        var result = await Mediator.Send(loginUserCommand);
        return result.Success ? Ok(result) : Unauthorized(result.Message);
    }

    //[AllowAnonymous]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<SignOutCommand>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> SignOut(SignOutCommand signOut)
    {
        var result = await Mediator.Send(signOut);
        return result.Success ? Ok(result) : Unauthorized(result.Message);
    }

    //[AllowAnonymous]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Application.Common.Results.IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Application.Common.Results.IResult))]
    [HttpPost]

    public async Task<IActionResult> RegisterCandidate(RegisterCandidateCommand registerCandidateCommand)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(registerCandidateCommand));
    }

    //[AllowAnonymous]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Application.Common.Results.IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Application.Common.Results.IResult))]
    [HttpPost]

    public async Task<IActionResult> RegisterCompany(RegisterCompanyCommand registerCompanyCommand)
    {
        return GetResponseOnlyResultMessage(await Mediator.Send(registerCompanyCommand));
    }
}
