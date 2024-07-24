using System.Text.Json.Serialization;

namespace Core.Models
{
    public record Todo (int Id, string Title, DateOnly? DueBy = null, bool IsComplete = false);


    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Todo[]))]
    public partial class TodoJsonSerializerContext : JsonSerializerContext;
}

