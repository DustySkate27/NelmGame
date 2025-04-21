using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Animation
    {
        private List<Image> images;
        private float speedAnimation;
        private bool isLooping;
        private int currentFrame;
        private float currentTime;

        public Image currentImage => images[currentFrame];

        public Animation(List<Image> images, float speedAnimation, bool isLooping)
        {
            this.images = images;
            this.speedAnimation = speedAnimation;
            this.isLooping = isLooping;
        }

        public void Update()
        {
            currentTime += Program.DeltaTime;

            if (currentTime >= speedAnimation)
            {
                currentFrame++;
                currentTime = 0;

                if (currentFrame >= images.Count)
                {
                    if (isLooping)
                    {
                        currentFrame = 0;
                    }
                    else
                    {
                        currentFrame = images.Count - 1;
                    }
                }
            }
        }
    }
}
