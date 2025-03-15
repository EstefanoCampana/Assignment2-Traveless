using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorHybridApp.Data
{
    internal class FlightManagement
    {
        private static string CSVPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Resources\Res\Flights.csv");
        public static List<Flight> PopulatedFlights()
        {
            List<Flight> flights = new List<Flight>();
            var lines = File.ReadAllLines(CSVPath, Encoding.UTF8);
            foreach (var line in lines)
            {
                 if (string.IsNullOrWhiteSpace(line)) continue;
                 string[] flightData = line.Split(',');
                 Flight flight = new Flight(flightData[0], flightData[1], flightData[2], flightData[3], flightData[4], flightData[5], Convert.ToInt32(flightData[6]), Convert.ToDouble(flightData[7]));
                 flights.Add(flight);
            }
            return flights;
        }
        public static List<Flight> FlightsFound(string from, string to, string day)
        {
            List<Flight> flights = new List<Flight>();
            var lines = File.ReadAllLines(CSVPath, Encoding.UTF8);
            foreach (Flight flight in FlightManagement.PopulatedFlights())
            {
                if ((string.IsNullOrWhiteSpace(from) || flight.From.Equals(from, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrWhiteSpace(to) || flight.To.Equals(to, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrWhiteSpace(day) || flight.Day.Equals(day, StringComparison.OrdinalIgnoreCase)))
                {
                    flights.Add(flight);
                }
            }
            return flights;
        }
    }
}
