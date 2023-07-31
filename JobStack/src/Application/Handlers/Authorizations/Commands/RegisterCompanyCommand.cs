using AutoMapper;
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using JobStack.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace JobStack.Application.Handlers.Authorizations.Commands;

public record RegisterCompanyCommand(string CompanyName, string Email, string Password) : IRequest<IResult>
{


    public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommand, IResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public RegisterCompanyCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper, IApplicationDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IResult> Handle(RegisterCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = _mapper.Map<Company>(request);
            var isAnyUser = await _userManager.FindByEmailAsync(request.Email);
            if (isAnyUser is not null)
            {
                return new ErrorResult(Messages.EmailExist);
            }
            ApplicationUser user = new()
            {
                CompanySignUpName = request.CompanyName,
                Email = request.Email,
                UserName = request.Email
            };
            company.CompanyName = request.CompanyName;
            company.CompanyEmail = request.Email;
            IdentityResult identityResult = await _userManager.CreateAsync(user, request.Password);
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync(cancellationToken);

            if (!identityResult.Succeeded)
            {
                return new ErrorResult(message: JsonConvert.SerializeObject(identityResult.Errors.Select(x => x.Description)));
            }
            return new Result(true, Messages.Registersucces);

        }
    }

}
