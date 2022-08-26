using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EventFinder.Controllers
{
    public class EventController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult PrintSearchResults(string startDate, string endDate, string city, string startTime, string endTime, string eventType, string genre)
        {                        
            bool isValid = true;
                        
            /* Check for valid for time of arrival */
            string startHour;                        
            startHour = startTime.Substring(0, 2);
            bool isStartHour = int.TryParse(startHour, out int startHourInt);
            //if (startTime.Substring(5, 2).ToUpper() != "PM" && startTime.Substring(5, 2).ToUpper() == "AM")
            //{
            //    isValid = false;
            //}
            if (startTime.Substring(5, 2).ToUpper() == "PM")
            {
                startHour = (startHourInt + 12).ToString();
            }
            if (!isStartHour || startHourInt < 0 || startHourInt > 24)
            {
                isValid = false;
            }
            var startMinutes = startTime.Substring(3, 2);
            bool isStartMinutes = int.TryParse(startMinutes, out int startMinuteInt);
            if (!isStartMinutes || startMinuteInt < 0 || startMinuteInt > 59)
            {
                isValid = false;
            }
            startTime = $"{startHour}:{startMinutes}";
            

            /* Check for valid time of departure */
            string endHour;                        
            endHour = endTime.Substring(0, 2);
            bool isEndHour = int.TryParse(endHour, out int endHourInt);
            //if (endTime.Substring(5, 2).ToUpper() != "PM" && endTime.Substring(5, 2).ToUpper() == "AM")
            //{
            //    isValid = false;
            //}
            if (endTime.Substring(5, 2).ToUpper() == "PM")
            {
                endHour = (endHourInt + 12).ToString();
            }           
            if (!isEndHour || endHourInt < 0 || endHourInt > 24)
            {
                isValid = false;
            }
            var endMinutes = endTime.Substring(3, 2);
            bool isEndMinutes = int.TryParse(endMinutes, out int endMinuteInt);
            if (!isEndMinutes || endMinuteInt < 0 || endMinuteInt > 59)
            {
                isValid = false;
            }            
            endTime = $"{endHour}:{endMinutes}";


            /* Check if valid start date */
            string startYear;
            startYear = startDate.Substring(0, 4);
            bool isStartYear = int.TryParse(startYear, out int startYearInt);
            if (!isStartYear || startYearInt < 2022)
            {
                isValid = false;
            }

            string startMonth;
            startMonth = startDate.Substring(5, 2);
            bool isStartMonth = int.TryParse(startMonth, out int startMonthInt);
            if(!isStartMonth || startMonthInt < 0 || startMonthInt > 12)
            {
                isValid = false;
            }

            string startDay;
            startDay = startDate.Substring(8, 2);
            bool isStartDay = int.TryParse(startDay, out int startDayInt);
            if (!isStartDay || startDayInt < 0 || startDayInt > 31)
            {
                isValid = false;
            }


            /* Check if valid end date */
            string endYear;
            endYear = endDate.Substring(0, 4);
            bool isEndYear = int.TryParse(endYear, out int endYearInt);
            if (!isEndYear || endYearInt < 2022)
            {
                isValid = false;
            }

            string endMonth;
            endMonth = endDate.Substring(5, 2);
            bool isEndMonth = int.TryParse(endMonth, out int endMonthInt);
            if (!isEndMonth || endMonthInt < 0 || endMonthInt > 12)
            {
                isValid = false;
            }

            string endDay;
            endDay = endDate.Substring(8, 2);
            bool isEndDay = int.TryParse(endDay, out int endDayInt);
            if (!isEndDay || endDayInt < 0 || endDayInt > 31)
            {
                isValid = false;
            }


            /* Check if correct symbols in date and time */
            var startDateDash1 = startDate[4];
            var startDateDash2 = startDate[7];
            var endDateDash1 = endDate[4];
            var endDateDash2 = endDate[7];
            if (startDateDash1 != '-' || startDateDash2 != '-' || endDateDash1 != '-' || endDateDash2 != '-')
            {
                isValid = false;
            }
            var startTimeColon = startTime[2];
            var endTimeColon = endTime[2];
            if (startTimeColon != ':' || endTimeColon != ':')
            {
                isValid = false;
            }

            /* Grab api Key */
            string apiKeys = System.IO.File.ReadAllText("appsettings.json");
            string apiKey = JObject.Parse(apiKeys).GetValue("Key").ToString();


            /* Convert user inputs to proper format to pass into url */
            var client = new HttpClient();
            var startDateTime = $"{startDate}T{startTime}:00Z";
            var endDateTime = $"{endDate}T{endTime}:00Z";


            /* Check for valid user input. If invalid, set deafult input*/
            if (isValid == false)
            {
                startDateTime = "2022-08-26T00:00:00Z";
                endDateTime = "2022-08-27T00:00:00Z";
                genre = "L";
            }

            /* Get search results that match criteria */
            var eventURL = $"https://app.ticketmaster.com/discovery/v2/events.json?city={city}&startDateTime={startDateTime}&endDateTime={endDateTime}&apikey={apiKey}";
            var response = client.GetStringAsync(eventURL).Result;
            var jsonResponse = JObject.Parse(response);
            var eventCount = 0;
            try
            {
                eventCount = jsonResponse["_embedded"]["events"].Count();
            }
            catch
            {
                eventCount = 0;
            }

            var infoList = new List<Info>();
            for (int i = 0; i < eventCount; i++)
            {
                string genreName;
                try
                {
                    genreName = jsonResponse["_embedded"]["events"][i]["classifications"][0]["genre"]["name"].ToString().ToLower();
                }
                catch
                {
                    genreName = "N/A";
                }
                string eventDate;
                try
                {
                    eventDate = jsonResponse["_embedded"]["events"][i]["dates"]["start"]["localDate"].ToString();
                }
                catch
                {
                    eventDate = "N/A";
                }
                string eventName;
                try
                {
                    eventName = jsonResponse["_embedded"]["events"][i]["name"].ToString();
                }
                catch
                {
                    eventName = "N/A";
                }
                string eventTime;
                try
                {
                    eventTime = Convert.ToString(jsonResponse["_embedded"]["events"][i]["dates"]["start"]["localTime"]);
                }
                catch
                {
                    eventTime = "N/A";
                }
                if (genre == genreName)
                {
                    var info = new Info()
                    {
                        GenreName = genreName,
                        EventDate = eventDate,
                        EventName = eventName,
                        EventTime = eventTime
                    };
                    infoList.Add(info);
                }

            }
            return View(infoList);
        }
    }
}
