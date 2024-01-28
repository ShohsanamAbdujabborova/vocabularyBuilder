using Language_Vocabularies_Builder.Services;
using Spectre.Console;
namespace Language_Vocabularies_Builder.Menu;
public class MainMenu
{
    private readonly UserMenu userMenu;
    private readonly VocabularyMenu vocabularyMenu;

    private readonly UserService userService;
    private readonly VocabularyService vocabularyService;

    public MainMenu()
    {
        userService = new UserService();
        vocabularyService = new VocabularyService();

        userMenu = new UserMenu();
        vocabularyMenu = new VocabularyMenu();
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.Write(new Markup("[red]====Welcome to our Language Vocabulary Builder====[/]\n"));
            AnsiConsole.Write(new Markup("[green]====MainMenu=====[/]\n\n"));
            AnsiConsole.Write(new Markup("[yellow]1.UserMenu[/]\n"));
            AnsiConsole.Write(new Markup("[yellow]2.VocabularyMenu[/]\n\n"));
            AnsiConsole.Write(new Markup("[red]3.Exit[/]\n"));
            Console.WriteLine();
            Console.WriteLine("Enter your choice:");
            string choice = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Enter a valid choice");
                choice = Console.ReadLine();
            }
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    userMenu.Show();
                    Console.WriteLine();
                    break;
                case "2":
                    Console.Clear();
                    vocabularyMenu.Show();
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Exiting the application.Goodbye");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice, try again one more time");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
