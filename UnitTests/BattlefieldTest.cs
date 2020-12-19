using System;
using NUnit.Framework;
using System.Drawing;
using GameLib.Imp;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        private Battlefield _battlefield;

        [SetUp]
        public void Setup()
        {
            _battlefield = new Battlefield(10);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Point point = new Point(i, j);
                    _battlefield.SetCell(new Cell { coordinates = point,
                                                    Type = CellType.empty });
                }
            }
        }

        [Test]
        [TestCase(-1, -1)]
        [TestCase(11, 11)]
        public void IsPointInFieldFalse(int x, int y)
        {
            var point = new Point { X = x, Y = y };

            Assert.That(_battlefield.IsPointInField(point), Is.False);
        }

        [Test]
        [TestCase(0, 1)]
        public void IsPointInFieldTrue(int x, int y)
        {
            var point = new Point { X = x, Y = y };

            Assert.That(_battlefield.IsPointInField(point), Is.True);
        }

        [Test]
        [TestCase(-1, -1)]
        [TestCase(11, 11)]
        public void IndexOutOfRangeThrowException(int x, int y)
        {
           Assert.Throws<IndexOutOfRangeException>(() => _battlefield.GetCell(new Point(x, y)));            
        }
    }
}