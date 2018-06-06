using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerlinClock.Classes.Renderers;
using BerlinClock.Classes.TimeParsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class FormatTimeWithExtraMidnightParserTests
    {
        [TestMethod]
        public void TestStandardTimeParsing()
        {
            var testedParser = new FormatTimeWithExtraMidnightParser();
            var testData = "23:59:59";
            var result = testedParser.Parse(testData);
            Assert.AreEqual(23, result.Hours);
            Assert.AreEqual(59, result.Minutes);
            Assert.AreEqual(59, result.Seconds);
        }

        [TestMethod]
        public void TestExtraMidnight()
        {
            var testedParser = new FormatTimeWithExtraMidnightParser();
            var testData = "24:00:00";
            var result = testedParser.Parse(testData);
            Assert.AreEqual(24, result.Hours);
            Assert.AreEqual(0, result.Minutes);
            Assert.AreEqual(0, result.Seconds);
        }

        [TestMethod]
        public void TestStandardMidnight()
        {
            var testedParser = new FormatTimeWithExtraMidnightParser();
            var testData = "00:00:00";
            var result = testedParser.Parse(testData);
            Assert.AreEqual(0, result.Hours);
            Assert.AreEqual(0, result.Minutes);
            Assert.AreEqual(0, result.Seconds);
        }


        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test240001TimeInput()
        {
            var testedParser = new FormatTimeWithExtraMidnightParser();
            var testData = "24:00:01";
            testedParser.Parse(testData);
        }
    }
}
