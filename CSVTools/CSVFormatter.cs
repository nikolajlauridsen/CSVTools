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
            int xCursor = 1;
            int yCursor = 1;

            foreach (Row row in table.Rows)
            {
                // Add empty rows
                builder.Append(GenerateEmptyRows(size[0],row.Position - yCursor));
                yCursor = row.Position;

                StringBuilder rowBuilder = new StringBuilder();
                foreach (Cell cell in row.Cells)
                {
                    // Add delimiters to "select" the cell
                    rowBuilder.Append(ColumnDelimiter.Repeat(cell.Position - xCursor));
                    // Add cell data
                    rowBuilder.Append(cell);
                    xCursor = cell.Position;
                }
                // Pad to dimensions
                rowBuilder.Append(ColumnDelimiter.Repeat(size[0] - xCursor));
                builder.Append(rowBuilder);
                xCursor = 1;
            }

            return builder.ToString();

        }

        private string GenerateEmptyRows(int width, int count)
        {
            if (count == 0) return string.Empty;
            StringBuilder rowBuilder = new StringBuilder();
            rowBuilder.Append(ColumnDelimiter.Repeat(width));
            rowBuilder.Append(RowDelimiter);
            return  rowBuilder.ToString().Repeat(count);
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
