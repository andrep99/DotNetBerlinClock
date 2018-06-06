
namespace BerlinClock
{
    public class ParsedTimeWithExtraMidnight
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public bool IsValid()
        {
            var isValid =  Is24AllowedTime() || IsStandardTime();
            return isValid;
        }

        private bool IsStandardTime()
        {
            return Hours >= 0 && Hours <= 23 &&
                   Minutes >= 0 && Minutes <= 59 &&
                   Seconds >= 0 && Seconds <= 59;
        }

        private bool Is24AllowedTime()
        {
            return Hours == 24 && Minutes == 0 && Seconds == 0;
        }
    }
}