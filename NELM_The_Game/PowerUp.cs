using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PowerUp
    {
        private Transform powerUpTransform;
        private Animation currentAnimation;

        private Score score;

        public Transform PowerUpTransform => powerUpTransform;

        public PowerUp(float positionX, float positionY)
        {
            powerUpTransform = new Transform(positionX, positionY, 32, 32);

            List<Image> powerUpFrames = new List<Image>();

            for (int i = 0; i < 12; i++)
            {
                Image frames = Engine.LoadImage($"assets/powerup/powerup0{i}.png");
                powerUpFrames.Add(frames);
            }

            currentAnimation = new Animation(powerUpFrames, 0.1f, true);
            score = new Score();
        }

        public void Update()
        {
            currentAnimation.Update();
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentImage, powerUpTransform.PosX, powerUpTransform.PosY);
        }
    }
}