namespace BaseASPNETCore.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity>
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<IEnumerable<TEntity>> ListAsync();
}


/*
Task AddAsync(TEntity entity);
Agrega una nueva entidad de tipo TEntity de forma asíncrona al repositorio (por ejemplo, a la base de datos).

Task<TEntity?> FindByIdAsync(int id);
Busca y devuelve una entidad por su identificador. Si no existe, retorna null. Es asíncrono.

void Update(TEntity entity);
Actualiza los datos de una entidad existente en el repositorio.

void Remove(TEntity entity);
Elimina la entidad especificada del repositorio.

Task<IEnumerable<TEntity>> ListAsync();
Obtiene una lista de todas las entidades del tipo TEntity de forma asíncrona.
 */