using SMStore.Entities;
using System.Threading.Tasks;

namespace SMStore.Service.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<Brand> MarkayiUrunlerliyleGetir(int brandId);
    }
}
