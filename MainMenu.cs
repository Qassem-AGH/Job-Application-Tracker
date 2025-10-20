using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Application_Tracker
{
    public class MainMenu
    {
        //Menyvalen ska kunna väljas genom att skriva in en siffra (1-8).
        public void ShowMainMenu()
        {
            // Loop för att visa menyn tills användaren väljer att avsluta
            bool exit = false;
            JobManager jobManager = new JobManager();
            Logo logo = new Logo();
            logo.DisplayLogo();

            while (!exit)
            {
                Console.Clear();

                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        jobManager.AddJob();
                        break;
                    case "2":
                        jobManager.ShowAll();
                        break;
                    case "3":
                        jobManager.ShowByStatus();
                        break;
                    case "4":
                        jobManager.SortApplicationsByDate();
                        break;
                    case "5":
                        jobManager.ShowStatistics();
                        break;
                    case "6":
                        jobManager.UpdateStatus();
                        break;
                    case "7":
                        jobManager.DeleteApplication();
                        break;
                    case "8":
                        exit = true;
                        logo.EndLogo();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please select a number between 1 and 8.");
                        Console.ResetColor();
                        break;
                }
                if (!exit)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
        // Metod för att visa menyn med dekorativa element 
        private void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═════════════════════════════════════════════╗");
            Console.WriteLine("║----+---+- Job Application Manager -+---+----║");
            Console.WriteLine("╠═════════════════════════════════════════════╣");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("║        1.  Add New Application              ║");
            Console.WriteLine("║                                             ║");
            Console.WriteLine("║        2.  View All Applications            ║");
            Console.WriteLine("║                                             ║");
            Console.WriteLine("║        3.  Filter Applications by Status    ║");
            Console.WriteLine("║                                             ║");
            Console.WriteLine("║        4.  Sort Applications by Date        ║");
            Console.WriteLine("║                                             ║");
            Console.WriteLine("║        5.  View Statistics                  ║");
            Console.WriteLine("║                                             ║");
            Console.WriteLine("║        6.  Update Application Status        ║");
            Console.WriteLine("║                                             ║");
            Console.WriteLine("║        7.  Delete an Application            ║");
            Console.WriteLine("║                                             ║");
            Console.WriteLine("║        8.  Exit                             ║");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╚═════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Select an option (1–8): ");
        }
    }
}
