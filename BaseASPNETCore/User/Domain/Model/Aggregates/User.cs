using BaseASPNETCore.User.Domain.Model.Commands;

namespace BaseASPNETCore.User.Domain.Model.Aggregates;

public class User
{
    public int Id { get; }
    public string Name { get; set; }
    public string Email { get; set; }
}