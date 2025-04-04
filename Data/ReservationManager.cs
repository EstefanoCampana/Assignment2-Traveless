﻿using System;
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
    public class ReservationManager
    {
        private static string JSONPATH = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Resources\Res\reservations_data.json");
        public static List<Reservation> resList = new List<Reservation>();

        // Populated with any reservations that are found
        public static void PopulatedReservations()
        {
            var content = File.ReadAllText(JSONPATH);
            var filecontent = JsonSerializer.Deserialize<List<Reservation>>(content);
            resList.AddRange(filecontent);
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
    
        //Create a Reservation using flight object
        public static void MakeReservation(Flight flight, string name, string citizenship)
        {
            Random rand = new Random();
            char letter = (char)rand.Next('A', 'Z' + 1); // Generate a random uppercase letter
            int number = rand.Next(100, 1000); // Generate a three-digit number
            string reservationCode = $"{letter}{number}";
            Reservation newReservation = new Reservation(reservationCode, flight.FlightCode, flight.Airline, flight.Cost, name, citizenship, "Active");
            resList.Add(newReservation);
        }

    }
}

