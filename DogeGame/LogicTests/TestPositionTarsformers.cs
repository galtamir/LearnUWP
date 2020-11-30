using DodgeGameLogics.Logic;
using DodgeGameLogics.Logic.PositionTarsformers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTests
{
    [TestClass]
    public class TestPositionTarsformers
    {
        [TestMethod]
        public void BoardInitCycle()
        {

            IPositionTarsformer PositionTarsformer = new CyclicTarsformer(3, 3);
            Assert.AreEqual(new Position { Height = 0, Width = 1 }, PositionTarsformer.Right(new Position { Height = 0, Width = 0 }));
            Assert.AreEqual(new Position { Height = 0, Width = 2 }, PositionTarsformer.Right(new Position { Height = 0, Width = 1 }));
            Assert.AreEqual(new Position { Height = 0, Width = 0 }, PositionTarsformer.Right(new Position { Height = 0, Width = 2 }));

            Assert.AreEqual(new Position { Height = 0, Width = 2 }, PositionTarsformer.Left(new Position { Height = 0, Width = 0 }));
            Assert.AreEqual(new Position { Height = 0, Width = 1 }, PositionTarsformer.Left(new Position { Height = 0, Width = 2 }));
            Assert.AreEqual(new Position { Height = 0, Width = 0 }, PositionTarsformer.Left(new Position { Height = 0, Width = 1 }));


            Assert.AreEqual(new Position { Height = 2, Width = 0 }, PositionTarsformer.Up(new Position { Height = 0, Width = 0 }));
            Assert.AreEqual(new Position { Height = 1, Width = 0 }, PositionTarsformer.Up(new Position { Height = 2, Width = 0 }));
            Assert.AreEqual(new Position { Height = 0, Width = 0 }, PositionTarsformer.Up(new Position { Height = 1, Width = 0 }));

            Assert.AreEqual(new Position { Height = 1, Width = 0 }, PositionTarsformer.Down(new Position { Height = 0, Width = 0 }));
            Assert.AreEqual(new Position { Height = 2, Width = 0 }, PositionTarsformer.Down(new Position { Height = 1, Width = 0 }));
            Assert.AreEqual(new Position { Height = 0, Width = 0 }, PositionTarsformer.Down(new Position { Height = 2, Width = 0 }));
        }

        [TestMethod]
        public void BoardInitNonCycle()
        {
            IPositionTarsformer PositionTarsformer = new NonCyclicTarsformer(3, 3);

            Assert.AreEqual(new Position { Height = 0, Width = 1 }, PositionTarsformer.Right(new Position{ Height =0, Width = 0}));
            Assert.AreEqual(new Position { Height = 0, Width = 2 }, PositionTarsformer.Right(new Position { Height = 0, Width = 1 }));
            Assert.AreEqual(new Position { Height = 0, Width = 2 }, PositionTarsformer.Right(new Position { Height = 0, Width = 2 }));

            Assert.AreEqual(new Position { Height = 0, Width = 0 }, PositionTarsformer.Left(new Position { Height = 0, Width = 0 }));
            Assert.AreEqual(new Position { Height = 0, Width = 1 }, PositionTarsformer.Left(new Position { Height = 0, Width = 2 }));
            Assert.AreEqual(new Position { Height = 0, Width = 0 }, PositionTarsformer.Left(new Position { Height = 0, Width = 1 }));


            Assert.AreEqual(new Position { Height = 0, Width = 0 }, PositionTarsformer.Up(new Position { Height = 0, Width = 0 }));
            Assert.AreEqual(new Position { Height = 1, Width = 0 }, PositionTarsformer.Up(new Position { Height = 2, Width = 0 }));
            Assert.AreEqual(new Position { Height = 0, Width = 0 }, PositionTarsformer.Up(new Position { Height = 1, Width = 0 }));

            Assert.AreEqual(new Position { Height = 1, Width = 0 }, PositionTarsformer.Down(new Position { Height = 0, Width = 0 }));
            Assert.AreEqual(new Position { Height = 2, Width = 0 }, PositionTarsformer.Down(new Position { Height = 1, Width = 0 }));
            Assert.AreEqual(new Position { Height = 2, Width = 0 }, PositionTarsformer.Down(new Position { Height = 2, Width = 0 }));
        }
    }
}
