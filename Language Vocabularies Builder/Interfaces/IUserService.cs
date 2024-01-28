using Language_Vocabularies_Builder.Models;
namespace Language_Vocabularies_Builder.Interfaces;
public interface IUserService
{
    User Create(User user);
    User Update(int id, User user);
    bool Delete(int id);
    User GetById(int id);
    IEnumerable<User> GetAll();
    (bool, bool) AddVocabulary(int userID, int vocabID);
}