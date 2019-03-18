using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVTools
{
    internal class Row
    {
        /// <summary>
        /// The Y position of the row
        /// </summary>
        public int Position;

        /// <summary>
        /// The width of the row
        /// </summary>
        public int Width => Cells[Cells.Count - 1].Position;
        
        /// <summary>
        /// A sorted copy of the cells (readonly)
        /// </summary>
        public List<Cell> Cells
        {
            get
            {
                List<Cell> returnList = new List<Cell>(_row);
                returnList.Sort();
                return returnList;
            }
        }
        private List<Cell> _row = new List<Cell>();

        internal Row(int pos)
        {
            Position = pos;
        }

        internal Row(IEnumerable<object> data, int pos)
        {
            Position = pos;

            int i = 0;
            foreach (object item in data)
            {
                Insert(item, i);
                i++;
            }
        }

        /// <summary>
        /// Insert an object into the cell at the x position of the column.
        /// Overwrites the data in the cell if it already exists
        /// </summary>
        /// <param name="data">Data to be inserted</param>
        /// <param name="x">The x position of the cell within the row</param>
        public void Insert(object data, int x)
        {
            try
            {
                Cell targetCell = _row.Find(cell => cell.Position == x);
                targetCell.SetContent(data);
            }
            catch (ArgumentNullException)
            {
                Cells.Add(new Cell(data, x));
            }
        }

        /// <summary>
        /// Retrieve the stored item at the given location
        /// </summary>
        /// <param name="pos">Potion in row to retrieve from</param>
        /// <returns></returns>
        public object ItemAt(int pos)
        {
            try
            {
                return _row.Find(cell => cell.Position == pos).GetData();
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }



    }
}
