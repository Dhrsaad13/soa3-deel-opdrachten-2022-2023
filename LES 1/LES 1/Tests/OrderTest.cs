using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deelopdrachten.Tests
{
    class OrderTest
{
        [TestClass()]
        public class OrderTests
        {
            [TestMethod()]
            public void CalculatePriceTest() // Testmethode om de berekening van de prijs te testen
            {
                // Aanmaken van tickets
                Movieticket ticket1 = new Movieticket(1, 1, false);
                Movieticket ticket2 = new Movieticket(1, 2, false);
                Movieticket ticket3 = new Movieticket(1, 3, true);

                // Maak een nieuwe Order aan met de gemaakte tickets
                Order order = new Order(1, true, new System.Collections.Generic.List<Movieticket> { ticket1, ticket2, ticket3 });

                decimal price = order.calculatePrice(false); // Roep de methode calculatePrice aan voor de gemaakte order

                Assert.AreEqual(30.60m, price); // Verwacht dat de prijs 30.60 is (2 normale tickets en 1 premium ticket, geen student, geen weekend)
            }

            [TestMethod()]
            public void ExportTest() // Testmethode om het exporteren van tickets te testen
            {
                // Aanmaken van tickets
                Movieticket ticket1 = new Movieticket(1, 1, false);
                Movieticket ticket2 = new Movieticket(1, 2, false);

                // Maak een nieuwe Order aan met de gemaakte tickets
                Order order = new Order(1, true, new System.Collections.Generic.List<Movieticket> { ticket1, ticket2 });

                // Exporteer de tickets naar een plaintext-bestand ("test.txt")
                order.Export(TicketExportFormat.PLAINTEXT, "test.txt");

                // Verwacht dat er een bestand "test.txt" is aangemaakt
                Assert.IsTrue(System.IO.File.Exists("test.txt"));
            }

            [TestMethod()]
            public void IsPremiumTicketTest() // Testmethode om te controleren of een Movieticket premium is
            {
                // Aanmaken van tickets
                Movieticket ticket1 = new Movieticket(1, 1, false);
                Movieticket ticket2 = new Movieticket(1, 2, true);

                // Act
                // Roep de methode isPremiumTicket aan voor ticket1
                bool isPremium1 = ticket1.isPremiumTicket();
                // Roep de methode isPremiumTicket aan voor ticket2
                bool isPremium2 = ticket2.isPremiumTicket();

                Assert.IsFalse(isPremium1); // Verwacht dat isPremium1 false is (niet premium)
                Assert.IsTrue(isPremium2); // Verwacht dat isPremium2 true is (premium)
            }
        }
    }
}
