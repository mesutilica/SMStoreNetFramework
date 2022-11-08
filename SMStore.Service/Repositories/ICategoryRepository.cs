using SMStore.Entities;
using System.Threading.Tasks;

namespace SMStore.Service.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> KategoriyiUrunlerliyleGetir(int categoryId);
    }
}
