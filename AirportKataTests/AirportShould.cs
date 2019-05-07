using AirportKata;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;

namespace AirportKataTests
{
    [TestFixture]
    class AirportShould
    {
        public Mock<IPlane> _planeMock;
        public Mock<IHanger> _hangerMock;
        public Mock<IWeather> _weatherMock;

        public Airport _airport;

        [SetUp]
        public void InitializeTest()
        {
            _planeMock = new Mock<IPlane>();
            _hangerMock = new Mock<IHanger>();
            _weatherMock = new Mock<IWeather>();
            _airport = new Airport(_hangerMock.Object, _weatherMock.Object);
        }

        [Test]
        public void LandAPlane()
        {
            _planeMock.Setup(x => x.IsFlying).Returns(true);
            _airport.Land(_planeMock.Object);

            _planeMock.Verify(x => x.Land());
        }

        [Test]
        public void InstructPlaneToTakeOff()
        {
            _airport.TakeOff(_planeMock.Object);

            _planeMock.Verify(x => x.TakeOff());
        }

        [Test]
        public void NotLandAPlaneThatHasAlreadyLanded()
        {
            _planeMock.Setup(x => x.IsFlying).Returns(false);

            Should.Throw<Exception>(() => _airport.Land(_planeMock.Object)).Message
                .ShouldBe("Plane has already landed");
        }

        [Test]
        public void NotAskAPlaneToTakeOffIfItIsInTheAir()
        {
            _planeMock.Setup(x => x.IsFlying).Returns(true);

            Should.Throw<Exception>(() => _airport.TakeOff(_planeMock.Object)).Message
                .ShouldBe("Plane is already in the air");
        }

        [Test]
        public void NotLandAPlaneInStormyWeather()
        {
            _planeMock.Setup(x => x.IsFlying).Returns(true);
            _weatherMock.Setup(x => x.IsStormy()).Returns(true);

            Should.Throw<Exception>(() => _airport.Land(_planeMock.Object)).Message
                .ShouldBe("Plane can't land in stormy weather");
        }

        [Test]
        public void NotAskAPlaneToTakeOffInStormyWeather()
        {
            _planeMock.Setup(x => x.IsFlying).Returns(false);
            _weatherMock.Setup(x => x.IsStormy()).Returns(true);

            Should.Throw<Exception>(() => _airport.TakeOff(_planeMock.Object)).Message
                .ShouldBe("Plane can't take off in stormy weather");
        }

        [Test]
        public void NotLandAPlaneIfAtCapacity()
        {
            _hangerMock.Setup(x => x.IsFull()).Returns(true);
            _weatherMock.Setup(x => x.IsStormy()).Returns(false);
            _planeMock.Setup(x => x.IsFlying).Returns(true);

            Should.Throw<Exception>(() => _airport.Land(_planeMock.Object)).Message
                .ShouldBe("Plane can't land as there is no room");
        }
    }
}
