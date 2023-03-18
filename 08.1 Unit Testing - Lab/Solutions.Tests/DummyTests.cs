using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_DummyLosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health,"Dummy loses health after taking attack");
        }
        [Test]
        public void Test_DeadDummyThrowsExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5));
        }
        [Test]
        public void Test_DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.AreEqual(10, dummy.GiveExperience());
        }
        [Test]
        public void Test_AliveDummyCannotGiveXP()
        {
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(()=>dummy.GiveExperience());
        }
    }
}