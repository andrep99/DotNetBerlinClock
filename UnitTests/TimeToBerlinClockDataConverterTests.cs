using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class TimeToBerlinClockDataConverterTests
    {

        [TestMethod]
        public void TestZeroTimeConversion()
        {
            var testedConverter = new TimeToBerlinClockDataConverter();
            var parsedTime = new ParsedTimeWithExtraMidnight()
            {
                Hours = 0,
                Minutes = 0,
                Seconds = 0
            };
            var result = testedConverter.ConvertParsedTimeToBerlinClockData(parsedTime);

            Assert.AreEqual(true, result.IsOneSecondLightActive);
            Assert.AreEqual(0, result.FiveHoursLightsCount);
            Assert.AreEqual(0, result.OneHourLightsCount);
            Assert.AreEqual(0, result.FiveMinutesLightsCount);
            Assert.AreEqual(0, result.OneMinuteLightsCount);
        }

        [TestMethod]
        public void TestMaxTimeConversion()
        {
            var testedConverter = new TimeToBerlinClockDataConverter();
            var parsedTime = new ParsedTimeWithExtraMidnight()
            {
                Hours = 24,
                Minutes = 0,
                Seconds = 0
            };
            var result = testedConverter.ConvertParsedTimeToBerlinClockData(parsedTime);

            Assert.AreEqual(true, result.IsOneSecondLightActive);
            Assert.AreEqual(4, result.FiveHoursLightsCount);
            Assert.AreEqual(4, result.OneHourLightsCount);
            Assert.AreEqual(0, result.FiveMinutesLightsCount);
            Assert.AreEqual(0, result.OneMinuteLightsCount);
        }

        [TestMethod]
        public void TestBeforeMidnightConversion()
        {
            var testedConverter = new TimeToBerlinClockDataConverter();
            var parsedTime = new ParsedTimeWithExtraMidnight()
            {
                Hours = 23,
                Minutes = 59,
                Seconds = 59
            };
            var result = testedConverter.ConvertParsedTimeToBerlinClockData(parsedTime);

            Assert.AreEqual(false, result.IsOneSecondLightActive);
            Assert.AreEqual(4, result.FiveHoursLightsCount);
            Assert.AreEqual(3, result.OneHourLightsCount);
            Assert.AreEqual(11, result.FiveMinutesLightsCount);
            Assert.AreEqual(4, result.OneMinuteLightsCount);
        }

        [TestMethod]
        public void TestAfterMidnightConversion()
        {
            var testedConverter = new TimeToBerlinClockDataConverter();
            var parsedTime = new ParsedTimeWithExtraMidnight()
            {
                Hours = 0,
                Minutes = 0,
                Seconds = 1
            };
            var result = testedConverter.ConvertParsedTimeToBerlinClockData(parsedTime);

            Assert.AreEqual(false, result.IsOneSecondLightActive);
            Assert.AreEqual(0, result.FiveHoursLightsCount);
            Assert.AreEqual(0, result.OneHourLightsCount);
            Assert.AreEqual(0, result.FiveMinutesLightsCount);
            Assert.AreEqual(0, result.OneMinuteLightsCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidTooManyHoursInput()
        {
            var testedConverter = new TimeToBerlinClockDataConverter();
            var parsedTime = new ParsedTimeWithExtraMidnight()
            {
                Hours = 100,
                Minutes = 0,
                Seconds = 0
            };
            testedConverter.ConvertParsedTimeToBerlinClockData(parsedTime);
        }

    }
}
