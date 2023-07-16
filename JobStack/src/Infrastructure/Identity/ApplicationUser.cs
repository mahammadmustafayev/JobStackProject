

using Microsoft.AspNetCore.Identity;

namespace JobStack.Infrastructure.Identity;

public class ApplicationUser : IdentityUser 
{
    public string FullName { get; set; }
}
