using DogeGameLogics;
using DogeGameLogics.Logic;
using System;
using System.Text;

namespace DogeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new GameBoard(GameLogics.LogicsBuilder()
                    .SetHeigth(10)
                    .SetWidth(10)
                    .Cyclic()
                    .NumberOfEnemies(5)
                    .Build());
            Console.WriteLine(ToMatrixString(g.GetState()));
            Console.WriteLine("\n");
            while(g.GetGameStatus() != GameStatus.Lose)
            {
                g.Update(Direction.Down);
                Console.WriteLine(ToMatrixString(g.GetState()));
            }
            
        }

        public static string ToMatrixString(int[,] matrix, string delimiter = "\t")
        {
            var s = new StringBuilder();

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    s.Append(matrix[i, j]).Append(delimiter);
                }

                s.AppendLine();
            }

            return s.ToString();
        }
    }
}
