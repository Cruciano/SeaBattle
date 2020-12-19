using System;
using NUnit.Framework;
using System.Drawing;
using GameLib.Abs;
using GameLib.Imp;
using GameLib.Builder;

namespace UnitTests
{
    [TestFixture]
    class PlayerManualTest
    {
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player() { DamagedCells = 0 };

            var preset = new GamePreset { Size = 10, ShipsCount = new() { { 4, 2 }, { 3, 3 } } };
            IBattlefieldBuilder builder = new BattlefieldBuilder(preset);
            Director director = new Director(builder);

            director.Construct();
            _player.Battlefield = builder.GetResult();
        }

        [Test]
        [TestCase(-1, -1)]
        [TestCase(11, 11)]
        public void ManualShotOutOfRange(int x, int y)
        {
            Assert.Throws<IndexOutOfRangeException>(() => _player.TargetShot(new Point(x, y), _player.Battlefield));
        }

        [Test]
        public void CellMustBeDamaged()
        {
            _player.Battlefield.SetCell(new Cell() { coordinates = new Point(5, 5), Type = CellType.ship });
            _player.TargetShot(new Point(5, 5), _player.Battlefield);

            Assert.That(_player.Battlefield.GetCell(new Point(5, 5)).Type, Is.EqualTo(CellType.checkShip));
        }

        [Test]
        [TestCase(CellType.empty)]
        [TestCase(CellType.nearShip)]
        public void CellMustBeChecked(CellType type)
        {
            _player.Battlefield.SetCell(new Cell() { coordinates = new Point(5, 5), Type = type });
            _player.TargetShot(new Point(5, 5), _player.Battlefield);

            Assert.That(_player.Battlefield.GetCell(new Point(5, 5)).Type, Is.EqualTo(CellType.check));
        }

    }
}
