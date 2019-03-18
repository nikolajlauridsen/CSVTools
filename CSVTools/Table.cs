using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
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

        public Table(char columnDelimiter = ';', char rowDelimiter = '\n')
        {
            RowDelimiter = rowDelimiter;
            ColumnDelimiter = columnDelimiter;
        }

        public Table(IEnumerable<IEnumerable<object>> data, char columnDelimiter = ';', char rowDelimiter = '\n') : this(columnDelimiter, rowDelimiter)
        {
            throw new NotImplementedException();
        }

        public object this[int x, int y]
        {
            get => ItemAt(x, y);
            set => InsertItem(value, x, y);
        }


        public void InsertItem(object data, int x, int y)
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

        public void InsertRow(IEnumerable<object> data, int y)
        {
            // Delete the y row if it already exists
            try
            {
                int oldRow = _rows.FindIndex(row => row.Position == y);
                _rows.RemoveAt(oldRow);
            }
            catch (ArgumentNullException)
            {
                // No row with that y pos exists, no need to do anything
            }
            
            // Create new row
            _rows.Add(new Row(data, y));
        }

        public object ItemAt(int x, int y)
        {
            Row targetRow = _rows.Find(row => row.Position == y);
            return targetRow?.ItemAt(x);
        }
    }
}