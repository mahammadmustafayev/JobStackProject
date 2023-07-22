


using JobStack.Domain.Identity;
using JobStack.Infrastructure.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<ApplicationDbContextInitializer> _logger;

    public ApplicationDbContextInitializer(ApplicationDbContext context, 
        RoleManager<IdentityRole> roleManager, 
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

    public async Task TrySeedAsync()
    {
        string[] roles= {"superadmin","moderator","company","candidate"};

        foreach (string role in roles)
        {
            if (_roleManager.Roles.All(r=>r.Name != role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        var administrator = new ApplicationUser
        {
            UserName = "manageAdmin",
            Email = "mahammadvm@code.edu.az",
            FirstName = "Mahammad",
            LastName="Mustafayev",
            NormalizedUserName= "MANAGEADMIN",
            NormalizedEmail= "MAHAMMADVM@CODE.EDU.AZ",
            EmailConfirmed= false,
            PhoneNumberConfirmed= false,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };
        var adminModerator = new ApplicationUser
        {
            UserName = "manageModerator",
            Email = "mmmyev125@gmail.com",
            FirstName = "Mustafa",
            LastName="Yevo",
            NormalizedUserName= "MANAGEMODERATOR",
            NormalizedEmail= "MMMYEV125@GMAIL.COM",
            EmailConfirmed= false,
            PhoneNumberConfirmed= false,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };
        // db içerisinde bu kullanıcı yok ise, ekle :)
        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "PaSSword1");
            await _userManager.AddToRoleAsync(administrator, roles.FirstOrDefault(r=>r.Contains("superadmin")).ToString());
        }
        
        if (_userManager.Users.All(u => u.UserName != adminModerator.UserName))
        {
            await _userManager.CreateAsync(adminModerator, "PaSSword2");
            await _userManager.AddToRoleAsync(adminModerator, roles.FirstOrDefault(r=>r.Contains("moderator")).ToString());
        }

        if (!_context.Countries.Any())
        {
           await _context.AddRangeAsync(CountrySeed.CountryData);
           await _context.SaveChangesAsync();
        } 
        if (!_context.Cities.Any())
        {
            await _context.AddRangeAsync(CitySeed.CityData);
            await _context.SaveChangesAsync();
        }
        if (!_context.JobTypes.Any())
        {
            await _context.AddRangeAsync(JobTypeSeed.JobTypesData);
            await _context.SaveChangesAsync();
        }
        if (!_context.Categories.Any())
        {
            await _context.AddRangeAsync(CategorySeed.CategoriesData);
            await _context.SaveChangesAsync();
        }

        await _context.SaveChangesAsync();
    }
}
