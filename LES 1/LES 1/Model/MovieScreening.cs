using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deelopdrachten
{
    class MovieScreening
    {
        public MovieScreening(DateTime dateandtime, double pricePerSeat)
        {
            this.dateandtime = dateandtime;
            this.pricePerSeat = pricePerSeat;
        }

        private DateTime dateandtime { get; set; }
        private double pricePerSeat {get; set;}
        public double getPricePerSeat()
        {
            return 0.0;
        }
        public String toString()
        {
            return "";
        }
    }
}
