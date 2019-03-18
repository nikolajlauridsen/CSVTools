using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVTools
{
    internal class Cell : IComparable<Cell>
    {
        public int Position;
        private object _data;

        public Cell(object data, int position)
        {
            _data = data;
            Position = position;
        }

        public object GetData()
        {
            return _data;
        }

        public void SetData(object data)
        {
            _data = data;
        }

        public override string ToString()
        {
            return _data.ToString();
        }

        public int CompareTo(Cell other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Position.CompareTo(other.Position);
        }
    }
}
