using Language_Vocabularies_Builder.Interfaces;
using Language_Vocabularies_Builder.Models;
using Language_Vocabularies_Builder.Services;
namespace Language_Vocabularies_Builder.Menu;
public class UserMenu
{
    private readonly UserService userService;
    public UserMenu()
    {
        userService = new UserService();
    }
    public void Show()
    {
        while (true)
        {
            Console.WriteLine("=====User Menu\n===== ");
            Console.WriteLine("1.Create");
            Console.WriteLine("2.Update");
            Console.WriteLine("3.Delete");
            Console.WriteLine("4.Get By Id");
            Console.WriteLine("5.Get All");
            Console.WriteLine("6.Add vocabulary to user");
            Console.WriteLine("7.Exit");
            Console.WriteLine("Choose an option");
            string choice = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Choose a valid option");
                choice = Console.ReadLine();
            }
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Create();
                    Console.WriteLine();
                    break;
                case "2":
                    Console.Clear();
                    Update();
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Clear();
                    Delete();
                    Console.WriteLine();
                    break;
                case "4":
                    GetById();
                    Console.WriteLine();
                    break;
                case "5":
                    Console.Clear();
                    GetAll();
                    Console.WriteLine();
                    break;
                case "6":
                    Console.Clear();
                    AddVocabulary();
                    Console.WriteLine();
                    return;
                case "7":
                    Console.Clear();
                    Console.WriteLine("Exit");
                    Console.WriteLine();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice,Please try again one more time");
                    Console.WriteLine();
                    break;

            }
        }
    }

    private void AddVocabulary()
    {
        Console.WriteLine("\n=== Create Note ===");
        Console.WriteLine("Enter User Id:");
        int UserId;
        while (!int.TryParse(Console.ReadLine(), out UserId))
        {
            Console.WriteLine("Enter a valid id");
        }
        Console.WriteLine("Enter Vocabulary Id:");
        int VocabularyId;

        while (!int.TryParse(Console.ReadLine(), out VocabularyId))
        {
            Console.WriteLine("Enter a valid id");
        }

        userService.AddVocabulary(UserId, VocabularyId);

        Console.WriteLine("Note created!");
    }

    private void Create()
    {
        Console.WriteLine("\n=== Create User ===");
        Console.WriteLine("Enter Id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Enter a valid id");
        }
        Console.Write("Enter user Name: ");
        string name = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(name))
        {
            Console.Write("Enter valid input: ");
            name = Console.ReadLine();
        }
        var newUser = new User
        {
            Id = id,
            Name = name,
        };

        userService.Create(newUser);
        Console.WriteLine("User created successfully.");
    }
    private void Update()
    {
        Console.WriteLine("\n==Update User==");
        Console.WriteLine("Enter id:");
        int userId;
        while (!int.TryParse(Console.ReadLine(), out userId))
        {
            Console.WriteLine("Enter a valid Id:");
        }
        var existUser = userService.GetById(userId);
        if (existUser != null)
        {
            Console.WriteLine("Enter update Name:");
            string updatedName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedName))
            {
                Console.WriteLine("Enter a valid name");
                updatedName = Console.ReadLine();
            }
            var user = userService.GetById(userId);
            if (user != null)
            {
                user.Name = updatedName;
                userService.Update(userId, user);
                Console.WriteLine("User updated successfully");
            }
            else
            {
                Console.WriteLine("User is not found");
            }
        }
    }

    private void Delete()
    {
        Console.WriteLine("===Delete User===");
        Console.WriteLine("Enter userId to delete");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Please enter a valid id");
        }
        if (userService.Delete(id))
        {
            Console.WriteLine("User deleted successfully");
        }
        else
        {
            Console.WriteLine($"User with Id {id} not found");
        }
    }
    private void GetById()
    {
        Console.WriteLine("====Get By Id====");
        Console.WriteLine("Enter the Id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Enter a valid id");
        }
        var user = userService.GetById(id);
        if (user == null)
        {
            Console.WriteLine("User not found");
        }
        else Console.WriteLine($"Id:{user.Id} | Name {user.Name} ");
    }
    private void GetAll()
    {
        Console.WriteLine("===View all User==");
        IEnumerable<User> users = userService.GetAll();
        if (users.Count() > 0)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Id:{user.Id} | {user.Name}");
            }
        }
        else
        {
            Console.WriteLine("Sorry,User not found");
        }

    }
}

