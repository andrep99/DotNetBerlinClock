using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using BerlinClock.Classes;
using BerlinClock.Classes.Renderers;
using BerlinClock.Classes.TimeParsers;

namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ITimeWithExtraMidnightParser<string> _timeWithExtraMidnightParser;
        private readonly ITimeToBerlinClockDataConverter _timeToBerlinClockDataConverter;
        private readonly IBerlinClockRenderer<string> _berlinClockRenderer;

        public TimeConverter(ITimeWithExtraMidnightParser<string> timeWithExtraMidnightParser, 
                             ITimeToBerlinClockDataConverter timeToBerlinClockDataConverter, 
                             IBerlinClockRenderer<string> berlinClockRenderer)
        {
            _timeWithExtraMidnightParser = timeWithExtraMidnightParser;
            _timeToBerlinClockDataConverter = timeToBerlinClockDataConverter;
            _berlinClockRenderer = berlinClockRenderer;
        }

        public string ConvertTime(string time) 
        {
            var parsedTime = _timeWithExtraMidnightParser.Parse(time);
            var berlinClockData = _timeToBerlinClockDataConverter.ConvertParsedTimeToBerlinClockData(parsedTime);
            var berlinClockStringRendition = _berlinClockRenderer.RenderBerlinClock(berlinClockData);
            return berlinClockStringRendition;
        }

    }
}
