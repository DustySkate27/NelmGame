using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Time
    {
        private static Time instance;

        private float deltaTime;
        private float timeLastFrame;
        private DateTime initialTime;
        public float DeltaTime => deltaTime;

        public DateTime InitialTime => initialTime;

        public static Time Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Time();
                }
                return instance;
            }
        }
        public void Initialize()
        {
            initialTime = DateTime.Now;
        }

        public void Update()
        {
            float currentTime = (float)(DateTime.Now - initialTime).TotalSeconds;
            deltaTime = currentTime - timeLastFrame;
            timeLastFrame = currentTime;
        }

    }
}
