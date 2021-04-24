using Microsoft.Extensions.Logging;
using MMT.CustomerOrder.SharedKernel.Api;
using MMT.CustomerOrder.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace MMT.CustomerOrder.CustomerData.ApiGateway
{
    public class BaseHttpClient : IBaseHttpClient
    {
        private readonly ILogger<BaseHttpClient> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseHttpClient(IHttpClientFactory httpClientFactory, ILogger<BaseHttpClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string requestUrl)
        {
            var client = _httpClientFactory.CreateClient();
            HttpRequestMessage  request= new HttpRequestMessage(HttpMethod.Get, requestUrl);
            var httpResponse = await client.SendAsync(request);
            return await ProcessHttpResponse<T>(httpResponse);

        }

        public async Task<ApiResponse<T>> PostAsync<T>(string requestUrl, object jsonObject)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(jsonObject), Encoding.UTF8, Application.Json);
            var httpResponse = await client.PostAsync(requestUrl, content);
            return await ProcessHttpResponse<T>(httpResponse);
        }

        private async Task<ApiResponse<T>> ProcessHttpResponse<T>(HttpResponseMessage httpResponseMessage) 
        {
            ApiResponse<T> response = new ApiResponse<T>();
            try
            {
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(responseContent))
                        response.Data = JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    response.WasSuccessful = true;
                }
                else
                {
                    string error = await httpResponseMessage.Content.ReadAsStringAsync();
                    _logger.LogTrace(error);
                    response.ErrorMessages.Add(new ErrorMessage { Description = error, Source = "Http request" });
                    response.WasSuccessful = false;
                }

                response.ResponseCode = httpResponseMessage.StatusCode.ToString();
                response.StatusCode = (int)httpResponseMessage.StatusCode;
                response.ResponseReason = httpResponseMessage.ReasonPhrase?.ToString();
            }
            catch(Exception ex)
            {
                response.ErrorMessages.Add(new ErrorMessage { Description = ex.Message, Source = "Http request" });
                response.WasSuccessful = false;
                response.ResponseCode = httpResponseMessage.StatusCode.ToString();
                response.StatusCode = (int)httpResponseMessage.StatusCode;
                response.ResponseReason = httpResponseMessage.ReasonPhrase?.ToString();
            }

            return response;
        }
    }
}
