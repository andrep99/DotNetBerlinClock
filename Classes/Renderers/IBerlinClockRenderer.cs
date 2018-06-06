namespace BerlinClock.Classes.Renderers
{
    public interface IBerlinClockRenderer<out T>
    {
        /// <summary>
        /// Creates some representation of berlin clock based on normalizaed time data. 
        /// </summary>
        /// <param name="aBerlinClockData">Normalized data for clock representation which corresponds to a specific time.</param>
        /// <returns>Some representation of berlin clock at specific time.</returns>
        T RenderBerlinClock(BerlinClockData aBerlinClockData);
    }
}
