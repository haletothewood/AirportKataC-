using AirportKata;
using NUnit.Framework;
using Shouldly;

namespace AirportKataTests
{
    [TestFixture]
    class PlaneShould
    {
        [Test]
        public void LandWhenInstructedTo()
        {
            Plane _plane = new Plane();

            _plane.Land();

            _plane.IsFlying.ShouldBe(false);
        }

        [Test]
        public void TakeOffWhenInstructedTo()
        {
            Plane _plane = new Plane();

            _plane.TakeOff();

            _plane.IsFlying.ShouldBe(true);
        }
    }
}
