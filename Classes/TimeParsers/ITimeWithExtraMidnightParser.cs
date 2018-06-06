using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.TimeParsers
{
    public interface ITimeWithExtraMidnightParser<T>
    {
        /// <summary>
        /// Parses some representation of time to the time 'berlin-clock-ready' structure. The implementation should
        /// count with two midnight representation (e.g. '00:00:00 and 24:00:00'). 
        /// </summary>
        /// <param name="time">Time representation</param>
        /// <returns>Time structure for berlin clock.</returns>
        ParsedTimeWithExtraMidnight Parse(T time);
    }
}
