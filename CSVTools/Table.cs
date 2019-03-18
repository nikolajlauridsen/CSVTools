using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CSVTools
{
    public class Table
    {
        public char RowDelimiter;
        public char ColumnDelimiter;
        private List<Row> _rows = new List<Row>();

        public Table(char rowDelimiter = ';', char columnDelimiter = '\n')
        {
            RowDelimiter = rowDelimiter;
            ColumnDelimiter = columnDelimiter;
        }

        public void InsertData(object data, int x, int y)
        {
            Row targetRow;
            try
            {
                targetRow = _rows.Find(row => row.Position == y);
            }
            catch (ArgumentNullException)
            {
                targetRow = new Row(y);
                _rows.Add(targetRow);
            }

            targetRow.Insert(data, x);
        }
    }
}