using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVTools
{
    internal class CSVFormatter
    {
        public char RowDelimiter;
        public char ColumnDelimiter;

        private Table _targetTable = null;

        internal CSVFormatter(char columnDelimiter = ';', char rowDelimiter = '\n')
        {
            ColumnDelimiter = columnDelimiter;
            RowDelimiter = rowDelimiter;
        }

        internal CSVFormatter(Table targetTable, char columnDelimiter = ';', char rowDelimiter = '\n')
        {
            ColumnDelimiter = columnDelimiter;
            RowDelimiter = rowDelimiter;
            _targetTable = targetTable;
        }

        public string GetCSV(Table table)
        {
            StringBuilder builder = new StringBuilder();
            int[] size = table.Dimensions;
            int cursor = 0;

            foreach (Row row in table.Rows)
            {
                
            }

            throw new NotImplementedException();

        }

        public void SaveToFile(string path)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return GetCSV(_targetTable);
        }
    }
}
