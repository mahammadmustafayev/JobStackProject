using AutoMapper;
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Extensions;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace JobStack.Application.Handlers.Companies.Commands;

public record ManageCreateCompanyCommand
    (
       string CompanyName,
        string Description,
        DateTime Founded,
        int NumberOfEmployees,
        int CountryId,
        int CityId,
        string CompanyEmail,
        string CompanySite,
        IFormFile CompanyLogoUrl
    ) : IRequest<IDataResult<ManageCreateCompanyCommand>>
{
    public class ManageCreateCompanyCommandHandler : IRequestHandler<ManageCreateCompanyCommand, IDataResult<ManageCreateCompanyCommand>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IHostEnvironment _env;

        public ManageCreateCompanyCommandHandler(IMapper mapper, IApplicationDbContext context, IHostEnvironment env)
        {
            _mapper = mapper;
            _context = context;
            _env = env;
        }

        public async Task<IDataResult<ManageCreateCompanyCommand>> Handle(ManageCreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = _mapper.Map<Company>(request);
            if (request != null)
            {
                if (request.CompanyLogoUrl.CheckSize(200))
                {
                    return new ErrorDataResult<ManageCreateCompanyCommand>(Messages.InvalidPhoto);
                }
                if (!request.CompanyLogoUrl.CheckType("image/"))
                {
                    return new ErrorDataResult<ManageCreateCompanyCommand>(Messages.InvalidImagePhoto);
                }
                company.CompanyLogo = request.CompanyLogoUrl.SaveFile(Path.Combine(_env.ContentRootPath, "wwwroot", "Company"));
            }
            company.CompanyName = request.CompanyName;
            company.Description = request.Description;
            company.CityId = request.CityId;
            company.CountryId = request.CountryId;
            company.CompanyEmail = request.CompanyEmail;
            company.NumberOfEmployees = request.NumberOfEmployees;
            company.Founded = request.Founded;
            company.CompanySite = request.CompanySite;

            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<ManageCreateCompanyCommand>(Messages.Added);
        }
    }

}
