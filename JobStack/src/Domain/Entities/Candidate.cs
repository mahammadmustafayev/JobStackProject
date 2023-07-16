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
    public string CandidateName { get; set; }
    public string CandidateEmail { get; set; }
    public string CandidateProfession { get; set; }

    public string Description { get; set; }

    public string CandidateSkillName { get; set; }
    public string[] CandidateSkillsArray { get; set; }

    public string CandidateCV { get; set; }
    [NotMapped]
    public IFormFile CandidateCVUrl { get; set; }

    public string CandidateProfilImage { get; set; }
    [NotMapped]
    public IFormFile  CandidateProfileUrl { get; set; }
}
