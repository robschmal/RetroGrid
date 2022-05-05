namespace RetroGrid
{
    /// <summary>
    /// The grid made up of <see cref="Tile"> objects along it's X and Y axis.
    /// </summary>
    public class Grid
    {
        public Grid(int rows, int columns)
        {
            Tiles = new Tile[rows, columns];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    Tiles[y, x] = new Tile(y, x);
                }
            }
        }

        public Tile[,] Tiles { get; set; }
    }
}
