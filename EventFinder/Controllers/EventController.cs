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
            /* Ask client for date of arrival */
            var valid = false;
            //do
            //{
            //    Console.WriteLine("When will you be visiting? (Enter using YYYY-MM-DD format)");

            //    if (int.Parse(startDate.Substring(0, 4)) < 2022)
            //    {
            //        Console.WriteLine("Invalid year! Must pick a future date");
            //        valid = true;
            //    }
            //    else if (int.Parse(startDate.Substring(5, 2)) < 1 || int.Parse(startDate.Substring(5, 2)) > 12)
            //    {
            //        Console.WriteLine("Invalid month! Must pick an existing month between 01-12");
            //        valid = true;
            //    }
            //    else if ((int.Parse(startDate.Substring(5, 2)) == 2) && (int.Parse(startDate.Substring(8, 2)) < 1 || int.Parse(startDate.Substring(8, 2)) > 28))
            //    {
            //        Console.WriteLine("Invalid day! Must choose between 01-28 for the month of February");
            //        valid = true;
            //    }
            //    else if ((int.Parse(startDate.Substring(5, 2)) == 4 || int.Parse(startDate.Substring(5, 2)) == 6 || int.Parse(startDate.Substring(5, 2)) == 9 || int.Parse(startDate.Substring(5, 2)) == 11) && (int.Parse(startDate.Substring(8, 2)) < 1 || int.Parse(startDate.Substring(8, 2)) > 30))
            //    {
            //        Console.WriteLine("Invalid day! Must choose day between 01-30 for this month");
            //        valid = true;

            //    }
            //    else if ((int.Parse(startDate.Substring(5, 2)) == 1 || int.Parse(startDate.Substring(5, 2)) == 3 || int.Parse(startDate.Substring(5, 2)) == 5 || int.Parse(startDate.Substring(5, 2)) == 7 || int.Parse(startDate.Substring(5, 2)) == 8 || int.Parse(startDate.Substring(5, 2)) == 10 || int.Parse(startDate.Substring(5, 2)) == 12) && (int.Parse(startDate.Substring(8, 2)) < 1 || int.Parse(startDate.Substring(8, 2)) > 31))
            //    {
            //        Console.WriteLine("Invalid day! Must choose day between 01-31 for this month");
            //        valid = true;
            //    }
            //    else if (startDate[4] != '-' || startDate[7] != '-')
            //    {
            //        Console.WriteLine("Invalid input! Must use '-' to separate year, month and date. Please check format!");
            //        valid = true;
            //    }
            //    else
            //    {
            //        valid = false;
            //    }
            //} while (valid == true);


            /* Ask client for date of departure */
            valid = false;
            //do
            //{

            //    if (int.Parse(endDate.Substring(0, 4)) < 2022)
            //    {
            //        Console.WriteLine("Invalid year! Must pick a future date");
            //        valid = true;
            //    }
            //    else if (int.Parse(endDate.Substring(5, 2)) < 1 || int.Parse(endDate.Substring(5, 2)) > 12)
            //    {
            //        Console.WriteLine("Invalid month! Must pick an existing month between 01-12");
            //        valid = true;
            //    }
            //    else if ((int.Parse(endDate.Substring(5, 2)) == 2) && (int.Parse(endDate.Substring(8, 2)) < 1 || int.Parse(endDate.Substring(8, 2)) > 28))
            //    {
            //        Console.WriteLine("Invalid day! Must choose between 01-28 for the month of February");
            //        valid = true;
            //    }
            //    else if ((int.Parse(endDate.Substring(5, 2)) == 4 || int.Parse(endDate.Substring(5, 2)) == 6 || int.Parse(endDate.Substring(5, 2)) == 9 || int.Parse(endDate.Substring(5, 2)) == 11) && (int.Parse(endDate.Substring(8, 2)) < 1 || int.Parse(endDate.Substring(8, 2)) > 30))
            //    {
            //        Console.WriteLine("Invalid day! Must choose day between 01-30 for this month");
            //        valid = true;

            //    }
            //    else if ((int.Parse(endDate.Substring(5, 2)) == 1 || int.Parse(endDate.Substring(5, 2)) == 3 || int.Parse(endDate.Substring(5, 2)) == 5 || int.Parse(endDate.Substring(5, 2)) == 7 || int.Parse(endDate.Substring(5, 2)) == 8 || int.Parse(endDate.Substring(5, 2)) == 10 || int.Parse(endDate.Substring(5, 2)) == 12) && (int.Parse(endDate.Substring(8, 2)) < 1 || int.Parse(endDate.Substring(8, 2)) > 31))
            //    {
            //        Console.WriteLine("Invalid day! Must choose day between 01-31 for this month");
            //        valid = true;
            //    }
            //    else if (endDate[4] != '-' || endDate[7] != '-')
            //    {
            //        Console.WriteLine("Invalid input! Must use '-' to separate year, month and date. Please check format!");
            //        valid = true;
            //    }
            //    else
            //    {
            //        valid = false;
            //    }
            //} while (valid == true);


            /* Ask client for time of arrival */
            string startHour;
            valid = false;
            //do
            //{              

            //    if (int.Parse(startTime.Substring(0, 2)) < 1 || int.Parse(startTime.Substring(0, 2)) > 12)
            //    {
            //        Console.WriteLine("Invalid hour! Please choose an hour between 01 and 12.");
            //        valid = true;
            //    }
            //    else if (int.Parse(startTime.Substring(3, 2)) < 0 || int.Parse(startTime.Substring(3, 2)) > 59)
            //    {
            //        Console.WriteLine("Invalid minute! Please choose a minute between 00 and 59.");
            //        valid = true;
            //    }
            //    else if (startTime[2] != ':')
            //    {
            //        Console.WriteLine("Invalid input! Please use ':' to separate hours and minutes.");
            //        valid = true;
            //    }
            //    else if (startTime.Length <= 5)
            //    {
            //        Console.WriteLine("Invalid input! Must indicate whether AM or PM");
            //        valid = true;
            //    }
            //    else if (!(startTime.Substring(5).ToLower().Equals("am") || startTime.Substring(5).ToLower().Equals("pm")))
            //    {
            //        Console.WriteLine($"Invalid input! Enter either 'AM' or 'PM' after time. You entered {startTime.Substring(5)}");
            //        valid = true;
            //    }
            //    else
            //    {
            //        valid = false;
            //    }
            //} while (valid == true);
            if (startTime.Substring(5, 2).ToUpper() == "PM")
            {
                startHour = (int.Parse(startTime.Substring(0, 2)) + 12).ToString();
            }
            else
            {
                startHour = startTime.Substring(0, 2);
            }
            var startMinutes = startTime.Substring(3, 2);
            startTime = $"{startHour}:{startMinutes}";


            /* Ask client for time of departure */
            string endHour;
            valid = false;
            //do
            //{

            //    if (int.Parse(endTime.Substring(0, 2)) < 1 || int.Parse(endTime.Substring(0, 2)) > 12)
            //    {
            //        Console.WriteLine("Invalid hour! Please choose an hour between 01 and 12.");
            //        valid = true;
            //    }
            //    else if (int.Parse(endTime.Substring(3, 2)) < 0 || int.Parse(endTime.Substring(3, 2)) > 59)
            //    {
            //        Console.WriteLine("Invalid minute! Please choose a minute between 00 and 59.");
            //        valid = true;
            //    }
            //    else if (endTime[2] != ':')
            //    {
            //        Console.WriteLine("Invalid input! Please use ':' to separate hours and minutes.");
            //        valid = true;
            //    }
            //    else if (endTime.Length <= 5)
            //    {
            //        Console.WriteLine("Invalid input! Must indicate whether AM or PM");
            //        valid = true;
            //    }
            //    else if (!(endTime.Substring(5).ToLower().Equals("am") || endTime.Substring(5).ToLower().Equals("pm")))
            //    {
            //        Console.WriteLine($"Invalid input! Enter either 'AM' or 'PM' after time. You entered {endTime.Substring(5)}");
            //        valid = true;
            //    }
            //    else
            //    {
            //        valid = false;
            //    }
            //} while (valid == true);
            if (endTime.Substring(5, 2).ToUpper() == "PM")
            {
                endHour = (int.Parse(endTime.Substring(0, 2)) + 12).ToString();
            }
            else
            {
                endHour = endTime.Substring(0, 2);
            }
            var endMinutes = endTime.Substring(3, 2);
            endTime = $"{endHour}:{endMinutes}";

            /* Grabs api Key */
            string apiKeys = System.IO.File.ReadAllText("appsettings.json");
            string apiKey = JObject.Parse(apiKeys).GetValue("Key").ToString();

            /* Get search results that match criteria */
            var client = new HttpClient();
            var startDateTime = $"{startDate}T{startTime}:00Z";
            var endDateTime = $"{endDate}T{endTime}:00Z";
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
