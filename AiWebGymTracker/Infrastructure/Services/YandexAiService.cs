using AiWebGymTracker.Abstractions;
using AiWebGymTracker.Infrastructure.Configurations;
using AiWebGymTracker.Models.BaseModels;
using AiWebGymTracker.Models.Enums;
using AiWebGymTracker.Models.YandexAiModels;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AiWebGymTracker.Infrastructure.Services
{
    public class YandexAiService : IAiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly YandexConfiguration _configuration;

        public YandexAiService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IOptions<YandexConfiguration> config)
        {
            _configuration = config.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TResponse> AskAi<TJsonInput, TResponse>(TJsonInput prompt)
            where TResponse : class, new()
            where TJsonInput : BaseInput
        {
            var yandexAiRequest = new YandexAiRequest<TResponse>(prompt)
            {
                modelUri = _configuration.ModelId
            };

            return await PostAsync(yandexAiRequest);
        }

        private async Task<TResponse> PostAsync<TResponse>(YandexAiRequest<TResponse> request)
            where TResponse : class, new()  
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
            };

            requestMessage.Content = new StringContent(JsonSerializer.Serialize(requestMessage), Encoding.UTF8, "application/json");

            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var client = _httpClientFactory.CreateClient(AiServiceName.YandexAi.ToString()))
            {
                using (var httpResponse = await client.SendAsync(requestMessage))
                {
                    httpResponse.EnsureSuccessStatusCode();

                    var responseStr = await httpResponse.Content.ReadAsStringAsync();

                    var response = JsonSerializer.Deserialize<TResponse>(responseStr)!;

                    return response;
                }  
            }
        }
    }
}
