using EntityProject.DAL.Entities;

namespace EntityProject.DAL.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями.
    /// </summary>
    public interface IEntityRepository
    {
        Task InsertAsync(Entity entity, CancellationToken cancellationToken = default);

        Task<Entity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
