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
        public Movieticket(int rowNr, int seatNr, bool isPremium = false)
        {
            this.rowNr = rowNr;
            this.seatNr = seatNr;
            this.isPremium = isPremium;
        }

        private int rowNr { get; set; }
        private int seatNr { get; set; }
        private bool isPremium { get; set; }

        public bool isPremiumTicket()
        {
            return isPremium;
        }

        public override string ToString()
        {
            return "true";
        }
    }
}