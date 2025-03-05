using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridApp.Data
{
    internal class ReservationManager
    {
        private static string PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Resources\Res\test.txt");
        private const char sep = ';';
        public static List<Reservation> FindReservations()
        {
            StreamReader reader = new StreamReader(PATH);
            string line;
            string[] fields;
            List<Reservation> reservals = new List<Reservation>();
            while(!reader.EndOfStream)
            {
                line = reader.ReadLine();
                fields = line.Split(sep);
                Reservation reservation = new Reservation(fields[0], fields[1], fields[2], Convert.ToDouble(fields[3]), fields[4], fields[5], Convert.ToBoolean(fields[6]));
                reservals.Add(reservation);
            }
            return reservals;
        }
    }
}

