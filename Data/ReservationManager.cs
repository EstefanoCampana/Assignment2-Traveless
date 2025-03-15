using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using Android.App;

namespace BlazorHybridApp.Data
{
    internal class ReservationManager
    {
        private static string JSONPATH = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Resources\Res\reservations_data.json");
        public static List<Reservation> resList = ReservationManager.PopulatedReservations();

        // Populated with any reservations that are found
        public static List<Reservation> PopulatedReservations()
        {
            List<Reservation> reservals = new List<Reservation>();
            var content = File.ReadAllText(JSONPATH);
            var filecontent = JsonSerializer.Deserialize<List<Reservation>>(content);
            reservals.Clear();
            reservals.AddRange(filecontent);
            return reservals;
        }
        public static void WriteToJson()
        {
            string content = JsonSerializer.Serialize(resList);
            File.WriteAllText(JSONPATH, content);
        }

        // The findReservation method returns a list of matching Reservation objects
        public static List<Reservation> FindReservation(string rcode, string aname, string cname)
        {
            List<Reservation> matchingReservation = new List<Reservation>();
            int ind = 0;

            // If the user doesn't enter any input
            if (String.IsNullOrWhiteSpace(rcode) &&
                    String.IsNullOrWhiteSpace(aname) &&
                    String.IsNullOrWhiteSpace(cname))
            {
                // all the reservations are displayed in the list
                matchingReservation = resList;
            }
            else
            {
                foreach (Reservation res in resList)
                {
                    // If the inputed value(s) is/are matched
                    if ((String.IsNullOrWhiteSpace(rcode) || (res.Rcode == rcode)) &&
                        (String.IsNullOrWhiteSpace(aname) || (res.Aname == aname)) &&
                        (String.IsNullOrWhiteSpace(cname) || (res.Cname == cname)))
                    {
                        // the matched Reservation objects will be added to the list
                        matchingReservation.Add(res);
                    }
                    ind++;

                    // If there is no matched result, the list will be empty. 

                }
            }
            // return the matched Reservation objects
            return matchingReservation;
        }

        public static string GenerateRandomRCode()
        {
            Random rand = new Random();
            char letter = (char)rand.Next('A', 'Z' + 1); // Generate a random uppercase letter
            int number = rand.Next(1000, 10000); // Generate a four-digit number
            return $"{letter}{number}";
        }

        //Create a Reservation using flight object
        public static string MakeReservation(Flight flight, string name = "", string citizenship = "")
        {
            bool isFullyBooked = FlightManagement.IsFullyBook(flight.FlightCode);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(citizenship))
            {
                throw new MakeReservationException(name, citizenship);
            }
            else if (!isFullyBooked)
            {
                throw new MakeReservationException(isFullyBooked);
            }
            else
            {
                string reservationCode = GenerateRandomRCode();
                Reservation newReservation = new Reservation(reservationCode, flight.FlightCode, flight.Airline, (double)flight.Cost, name, citizenship, "Active");
                resList.Add(newReservation);
                WriteToJson();
                return reservationCode;
            }
        }

    }
}

