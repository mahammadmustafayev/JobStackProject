using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Application.Handlers.Countries.Commands.CreateCountry;

public record CreateCountryCommand(string CountryName):IRequest<IDataResult<CreateCountryCommand>>
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, IDataResult<CreateCountryCommand>>
    {
        private readonly IApplicationDbContext _context;

        public CreateCountryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<CreateCountryCommand>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            Country country = new()
            {
                Name=request.CountryName,
            };
            await _context.Countries.AddAsync(country); 
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<CreateCountryCommand>(request,Messages.Added);
        }
    }
}
