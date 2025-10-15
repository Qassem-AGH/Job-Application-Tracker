using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Application_Tracker
{
    public class JobManager
    {
        //Här är attributen för klassen JobManager:
        //Applications | List<JobApplication> - Samling av alla ansökningar
        private List<JobApplication> Applications = new List<JobApplication>()
            {
            new JobApplication("IKEA", "Software Developer", JobApplication.Status.Applied, new DateTime(2025, 10, 1), null, 45000),
            new JobApplication("Spotify", "Backend Engineer", JobApplication.Status.Interview, new DateTime(2025, 9, 15), new DateTime(2025, 9, 20), 55000),
            new JobApplication("H&M", "Frontend Developer", JobApplication.Status.Offer, new DateTime(2025, 8, 30), new DateTime(2025, 9, 5), 50000),
            new JobApplication("Ericsson", "DevOps Engineer", JobApplication.Status.Rejected, new DateTime(2025, 7, 20), new DateTime(2025, 7, 25), 60000),
            new JobApplication("Volvo", "Data Scientist", JobApplication.Status.Applied, new DateTime(2025, 10, 5), null, 70000),
            new JobApplication("Klarna", "Full Stack Developer", JobApplication.Status.Interview, new DateTime(2025, 9, 10), new DateTime(2025, 9, 15), 65000),
            new JobApplication("Tetra Pak", "System Architect", JobApplication.Status.Offer, new DateTime(2025, 8, 25), new DateTime(2025, 8, 30), 80000),
            new JobApplication("ABB", "Cloud Engineer", JobApplication.Status.Rejected, new DateTime(2025, 7, 15), new DateTime(2025, 7, 20), 72000)
        };

        //Metoder:
        //AddJob() – lägger till en ny ansökan
        public void AddJob()
        {
            bool addingJob = true;
            while (addingJob)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("==========================================");
                Console.WriteLine("|-+-- Adding a new job application ---+--|");
                Console.WriteLine("==========================================");
                Console.WriteLine("");
                Console.ResetColor();

                // Input från användaren

                //Input för företagsnamn
                Console.WriteLine("Enter company name:");
                Console.WriteLine("-------------------");
                string companyName = Console.ReadLine();

                //Här validerar vi att användaren inte lämnar fältet tomt while loop
                while (string.IsNullOrWhiteSpace(companyName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Company name cannot be empty. Please enter a valid company name:");
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.ResetColor();
                    companyName = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Company name accepted.");
                Console.WriteLine("----------------------");
                Console.ResetColor();

                //Input för positionstitel
                Console.WriteLine("Enter position title:");
                string positionTitle = Console.ReadLine();

                //Här validerar vi att användaren inte lämnar fältet tomt while loop
                while (string.IsNullOrWhiteSpace(positionTitle))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Position title cannot be empty. Please enter a valid position title:");
                    Console.WriteLine("--------------------------------------------------------------------");
                    Console.ResetColor();
                    positionTitle = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Position title accepted.");
                Console.WriteLine("------------------------");
                Console.ResetColor();

                //Input för status
                Console.WriteLine("Enter application status (Applied, Interview, Offer, Rejected):");
                string statusInput = Console.ReadLine();

                //Här validerar vi att användaren anger en giltig status while loop
                while (!Enum.TryParse(typeof(JobApplication.Status), statusInput, out object statusObj))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid status. Please enter one of the following: Applied, Interview, Offer, Rejected.");
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    statusInput = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Status accepted.");
                Console.WriteLine("----------------");
                Console.ResetColor();

                //Input för ansökningsdatum
                Console.WriteLine("Enter application date (yyyy-MM-dd):");
                string applicationDateInput = Console.ReadLine();

                //Här validerar vi att användaren anger ett giltigt datum while loop
                DateTime applicationDate;
                while (!DateTime.TryParse(applicationDateInput, out applicationDate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
                    Console.WriteLine("----------------------------------------------");
                    Console.ResetColor();
                    applicationDateInput = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Application date accepted.");
                Console.WriteLine("--------------------------");
                Console.ResetColor();

                //Input för svarsdatu
                Console.WriteLine("Enter response date (yyyy-MM-dd) or leave empty if not applicable:");
                string responseDateInput = Console.ReadLine();
                DateTime? responseDate = null;

                //Här validerar vi att användaren anger ett giltigt datum eller lämnar tomt while loop
                while (!string.IsNullOrWhiteSpace(responseDateInput) && !DateTime.TryParse(responseDateInput, out DateTime parsedDate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid date format. Please use yyyy-MM-dd or leave empty.");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.ResetColor();
                    responseDateInput = Console.ReadLine();
                }
                if (!string.IsNullOrWhiteSpace(responseDateInput))
                {
                    responseDate = DateTime.Parse(responseDateInput);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Response date accepted.");
                Console.WriteLine("-----------------------");
                Console.ResetColor();

                //Input för löneanspråk
                Console.WriteLine("Enter salary expectation (in SEK):");
                string salaryExpectationInput = Console.ReadLine();

                int salaryExpectation;
                //Här validerar vi att användaren anger ett giltigt löneanspråk while loop
                while (!int.TryParse(salaryExpectationInput, out salaryExpectation) || salaryExpectation < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid salary expectation. Please enter a positive integer.");
                    Console.WriteLine("------------------------------------------------------------");
                    Console.ResetColor();
                    salaryExpectationInput = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Salary expectation accepted.");
                Console.WriteLine("----------------------------");
                Console.ResetColor();

                // Skapa en ny ansökan och lägg till i listan
                JobApplication.Status status = (JobApplication.Status)Enum.Parse(typeof(JobApplication.Status), statusInput);
                JobApplication newApplication = new JobApplication(companyName, positionTitle, status, applicationDate, responseDate, salaryExpectation);
                Applications.Add(newApplication);

                //Bekräftelse till användaren att ansökan lagts till i listan 
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("New job application added successfully!");
                Console.WriteLine("---------------------------------------");
                Console.ResetColor();

                //Visa sammanfattning av den nya ansökan till användaren 
                Console.WriteLine(newApplication.GetSummary());

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("---------------------------------------");
                Console.ResetColor();

                //Fråga användaren om de vill lägga till en till ansökan
                Console.WriteLine("Do you want to add another job application? (y/n)");
                string continueInput = Console.ReadLine();

                if (continueInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    addingJob = false;
                }
            }
        }

        //UpdateStatus() – ändrar status på en befintlig ansökan
        public void UpdateStatus()
        {
            bool updatingStatus = true;
            while (updatingStatus)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("========================================");
                Console.WriteLine("|--+--- Updating job application ---+--|");
                Console.WriteLine("========================================");
                Console.WriteLine("");
                Console.ResetColor();

                //Visa alla ansökningar med indexnummer med while loop

                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("List of Job Applications:");
                Console.ResetColor();

                for (int i = 0; i < Applications.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Applications[i].GetSummary()}");
                    Console.WriteLine("--------------------------------------------------");
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Choose the number of the application you want to update:");
                Console.ResetColor();

                //Val av ansökan att uppdatera med validering while loop
                string selectedInput = Console.ReadLine();
                int selectedIndex;
                while (!int.TryParse(selectedInput, out selectedIndex) || selectedIndex < 1 || selectedIndex > Applications.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid selection. Please enter a valid number from the list:");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.ResetColor();
                    selectedInput = Console.ReadLine();
                }
                JobApplication selectedApp = Applications[selectedIndex - 1];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have selected:");
                Console.WriteLine("-------------------");
                Console.ResetColor();
                Console.WriteLine(selectedApp.GetSummary());

                //Ny status att uppdatera till med validering while loop
                Console.WriteLine("Enter new status (Applied, Interview, Offer, Rejected):");
                string newStatusInput = Console.ReadLine();

                while (!Enum.TryParse(typeof(JobApplication.Status), newStatusInput, out object statusObj))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid status. Please enter one of the following: Applied, Interview, Offer, Rejected.");
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    newStatusInput = Console.ReadLine();
                }

                selectedApp.ApplicationStatus = (JobApplication.Status)Enum.Parse(typeof(JobApplication.Status), newStatusInput);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Status updated successfully.");
                Console.WriteLine("----------------------------");
                Console.ResetColor();
                Console.WriteLine("Updated application details:");

                //Visa den uppdaterade ansökan med GetSummary() metoden från JobApplication klassen
                Console.WriteLine(selectedApp.GetSummary());

                Console.WriteLine("Do you want to update another application? (y/n)");
                //Fråga användaren om de vill uppdatera en till ansökan med validering while loop
                string continueInput = Console.ReadLine();

                while (!continueInput.Equals("y", StringComparison.OrdinalIgnoreCase) && !continueInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no:");
                    Console.WriteLine("------------------------------------------------------");
                    Console.ResetColor();
                    continueInput = Console.ReadLine();
                }
                if (continueInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    updatingStatus = false;
                }
            }
        }

        //ShowAll() – visar alla ansökningar
        public void ShowAll()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("====================================");
            Console.WriteLine("|--+--- All Job Applications ---+--|");
            Console.WriteLine("====================================");
            Console.WriteLine("");
            Console.ResetColor();

            //Visa alla ansökningar med GetSummary() metoden från JobApplication klassen
            if (Applications.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No job applications found.");
                Console.ResetColor();
                return;
            }
            foreach (var app in Applications)
            {
                Console.WriteLine(app.GetSummary());
                Console.WriteLine("--------------------------------------------------");
            }
        }
        //ShowByStatus() – filtrerar med LINQ efter status 
        public void ShowByStatus()
        {
            bool filteringByStatus = true;
            while (filteringByStatus)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=======================================");
                Console.WriteLine("|--+--- Filter Job Applications ---+--|");
                Console.WriteLine("=======================================");
                Console.WriteLine("");
                Console.ResetColor();

                //Fråga användaren vilken status de vill filtrera på med validering while loop
                Console.WriteLine("Enter status to filter by (Applied, Interview, Offer, Rejected):");
                string statusInput = Console.ReadLine();

                while (!Enum.TryParse(typeof(JobApplication.Status), statusInput, out object statusObj))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid status. Please enter one of the following: Applied, Interview, Offer, Rejected.");
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    statusInput = Console.ReadLine();
                }
                JobApplication.Status filterStatus = (JobApplication.Status)Enum.Parse(typeof(JobApplication.Status), statusInput);

                //Filtrera ansökningar med LINQ
                var filteredApps = Applications.Where(a => a.ApplicationStatus == filterStatus).ToList();
                //Visa filtrerade ansökningar eller meddelande om inga hittades
                if (filteredApps.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"No job applications found with status: {filterStatus}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Job applications with status: {filterStatus}");
                    Console.ResetColor();
                    foreach (var app in filteredApps)
                    {
                        Console.WriteLine(app.GetSummary());
                        Console.WriteLine("--------------------------------------------------");
                    }
                }
                Console.WriteLine("Do you want to filter by another status? (y/n)");
                string continueInput = Console.ReadLine();

                while (!continueInput.Equals("y", StringComparison.OrdinalIgnoreCase) && !continueInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no:");
                    Console.WriteLine("------------------------------------------------------");
                    Console.ResetColor();
                    continueInput = Console.ReadLine();
                }
                if (continueInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    filteringByStatus = false;
                    Console.WriteLine("Returning to main menu...");
                }
                else
                {
                    filteringByStatus = true;
                }
            }
        }

        //ShowStatistics() – visar statistik med LINQ (Count, Average, OrderBy, Where) (VG del)
        public void ShowStatistics()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====================================");
            Console.WriteLine("|--+--- Job Application Stats ---+--|");
            Console.WriteLine("=====================================");
            Console.WriteLine("");
            Console.ResetColor();

            //Totalt antal ansökningar
            int totalApplications = Applications.Count;
            Console.WriteLine($"Total job applications: {totalApplications}");
            Console.WriteLine("-------------------------------------");

            //Antal per status 
            var statusCounts = Applications
                .GroupBy(a => a.ApplicationStatus)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToList();

            Console.WriteLine("Applications by status:");

            foreach (var statusCount in statusCounts)
            {
                Console.WriteLine($"{statusCount.Status}: {statusCount.Count}");
            }

            Console.WriteLine("-------------------------------------");

            //Genomsnittlig svarstid
            var averageResponseTime = Applications
                .Where(a => a.ResponseDate != null)
                .Average(a => (a.ResponseDate - a.ApplicationDate)?.TotalDays);

            Console.WriteLine($"Average response time (in days): {averageResponseTime:F2}");
            Console.WriteLine("-------------------------------------");

            // Sortera ansökningar efter datum (OrderBy)
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Press Enter to see applications ordered by application date:");
            Console.ResetColor();
            Console.ReadLine();
            var orderedApps = Applications.OrderBy(a => a.ApplicationDate).ToList();
            foreach (var app in orderedApps)
            {
                Console.WriteLine(app.GetSummary());
                Console.WriteLine("--------------------------------------------------");
            }
        }

        //Skapa ett extra filter, t.ex. “Visa ansökningar utan svar äldre än 14 dagar”
        public void ShowUnansweredOlderThan()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================");
            Console.WriteLine("|--+--- Applications Without Response ---+--|");
            Console.WriteLine("==============================================");
            Console.WriteLine("");
            Console.ResetColor();

            //Filtrera ansökningar utan svar äldre än 14 dagar med LINQ 
            Console.WriteLine("Enter the number of days to filter applications without response:");
            Console.WriteLine("-----------------------------------------------------------------");

            string daysInput = Console.ReadLine();
            int days;
            while (!int.TryParse(daysInput, out days) || days < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive integer for days:");
                Console.WriteLine("-------------------------------------------------------");
                Console.ResetColor();
                daysInput = Console.ReadLine();
            }
            var filteredApps = Applications
                .Where(a => a.ResponseDate == null && (DateTime.Now - a.ApplicationDate).TotalDays > days)
                .ToList();
            if (filteredApps.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No job applications found without response older than {days} days.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Job applications without response older than {days} days:");
                Console.ResetColor();
                foreach (var app in filteredApps)
                {
                    Console.WriteLine(app.GetSummary());
                    Console.WriteLine("--------------------------------------------------");
                }
            }
            Console.WriteLine("Do you want to filter by another number of days? (y/n)");
            string continueInput = Console.ReadLine();
            while (!continueInput.Equals("y", StringComparison.OrdinalIgnoreCase) && !continueInput.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no:");
                Console.WriteLine("------------------------------------------------------");
                Console.ResetColor();
                continueInput = Console.ReadLine();
            }
            if (continueInput.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                ShowUnansweredOlderThan();
            }
        }

        //Ta bort en ansökan 
        public void DeleteApplication()
        {
            bool deletingApp = true;
            while (deletingApp)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("==========================================");
                Console.WriteLine("|--+--- Deleting a job application ---+--|");
                Console.WriteLine("==========================================");
                Console.WriteLine("");
                Console.ResetColor();

                //Visa alla ansökningar med indexnummer med while loop
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("List of Job Applications:");
                Console.WriteLine("-------------------------");
                Console.ResetColor();

                for (int i = 0; i < Applications.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Applications[i].GetSummary()}");
                    Console.WriteLine("--------------------------------------------------");
                }

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Choose the number of the application you want to delete:");
                Console.ResetColor();

                //Val av ansökan att ta bort med validering while loop
                string selectedInput = Console.ReadLine();
                int selectedIndex;
                while (!int.TryParse(selectedInput, out selectedIndex) || selectedIndex < 1 || selectedIndex > Applications.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid selection. Please enter a valid number from the list:");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.ResetColor();
                    selectedInput = Console.ReadLine();
                }
                JobApplication selectedApp = Applications[selectedIndex - 1];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You have selected to delete:");
                Console.WriteLine("----------------------------");
                Console.ResetColor();
                Console.WriteLine(selectedApp.GetSummary());

                //Bekräftelse från användaren att de vill ta bort ansökan med validering while loop
                Console.WriteLine("Are you sure you want to delete this application? (y/n)");
                string confirmInput = Console.ReadLine();
                while (!confirmInput.Equals("y", StringComparison.OrdinalIgnoreCase) && !confirmInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no:");
                    Console.WriteLine("------------------------------------------------------");
                    Console.ResetColor();
                    confirmInput = Console.ReadLine();
                }
                if (confirmInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    Applications.Remove(selectedApp);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Application deleted successfully.");
                    Console.WriteLine("-------------------------------");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Deletion cancelled. No changes made.");
                    Console.WriteLine("-------------------------------------");
                    Console.ResetColor();
                }
                Console.WriteLine("Do you want to delete another application? (y/n)");
                string continueInput = Console.ReadLine();
                while (!continueInput.Equals("y", StringComparison.OrdinalIgnoreCase) && !continueInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no:");
                    Console.WriteLine("------------------------------------------------------");
                    Console.ResetColor();
                    continueInput = Console.ReadLine();
                }
                if (continueInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    deletingApp = false;
                }
            }
        }
    }
}
