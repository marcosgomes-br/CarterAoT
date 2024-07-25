using System.Text.Json.Serialization;
using Core.Results;

namespace Core.Models
{
    public record Post
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("body")]
        public string Body { get; set; } = string.Empty;
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Post[]))]
    [JsonSerializable(typeof(Result<Post>[]))]
    [JsonSerializable(typeof(IEnumerable<Post>))]
    [JsonSerializable(typeof(Result<IEnumerable<Post>>))]

    public partial class PostJsonSerializerContext : JsonSerializerContext;
}
