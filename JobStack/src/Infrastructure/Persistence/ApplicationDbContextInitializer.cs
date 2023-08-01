

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<ApplicationDbContextInitializer> _logger;

    public ApplicationDbContextInitializer(ApplicationDbContext context,
        RoleManager<AppRole> roleManager,
        UserManager<ApplicationUser> userManager,
        ILogger<ApplicationDbContextInitializer> logger)
    {
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
        _logger = logger;
    }

    public async System.Threading.Tasks.Task InitializeAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }
    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured while seeding the database");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        string[] roles = { "superadmin", "moderator", "company", "candidate" };

        foreach (string role in roles)
        {
            if (_roleManager.Roles.All(r => r.Name != role))
            {
                await _roleManager.CreateAsync(new AppRole() { Name = role });
            }
        }

        //var administrator = new ApplicationUser
        //{
        //    UserName = "manageAdmin",
        //    Email = "mahammadvm@code.edu.az",
        //    FirstName = "Mahammad",
        //    LastName = "Mustafayev",
        //    NormalizedUserName = "MANAGEADMIN",
        //    NormalizedEmail = "MAHAMMADVM@CODE.EDU.AZ",
        //    EmailConfirmed = false,
        //    PhoneNumberConfirmed = false,
        //    SecurityStamp = Guid.NewGuid().ToString("D")
        //};
        //var adminModerator = new ApplicationUser
        //{
        //    UserName = "manageModerator",
        //    Email = "mmmyev125@gmail.com",
        //    FirstName = "Mustafa",
        //    LastName = "Yevo",
        //    NormalizedUserName = "MANAGEMODERATOR",
        //    NormalizedEmail = "MMMYEV125@GMAIL.COM",
        //    EmailConfirmed = false,
        //    PhoneNumberConfirmed = false,
        //    SecurityStamp = Guid.NewGuid().ToString("D")
        //};

        //if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        //{

        //    await _userManager.CreateAsync(administrator, "PaSSword1");
        //    await _userManager.AddToRoleAsync(administrator, "superadmin");

        //    //await _context.SaveChangesAsync();
        //}

        //if (_userManager.Users.All(u => u.UserName != adminModerator.UserName))
        //{
        //    await _userManager.CreateAsync(adminModerator, "PaSSword2");
        //    await _userManager.AddToRoleAsync(adminModerator, "moderator");
        //    //await _context.SaveChangesAsync();

        //}

        //if (!_context.Countries.Any())
        //{
        //    await _context.Countries.AddRangeAsync(CountrySeed.CountryData);
        //    //await _context.SaveChangesAsync();
        //}
        //if (!_context.Cities.Any())
        //{
        //    await _context.Cities.AddRangeAsync(CitySeed.CityData);
        //    //await _context.SaveChangesAsync();
        //}
        //if (!_context.JobTypes.Any())
        //{
        //    await _context.JobTypes.AddRangeAsync(JobTypeSeed.JobTypesData);
        //    //await _context.SaveChangesAsync();
        //}
        //if (!_context.Categories.Any())
        //{
        //    await _context.Categories.AddRangeAsync(CategorySeed.CategoriesData);
        //    //await _context.SaveChangesAsync();
        //}

        await _context.SaveChangesAsync();
    }
}
