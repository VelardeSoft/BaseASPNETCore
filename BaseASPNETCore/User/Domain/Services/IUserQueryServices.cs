using BaseASPNETCore.User.Domain.Model.Commands;
using BaseASPNETCore.User.Domain.Model.Queries;

namespace BaseASPNETCore.User.Domain.Services;

public interface IUserQueryServices
{
    Task<IEnumerable<Model.Aggregates.User>> Handle(GetAllUserQueries queries);
    Task<Model.Aggregates.User?> Handle(GetUserByIdQueries query);
}