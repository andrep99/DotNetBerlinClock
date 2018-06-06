using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BerlinClock.Classes;
using BerlinClock.Classes.Renderers;
using BerlinClock.Classes.TimeParsers;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly ITimeConverter _berlinClock = new TimeConverter(new FormatTimeWithExtraMidnightParser(), 
                                                                        new TimeToBerlinClockDataConverter(), 
                                                                        new StringBerlinClockRenderer());
        private string _theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            _theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(_berlinClock.ConvertTime(_theTime), theExpectedBerlinClockOutput);
        }

    }
}
