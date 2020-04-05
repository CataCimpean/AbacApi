using System.Linq;
using System.Threading.Tasks;

namespace Abac.Web.Api.Infrastructure.Repository
{
    public interface IAbacRepository<T>
    {
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity, object key);
        Task<int> Delete(T entity);
    }
}
