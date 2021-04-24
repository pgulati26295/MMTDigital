using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMT.CustomerOrder.SharedKernel.Authentication
{
  public  interface IAuthService
    {
        Task<bool> AuthenticateAsync(string email, string userId);
    }
}
