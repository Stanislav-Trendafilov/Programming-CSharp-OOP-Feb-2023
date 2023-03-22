namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena= new Arena();
        }

        [TearDown]
        public void TearDown()
        {
            arena = null;
        }

        [Test]
        public void Test_EnrolledWarriorCount()
        {
            arena.Enroll(new Warrior("Kaisa", 50, 50));

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void Test_CreatingArena()
        { 
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Test_EnrollExistingWarriorInTheArena()
        {
            arena.Enroll(new Warrior("Asen", 50, 50));

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Asen", 60, 50)));

            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [Test]
        public void Test_EnrollWarriorInTheArena()
        {
            arena.Enroll(new Warrior("Asen", 50, 50));

            Assert.AreEqual(1,arena.Count);
        }

        [Test]
        public void Test_FightWithoutEnemy()
        {
            arena.Enroll(new Warrior("Asen", 50, 50));

            InvalidOperationException exception =
                    Assert.Throws<InvalidOperationException>(() => arena.Fight("Asen","Petar"));

            Assert.AreEqual($"There is no fighter with name Petar enrolled for the fights!", exception.Message);

        }

        [Test]
        public void Test_FightMethod()
        {
            Warrior attacker = new Warrior("Asen", 50, 50);
            Warrior defender = new Warrior("Ivan", 40, 35);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Asen", "Ivan");

            Assert.AreEqual(10, attacker.HP);
            Assert.AreEqual(0, defender.HP);

        }
    }
}
