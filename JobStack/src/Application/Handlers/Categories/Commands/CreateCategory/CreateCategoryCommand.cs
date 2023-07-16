
using JobStack.Application.Common.Interfaces;
using JobStack.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobStack.Application.Handlers.Categories.Commands.CreateCategory;

public class CreateCategoryCommand:IRequest<int>
{
    public string CategoryName { get; set; } = null!;
    public string Logo { get; set; }
    [NotMapped]
    public IFormFile Photo { get; set; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async  Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category entity = new()
        {
            // sekil yukleme yazilacaq
        };
        return entity.Id;
    }
}

