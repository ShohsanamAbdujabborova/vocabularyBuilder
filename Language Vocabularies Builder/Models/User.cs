using System.Text.Json.Serialization;
namespace Language_Vocabularies_Builder.Models;
public class User
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("sVocabularies")]
    public List<Vocabulary> SavedVocabularies { get; set; }
}