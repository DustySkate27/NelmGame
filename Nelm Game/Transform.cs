using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    

    public class Transform
    {

        private Vector2 position;
        private Vector2 scale;

        public float PosX => position.x;
        public float PosY => position.y;

        public float ScaleX => scale.x;
        public float ScaleY => scale.y;


        public Transform(float x, float y, float sX, float sY)
        {
            position = new Vector2(x, y);
            scale = new Vector2(sX, sY);
            position.x -= scale.x/2;
            position.y -= scale.y/2;

        }


        public void Translate(float x, float y, int speed)
        {
            position.x += x * speed;
            position.y += y * speed;
        }

        public void Teleport(float x, float y)
        {
            position.x = x;
            position.y = y;
        }
    }
    
}
