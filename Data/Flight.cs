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
        public decimal Price { get; set; }

        public Flight(string[] data)
        {
            FlightCode = data[0].Trim();
            Airline = data[1].Trim();
            From = data[2].Trim();
            To = data[3].Trim();
            Day = data[4].Trim();
            Time = data[5].Trim();
            AvailableSeats = int.TryParse(data[6].Trim(), out int seats) ? seats : 0;
            Price = decimal.TryParse(data[7].Trim(), out decimal price) ? price : 0.0m;
        }
    }
}
