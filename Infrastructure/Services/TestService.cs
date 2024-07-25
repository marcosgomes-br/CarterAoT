using Core.DTOs;
using Core.Models;
using Core.Results;
using Core.Services;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace Infrastructure.Services
{
    public class TestService(IHttpClientFactory httpClientFactory) : ITestService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        public IEnumerable<Post> TestPosts = [];



        public async Task<Result<IEnumerable<Post>>> GetPosts()
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

            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                    TestPosts = await JsonSerializer.DeserializeAsync<IEnumerable<Post>>(contentStream, jsonOptions) ?? [];
                }
                else
                {
                     throw new Exception("Not Found");
                }
            }
            catch (Exception ex)
            {
                return new Exception(ex.Message, ex.InnerException);
            }
            

            return new Result<IEnumerable<Post>>(TestPosts);
        }

        public async Task<Result<Post>> InputPost(InputPostDTO inputPostDTO)
            => new Result<Post>
            (
                new Post() { 
                    Id = 123445,
                    Body = inputPostDTO.Body,
                    Title = inputPostDTO.Title,
                    UserId = inputPostDTO.UserId,
                } 
            );
    }
}
