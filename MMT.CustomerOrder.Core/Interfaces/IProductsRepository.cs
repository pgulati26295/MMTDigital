using MMT.CustomerOrder.Core.Entities;
using MMT.CustomerOrder.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMT.CustomerOrder.Core.Interfaces
{
  public  interface IProductsRepository : IRepository<Products>
    {
    }
}
