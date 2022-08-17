using EntityProject.DAL.Entities;

namespace EntityProject.Services
{
    /// <summary>
    /// Сервис для работы с сущностями.
    /// </summary>
    public interface IEntityService
    {
        Task InsertAsync(Entity entity, CancellationToken cancellationToken = default);

        Task<string> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
