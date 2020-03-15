using Brewer.Infrastructure.Abstractions.Data;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using Brewer.Domain.Entities;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Brewer.Infrastructure.Data
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        protected readonly IConfiguration Configuration;

        private string _connectionString;

        protected readonly Type EntityType;

        protected readonly PropertyInfo[] EntityProperties;

        protected readonly string[] EntityPropertyNames;

        public Repository(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            EntityType = typeof(TEntity);
            
            EntityProperties = 
                EntityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.Name != nameof(IEntity<TKey>.Id)).ToArray();
            
            EntityPropertyNames = EntityProperties.Select(x => x.Name).ToArray();

            GetConnectionString();
        }

        protected string PropertyNamesAggregated => EntityPropertyNames.Aggregate((x, y) => $"{x}, {y}");

        protected virtual void GetConnectionString() => _connectionString = Configuration.GetConnectionString("BrewerDatabase");

        protected IEnumerable<object> GetPropertyValues(TEntity entity) => EntityProperties.Select(x => x.GetValue(entity));

        protected async Task<T> ExecuteAsync<T>(Func<IDbConnection, Task<T>> executor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                return await executor(connection);
            }
        }

        protected DynamicParameters GetPropertyParameters(TEntity entity)
        {
            var parameters = new DynamicParameters();
            
            foreach (var property in EntityProperties)
                parameters.Add(property.Name, property.GetValue(entity));

            return parameters;
        }

        public virtual async Task Delete(TEntity entity)
        {
            var sql = $"DELETE FROM {typeof(TEntity).Name} WHERE Id = @Id";

            await ExecuteAsync(async connection => await connection.ExecuteAsync(sql, new { entity.Id }));
        }

        public virtual async Task<TEntity> GetByKey(TKey key)
        {
            var sql = $"SELECT * FROM {typeof(TEntity).Name} WHERE Id = @Id";

            return await ExecuteAsync(async connection => await connection.QueryFirstAsync<TEntity>(sql, new { Id = key }));
        }

        public virtual async Task Insert(TEntity entity)
        {
            var sql = $"INSERT INTO {typeof(TEntity).Name} ({PropertyNamesAggregated}) OUTPUT INSERTED.{nameof(IEntity<TKey>.Id)} VALUES @Values";

            var values = GetPropertyValues(entity);

            var key = await ExecuteAsync(async connection => await connection.ExecuteScalarAsync<TKey>(sql, new { Values = values, entity.Id }));

            entity.Id = key;
        }

        public virtual async Task Update(TEntity entity)
        {
            var itemsToUpdate = EntityPropertyNames.Select(x => $"{x} = @{x}");

            var sql = $"UPDATE {typeof(TEntity).Name} SET {itemsToUpdate} WHERE Id = @Id";

            var parameters = GetPropertyParameters(entity);

            await ExecuteAsync(async connection => await connection.ExecuteAsync(sql, parameters));
        }
    }
}