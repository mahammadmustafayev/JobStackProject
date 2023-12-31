﻿


namespace JobStack.Infrastructure.Persistence.Interceptors;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly IDateTime _dateTime;
    private readonly ICurrentUserService _currentUserService;
    public AuditableEntitySaveChangesInterceptor(IDateTime dateTime, ICurrentUserService currentUserService)
    {
        _dateTime = dateTime;
        _currentUserService = currentUserService;
    }
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.Created = _dateTime.Now;
                entry.Entity.CreatedBy = _currentUserService.UserName != null ? _currentUserService.UserName : "User";
            }

            if (
                entry.State == EntityState.Added ||
                entry.State == EntityState.Modified
                )
            {
                entry.Entity.LastModified = _dateTime.Now;
                entry.Entity.LastModifiedBy = _currentUserService.UserName != null ? _currentUserService.UserName : "User";
            }
        }
    }

}
