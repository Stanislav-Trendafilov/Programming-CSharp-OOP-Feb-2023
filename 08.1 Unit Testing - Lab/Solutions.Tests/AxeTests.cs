using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int axeAttack = 10;
        private const int axeDamage = 10;

        [Test]
        public void Test_AxeGettersTest()
        {
            Axe axe = new Axe(10, 10);

            Assert.AreEqual(axeAttack, axe.AttackPoints,"axeSetter doesn't set the right value");
            Assert.AreEqual(axeDamage, axe.DurabilityPoints, "damageSetter doesn't set the right value");
        }

        private int expectedAxeDurability = 9;
        [Test]
        public void Test_WeaponLosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, expectedAxeDurability, "Axe Durability doesn't change after attack");
        }

        [Test]
        public void Test_AttackingWithBrokenWeapon()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(()=>axe.Attack(dummy));
        }
    }
}