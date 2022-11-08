using SMStore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMStore.Service.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> UrunleriKategoriveMarkaylaGetirAsync();
        Task<Product> UrunuKategoriVeMarkaylaGetir(int productId);
    }
}
