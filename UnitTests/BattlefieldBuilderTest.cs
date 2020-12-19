using System;
using NUnit.Framework;
using System.Drawing;
using GameLib.Abs;
using GameLib.Imp;
using GameLib.Builder;

namespace UnitTests
{
    [TestFixture]
    class BattlefieldBuilderTest
    {
        private BattlefieldBuilder _builder;
        private int _shipCells;

        [SetUp]
        public void Setup()
        {
            var preset = new GamePreset { Size = 10, ShipsCount = new (){ {4, 2}, {3, 3} } };
            _builder = new BattlefieldBuilder(preset);
            _shipCells = 0;

            foreach (var (size, count) in preset.ShipsCount)
            {
                _shipCells += size * count;
            }
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void IsBattlefieldCreated_LessZero(int size)
        {
            var preset = new GamePreset { Size = size, ShipsCount = new() { { 4, 2 }, { 3, 3 } } };
            var builder = new BattlefieldBuilder(preset);

            Assert.Throws<OverflowException>(() => builder.CreateBattlefield());
        }

        [Test]
        public void IsBuilderReturnsTypeOfBattlefield()
        {
            Assert.That(_builder.GetResult(), Is.TypeOf<Battlefield>());
        }

        [Test]
        public void IsBattlefieldCreatedEmpty()
        {
            _builder.CreateBattlefield();
            AssertCellsEmpty(_builder.GetResult());
        }

        [Test]
        public void IsShipsCreatedCorrectly()
        {
            _builder.CreateBattlefield();
            _builder.CreateShips();
            AssertShipsCreatedCrorrectly(_builder.GetResult());
        }


        public void AssertCellsEmpty(IBattlefield field)
        {
            for (int i = 0; i < field.Size; i++)
            {
                for (int j = 0; j < field.Size; j++)
                {
                    Assert.That(field.GetCell(new Point(i, j)).Type, Is.EqualTo(CellType.empty));
                }
            }
        }

        public void AssertShipsCreatedCrorrectly(IBattlefield field)
        {
            int shipCells = 0;

            for (int i = 0; i < field.Size; i++)
            {
                for (int j = 0; j < field.Size; j++)
                {
                    if(field.GetCell(new Point(i, j)).Type == CellType.ship)
                    {
                        shipCells++;
                    }
                }
            }

            Assert.That(shipCells, Is.EqualTo(_shipCells));
        }
    }
}
