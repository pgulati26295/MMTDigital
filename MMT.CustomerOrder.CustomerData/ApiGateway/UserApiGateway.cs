using MMT.CustomerOrder.Core.User;
using MMT.CustomerOrder.SharedKernel.Api;
using MMT.CustomerOrder.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
namespace MMT.CustomerOrder.CustomerData.ApiGateway
{
    public class UserApiGateway : IUserApiGateway
    {
        private readonly IBaseHttpClient _baseHttpClient;
        private readonly UserApiSettings _userApiSettings;

        public UserApiGateway(IBaseHttpClient baseHttpClient , IOptions<UserApiSettings> options)
        {
            _baseHttpClient = baseHttpClient;
            _userApiSettings = options.Value;
        }
        public async Task<ApiResponse<User>> GetAsync(string email)
        {
            var uri = new Uri($"{_userApiSettings.ApiBaseAddress}/GetUserDetails?code={_userApiSettings.ApiKey}&email={email}").ToString();
            var response = await _baseHttpClient.GetAsync<User>(uri);
            return response;
        }

        public async Task<ApiResponse<User>> PostAsync(string email)
        {
            var uri = new Uri($"{_userApiSettings.ApiBaseAddress}/GetUserDetails?code={_userApiSettings.ApiKey}").ToString();
            var response = await _baseHttpClient.PostAsync<User>(uri, email);
            return response;
        }
    }
}
