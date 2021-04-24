using MMT.CustomerOrder.SharedKernel.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMT.CustomerOrder.Core.User
{
  public  interface IUserApiGateway
    {
        Task<ApiResponse<User>> GetAsync(string email);

        Task<ApiResponse<User>> PostAsync(string email);
    }
}
