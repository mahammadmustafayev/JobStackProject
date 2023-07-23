using AutoMapper;
using JobStack.Application.Common.Interfaces;
using JobStack.Application.Common.Results;
using JobStack.Domain.Entities;
using JobStack.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobStack.Application.Handlers.Candidates.Commands.CreateCandidate;

public record CreateCandidateCommand:IRequest<IDataResult<CreateCandidateCommand>>
{
    public string CandidateFirstName { get; set; } = null!;
    public string CandidateLastName { get; set; } = null!;
    public string CandidateEmail { get; set; } = null!;
    public string CandidateProfession { get; set; } = null!;

    public string? Description { get; set; }

    public int? CountryId { get; set; }
    public Country? Country { get; set; }
    public ICollection<Experience>? Experiences { get; set; }

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

    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, IDataResult<CreateCandidateCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationUser _user;


        public CreateCandidateCommandHandler(IApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, ApplicationUser user, IHttpContextAccessor accessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _user = user;
            _accessor = accessor;
        }

        public async Task<IDataResult<CreateCandidateCommand>> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<CreateCandidateCommand>(request, "Good");
           
        }
    }

}

