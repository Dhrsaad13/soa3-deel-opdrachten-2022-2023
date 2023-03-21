using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;

namespace Deelopdrachten
{
    class Order
    {
        public Order(int orderNr, bool isStudentOrder, List<Movieticket> tickets)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
            this.Tickets = tickets;

        }

        private int orderNr { get; set; }
        public List<Movieticket> Tickets { get; set; }

        private Boolean isStudentOrder { get; set; }
        public void addSeatReservation(Movieticket movieticket)
        {

        }
        public decimal calculatePrice(Boolean IsWeekend)
        {
            int NormalTicketPrice = 10;
            decimal Totalprice = 0;
            int PremiumTicketPrice;
            int paidTicketCount = 0;
            int Ticketcount;

            if (this.isStudentOrder)
            {
                PremiumTicketPrice = 12;
            }
            else
            {
                PremiumTicketPrice = 13;
            }

            // Check if there are free tickets
            if (this.isStudentOrder)
            {
                int ticketCount = Tickets.Count;
                int freeTicketCount = (ticketCount + 1) / 2; // Divide by 2 and round up
                 paidTicketCount = ticketCount - freeTicketCount;
            }

            if (!this.isStudentOrder || !IsWeekend)
            {
                int ticketCount = Tickets.Count;
                int freeTicketCount = (ticketCount + 1) / 2; // Divide by 2 and round up
                 paidTicketCount = ticketCount - freeTicketCount;
            }

            // Loop through the number of tickets and check if they are premium or not
            for (int i = 0; i < paidTicketCount; i++)
            {
                if (Tickets[i].isPremiumTicket())
                {
                    Totalprice += PremiumTicketPrice;
                }
                else
                {
                    Totalprice += NormalTicketPrice;
                }
            }

            // Check if non-students are buying tickets on the weekend and give a 10% discount if true
            if (IsWeekend || !this.isStudentOrder)
            {
                Totalprice = Totalprice * 0.9m;
            }

            return Totalprice;
        }

        public void Export(TicketExportFormat format, String fileName)
        {
            string output = "";
            foreach (Movieticket ticket in Tickets)
            {
                output += ticket.ToString();
            }
            switch (format)
            {
                case TicketExportFormat.PLAINTEXT:
                    File.WriteAllText(fileName, output);
                    break;
                case TicketExportFormat.JSON:
                    string jsonOutput = JsonConvert.SerializeObject(output);
                    File.WriteAllText(fileName, jsonOutput);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }
    }
}
    

