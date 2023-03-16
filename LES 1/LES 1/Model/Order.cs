using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;

namespace LES_1.Model
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
        public decimal calculatePrice(Boolean isStudent, Boolean isWeekend, Boolean isPremium)
        {
            int numTickets = Tickets.Count;
            decimal standardPrice = 10.00m;
            decimal premiumPrice = standardPrice + (isStudent ? 2.00m : 3.00m);
            int numFreeTickets = (isWeekend && !isStudent) ? 0 : (numTickets / 2);
            int numPaidTickets = numTickets - numFreeTickets;
            decimal totalPrice;

            if (isStudent || !isWeekend)
            {
                if (isPremium)
                {
                    totalPrice = 0.0m;
                    int numPremiumTickets = 0;
                    int numStandardTickets = 0;

                    foreach (Movieticket ticket in Tickets)
                    {
                        if (ticket.isPremiumTicket())
                        {
                            totalPrice += premiumPrice;
                            numPremiumTickets++;
                        }
                        else
                        {
                            totalPrice += standardPrice;
                            numStandardTickets++;
                        }
                    }

                    int numFreePremiumTickets = (numPremiumTickets + numStandardTickets) / 2 - numPremiumTickets;
                    int numFreeStandardTickets = numFreeTickets - numFreePremiumTickets;

                    totalPrice -= (numFreePremiumTickets * premiumPrice) + (numFreeStandardTickets * standardPrice);
                }
                else
                {
                    totalPrice = (numPaidTickets * standardPrice) + (numFreeTickets * standardPrice);
                }
            }
            else
            {
                decimal groupDiscount = (numTickets >= 6) ? 0.10m : 0.00m;
                decimal discountedPrice = standardPrice * (1 - groupDiscount);
                if (isPremium)
                {
                    totalPrice = (numPaidTickets * premiumPrice) + (numFreeTickets * discountedPrice);
                }
                else
                {
                    totalPrice = (numPaidTickets * discountedPrice) + (numFreeTickets * discountedPrice);
                }
            }

            return totalPrice;
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
    

