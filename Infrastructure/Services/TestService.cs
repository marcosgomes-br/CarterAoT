using Core.DTOs;
using Core.Models;
using Core.Results;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;

[assembly: InternalsVisibleTo("TestAPIMinimal")]

namespace Infrastructure.Services
{
    public class TestService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : ITestService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        public IEnumerable<Post> TestPosts = [];



        public async Task<Result<IEnumerable<Post>>> GetPosts()
        {
            
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(ServiceBase.ConnectService(configuration.GetSection("TesteServiceUrl").Value ?? "", HttpMethod.Get));

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                    TestPosts = await JsonSerializer.DeserializeAsync<IEnumerable<Post>>(contentStream, ServiceBase.options) ?? [];
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
        {
            if (!ValidarIdade(inputPostDTO.Idade))
            {
                return new Result<Post>();
            }

            var post = new Post()
            {
                Id = 123445,
                Body = inputPostDTO.Body,
                Title = inputPostDTO.Title,
                UserId = inputPostDTO.UserId,
                Idade = inputPostDTO.Idade,
            };

            return new Result<Post>(post);

        }


        internal bool ValidarIdade(int idade) {
            return idade > 18;
        }

    }
}
