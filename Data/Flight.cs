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
        public double Cost { get; set; }

        public Flight() { }
        public Flight(string fc, string air, string fr, string to, string day, string time, int avail, double cost)
        {
            FlightCode = fc;
            Airline = air;
            From = fr;
            To = to;
            Day = day;
            Time = time;
            AvailableSeats = avail;
            Cost = cost;
        }
        public override string ToString()
        {
            return $"{FlightCode}, {Airline}, {From}, {To}, {Day}, {Time}, {Cost}";
        }
    }
}
