using BaseASPNETCore.Shared.Domain.Repositories;
using BaseASPNETCore.User.Domain.Model.Commands;
using BaseASPNETCore.User.Domain.Repositories;
using BaseASPNETCore.User.Domain.Services;

namespace BaseASPNETCore.User.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : IUserCommandServices
{
    public async Task<Domain.Model.Aggregates.User?> Handle(CreateNewUserCommand command)
    {
        var user = new Domain.Model.Aggregates.User
        {
            Email = command.Email,
            Name = command.Name
        }; // Crear una nueva instancia de User con los datos del comando
        
        // Verificar si el email ya existe
        if (await userRepository.EmailExistsAsync(user.Email))
        {
            throw new Exception("Email already exists");
        }

        // Agregar el nuevo usuario al repositorio
        await userRepository.AddAsync(user);
        
        // Completar la unidad de trabajo
        await unitOfWork.CompleteAsync();
        return user;
    }
}