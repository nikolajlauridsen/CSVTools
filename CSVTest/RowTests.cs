using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSVTools;

namespace CSVTest
{

    [TestClass]
    public class RowTests
    {
        Row r1, r2, r3;

        [TestMethod]
        public void TestConstructorWithPos(){
            r1 = new Row(1);
            Assert.AreEqual(r1.Position, 1);
        }

        [TestMethod]
        public void TestConstructorWithPosAndData(){
            List<String> data = new List<string> {"Hello", "World", "!"};

            r1 = new Row(data, 1);
            Assert.AreEqual(r1.ItemAt(0), "Hello");
            Assert.AreEqual(r1.ItemAt(1), "World");
            Assert.AreEqual(r1.ItemAt(2), "!");

        }
    }
}
