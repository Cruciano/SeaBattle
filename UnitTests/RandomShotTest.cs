using System;
using NUnit.Framework;
using System.Drawing;
using Moq;
using GameLib.Abs;
using GameLib.Imp;
using GameLib.ShotState;

namespace UnitTests
{
    [TestFixture]
    class RandomShotTest
    {
        private Mock<IPlayer> _player = new();
        private Mock<IBattlefield> _battlefield = new();
        private RandomShot _randomShot;

        [SetUp]
        public void Setup()
        {
            _player.Setup(p => p.Battlefield).Returns(_battlefield.Object);
            _battlefield.Setup(b => b.Size).Returns(10);
            _randomShot = new(_player.Object);
        }

        [Test]
        public void ShotEmptyCellReturnFalse()
        {
               
        }
    }
}
