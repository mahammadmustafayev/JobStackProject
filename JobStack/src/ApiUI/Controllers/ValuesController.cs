

namespace ApiUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ValuesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> CreateSeedAsync()
    {
        var administrator = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(""),
            UserName = "manageAdmin",
            Email = "mahammadvm@code.edu.az",
            FirstName = "Mahammad",
            LastName = "Mustafayev",
            NormalizedUserName = "MANAGEADMIN",
            NormalizedEmail = "MAHAMMADVM@CODE.EDU.AZ",
            EmailConfirmed = false,
            PhoneNumberConfirmed = false,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        var adminModerator = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(""),
            UserName = "manageModerator",
            Email = "mmmyev125@gmail.com",
            FirstName = "Mustafa",
            LastName = "Yevo",
            NormalizedUserName = "MANAGEMODERATOR",
            NormalizedEmail = "MMMYEV125@GMAIL.COM",
            EmailConfirmed = false,
            PhoneNumberConfirmed = false,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };


        await _userManager.CreateAsync(administrator, "PaSSword1!");
        await _userManager.AddToRoleAsync(administrator, "superadmin");





        await _userManager.CreateAsync(adminModerator, "PaSSword2!");
        await _userManager.AddToRoleAsync(adminModerator, "moderator");
        await _context.SaveChangesAsync();





        if (!_context.Countries.Any())
        {
            await _context.Countries.AddRangeAsync(CountrySeed.CountryData);

        }
        if (!_context.Cities.Any())
        {
            await _context.Cities.AddRangeAsync(CitySeed.CityData);

        }
        if (!_context.JobTypes.Any())
        {
            await _context.JobTypes.AddRangeAsync(JobTypeSeed.JobTypesData);

        }
        if (!_context.Categories.Any())
        {
            await _context.Categories.AddRangeAsync(CategorySeed.CategoriesData);

        }


        return NoContent();

    }
}
