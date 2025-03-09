using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridApp.Data
{
    public class FlightManagement
    {
        public List<string> FlightsFound { get; private set;} = new List<string>();
        public async Task SearchFlights(string from, string to, string day)
        {
            FlightsFound.Clear();

            var lines = await File.ReadAllLinesAsync("Res/flights.csv");

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
                        FlightsFound.Add($"{flight.FlightCode}, {flight.Airline}, {flight.From} to {flight.To}, {flight.Day}, {flight.Time}, {flight.Price}");
                    }
                }
            }
        }
    }
}
