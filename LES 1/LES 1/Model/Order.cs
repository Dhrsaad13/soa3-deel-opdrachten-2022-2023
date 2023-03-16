using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES_1.Model
{
    class Order
    {
        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
        }

        private int orderNr { get; set; }
        private Boolean isStudentOrder { get; set; }
        public void addSeatReservation(Movieticket movieticket)
        {

        }
        public double calculatePrice()
        {
            return 0.0;
        }
        public void export(TicketExportFormat exportFormat)
        {

        }
    }
}
