using AirportKata;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;

namespace AirportKataTests
{
    class WeatherShould
    {
        private Weather _weather;

        [Test]
        public void ShouldBeEitherStormyOrNotStormy()
        {
            _weather = new Weather();

            _weather.IsStormy().ShouldBeOfType<bool>();
        }

        [Test]
        public void ShouldBeMostlyNotStormy()
        {
            _weather = new Weather();

            List<bool> weatherPattern = new List<bool>();

            for (var i = 0; i < 1000; i++)
            {
                var result = _weather.IsStormy();
                weatherPattern.Add(result);
            }

            var trueCount = weatherPattern.Where(x => x == true).ToList().Count;

            var half = 500;
            var fourfifths = 800;

            trueCount.ShouldBeGreaterThan(half);
            trueCount.ShouldBeLessThan(fourfifths);
        }
    }
}
