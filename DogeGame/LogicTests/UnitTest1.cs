using DogeGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BoardInitCycle()
        {
            GameBoard board = new GameBoard(new GameLogics { BoardHigth = 3, BoardWith = 3, IsBoardCyclic = true });

            Assert.AreEqual(board.Board[0, 1], board.Board[0, 0].Right);
            Assert.AreEqual(board.Board[0, 2], board.Board[0, 1].Right);
            Assert.AreEqual(board.Board[0, 0], board.Board[0, 2].Right);

            Assert.AreEqual(board.Board[0, 2], board.Board[0, 0].Left);
            Assert.AreEqual(board.Board[0, 1], board.Board[0, 2].Left);
            Assert.AreEqual(board.Board[0, 0], board.Board[0, 1].Left);


            Assert.AreEqual(board.Board[2, 0], board.Board[0, 0].Up);
            Assert.AreEqual(board.Board[1, 0], board.Board[2, 0].Up);
            Assert.AreEqual(board.Board[0, 0], board.Board[1, 0].Up);

            Assert.AreEqual(board.Board[1, 0], board.Board[0, 0].Down);
            Assert.AreEqual(board.Board[2, 0], board.Board[1, 0].Down);
            Assert.AreEqual(board.Board[0, 0], board.Board[2, 0].Down);
        }

        [TestMethod]
        public void BoardInitNonCycle()
        {
            GameBoard board = new GameBoard(new GameLogics { BoardHigth = 3, BoardWith = 3, IsBoardCyclic = false });

            Assert.AreEqual(board.Board[0, 1], board.Board[0, 0].Right);
            Assert.AreEqual(board.Board[0, 2], board.Board[0, 1].Right);
            Assert.AreEqual(board.Board[0, 2], board.Board[0, 2].Right);

            Assert.AreEqual(board.Board[0, 0], board.Board[0, 0].Left);
            Assert.AreEqual(board.Board[0, 1], board.Board[0, 2].Left);
            Assert.AreEqual(board.Board[0, 0], board.Board[0, 1].Left);


            Assert.AreEqual(board.Board[0, 0], board.Board[0, 0].Up);
            Assert.AreEqual(board.Board[1, 0], board.Board[2, 0].Up);
            Assert.AreEqual(board.Board[0, 0], board.Board[1, 0].Up);

            Assert.AreEqual(board.Board[1, 0], board.Board[0, 0].Down);
            Assert.AreEqual(board.Board[2, 0], board.Board[1, 0].Down);
            Assert.AreEqual(board.Board[2, 0], board.Board[2, 0].Down);
        }
    }
}
