using System.Text.Json.Serialization;
namespace Language_Vocabularies_Builder.Models;
public class Vocabulary
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("userId")]
    public int UserId { get; set; }
    [JsonPropertyName("language")]
    public string Language { get; set; }//qaysi tiligi
    [JsonPropertyName("translateLanguage")]
    public string TranslateLanguage { get; set; }//qaysi tilga tarjima qilishi kereligi
    [JsonPropertyName("word")]
    public string Word { get; set; }
    [JsonPropertyName("definition")]
    public string Definition { get; set; }
    [JsonPropertyName("synonyms")]
    public string Synonyms { get; set; }
    [JsonPropertyName("example")]
    public string Example { get; set; }
}
