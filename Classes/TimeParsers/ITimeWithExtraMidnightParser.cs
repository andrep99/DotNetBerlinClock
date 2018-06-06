using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.TimeParsers
{
    public interface ITimeWithExtraMidnightParser<T>
    {
        ParsedTimeWithExtraMidnight Parse(T aTime);
    }
}
