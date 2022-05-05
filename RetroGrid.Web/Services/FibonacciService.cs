using System;
using System.Collections.Generic;

namespace RetroGrid
{
    /// <summary>
    /// Service to provide calculations for Fibonacci numbers and sequences.
    /// </summary>
    public class FibonacciService
    {
        /// <summary>
        /// Checks if the given number belongs to the Fibonacci sequence.
        /// </summary>
        /// <param name="number">The given number.</param>
        /// <returns> True if the number belongs to the Fibonacci sequence, or false otherwise</returns>
        public static bool IsFibonacciNumber(long number)
        {
            if (number == 0)
                return false;

            double root5 = Math.Sqrt(5);
            double phi = (1 + root5) / 2;

            long idx = (long)Math.Floor(Math.Log(number * root5) / Math.Log(phi) + 0.5);
            long u = (long)Math.Floor(Math.Pow(phi, idx) / root5 + 0.5);

            return (u == number);
        }

        /// <summary>
        /// Checks if there are Fibonacci sequences of at least 5 numbers in each row of tiles.
        /// </summary>
        /// <param name="tiles">Double array of <see cref="Tile"> objects</param>
        /// <returns> Tuples with the grid's X and Y coordinates of the tiles belonging to a Fibonacci sequence</returns>
        public static List<Tuple<int, int>> GetFibonacciSequenceRecords(Tile[,] tiles)
        {
            var sequenceRecords = new List<Tuple<int, int>>();
            int sequenceCounter = 2;
            int lastRow = 0;

            foreach (Tile tile in tiles)
            {
                // No need to start checking non-Fibonacci numbers or when there are not enough previous tiles to determine sequence.
                if (!tile.IsFibonacciNumber || tile.ColumnX < 2)
                    continue;

                int rowIndex = tile.RowY;
                int columnIndex = tile.ColumnX;

                // A new row starts a new sequence.
                if (rowIndex != lastRow)
                    sequenceCounter = 2;

                int currentValue = tile.Value;
                int previousValue1 = tiles[rowIndex, columnIndex - 1].Value;
                int previousValue2 = tiles[rowIndex, columnIndex - 2].Value;

                if (previousValue1 + previousValue2 != currentValue || previousValue1 == 0 || previousValue2 == 0)
                {
                    // When the sequence breaks.
                    // Reset the counter to start determining the next sequence.
                    sequenceCounter = 2;
                    continue;
                }

                sequenceCounter++;
                if (sequenceCounter == 5)
                {
                    sequenceRecords.Add(Tuple.Create(rowIndex, columnIndex - 4));
                    sequenceRecords.Add(Tuple.Create(rowIndex, columnIndex - 3));
                    sequenceRecords.Add(Tuple.Create(rowIndex, columnIndex - 2));
                    sequenceRecords.Add(Tuple.Create(rowIndex, columnIndex - 1));
                    sequenceRecords.Add(Tuple.Create(rowIndex, columnIndex));
                }
                if (sequenceCounter > 5)
                {
                    sequenceRecords.Add(Tuple.Create(rowIndex, columnIndex));
                }
                lastRow = tile.RowY;
            }

            return sequenceRecords;
        }
    }
}
