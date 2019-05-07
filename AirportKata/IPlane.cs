namespace AirportKata
{
    public interface IPlane
    {
        void Land();
        void TakeOff();
        bool IsFlying { get; set; }
    }
}