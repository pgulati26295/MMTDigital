using MMT.CustomerOrder.Core.Entities;
using MMT.CustomerOrder.Core.Interfaces;
using MMT.CustomerOrder.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMT.CustomerOrder.Infrastructure.Repositories
{
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        public ProductsRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
