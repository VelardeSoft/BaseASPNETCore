using BaseASPNETCore.Shared.Domain.Repositories;

namespace BaseASPNETCore.User.Domain.Repositories;

public interface IUserRepository : IBaseRepository<Model.Aggregates.User>
{
    Task<Model.Aggregates.User?> FindByEmailAsync(string email); // Método para buscar un usuario por email
    Task<bool> EmailExistsAsync(string email); // Método para verificar si un email ya está registrado
}

/*
Puedes agregar métodos específicos para la entidad User que no estén 
cubiertos por las operaciones CRUD genéricas. Ejemplos comunes:

Buscar usuario por email.
Verificar si un email ya está registrado.
Listar usuarios activos/inactivos.

 */