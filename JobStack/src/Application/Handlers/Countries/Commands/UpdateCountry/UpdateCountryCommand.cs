namespace JobStack.Application.Handlers.Countries.Commands.UpdateCountry;

public class UpdateCountryCommand : IRequest<IDataResult<UpdateCountryCommand>>
{
    public int CountryId { get; set; }
    public string CountryName { get; set; } = null!;
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, IDataResult<UpdateCountryCommand>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCountryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<UpdateCountryCommand>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            Country existcountry = await _context.Countries.FindAsync(request.CountryId);
            if (existcountry is null)
            {
                return new ErrorDataResult<UpdateCountryCommand>(Messages.NullMessage);

            }
            existcountry.Name = request.CountryName;
            _context.Countries.Update(existcountry);
            await _context.SaveChangesAsync(cancellationToken);

            return new SuccessDataResult<UpdateCountryCommand>(request, Messages.Updated);

        }
    }
}
