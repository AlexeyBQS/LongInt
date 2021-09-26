using LongInt;
using NUnit.Framework;

namespace TestLongInt
{
    public class InitUT
    {
        [Test]
        public void TestNullInit()
        {
            Assert.AreEqual("0", new longint().ToString());
        }

        [Test]
        public void TestSbyteInit()
        {
            Assert.AreEqual("1234", new longint(false, new sbyte[] { 4, 3, 2, 1 }).ToString());
            Assert.AreEqual("-1234", new longint(true, new sbyte[] { 4, 3, 2, 1 }).ToString());
        }

        [Test]
        public void TestIntInit()
        {
            Assert.AreEqual("1234", (new longint(1234).ToString()));
            Assert.AreEqual("-1234", (new longint(-1234).ToString()));

            Assert.AreEqual("1234", ((longint)1234).ToString());
            Assert.AreEqual("-1234", ((longint)(-1234)).ToString());
        }
    }
}
