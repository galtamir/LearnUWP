namespace DogeGame
{
    internal interface IPiece
    {
        int ID { get; }

        int Height { get; }

        int Width { get; }

        void Update(IPiece _Player, Direction playersDirection);
    }
}