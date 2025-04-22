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
            ChangeBlock();
        }

        private void Movement()
        {
            if (Engine.GetKey(Engine.KEY_D))
            {
                transform.Translate(1, 0, 8);
                isMooving = true;
            }
            else if (Engine.GetKey(Engine.KEY_A))
            {
                transform.Translate(-1, 0, 8);
                isMooving = true;
            }
            else if (Engine.GetKey(Engine.KEY_S))
            {
                transform.Translate(0, 1, 8);
                isMooving = true;
            }
            else if (Engine.GetKey(Engine.KEY_W))
            {
                transform.Translate(0, -1, 8);
                isMooving = true;
            }
            else
                isMooving = false;
        }

        private void ChangeBlock()
        {
            if (Engine.GetKey(Engine.KEY_UP))
            {
                transform.Teleport(256, 192);
            }
            else if (Engine.GetKey(Engine.KEY_DOWN))
            {
                transform.Teleport(256, 576);
            }
            else if (Engine.GetKey(Engine.KEY_RIGHT))
            {
                transform.Teleport(576, 192);
            }
            else if (Engine.GetKey(Engine.KEY_LEFT))
            {
                transform.Teleport(576, 576);
            }
        }

    }
}
