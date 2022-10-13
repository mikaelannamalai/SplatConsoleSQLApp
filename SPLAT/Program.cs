// See https://aka.ms/new-console-template for more information
using SPLAT;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
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
                    Console.WriteLine("To View: v");
                    Console.WriteLine("To create: c");
                    Console.WriteLine("To delete: d");
                    Console.WriteLine("To update: u");

                    string tickInput = "start";Console.WriteLine("To View: v");
                        tickInput = Console.ReadLine();

                    
                    while (tickInput.ToLower() != "q")
                    {
                        TicketController ticketController = TicketController.getInstance();
                        int userID, projectID;
                        String title, description, date, status, priority, target_date, actual_date;

                        switch (tickInput.ToLower())
                        {
                            case "v":
                                { 
                                }
                                
                                
                                
                                
                                ; break;


                            case "c":
                                {
                                 Console.Write("\nEnter your UserID: ");
                                 userID = int.Parse(Console.ReadLine());
                                 Console.Write("\nEnter the Project ID: ");
                                 projectID = int.Parse(Console.ReadLine());
                                 Console.Write("\nEnter the ticket title: ");
                                 title = Console.ReadLine();
                                 Console.Write("\nEnter a description: ");
                                 description= Console.ReadLine();
                                 date = DateTime.Now.ToShortDateString();
                                 Console.Write("\nEnter a status: ");
                                 status = Console.ReadLine();
                                 Console.Write("\nEnter the priority level: ");
                                 priority = Console.ReadLine();
                                 Console.Write("\nEnter a target end date: ");
                                 target_date = Console.ReadLine();
                                 
                                ticketController.addTicket(userID, projectID, title, description, date, status, priority, target_date);
                                


                                }
                                
                                
                                
                                
                                Console.WriteLine(); break;

                                
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
