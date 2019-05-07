using System;

namespace AirportKata
{
    public class Airport : IAirport
    {
        private readonly IHanger _hanger;
        private readonly IWeather _weather;

        public Airport(IHanger hanger, IWeather weather)
        {
            _hanger = hanger;
            _weather = weather;
        }

        public void Land(IPlane plane)
        {
            if (_weather.IsStormy()) throw new Exception("Plane can't land in stormy weather");
            if (!plane.IsFlying) throw new Exception("Plane has already landed");
            if (_hanger.IsFull()) throw new Exception("Plane can't land as there is no room");
            plane.Land();
            _hanger.Store(plane);
        }

        public void TakeOff(IPlane plane)
        {
            if (_weather.IsStormy()) throw new Exception("Plane can't take off in stormy weather");
            if (plane.IsFlying) throw new Exception("Plane is already in the air");
            _hanger.Release(plane);
            plane.TakeOff();
        }
    }
}