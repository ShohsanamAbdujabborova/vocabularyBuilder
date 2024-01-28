using Language_Vocabularies_Builder.Interfaces;
using Language_Vocabularies_Builder.Models;
using Newtonsoft.Json;
using System.Text;

namespace Language_Vocabularies_Builder.Services;
public class VocabularyService : IVocabularyService
{
    private readonly List<Vocabulary> vocabularies;
    public VocabularyService()
    {
        vocabularies = new List<Vocabulary>();
    }
    public Vocabulary Create(Vocabulary vocabulary)
    {
        vocabularies.Add(vocabulary);

        var content = JsonConvert.SerializeObject(vocabularies, Formatting.Indented);
        File.WriteAllText(Constants.VOCABULARIES_PATH, content);
        return vocabulary;
    }
    public List<Vocabulary> GetAll()
    {
        var content = File.ReadAllText(Constants.VOCABULARIES_PATH);
        return JsonConvert.DeserializeObject<List<Vocabulary>>(content);
    }
    public Vocabulary Update(int id, Vocabulary vocabulary)
    {
        var content = File.ReadAllText(Constants.VOCABULARIES_PATH);
        List<Vocabulary> Vocabularies = JsonConvert.DeserializeObject<List<Vocabulary>>(content);

        foreach (var item in vocabularies)
        {
            if (item.Id == id)
            {
                item.Language = vocabulary.Language;
                item.TranslateLanguage = vocabulary.TranslateLanguage;
                item.Word = vocabulary.Word;
                item.Definition = vocabulary.Definition;
                item.Synonyms = vocabulary.Synonyms;
                item.Example = vocabulary.Example;

                break;
            }
        }
        var result = JsonConvert.SerializeObject(vocabularies, Formatting.Indented);
        File.WriteAllText(Constants.VOCABULARIES_PATH, result);

        return vocabulary;
    }
    public bool Delete(int id)
    {
        var content = File.ReadAllText(Constants.VOCABULARIES_PATH);
        List<Vocabulary> Vocabularies = JsonConvert.DeserializeObject<List<Vocabulary>>(content);

        foreach (var item in vocabularies)
        {
            if (item.Id == id)
            {
                vocabularies.Remove(item);
                break;
            }
        }
        var result = JsonConvert.SerializeObject(vocabularies, Formatting.Indented);
        File.WriteAllText(Constants.VOCABULARIES_PATH, result);

        return true;
    }
    public Vocabulary GetById(int vocabularyId)
    {
        var vocabulary = GetAll().FirstOrDefault(vocabulary => vocabulary.Id == vocabularyId)
        ?? throw new Exception("User is not found");//?? bu null bo'sa degani
        return vocabulary;
    }
}

