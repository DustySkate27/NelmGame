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

        private PlayerController playerController;

        

        public Player(float x, float y)
        {
            transform = new Transform(x, y, 128, 128);
            playerController = new PlayerController(transform);

            List<Image> images = new List<Image>();

            for (int i = 0; i < 2; i++)
            {
                images.Add(Engine.LoadImage($"assets/animations/tipiM0{i}.png"));
            }

            animation = new Animation(images, 0.1f, true);

        }

        public void Update()
        {
            playerController.Update();
            animation.Update();
        }

        public void Render()
        {
            if (playerController.IsMooving == false)
                Engine.Draw(idle, transform.PosX, transform.PosY);
            else
                Engine.Draw(animation.currentImage, transform.PosX, transform.PosY);

        }


    }

}

// PascalCase  => Clases, métodos
// camelCase   => atributos
