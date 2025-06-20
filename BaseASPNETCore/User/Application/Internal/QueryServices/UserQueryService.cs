using BaseASPNETCore.Shared.Domain.Repositories;
using BaseASPNETCore.User.Domain.Model.Queries;
using BaseASPNETCore.User.Domain.Repositories;
using BaseASPNETCore.User.Domain.Services;

namespace BaseASPNETCore.User.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) 
    : IUserQueryServices
{
    // Este clase muestra todos los usuarios y permite buscar por ID.
    public async Task<IEnumerable<Domain.Model.Aggregates.User>> Handle(GetAllUserQueries query)
    {
        return await userRepository.ListAsync();
    }
    
    // Este método busca un usuario por su ID.
    public async Task<Domain.Model.Aggregates.User?> Handle(GetUserByIdQueries query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }
}