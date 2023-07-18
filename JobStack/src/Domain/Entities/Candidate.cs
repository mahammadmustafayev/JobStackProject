using JobStack.Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStack.Domain.Entities;

public class Candidate:BaseAuditableEntity
{
    public string CandidateFirstName { get; set; } = null!;
    public string CandidateLastName { get; set; }= null!;
    public string CandidateEmail { get; set; } = null!;
    public string CandidateProfession { get; set; } = null!;

    public string? Description { get; set; }

    public int? CountryId { get; set; }
    public Country? Country { get; set; }

    public int? CityId { get; set; }
    public City? City { get; set; }




    public string CandidateSkillName { get; set; } = null!;
    public string[] CandidateSkillsArray { get; set; }= null!;

    public string CandidateCV { get; set; } = null!;
    [NotMapped]
    public IFormFile CandidateCVUrl { get; set; } = null!;

    public string? CandidateProfilImage { get; set; }
    [NotMapped]
    public IFormFile?  CandidateProfileUrl { get; set; }
}
