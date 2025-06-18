using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Renderer //Renderiza de forma casi automática lo que se le asigne.
    {
        private Transform transform;
        private string locationInAssets;
        private Animation animation;
        private float speedAnimation;

        public Animation Animation => animation;

        public string LocationInAssets
        {
            set => value = locationInAssets;
        }

        public Renderer(Transform transform, string locationInAssets, int frames, float speedanimation, bool loop) //Prepara la animación a ejecutar
        {

            this.transform = transform;
            this.locationInAssets = locationInAssets;
            this.speedAnimation = speedanimation;

            List<Image> images = new List<Image>(); //Lista de frames

            for (int i = 0; i < frames; i++) //Se cargan los frames
            {
                Image imagen = Engine.LoadImage($"assets/{locationInAssets}{i}.png");
                images.Add(imagen);
            }

            animation = new Animation(images, speedAnimation, loop); //Se añaden a una animación

        }

        public void AnimationUpdate()
        {
            animation.Update();
        }

        public void ChangeAnimation(string locationInAssets, int frames, float speedAnimation) //Modifica en tiempo real la animación en ejecución.
        {
            List<Image> images = new List<Image>();
            for (int i = 0; i < frames; i++) //Se cargan los frames
            {
                Image imagen = Engine.LoadImage($"assets/{locationInAssets}{i}.png");
                images.Add(imagen);
            }
            animation.speedAnimation = speedAnimation;
            animation.images = images;
        }

        public void Render()
        {
            Engine.Draw(animation.CurrentImage, transform.PosX, transform.PosY);
        }
    }
}
