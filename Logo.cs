using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Application_Tracker
{
    public class Logo
    {
        //Metod för att visa en enkel logotyp med en laddningsanimation
        public void DisplayLogo()
        {
            string loadingText = "Welcome to Job Application Tracker";
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int centerY = windowHeight / 2;
            int padding = (windowWidth - loadingText.Length) / 2;
            // Simulate loading animation from 1% to 100%
            for (int i = 1; i <= 100; i++)
            {
                Console.Clear();

                // Print the centered message
                Console.SetCursorPosition(padding, centerY);
                Console.WriteLine(loadingText);

                string percentage = $"Loading... {i}%";
                CenterText(percentage);

                Thread.Sleep(30);
            }
            Console.Clear();
            Console.WriteLine("\n");

            string logo = @"  
       _       _                            _ _           _   _               _______             _             
      | |     | |         /\               | (_)         | | (_)             |__   __|           | |            
      | | ___ | |__      /  \   _ __  _ __ | |_  ___ __ _| |_ _  ___  _ __      | |_ __ __ _  ___| | _____ _ __ 
  _   | |/ _ \| '_ \    / /\ \ | '_ \| '_ \| | |/ __/ _` | __| |/ _ \| '_ \     | | '__/ _` |/ __| |/ / _ \ '__|
 | |__| | (_) | |_) |  / ____ \| |_) | |_) | | | (_| (_| | |_| | (_) | | | |    | | | | (_| | (__|   <  __/ |   
  \____/ \___/|_.__/  /_/    \_\ .__/| .__/|_|_|\___\__,_|\__|_|\___/|_| |_|    |_|_|  \__,_|\___|_|\_\___|_|   
                               | |   | |                                                                        
                               |_|   |_|                                                                        
            ";

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            CenterText(logo);
            Console.ResetColor();

            Console.WriteLine("");
            string message = "Press Enter to start application...";
            Console.ForegroundColor = ConsoleColor.Green;
            CenterText(message);
            Console.ResetColor();
            Console.ReadLine();
        }
        //Metod för att visa ett avslutningsmeddelande med logotyp
        public void EndLogo()
        {
            Console.Clear();

            string goodbyeLogo = @"  
       _       _                            _ _           _   _               _______             _             
      | |     | |         /\               | (_)         | | (_)             |__   __|           | |            
      | | ___ | |__      /  \   _ __  _ __ | |_  ___ __ _| |_ _  ___  _ __      | |_ __ __ _  ___| | _____ _ __ 
  _   | |/ _ \| '_ \    / /\ \ | '_ \| '_ \| | |/ __/ _` | __| |/ _ \| '_ \     | | '__/ _` |/ __| |/ / _ \ '__|
 | |__| | (_) | |_) |  / ____ \| |_) | |_) | | | (_| (_| | |_| | (_) | | | |    | | | | (_| | (__|   <  __/ |   
  \____/ \___/|_.__/  /_/    \_\ .__/| .__/|_|_|\___\__,_|\__|_|\___/|_| |_|    |_|_|  \__,_|\___|_|\_\___|_|   
                               | |   | |                                                                        
                               |_|   |_|                                                                        
            ";


            string goodbyeLogo2 = @"
   _____                 _ _                
  / ____|               | | |               
 | |  __  ___   ___   __| | |__  _   _  ___ 
 | | |_ |/ _ \ / _ \ / _` | '_ \| | | |/ _ \
 | |__| | (_) | (_) | (_| | |_) | |_| |  __/
  \_____|\___/ \___/ \__,_|_.__/ \__, |\___|
                                  __/ |     
                                 |___/   

            ";

            Console.ForegroundColor = ConsoleColor.Red;
            CenterText(goodbyeLogo);
            Console.ResetColor();
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            CenterText(goodbyeLogo2);
            Console.ResetColor();
            Console.WriteLine("");

            string message = "Thank you for using Job Application Tracker. Goodbye!";
            Console.ForegroundColor = ConsoleColor.Green;
            CenterText(message);
            Console.ResetColor();
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
        // Metod för att centrera text i konsolfönstret 
        static void CenterText(string text)
        {
            string[] lines = text.Split('\n');
            foreach (string line in lines)
            {
                int padding = (Console.WindowWidth - line.Length) / 2;
                Console.WriteLine(new string(' ', Math.Max(padding, 0)) + line);
            }
        }
    }
}
