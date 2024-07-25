using Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public record InputPostDTO
    {

        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        [JsonPropertyName("body")]
        public string Body { get; set; } = string.Empty;
        public int Idade { get; set; }

    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(InputPostDTO[]))]
    [JsonSerializable(typeof(IEnumerable<InputPostDTO>))]
    [JsonSerializable(typeof(Result<IEnumerable<InputPostDTO>>))]

    public partial class InputPostDTOsonSerializerContext : JsonSerializerContext;

}
