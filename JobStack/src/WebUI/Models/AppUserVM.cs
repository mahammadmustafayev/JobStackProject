using Microsoft.AspNetCore.Identity;

namespace WebUI.Models;

public class AppUserVM : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? CompanySignUpName { get; set; }
}
