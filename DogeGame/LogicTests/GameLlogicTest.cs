using DogeGameLogics.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTests
{
    [TestClass]
    public class GameLlogicTest
    {
        [TestMethod]
        public void BoardInitCycle()
        {
            GameLogics g = GameLogics.LogicsBuilder()
                .SetHeigth(50)
                .SetWidth(70)
                .Cyclic(true)
                .NumberOfEnemies(5)
                .BuildLogics();
            Assert.AreEqual(50, g.BoardHiegth);
            Assert.AreEqual(70, g.BoardWidth);
            Assert.AreEqual(5, g.CreateEnemies().Count);
        }
    }
}
