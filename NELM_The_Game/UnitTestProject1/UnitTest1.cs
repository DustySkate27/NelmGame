using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //TEST DE REFERENCIA

        //[TestMethod]
        //public void GettingInvincibility()
        //{
        //    LevelController levelController = new LevelController();
        //    levelController.Player1 = new Player();

        //    levelController.Player1.PlayerController.Invincibility = true;

        //    bool resultadoEsperado = true;
        //    bool resultadoReal = levelController.Player1.TestGetInvincibility();

        //    Assert.AreEqual(resultadoEsperado,resultadoReal);
        //}

        [TestMethod]
        public void GettingExtraPoints()
        {
            LevelController levelController = new LevelController();
            levelController.Player1 = new Player();

            IPowerUp powerUp = levelController.Power;

            GameObject power = powerUp as GameObject;

            bool extraPointsExpected = false;

            bool collision = false;

            bool extraPointsReal = levelController.Player1.extraPointChecker(collision);

            Assert.AreEqual(extraPointsExpected, extraPointsReal);

        }


        [TestMethod]
        public void Getting()
        {
            LevelController levelController = new LevelController();
            levelController.Score = new Score();

            int numberExpected = 15;

            int numberReal = levelController.Score.AddPointsChecker(15);

            Assert.AreEqual(numberExpected, numberReal);
        }
    }
}
