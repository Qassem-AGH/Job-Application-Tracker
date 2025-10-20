using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Application_Tracker
{
    public class JobApplication
    {
        //Här är atttributen för klassen JobApplication:
        public string CompanyName;
        public string PositionTitle;
        public enum Status { Applied, Interview, Offer, Rejected }
        public Status ApplicationStatus;
        public DateTime ApplicationDate;
        public DateTime? ResponseDate; // Nullable DateTime
        public int SalaryExpectation;

        //Konstruktor för att initiera en ny ansökan
        public JobApplication(string companyName, string positionTitle, Status applicationStatus, DateTime applicationDate, DateTime? responseDate, int salaryExpectation)
        {
            CompanyName = companyName;
            PositionTitle = positionTitle;
            ApplicationStatus = applicationStatus;
            ApplicationDate = applicationDate;
            ResponseDate = responseDate;
            SalaryExpectation = salaryExpectation;
        }

        //GetDaysSinceApplied() – returnerar antal dagar sedan ansökan skickades
        //Här är en metod för att få antal dagar sedan ansökan skickades
        public int GetDaysSinceApplied()
        {
            return (DateTime.Now - ApplicationDate).Days;
        }
        //Här är en metod för att få en sammanfattning av ansökan
        public string GetSummary()
        {
            string responseDateStr = ResponseDate.HasValue ? ResponseDate.Value.ToShortDateString() : "N/A";
            return $"Company: {CompanyName}, Position: {PositionTitle}, Status: {ApplicationStatus}, Applied On: {ApplicationDate.ToShortDateString()}, Response Date: {responseDateStr}, Salary Expectation: {SalaryExpectation} SEK";
        }
    }
}
