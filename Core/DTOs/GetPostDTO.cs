using Core.Models;
using Core.Results;
using System.Text.Json.Serialization;

namespace Core.DTOs
{
    public record GetPostDTO
    {
        public GetPostDTO(Post post){
            Title = post.Title;
            Body = post.Body;
        }

        public GetPostDTO(InputPostDTO post)
        {
            Title = post.Title;
            Body = post.Body;
        }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("body")]
        public string Body { get; set; } = string.Empty;
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(GetPostDTO[]))]
    [JsonSerializable(typeof(Result<GetPostDTO>[]))]
    [JsonSerializable(typeof(IEnumerable<GetPostDTO>))]
    [JsonSerializable(typeof(Result<IEnumerable<GetPostDTO>>))]

    public partial class GetPostJsonSerializerContext : JsonSerializerContext;
}
