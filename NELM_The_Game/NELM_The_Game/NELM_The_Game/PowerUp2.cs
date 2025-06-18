using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PowerUp2 : GameObject, IPowerUp
    {
        public event Action OnSpecialGain;

        private Animation animation;
        private LevelController levelController;
        public Transform PowerUpTransform => transform;

        private int scale = 32;

        public PowerUp2(float positionX, float positionY, float speedAnimation) //Constructor
        {
            levelController = GameManager.Instance.LevelController;

            transform = new Transform(positionX, positionY, scale, scale); //Se llama a la posición del Power Up

            renderer = new Renderer(transform, "powerup2/powerup20", 9, 0.1f, true);

        }

        public void Update()
        {
            renderer.AnimationUpdate();
            if (CheckCollisions(levelController.Player1.Transform))
            {
                SpecialPower();
            }
        }

        public void SpecialPower()
        {
            levelController.Score.AddPowerUpPoints(70);
            OnSpecialGain?.Invoke();
        }

        public bool CheckCollisions(Transform player)
        {
            float distanceX = Math.Abs((player.PosX + player.ScaleX) - (transform.PosX + transform.ScaleX));
            float distanceY = Math.Abs((player.PosY + player.ScaleY) - (transform.PosY + transform.ScaleY));

            float sumHalfWidth = (player.ScaleX / 2) + (transform.ScaleX / 2);
            float sumHalfHeight = (player.ScaleX / 2) + (transform.ScaleX / 2);

            if (distanceX < sumHalfWidth && distanceY < sumHalfHeight)
            {
                return true;
            }
            else
                return false;
        }

        public void Render()
        {
            Engine.Draw(animation.CurrentImage, transform.PosX, transform.PosY);
        }
    }
}
