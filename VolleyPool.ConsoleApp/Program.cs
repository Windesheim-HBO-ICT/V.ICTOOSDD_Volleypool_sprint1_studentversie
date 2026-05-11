// See https://aka.ms/new-console-template for more information
using VolleyPool.ConsoleApp.Helpers;
using VolleyPool.Core.Models;
using VolleyPool.Core.Services;
using VolleyPool.Data.Repostories;

////////////////////////////////////////////////////////////////////////
// Repository and Service instances
// For simplicity, repository and service instances are created manually.
// In production-ready environments, Dependence Injection (DI) is applied by
// using Inversion of Control (IoC) instead.
////////////////////////////////////////////////////////////////////////

// Repository instances
var parentRepository = new ParentRepository();
var playerRepository = new PlayerRepository();

// Service instance
var authService = new AuthService(parentRepository, playerRepository);

// Console helper
var consolePrinter = new ConsolePrinter();


////////////////////////////////////////////////////////////////////////
// Welcome message
////////////////////////////////////////////////////////////////////////
Console.WriteLine("Welcome to VolleyPool, transport your child's team like a rocket");

////////////////////////////////////////////////////////////////////////
// Runner loop
////////////////////////////////////////////////////////////////////////
var quit = false;
while (!quit)
{
    consolePrinter.PrintBlock("Menu");

    if(authService.LoggedInParent != null)
    {
        consolePrinter.PrintMessage("Logged in: " + authService.LoggedInParent.Name);
    } else
    {
        consolePrinter.PrintMessage("Not signed in");
    }

    var menuChoice = ShowMenu(); // Method call. Use Ctrl + Left Click to view implementation details.


    switch (menuChoice)
    {
        case null:
            break;
        case "":
            break;
        case "1":
            ShowRegister();
            break;
        case "2":
            StopApplication(menuChoice);
            break;

            // For sake of simplicity the 'numbers' are hardcoded
            // This is bad practice, use global consts or enums
            // instead.

    }
    
    consolePrinter.PrintDebugBlock("Show data");
    ShowData();
}

////////////////////////////////////////////////////////////////////////
// Menu
////////////////////////////////////////////////////////////////////////
string ShowMenu()
{ 
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("Enter 1 to register");
    Console.WriteLine("Enter 2 to quit");

    var menuChoice = Console.ReadLine();

    if(menuChoice == "" || menuChoice == null)
    {
        consolePrinter.PrintError("No valid choice has been made, we're leaving you. Bye.");
        Console.ReadKey();
        System.Environment.Exit(0);
    }

    return menuChoice;
}

////////////////////////////////////////////////////////////////////////
// Menu
////////////////////////////////////////////////////////////////////////
void StopApplication(string menuChoice)
{
    Console.WriteLine("Bye bye.");
    Thread.Sleep(2000); // Wait 2000 milliseconds (2 sec.) for exiting
    System.Environment.Exit(0);
}


////////////////////////////////////////////////////////////////////////
// Register
////////////////////////////////////////////////////////////////////////
void ShowRegister() {

    consolePrinter.PrintBlock("Register parent"); // Use Ctrl + Left Click to view implementation details.

    // For the sake of simplicity this is a linear flow. What a pity if
    // it fails, the program exits and the user should start the whole
    // flow/program again. Best practice is to remember the values, provide
    // retries and prefill the correct values. This could be done with a
    // while loop.

    // Collecting user inputs
    // This code contains a lot of duplicated code. This could be improved
    // by creating a helper like this:
    // CollectUserInput("Enter player id"). It returns the collected value.
    Console.WriteLine("Enter player id");
    var playerId = Console.ReadLine();
    Console.WriteLine("Enter player birthdate. You should know that date!. Example 21-1-2000");
    var playerBirthDateString = Console.ReadLine();
    Console.WriteLine("Enter your name");
    var name = Console.ReadLine();
    Console.WriteLine("Enter your email");
    var email = Console.ReadLine();
    Console.WriteLine("Enter your phone number");
    var phone = Console.ReadLine();
    Console.WriteLine("Enter password for your account");
    var password = Console.ReadLine();

    // playerIdInt
    if (playerId == null || playerBirthDateString == null) return;
    var playerIdInt = int.Parse(playerId);

    // playerBirthDate
    var playerBirthDateArr = playerBirthDateString.Split("-");
    if (playerBirthDateArr.Length != 3) return;
    var year = int.Parse(playerBirthDateArr[2]);
    var month = int.Parse(playerBirthDateArr[1]);
    var day = int.Parse(playerBirthDateArr[0]);
    var playerBirthDate = new DateTime(year, month, day);


    var authResult = authService.Register(playerIdInt, playerBirthDate, name, email, phone, password); // For the sake of simplicity no null check has been made. This is bad practice!
    if (authResult != null)
    {
        consolePrinter.PrintSuccess("Registration completed");
    }
    else
    {
        consolePrinter.PrintError("Something went wrong.");
    }
}

////////////////////////////////////////////////////////////////////////
// Show data of repositories
////////////////////////////////////////////////////////////////////////
void ShowData()
{
    foreach (var parent in parentRepository.GetAll())
    {
       consolePrinter.PrintDebugMessage(parent.ToString());
    }

    foreach (var player in playerRepository.GetAll())
    {
        consolePrinter.PrintDebugMessage(player.ToString());
    }

}
