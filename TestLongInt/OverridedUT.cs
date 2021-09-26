using LongInt;
using NUnit.Framework;

namespace TestLongInt
{
    public class OverridedUT
    {
        longint li1 = 1234;
        longint li2 = 1234;
        longint li3 = 4321;

        [Test]
        public void TestEquals()
        {
            Assert.AreEqual(true, li1.Equals(li2));
            Assert.AreNotEqual(true, li1.Equals(1234));
        }
        
        [Test]
        public void TestGetHashCode()
        {
            Assert.AreEqual(true, li1.GetHashCode() == li2.GetHashCode());
            Assert.AreEqual(true, li1.GetHashCode() != li3.GetHashCode());
        }
    }
}
