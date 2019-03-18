using System;
using System.Collections.Generic;
using CSVTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVTest
{
    [TestClass]
    public class TableTest
    {
        private Table t1;

        [TestMethod]
        public void TestIndexer()
        {
            t1 = new Table();
            t1[1, 1] = "Column1";
            t1[2, 1] = "Column2";
            t1[3, 1] = "Column3";
            t1[7, 8] = 27.5;

            Assert.AreEqual("Column1", t1[1,1]);
            Assert.AreEqual("Column2", t1[2, 1]);
            Assert.AreEqual("Column3", t1[3, 1]);
            Assert.AreEqual(27.5, t1[7, 8]);
        }

        [TestMethod]
        public void TestInsertRow()
        {
            t1 = new Table();
            string[] data = new[] {"some", "random", "data"};
            List<string> moreData = new List<string>(new [] {"second", "line", "of", "data"});
            t1.InsertRow(data, 1);
            t1.InsertRow(moreData, 2);

            Assert.AreEqual("some", t1[1,1]);
            Assert.AreEqual("random", t1[2, 1]);
            Assert.AreEqual("data", t1[3, 1]);


            Assert.AreEqual("second", t1[1, 2]);
            Assert.AreEqual("line", t1[2, 2]);
            Assert.AreEqual("of", t1[3, 2]);
            Assert.AreEqual("data", t1[4, 2]);
        }
    }
}
