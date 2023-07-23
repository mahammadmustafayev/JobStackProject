﻿
using JobStack.Application.Common.Interfaces;
using JobStack.Domain.Entities;

namespace JobStack.Application.Handlers.JobTypes.Queries;

public class JobTypeDto:IMapFrom<JobType>
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public string TypeName { get; set; }
    public ICollection<Vacancy>? Vacancies { get; set; }
}
