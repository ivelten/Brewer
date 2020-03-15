using System.Threading.Tasks;
using Brewer.Domain.Entities;

namespace Brewer.Infrastructure.Abstractions.Data
{
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        Task<TEntity> GetByKey(TKey key);

        Task Insert(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}