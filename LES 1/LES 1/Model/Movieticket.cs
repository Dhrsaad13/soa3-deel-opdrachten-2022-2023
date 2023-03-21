using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Deelopdrachten
{
    class Movieticket
    {
        public Movieticket(int rowNr, int seatNr, bool isPremium)
        {
            this.rowNr = rowNr;
            this.seatNr = seatNr;
            this.isPremium = isPremium;
        }
        private int rowNr { get; set; }
        private int seatNr { get; set; }
        private Boolean isPremium { get; set; }
        public Boolean isPremiumTicket()
        {
            if (isPremium)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public String toString() { return "true"; }
    }
}


      