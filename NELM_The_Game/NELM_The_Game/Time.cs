using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    static class Time
    {
        private static float deltaTime;
        private static float timeLastFrame;
        private static DateTime initialTime;
        public static float DeltaTime => deltaTime;

        public static DateTime InitialTime => initialTime;
        public static void Initialize() //Inicializador de tiempo.
        {
            initialTime = DateTime.Now;
        }

        public static void Update()
        {
            float currentTime = (float)(DateTime.Now - initialTime).TotalSeconds; //Se define el tiempo actual
            deltaTime = currentTime - timeLastFrame; // Se calcula al diferencia del tiempo actual con la instancia requerida.
            timeLastFrame = currentTime; // Se marca una instancia X.
        }

    }
}

/*
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

            int numbExpected = 500;

            int numberReal = 500;

            Assert.AreEqual(numbExpected, numberReal);
        }
    }
}
*/
