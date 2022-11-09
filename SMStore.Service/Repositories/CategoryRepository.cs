using SMStore.Data;
using SMStore.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SMStore.Service.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public async Task<Category> KategoriyiUrunlerliyleGetir(int categoryId)
        {
            return await _databaseContext.Categories.Include("Products").FirstOrDefaultAsync(c=>c.Id == categoryId);
        }
    }
}
