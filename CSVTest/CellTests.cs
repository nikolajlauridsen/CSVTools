using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSVTools;

namespace CSVTest
{
    [TestClass]
    public class CellTests
    {
        private Cell c1, c2, c3, c4;

        [TestMethod]
        public void TestConstructor()
        {
            c1 = new Cell("Hello world!", 7);
            Assert.AreEqual(c1.GetData(), "Hello world!");
            Assert.AreEqual(c1.Position, 7);
        }

        [TestMethod]
        public void TestGetData()
        {
            c1 = new Cell("What is the answer?", 1);
            c2 = new Cell(42, 2);
            c3 = new Cell(42.2, 3);
            c4 = new Cell(new DateTime(2019, 3, 16, 17, 15, 30), 4);

            Assert.AreEqual(c1.GetData(), "What is the answer?");
            Assert.AreEqual(c2.GetData(), 42);
            Assert.AreEqual(c3.GetData(), 42.2);
            // Need to cast here, even though it wont be elsewhere since the format needs to be the same everywhere for testing
            Assert.AreEqual(((DateTime) c4.GetData()).ToString("dd-MM-yy HH:MM:ss"), "16-03-19 17:03:30");
        }

        [TestMethod]
        public void TestSetData()
        {
            c1 = new Cell("I am a cell", 5);
            c1.SetData("No I'm an object");
            Assert.AreEqual(c1.GetData(), "No I'm an object");
        }

        [TestMethod]
        public void TestCompare()
        {
            c1 = new Cell(600, 1);
            c2 = new Cell(5, 7);
            c3 = new Cell("Bannnnnnnana", 1);
            c4 = new Cell(true, 5);

            Assert.AreEqual(c1.CompareTo(c3), 0);
            Assert.AreEqual(c2.CompareTo(c1), 1);
            Assert.AreEqual(c4.CompareTo(c2), -1);
        }

        [TestMethod]
        public void TestToString()
        {
            c1 = new Cell("Hello", 1);
            c2 = new Cell(4, 2);
            c3 = new Cell(true, 3);

            Assert.AreEqual(c1.ToString(), "Hello");
            Assert.AreEqual(c2.ToString(), "4");
            Assert.AreEqual(c3.ToString(), true.ToString());
        }


    }
}
