using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES_1
{
    class Movieticket
    {
        public Movieticket(int rowNr, int seatNr, bool isPremiun)
        {
            this.rowNr = rowNr;
            this.seatNr = seatNr;
            this.isPremiun = isPremiun;
        }

        private int rowNr { get; set; }
        private int seatNr { get; set; }
        private Boolean isPremiun { get; set; }
       public Boolean isPremiumTicket() {
            return false;
        }
        public String toString() { return "true"; }
    }
}
