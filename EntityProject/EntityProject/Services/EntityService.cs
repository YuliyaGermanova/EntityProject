using EntityProject.DAL.Entities;
using EntityProject.DAL.Repositories;
using EntityProject.Exceptions;
using System.Text.Json;

namespace EntityProject.Services
{
    /// <summary>
    /// <inheritdoc cref="IEntityService"/>
    /// </summary>
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _entityRepository;

        public EntityService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task InsertAsync(Entity entity, CancellationToken cancellationToken = default)
        {
            var isEntity = await _entityRepository.AnyAsync(entity.Id, cancellationToken);

            if (isEntity)
            {
                throw new CastomException("Идентификатор записи должен быть уникальным", CastomExceptionTypes.BadRequestException);
            }

            await _entityRepository.InsertAsync(entity, cancellationToken);
        }

        public async Task<string> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _entityRepository.GetByIdAsync(id, cancellationToken);

            if (result == null)
            {
                throw new CastomException("Сущность не существует", CastomExceptionTypes.NotFoundException);
            }

            return JsonSerializer.Serialize(result);
        }
    }
}
