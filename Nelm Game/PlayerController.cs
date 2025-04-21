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

        private bool isMooving = false;

        public bool IsMooving => isMooving;

        public PlayerController(Transform transform)
        {
            this.transform = transform;

            
        }

        public void Update()
        {
            Movement();
            
        }

        private void Movement()
        {
            if (Engine.GetKey(Engine.KEY_D))
            {
                transform.Translate(1, 0, 3);
                isMooving = true;
            }
            else if (Engine.GetKey(Engine.KEY_A))
            {
                transform.Translate(-1, 0, 3);
                isMooving = true;
            }
            else if (Engine.GetKey(Engine.KEY_S))
            {
                transform.Translate(0, 1, 4);
                isMooving = true;
            }
            else if (Engine.GetKey(Engine.KEY_W))
            {
                transform.Translate(0, -1, 4);
                isMooving = true;
            }
            else
                isMooving = false;
        }

    }
}
