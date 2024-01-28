using Language_Vocabularies_Builder.Models;
namespace Language_Vocabularies_Builder.Interfaces;
public interface IVocabularyService
{
    Vocabulary Create(Vocabulary vocabulary);
    Vocabulary Update(int id, Vocabulary vocabulary);
    bool Delete(int id);
    List<Vocabulary> GetAll();
}