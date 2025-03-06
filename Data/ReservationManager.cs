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
        private static string BINPATH = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Resources\Res\reservations_data.bin");
        private static string TESTPATH = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Resources\Res\reservations_data.txt");
        private static string RESPATH = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\Resources\Res\test.txt");
        private const char sep = ';';
        public static List<Reservation> FindReservations()
        {
            List<Reservation> reservals = new List<Reservation>();
            string[] filecontent = File.ReadAllLines(RESPATH);
            int ind = 0;
            string[] fields = [];
            foreach (string line in filecontent)
            {
                fields = filecontent[ind].Split(sep);
                ind++;
                Reservation reservation = new Reservation(fields[0], fields[1], fields[2], Convert.ToDouble(fields[3]), fields[4], fields[5], fields[6]);
                reservals.Add(reservation);
            }
            return reservals;
        }
        public static void WriteToBinary()
        {
            using(BinaryWriter writer = new BinaryWriter(File.Open(BINPATH, FileMode.Create)))
            {
                foreach (Reservation res in ReservationManager.FindReservations()) 
                {
                    writer.Write(res.ToString());
                };
            }
            using (StreamWriter writer = new StreamWriter(File.Open(TESTPATH, FileMode.Create)))
            {
                foreach (Reservation res in ReservationManager.FindReservations())
                {
                    writer.Write($"{res.Rcode};{res.Fcode};{res.Aname};{res.Cost};{res.Cname};{res.Citizenship};{res.Status}\n");
                };
            }
        }
    }
}

