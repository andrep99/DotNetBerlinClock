using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.TimeParsers
{
    class FormatTimeWithExtraMidnightParser: ITimeWithExtraMidnightParser<string>
    {
        private const string MidnightExtraRepresentationDefault = "24:00:00";
        private const string TimeFormatDefault = "HH:mm:ss";

        private readonly string _timeFormat;
        private readonly string _midnightExtraRepresentation;

        public FormatTimeWithExtraMidnightParser()
        {
            _timeFormat = TimeFormatDefault;
            _midnightExtraRepresentation = MidnightExtraRepresentationDefault;
        }

        public FormatTimeWithExtraMidnightParser(string timeFormat, string midnightExtraRepresentation)
        {
            _timeFormat = timeFormat;
            _midnightExtraRepresentation = midnightExtraRepresentation;
        }

        public ParsedTimeWithExtraMidnight Parse(string aTime)
        {
            //todo: do the parsing with proper erros (e.g. 24:01:01 is not valid msg)
            if (aTime == _midnightExtraRepresentation)
            {
                return CreateExtraMidnightParsedTime();
            }
            else
            {
                return ParseUsingDateTime(aTime);
            }
        }

        private ParsedTimeWithExtraMidnight CreateExtraMidnightParsedTime()
        {
            return new ParsedTimeWithExtraMidnight()
            {
                Hours = 24,
                Minutes = 0,
                Seconds = 0,
            };
        }

        private ParsedTimeWithExtraMidnight ParseUsingDateTime(string aTime)
        {
            var timeParsedTmp = DateTime.ParseExact(aTime, _timeFormat, CultureInfo.InvariantCulture);
            return new ParsedTimeWithExtraMidnight()
            {
                Hours = timeParsedTmp.Hour,
                Minutes = timeParsedTmp.Minute,
                Seconds = timeParsedTmp.Second,
            };
        }
    }
}
