using LibraryAPI.Models.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity entity);

        Task CreateAsync(TEntity entity);

        void CreateRange(IEnumerable<TEntity> entities);

        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        // Get
        Task<List<TEntity>> GetAllAsync();
        List<TEntity> GetAll();

        IQueryable<TEntity> GetAllAsQueryable();

        TEntity FindById(object id);

        Task<TEntity> FindByIdAsync(object id);

        // Update

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        // Delete 
        
        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        // Save

        bool Save();

        Task<bool> SaveAsync();
    }
}
