using System;

namespace AirportKata
{
    public class Weather : IWeather
    {
        private readonly Random _random;

        public Weather()
        {
            _random = new Random();
        }
        public bool IsStormy()
        {
            return _random.Next(0, 100) > 25;
        }
    }
}