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

        public static List<Reservation> SearchReservation(string rcode, string aname, string cname)
        {
            List<Reservation> find = new List<Reservation>();
            int ind = 0;
            foreach (Reservation res in resList)
            {
                if (String.IsNullOrWhiteSpace(rcode) &&
                    String.IsNullOrWhiteSpace(aname) &&
                    String.IsNullOrWhiteSpace(cname))
                {
                    find = resList;
                }
                else if ((String.IsNullOrWhiteSpace(rcode) || (res.Rcode == rcode)) &&
                    (String.IsNullOrWhiteSpace(aname) || (res.Aname == aname)) &&
                    (String.IsNullOrWhiteSpace(cname) || (res.Cname == cname)))
                {
                    find.Add(res);
                }
                ind++;

            }
            return find;
        }
    }
}

