using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
            get => position.x; 
            set => position.x = value;
        }
        public float PosY
        {
            get => position.y; 
            set => position.y = value;
        }

        public float ScaleX
        {
            get => scale.x;
            set => scale.x = value;
        }
        public float ScaleY
        {
            get => scale.y;
            set => scale.y = value;
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
            position.x += directionX * speed * Time.DeltaTime;
            position.y += directionY * speed * Time.DeltaTime;
        }

        public void TranslateJump(float directionX, float directionY, float speed)
        {
            position.x += directionX * speed;
            position.y += directionY * speed;
        }

        public void Translate(float directionX, float directionY)
        {
            position.x += directionX;
            position.y += directionY;
        }
    }
}
