using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    public class Collider //Es un colisionador automático.
    {

        private Transform transform;
        public Collider(Transform transform)
        {
            this.transform = transform;
        }


        public bool CheckCollision(Transform collision) //Devuelve un verdadero o falso, en función de la corroboración que se desee aplicar.
        {

            float distanceX = Math.Abs((collision.PosX + collision.ScaleX) - (transform.PosX + transform.ScaleX));
            float distanceY = Math.Abs((collision.PosY + collision.ScaleY) - (transform.PosY + transform.ScaleY));

            float sumHalfWidth = (collision.ScaleX / 2) + (transform.ScaleX / 2);
            float sumHalfHeight = (collision.ScaleX / 2) + (transform.ScaleX / 2);

            if (distanceX < sumHalfWidth && distanceY < sumHalfHeight)
            {
                return true;
            }
            else 
                return false;

        }

    }
}
