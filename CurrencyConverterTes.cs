using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using CurrencyConverter.Domain;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CurrencyConverter.Test
{
    [TestFixture]
    public class CurrencyConverterTes
    {
        private IFixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture().Customize(customization: new AutoMoqCustomization()); 
        }

        [TearDown]
        public void Teardown()
        {
            _fixture = null;
        }

        [Test]
        public void PoundToDollar_Should_Return_Correct_Amount()
        {
            //Arrange 
            const double toConvert = 1.2;

            var expected = Convert.ToDecimal(toConvert *  Constants.DollarRate);
            
            var mockedLogger = new Mock<ILogs>();

            mockedLogger.Setup(x =>
                x.Add(It.IsAny<KeyValuePair<DateTime, decimal>>())).Verifiable();

            //Act
            var sut = new Currency(mockedLogger.Object);

            var result = sut.PoundToDollar(toConvert);

            mockedLogger.Verify();

            //Assert
            
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void PoundToDollar_Should_Return_Exception()
        {
            //Arrange 
            var currency = _fixture.Create<Currency>();

            //Act
            var result = Assert.Catch(() => currency.PoundToDollar(-1));
            // Assert
            result.Should().BeOfType<ArgumentOutOfRangeException>();
        }

        [Test]
        public void PoundToAud_Should_Return_Correct_Amount()
        {
            //Arrange 
            const double toConvert = 1.2;

            var expected = Convert.ToDecimal(toConvert * Constants.AudRate);
            
            var mockedLogger = new Mock<ILogs>();

            mockedLogger.Setup(x =>
                x.Add(It.IsAny<KeyValuePair<DateTime, decimal>>())).Verifiable();

            //Act
            var sut = new Currency(mockedLogger.Object);

            var result = sut.PoundToAud(toConvert);

            mockedLogger.Verify();

            //Assert

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void PoundToAud_Should_Return_Exception()
        {
            //Arrange 
            var currency = _fixture.Create<Currency>();

            //Act
            var result = Assert.Catch(() => currency.PoundToAud(-1));
            // Assert
            result.Should().BeOfType<ArgumentOutOfRangeException>();
        }

        [Test]
        public void PoundToEuro_Should_Return_Correct_Amount()
        {
            //Arrange 
            const double toConvert = 1.2;

            var expected = Convert.ToDecimal(toConvert * Constants.EurRate);

            var mockedLogger = new Mock<ILogs>();

            mockedLogger.Setup(x =>
                x.Add(It.IsAny<KeyValuePair<DateTime, decimal>>())).Verifiable();
            
            //Act
            var sut = new Currency(mockedLogger.Object);

            var result = sut.PoundToEuro(toConvert);

            mockedLogger.Verify();

            //Assert

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void PoundToEuro_Should_Return_Exception()
        {
            //Arrange 
            var currency = _fixture.Create<Currency>();

            //Act
            var result = Assert.Catch(() => currency.PoundToEuro(-1));
            // Assert
            result.Should().BeOfType<ArgumentOutOfRangeException>();
        }
    }
}
