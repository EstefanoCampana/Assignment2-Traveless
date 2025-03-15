using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridApp.Data
{
    class MakeReservationException : Exception
    {
        public MakeReservationException(string name, string citizenship) : base("Name AND/OR Citizenship cannot be null") { }
        public MakeReservationException(bool isFullyBooked) : base("Sorry, the flight is fully booked.\nPlease make another flight reservation.") { }
    }
}
