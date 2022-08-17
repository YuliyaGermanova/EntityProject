using EntityProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityProject.DAL.Repositories
{
    /// <summary>
    /// <inheritdoc cref="IEntityRepository"/>
    /// </summary>
    public class EntityRepository : IEntityRepository
    {
        private readonly EntitiesContext _context;

        public EntityRepository(EntitiesContext context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Entity>().AnyAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Entity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Entity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task InsertAsync(Entity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<Entity>().Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
