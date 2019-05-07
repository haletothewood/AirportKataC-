namespace AirportKata
{
    public interface IAirport
    {
        void Land(IPlane plane);
        void TakeOff(IPlane plane);
    }
}