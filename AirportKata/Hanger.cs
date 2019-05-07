using System.Collections.Generic;

namespace AirportKata
{
    public class Hanger : IHanger
    {
        private readonly int _capacity;
        private List<IPlane> _planes = new List<IPlane>();

        public Hanger(int capacity = 1)
        {
            _capacity = capacity;
        }

        public bool IsFull()
        {
            return _planes.Count == _capacity;
        }

        public void Store(IPlane plane)
        {
            _planes.Add(plane);
        }

        public void Release(IPlane plane)
        {
            _planes.Remove(plane);
        }
    }
}