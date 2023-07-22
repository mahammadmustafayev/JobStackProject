

using AutoMapper;
using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.Cities.Commands.CreateCity;

public  record CreateCityCommand(string CityName):IRequest<IDataResult<CreateCityCommand>>
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, IDataResult<CreateCityCommand>>
    {
        private readonly IApplicationDbContext _context;

        public CreateCityCommandHandler( IApplicationDbContext context)
        {
            
            _context = context;
        }

        public async Task<IDataResult<CreateCityCommand>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            City city = new()
            {
                CityName=request.CityName,
            };
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<CreateCityCommand>(request, Messages.Added);
        }
    }
}
