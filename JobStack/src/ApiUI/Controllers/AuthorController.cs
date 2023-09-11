using Newtonsoft.Json;

namespace JobStack.ApiUI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthorController : BaseApiController
{
    private readonly string root = Path.Combine(Directory.GetParent("src").Parent.ToString(), "WebUI", "wwwroot", "user", "identity.json");

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

    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<IActionResult> LoginTest(LoginPostCommand loginUserCommand)
    {

        var result = await Mediator.Send(loginUserCommand);
        //System.IO.File.WriteAllText(root, result.ToString());
        var test = JsonConvert.SerializeObject(result);
        //TestPost(test);
        return Ok(result);
    }

    //[Produces("application/json", "text/plain")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    //[HttpPost]
    //public async Task<IActionResult> TestPost(string command)
    //{

    //    var result = await Mediator.Send(command);


    //    // return result.Success ? Ok(result) : Unauthorized(result.Message);
    //    return Ok(result);

    //}



    //[Consumes("application/json")]
    //[Produces("application/json", "text/plain")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<object>))]
    //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    //[HttpGet]
    //public async Task<IActionResult> GetTest(object daa)
    //{
    //    return GetResponseOnlyResultData(await Mediator.Send(new TestPostCommand(daa)));
    //}


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
