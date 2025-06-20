using BaseASPNETCore.User.Domain.Model.Commands;

namespace BaseASPNETCore.User.Domain.Services;

public interface IUserCommandServices
{
    Task<Model.Aggregates.User?> Handle(CreateNewUserCommand command);
}