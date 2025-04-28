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
        public static void Initialize()
        {
            initialTime = DateTime.Now;
        }

        public static void Update()
        {
            float currentTime = (float)(DateTime.Now - initialTime).TotalSeconds;
            deltaTime = currentTime - timeLastFrame;
            timeLastFrame = currentTime;
        }

    }
}
