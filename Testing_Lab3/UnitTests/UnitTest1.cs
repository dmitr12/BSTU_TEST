using NUnit.Framework;
using Testing_Lab3;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void BisNegative()
        {
            Assert.IsFalse(new Triangle().IsTriangle(2, -4, 5));
        }
        [Test]
        public void AisNegative()
        {
            Assert.IsFalse(new Triangle().IsTriangle(-2, 4, 5));
        }
        [Test]
        public void CisNegative()
        {
            Assert.IsFalse(new Triangle().IsTriangle(2, 4, -5));
        }
        [Test]
        public void SidesAreEqual()
        {
            Assert.IsTrue(new Triangle().IsTriangle(4.25f, 4.25f, 4.25f));
        }
        [Test]
        public void BisLessThenSumOtherSides()
        {
            Assert.IsTrue(new Triangle().IsTriangle(8, 3, 10));
        }
        [Test]
        public void APlusBEqualC()
        {
            Assert.IsFalse(new Triangle().IsTriangle(2, 4, 6));
        }
        [Test]
        public void AisMoreThenSumOtherSides()
        {
            Assert.IsFalse(new Triangle().IsTriangle(17.56f, 4.13f, 10));
        }
        [Test]
        public void BisMoreThenSumOtherSides()
        {
            Assert.IsFalse(new Triangle().IsTriangle(3, 10, 2.7f));
        }
        [Test]
        public void CisMoreThenSumOtherSides()
        {
            Assert.IsFalse(new Triangle().IsTriangle(3.5f, 10, 27));
        }
        [Test]
        public void AllSidesAreNegative()
        {
            Assert.IsFalse(new Triangle().IsTriangle(-1, -6, -5));
        }
    }
}