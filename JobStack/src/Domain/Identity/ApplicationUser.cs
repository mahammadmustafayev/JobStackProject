

using Microsoft.AspNetCore.Identity;

namespace JobStack.Domain.Identity;

public class ApplicationUser : IdentityUser 
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? CompanySignUpName { get; set; }
    

}
