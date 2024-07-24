using Core.Models;
using Core.Services;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace Infrastructure.Services
{
    public class TestService(IHttpClientFactory httpClientFactory) : ITestService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        public IEnumerable<Post> TestPosts = new List<Post>();

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.TypeInfoResolverChain.Add(PostJsonSerializerContext.Default);


            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/posts")
            {
                Headers =
            {
                    { HeaderNames.Accept, "application/json; charset=UTF-8" }
            }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                TestPosts = await JsonSerializer.DeserializeAsync<IEnumerable<Post>>(contentStream, jsonOptions) ?? [];
            }

            return TestPosts;
        }
    }
}
