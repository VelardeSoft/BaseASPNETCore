using BaseASPNETCore.User.Interfaces.REST.Resources;

namespace BaseASPNETCore.User.Interfaces.REST.Transform;

public static class UserResourceFromEntityAsembler
{
    public static UserResources ToResourceFromEntity(Domain.Model.Aggregates.User entity) => 
    new UserResources(entity.Id, entity.Name, entity.Email);
    
}