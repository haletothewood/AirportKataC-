using AirportKata;
using Moq;
using NUnit.Framework;


namespace AirportKataTests.Feature
{
    [TestFixture]
    class LandPlaneFeatureTest
    {
        public Mock<IHanger> _hangerMock;
        public Mock<IWeather> _weatherMock;
        private Airport _airport;

        [SetUp]
        public void InitializeTest()
        {
            _hangerMock = new Mock<IHanger>();
            _weatherMock = new Mock<IWeather>();
            _airport = new Airport(_hangerMock.Object, _weatherMock.Object);
        }

        [Test]
        public void WhenAPlaneIsInstructedToLandAtAnAirport_ThenItLandsAsTheAirport()
        {
            // assemble
            Mock<IPlane> _planeMock = new Mock<IPlane>();
            _planeMock.Setup(x => x.IsFlying).Returns(true);
            _weatherMock.Setup(x => x.IsStormy()).Returns(false);

            // act
            _airport.Land(_planeMock.Object);

            // assert
            _planeMock.Verify(x => x.Land());
            _hangerMock.Verify(x => x.Store(_planeMock.Object));
        }
    }
}
