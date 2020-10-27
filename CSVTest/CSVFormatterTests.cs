using CSVTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVTest
{
    [TestClass]
    public class CSVFormatterTests
    {
        [TestMethod]
        public void EvenTableWithSep()
        {
            Table table = new Table();
            table[1, 1] = 1;
            table[2, 1] = 2;
            table[1, 2] = 3;
            table[2, 2] = 4;
            
            CSVFormatter sut = new CSVFormatter(table);
            
            string expected = "sep=;\n1;2\n3;4\n";
            string actual = sut.GetCSV(table);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void EvenTableWithSepAndDifferentDelim()
        {
            Table table = new Table();
            table.ColumnDelimiter = ',';
            table[1, 1] = 1;
            table[2, 1] = 2;
            table[1, 2] = 3;
            table[2, 2] = 4;
            
            CSVFormatter sut = new CSVFormatter(table);
            
            string expected = "sep=,\n1,2\n3,4\n";
            string actual = sut.GetCSV(table);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void EvenTableWithNoSep()
        {
            Table table = new Table();
            table.SpecifyColumnDelimiterInFile = false;
            table[1, 1] = 1;
            table[2, 1] = 2;
            table[1, 2] = 3;
            table[2, 2] = 4;
            
            CSVFormatter sut = new CSVFormatter(table);

            string expected = "1;2\n3;4\n";
            string actual = sut.GetCSV(table);
            Assert.AreEqual(expected, actual);
        }
    }
}