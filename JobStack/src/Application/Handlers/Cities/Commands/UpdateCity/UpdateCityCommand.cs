

using JobStack.Application.Common.Constants;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Application.Handlers.Categories.Commands.UpdateCategory;
using JobStack.Domain.Entities;
using MediatR;

namespace JobStack.Application.Handlers.Cities.Commands.UpdateCity;

public class UpdateCityCommand:IRequest<IDataResult<UpdateCityCommand>>
{
    public int CityId { get; set; }
    public string CityName { get; set; } = null!;

    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, IDataResult<UpdateCityCommand>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<UpdateCityCommand>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            City existcity= await _context.Cities.FindAsync(request.CityId);
            if (existcity is null)
            {
                return new ErrorDataResult<UpdateCityCommand>(Messages.NullMessage);
            }
            existcity.CityName = request.CityName;
            _context.Cities.Update(existcity);
            await _context.SaveChangesAsync(cancellationToken);



            return new SuccessDataResult<UpdateCityCommand>(request, Messages.Updated);
        }
    }
}
