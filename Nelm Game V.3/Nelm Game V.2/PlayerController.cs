using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PlayerController
    {

        private Transform transform;

        private float movementCooldown = 0.2f;
        private float reseter = 0;

        public PlayerController(Transform trans)
        {
            transform = trans;
        }

        public void Update() 
        {
            reseter += Program.DeltaTime;

            if (reseter >= movementCooldown)
            {
                if (Engine.GetKey(Engine.KEY_D))
                {
                    transform.Translate(1, 0, 185);
                    reseter = 0;
                }
                if (Engine.GetKey(Engine.KEY_A))
                {
                    transform.Translate(-1, 0, 185);
                    reseter = 0;
                }
                if (Engine.GetKey(Engine.KEY_S))
                {
                    transform.Translate(0, 1, 140);
                    reseter = 0;
                }
                if (Engine.GetKey(Engine.KEY_W))
                {
                    transform.Translate(0, -1, 140);
                    reseter = 0;
                }
            }

        }
    }
}
