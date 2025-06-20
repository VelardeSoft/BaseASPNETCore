using BaseASPNETCore.User.Domain.Model.Commands;
using BaseASPNETCore.User.Interfaces.REST.Resources;

namespace BaseASPNETCore.User.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateNewUserCommand ToCommandFromResource(CreateUserResources resource) =>
    new CreateNewUserCommand(resource.Name, resource.Email);
}