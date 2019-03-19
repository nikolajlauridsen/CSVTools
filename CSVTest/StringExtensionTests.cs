using System;
using System.Runtime.Remoting;
using CSVTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVTest
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void TestRepeatSingleCharString()
        {
            Assert.AreEqual("aaaa", "a".Repeat(4));
        }

        [TestMethod]
        public void TestRepeatString()
        {
            Assert.AreEqual("abcabc", "abc".Repeat(2));
        }

        [TestMethod]
        public void TestEmptyString()
        {
            Assert.AreEqual("", "".Repeat(100));
        }

        [TestMethod]
        public void TestStringRepeatOnce()
        {
            Assert.AreEqual("a", "a".Repeat(1));
        }

        [TestMethod]
        public void TestNegativeCount()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => "a".Repeat(-1));
        }

        [TestMethod]
        public void TestRepeatChar()
        {
            Assert.AreEqual("aaaa", 'a'.Repeat(4));
        }

        [TestMethod]
        public void TestCharNegativeCount()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => 'a'.Repeat(-1));
        }

        [TestMethod]
        public void TestCharRepeatOnce()
        {
            Assert.AreEqual("a", 'a'.Repeat(1));
        }

    }
}
