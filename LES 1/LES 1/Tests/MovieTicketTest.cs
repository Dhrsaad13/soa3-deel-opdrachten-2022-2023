using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Deelopdrachten.Tests
{
    [TestFixture]
public class MovieTicketTest
{
        [Test]
        public void TestCalculatePrice_IncorrectPrice_Weekend_NonStudentOrder()
        {
            // Arrange
            var tickets = new List<Movieticket>()
        {
              new Movieticket(1, 1, false),
              new Movieticket(1, 2, false),
              new Movieticket(1, 3, true),
              new Movieticket(1, 4, true),
        };
            var order = new Order(1, false, tickets);

            // Act
            var price = order.calculatePrice(true);

            // Assert
            Assert.AreNotEqual(26.50m, price);
        }

        [Test]
    public void TestCalculatePrice_Weekend_NonStudentOrder()
    {
        // Arrange
        var tickets = new List<Movieticket>()
            {
                  new Movieticket(1, 1, false),
                  new Movieticket(1, 2, false),
                  new Movieticket(1, 3, true),
                  new Movieticket(1, 4, true),
            };
        var order = new Order(1, false, tickets);

        // Act
        var price = order.calculatePrice(true);

        // Assert
        Assert.AreEqual(26.10m, price);
    }

    [Test]
    public void TestCalculatePrice_Weekday_StudentOrder()
    {
        // Arrange
        var tickets = new List<Movieticket>()
            {
                 new Movieticket(1, 1, false),
                 new Movieticket(1, 2, false),
                 new Movieticket(1, 3, true),
                 new Movieticket(1, 4, true),
            };
        var order = new Order(1, true, tickets);

        // Act
        var price = order.calculatePrice(false);

        // Assert
        Assert.AreEqual(21.60m, price);
    }

    [Test]
    public void TestCalculatePrice_Weekday_NonStudentOrder()
    {
        // Arrange
        var tickets = new List<Movieticket>()
            {
                  new Movieticket(1, 1, false),
                  new Movieticket(1, 2, false),
                  new Movieticket(1, 3, true),
                  new Movieticket(1, 4, true),
            };
        var order = new Order(1, false, tickets);

        // Act
        var price = order.calculatePrice(false);

        // Assert
        Assert.AreEqual(48.60m, price);
    }

    [Test]
    public void TestCalculatePrice_Weekend_StudentOrder()
    {
        // Arrange
        var tickets = new List<Movieticket>()
            {
                  new Movieticket(1, 1, false),
                  new Movieticket(1, 2, false),
                  new Movieticket(1, 3, true),
                  new Movieticket(1, 4, true),
            };
        var order = new Order(1, true, tickets);

        // Act
        var price = order.calculatePrice(true);

        // Assert
        Assert.AreEqual(22.05m, price);
    }
}
}