using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridApp.Data
{
    internal class FlightManagement
    {
        private static string CSVPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Resources\Res\Flights.csv");
        private static List<Flight> flights;

        public static List<Flight> FlightsFound(string from, string to, string day)
        {
            flights = new List<Flight>();
            var lines = File.ReadAllLines(CSVPath, Encoding.UTF8);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue; 

                var flightData = line.Split(',');

                if (flightData.Length == 8)
                {
                    var flight = new Flight(flightData);

                    if ((string.IsNullOrWhiteSpace(from) || flight.From.Equals(from, StringComparison.OrdinalIgnoreCase)) &&
                        (string.IsNullOrWhiteSpace(to) || flight.To.Equals(to, StringComparison.OrdinalIgnoreCase)) &&
                        (string.IsNullOrWhiteSpace(day) || flight.Day.Equals(day, StringComparison.OrdinalIgnoreCase)))
                    {
                        flights.Add(flight);
                    }
                }
            }
            return flights; 
        }

        public static bool IsFullyBook(string flightCode)
        {
            int seat = 0;
            int seatCount = 0;

            foreach (Flight f in flights)
            {
                if (flightCode == f.FlightCode)
                {
                    seat = f.AvailableSeats;
                }
            }

            List<Reservation> resList = ReservationManager.PopulatedReservations();

            foreach (Reservation res in resList)
            {
                if (flightCode == res.Fcode)
                {
                    seatCount++;
                }
            }

            if (seatCount < seat)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
