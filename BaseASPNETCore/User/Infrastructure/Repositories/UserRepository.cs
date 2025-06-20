using BaseASPNETCore.Shared.Infrastructure.Persistence.EFC.Configuration;
using BaseASPNETCore.Shared.Infrastructure.Persistence.EFC.Repositories;
using BaseASPNETCore.User.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseASPNETCore.User.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<Domain.Model.Aggregates.User>(context), IUserRepository
{
    public async Task<bool> EmailExistsAsync(string email)  // Método para verificar si un email ya está registrado
    {
        return await context.Set<Domain.Model.Aggregates.User>().AnyAsync(u => u.Email == email);
    }

    public async Task<Domain.Model.Aggregates.User?> FindByEmailAsync(string email) // Método para buscar un usuario por email
    {
        return await context.Set<Domain.Model.Aggregates.User>().FirstOrDefaultAsync(u => u.Email == email);
    }
}