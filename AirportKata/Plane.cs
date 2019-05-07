namespace AirportKata
{
    public class Plane : IPlane
    {
        public Plane()
        {
            IsFlying = true;
        }

        public void Land()
        {
            IsFlying = false;
        }

        public void TakeOff()
        {
            IsFlying = true;
        }

        public bool IsFlying { get; set; }
    }
}