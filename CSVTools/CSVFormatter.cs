using System;
using System.Collections.Generic;
using System.IO;
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
            StringBuilder tableBuilder = new StringBuilder();
            int[] size = table.Dimensions;
            int xCursor = 1;
            int yCursor = 1;
            bool rowInserted = false;

            if (table.SpecifyColumnDelimiterInFile)
            {
                tableBuilder.AppendLine($"sep={ColumnDelimiter}");
            }

            foreach (Row row in table.Rows)
            {
                // Add empty rows
                if (rowInserted == false)
                {
                    tableBuilder.Append(GenerateEmptyRow(size[0], row.Position - yCursor));
                }
                else
                {
                    // Remove 1 from the amount of rows to be inserted if we just added a row.
                    tableBuilder.Append(GenerateEmptyRow(size[0], row.Position - yCursor-1));
                    rowInserted = false;
                }
                yCursor = row.Position;

                StringBuilder rowBuilder = new StringBuilder();
                foreach (Cell cell in row.Cells)
                {
                    // Add delimiters to "select" the cell
                    rowBuilder.Append(ColumnDelimiter.Repeat(cell.Position - xCursor));
                    // Add cell data
                    if (cell.GetData() != null) rowInserted = true;
                    rowBuilder.Append(cell);
                    xCursor = cell.Position;
                }
                // Pad to dimensions
                rowBuilder.Append(ColumnDelimiter.Repeat(size[0] - xCursor));
                // Column finished, add row delim
                rowBuilder.Append(RowDelimiter);
                tableBuilder.Append(rowBuilder);
                xCursor = 1;
            }

            return tableBuilder.ToString();

        }

        private string GenerateEmptyRow(int width, int count)
        {
            if (count == 0) return string.Empty;
            StringBuilder rowBuilder = new StringBuilder();
            // Remove one from width since the last column isn't delimited
            rowBuilder.Append(ColumnDelimiter.Repeat(width-1));
            rowBuilder.Append(RowDelimiter);
            return  rowBuilder.ToString().Repeat(count);
        }

        public void SaveToFile(string path, Encoding encoding)
        {
            File.WriteAllText(path, GetCSV(_targetTable), encoding);
        }

        public void SaveToFile(string path)
        {
            SaveToFile(path, Encoding.UTF8);
        }

        public override string ToString()
        {
            return GetCSV(_targetTable);
        }
    }
}
