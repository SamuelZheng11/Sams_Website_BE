using Sams_Website_BE.Dto.Education;
using Sams_Website_BE.Model;

namespace Sams_Website_BE.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> CreateAsync(T entityToCreate);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task<T> UpdateAsync(T entityToUpdate);
        Task RemoveAsync(Guid id);
    }
}