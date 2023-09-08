using Entity.Models;
using Repository.IRepositories;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly db_a9c1e6_soleauthenticitydbContext _dbContext;

        public UnitOfWorks(db_a9c1e6_soleauthenticitydbContext dbContext)
        {
            _dbContext = dbContext;
            ProductRepository = new ProductRepository(_dbContext);
            BrandRepository = new BrandRepository(_dbContext);
        }
        public IProductRepository ProductRepository { get; private set; }
        public IBrandRepository BrandRepository { get; set; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
