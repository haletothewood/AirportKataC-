namespace AirportKata
{
    public interface IHanger
    {
        bool IsFull();
        void Store(IPlane plane);
        void Release(IPlane plane);
    }
}