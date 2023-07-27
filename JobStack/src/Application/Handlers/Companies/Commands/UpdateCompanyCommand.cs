using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Extensions;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace JobStack.Application.Handlers.Companies.Commands;

public class UpdateCompanyCommand : IRequest<IDataResult<UpdateCompanyCommand>>
{
    public int CompanyId { get; set; }


    public string Description { get; set; }


    public DateTime Founded { get; set; }
    public int NumberOfEmployees { get; set; }

    public int CountryId { get; set; }

    public int CityId { get; set; }

    public string CompanySite { get; set; }


    public IFormFile CompanyUrl { get; set; }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, IDataResult<UpdateCompanyCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHostEnvironment _env;

        public UpdateCompanyCommandHandler(IApplicationDbContext context, IHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IDataResult<UpdateCompanyCommand>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company existcompany = await _context.Companies.FindAsync(request.CompanyId);
            if (existcompany is null)
            {
                return new ErrorDataResult<UpdateCompanyCommand>(Messages.NullMessage);
            }
            if (request.CompanyUrl != null)
            {
                IFormFile file = request.CompanyUrl;
                string newFileName = Guid.NewGuid().ToString();
                newFileName += file.CutFileName(60);
                if (System.IO.File.Exists(Path.Combine(_env.ContentRootPath, "wwwroot", "Company")))
                {
                    System.IO.File.Delete(Path.Combine(_env.ContentRootPath, "wwwroot", "Company"));
                }
                file.UpdateSaveFile(Path.Combine(newFileName));
                existcompany.CompanyLogo = newFileName;
            }
            existcompany.Description = request.Description;
            existcompany.CityId = request.CityId;
            existcompany.CountryId = request.CountryId;
            existcompany.Founded = request.Founded;
            existcompany.NumberOfEmployees = request.NumberOfEmployees;
            existcompany.CompanySite = request.CompanySite;

            _context.Companies.Update(existcompany);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<UpdateCompanyCommand>(request, Messages.Updated);

        }
    }
}
