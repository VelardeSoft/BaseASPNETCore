using BaseASPNETCore.Shared.Domain.Repositories;
using BaseASPNETCore.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace BaseASPNETCore.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        // Save changes to the database
        await context.SaveChangesAsync();
    }
}