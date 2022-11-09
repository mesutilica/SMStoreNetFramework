using SMStore.Data;
using SMStore.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SMStore.Service.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public async Task<Brand> MarkayiUrunlerliyleGetir(int brandId)
        {
            return await _databaseContext.Brands.Include("Products").FirstOrDefaultAsync(c => c.Id == brandId);
        }
    }
}
