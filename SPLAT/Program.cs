// See https://aka.ms/new-console-template for more information
using SPLAT;
using Ticket;

DB.openConnection();
DB.closeConnection();

Console.WriteLine("Splat Console App");

Console.WriteLine("Enter P for Projects, T for Tickets, U for Users, Q to Quit");
try
{
    string input = "Start";
    
    while (input.ToLower() != "q") { 
        input= Console.ReadLine();

        switch (input.ToLower())
        {
            case "p": Console.WriteLine("Projects:"); break;

            case "t":
                {
                    Console.WriteLine("Tickets:");


                    string tickInput = "start";
                        tickInput = Console.ReadLine();

                    while (tickInput.ToLower() != "q")
                    {
                        switch (tickInput.ToLower())
                        {
                            case "v":Console.WriteLine(); break;


                            case "c": Console.WriteLine(); break;

                            case "d": Console.WriteLine(); break;

                            case "u": Console.WriteLine(); break;

                            case "q": Console.WriteLine("Quitting"); break;


                        }
                    }

                    break;
                }
            case "u": Console.WriteLine("Users:"); break;

            case "q": Console.WriteLine("Quitting"); break;


            default: { Console.WriteLine("Try again"); Console.WriteLine("Enter P for Projects, T for Tickets, U for Users, Q to Quit"); break; }
        }
    }
}
catch (Exception)
{

    throw;
}
