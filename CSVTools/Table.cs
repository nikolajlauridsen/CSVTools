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

        /// <summary>
        /// The dimensions of the table [width, height]
        /// </summary>
        public int[] Dimensions
        {
            get
            {
                int[] dimensions = new int[2];



                // Find width
                int width = 0;
                foreach (Row row in _rows) if (row.Width > width) width = row.Width;
                dimensions[0] = width;

                // Find height
                _rows.Sort();
                dimensions[1] = _rows[_rows.Count - 1].Position;

                return dimensions;
            }
        }

        /// <summary>
        /// Creates a new empty table
        /// </summary>
        /// <param name="columnDelimiter">Delimiter used to separate columns</param>
        /// <param name="rowDelimiter">Delimiter used to separate rows</param>
        public Table(char columnDelimiter = ';', char rowDelimiter = '\n')
        {
            RowDelimiter = rowDelimiter;
            ColumnDelimiter = columnDelimiter;
        }

        /// <summary>
        /// Creates a new table containing the provided data
        /// </summary>
        /// <param name="data">Data to be inserted</param>
        /// <param name="columnDelimiter">Delimiter used to separate columns</param>
        /// <param name="rowDelimiter">Delimiter used to separate rows</param>
        public Table(IEnumerable<IEnumerable<object>> data, char columnDelimiter = ';', char rowDelimiter = '\n') : this(columnDelimiter, rowDelimiter)
        {
            int i = 0;
            foreach (IEnumerable<object> row in data)
            {
                InsertRow(row, i);
                i++;
            }
        }

        public object this[int x, int y]
        {
            get => ItemAt(x, y);
            set => InsertItem(value, x, y);
        }


        /// <summary>
        /// Insert an object into the given position, rewrites existing data if any
        /// </summary>
        /// <param name="data">Object to be inserted</param>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        public void InsertItem(object data, int x, int y)
        {
            Row targetRow = _rows.Find(row => row.Position == y);

            if (targetRow == null)
            {
                targetRow = new Row(y);
                _rows.Add(targetRow);
            }

            targetRow.Insert(data, x);
        }

        /// <summary>
        /// Insert a row into the table at the given position, rewrites existing data if any
        /// </summary>
        /// <param name="data">Objects to be added</param>
        /// <param name="y">Row number</param>
        public void InsertRow(IEnumerable<object> data, int y)
        {
            // Delete the y row if it already exists
            int oldRow = _rows.FindIndex(row => row.Position == y);
            if (oldRow != -1)
            {
                _rows.RemoveAt(oldRow);
            }
            
            // Create new row
            _rows.Add(new Row(data, y));
        }

        /// <summary>
        /// Get the item at the given position.
        /// </summary>
        /// <param name="x">Column number</param>
        /// <param name="y">Row number</param>
        /// <returns></returns>
        public object ItemAt(int x, int y)
        {
            Row targetRow = _rows.Find(row => row.Position == y);
            return targetRow?.ItemAt(x);
        }

        // TODO: use CSVFormatter for these last 2
        public void SaveToFile(string path)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}