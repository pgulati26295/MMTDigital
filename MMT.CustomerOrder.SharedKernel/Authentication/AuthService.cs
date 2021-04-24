using Microsoft.Extensions.Options;
using MMT.CustomerOrder.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMT.CustomerOrder.SharedKernel.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IBaseHttpClient _baseHttpClient;
        private readonly ApiSettings _apiSettings;
        public AuthService (IBaseHttpClient baseHttpClient, IOptions<ApiSettings> options)
        {
            _baseHttpClient = baseHttpClient;
            _apiSettings = options.Value;
        }
        public async Task<bool> AuthenticateAsync(string email, string userId)
        {
            var uri = new Uri($"{_apiSettings.ApiBaseAddress}/GetUserDetails?code={_apiSettings.ApiKey}&email={email}").ToString();
            var response = await _baseHttpClient.GetAsync<User>(uri);
            if (response.WasSuccessful && response.Data.CustomerId == userId && response.Data.Email == email)
                return true;
            else
                return false;
           
        }
    }
}
