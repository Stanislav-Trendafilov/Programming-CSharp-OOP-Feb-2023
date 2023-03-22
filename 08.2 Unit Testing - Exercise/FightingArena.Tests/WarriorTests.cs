namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {

        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Kaisa", 50, 40);
        }

        [TearDown]
        public void TearDown()
        {
            warrior = null;
        }

        [Test]
        public void Test_ConstructorSettingRightValues()
        {
            Assert.AreEqual("Kaisa", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(40, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void Test_NameCannotBeNullOrWhiteSpace(string name)
        {
            ArgumentException argumentException=
                Assert.Throws<ArgumentException>(() => new Warrior(name, 50, 40));

            Assert.AreEqual("Name should not be empty or whitespace!", argumentException.Message);
        }

        [Test]
        [TestCase(-3)]
        [TestCase(0)]
        public void Test_DamageCannotBeZeroOrNegative(int damage)
        {
            ArgumentException argumentException =
                Assert.Throws<ArgumentException>(() => new Warrior("Kaisa", damage, 40));

            Assert.AreEqual("Damage value should be positive!", argumentException.Message);
        }

        [Test]
        [TestCase(-3)]
        public void Test_HpCannotBeNegative(int hp)
        {
            ArgumentException argumentException =
                Assert.Throws<ArgumentException>(() => new Warrior("Kaisa", 50, hp));

            Assert.AreEqual("HP should not be negative!", argumentException.Message);
        }

        private const int MIN_ATTACK_HP = 30;
        [Test]
        public void Test_AttackWithoutEnoughHP()
        {
            Warrior warrior = new Warrior("Ivan", 50, 10);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Peppu",1,50)));

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }

        [Test]
        public void Test_AttackEnemyWhoseHPIsNotEnough()
        {
            Warrior warrior = new Warrior("Ivan", 50, 50);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Peppu", 1, 1)));

            Assert.AreEqual($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!", exception.Message);
        }

        [Test]
        public void Test_AttackEnemyWhoHasMoreDamageThanYou()
        {
            Warrior warrior = new Warrior("Ivan", 50, 50);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Peppu", 100, 40)));

            Assert.AreEqual($"You are trying to attack too strong enemy", exception.Message);
        }

        [Test]
        public void Test_TakeDamageAfterAttack()
        {
            Warrior warrior = new Warrior("Ivan", 60, 50);

            warrior.Attack(new Warrior("Peppu", 40, 40));

            Assert.AreEqual(10,warrior.HP);
        }

        [Test]
        public void Test_KillEnemyAfterAttack()
        {
            Warrior warrior = new Warrior("Ivan", 60, 50);

            Warrior attackedWarrior = new Warrior("Peppu", 40, 40);
            warrior.Attack(attackedWarrior);

            Assert.AreEqual(0, attackedWarrior.HP);
        }

        [Test]
        public void Test_EnemyTakingDamage()
        {
            Warrior warrior = new Warrior("Ivan", 60, 50);

            Warrior attackedWarrior = new Warrior("Peppu", 40, 80);
            warrior.Attack(attackedWarrior);

            Assert.AreEqual(20, attackedWarrior.HP);
        }

    }
}