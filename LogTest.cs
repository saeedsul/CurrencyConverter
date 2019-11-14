using System;
using System.Collections.Generic;
using CurrencyConverter.Domain;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CurrencyConverter.Test
{
    public class LogTest
    {

        [Test]
        public void GetLog_Should_Return_Correct_Count()
        {
            //Arrange 

            var sut = new Logs();

            var entryDate = new DateTime(2020, 01, 01);

            //Act

            sut.Add(new KeyValuePair<DateTime, decimal>(entryDate, 1.1m));

            var result = sut.Get(entryDate);

            //Assert

            Assert.AreEqual(1, result?.Count);
        }

        [Test]
        public void GetLog_Should_Return_Correct_ResultSet()
        {
            //Arrange 

            var entryDate = new DateTime(2020, 01, 01);

            var sut = new Logs();

            var expected = new List<KeyValuePair<DateTime, decimal>>();

            expected.Add(new KeyValuePair<DateTime, decimal>(entryDate, 1.1m));
            expected.Add(new KeyValuePair<DateTime, decimal>(entryDate, 2.1m));
            expected.Add(new KeyValuePair<DateTime, decimal>(entryDate, 3.1m));

            //Act

            sut.Add(new KeyValuePair<DateTime, decimal>(entryDate, 1.1m));
            sut.Add(new KeyValuePair<DateTime, decimal>(entryDate, 2.1m));
            sut.Add(new KeyValuePair<DateTime, decimal>(entryDate, 3.1m));

            var result = sut.Get(entryDate);

            //Assert

            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetLog_Should_Return_Correct_Filtered_ResultSet()
        {
            //Arrange 

            var entryDate = new DateTime(2020, 01, 01);

            var sut = new Logs();
            
            //Act

            sut.Add(new KeyValuePair<DateTime, decimal>(entryDate, 1.1m));
            sut.Add(new KeyValuePair<DateTime, decimal>(entryDate, 2.1m));
            sut.Add(new KeyValuePair<DateTime, decimal>(DateTime.Now, 3.1m));

            var result = sut.Get(entryDate);

            //Assert

            Assert.AreEqual(2,result.Count);
        }

        [Test]
        public void GetLog_Should_Return_Exception()
        {
            //Arrange 

            var sut = new Logs();

            //Act
            var result = Assert.Catch(() => sut.Get(DateTime.MinValue));

            // Assert
            result.Should().BeOfType<ArgumentNullException>();
        }
    }
}