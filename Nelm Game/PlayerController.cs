using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class PlayerController
    {

        public DateTime startTime;

        private Transform transform;

        public PlayerController(Transform trans)
        {
            transform = trans;
        }

        public void Update() 
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;

            if (Engine.GetKey(Engine.KEY_D))
            {
                transform.Translate(1, 0, 5);
            }
            if (Engine.GetKey(Engine.KEY_A))
            {
                transform.Translate(-1, 0, 5);
            }
            if (Engine.GetKey(Engine.KEY_S))
            {
                transform.Translate(0, 1, 5);
            }
            if (Engine.GetKey(Engine.KEY_W))
            {
                transform.Translate(0, -1, 5);
            }
        }
    }
}
