using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GettingInvincibility()
        {
            LevelController levelController = new LevelController();
            levelController.Player1 = new Player();

            levelController.Player1.PlayerController.Invincibility = true;

            bool resultadoEsperado = true;
            bool resultadoReal = levelController.Player1.TestGetInvincibility();


            Assert.AreEqual(resultadoEsperado,resultadoReal);
        }

        [TestMethod]
        public void 
    }
}
