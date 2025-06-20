namespace BaseASPNETCore.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}

/*
La interfaz IUnitOfWork representa el patrón "Unidad de Trabajo" (Unit of Work). 
Su propósito es coordinar y gestionar la escritura de cambios en la base de datos 
como una única transacción. El método CompleteAsync() se encarga de confirmar 
(commit) todos los cambios pendientes de manera asíncrona, asegurando que todas 
las operaciones realizadas en el contexto actual se guarden juntas o se deshagan si ocurre un error.
 */