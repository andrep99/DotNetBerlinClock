using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{

    public interface ITimeToBerlinClockDataConverter
    {
        /// <summary>
        /// Converts time to normalized data for berlin clock. The implementation should change only if logic behind 
        /// berlin clock changes.
        /// </summary>
        /// <param name="parsedTimeWithExtraMidnight">Time to convert</param>
        /// <returns>Normalized data for berlin clock</returns>
        BerlinClockData ConvertParsedTimeToBerlinClockData(ParsedTimeWithExtraMidnight parsedTimeWithExtraMidnight);
    }
}
