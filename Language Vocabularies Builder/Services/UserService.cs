using Language_Vocabularies_Builder.Interfaces;
using Language_Vocabularies_Builder.Models;
using Newtonsoft.Json;
using System.Text;
namespace Language_Vocabularies_Builder.Services;
public class UserService : IUserService
{
    private readonly List<User> users;
    public UserService()
    {
        users = new List<User>();
    }

    public (bool, bool) AddVocabulary(int userID, int vocabID)
    {
        var userFound = false;
        var vocabFound = false;

        var uContent = File.ReadAllText(Constants.USERS_PATH);
        List<User> Users = JsonConvert.DeserializeObject<List<User>>(uContent);

        var vContent = File.ReadAllText(Constants.VOCABULARIES_PATH);
        List<Vocabulary> Vocabs = JsonConvert.DeserializeObject<List<Vocabulary>>(vContent);

        var vocab = Vocabs.FirstOrDefault(Vocabulary => Vocabulary.Id == vocabID);
        if (vocab != null)
        {
            vocabFound = true;
            foreach (var User in Users)
            {
                if (User.Id == userID)
                {
                    List<Vocabulary> vocabularies = new List<Vocabulary>();
                    User.SavedVocabularies = vocabularies;

                    User.SavedVocabularies.Add(vocab);
                    userFound = true;
                    break;
                }
            }
        } else
        {
            vocabFound = false;
        }

        var result = JsonConvert.SerializeObject(Users, Formatting.Indented);
        File.WriteAllText(Constants.USERS_PATH, result);

        return (userFound, vocabFound);
    }
    public User Create(User user)
    {
        users.Add(user);
        var content = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(Constants.USERS_PATH, content);
        return user;
    }
    public bool Delete(int id)
    {
        var content = File.ReadAllText(Constants.USERS_PATH);
        List<User> Users = JsonConvert.DeserializeObject<List<User>>(content);

        foreach (var item in Users)
        {
            if (item.Id == id)
            {
                Users.Remove(item);
                break;
            }
        }
        var result = JsonConvert.SerializeObject(Users, Formatting.Indented);
        File.WriteAllText(Constants.USERS_PATH, result);

        return true;
    }
    public IEnumerable<User> GetAll()
    {
        var content = File.ReadAllText(Constants.USERS_PATH);
        return JsonConvert.DeserializeObject<IEnumerable<User>>(content);
    }
    public User GetById(int id)
    {
        var user = GetAll().FirstOrDefault(user => user.Id == id);
        return user;
    }
    public User Update(int id, User user)
    {
        var content = File.ReadAllText(Constants.USERS_PATH);
        IEnumerable<User> Users = JsonConvert.DeserializeObject<IEnumerable<User>>(content);

        foreach (var item in Users)
        {
            if (item.Id == id)
            {
                item.Name = user.Name;
                break;
            }
        }
        var result = JsonConvert.SerializeObject(Users, Formatting.Indented);
        File.WriteAllText(Constants.USERS_PATH, result);

        return user;
    }
}
