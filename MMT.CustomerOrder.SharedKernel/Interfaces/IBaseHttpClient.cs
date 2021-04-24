using MMT.CustomerOrder.SharedKernel.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMT.CustomerOrder.SharedKernel.Interfaces
{
   public interface IBaseHttpClient
    {
        Task<ApiResponse<T>> GetAsync<T>(string requestUrl);

        Task<ApiResponse<T>> PostAsync<T>(string requestUrl, object jsonObject);

    }
}
