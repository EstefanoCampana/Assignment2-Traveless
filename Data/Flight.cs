using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridApp.Data
{
    public class Flight
    {
        public string FlightCode { get; set; }
        public string Airline { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int AvailableSeats { get; set; }
        public decimal Cost { get; set; }

        public Flight(string[] flightData)
        {
            FlightCode = flightData[0].Trim();
            Airline = flightData[1].Trim();
            From = flightData[2].Trim();
            To = flightData[3].Trim();
            Day = flightData[4].Trim();
            Time = flightData[5].Trim();
            AvailableSeats = int.TryParse(flightData[6].Trim(), out int seats) ? seats : 0;
            Cost = decimal.TryParse(flightData[7].Trim(), out var cost) ? cost : 0;
        }
        public override string ToString()
        {
            return $"{FlightCode}, {Airline}, {From}, {To}, {Day}, {Time}, {Cost}";
        }
    }
}
