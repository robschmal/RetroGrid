namespace RetroGrid
{
    /// <summary>
    /// Class that represents a cell in the <see cref="Grid">
    /// </summary>
    public class Tile
    {
        public Tile(int row, int column)
        {
            RowY = row;
            ColumnX = column;
        }

        public int RowY { get; set; }
        public int ColumnX { get; set; }
        public int Value { get; set; } = 0;
        public bool IsFibonacciNumber { get; set; }
        public string CssClass { get; set; }
        
        // Do not show the value if it's 0.
        public override string ToString()
        {
            string value = Value <= 0 ? string.Empty : Value.ToString();
            return value;
        }
    }
}
