using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWorks : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IBrandRepository BrandRepository { get; }
        Task<int> Save();
    }
}
