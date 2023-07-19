using JobStack.Application.Common.Interfaces;
using JobStack.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobStack.Application.Handlers.Candidates.Commands.CreateCandidate;

public class CreateCandidateCommand:IRequest<int>
{
    public string CandidateFirstName { get; set; } = null!;
    public string CandidateLastName { get; set; } = null!;
    public string CandidateEmail { get; set; } = null!;
    public string CandidateProfession { get; set; } = null!;

    public string? Description { get; set; }

    public int? CountryId { get; set; }
    public Country? Country { get; set; }

    public int? CityId { get; set; }
    public City? City { get; set; }
    public string CandidateSkillName { get; set; } = null!;
    public string[] CandidateSkillsArray { get; set; } = null!;

    public string CandidateCV { get; set; } = null!;
    [NotMapped]
    public IFormFile CandidateCVUrl { get; set; } = null!;

    public string? CandidateProfilImage { get; set; }
    [NotMapped]
    public IFormFile? CandidateProfileUrl { get; set; }
}

public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCandidateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        Candidate entity = new()
        {

        };
        return entity.Id;
    }
}
