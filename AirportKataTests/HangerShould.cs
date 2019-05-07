using AirportKata;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace AirportKataTests
{
    [TestFixture]
    class HangerShould
    {
        private Mock<IPlane> _planeMock;
        private Hanger _hanger;

        [Test]
        public void ShouldHaveADefaultCapacity()
        {
            _hanger = new Hanger();
            _planeMock = new Mock<IPlane>();

            _hanger.Store(_planeMock.Object);

            _hanger.IsFull().ShouldBe(true);
        }

        [Test]
        public void ShouldHaveAOverridableDefaultCapacity()
        {
            _hanger = new Hanger(10);
            _planeMock = new Mock<IPlane>();

            for (var i = 0; i < 10; i++)
            {
                _hanger.Store(new Mock<IPlane>().Object);
            }

            _hanger.IsFull().ShouldBe(true);
        }
    }
}

