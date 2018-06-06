namespace BerlinClock.Classes.Renderers
{
    public interface IBerlinClockRenderer<out T>
    {
        T RenderBerlinClock(BerlinClockData aBerlinClockData);
    }
}
