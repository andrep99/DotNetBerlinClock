namespace BerlinClock.Classes.Utils
{
    static class ExtensionMethods
    {
        public static bool IsEvenNumber(this int number)
        {
            return (number % 2) == 0;
        }
    }
}
