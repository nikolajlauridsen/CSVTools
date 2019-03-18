using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSVTools;

namespace CSVTest
{

    [TestClass]
    public class RowTests
    {
        Row r1, r2, r3, r4;

        [TestMethod]
        public void TestConstructorWithPos(){
            r1 = new Row(1);
            Assert.AreEqual(r1.Position, 1);
        }

        [TestMethod]
        public void TestConstructorWithPosAndData(){
            List<String> data = new List<string> {"Hello", "World", "!"};

            r1 = new Row(data, 1);
            Assert.AreEqual(r1.ItemAt(1), "Hello");
            Assert.AreEqual(r1.ItemAt(2), "World");
            Assert.AreEqual(r1.ItemAt(3), "!");
        }

        [TestMethod]
        public void TestWidth()
        {
            List<String> data = new List<string> { "I", "contain", "four", "items" };
            r1 = new Row(data, 1);

            r2 = new Row(2);
            r2.Insert("I am", 1);
            r2.Insert("wider than", 28);
            r2.Insert("I seem", 10);

            Assert.AreEqual(4, r1.Width);
            Assert.AreEqual(28,r2.Width);
        }

        [TestMethod]
        public void TestColumnException()
        {
            r1 = new Row(1);
            Assert.ThrowsException<ArgumentException>(() => r1.Insert("Some data", 0));
            Assert.ThrowsException<ArgumentException>(() => r1.Insert("Some data", -1));

        }

        [TestMethod]
        public void TestRowException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Row(0));
            Assert.ThrowsException<ArgumentException>(() => new Row(-1));
        }

        [TestMethod]
        public void TestCompareTo()
        {
            r1 = new Row(1);
            r2 = new Row(7);
            r3 = new Row(1);
            r4 = new Row(5);

            Assert.AreEqual(r1.CompareTo(r3), 0);
            Assert.AreEqual(r2.CompareTo(r1), 1);
            Assert.AreEqual(r4.CompareTo(r2), -1);
        }

        [TestMethod]
        public void TestCellsGetter()
        {
            List<String> data = new List<string> { "I", "contain", "four", "items" };
            r1 = new Row(data, 1);

            r2 = new Row(2);
            r2.Insert("I am", 1);
            r2.Insert("I seem", 28);
            r2.Insert("wider than", 10);
            

            Assert.AreEqual(r1.Cells[0].ToString(), "I");
            Assert.AreEqual(r1.Cells[1].ToString(), "contain");
            Assert.AreEqual(r1.Cells[2].ToString(), "four");
            Assert.AreEqual(r1.Cells[3].ToString(), "items");

            Assert.AreEqual(r2.Cells[0].ToString(), "I am");
            Assert.AreEqual(r2.Cells[1].ToString(), "wider than");
            Assert.AreEqual(r2.Cells[2].ToString(), "I seem");
        }

    }
}
