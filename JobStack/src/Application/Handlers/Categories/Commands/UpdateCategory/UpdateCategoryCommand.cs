

using JobStack.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobStack.Application.Handlers.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand:IRequest
{
    public string CategoryId { get; set;}
    public string CategoryName { get; set;}
    public string Logo { get; set; }
    [NotMapped]
    public IFormFile Photo { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        // fayl yukleme ile yazilacak
        return Unit.Value;
    }
}