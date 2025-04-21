using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Player
    {
        private Transform transform;
        private Image idle = Engine.LoadImage("assets/animations/tipitoIdle.png");
        private Animation animation;
        private Animation idleAnimation;

        private PlayerController playerController;

        

        public Player(float x, float y)
        {
            transform = new Transform(x, y, 100, 100);
            playerController = new PlayerController(transform);

            List<Image> images = new List<Image>();

            for (int i = 0; i < 2; i++)
            {
                images.Add(Engine.LoadImage($"assets/animations/soldier_walk/Soldier_walk{i}.png"));
            }

            animation = new Animation(images, 0.1f, true);

            List<Image> idleAnim = new List<Image>();

            for (int i = 0; i < 6; i++)
            {
                idleAnim.Add(Engine.LoadImage($"assets/animations/soldier_idle/Soldier_idle{i}.png"));
            }

            idleAnimation = new Animation(idleAnim, 0.1f, true);


        }

        public void Update()
        {
            playerController.Update();

            if (playerController.IsMooving == false)
            {
                idleAnimation.Update();
            }

            animation.Update();
        }

        public void Render()
        {
            if (playerController.IsMooving == false)
                Engine.Draw(idleAnimation.currentImage, transform.PosX, transform.PosY);
            else
                Engine.Draw(animation.currentImage, transform.PosX, transform.PosY);

        }


    }

}

// PascalCase  => Clases, métodos
// camelCase   => atributos
