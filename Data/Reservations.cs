using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridApp.Data
{
    internal class Reservation
    {
        //Private data
        private string rcode = String.Empty;
        private string fcode = String.Empty;
        private string aname = String.Empty;
        private double cost;
        private string cname = String.Empty;
        private string citizenship = String.Empty;
        private bool status;

        //Public data
        public string Rcode { get { return rcode; } set { rcode = value; } }
        public string Fcode { get { return fcode; } set { fcode = value; } }
        public string Aname { get { return aname; } set { aname = value; } }
        public double Cost { get { return cost; } set { cost = value; } }
        public string Cname { get { return cname; } set { cname = value; } }
        public string Citizenship { get { return citizenship; } set { citizenship = value; } }
        public bool Status { get { return status; } set { status = value; } }

        public Reservation() { }
        public Reservation(string rc, string fc, string an, double c, string cn, string cz, string st)
        {
            Rcode = rc;
            Fcode = fc;
            Aname = an;
            Cost = c;
            Cname = cn;
            Citizenship = cz;
            if (st == "Active")
            {
                Status = true;
            }
            else if (st == "Inactive")
            {
                Status = false;
            }
        }
        public override string ToString()
        {
            return $"{Rcode}\n" +
            $"{Fcode}\n" +
            $"{Aname}\n" +
            $"{Cost}\n" +
            $"{Cname}\n" +
            $"{Citizenship}\n" +
            $"{Status}\n";
        }
    }
}
