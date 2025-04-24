using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        } 
    }

    public class Transform
    {
        private Vector2 position;

        private Vector2 scale;

        public float PosX
        {
            get { return position.x; }
            set { position.x = value; }
        }
        public float PosY
        {
            get { return position.y; }
            set { position.y = value; }
        }

        public float ScaleX
        {
            get { return scale.x; }
            set { position.x = value; }
        }
        public float ScaleY
        {
            get { return scale.y; }
            set { position.y = value; }
        }

        public Transform(float positionX, float positionY, float scaleX, float scaleY)
        {
            position.x = positionX;
            position.y = positionY;
            scale.x = scaleX;
            scale.y = scaleY;
        }

        public void Translate(float directionX, float directionY, float speed)
        {
            position.x += directionX * speed;
            position.y += directionY * speed;
        }

    }
}
