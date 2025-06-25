using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GettingExtraPoints()
        {
            LevelController levelController = new LevelController();
            levelController.Player1 = new Player();

            IPowerUp powerUp = levelController.Power;

            GameObject power = powerUp as GameObject;

            bool extraPointsExpected = true;

            bool collision = true;

            bool extraPointsReal = levelController.Player1.extraPointChecker(collision);

            Assert.AreEqual(extraPointsExpected, extraPointsReal);

        }

        [TestMethod]
        public void GettingInitialPositionPlayer()
        {
            LevelController levelController = new LevelController();
            levelController.Player1 = new Player();

            float positionXExpected = 480;

            float positionXReal = levelController.Player1.Transform.PosX;

            Assert.AreEqual(positionXExpected, positionXReal);

        }


        [TestMethod]
        public void GettingWinCondition()
        {
            LevelController levelController = new LevelController();

            int points = 500;

            bool realWin = levelController.WinCheck(points);

            Assert.IsTrue(realWin);

        }

    }
}
