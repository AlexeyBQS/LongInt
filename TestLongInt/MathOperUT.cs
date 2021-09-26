using NUnit.Framework;
using LongInt;

namespace TestLongInt
{
    public class MathOperUT
    {
        longint li1 = 100;
        longint li2 = 50;

        [Test]
        public void TestPlus()
        {
            Assert.AreEqual("150", (li1 + li2).ToString());
        }

        [Test]
        public void TestMinus()
        {
            Assert.AreEqual("50", (li1 - li2).ToString());
            Assert.AreEqual("-50", (li2 - li1).ToString());
        }
    }
}
