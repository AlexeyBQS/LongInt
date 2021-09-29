using NUnit.Framework;
using LongInt;

namespace TestLongInt
{
    public class MathOperUT
    {
        longint li1 = 100;
        longint li2 = 50;

        [Test]
        public void TestАddition()
        {
            Assert.AreEqual("150", (li1 + li2).ToString());
        }

        [Test]
        public void TestSubtraction()
        {
            Assert.AreEqual("50", (li1 - li2).ToString());
            Assert.AreEqual("-50", (li2 - li1).ToString());
        }

        [Test]
        public void TestMultiply()
        {
            Assert.AreEqual("5000", (li1 * li2).ToString());
        }

        [Test]
        public void TestDivision()
        {
            Assert.AreEqual("2", (li1 / li2).ToString());
        }

        [Test]
        public void TestRemainder()
        {
            Assert.AreEqual("0", (li1 % li2).ToString());
        }
    }
}
