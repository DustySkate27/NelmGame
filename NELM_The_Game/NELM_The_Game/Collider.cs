using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    public class Collider 
    {

        private Transform transform;
        public Collider(Transform transform)
        {
            this.transform = transform;
        }


        public bool CheckCollision(Transform collision) 
        {

            float distanceX = Math.Abs((collision.PosX + collision.ScaleX) - (transform.PosX + transform.ScaleX));
            float distanceY = Math.Abs((collision.PosY + collision.ScaleY) - (transform.PosY + transform.ScaleY));

            float sumHalfWidth = (collision.ScaleX / 2) + (transform.ScaleX / 2);
            float sumHalfHeight = (collision.ScaleY / 2) + (transform.ScaleY / 2);

            if (distanceX < sumHalfWidth && distanceY < sumHalfHeight)
            {
                return true;
            }
            else 
                return false;

        }

    }
}
