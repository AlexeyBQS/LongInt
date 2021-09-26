using LongInt;
using NUnit.Framework;

namespace TestLongInt
{
    public class ComapeUT
    {
        private longint li1 = 12;
        private longint li2 = 12;
        private longint li3 = 34;

        [Test]
        public void TestEquals()
        {
            Assert.AreEqual(true, li1 == li2);
            Assert.AreEqual(false, li1 == li3);
        }

        [Test]
        public void TestNotEquals()
        {
            Assert.AreEqual(false, li1 != li2);
            Assert.AreEqual(true, li1 != li3);
        }

        [Test]
        public void TestMoreThan()
        {
            Assert.AreEqual(false, li1 > li3);
            Assert.AreEqual(true, li3 > li1);
        }

        [Test]
        public void TestLessThan()
        {
            Assert.AreEqual(true, li1 < li3);
            Assert.AreEqual(false, li3 < li1);
        }

        [Test]
        public void TestEqualsOrMoreThan()
        {
            Assert.AreEqual(true, li1 >= li2);
            Assert.AreEqual(false, li1 >= li3);
            Assert.AreEqual(true, li3 >= li1);
        }

        [Test]
        public void TestEqualsOrLessThan()
        {
            Assert.AreEqual(true, li1 <= li2);
            Assert.AreEqual(true, li1 <= li3);
            Assert.AreEqual(false, li3 <= li1);
        }
    }
}
