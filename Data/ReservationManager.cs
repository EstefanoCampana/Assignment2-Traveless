using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorHybridApp.Data
{
    internal class ReservationManager
    {
        private static string JSONPATH = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Resources\Res\reservations_data.json");
        private static List<Reservation> resList = ReservationManager.FindReservations();
        public static List<Reservation> FindReservations()
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
    }
}

