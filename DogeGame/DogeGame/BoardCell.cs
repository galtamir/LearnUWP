namespace DogeGame
{
    public class BoardCell
    {
        public BoardCell Up { get; internal set; }
        public BoardCell Left { get; internal set; }
        public BoardCell Down { get; internal set; }
        public BoardCell Right { get; internal set; }

        public int Height;
        public int Width;

        public BoardCell(int i, int j)
        {
            Width = i;
            Height = j;
        }

        public override string ToString()
        {
            return $"({Width},{Height})";
        }

    }
}