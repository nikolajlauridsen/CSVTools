using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSVTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVTest
{
    [TestClass]
    public class TableTest
    {
        private Table t1;

        [TestMethod]
        public void ConstructWithData()
        {
            List<List<string>> data = new List<List<string>>();
            // Create data
            List<String> row1, row2, row3, row4;
            row1 = new List<string> { "1,1", "2,1", "3,1", "4,1" };
            row2 = new List<string> { "1,2", "2,2", "3,2", "4,2" };
            row3 = new List<string> { "1,3", "2,3", "3,3", "4,3" };
            row4 = new List<string> { "1,4", "2,4", "3,4", "4,4" };
            data.Add(row1);
            data.Add(row2);
            data.Add(row3);
            data.Add(row4);

            t1 = new Table(data);

            Assert.AreEqual("1,1", t1[1, 1]);
            Assert.AreEqual("2,1", t1[2, 1]);
            Assert.AreEqual("3,1", t1[3, 1]);
            Assert.AreEqual("4,1", t1[4, 1]);

            Assert.AreEqual("1,2", t1[1, 2]);
            Assert.AreEqual("2,2", t1[2, 2]);
            Assert.AreEqual("3,2", t1[3, 2]);
            Assert.AreEqual("4,2", t1[4, 2]);

            Assert.AreEqual("1,3", t1[1, 3]);
            Assert.AreEqual("2,3", t1[2, 3]);
            Assert.AreEqual("3,3", t1[3, 3]);
            Assert.AreEqual("4,3", t1[4, 3]);

            Assert.AreEqual("1,4", t1[1, 4]);
            Assert.AreEqual("2,4", t1[2, 4]);
            Assert.AreEqual("3,4", t1[3, 4]);
            Assert.AreEqual("4,4", t1[4, 4]);

        }

        [TestMethod]
        public void ConstructWithDataArray()
        {
            string[][] data = new string[4][];
            data[0] = new[] {"1,1", "2,1", "3,1", "4,1"};
            data[1] = new[] {"1,2", "2,2", "3,2", "4,2"};
            data[2] = new[] {"1,3", null, "3,3", "4,3"};
            data[3] = new[] {"1,4", "2,4", "3,4", "4,4"};

            t1 = new Table(data);

            Assert.AreEqual("1,1", t1[1, 1]);
            Assert.AreEqual("2,1", t1[2, 1]);
            Assert.AreEqual("3,1", t1[3, 1]);
            Assert.AreEqual("4,1", t1[4, 1]);

            Assert.AreEqual("1,2", t1[1, 2]);
            Assert.AreEqual("2,2", t1[2, 2]);
            Assert.AreEqual("3,2", t1[3, 2]);
            Assert.AreEqual("4,2", t1[4, 2]);

            Assert.AreEqual("1,3", t1[1, 3]);
            Assert.AreEqual(null, t1[2, 3]);
            Assert.AreEqual("3,3", t1[3, 3]);
            Assert.AreEqual("4,3", t1[4, 3]);

            Assert.AreEqual("1,4", t1[1, 4]);
            Assert.AreEqual("2,4", t1[2, 4]);
            Assert.AreEqual("3,4", t1[3, 4]);
            Assert.AreEqual("4,4", t1[4, 4]);

        }

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
            t1.InsertRow(moreData, 4);

            Assert.AreEqual("some", t1[1,1]);
            Assert.AreEqual("random", t1[2, 1]);
            Assert.AreEqual("data", t1[3, 1]);


            Assert.AreEqual("second", t1[1, 4]);
            Assert.AreEqual("line", t1[2, 4]);
            Assert.AreEqual("of", t1[3, 4]);
            Assert.AreEqual("data", t1[4, 4]);
        }

        [TestMethod]
        public void TestDimensions()
        {
            List<List<string>> data = new List<List<string>>();
            List<string> row1, row2, row3, row4;
            row1 = new List<string> { "1,1", "2,1", "3,1", "4,1" };
            row2 = new List<string> { "1,2", "2,2" };
            row3 = new List<string> { "1,3", "2,3", "3,3", "4,3" };
            row4 = new List<string> { "1,4", "2,4", "3,4", "4,4", "5,4", "6,4" };
            data.Add(row1);
            data.Add(row2);
            data.Add(row3);
            data.Add(row4);
            t1 = new Table(data);

            Assert.AreEqual(6, t1.Dimensions[0]);
            Assert.AreEqual(4, t1.Dimensions[1]);

            t1.InsertItem("banana", 20, 20);
            Assert.AreEqual(20, t1.Dimensions[0]);
            Assert.AreEqual(20, t1.Dimensions[1]);
        }

        [TestMethod]
        public void TestInternalRowAccesor()
        {
            t1 = new Table();
            string[] data = new[] { "some", "random", "data" };
            List<string> moreData = new List<string>(new[] { "second", "line", "of", "data" });
            t1.InsertRow(moreData, 8);
            t1.InsertRow(data, 1);

            List<Row> rows = t1.Rows;

            Assert.AreEqual(2, rows.Count);
            Assert.AreEqual(1, rows[0].Position);
            Assert.AreEqual(8, rows[1].Position);


        }
    }
}
