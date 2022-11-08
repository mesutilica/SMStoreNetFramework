using SMStore.Data;
using SMStore.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SMStore.Service.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<IEnumerable<Product>> UrunleriKategoriveMarkaylaGetirAsync()
        {
            return await _databaseContext.Products.Include("Brand").Include("Category").ToListAsync();
        }

        public async Task<Product> UrunuKategoriVeMarkaylaGetir(int productId)
        {
            return await _databaseContext.Products.Include(c => c.Brand).Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == productId);
        }
    }
}
