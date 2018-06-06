using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerlinClock.Classes.Renderers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class StringBerlinClockRendererTests
    {
        private const int LengthOfRendition = 32;

        [TestMethod]
        public void TestZeroTimeRendition()
        {
            var lightRepresentation = CreateLightRepresentation();
            var testedRenderer = new StringBerlinClockRenderer(lightRepresentation);
            var berlinClockData = new BerlinClockData()
            {
                FiveHoursLightsCount = 0,
                FiveMinutesLightsCount = 0,
                IsOneSecondLightActive = true,
                OneHourLightsCount = 0,
                OneMinuteLightsCount = 0
            };

            var result = testedRenderer.RenderBerlinClock(berlinClockData);
            Assert.AreEqual(LengthOfRendition, result.Length);
            Assert.AreEqual("y\r\nXXXX\r\nXXXX\r\nXXXXXXXXXXX\r\nXXXX", result); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidInput()
        {
            var testedRenderer = new StringBerlinClockRenderer();
            var berlinClockData = new BerlinClockData()
            {
                FiveHoursLightsCount = 10, //invalid
                FiveMinutesLightsCount = 0,
                IsOneSecondLightActive = true,
                OneHourLightsCount = 0,
                OneMinuteLightsCount = 0
            };

            testedRenderer.RenderBerlinClock(berlinClockData);
        }

        private LightRepresentations CreateLightRepresentation()
        {
            return new LightRepresentations()
            {
                Off = 'X',
                RedLight = 'r',
                YellowLight = 'y'
            };
        }
    }
}
