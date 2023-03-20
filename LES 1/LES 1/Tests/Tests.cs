using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LES_1.Model;

namespace Deel-Opdrachten.Tests
{
    [TestFixture]
public class Tests
{
    [Test]
    public void TestCalculatePrice_Weekend_NonStudentOrder()
    {
        // Arrange
        var tickets = new List<Movieticket>()
            {
                new Movieticket(false, false),
                new Movieticket(false, false),
                new Movieticket(false, false),
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
                new Movieticket(true, false),
                new Movieticket(true, false),
                new Movieticket(true, false),
                new Movieticket(true, false),
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
                new Movieticket(false, false),
                new Movieticket(false, false),
                new Movieticket(false, true),
                new Movieticket(false, true),
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
                new Movieticket(true, true),
                new Movieticket(true, true),
                new Movieticket(true, false),
                new Movieticket(true, false),
                new Movieticket(true, false),
            };
        var order = new Order(1, true, tickets);

        // Act
        var price = order.calculatePrice(true);

        // Assert
        Assert.AreEqual(22.05m, price);
    }
}
}